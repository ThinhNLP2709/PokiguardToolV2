namespace Unity.Collections;

[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
[GenerateTestsForBurstCompatibility]
[NativeContainer]
public struct NativeBitArray : INativeDisposable, IDisposable
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly
	{
		[NativeDisableUnsafePtrRestriction]
		internal ReadOnly m_BitArray; //Field offset: 0x0

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 8
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 17
		}

		public int Length
		{
			[IsReadOnly]
			 get { } //Length: 4
		}

		internal ReadOnly(ref NativeBitArray data) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead() { }

		[IsReadOnly]
		public int CountBits(int pos, int numBits = 1) { }

		[IsReadOnly]
		public int Find(int pos, int numBits) { }

		[IsReadOnly]
		public int Find(int pos, int count, int numBits) { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public bool get_IsEmpty() { }

		[IsReadOnly]
		public int get_Length() { }

		[IsReadOnly]
		public ulong GetBits(int pos, int numBits = 1) { }

		[IsReadOnly]
		public bool IsSet(int pos) { }

		[IsReadOnly]
		public bool TestAll(int pos, int numBits = 1) { }

		[IsReadOnly]
		public bool TestAny(int pos, int numBits = 1) { }

		[IsReadOnly]
		public bool TestNone(int pos, int numBits = 1) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal UnsafeBitArray* m_BitArray; //Field offset: 0x0
	internal AllocatorHandle m_Allocator; //Field offset: 0x8

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 25
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 20
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 26
	}

	public int Length
	{
		[IsReadOnly]
		 get { } //Length: 25
	}

	public NativeBitArray(int numBits, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> AsNativeArray() { }

	public ReadOnly AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckReadBounds() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public void Copy(int dstPos, int srcPos, int numBits) { }

	public void Copy(int dstPos, ref NativeBitArray srcBitArray, int srcPos, int numBits) { }

	public int CountBits(int pos, int numBits = 1) { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public int Find(int pos, int numBits) { }

	public int Find(int pos, int count, int numBits) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	[IsReadOnly]
	public int get_Length() { }

	public ulong GetBits(int pos, int numBits = 1) { }

	public bool IsSet(int pos) { }

	public void Resize(int numBits, NativeArrayOptions options = 0) { }

	public void Set(int pos, bool value) { }

	public void SetBits(int pos, ulong value, int numBits = 1) { }

	public void SetBits(int pos, bool value, int numBits) { }

	public void SetCapacity(int capacityInBits) { }

	public bool TestAll(int pos, int numBits = 1) { }

	public bool TestAny(int pos, int numBits = 1) { }

	public bool TestNone(int pos, int numBits = 1) { }

	public void TrimExcess() { }

}

