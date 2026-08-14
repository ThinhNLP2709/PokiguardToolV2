namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class NoInterpTextureParameter : VolumeParameter<Texture>
{

	public NoInterpTextureParameter(Texture value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

