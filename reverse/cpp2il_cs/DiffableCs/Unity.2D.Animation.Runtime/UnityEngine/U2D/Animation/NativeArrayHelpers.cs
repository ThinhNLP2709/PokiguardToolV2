namespace UnityEngine.U2D.Animation;

[Extension]
internal static class NativeArrayHelpers
{

	[Extension]
	[WriteAccessRequired]
	public static void CopyFromNativeSlice(NativeArray<T> nativeArray, int dstStartIndex, int dstEndIndex, NativeSlice<S> slice, int srcStartIndex, int srcEndIndex) { }

	[Extension]
	public static void DisposeIfCreated(NativeArray<T> nativeArray) { }

	public static void ResizeAndCopyIfNeeded(ref NativeArray<T>& nativeArray, int size, Allocator allocator = 4) { }

	public static void ResizeIfNeeded(ref NativeArray<T>& nativeArray, int size, Allocator allocator = 4) { }

}

