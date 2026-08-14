namespace UnityEngine.UIElements;

public struct StyleList : IStyleValue<List`1<T>>, IEquatable<StyleList`1<T>>
{
	private StyleKeyword m_Keyword; //Field offset: 0x0
	private List<T> m_Value; //Field offset: 0x0

	public override StyleKeyword keyword
	{
		 get { } //Length: 5
		 set { } //Length: 3
	}

	public override List<T> value
	{
		 get { } //Length: 13
		 set { } //Length: 34
	}

	public StyleList`1(StyleKeyword keyword) { }

	internal StyleList`1(List<T> v, StyleKeyword keyword) { }

	public override bool Equals(StyleList<T> other) { }

	public virtual bool Equals(object obj) { }

	public override StyleKeyword get_keyword() { }

	public override List<T> get_value() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(StyleList<T> lhs, StyleList<T> rhs) { }

	public static StyleList<T> op_Implicit(StyleKeyword keyword) { }

	public override void set_keyword(StyleKeyword value) { }

	public override void set_value(List<T> value) { }

	public virtual string ToString() { }

}

