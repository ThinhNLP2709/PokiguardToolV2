namespace UnityEngine.Rendering;

[Extension]
public static class DynamicArrayExtensions
{

	private static int Partition(Span<T> data, int left, int right) { }

	private static int Partition(Span<T> data, int left, int right, SortComparer<T> comparer) { }

	private static void QuickSort(Span<T> data, int left, int right) { }

	private static void QuickSort(Span<T> data, int left, int right, SortComparer<T> comparer) { }

	[Extension]
	public static void QuickSort(DynamicArray<T> array) { }

	[Extension]
	public static void QuickSort(DynamicArray<T> array, SortComparer<T> comparer) { }

}

