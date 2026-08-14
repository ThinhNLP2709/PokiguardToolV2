namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class NoInterpRenderTextureParameter : VolumeParameter<RenderTexture>
{

	public NoInterpRenderTextureParameter(RenderTexture value, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

