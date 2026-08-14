namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class RenderTextureParameter : VolumeParameter<RenderTexture>
{

	public RenderTextureParameter(RenderTexture value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

