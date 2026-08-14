namespace UnityEngine.UIElements.UIR;

internal class EntryPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal Entry <.cctor>b__8_0() { }

		internal void <.cctor>b__8_1(Entry e) { }

	}

	private const int k_StackSize = 128; //Field offset: 0x0
	private static readonly Func<Entry> k_CreateAction; //Field offset: 0x0
	private static readonly Action<Entry> k_ResetAction; //Field offset: 0x8
	private Stack<Entry>[] m_ThreadEntries; //Field offset: 0x10
	private ImplicitPool<Entry> m_SharedPool; //Field offset: 0x18

	private static EntryPool() { }

	public EntryPool(int maxCapacity = 1024) { }

	public Entry Get() { }

	public void ReturnAll() { }

}

