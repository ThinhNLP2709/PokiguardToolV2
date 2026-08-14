namespace Unity.Collections.LowLevel.Unsafe;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class DataStreamExtensions
{

	public static DataStreamWriter Create(Byte* data, int length) { }

	[Extension]
	public static Void* GetUnsafeReadOnlyPtr(ref DataStreamReader reader) { }

	[Extension]
	public static void ReadBytesUnsafe(ref DataStreamReader reader, Byte* data, int length) { }

	[Extension]
	public static ushort ReadFixedStringUnsafe(ref DataStreamReader reader, Byte* data, int maxLength) { }

	[Extension]
	public static ushort ReadPackedFixedStringDeltaUnsafe(ref DataStreamReader reader, Byte* data, int maxLength, Byte* baseData, ushort baseLength, StreamCompressionModel model) { }

	[Extension]
	public static bool WriteBytesUnsafe(ref DataStreamWriter writer, Byte* data, int bytes) { }

}

