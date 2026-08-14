namespace UnityEngine.UIElements;

public struct StyleColor : IStyleValue<Color>, IEquatable<StyleColor>
{
	private Color m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0x10

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override Color value
	{
		 get { } //Length: 26
		 set { } //Length: 14
	}

	public StyleColor(Color v) { }

	public StyleColor(StyleKeyword keyword) { }

	internal StyleColor(Color v, StyleKeyword keyword) { }

	public override bool Equals(StyleColor other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override Color get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleColor lhs, StyleColor rhs) { }

	public static StyleColor op_Implicit(StyleKeyword keyword) { }

	public static StyleColor op_Implicit(Color v) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(Color value) { }

	public virtual string ToString() { }

}

