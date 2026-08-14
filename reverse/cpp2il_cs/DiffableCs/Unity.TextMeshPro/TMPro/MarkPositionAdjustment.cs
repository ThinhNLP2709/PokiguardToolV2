namespace TMPro;

public struct MarkPositionAdjustment
{
	[SerializeField]
	private float m_XPositionAdjustment; //Field offset: 0x0
	[SerializeField]
	private float m_YPositionAdjustment; //Field offset: 0x4

	public float xPositionAdjustment
	{
		 get { } //Length: 5
		 set { } //Length: 5
	}

	public float yPositionAdjustment
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public MarkPositionAdjustment(float x, float y) { }

	public float get_xPositionAdjustment() { }

	public float get_yPositionAdjustment() { }

	public void set_xPositionAdjustment(float value) { }

	public void set_yPositionAdjustment(float value) { }

}

