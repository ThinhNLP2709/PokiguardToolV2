namespace UnityEngine.UIElements;

public struct StyleBackgroundRepeat : IStyleValue<BackgroundRepeat>, IEquatable<StyleBackgroundRepeat>
{
	private BackgroundRepeat m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0x8

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override BackgroundRepeat value
	{
		 get { } //Length: 13
		 set { } //Length: 11
	}

	public StyleBackgroundRepeat(BackgroundRepeat v) { }

	public StyleBackgroundRepeat(StyleKeyword keyword) { }

	internal StyleBackgroundRepeat(BackgroundRepeat v, StyleKeyword keyword) { }

	public override bool Equals(StyleBackgroundRepeat other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override BackgroundRepeat get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleBackgroundRepeat lhs, StyleBackgroundRepeat rhs) { }

	public static StyleBackgroundRepeat op_Implicit(StyleKeyword keyword) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(BackgroundRepeat value) { }

	public virtual string ToString() { }

}

