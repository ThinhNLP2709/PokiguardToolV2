namespace UnityEngine.UIElements.Layout;

internal struct LayoutValue
{
	private float value; //Field offset: 0x0
	private LayoutUnit unit; //Field offset: 0x4

	public LayoutUnit Unit
	{
		 get { } //Length: 4
	}

	public float Value
	{
		 get { } //Length: 5
	}

	public static LayoutValue Auto() { }

	public bool Equals(LayoutValue other) { }

	public virtual bool Equals(object obj) { }

	public LayoutUnit get_Unit() { }

	public float get_Value() { }

	public virtual int GetHashCode() { }

	public static LayoutValue op_Implicit(float value) { }

	public static LayoutValue Percent(float value) { }

	public static LayoutValue Point(float value) { }

	public static LayoutValue Undefined() { }

}

