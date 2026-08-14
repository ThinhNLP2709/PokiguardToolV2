namespace UnityEngine.UIElements;

public class ConverterGroup
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <id>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <displayName>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly string <description>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly TypeConverterRegistry <registry>k__BackingField; //Field offset: 0x28

	internal TypeConverterRegistry registry
	{
		[CompilerGenerated]
		internal get { } //Length: 5
	}

	public ConverterGroup(string id, string displayName = null, string description = null) { }

	[CompilerGenerated]
	internal TypeConverterRegistry get_registry() { }

	public bool TryConvert(ref TSource source, out TDestination destination) { }

	public bool TrySetValue(ref TContainer container, in PropertyPath path, TValue value, out VisitReturnCode returnCode) { }

}

