namespace UnityEngine.Pool;

public class GenericPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal T <.cctor>b__5_0() { }

	}

	internal static readonly ObjectPool<T> s_Pool; //Field offset: 0x0

	private static GenericPool`1() { }

	public static T Get() { }

	public static PooledObject<T> Get(out T value) { }

	public static void Release(T toRelease) { }

}

