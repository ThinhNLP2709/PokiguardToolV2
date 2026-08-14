namespace UnityEngine.InputSystem.Processors;

public class StickDeadzoneProcessor : InputProcessor<Vector2>
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

	public StickDeadzoneProcessor() { }

	private float get_maxOrDefault() { }

	private float get_minOrDefault() { }

	private float GetDeadZoneAdjustedValue(float value) { }

	public virtual Vector2 Process(Vector2 value, InputControl control = null) { }

	public virtual string ToString() { }

}

