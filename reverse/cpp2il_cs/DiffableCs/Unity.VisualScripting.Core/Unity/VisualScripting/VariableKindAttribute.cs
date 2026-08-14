namespace Unity.VisualScripting;

[AttributeUsage(384, AllowMultiple = False, Inherited = True)]
[Obsolete("Set VariableKind via VariableDeclarations.Kind")]
public sealed class VariableKindAttribute : Attribute
{
	[CompilerGenerated]
	private readonly VariableKind <kind>k__BackingField; //Field offset: 0x10

	public VariableKind kind
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public VariableKindAttribute(VariableKind kind) { }

	[CompilerGenerated]
	public VariableKind get_kind() { }

}

