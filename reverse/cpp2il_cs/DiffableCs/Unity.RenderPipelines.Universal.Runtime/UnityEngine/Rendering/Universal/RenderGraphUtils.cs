namespace UnityEngine.Rendering.Universal;

internal static class RenderGraphUtils
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__6_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <SetGlobalTexture>b__6_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle texture; //Field offset: 0x10
		internal int nameID; //Field offset: 0x20

		public PassData() { }

	}

	private static ProfilingSampler s_SetGlobalTextureProfilingSampler; //Field offset: 0x0
	internal const int GBufferSize = 7; //Field offset: 0x0
	internal const int DBufferSize = 3; //Field offset: 0x0
	internal const int LightTextureSize = 4; //Field offset: 0x0

	private static RenderGraphUtils() { }

	public static void SetGlobalTexture(RenderGraph graph, int nameId, TextureHandle handle, string passName = "Set Global Texture", string file = "", int line = 0) { }

	internal static void UseDBufferIfValid(IRasterRenderGraphBuilder builder, UniversalResourceData resourceData) { }

}

