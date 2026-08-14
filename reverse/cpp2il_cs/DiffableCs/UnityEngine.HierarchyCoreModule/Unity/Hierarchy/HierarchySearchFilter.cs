namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
[RequiredByNativeCode]
public struct HierarchySearchFilter
{
	private static readonly Char[] s_WhiteSpaces; //Field offset: 0x0
	private static readonly HierarchySearchFilter s_Invalid; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <Name>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <Value>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private float <NumValue>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private HierarchySearchFilterOperator <Op>k__BackingField; //Field offset: 0x14

	[IsReadOnly]
	public static HierarchySearchFilter Invalid
	{
		 get { } //Length: 79
	}

	public bool IsValid
	{
		 get { } //Length: 76
	}

	public string Name
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	public float NumValue
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 6
	}

	public HierarchySearchFilterOperator Op
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	public string Value
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
	}

	private static HierarchySearchFilter() { }

	public static HierarchySearchFilter get_Invalid() { }

	public bool get_IsValid() { }

	[CompilerGenerated]
	[IsReadOnly]
	public string get_Name() { }

	[CompilerGenerated]
	[IsReadOnly]
	public float get_NumValue() { }

	[CompilerGenerated]
	[IsReadOnly]
	public HierarchySearchFilterOperator get_Op() { }

	[CompilerGenerated]
	[IsReadOnly]
	public string get_Value() { }

	internal static string QuoteStringIfNeeded(string s) { }

	public static string ToString(HierarchySearchFilterOperator op) { }

	public virtual string ToString() { }

}

