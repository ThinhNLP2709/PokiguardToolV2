namespace UnityEngine.Rendering;

public static class HashSetPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__4_0(HashSet<T> l) { }

	}

	private static readonly ObjectPool<HashSet`1<T>> s_Pool; //Field offset: 0x0

	private static HashSetPool`1() { }

	public static HashSet<T> Get() { }

	public static PooledObject<HashSet<T>> Get(out HashSet<T>& value) { }

	public static void Release(HashSet<T> toRelease) { }

}

