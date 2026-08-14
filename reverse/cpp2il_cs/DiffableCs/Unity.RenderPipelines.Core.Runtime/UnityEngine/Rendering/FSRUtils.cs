namespace UnityEngine.Rendering;

public static class FSRUtils
{
	private static class ShaderConstants
	{
		public static readonly int _FsrEasuConstants0; //Field offset: 0x0
		public static readonly int _FsrEasuConstants1; //Field offset: 0x4
		public static readonly int _FsrEasuConstants2; //Field offset: 0x8
		public static readonly int _FsrEasuConstants3; //Field offset: 0xC
		public static readonly int _FsrRcasConstants; //Field offset: 0x10

		private static ShaderConstants() { }

	}

	internal const float kMaxSharpnessStops = 2.5; //Field offset: 0x0
	public const float kDefaultSharpnessStops = 0.2; //Field offset: 0x0
	public const float kDefaultSharpnessLinear = 0.92; //Field offset: 0x0

	public static bool IsSupported() { }

	public static void SetEasuConstants(CommandBuffer cmd, Vector2 inputViewportSizeInPixels, Vector2 inputImageSizeInPixels, Vector2 outputImageSizeInPixels) { }

	public static void SetEasuConstants(BaseCommandBuffer cmd, Vector2 inputViewportSizeInPixels, Vector2 inputImageSizeInPixels, Vector2 outputImageSizeInPixels) { }

	public static void SetRcasConstants(CommandBuffer cmd, float sharpnessStops = 0.2) { }

	public static void SetRcasConstantsLinear(CommandBuffer cmd, float sharpnessLinear = 0.92) { }

	public static void SetRcasConstantsLinear(RasterCommandBuffer cmd, float sharpnessLinear = 0.92) { }

}

