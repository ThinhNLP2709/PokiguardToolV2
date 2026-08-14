namespace UnityEngine.InputSystem.Utilities;

[DefaultMember("Item")]
internal struct OneOrMore : IReadOnlyList<TValue>, IEnumerable<TValue>, IEnumerable, IReadOnlyCollection<TValue>
{
	private class Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		internal int m_Index; //Field offset: 0x0
		internal OneOrMore<TValue, TList> m_List; //Field offset: 0x0

		public override TValue Current
		{
			 get { } //Length: 31
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 46
		}

		public Enumerator() { }

		public override void Dispose() { }

		public override TValue get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	private readonly bool m_IsSingle; //Field offset: 0x0
	private readonly TValue m_Single; //Field offset: 0x0
	private readonly TList m_Multiple; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 65
	}

	public override TValue Item
	{
		 get { } //Length: 172
	}

	public OneOrMore`2(TValue single) { }

	public OneOrMore`2(TList multiple) { }

	public override int get_Count() { }

	public override TValue get_Item(int index) { }

	public override IEnumerator<TValue> GetEnumerator() { }

	public static OneOrMore<TValue, TList> op_Implicit(TValue single) { }

	public static OneOrMore<TValue, TList> op_Implicit(TList multiple) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

