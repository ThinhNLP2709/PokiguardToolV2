namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class FloatParameter : VolumeParameter<Single>
{

	public FloatParameter(float value, bool overrideState = false) { }

	public virtual void Interp(float from, float to, float t) { }

}

