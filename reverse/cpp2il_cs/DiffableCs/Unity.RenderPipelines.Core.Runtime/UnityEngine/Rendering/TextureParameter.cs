namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class TextureParameter : VolumeParameter<Texture>
{
	public TextureDimension dimension; //Field offset: 0x20

	public TextureParameter(Texture value, bool overrideState = false) { }

	public TextureParameter(Texture value, TextureDimension dimension, bool overrideState = false) { }

	public virtual int GetHashCode() { }

}

