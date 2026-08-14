namespace UnityEngine.InputSystem.EnhancedTouch;

[DefaultMember("Item")]
public struct TouchHistory : IReadOnlyList<Touch>, IEnumerable<Touch>, IEnumerable, IReadOnlyCollection<Touch>
{
	private class Enumerator : IEnumerator<Touch>, IEnumerator, IDisposable
	{
		private readonly TouchHistory m_Owner; //Field offset: 0x10
		private int m_Index; //Field offset: 0x30

		public override Touch Current
		{
			 get { } //Length: 74
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 119
		}

		internal Enumerator(TouchHistory owner) { }

		public override void Dispose() { }

		public override Touch get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	private readonly InputStateHistory<TouchState> m_History; //Field offset: 0x0
	private readonly Finger m_Finger; //Field offset: 0x8
	private readonly int m_Count; //Field offset: 0x10
	private readonly int m_StartIndex; //Field offset: 0x14
	private readonly uint m_Version; //Field offset: 0x18

	public override int Count
	{
		 get { } //Length: 4
	}

	public override Touch Item
	{
		 get { } //Length: 340
	}

	internal TouchHistory(Finger finger, InputStateHistory<TouchState> history, int startIndex = -1, int count = -1) { }

	internal void CheckValid() { }

	public override int get_Count() { }

	public override Touch get_Item(int index) { }

	public override IEnumerator<Touch> GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

