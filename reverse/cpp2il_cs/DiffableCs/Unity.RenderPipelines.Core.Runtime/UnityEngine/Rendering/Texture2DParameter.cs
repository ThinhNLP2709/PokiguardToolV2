namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class Texture2DParameter : VolumeParameter<Texture>
{

	public Texture2DParameter(Texture value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

