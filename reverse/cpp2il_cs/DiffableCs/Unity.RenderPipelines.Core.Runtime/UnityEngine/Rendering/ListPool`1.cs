namespace UnityEngine.Rendering;

public static class ListPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__4_0(List<T> l) { }

	}

	private static readonly ObjectPool<List`1<T>> s_Pool; //Field offset: 0x0

	private static ListPool`1() { }

	public static List<T> Get() { }

	public static PooledObject<List<T>> Get(out List<T>& value) { }

	public static void Release(List<T> toRelease) { }

}

