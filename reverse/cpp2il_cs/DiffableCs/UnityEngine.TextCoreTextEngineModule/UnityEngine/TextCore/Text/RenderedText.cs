namespace UnityEngine.TextCore.Text;

[IsReadOnly]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule", "UnityEditor.GraphToolsFoundationModule"})]
internal struct RenderedText : IEquatable<RenderedText>, IEquatable<String>
{
	internal struct Enumerator
	{
		private readonly RenderedText m_Source; //Field offset: 0x0
		private int m_Stage; //Field offset: 0x20
		private int m_StageIndex; //Field offset: 0x24
		private char m_Current; //Field offset: 0x28

		public char Current
		{
			 get { } //Length: 5
		}

		public Enumerator(in RenderedText source) { }

		public char get_Current() { }

		public bool MoveNext() { }

	}

	public readonly string value; //Field offset: 0x0
	public readonly int valueStart; //Field offset: 0x8
	public readonly int valueLength; //Field offset: 0xC
	public readonly string suffix; //Field offset: 0x10
	public readonly char repeat; //Field offset: 0x18
	public readonly int repeatCount; //Field offset: 0x1C

	public int CharacterCount
	{
		 get { } //Length: 21
	}

	public RenderedText(string value) { }

	public RenderedText(string value, string suffix) { }

	public RenderedText(string value, int start, int length, string suffix = null) { }

	public RenderedText(char repeat, int repeatCount, string suffix = null) { }

	public string CreateString() { }

	public override bool Equals(RenderedText other) { }

	public override bool Equals(string other) { }

	public virtual bool Equals(object obj) { }

	public int get_CharacterCount() { }

	public Enumerator GetEnumerator() { }

	public virtual int GetHashCode() { }

}

