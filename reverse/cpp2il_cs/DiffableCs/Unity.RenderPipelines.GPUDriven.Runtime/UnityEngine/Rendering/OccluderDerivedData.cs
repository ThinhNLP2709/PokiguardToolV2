namespace UnityEngine.Rendering;

internal struct OccluderDerivedData
{
	public Matrix4x4 viewProjMatrix; //Field offset: 0x0
	public Vector4 viewOriginWorldSpace; //Field offset: 0x40
	public Vector4 radialDirWorldSpace; //Field offset: 0x50
	public Vector4 facingDirWorldSpace; //Field offset: 0x60

	public static OccluderDerivedData FromParameters(in OccluderSubviewUpdate occluderSubviewUpdate) { }

}

