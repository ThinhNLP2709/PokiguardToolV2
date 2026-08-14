namespace UnityEngine.Rendering.RenderGraphModule;

internal struct TextureAccess
{
	public TextureHandle textureHandle; //Field offset: 0x0
	public int mipLevel; //Field offset: 0x10
	public int depthSlice; //Field offset: 0x14
	public AccessFlags flags; //Field offset: 0x18

	public TextureAccess(TextureHandle handle, AccessFlags flags, int mipLevel, int depthSlice) { }

}

