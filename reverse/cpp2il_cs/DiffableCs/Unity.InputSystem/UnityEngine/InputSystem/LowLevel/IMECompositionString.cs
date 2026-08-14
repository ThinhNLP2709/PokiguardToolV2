namespace UnityEngine.InputSystem.LowLevel;

[DefaultMember("Item")]
public struct IMECompositionString : IEnumerable<Char>, IEnumerable
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <buffer>e__FixedBuffer
	{
		public char FixedElementField; //Field offset: 0x0

	}

	public struct Enumerator : IEnumerator<Char>, IEnumerator, IDisposable
	{
		private IMECompositionString m_CompositionString; //Field offset: 0x0
		private char m_CurrentCharacter; //Field offset: 0x84
		private int m_CurrentIndex; //Field offset: 0x88

		public override char Current
		{
			 get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 38
		}

		public Enumerator(IMECompositionString compositionString) { }

		public override void Dispose() { }

		public override char get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	private int size; //Field offset: 0x0
	[FixedBuffer(typeof(char), 64)]
	private <buffer>e__FixedBuffer buffer; //Field offset: 0x4

	public int Count
	{
		 get { } //Length: 3
	}

	public char Item
	{
		 get { } //Length: 107
	}

	public IMECompositionString(string characters) { }

	public int get_Count() { }

	public char get_Item(int index) { }

	public override IEnumerator<Char> GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public virtual string ToString() { }

}

