namespace UnityEngine.Experimental.Rendering;

[IsReadOnly]
internal struct XRView
{
	internal readonly Matrix4x4 projMatrix; //Field offset: 0x0
	internal readonly Matrix4x4 viewMatrix; //Field offset: 0x40
	internal readonly Matrix4x4 prevViewMatrix; //Field offset: 0x80
	internal readonly Rect viewport; //Field offset: 0xC0
	internal readonly Mesh occlusionMesh; //Field offset: 0xD0
	internal readonly int textureArraySlice; //Field offset: 0xD8
	internal readonly Vector2 eyeCenterUV; //Field offset: 0xDC
	internal readonly bool isPrevViewMatrixValid; //Field offset: 0xE4

	internal XRView(Matrix4x4 projMatrix, Matrix4x4 viewMatrix, Matrix4x4 prevViewMatrix, bool isPrevViewMatrixValid, Rect viewport, Mesh occlusionMesh, int textureArraySlice) { }

	private static Vector2 ComputeEyeCenterUV(Matrix4x4 proj) { }

}

