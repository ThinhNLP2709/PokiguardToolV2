namespace UnityEngine.UIElements;

public struct StyleTranslate : IStyleValue<Translate>, IEquatable<StyleTranslate>
{
	private Translate m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0x18

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override Translate value
	{
		 get { } //Length: 171
		 set { } //Length: 24
	}

	public StyleTranslate(Translate v) { }

	public StyleTranslate(StyleKeyword keyword) { }

	internal StyleTranslate(Translate v, StyleKeyword keyword) { }

	public override bool Equals(StyleTranslate other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override Translate get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleTranslate lhs, StyleTranslate rhs) { }

	public static StyleTranslate op_Implicit(StyleKeyword keyword) { }

	public static StyleTranslate op_Implicit(Translate v) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(Translate value) { }

	public virtual string ToString() { }

}

