namespace UnityEngine.Rendering;

public static class HDROutputUtils
{
	internal struct HDRDisplayInformation
	{
		public int maxFullFrameToneMapLuminance; //Field offset: 0x0
		public int maxToneMapLuminance; //Field offset: 0x4
		public int minToneMapLuminance; //Field offset: 0x8
		public float paperWhiteNits; //Field offset: 0xC

		public HDRDisplayInformation(int maxFullFrameToneMapLuminance, int maxToneMapLuminance, int minToneMapLuminance, float hdrPaperWhiteNits) { }

	}

	[Flags]
	internal enum Operation
	{
		None = 0,
		ColorConversion = 1,
		ColorEncoding = 2,
	}

	internal static class ShaderKeywords
	{
		public const string HDR_COLORSPACE_CONVERSION = "HDR_COLORSPACE_CONVERSION"; //Field offset: 0x0
		public const string HDR_ENCODING = "HDR_ENCODING"; //Field offset: 0x0
		public const string HDR_COLORSPACE_CONVERSION_AND_ENCODING = "HDR_COLORSPACE_CONVERSION_AND_ENCODING"; //Field offset: 0x0
		public const string HDR_INPUT = "HDR_INPUT"; //Field offset: 0x0
		internal static readonly ShaderKeyword HDRColorSpaceConversion; //Field offset: 0x0
		internal static readonly ShaderKeyword HDREncoding; //Field offset: 0x10
		internal static readonly ShaderKeyword HDRColorSpaceConversionAndEncoding; //Field offset: 0x20
		internal static readonly ShaderKeyword HDRInput; //Field offset: 0x30

		private static ShaderKeywords() { }

	}

	private static class ShaderPropertyId
	{
		public static readonly int hdrColorSpace; //Field offset: 0x0
		public static readonly int hdrEncoding; //Field offset: 0x4

		private static ShaderPropertyId() { }

	}


	public static void ConfigureHDROutput(Material material, ColorGamut gamut, Operation operations) { }

	public static void ConfigureHDROutput(MaterialPropertyBlock properties, ColorGamut gamut) { }

	public static void ConfigureHDROutput(Material material, Operation operations) { }

	public static void ConfigureHDROutput(ComputeShader computeShader, ColorGamut gamut, Operation operations) { }

	public static bool GetColorEncodingForGamut(ColorGamut gamut, out int encoding) { }

	public static bool GetColorSpaceForGamut(ColorGamut gamut, out int colorspace) { }

	public static bool IsShaderVariantValid(ShaderKeywordSet shaderKeywordSet, bool isHDREnabled) { }

}

