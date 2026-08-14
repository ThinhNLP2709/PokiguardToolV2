namespace Unity.VisualScripting;

public static class DictionaryPool
{
	private static readonly object lock; //Field offset: 0x0
	private static readonly Stack<Dictionary`2<TKey, TValue>> free; //Field offset: 0x0
	private static readonly HashSet<Dictionary`2<TKey, TValue>> busy; //Field offset: 0x0

	private static DictionaryPool`2() { }

	public static void Free(Dictionary<TKey, TValue> dictionary) { }

	public static Dictionary<TKey, TValue> New(Dictionary<TKey, TValue> source = null) { }

}

