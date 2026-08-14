namespace UnityEngine.UIElements;

public struct StyleFontDefinition : IStyleValue<FontDefinition>, IEquatable<StyleFontDefinition>
{
	private StyleKeyword m_Keyword; //Field offset: 0x0
	private FontDefinition m_Value; //Field offset: 0x8

	public override StyleKeyword keyword
	{
		 get { } //Length: 5
		 set { } //Length: 3
	}

	public override FontDefinition value
	{
		 get { } //Length: 26
		 set { } //Length: 39
	}

	internal StyleFontDefinition(object obj, StyleKeyword keyword) { }

	internal StyleFontDefinition(FontDefinition f, StyleKeyword keyword) { }

	public StyleFontDefinition(FontDefinition f) { }

	public StyleFontDefinition(FontAsset f) { }

	public StyleFontDefinition(Font f) { }

	public StyleFontDefinition(StyleKeyword keyword) { }

	internal StyleFontDefinition(FontAsset f, StyleKeyword keyword) { }

	internal StyleFontDefinition(Font f, StyleKeyword keyword) { }

	public override bool Equals(StyleFontDefinition other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override FontDefinition get_value() { }

	public virtual int GetHashCode() { }

	public static StyleFontDefinition op_Implicit(StyleKeyword keyword) { }

	public static StyleFontDefinition op_Implicit(FontDefinition f) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(FontDefinition value) { }

}

