namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class CubemapParameter : VolumeParameter<Texture>
{

	public CubemapParameter(Texture value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

