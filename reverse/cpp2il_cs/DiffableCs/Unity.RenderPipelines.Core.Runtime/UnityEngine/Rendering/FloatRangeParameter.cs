namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class FloatRangeParameter : VolumeParameter<Vector2>
{
	public float min; //Field offset: 0x20
	public float max; //Field offset: 0x24

	public virtual Vector2 value
	{
		 get { } //Length: 19
		 set { } //Length: 38
	}

	public FloatRangeParameter(Vector2 value, float min, float max, bool overrideState = false) { }

	public virtual Vector2 get_value() { }

	public virtual void Interp(Vector2 from, Vector2 to, float t) { }

	public virtual void set_value(Vector2 value) { }

}

