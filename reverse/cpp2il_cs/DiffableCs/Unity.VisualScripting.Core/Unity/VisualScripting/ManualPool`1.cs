namespace Unity.VisualScripting;

public static class ManualPool
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Stack<T> free; //Field offset: 0x0
	private static readonly HashSet<T> busy; //Field offset: 0x0

	private static ManualPool`1() { }

	public static void Free(T item) { }

	public static T New(Func<T> constructor) { }

}

