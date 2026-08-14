namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class ClampedFloatParameter : FloatParameter
{
	public float min; //Field offset: 0x20
	public float max; //Field offset: 0x24

	public virtual float value
	{
		 get { } //Length: 6
		 set { } //Length: 32
	}

	public ClampedFloatParameter(float value, float min, float max, bool overrideState = false) { }

	public virtual float get_value() { }

	public virtual void set_value(float value) { }

}

