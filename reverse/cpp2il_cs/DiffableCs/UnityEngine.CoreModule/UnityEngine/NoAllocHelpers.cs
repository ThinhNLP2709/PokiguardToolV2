namespace UnityEngine;

internal static class NoAllocHelpers
{
	private class ListPrivateFieldAccess
	{
		internal T[] _items; //Field offset: 0x0
		internal int _size; //Field offset: 0x0
		internal int _version; //Field offset: 0x0

	}


	public static void EnsureListElemCount(List<T> list, int count) { }

	public static T[] ExtractArrayFromList(List<T> list) { }

	public static void ResetListContents(List<T> list, ReadOnlySpan<T> span) { }

	public static void ResetListSize(List<T> list, int size) { }

	public static int SafeLength(Array values) { }

	public static int SafeLength(List<T> values) { }

}

