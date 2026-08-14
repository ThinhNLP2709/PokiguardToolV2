namespace UnityEngine.Rendering.Universal;

internal class ClearTargetsPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__3_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle color; //Field offset: 0x10
		internal TextureHandle depth; //Field offset: 0x20
		internal RTClearFlags clearFlags; //Field offset: 0x30
		internal Color clearColor; //Field offset: 0x34

		public PassData() { }

	}

	private static ProfilingSampler s_ClearProfilingSampler; //Field offset: 0x0

	private static ClearTargetsPass() { }

	public ClearTargetsPass() { }

	internal static void Render(RenderGraph graph, TextureHandle colorHandle, TextureHandle depthHandle, UniversalCameraData cameraData) { }

	internal static void Render(RenderGraph graph, TextureHandle colorHandle, TextureHandle depthHandle, RTClearFlags clearFlags, Color clearColor) { }

}

