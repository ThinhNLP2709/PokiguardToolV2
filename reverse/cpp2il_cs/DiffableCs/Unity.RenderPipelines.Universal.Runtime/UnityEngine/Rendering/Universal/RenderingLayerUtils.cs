namespace UnityEngine.Rendering.Universal;

internal static class RenderingLayerUtils
{
	internal enum Event
	{
		DepthNormalPrePass = 0,
		Opaque = 1,
	}

	internal enum MaskSize
	{
		Bits8 = 0,
		Bits16 = 1,
		Bits24 = 2,
		Bits32 = 3,
	}


	private static Event Combine(Event a, Event b) { }

	private static MaskSize Combine(MaskSize a, MaskSize b) { }

	public static void CombineRendererEvents(bool isDeferred, int msaaSampleCount, Event rendererEvent, ref Event combinedEvent) { }

	private static int GetBits(MaskSize maskSize) { }

	public static GraphicsFormat GetFormat(MaskSize maskSize) { }

	private static MaskSize GetMaskSize(int bits) { }

	public static bool RequireRenderingLayers(UniversalRenderer universalRenderer, List<ScriptableRendererFeature> rendererFeatures, int msaaSampleCount, out Event combinedEvent, out MaskSize combinedMaskSize) { }

	internal static bool RequireRenderingLayers(List<ScriptableRendererFeature> rendererFeatures, RenderingMode renderingMode, bool accurateGbufferNormals, int msaaSampleCount, out Event combinedEvent, out MaskSize combinedMaskSize) { }

	public static void SetupProperties(CommandBuffer cmd, MaskSize maskSize) { }

	internal static void SetupProperties(RasterCommandBuffer cmd, MaskSize maskSize) { }

	public static uint ToValidRenderingLayers(uint renderingLayers) { }

}

