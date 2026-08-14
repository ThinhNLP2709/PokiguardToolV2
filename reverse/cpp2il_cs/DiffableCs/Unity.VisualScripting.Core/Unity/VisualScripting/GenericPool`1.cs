namespace Unity.VisualScripting;

public static class GenericPool
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Stack<T> free; //Field offset: 0x0
	private static readonly HashSet<T> busy; //Field offset: 0x0

	private static GenericPool`1() { }

	public static void Free(T item) { }

	public static T New(Func<T> constructor) { }

}

