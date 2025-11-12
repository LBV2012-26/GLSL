using DMS.GLSL.Contracts;
using GLSLhelper;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Collections.Generic;

namespace DMS.GLSL.Classification
{
	internal class SyntaxColorParser : ISyntaxColorParser
	{
		private readonly GlslParser _parser;
		private readonly Dictionary<string, IClassificationType> _userKeywords = new Dictionary<string, IClassificationType>();

		private IClassificationType Comment { get; }
		private IClassificationType Identifier { get; }
		private IClassificationType Number { get; }
		private IClassificationType Operator { get; }
		private IClassificationType QuotedString { get; }
		private IClassificationType PreprocessorKeyword { get; }
		private IClassificationType Function { get; }
		private IClassificationType Keyword { get; }
		private IClassificationType UserKeyword1 { get; }
		private IClassificationType UserKeyword2 { get; }
		private IClassificationType BuiltInVariable { get; }
		private IClassificationType UserVariable { get; }
		private IClassificationType GlobalVariable { get; }
		private IClassificationType FunctionParameter { get; }
		private IClassificationType MemberVariable { get; }
		private IClassificationType ControlKeyword { get; }
		private IClassificationType UserDefinedType { get; }
		private IClassificationType CompoundType { get; }
		private IClassificationType Macro { get; }
		private IClassificationType InactiveMacro { get; }

		public SyntaxColorParser(IClassificationTypeRegistryService classificationTypeRegistry, IUserKeywords userKeywords)
		{
			if (classificationTypeRegistry is null)
			{
				throw new System.ArgumentNullException(nameof(classificationTypeRegistry));
			}

			if (userKeywords is null)
			{
				throw new System.ArgumentNullException(nameof(userKeywords));
			}

			Comment             = classificationTypeRegistry.GetClassificationType(PredefinedClassificationTypeNames.Comment);
			Identifier          = classificationTypeRegistry.GetClassificationType(PredefinedClassificationTypeNames.Identifier);
			Number              = classificationTypeRegistry.GetClassificationType(PredefinedClassificationTypeNames.Number);
			Operator            = classificationTypeRegistry.GetClassificationType(PredefinedClassificationTypeNames.Operator);
			QuotedString        = classificationTypeRegistry.GetClassificationType(PredefinedClassificationTypeNames.String);
			PreprocessorKeyword = classificationTypeRegistry.GetClassificationType(PredefinedClassificationTypeNames.PreprocessorKeyword);

			Function            = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.Function);
			Keyword             = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.Keyword);
			UserKeyword1        = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.UserKeyword1);
			UserKeyword2        = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.UserKeyword2);
			BuiltInVariable     = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.BuiltInVariable);
			UserVariable        = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.UserVariable);
			GlobalVariable      = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.GlobalVariable);
			FunctionParameter   = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.FunctionParameter);
			MemberVariable      = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.MemberVariable);
			ControlKeyword      = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.ControlKeyword);
			UserDefinedType     = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.UserDefinedType);
			CompoundType        = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.CompoundType);
			Macro               = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.Macro);
			InactiveMacro       = classificationTypeRegistry.GetClassificationType(GlslClassificationTypes.InactiveMacro);

			_parser = new GlslParser();

			userKeywords.PropertyChanged += (s, a) =>
			{
				ResetUserKeywords(userKeywords);
				Changed?.Invoke(this);
			};

			ResetUserKeywords(userKeywords);
		}

		public delegate void ChangedEventHandler(object sender);
		public event ChangedEventHandler Changed;

		public IList<ClassificationSpan> CalculateSpans(SnapshotSpan snapshotSpan)
		{
			var output = new List<ClassificationSpan>();
			var text   = snapshotSpan.GetText();
			foreach (var token in _parser.Tokenize(text))
			{
				var lineSpan = new SnapshotSpan(snapshotSpan.Snapshot, token.Start, token.Length);
				output.Add(new ClassificationSpan(lineSpan, Convert(token)));
			}

			return output;
		}

		private void ResetUserKeywords(IUserKeywords userKeywords)
		{
			_userKeywords.Clear();
			foreach (var word in userKeywords.UserKeywordArray1) _userKeywords[word] = UserKeyword1;
			foreach (var word in userKeywords.UserKeywordArray2) _userKeywords[word] = UserKeyword2;
		}

		private IClassificationType Convert(IToken token)
		{
			IClassificationType CheckUserDefined(IToken currentToken, IClassificationType defaultType)
			{
				return _userKeywords.TryGetValue(currentToken.Value, out var type) ? type : defaultType;
			}

			switch (token.Type)
			{
			case TokenType.Comment:
				return Comment;
			case TokenType.Function:
				return CheckUserDefined(token, Function);
			case TokenType.Keyword:
				return CheckUserDefined(token, Keyword);
			case TokenType.ControlKeyword:
				return CheckUserDefined(token, ControlKeyword);
			case TokenType.UserDefinedType:
				return CheckUserDefined(token, UserDefinedType);
			case TokenType.CompoundType:
				return CheckUserDefined(token, CompoundType);
			case TokenType.BuiltInVariable:
				return CheckUserDefined(token, BuiltInVariable);
			case TokenType.UserVariable:
				return CheckUserDefined(token, UserVariable);
			case TokenType.GlobalVariable:
				return CheckUserDefined(token, GlobalVariable);
			case TokenType.FunctionParameter:
				return CheckUserDefined(token, FunctionParameter);
			case TokenType.MemberVariable:
				return CheckUserDefined(token, MemberVariable);
			case TokenType.Number:
				return Number;
			case TokenType.Operator:
				return Operator;
			case TokenType.Preprocessor:
				return PreprocessorKeyword;
			case TokenType.Identifier:
				return CheckUserDefined(token, Identifier);
			case TokenType.QuotedString:
				return QuotedString;
			case TokenType.Macro:
				return Macro;
			case TokenType.InactiveMacro:
				return InactiveMacro;
			default:
				return Identifier;
			}
		}
	}
}
