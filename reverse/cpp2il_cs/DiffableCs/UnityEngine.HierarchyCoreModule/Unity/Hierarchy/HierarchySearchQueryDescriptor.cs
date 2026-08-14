namespace Unity.Hierarchy;

[NativeAsStruct]
[NativeHeader("Modules/HierarchyCore/Public/HierarchySearch.h")]
[RequiredByNativeCode]
public sealed class HierarchySearchQueryDescriptor
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<HierarchySearchFilter, Boolean> <>9__33_0; //Field offset: 0x8
		public static Func<HierarchySearchFilter, Boolean> <>9__33_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <.ctor>b__33_0(HierarchySearchFilter f) { }

		internal bool <.ctor>b__33_1(HierarchySearchFilter f) { }

	}

	private static readonly HashSet<String> s_SystemFilters; //Field offset: 0x0
	private static readonly HierarchySearchQueryDescriptor s_Empty; //Field offset: 0x8
	private static readonly HierarchySearchQueryDescriptor s_InvalidQuery; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private HierarchySearchFilter[] <SystemFilters>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private HierarchySearchFilter[] <Filters>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private String[] <TextValues>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <Strict>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <Invalid>k__BackingField; //Field offset: 0x29

	public HierarchySearchFilter[] Filters
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public bool Invalid
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool Strict
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public HierarchySearchFilter[] SystemFilters
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public String[] TextValues
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private static HierarchySearchQueryDescriptor() { }

	public HierarchySearchQueryDescriptor(HierarchySearchFilter[] filters = null, String[] textValues = null) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.HierarchyModule"})]
	internal string BuildFilterQuery() { }

	internal string BuildQuery() { }

	internal string BuildSystemFilterQuery() { }

	internal string BuildTextQuery() { }

	[CompilerGenerated]
	public HierarchySearchFilter[] get_Filters() { }

	[CompilerGenerated]
	public HierarchySearchFilter[] get_SystemFilters() { }

	[CompilerGenerated]
	public String[] get_TextValues() { }

	[CompilerGenerated]
	public void set_Filters(HierarchySearchFilter[] value) { }

	[CompilerGenerated]
	public void set_Invalid(bool value) { }

	[CompilerGenerated]
	public void set_Strict(bool value) { }

	[CompilerGenerated]
	public void set_SystemFilters(HierarchySearchFilter[] value) { }

	[CompilerGenerated]
	public void set_TextValues(String[] value) { }

	public virtual string ToString() { }

	private static T[] Where(IEnumerable<T> src, Func<T, Boolean> pred) { }

}

