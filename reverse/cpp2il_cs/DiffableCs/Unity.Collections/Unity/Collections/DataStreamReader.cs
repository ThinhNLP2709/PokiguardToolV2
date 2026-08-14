namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
[MovedFrom(True, "Unity.Networking.Transport", null, null)]
public struct DataStreamReader
{
	private struct Context
	{
		public int m_ReadByteIndex; //Field offset: 0x0
		public int m_BitIndex; //Field offset: 0x4
		public ulong m_BitBuffer; //Field offset: 0x8
		public int m_FailedReads; //Field offset: 0x10

	}

	[NativeDisableUnsafePtrRestriction]
	internal Byte* m_BufferPtr; //Field offset: 0x0
	private Context m_Context; //Field offset: 0x8
	private int m_Length; //Field offset: 0x20

	public bool HasFailedReads
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public static bool IsLittleEndian
	{
		 get { } //Length: 3
	}

	public int Length
	{
		[IsReadOnly]
		 get { } //Length: 4
	}

	public DataStreamReader(NativeArray<Byte> array) { }

	private static int ByteSwap(int val) { }

	private static short ByteSwap(short val) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckBits(int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	internal void CheckRead() { }

	private void FillBitBuffer() { }

	public void Flush() { }

	[IsReadOnly]
	public bool get_HasFailedReads() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	public static bool get_IsLittleEndian() { }

	[IsReadOnly]
	public int get_Length() { }

	public int GetBitsRead() { }

	public int GetBytesRead() { }

	private static void Initialize(out DataStreamReader self, NativeArray<Byte> array) { }

	public byte ReadByte() { }

	public void ReadBytes(NativeArray<Byte> array) { }

	public void ReadBytes(Span<Byte> span) { }

	private void ReadBytesInternal(Byte* data, int length) { }

	public double ReadDouble() { }

	public ushort ReadFixedString(NativeArray<Byte> array) { }

	public FixedString128Bytes ReadFixedString128() { }

	public FixedString32Bytes ReadFixedString32() { }

	public FixedString4096Bytes ReadFixedString4096() { }

	public FixedString512Bytes ReadFixedString512() { }

	public FixedString64Bytes ReadFixedString64() { }

	private ushort ReadFixedStringInternal(Byte* data, int maxLength) { }

	public float ReadFloat() { }

	public int ReadInt() { }

	public int ReadIntNetworkByteOrder() { }

	public long ReadLong() { }

	public double ReadPackedDouble(in StreamCompressionModel model) { }

	public double ReadPackedDoubleDelta(double baseline, in StreamCompressionModel model) { }

	public FixedString128Bytes ReadPackedFixedString128Delta(FixedString128Bytes baseline, in StreamCompressionModel model) { }

	public FixedString32Bytes ReadPackedFixedString32Delta(FixedString32Bytes baseline, in StreamCompressionModel model) { }

	public FixedString4096Bytes ReadPackedFixedString4096Delta(FixedString4096Bytes baseline, in StreamCompressionModel model) { }

	public FixedString512Bytes ReadPackedFixedString512Delta(FixedString512Bytes baseline, in StreamCompressionModel model) { }

	public FixedString64Bytes ReadPackedFixedString64Delta(FixedString64Bytes baseline, in StreamCompressionModel model) { }

	public ushort ReadPackedFixedStringDelta(NativeArray<Byte> data, NativeArray<Byte> baseData, in StreamCompressionModel model) { }

	private ushort ReadPackedFixedStringDeltaInternal(Byte* data, int maxLength, Byte* baseData, ushort baseLength, in StreamCompressionModel model) { }

	public float ReadPackedFloat(in StreamCompressionModel model) { }

	public float ReadPackedFloatDelta(float baseline, in StreamCompressionModel model) { }

	public int ReadPackedInt(in StreamCompressionModel model) { }

	public int ReadPackedIntDelta(int baseline, in StreamCompressionModel model) { }

	public long ReadPackedLong(in StreamCompressionModel model) { }

	public long ReadPackedLongDelta(long baseline, in StreamCompressionModel model) { }

	public uint ReadPackedUInt(in StreamCompressionModel model) { }

	public uint ReadPackedUIntDelta(uint baseline, in StreamCompressionModel model) { }

	private uint ReadPackedUIntInternal(int maxSymbolLength, in StreamCompressionModel model) { }

	public ulong ReadPackedULong(in StreamCompressionModel model) { }

	public ulong ReadPackedULongDelta(ulong baseline, in StreamCompressionModel model) { }

	public uint ReadRawBits(int numbits) { }

	private uint ReadRawBitsInternal(int numbits) { }

	public short ReadShort() { }

	public short ReadShortNetworkByteOrder() { }

	public uint ReadUInt() { }

	public uint ReadUIntNetworkByteOrder() { }

	public ulong ReadULong() { }

	public ushort ReadUShort() { }

	public ushort ReadUShortNetworkByteOrder() { }

	public void SeekSet(int pos) { }

}

