namespace UnityEngine.Rendering;

internal struct SharedInstanceHandle : IEquatable<SharedInstanceHandle>, IComparable<SharedInstanceHandle>
{
	public static readonly SharedInstanceHandle Invalid; //Field offset: 0x0
	[CompilerGenerated]
	private int <index>k__BackingField; //Field offset: 0x0

	public int index
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		 set { } //Length: 3
	}

	public bool valid
	{
		 get { } //Length: 70
	}

	private static SharedInstanceHandle() { }

	public override int CompareTo(SharedInstanceHandle other) { }

	public override bool Equals(SharedInstanceHandle other) { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_index() { }

	public bool get_valid() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	public void set_index(int value) { }

}

