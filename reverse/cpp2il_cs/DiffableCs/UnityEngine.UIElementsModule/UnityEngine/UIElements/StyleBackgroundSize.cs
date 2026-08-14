namespace UnityEngine.UIElements;

public struct StyleBackgroundSize : IStyleValue<BackgroundSize>, IEquatable<StyleBackgroundSize>
{
	private BackgroundSize m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0x14

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override BackgroundSize value
	{
		 get { } //Length: 37
		 set { } //Length: 20
	}

	public StyleBackgroundSize(StyleKeyword keyword) { }

	internal StyleBackgroundSize(BackgroundSize v, StyleKeyword keyword) { }

	public override bool Equals(StyleBackgroundSize other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override BackgroundSize get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleBackgroundSize lhs, StyleBackgroundSize rhs) { }

	public static StyleBackgroundSize op_Implicit(StyleKeyword keyword) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(BackgroundSize value) { }

	public virtual string ToString() { }

}

