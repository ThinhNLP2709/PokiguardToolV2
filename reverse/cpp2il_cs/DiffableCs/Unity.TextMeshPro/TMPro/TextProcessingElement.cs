namespace TMPro;

[DebuggerDisplay("{DebuggerDisplay()}")]
internal struct TextProcessingElement
{
	private TextProcessingElementType m_ElementType; //Field offset: 0x0
	private int m_StartIndex; //Field offset: 0x4
	private int m_Length; //Field offset: 0x8
	private CharacterElement m_CharacterElement; //Field offset: 0x10
	private MarkupElement m_MarkupElement; //Field offset: 0x20

	public CharacterElement CharacterElement
	{
		 get { } //Length: 11
	}

	public TextProcessingElementType ElementType
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public int Length
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public MarkupElement MarkupElement
	{
		 get { } //Length: 5
		 set { } //Length: 15
	}

	public int StartIndex
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public static TextProcessingElement Undefined
	{
		 get { } //Length: 20
	}

	public TextProcessingElement(TextProcessingElementType elementType, int startIndex, int length) { }

	public TextProcessingElement(TMP_TextElement textElement, int startIndex, int length) { }

	public TextProcessingElement(CharacterElement characterElement, int startIndex, int length) { }

	public TextProcessingElement(MarkupElement markupElement) { }

	private string DebuggerDisplay() { }

	public CharacterElement get_CharacterElement() { }

	public TextProcessingElementType get_ElementType() { }

	public int get_Length() { }

	public MarkupElement get_MarkupElement() { }

	public int get_StartIndex() { }

	public static TextProcessingElement get_Undefined() { }

	public void set_ElementType(TextProcessingElementType value) { }

	public void set_Length(int value) { }

	public void set_MarkupElement(MarkupElement value) { }

	public void set_StartIndex(int value) { }

}

