using DMS.GLSL.Contracts;
using GLSLhelper;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Reactive.Linq;

namespace DMS.GLSL.Errors
{
	[Export(typeof(IViewTaggerProvider))]
	[ContentType("glslShader")]
	[TagType(typeof(ErrorTag))]
	internal class SquiggleTaggerProvider : IViewTaggerProvider
	{
		[ImportingConstructor]
		public SquiggleTaggerProvider(ShaderCompiler shaderCompiler, ICompilerSettings settings, ILogger logger)
		{
			_shaderCompiler = shaderCompiler ?? throw new ArgumentNullException(nameof(shaderCompiler));
			_settings = settings ?? throw new ArgumentNullException(nameof(settings));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
		{
			//Debug.WriteLine($"CreateTagger: textView={textView}, buffer={buffer}");

			// Make sure we are only tagging the top buffer
			if (!ReferenceEquals(buffer, textView.TextBuffer))
				return null;

			return buffer.Properties.GetOrCreateSingletonProperty(() =>
			{
				var tagger = new SquiggleTagger(buffer);
				var shaderType = buffer.ContentType.TypeName;
				var observableSourceCode = Observable.Return(buffer.CurrentSnapshot.GetText()).Concat(
						Observable.FromEventPattern<TextContentChangedEventArgs>(h => buffer.Changed += h, h => buffer.Changed -= h)
						.Select(e => e.EventArgs.After.GetText()));

				void RequestCompileShader(string shaderCode)
				{
					//if not currently compiling then compile shader from changed text otherwise add to the "to be compiled" list
					if (_settings.LiveCompiling)
					{
						var filePath = GetFilePath(buffer);
						try
						{
							if (!File.Exists(filePath))
								return;
							
							var dir  = Path.GetDirectoryName(filePath);
							var name = Path.GetFileName(filePath);
							_shaderCompiler.RequestCompile(shaderCode, shaderType, tagger.UpdateErrors, dir, name);
						}
						catch (SystemException ex)
						{
							_logger.Log(ex.Message);
						}
					}
					else
					{
						tagger.UpdateErrors(new List<ShaderLogLine>());
					}
				}

				observableSourceCode.Throttle(TimeSpan.FromSeconds(_settings.CompileDelay * 0.001f))
									.Subscribe(sourceCode => RequestCompileShader(sourceCode));

				return tagger;

			}) as ITagger<T>;
		}

		private readonly ShaderCompiler _shaderCompiler;
		private readonly ICompilerSettings _settings;
		private readonly ILogger _logger;

		private static string GetFilePath(ITextBuffer textBuffer)
		{
			foreach (var prop in textBuffer.Properties.PropertyList)
			{
				if (!(prop.Value is ITextDocument doc))
					continue;
				return doc.FilePath;
			}
			return string.Empty;
		}
	}
}
