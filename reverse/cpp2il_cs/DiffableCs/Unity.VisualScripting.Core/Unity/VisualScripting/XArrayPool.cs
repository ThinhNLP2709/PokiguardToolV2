namespace Unity.VisualScripting;

[Extension]
public static class XArrayPool
{

	[Extension]
	public static void Free(T[] array) { }

	[Extension]
	public static T[] ToArrayPooled(IEnumerable<T> source) { }

}

