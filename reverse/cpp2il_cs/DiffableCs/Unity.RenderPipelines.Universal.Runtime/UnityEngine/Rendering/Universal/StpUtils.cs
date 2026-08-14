namespace UnityEngine.Rendering.Universal;

internal static class StpUtils
{
	internal static JitterFunc s_JitterFunc; //Field offset: 0x0

	private static StpUtils() { }

	private static void CalculateJitter(int frameIndex, out Vector2 jitter, out bool allowScaling) { }

	internal static void Execute(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, TextureHandle inputColor, TextureHandle inputDepth, TextureHandle inputMotion, TextureHandle destination, Texture2D noiseTexture) { }

	private static void PopulateStpConfig(UniversalCameraData cameraData, TextureHandle inputColor, TextureHandle inputDepth, TextureHandle inputMotion, int debugViewIndex, TextureHandle debugView, TextureHandle destination, Texture2D noiseTexture, out Config config) { }

}

