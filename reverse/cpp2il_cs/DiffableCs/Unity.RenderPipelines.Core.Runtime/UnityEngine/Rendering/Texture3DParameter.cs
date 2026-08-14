namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class Texture3DParameter : VolumeParameter<Texture>
{

	public Texture3DParameter(Texture value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

