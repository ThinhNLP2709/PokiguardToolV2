namespace TMPro;

public class TMP_TextElement
{
	[SerializeField]
	internal TextElementType m_ElementType; //Field offset: 0x10
	[SerializeField]
	internal uint m_Unicode; //Field offset: 0x14
	internal TMP_Asset m_TextAsset; //Field offset: 0x18
	internal Glyph m_Glyph; //Field offset: 0x20
	[SerializeField]
	internal uint m_GlyphIndex; //Field offset: 0x28
	[SerializeField]
	internal float m_Scale; //Field offset: 0x2C

	public TextElementType elementType
	{
		 get { } //Length: 5
	}

	public Glyph glyph
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public uint glyphIndex
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public float scale
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public TMP_Asset textAsset
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public uint unicode
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public TMP_TextElement() { }

	public TextElementType get_elementType() { }

	public Glyph get_glyph() { }

	public uint get_glyphIndex() { }

	public float get_scale() { }

	public TMP_Asset get_textAsset() { }

	public uint get_unicode() { }

	public void set_glyph(Glyph value) { }

	public void set_glyphIndex(uint value) { }

	public void set_scale(float value) { }

	public void set_textAsset(TMP_Asset value) { }

	public void set_unicode(uint value) { }

}

