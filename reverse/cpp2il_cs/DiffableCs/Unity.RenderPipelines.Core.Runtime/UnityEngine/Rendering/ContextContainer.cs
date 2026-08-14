namespace UnityEngine.Rendering;

public class ContextContainer : IDisposable
{
	private struct Item
	{
		public ContextItem storage; //Field offset: 0x0
		public bool isSet; //Field offset: 0x8

	}

	private static class TypeId
	{
		public static uint value; //Field offset: 0x0

		private static TypeId`1() { }

	}

	private static uint s_TypeCount; //Field offset: 0x0
	private Item[] m_Items; //Field offset: 0x10
	private List<UInt32> m_ActiveItemIndices; //Field offset: 0x18

	public ContextContainer() { }

	public bool Contains() { }

	private bool Contains(uint typeId) { }

	public T Create() { }

	private T CreateAndGetData(uint typeId) { }

	public override void Dispose() { }

	public T Get() { }

	public T GetOrCreate() { }

}

