namespace UnityEngine.Experimental.Rendering;

public static class XRBuiltinShaderConstants
{
	public static readonly int unity_StereoCameraProjection; //Field offset: 0x0
	public static readonly int unity_StereoCameraInvProjection; //Field offset: 0x4
	public static readonly int unity_StereoMatrixV; //Field offset: 0x8
	public static readonly int unity_StereoMatrixInvV; //Field offset: 0xC
	public static readonly int unity_StereoMatrixP; //Field offset: 0x10
	public static readonly int unity_StereoMatrixInvP; //Field offset: 0x14
	public static readonly int unity_StereoMatrixVP; //Field offset: 0x18
	public static readonly int unity_StereoMatrixInvVP; //Field offset: 0x1C
	public static readonly int unity_StereoWorldSpaceCameraPos; //Field offset: 0x20
	private static Matrix4x4[] s_cameraProjMatrix; //Field offset: 0x28
	private static Matrix4x4[] s_invCameraProjMatrix; //Field offset: 0x30
	private static Matrix4x4[] s_viewMatrix; //Field offset: 0x38
	private static Matrix4x4[] s_invViewMatrix; //Field offset: 0x40
	private static Matrix4x4[] s_projMatrix; //Field offset: 0x48
	private static Matrix4x4[] s_invProjMatrix; //Field offset: 0x50
	private static Matrix4x4[] s_viewProjMatrix; //Field offset: 0x58
	private static Matrix4x4[] s_invViewProjMatrix; //Field offset: 0x60
	private static Vector4[] s_worldSpaceCameraPos; //Field offset: 0x68

	private static XRBuiltinShaderConstants() { }

	public static void SetBuiltinShaderConstants(CommandBuffer cmd) { }

	public static void SetBuiltinShaderConstants(RasterCommandBuffer cmd) { }

	public static void Update(XRPass xrPass, CommandBuffer cmd, bool renderIntoTexture) { }

	public static void UpdateBuiltinShaderConstants(Matrix4x4 viewMatrix, Matrix4x4 projMatrix, bool renderIntoTexture, int viewIndex) { }

}

