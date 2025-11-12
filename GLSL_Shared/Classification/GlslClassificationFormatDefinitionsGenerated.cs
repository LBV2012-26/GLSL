
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace DMS.GLSL.Classification
{
	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.Function)]
	[Name(nameof(GlslFunctionClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslFunctionClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslFunctionClassificationFormatDefinition()
		{
			DisplayName     = "GLSL Function"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#dcdcaa");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.Keyword)]
	[Name(nameof(GlslKeywordClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslKeywordClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslKeywordClassificationFormatDefinition()
		{
			DisplayName     = "GLSL Keyword"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#569cd6");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.ControlKeyword)]
	[Name(nameof(GlslControlKeywordClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslControlKeywordClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslControlKeywordClassificationFormatDefinition()
		{
			DisplayName     = "GLSL ControlKeyword"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#d8a0df");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.BuiltInVariable)]
	[Name(nameof(GlslBuiltInVariableClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslBuiltInVariableClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslBuiltInVariableClassificationFormatDefinition()
		{
			DisplayName     = "GLSL BuiltInVariable"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#5fffff");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.UserVariable)]
	[Name(nameof(GlslUserVariableClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslUserVariableClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslUserVariableClassificationFormatDefinition()
		{
			DisplayName     = "GLSL UserVariable"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#98dcfe");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.GlobalVariable)]
	[Name(nameof(GlslGlobalVariableClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslGlobalVariableClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslGlobalVariableClassificationFormatDefinition()
		{
			DisplayName     = "GLSL GlobalVariable"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#c8c8c8");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.FunctionParameter)]
	[Name(nameof(GlslFunctionParameterClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslFunctionParameterClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslFunctionParameterClassificationFormatDefinition()
		{
			DisplayName     = "GLSL FunctionParameter"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#9a9a9a");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.MemberVariable)]
	[Name(nameof(GlslMemberVariableClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslMemberVariableClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslMemberVariableClassificationFormatDefinition()
		{
			DisplayName     = "GLSL MemberVariable"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#c8c8c8");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.UserDefinedType)]
	[Name(nameof(GlslUserDefinedTypeClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslUserDefinedTypeClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslUserDefinedTypeClassificationFormatDefinition()
		{
			DisplayName     = "GLSL UserDefinedType"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#4ec9b0");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.CompoundType)]
	[Name(nameof(GlslCompoundTypeClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslCompoundTypeClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslCompoundTypeClassificationFormatDefinition()
		{
			DisplayName     = "GLSL CompoundType"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#4ec9b0");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.UserKeyword1)]
	[Name(nameof(GlslUserKeyword1ClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslUserKeyword1ClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslUserKeyword1ClassificationFormatDefinition()
		{
			DisplayName     = "GLSL UserKeyword1"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#af5fff");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.UserKeyword2)]
	[Name(nameof(GlslUserKeyword2ClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslUserKeyword2ClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslUserKeyword2ClassificationFormatDefinition()
		{
			DisplayName     = "GLSL UserKeyword2"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#ff5faf");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.Macro)]
	[Name(nameof(GlslMacroClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslMacroClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslMacroClassificationFormatDefinition()
		{
			DisplayName     = "GLSL Macro"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#beb7ff");
		}
	}

	[Export(typeof(EditorFormatDefinition))]
	[ClassificationType(ClassificationTypeNames = GlslClassificationTypes.InactiveMacro)]
	[Name(nameof(GlslInactiveMacroClassificationFormatDefinition))]
	// this should be visible to the end user
	[UserVisible(true)]
	// set the priority to be after the default classifiers
	[Order(Before = Priority.Default)]
	internal sealed class GlslInactiveMacroClassificationFormatDefinition : ClassificationFormatDefinition
	{
		public GlslInactiveMacroClassificationFormatDefinition()
		{
			DisplayName     = "GLSL InactiveMacro"; //human readable version of the name
			ForegroundColor = ColorTools.FromHexCode("#ffffff");
		}
	}

}
