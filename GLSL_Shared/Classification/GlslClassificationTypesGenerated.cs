
namespace DMS.GLSL.Classification
{
	using Microsoft.VisualStudio.Language.StandardClassification;
	using Microsoft.VisualStudio.Text.Classification;
	using Microsoft.VisualStudio.Utilities;
	using System.ComponentModel.Composition;

	internal static class GlslClassificationTypes
	{
	
		public const string Function = nameof(_glslFunction);
	
		public const string Keyword = nameof(_glslKeyword);
	
		public const string ControlKeyword = nameof(_glslControlKeyword);
	
		public const string BuiltInVariable = nameof(_glslBuiltInVariable);
	
		public const string UserVariable = nameof(_glslUserVariable);
	
		public const string UserDefinedType = nameof(_glslUserDefinedType);
	
		public const string UserKeyword1 = nameof(_glslUserKeyword1);
	
		public const string UserKeyword2 = nameof(_glslUserKeyword2);
	
#pragma warning disable 169 //never used warning
	
		[Export]
		[Name(Function)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslFunction;
	
		[Export]
		[Name(Keyword)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslKeyword;
	
		[Export]
		[Name(ControlKeyword)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslControlKeyword;
	
		[Export]
		[Name(BuiltInVariable)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslBuiltInVariable;
	
		[Export]
		[Name(UserVariable)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserVariable;
	
		[Export]
		[Name(UserDefinedType)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserDefinedType;
	
		[Export]
		[Name(UserKeyword1)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserKeyword1;
	
		[Export]
		[Name(UserKeyword2)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserKeyword2;
	
#pragma warning restore 169 //never used warning
	}
}
