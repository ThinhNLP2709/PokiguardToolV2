namespace UnityEngine.Rendering.Universal;

internal struct Sorting
{
	[CompilerGenerated]
	private struct <>c__DisplayClass4_0
	{
		public T[] data; //Field offset: 0x0

	}

	public static ProfilingSampler s_QuickSortSampler; //Field offset: 0x0
	public static ProfilingSampler s_InsertionSortSampler; //Field offset: 0x8

	private static Sorting() { }

	[CompilerGenerated]
	internal static void <Median3Pivot>g__Swap|4_0(int a, int b, ref <>c__DisplayClass4_0<T>& unnamed_param_2) { }

	public static void InsertionSort(T[] data, Func<T, T, Int32> compare) { }

	public static void InsertionSort(T[] data, int start, int end, Func<T, T, Int32> compare) { }

	private static T Median3Pivot(T[] data, int start, int pivot, int end, Func<T, T, Int32> compare) { }

	private static int Partition(T[] data, int start, int end, Func<T, T, Int32> compare) { }

	public static void QuickSort(T[] data, Func<T, T, Int32> compare) { }

	public static void QuickSort(T[] data, int start, int end, Func<T, T, Int32> compare) { }

}

