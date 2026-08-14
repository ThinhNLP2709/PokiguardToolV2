namespace Unity.Properties;

[DefaultMember("Item")]
[IsReadOnly]
public struct PropertyPath : IEquatable<PropertyPath>
{
	[CompilerGenerated]
	private struct <>c__DisplayClass36_0
	{
		public int index; //Field offset: 0x0
		public int length; //Field offset: 0x4
		public string path; //Field offset: 0x8
		public int state; //Field offset: 0x10

	}

	internal const int k_InlineCount = 4; //Field offset: 0x0
	private readonly PropertyPathPart m_Part0; //Field offset: 0x0
	private readonly PropertyPathPart m_Part1; //Field offset: 0x20
	private readonly PropertyPathPart m_Part2; //Field offset: 0x40
	private readonly PropertyPathPart m_Part3; //Field offset: 0x60
	private readonly PropertyPathPart[] m_AdditionalParts; //Field offset: 0x80
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly int <Length>k__BackingField; //Field offset: 0x88

	public bool IsEmpty
	{
		 get { } //Length: 11
	}

	public PropertyPathPart Item
	{
		 get { } //Length: 499
	}

	public int Length
	{
		[CompilerGenerated]
		 get { } //Length: 7
	}

	public PropertyPath(string path) { }

	private PropertyPath(in PropertyPathPart part) { }

	private PropertyPath(in PropertyPathPart part0, in PropertyPathPart part1) { }

	private PropertyPath(in PropertyPathPart part0, in PropertyPathPart part1, in PropertyPathPart part2) { }

	private PropertyPath(in PropertyPathPart part0, in PropertyPathPart part1, in PropertyPathPart part2, in PropertyPathPart part3) { }

	internal PropertyPath(List<PropertyPathPart> parts) { }

	[CompilerGenerated]
	internal static void <ConstructFromPath>g__ReadNext|36_1(ref <>c__DisplayClass36_0 unnamed_param_0) { }

	[CompilerGenerated]
	internal static void <ConstructFromPath>g__TrimStart|36_0(ref <>c__DisplayClass36_0 unnamed_param_0) { }

	public static PropertyPath AppendIndex(in PropertyPath path, int index) { }

	public static PropertyPath AppendPart(in PropertyPath path, in PropertyPathPart part) { }

	public static PropertyPath AppendProperty(in PropertyPath path, IProperty property) { }

	private static void AppendToBuilder(in PropertyPathPart part, StringBuilder builder) { }

	public static PropertyPath Combine(in PropertyPath path, in PropertyPath pathToAppend) { }

	private static PropertyPath ConstructFromPath(string path) { }

	public override bool Equals(PropertyPath other) { }

	public virtual bool Equals(object obj) { }

	public static PropertyPath FromIndex(int index) { }

	public bool get_IsEmpty() { }

	public PropertyPathPart get_Item(int index) { }

	[CompilerGenerated]
	public int get_Length() { }

	public virtual int GetHashCode() { }

	private static void GetParts(in PropertyPath path, List<PropertyPathPart> parts) { }

	public static bool op_Equality(PropertyPath lhs, PropertyPath rhs) { }

	public static bool op_Inequality(PropertyPath lhs, PropertyPath rhs) { }

	public static PropertyPath Pop(in PropertyPath path) { }

	public static PropertyPath SubPath(in PropertyPath path, int startIndex, int length) { }

	public virtual string ToString() { }

}

