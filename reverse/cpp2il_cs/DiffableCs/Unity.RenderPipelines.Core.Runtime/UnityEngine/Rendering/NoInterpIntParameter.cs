namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class NoInterpIntParameter : VolumeParameter<Int32>
{

	public NoInterpIntParameter(int value, bool overrideState = false) { }

}

