namespace UnityEngine.Rendering.Universal;

internal class Universal2DResourceData : UniversalResourceDataBase
{
	private TextureHandle _intermediateDepth; //Field offset: 0x18
	private TextureHandle[][] _lightTextures; //Field offset: 0x28
	private TextureHandle[] _cameraNormalsTexture; //Field offset: 0x30
	private TextureHandle _shadowsTexture; //Field offset: 0x38
	private TextureHandle _shadowsDepth; //Field offset: 0x48
	private TextureHandle _upscaleTexture; //Field offset: 0x58
	private TextureHandle _cameraSortingLayerTexture; //Field offset: 0x68

	internal TextureHandle cameraSortingLayerTexture
	{
		internal get { } //Length: 41
		internal set { } //Length: 121
	}

	internal TextureHandle intermediateDepth
	{
		internal get { } //Length: 41
		internal set { } //Length: 121
	}

	internal TextureHandle[][] lightTextures
	{
		internal get { } //Length: 365
		internal set { } //Length: 312
	}

	internal TextureHandle[] normalsTexture
	{
		internal get { } //Length: 12
		internal set { } //Length: 15
	}

	internal TextureHandle shadowsDepth
	{
		internal get { } //Length: 41
		internal set { } //Length: 121
	}

	internal TextureHandle shadowsTexture
	{
		internal get { } //Length: 41
		internal set { } //Length: 121
	}

	internal TextureHandle upscaleTexture
	{
		internal get { } //Length: 41
		internal set { } //Length: 121
	}

	public Universal2DResourceData() { }

	private TextureHandle[][] CheckAndGetTextureHandle(ref TextureHandle[][] handle) { }

	private void CheckAndSetTextureHandle(ref TextureHandle[][] handle, TextureHandle[][] newHandle) { }

	internal TextureHandle get_cameraSortingLayerTexture() { }

	internal TextureHandle get_intermediateDepth() { }

	internal TextureHandle[][] get_lightTextures() { }

	internal TextureHandle[] get_normalsTexture() { }

	internal TextureHandle get_shadowsDepth() { }

	internal TextureHandle get_shadowsTexture() { }

	internal TextureHandle get_upscaleTexture() { }

	public virtual void Reset() { }

	internal void set_cameraSortingLayerTexture(TextureHandle value) { }

	internal void set_intermediateDepth(TextureHandle value) { }

	internal void set_lightTextures(TextureHandle[][] value) { }

	internal void set_normalsTexture(TextureHandle[] value) { }

	internal void set_shadowsDepth(TextureHandle value) { }

	internal void set_shadowsTexture(TextureHandle value) { }

	internal void set_upscaleTexture(TextureHandle value) { }

}

