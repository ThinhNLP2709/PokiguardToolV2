namespace Unity.Collections.NotBurstCompatible;

[Extension]
public static class Extensions
{

	[ExcludeFromBurstCompatTesting("Takes managed array")]
	[Extension]
	public static void CopyFromNBC(NativeList<T> list, T[] array) { }

	[ExcludeFromBurstCompatTesting("Returns managed array")]
	[Extension]
	public static T[] ToArray(NativeHashSet<T> set) { }

	[ExcludeFromBurstCompatTesting("Returns managed array")]
	[Extension]
	public static T[] ToArray(NativeParallelHashSet<T> set) { }

	[ExcludeFromBurstCompatTesting("Returns managed array")]
	[Extension]
	public static T[] ToArrayNBC(NativeList<T> list) { }

}

