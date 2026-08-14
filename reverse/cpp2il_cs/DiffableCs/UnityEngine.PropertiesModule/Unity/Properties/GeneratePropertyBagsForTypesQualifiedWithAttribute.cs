namespace Unity.Properties;

[AttributeUsage(AttributeTargets::Assembly (1), AllowMultiple = True)]
public class GeneratePropertyBagsForTypesQualifiedWithAttribute : Attribute
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Type <Type>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly TypeGenerationOptions <Options>k__BackingField; //Field offset: 0x18

	public GeneratePropertyBagsForTypesQualifiedWithAttribute(Type type, TypeGenerationOptions options = 6) { }

}

