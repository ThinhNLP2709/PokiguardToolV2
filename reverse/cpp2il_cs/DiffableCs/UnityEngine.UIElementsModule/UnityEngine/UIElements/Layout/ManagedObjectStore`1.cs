namespace UnityEngine.UIElements.Layout;

internal class ManagedObjectStore
{
	private int m_Length; //Field offset: 0x0
	private readonly List<T[]> m_Chunks; //Field offset: 0x0
	private readonly Queue<Int32> m_Free; //Field offset: 0x0

	public ManagedObjectStore`1() { }

	public T GetValue(int index) { }

	public void UpdateValue(ref int index, T value) { }

}

