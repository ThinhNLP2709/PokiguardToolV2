namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, IsCreated = {IsCreated}")]
[DebuggerTypeProxy(typeof(UnsafeBitArrayDebugView))]
[GenerateTestsForBurstCompatibility]
public struct UnsafeBitArray : INativeDisposable, IDisposable
{
	internal struct ReadOnly
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly UInt64* Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x8

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

		internal ReadOnly(UInt64* ptr, int length) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void CheckArgs(int pos, int numBits) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void CheckArgsPosCount(int begin, int count, int numBits) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void CheckArgsUlong(int pos, int numBits) { }

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
	public UInt64* Ptr; //Field offset: 0x0
	public int Length; //Field offset: 0x8
	public int Capacity; //Field offset: 0xC
	public AllocatorHandle Allocator; //Field offset: 0x10

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

	public UnsafeBitArray(Void* ptr, int sizeInBytes, AllocatorHandle allocator = null) { }

	public UnsafeBitArray(int numBits, AllocatorHandle allocator, NativeArrayOptions options = 1) { }

	internal static UnsafeBitArray* Alloc(AllocatorHandle allocator) { }

	public ReadOnly AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckArgs(int pos, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckArgsCopy(ref UnsafeBitArray dstBitArray, int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckArgsPosCount(int begin, int count, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckArgsUlong(int pos, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckSizeMultipleOf8(int sizeInBytes) { }

	public void Clear() { }

	public void Copy(int dstPos, int srcPos, int numBits) { }

	public void Copy(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits) { }

	internal void CopyUlong(int dstPos, ref UnsafeBitArray srcBitArray, int srcPos, int numBits) { }

	public int CountBits(int pos, int numBits = 1) { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	public int Find(int pos, int count, int numBits) { }

	public int Find(int pos, int numBits) { }

	internal static void Free(UnsafeBitArray* data, AllocatorHandle allocator) { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	public ulong GetBits(int pos, int numBits = 1) { }

	public bool IsSet(int pos) { }

	private void Realloc(int capacityInBits) { }

	public void Resize(int numBits, NativeArrayOptions options = 0) { }

	public void Set(int pos, bool value) { }

	public static void Set(UInt64* ptr, int pos, bool value) { }

	public void SetBits(int pos, bool value, int numBits) { }

	public void SetBits(int pos, ulong value, int numBits = 1) { }

	public void SetCapacity(int capacityInBits) { }

	public bool TestAll(int pos, int numBits = 1) { }

	public bool TestAny(int pos, int numBits = 1) { }

	public bool TestNone(int pos, int numBits = 1) { }

	public void TrimExcess() { }

}

