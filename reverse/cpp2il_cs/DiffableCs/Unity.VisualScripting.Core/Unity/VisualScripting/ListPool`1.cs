namespace Unity.VisualScripting;

public static class ListPool
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Stack<List`1<T>> free; //Field offset: 0x0
	private static readonly HashSet<List`1<T>> busy; //Field offset: 0x0

	private static ListPool`1() { }

	public static void Free(List<T> list) { }

	public static List<T> New() { }

}

