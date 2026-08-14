namespace UnityEngine.Rendering;

public static class DictionaryPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TKey, TValue> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__4_0(Dictionary<TKey, TValue> l) { }

	}

	private static readonly ObjectPool<Dictionary`2<TKey, TValue>> s_Pool; //Field offset: 0x0

	private static DictionaryPool`2() { }

	public static Dictionary<TKey, TValue> Get() { }

	public static PooledObject<Dictionary<TKey, TValue>> Get(out Dictionary<TKey, TValue>& value) { }

	public static void Release(Dictionary<TKey, TValue> toRelease) { }

}

