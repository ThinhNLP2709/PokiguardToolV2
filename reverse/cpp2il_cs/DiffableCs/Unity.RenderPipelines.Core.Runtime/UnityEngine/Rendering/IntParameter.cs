namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class IntParameter : VolumeParameter<Int32>
{

	public IntParameter(int value, bool overrideState = false) { }

	public virtual void Interp(int from, int to, float t) { }

}

