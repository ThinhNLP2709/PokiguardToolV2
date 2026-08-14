namespace UnityEngine.Rendering;

internal struct InstanceHandle : IEquatable<InstanceHandle>, IComparable<InstanceHandle>
{
	public static readonly InstanceHandle Invalid; //Field offset: 0x0
	[CompilerGenerated]
	private int <index>k__BackingField; //Field offset: 0x0

	public private int index
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		private set { } //Length: 3
	}

	public int instanceIndex
	{
		 get { } //Length: 68
	}

	public InstanceType type
	{
		 get { } //Length: 69
	}

	public bool valid
	{
		 get { } //Length: 70
	}

	private static InstanceHandle() { }

	public override int CompareTo(InstanceHandle other) { }

	public static InstanceHandle Create(int instanceIndex, InstanceType instanceType) { }

	public override bool Equals(InstanceHandle other) { }

	public static InstanceHandle FromInt(int value) { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_index() { }

	public int get_instanceIndex() { }

	public InstanceType get_type() { }

	public bool get_valid() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	private void set_index(int value) { }

}

