namespace Unity.Collections;

[BurstCompile]
public struct RewindableAllocator : IAllocator, IDisposable
{
	[GenerateTestsForBurstCompatibility]
	public struct MemoryBlock : IDisposable
	{
		public const int kMaximumAlignment = 16384; //Field offset: 0x0
		public Byte* m_pointer; //Field offset: 0x0
		public long m_bytes; //Field offset: 0x8
		public Union m_union; //Field offset: 0x10

		public MemoryBlock(long bytes) { }

		public bool Contains(IntPtr ptr) { }

		public override void Dispose() { }

		public void Rewind() { }

	}

	public static class Try_000009DE$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static int Invoke(IntPtr state, ref Block block) { }

	}

	[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
	internal sealed class Try_000009DE$PostfixBurstDelegate : MulticastDelegate
	{

		public Try_000009DE$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(IntPtr state, ref Block block, AsyncCallback unnamed_param_2, object unnamed_param_3) { }

		public override int EndInvoke(IAsyncResult unnamed_param_0) { }

		public override int Invoke(IntPtr state, ref Block block) { }

	}

	public struct Union
	{
		private const int currentBits = 40; //Field offset: 0x0
		private const int currentOffset = 0; //Field offset: 0x0
		private const long currentMask = 1099511627775; //Field offset: 0x0
		private const int allocCountBits = 24; //Field offset: 0x0
		private const int allocCountOffset = 40; //Field offset: 0x0
		private const long allocCountMask = 16777215; //Field offset: 0x0
		internal long m_long; //Field offset: 0x0

		internal long m_allocCount
		{
			internal get { } //Length: 13
			internal set { } //Length: 21
		}

		internal long m_current
		{
			internal get { } //Length: 17
			internal set { } //Length: 26
		}

		internal long get_m_allocCount() { }

		internal long get_m_current() { }

		internal void set_m_allocCount(long value) { }

		internal void set_m_current(long value) { }

	}

	private const int kLog2MaxMemoryBlockSize = 26; //Field offset: 0x0
	private const long kMaxMemoryBlockSize = 67108864; //Field offset: 0x0
	private const long kMinMemoryBlockSize = 131072; //Field offset: 0x0
	private const int kMaxNumBlocks = 64; //Field offset: 0x0
	private const int kBlockBusyRewindMask = -2147483648; //Field offset: 0x0
	private const int kBlockBusyAllocateMask = 2147483647; //Field offset: 0x0
	private Spinner m_spinner; //Field offset: 0x0
	private AllocatorHandle m_handle; //Field offset: 0x4
	private UnmanagedArray<MemoryBlock> m_block; //Field offset: 0x8
	private int m_last; //Field offset: 0x18
	private int m_used; //Field offset: 0x1C
	private byte m_enableBlockFree; //Field offset: 0x20
	private byte m_reachMaxBlockSize; //Field offset: 0x21

	public int BlocksAllocated
	{
		 get { } //Length: 6
	}

	internal long BytesAllocated
	{
		internal get { } //Length: 115
	}

	public bool EnableBlockFree
	{
		 get { } //Length: 8
		 set { } //Length: 6
	}

	[ExcludeFromBurstCompatTesting("Uses managed delegate")]
	public override TryFunction Function
	{
		 get { } //Length: 90
	}

	public override AllocatorHandle Handle
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public int InitialSizeInBytes
	{
		 get { } //Length: 57
	}

	public override bool IsAutoDispose
	{
		 get { } //Length: 3
	}

	public override bool IsCustomAllocator
	{
		 get { } //Length: 11
	}

	internal long MaxMemoryBlockSize
	{
		internal get { } //Length: 6
	}

	public override Allocator ToAllocator
	{
		 get { } //Length: 11
	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeArray<T> AllocateNativeArray(int length) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public NativeList<T> AllocateNativeList(int capacity) { }

	public override void Dispose() { }

	public int get_BlocksAllocated() { }

	internal long get_BytesAllocated() { }

	public bool get_EnableBlockFree() { }

	public override TryFunction get_Function() { }

	public override AllocatorHandle get_Handle() { }

	public int get_InitialSizeInBytes() { }

	public override bool get_IsAutoDispose() { }

	public override bool get_IsCustomAllocator() { }

	internal long get_MaxMemoryBlockSize() { }

	public override Allocator get_ToAllocator() { }

	public void Initialize(int initialSizeInBytes, bool enableBlockFree = false) { }

	public void Rewind() { }

	public void set_EnableBlockFree(bool value) { }

	public override void set_Handle(AllocatorHandle value) { }

	public override int Try(ref Block block) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(TryFunction))]
	internal static int Try(IntPtr state, ref Block block) { }

	[BurstCompile]
	[MonoPInvokeCallback(typeof(TryFunction))]
	public static int Try$BurstManaged(IntPtr state, ref Block block) { }

	private int TryAllocate(ref Block block, int startIndex, int lastIndex, long alignedSize, long alignmentMask) { }

}

