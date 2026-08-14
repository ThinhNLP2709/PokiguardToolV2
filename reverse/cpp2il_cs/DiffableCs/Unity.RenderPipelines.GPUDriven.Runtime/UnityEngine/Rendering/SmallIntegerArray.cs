namespace UnityEngine.Rendering;

[DefaultMember("Item")]
internal struct SmallIntegerArray : IDisposable
{
	private FixedList32Bytes<Int32> m_FixedArray; //Field offset: 0x0
	private UnsafeList<Int32> m_List; //Field offset: 0x20
	private readonly bool m_IsEmbedded; //Field offset: 0x38
	[CompilerGenerated]
	private bool <Valid>k__BackingField; //Field offset: 0x39
	public readonly int Length; //Field offset: 0x3C

	public int Item
	{
		 get { } //Length: 172
		 set { } //Length: 190
	}

	public private bool Valid
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public SmallIntegerArray(int length, Allocator allocator) { }

	public override void Dispose() { }

	public int get_Item(int index) { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_Valid() { }

	public void set_Item(int index, int value) { }

	[CompilerGenerated]
	private void set_Valid(bool value) { }

}

