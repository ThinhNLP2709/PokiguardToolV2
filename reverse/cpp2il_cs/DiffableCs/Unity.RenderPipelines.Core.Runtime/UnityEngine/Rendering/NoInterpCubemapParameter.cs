namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class NoInterpCubemapParameter : VolumeParameter<Cubemap>
{

	public NoInterpCubemapParameter(Cubemap value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

