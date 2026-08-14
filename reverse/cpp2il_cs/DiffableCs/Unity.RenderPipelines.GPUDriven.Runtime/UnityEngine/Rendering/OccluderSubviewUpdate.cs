namespace UnityEngine.Rendering;

public struct OccluderSubviewUpdate
{
	public int subviewIndex; //Field offset: 0x0
	public int depthSliceIndex; //Field offset: 0x4
	public Vector2Int depthOffset; //Field offset: 0x8
	public Matrix4x4 viewMatrix; //Field offset: 0x10
	public Matrix4x4 invViewMatrix; //Field offset: 0x50
	public Matrix4x4 gpuProjMatrix; //Field offset: 0x90
	public Vector3 viewOffsetWorldSpace; //Field offset: 0xD0

	public OccluderSubviewUpdate(int subviewIndex) { }

}

