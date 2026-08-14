namespace Unity.VisualScripting;

public static class ArrayPool
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Dictionary<Int32, Stack`1<T[]>> free; //Field offset: 0x0
	private static readonly HashSet<T[]> busy; //Field offset: 0x0

	private static ArrayPool`1() { }

	public static void Free(T[] array) { }

	public static T[] New(int length) { }

}

