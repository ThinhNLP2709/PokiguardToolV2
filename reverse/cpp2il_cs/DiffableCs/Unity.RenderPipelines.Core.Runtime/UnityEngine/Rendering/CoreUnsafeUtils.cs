namespace UnityEngine.Rendering;

[Extension]
public static class CoreUnsafeUtils
{
	public struct DefaultKeyGetter : IKeyGetter<T, T>
	{

		public override T Get(ref T v) { }

	}

	internal struct FixedBufferStringQueue
	{
		private Byte* m_ReadCursor; //Field offset: 0x0
		private Byte* m_WriteCursor; //Field offset: 0x8
		private readonly Byte* m_BufferEnd; //Field offset: 0x10
		private readonly Byte* m_BufferStart; //Field offset: 0x18
		private readonly int m_BufferLength; //Field offset: 0x20
		[CompilerGenerated]
		private int <Count>k__BackingField; //Field offset: 0x24

		public private int Count
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
			[CompilerGenerated]
			private set { } //Length: 4
		}

		public FixedBufferStringQueue(Byte* ptr, int length) { }

		public void Clear() { }

		[CompilerGenerated]
		[IsReadOnly]
		public int get_Count() { }

		[CompilerGenerated]
		private void set_Count(int value) { }

		public bool TryPop(out string v) { }

		public bool TryPush(string v) { }

	}

	internal interface IKeyGetter
	{

		public TKey Get(ref TValue v) { }

	}

	public struct UintKeyGetter : IKeyGetter<UInt32, UInt32>
	{

		public override uint Get(ref uint v) { }

	}

	public struct UlongKeyGetter : IKeyGetter<UInt64, UInt64>
	{

		public override ulong Get(ref ulong v) { }

	}


	private static void CalculateRadixParams(int radixBits, out int bitStates) { }

	private static void CalculateRadixSortSupportArrays(int bitStates, int arrayLength, UInt32* supportArray, out UInt32* bucketIndices, out UInt32* bucketSizes, out UInt32* bucketPrefix, out UInt32* arrayOutput) { }

	private static int CalculateRadixSupportSize(int bitStates, int arrayLength) { }

	public static void CombineHashes(int count, Hash128* hashes, Hash128* outHash) { }

	public static void CombineHashes(int count, Void* hashes, Hash128* outHash) { }

	public static int CompareHashes(int oldHashCount, Hash128* oldHashes, int newHashCount, Hash128* newHashes, Int32* addIndices, Int32* removeIndices, out int addCount, out int remCount) { }

	public static int CompareHashes(int oldHashCount, Void* oldHashes, int newHashCount, Void* newHashes, Int32* addIndices, Int32* removeIndices, out int addCount, out int remCount) { }

	[Extension]
	public static void CopyTo(List<T> list, Void* dest, int count) { }

	[Extension]
	public static void CopyTo(T[] list, Void* dest, int count) { }

	public static bool HaveDuplicates(Int32[] arr) { }

	public static int IndexOf(Void* data, int count, T v) { }

	public static void InsertionSort(NativeArray<UInt32> arr, int sortSize) { }

	private static void InsertionSort(UInt32* arr, int length) { }

	public static void InsertionSort(UInt32[] arr, int sortSize) { }

	public static void MergeSort(NativeArray<UInt32> arr, int sortSize, ref NativeArray<UInt32>& supportArray) { }

	public static void MergeSort(UInt32[] arr, int sortSize, ref UInt32[] supportArray) { }

	private static void MergeSort(UInt32* array, UInt32* support, int length) { }

	private static int Partition(Void* data, int left, int right) { }

	public static void QuickSort(UInt32[] arr, int left, int right) { }

	public static void QuickSort(UInt64[] arr, int left, int right) { }

	public static void QuickSort(int count, Void* data) { }

	public static void QuickSort(int count, Void* data) { }

	public static void QuickSort(Void* data, int left, int right) { }

	private static void RadixSort(UInt32* array, UInt32* support, int radixBits, int bitStates, int length) { }

	public static void RadixSort(NativeArray<UInt32> array, int sortSize, ref NativeArray<UInt32>& supportArray, int radixBits = 8) { }

	public static void RadixSort(UInt32[] arr, int sortSize, ref UInt32[] supportArray, int radixBits = 8) { }

}

