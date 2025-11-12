
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
	
		public const string GlobalVariable = nameof(_glslGlobalVariable);
	
		public const string FunctionParameter = nameof(_glslFunctionParameter);
	
		public const string MemberVariable = nameof(_glslMemberVariable);
	
		public const string UserDefinedType = nameof(_glslUserDefinedType);
	
		public const string CompoundType = nameof(_glslCompoundType);
	
		public const string UserKeyword1 = nameof(_glslUserKeyword1);
	
		public const string UserKeyword2 = nameof(_glslUserKeyword2);
	
		public const string Macro = nameof(_glslMacro);
	
		public const string InactiveMacro = nameof(_glslInactiveMacro);
	
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
		[Name(GlobalVariable)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslGlobalVariable;
	
		[Export]
		[Name(FunctionParameter)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslFunctionParameter;
	
		[Export]
		[Name(MemberVariable)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslMemberVariable;
	
		[Export]
		[Name(UserDefinedType)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserDefinedType;
	
		[Export]
		[Name(CompoundType)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslCompoundType;
	
		[Export]
		[Name(UserKeyword1)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserKeyword1;
	
		[Export]
		[Name(UserKeyword2)]
		[BaseDefinition(PredefinedClassificationTypeNames.Identifier)]
		private static readonly ClassificationTypeDefinition _glslUserKeyword2;
	
		[Export]
		[Name(Macro)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslMacro;
	
		[Export]
		[Name(InactiveMacro)]
		[BaseDefinition(PredefinedClassificationTypeNames.Keyword)]
		private static readonly ClassificationTypeDefinition _glslInactiveMacro;
	
#pragma warning restore 169 //never used warning
	}
}
