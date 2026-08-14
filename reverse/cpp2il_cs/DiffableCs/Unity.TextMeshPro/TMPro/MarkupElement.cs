namespace TMPro;

internal struct MarkupElement
{
	private MarkupAttribute[] m_Attributes; //Field offset: 0x0

	public MarkupAttribute[] Attributes
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public int NameHashCode
	{
		 get { } //Length: 39
		 set { } //Length: 119
	}

	public int ValueHashCode
	{
		 get { } //Length: 39
		 set { } //Length: 37
	}

	public int ValueLength
	{
		 get { } //Length: 39
		 set { } //Length: 37
	}

	public int ValueStartIndex
	{
		 get { } //Length: 39
		 set { } //Length: 37
	}

	public MarkupElement(int nameHashCode, int startIndex, int length) { }

	public MarkupAttribute[] get_Attributes() { }

	public int get_NameHashCode() { }

	public int get_ValueHashCode() { }

	public int get_ValueLength() { }

	public int get_ValueStartIndex() { }

	public void set_Attributes(MarkupAttribute[] value) { }

	public void set_NameHashCode(int value) { }

	public void set_ValueHashCode(int value) { }

	public void set_ValueLength(int value) { }

	public void set_ValueStartIndex(int value) { }

}

