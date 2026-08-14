namespace Unity.VisualScripting;

[Extension]
public static class XListPool
{

	[Extension]
	public static void Free(List<T> list) { }

	[Extension]
	public static List<T> ToListPooled(IEnumerable<T> source) { }

}

