namespace Unity.VisualScripting;

public interface IUnitConnectionDebugData : IGraphElementDebugData
{

	public int lastInvokeFrame
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float lastInvokeTime
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int get_lastInvokeFrame() { }

	public float get_lastInvokeTime() { }

	public void set_lastInvokeFrame(int value) { }

	public void set_lastInvokeTime(float value) { }

}

