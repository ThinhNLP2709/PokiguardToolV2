namespace UnityEngine.Rendering;

public class ObjectPool
{
	internal struct PooledObject : IDisposable
	{
		private readonly T m_ToReturn; //Field offset: 0x0
		private readonly ObjectPool<T> m_Pool; //Field offset: 0x0

		internal PooledObject(T value, ObjectPool<T> pool) { }

		private override void System.IDisposable.Dispose() { }

	}

	private readonly Stack<T> m_Stack; //Field offset: 0x0
	private readonly UnityAction<T> m_ActionOnGet; //Field offset: 0x0
	private readonly UnityAction<T> m_ActionOnRelease; //Field offset: 0x0
	private readonly bool m_CollectionCheck; //Field offset: 0x0
	[CompilerGenerated]
	private int <countAll>k__BackingField; //Field offset: 0x0

	public int countActive
	{
		 get { } //Length: 29
	}

	public private int countAll
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public int countInactive
	{
		 get { } //Length: 26
	}

	public ObjectPool`1(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease, bool collectionCheck = true) { }

	public T Get() { }

	public PooledObject<T> Get(out T v) { }

	public int get_countActive() { }

	[CompilerGenerated]
	public int get_countAll() { }

	public int get_countInactive() { }

	public void Release(T element) { }

	[CompilerGenerated]
	private void set_countAll(int value) { }

}

