namespace UnityEngine.Rendering;

public static class GenericPool
{
	private static readonly ObjectPool<T> s_Pool; //Field offset: 0x0

	private static GenericPool`1() { }

	public static T Get() { }

	public static PooledObject<T> Get(out T value) { }

	public static void Release(T toRelease) { }

}

