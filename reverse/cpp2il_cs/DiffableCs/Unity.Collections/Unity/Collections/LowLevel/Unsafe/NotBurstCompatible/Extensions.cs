namespace Unity.Collections.LowLevel.Unsafe.NotBurstCompatible;

[Extension]
public static class Extensions
{

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	[Extension]
	public static void AddNBC(ref UnsafeAppendBuffer buffer, string value) { }

	[ExcludeFromBurstCompatTesting("Managed string out argument")]
	[Extension]
	public static void ReadNextNBC(ref Reader reader, out string value) { }

	[Extension]
	public static T[] ToArray(UnsafeParallelHashSet<T> set) { }

	[ExcludeFromBurstCompatTesting("Returns managed array")]
	[Extension]
	public static Byte[] ToBytesNBC(ref UnsafeAppendBuffer buffer) { }

}

