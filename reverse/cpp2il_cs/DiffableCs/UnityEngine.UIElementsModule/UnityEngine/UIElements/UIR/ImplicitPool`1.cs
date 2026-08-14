namespace UnityEngine.UIElements.UIR;

internal class ImplicitPool
{
	private readonly int m_StartCapacity; //Field offset: 0x0
	private readonly int m_MaxCapacity; //Field offset: 0x0
	private Func<T> m_CreateAction; //Field offset: 0x0
	private Action<T> m_ResetAction; //Field offset: 0x0
	private List<T> m_List; //Field offset: 0x0
	private int m_UsedCount; //Field offset: 0x0

	public ImplicitPool`1(Func<T> createAction, Action<T> resetAction, int startCapacity, int maxCapacity) { }

	public T Get() { }

	public void ReturnAll() { }

}

