namespace UnityEngine.UIElements;

public struct StyleBackground : IStyleValue<Background>, IEquatable<StyleBackground>
{
	private Background m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0x20

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override Background value
	{
		 get { } //Length: 41
		 set { } //Length: 43
	}

	internal StyleBackground(Texture2D v, StyleKeyword keyword) { }

	public StyleBackground(Texture2D v) { }

	public StyleBackground(Sprite v) { }

	public StyleBackground(VectorImage v) { }

	public StyleBackground(StyleKeyword keyword) { }

	internal StyleBackground(Background v, StyleKeyword keyword) { }

	internal StyleBackground(Sprite v, StyleKeyword keyword) { }

	internal StyleBackground(VectorImage v, StyleKeyword keyword) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(StyleBackground other) { }

	public override StyleKeyword get_keyword() { }

	public override Background get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleBackground lhs, StyleBackground rhs) { }

	public static StyleBackground op_Implicit(StyleKeyword keyword) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(Background value) { }

	public virtual string ToString() { }

}

