namespace UnityEngine.UIElements;

public struct StyleBackgroundPosition : IStyleValue<BackgroundPosition>, IEquatable<StyleBackgroundPosition>
{
	private BackgroundPosition m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0xC

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override BackgroundPosition value
	{
		 get { } //Length: 58
		 set { } //Length: 22
	}

	public StyleBackgroundPosition(BackgroundPosition v) { }

	public StyleBackgroundPosition(StyleKeyword keyword) { }

	internal StyleBackgroundPosition(BackgroundPosition v, StyleKeyword keyword) { }

	public override bool Equals(StyleBackgroundPosition other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override BackgroundPosition get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleBackgroundPosition lhs, StyleBackgroundPosition rhs) { }

	public static StyleBackgroundPosition op_Implicit(StyleKeyword keyword) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(BackgroundPosition value) { }

	public virtual string ToString() { }

}

