/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal static class SphericalHarmonicsUtil // TypeDefIndex: 13606
	{
		// Fields
		private const float SH_L0_Normalization = 0.2820948f; // Metadata: 0x006A7D72
		private const float SH_L1_Normalization = 0.48860252f; // Metadata: 0x006A7D76
		private const float SH_L2_2_Normalization = 1.0925485f; // Metadata: 0x006A7D7A
		private const float SH_L2_1_Normalization = 1.0925485f; // Metadata: 0x006A7D7E
		private const float SH_L20_Normalization = 0.31539157f; // Metadata: 0x006A7D82
		private const float SH_L21_Normalization = 1.0925485f; // Metadata: 0x006A7D86
		private const float SH_L22_Normalization = 0.54627424f; // Metadata: 0x006A7D8A
	
		// Methods
		private static float SHL0(); // 0x0000000181E14060-0x0000000181E14070
		private static float SHL1_1(float3 direction); // 0x0000000181E14090-0x0000000181E140A0
		private static float SHL10(float3 direction); // 0x0000000181E14070-0x0000000181E14080
		private static float SHL11(float3 direction); // 0x0000000181E14080-0x0000000181E14090
		private static float SHL2_2(float3 direction); // 0x0000000181E14130-0x0000000181E14150
		private static float SHL2_1(float3 direction); // 0x0000000181E14110-0x0000000181E14130
		private static float SHL20(float3 direction); // 0x0000000181E140A0-0x0000000181E140D0
		private static float SHL21(float3 direction); // 0x0000000181E140D0-0x0000000181E140F0
		private static float SHL22(float3 direction); // 0x0000000181E140F0-0x0000000181E14110
		public static float3 EvaluateSH(Span<float> sh, float3 direction); // 0x0000000181E13D10-0x0000000181E14060
	}
}
