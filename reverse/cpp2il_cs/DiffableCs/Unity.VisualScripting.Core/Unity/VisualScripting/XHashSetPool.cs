namespace Unity.VisualScripting;

[Extension]
public static class XHashSetPool
{

	[Extension]
	public static void Free(HashSet<T> hashSet) { }

	[Extension]
	public static HashSet<T> ToHashSetPooled(IEnumerable<T> source) { }

}

