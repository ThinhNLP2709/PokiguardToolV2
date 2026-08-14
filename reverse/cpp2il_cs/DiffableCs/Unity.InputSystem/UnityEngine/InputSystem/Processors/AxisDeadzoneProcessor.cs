namespace UnityEngine.InputSystem.Processors;

public class AxisDeadzoneProcessor : InputProcessor<Single>
{
	public float min; //Field offset: 0x10
	public float max; //Field offset: 0x14

	private float maxOrDefault
	{
		private get { } //Length: 110
	}

	private float minOrDefault
	{
		private get { } //Length: 110
	}

	public AxisDeadzoneProcessor() { }

	private float get_maxOrDefault() { }

	private float get_minOrDefault() { }

	public virtual float Process(float value, InputControl control = null) { }

	public virtual string ToString() { }

}

