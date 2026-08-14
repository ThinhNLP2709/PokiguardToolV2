namespace Unity.VisualScripting;

public static class HashSetPool
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Stack<HashSet`1<T>> free; //Field offset: 0x0
	private static readonly HashSet<HashSet`1<T>> busy; //Field offset: 0x0

	private static HashSetPool`1() { }

	public static void Free(HashSet<T> hashSet) { }

	public static HashSet<T> New() { }

}

