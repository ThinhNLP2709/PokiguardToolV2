namespace UnityEngine.UIElements;

[IsReadOnly]
public struct BindingResult
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly BindingStatus <status>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <message>k__BackingField; //Field offset: 0x8

	public string message
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public BindingStatus status
	{
		[CompilerGenerated]
		 get { } //Length: 3
	}

	public BindingResult(BindingStatus status, string message = null) { }

	[CompilerGenerated]
	public string get_message() { }

	[CompilerGenerated]
	public BindingStatus get_status() { }

}

