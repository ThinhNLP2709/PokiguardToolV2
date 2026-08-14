namespace UnityEngine.UIElements;

public struct StyleRotate : IStyleValue<Rotate>, IEquatable<StyleRotate>
{
	private Rotate m_Value; //Field offset: 0x0
	private StyleKeyword m_Keyword; //Field offset: 0x18

	public override StyleKeyword keyword
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override Rotate value
	{
		 get { } //Length: 301
		 set { } //Length: 24
	}

	public StyleRotate(Rotate v) { }

	public StyleRotate(StyleKeyword keyword) { }

	internal StyleRotate(Rotate v, StyleKeyword keyword) { }

	public override bool Equals(StyleRotate other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override Rotate get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleRotate lhs, StyleRotate rhs) { }

	public static StyleRotate op_Implicit(StyleKeyword keyword) { }

	public static StyleRotate op_Implicit(Rotate v) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(Rotate value) { }

	public virtual string ToString() { }

}

