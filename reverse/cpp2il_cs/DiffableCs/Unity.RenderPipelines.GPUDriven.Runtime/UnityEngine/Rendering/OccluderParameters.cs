namespace UnityEngine.Rendering;

public struct OccluderParameters
{
	public int viewInstanceID; //Field offset: 0x0
	public int subviewCount; //Field offset: 0x4
	public TextureHandle depthTexture; //Field offset: 0x8
	public Vector2Int depthSize; //Field offset: 0x18
	public bool depthIsArray; //Field offset: 0x20

	public OccluderParameters(int viewInstanceID) { }

}

