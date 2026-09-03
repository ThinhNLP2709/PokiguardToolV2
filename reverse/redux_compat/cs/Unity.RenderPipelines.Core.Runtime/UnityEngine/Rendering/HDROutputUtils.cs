/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class HDROutputUtils // TypeDefIndex: 5769
	{
		// Nested types
		[Flags]
		public enum Operation // TypeDefIndex: 5770
		{
			None = 0,
			ColorConversion = 1,
			ColorEncoding = 2
		}
	
		public struct HDRDisplayInformation // TypeDefIndex: 5771
		{
			// Fields
			public int maxFullFrameToneMapLuminance; // 0x00
			public int maxToneMapLuminance; // 0x04
			public int minToneMapLuminance; // 0x08
			public float paperWhiteNits; // 0x0C
	
			// Constructors
			public HDRDisplayInformation(int maxFullFrameToneMapLuminance, int maxToneMapLuminance, int minToneMapLuminance, float hdrPaperWhiteNits); // 0x0000000181EB6300-0x0000000181EB6320
		}
	
		public static class ShaderKeywords // TypeDefIndex: 5772
		{
			// Fields
			public const string HDR_COLORSPACE_CONVERSION = "HDR_COLORSPACE_CONVERSION"; // Metadata: 0x00661AA9
			public const string HDR_ENCODING = "HDR_ENCODING"; // Metadata: 0x00661AC3
			public const string HDR_COLORSPACE_CONVERSION_AND_ENCODING = "HDR_COLORSPACE_CONVERSION_AND_ENCODING"; // Metadata: 0x00661AD0
			public const string HDR_INPUT = "HDR_INPUT"; // Metadata: 0x00661AF7
			internal static readonly ShaderKeyword HDRColorSpaceConversion; // 0x00
			internal static readonly ShaderKeyword HDREncoding; // 0x10
			internal static readonly ShaderKeyword HDRColorSpaceConversionAndEncoding; // 0x20
			internal static readonly ShaderKeyword HDRInput; // 0x30
	
			// Constructors
			static ShaderKeywords(); // 0x0000000181EB9640-0x0000000181EB97C0
		}
	
		private static class ShaderPropertyId // TypeDefIndex: 5773
		{
			// Fields
			public static readonly int hdrColorSpace; // 0x00
			public static readonly int hdrEncoding; // 0x04
	
			// Constructors
			static ShaderPropertyId(); // 0x0000000181EB97C0-0x0000000181EB9840
		}
	
		// Methods
		public static bool GetColorSpaceForGamut(ColorGamut gamut, out int colorspace); // 0x0000000181EB6B70-0x0000000181EB6DE0
		public static bool GetColorEncodingForGamut(ColorGamut gamut, out int encoding); // 0x0000000181EB69D0-0x0000000181EB6B70
		public static void ConfigureHDROutput(Material material, ColorGamut gamut, Operation operations); // 0x0000000181EB67B0-0x0000000181EB69D0
		public static void ConfigureHDROutput(MaterialPropertyBlock properties, ColorGamut gamut); // 0x0000000181EB64C0-0x0000000181EB6590
		public static void ConfigureHDROutput(Material material, Operation operations); // 0x0000000181EB6320-0x0000000181EB64C0
		public static void ConfigureHDROutput(ComputeShader computeShader, ColorGamut gamut, Operation operations); // 0x0000000181EB6590-0x0000000181EB67B0
		public static bool IsShaderVariantValid(ShaderKeywordSet shaderKeywordSet, bool isHDREnabled); // 0x0000000181EB6DE0-0x0000000181EB6F00
	}
}
