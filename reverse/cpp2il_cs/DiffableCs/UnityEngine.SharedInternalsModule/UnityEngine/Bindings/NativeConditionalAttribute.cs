namespace UnityEngine.Bindings;

[AttributeUsage(204)]
[VisibleToOtherModules]
internal class NativeConditionalAttribute : Attribute
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <Condition>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <StubReturnStatement>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <Enabled>k__BackingField; //Field offset: 0x20

	public string Condition
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public bool Enabled
	{
		[CompilerGenerated]
		 set { } //Length: 1011
	}

	public string StubReturnStatement
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public NativeConditionalAttribute(string condition) { }

	public NativeConditionalAttribute(string condition, string stubReturnStatement) { }

	[CompilerGenerated]
	public void set_Condition(string value) { }

	[CompilerGenerated]
	public void set_Enabled(bool value) { }

	[CompilerGenerated]
	public void set_StubReturnStatement(string value) { }

}

