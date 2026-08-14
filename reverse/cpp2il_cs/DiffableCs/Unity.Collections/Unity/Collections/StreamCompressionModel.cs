namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
public struct StreamCompressionModel
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <bucketOffsets>e__FixedBuffer
	{
		public uint FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <bucketSizes>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <decodeTable>e__FixedBuffer
	{
		public ushort FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <encodeTable>e__FixedBuffer
	{
		public ushort FixedElementField; //Field offset: 0x0

	}

	private static class SharedStaticCompressionModel
	{
		internal static readonly SharedStatic<StreamCompressionModel> Default; //Field offset: 0x0

		private static SharedStaticCompressionModel() { }

	}

	internal static readonly Byte[] k_BucketSizes; //Field offset: 0x0
	internal const int k_AlphabetSize = 16; //Field offset: 0x0
	internal const int k_MaxHuffmanSymbolLength = 6; //Field offset: 0x0
	internal const int k_MaxContexts = 1; //Field offset: 0x0
	internal static readonly UInt32[] k_BucketOffsets; //Field offset: 0x8
	internal static readonly Int32[] k_FirstBucketCandidate; //Field offset: 0x10
	internal static readonly Byte[] k_DefaultModelData; //Field offset: 0x18
	private byte m_Initialized; //Field offset: 0x0
	[FixedBuffer(typeof(ushort), 16)]
	internal <encodeTable>e__FixedBuffer encodeTable; //Field offset: 0x2
	[FixedBuffer(typeof(ushort), 64)]
	internal <decodeTable>e__FixedBuffer decodeTable; //Field offset: 0x22
	[FixedBuffer(typeof(byte), 16)]
	internal <bucketSizes>e__FixedBuffer bucketSizes; //Field offset: 0xA2
	[FixedBuffer(typeof(uint), 16)]
	internal <bucketOffsets>e__FixedBuffer bucketOffsets; //Field offset: 0xB4

	public static StreamCompressionModel Default
	{
		 get { } //Length: 382
	}

	private static StreamCompressionModel() { }

	[IsReadOnly]
	public int CalculateBucket(uint value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckAlphabetAndMaxCodeLength(int alphabetSize, int maxCodeLength) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckAlphabetSize(int alphabetSize) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckExceedMaxCodeLength(int length, int maxCodeLength) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckSymbolLength(NativeArray<Byte> symbolLengths, int symbolLengthsOffset, int symbol, int length) { }

	private static void GenerateHuffmanCodes(NativeArray<Byte> symbolCodes, int symbolCodesOffset, NativeArray<Byte> symbolLengths, int symbolLengthsOffset, int alphabetSize, int maxCodeLength) { }

	private static void GenerateHuffmanDecodeTable(NativeArray<UInt16> decodeTable, int decodeTableOffset, NativeArray<Byte> symbolLengths, NativeArray<Byte> symbolCodes, int alphabetSize, int maxCodeLength) { }

	public static StreamCompressionModel get_Default() { }

	[IsReadOnly]
	public int GetCompressedSizeInBits(uint value) { }

	private static void Initialize() { }

	private static uint ReverseBits(uint value, int num_bits) { }

}

