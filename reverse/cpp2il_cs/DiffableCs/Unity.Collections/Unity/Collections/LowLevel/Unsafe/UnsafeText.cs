namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility]
public struct UnsafeText : INativeDisposable, IDisposable, IUTF8Bytes, INativeList<Byte>, IIndexable<Byte>
{
	internal UntypedUnsafeList m_UntypedListData; //Field offset: 0x0

	public override int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 100
		 set { } //Length: 99
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 88
	}

	public override bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 110
	}

	public override byte Item
	{
		 get { } //Length: 62
		 set { } //Length: 75
	}

	public override int Length
	{
		[IsReadOnly]
		 get { } //Length: 112
		 set { } //Length: 151
	}

	public UnsafeText(int capacity, AllocatorHandle allocator) { }

	internal static UnsafeText* Alloc(AllocatorHandle allocator) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckCapacityInRange(int value, int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckIndexInRange(int index) { }

	public override void Clear() { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override byte ElementAt(int index) { }

	internal static void Free(UnsafeText* data) { }

	[IsReadOnly]
	public override int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public override bool get_IsEmpty() { }

	public override byte get_Item(int index) { }

	[IsReadOnly]
	public override int get_Length() { }

	public override Byte* GetUnsafePtr() { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, byte value) { }

	public override void set_Length(int value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void ThrowCopyError(CopyError error, string source) { }

	[ExcludeFromBurstCompatTesting("Returns managed string")]
	public virtual string ToString() { }

	public override bool TryResize(int newLength, NativeArrayOptions clearOptions = 1) { }

}

