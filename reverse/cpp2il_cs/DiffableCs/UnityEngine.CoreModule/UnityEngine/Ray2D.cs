namespace UnityEngine;

public struct Ray2D : IFormattable
{
	private Vector2 m_Origin; //Field offset: 0x0
	private Vector2 m_Direction; //Field offset: 0x8

	public Vector2 direction
	{
		 get { } //Length: 19
		 set { } //Length: 59
	}

	public Vector2 origin
	{
		 get { } //Length: 18
		 set { } //Length: 4
	}

	public Vector2 get_direction() { }

	public Vector2 get_origin() { }

	public void set_direction(Vector2 value) { }

	public void set_origin(Vector2 value) { }

	public virtual string ToString() { }

	public override string ToString(string format, IFormatProvider formatProvider) { }

}

