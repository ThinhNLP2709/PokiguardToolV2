namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
[MovedFrom(True, "Unity.Networking.Transport", "Unity.Networking.Transport", null)]
public struct DataStreamWriter
{
	private struct StreamData
	{
		public Byte* buffer; //Field offset: 0x0
		public int length; //Field offset: 0x8
		public int capacity; //Field offset: 0xC
		public ulong bitBuffer; //Field offset: 0x10
		public int bitIndex; //Field offset: 0x18
		public int failedWrites; //Field offset: 0x1C

	}

	[NativeDisableUnsafePtrRestriction]
	private StreamData m_Data; //Field offset: 0x0
	public IntPtr m_SendHandleData; //Field offset: 0x20

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 4
	}

	public bool HasFailedWrites
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
		 get { } //Length: 77
	}

	public int LengthInBits
	{
		 get { } //Length: 74
	}

	public DataStreamWriter(int length, AllocatorHandle allocator) { }

	public DataStreamWriter(NativeArray<Byte> data) { }

	public DataStreamWriter(Byte* data, int length) { }

	public NativeArray<Byte> AsNativeArray() { }

	private static short ByteSwap(short val) { }

	private static int ByteSwap(int val) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckAllocator(AllocatorHandle allocator) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckBits(uint value, int numBits) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public void Flush() { }

	private void FlushBits() { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_HasFailedWrites() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	public static bool get_IsLittleEndian() { }

	public int get_Length() { }

	public int get_LengthInBits() { }

	private static void Initialize(out DataStreamWriter self, NativeArray<Byte> data) { }

	private void SyncBitData() { }

	public bool WriteByte(byte value) { }

	public bool WriteBytes(NativeArray<Byte> value) { }

	public bool WriteBytes(Span<Byte> value) { }

	private bool WriteBytesInternal(Byte* data, int bytes) { }

	public bool WriteDouble(double value) { }

	public bool WriteFixedString128(FixedString128Bytes str) { }

	public bool WriteFixedString32(FixedString32Bytes str) { }

	public bool WriteFixedString4096(FixedString4096Bytes str) { }

	public bool WriteFixedString512(FixedString512Bytes str) { }

	public bool WriteFixedString64(FixedString64Bytes str) { }

	public bool WriteFloat(float value) { }

	public bool WriteInt(int value) { }

	public bool WriteIntNetworkByteOrder(int value) { }

	public bool WriteLong(long value) { }

	public bool WritePackedDouble(double value, in StreamCompressionModel model) { }

	public bool WritePackedDoubleDelta(double value, double baseline, in StreamCompressionModel model) { }

	public bool WritePackedFixedString128Delta(FixedString128Bytes str, FixedString128Bytes baseline, in StreamCompressionModel model) { }

	public bool WritePackedFixedString32Delta(FixedString32Bytes str, FixedString32Bytes baseline, in StreamCompressionModel model) { }

	public bool WritePackedFixedString4096Delta(FixedString4096Bytes str, FixedString4096Bytes baseline, in StreamCompressionModel model) { }

	public bool WritePackedFixedString512Delta(FixedString512Bytes str, FixedString512Bytes baseline, in StreamCompressionModel model) { }

	public bool WritePackedFixedString64Delta(FixedString64Bytes str, FixedString64Bytes baseline, in StreamCompressionModel model) { }

	private bool WritePackedFixedStringDelta(Byte* data, uint length, Byte* baseData, uint baseLength, in StreamCompressionModel model) { }

	public bool WritePackedFloat(float value, in StreamCompressionModel model) { }

	public bool WritePackedFloatDelta(float value, float baseline, in StreamCompressionModel model) { }

	public bool WritePackedInt(int value, in StreamCompressionModel model) { }

	public bool WritePackedIntDelta(int value, int baseline, in StreamCompressionModel model) { }

	public bool WritePackedLong(long value, in StreamCompressionModel model) { }

	public bool WritePackedLongDelta(long value, long baseline, in StreamCompressionModel model) { }

	public bool WritePackedUInt(uint value, in StreamCompressionModel model) { }

	public bool WritePackedUIntDelta(uint value, uint baseline, in StreamCompressionModel model) { }

	public bool WritePackedULong(ulong value, in StreamCompressionModel model) { }

	public bool WritePackedULongDelta(ulong value, ulong baseline, in StreamCompressionModel model) { }

	public bool WriteRawBits(uint value, int numbits) { }

	private void WriteRawBitsInternal(uint value, int numbits) { }

	public bool WriteShort(short value) { }

	public bool WriteShortNetworkByteOrder(short value) { }

	public bool WriteUInt(uint value) { }

	public bool WriteUIntNetworkByteOrder(uint value) { }

	public bool WriteULong(ulong value) { }

	public bool WriteUShort(ushort value) { }

	public bool WriteUShortNetworkByteOrder(ushort value) { }

}

