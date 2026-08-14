namespace UnityEngine.Rendering;

internal struct PackedMatrix
{
	public float4 packed0; //Field offset: 0x0
	public float4 packed1; //Field offset: 0x10
	public float4 packed2; //Field offset: 0x20

	public static PackedMatrix FromFloat4x4(in float4x4 m) { }

	public static PackedMatrix FromMatrix4x4(in Matrix4x4 m) { }

}

