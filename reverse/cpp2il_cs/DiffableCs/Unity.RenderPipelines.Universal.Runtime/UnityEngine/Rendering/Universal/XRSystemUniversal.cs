namespace UnityEngine.Rendering.Universal;

internal static class XRSystemUniversal
{
	private static Matrix4x4[] s_projMatrix; //Field offset: 0x0

	private static XRSystemUniversal() { }

	internal static void BeginLateLatching(Camera camera, XRPassUniversal xrPass) { }

	internal static void EndLateLatching(Camera camera, XRPassUniversal xrPass) { }

	internal static void MarkShaderProperties(RasterCommandBuffer cmd, XRPassUniversal xrPass, bool renderIntoTexture) { }

	internal static void UnmarkShaderProperties(RasterCommandBuffer cmd, XRPassUniversal xrPass) { }

}

