using DMS.GLSL.Contracts;
using GLSLhelper;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;

namespace DMS.GLSL.Errors
{
	internal class SquiggleTagger : ITagger<IErrorTag>
	{
		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
		private readonly List<ITagSpan<IErrorTag>> _tags = new List<ITagSpan<IErrorTag>>();
		private readonly ITextBuffer _buffer;
		private readonly string _filePath;

		internal SquiggleTagger(ITextBuffer buffer)
		{
			_buffer = buffer;
			if (buffer.Properties.TryGetProperty(typeof(ITextDocument), out ITextDocument document))
			{
				_filePath = document.FilePath;
			}
		}

		public IEnumerable<ITagSpan<IErrorTag>> GetTags(NormalizedSnapshotSpanCollection inputSpans) => _tags;

		public void UpdateErrors(IEnumerable<ShaderLogLine> errorLog)
		{
			_tags.Clear();
			ErrorList.GetInstance().Clear();

			foreach (var error in errorLog)
			{
				var lineNumber = error.LineNumber.HasValue ? error.LineNumber.Value - 1 : 0;
				ErrorList.GetInstance().Write(error.Message, lineNumber, _filePath, error.Type);

				var lineSpan = _buffer.CurrentSnapshot.GetLineFromLineNumber(lineNumber).Extent; //TODO: parse error.message for offending words to trim down span
				var tag = new ErrorTag(ConvertErrorType(error.Type), error.Message);
				_tags.Add(new TagSpan<IErrorTag>(lineSpan, tag));
			}
			var span = new SnapshotSpan(_buffer.CurrentSnapshot, 0, _buffer.CurrentSnapshot.Length);
			TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(span));
		}

		private static string ConvertErrorType(MessageType type)
		{
			switch (type)
			{
			case MessageType.Error:
				return PredefinedErrorTypeNames.SyntaxError;
			case MessageType.Warning:
				return PredefinedErrorTypeNames.Warning;
			default:
				return PredefinedErrorTypeNames.Suggestion;
			}
		}
	}
}
