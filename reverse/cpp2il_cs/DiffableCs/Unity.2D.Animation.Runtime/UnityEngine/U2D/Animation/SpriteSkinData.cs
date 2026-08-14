namespace UnityEngine.U2D.Animation;

internal struct SpriteSkinData
{
	public NativeCustomSlice<Vector3> vertices; //Field offset: 0x0
	public NativeCustomSlice<BoneWeight> boneWeights; //Field offset: 0x10
	public NativeCustomSlice<Matrix4x4> bindPoses; //Field offset: 0x20
	public NativeCustomSlice<Vector4> tangents; //Field offset: 0x30
	public bool hasTangents; //Field offset: 0x40
	public int spriteVertexStreamSize; //Field offset: 0x44
	public int spriteVertexCount; //Field offset: 0x48
	public int tangentVertexOffset; //Field offset: 0x4C
	public int deformVerticesStartPos; //Field offset: 0x50
	public int transformId; //Field offset: 0x54
	public NativeCustomSlice<Int32> boneTransformId; //Field offset: 0x58

}

