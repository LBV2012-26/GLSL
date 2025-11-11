using DMS.GLSL.Contracts;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace DMS.GLSL.Classification
{
	[Export(typeof(IClassifierProvider))]
	[ContentType("glslShader")]
	[TagType(typeof(ClassificationTag))]
	internal class GlslClassifierProvider : IClassifierProvider
	{
		[ImportingConstructor]
		public GlslClassifierProvider(IClassificationTypeRegistryService classificationTypeRegistry, ILogger logger, IUserKeywords userKeywords)
		{
			if (classificationTypeRegistry is null)
			{
				throw new System.ArgumentNullException(nameof(classificationTypeRegistry));
			}

			if (userKeywords is null)
			{
				throw new System.ArgumentNullException(nameof(userKeywords));
			}

			_logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
			_parser = new SyntaxColorParser(classificationTypeRegistry, userKeywords);
		}

		public IClassifier GetClassifier(ITextBuffer textBuffer)
		{
			// per buffer classifier
			return textBuffer.Properties.GetOrCreateSingletonProperty(() => new GlslClassifier(textBuffer, _parser, _logger));
		}

		private readonly ILogger _logger;
		private readonly SyntaxColorParser _parser;
	}
}
