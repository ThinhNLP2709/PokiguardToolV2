/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class LightFalloffLUT // TypeDefIndex: 13579
	{
		// Fields
		public const float DistThresholdSqr = 0.0001f; // Metadata: 0x006A7D3B
		private const float ToZeroFadeStart = 0.64000005f; // Metadata: 0x006A7D3F
		private const float ConstantFac = 1f; // Metadata: 0x006A7D43
		private const float QuadraticFac = 25f; // Metadata: 0x006A7D47
	
		// Constructors
		public LightFalloffLUT(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static float CalculateLightQuadFac(float range); // 0x0000000181DEE5D0-0x0000000181DEE5F0
		private static float LightAttenuateNormalized(float distSqr); // 0x0000000181DEE730-0x0000000181DEE780
		public static float LegacyUnityFalloff(float normalizedDistance); // 0x0000000181DEE6A0-0x0000000181DEE730
		public static float SmoothDistanceAttenuation(float squaredDistance, float invSqrAttenuationRadius); // 0x0000000181DEE780-0x0000000181DEE7D0
		public static float InverseSquaredFalloffSmooth(float squaredDistance, float invSqrAttenuationRadius); // 0x0000000181DEE5F0-0x0000000181DEE670
		public static float InverseSquaredFalloff(float squaredDistance); // 0x0000000181DEE670-0x0000000181DEE6A0
		public static float[] BuildLightFalloffLUTs(LightFalloffDesc[] lightFalloffDescs, uint lightFalloffLUTLength = 1024 /* Metadata: 0x006A7D39 */); // 0x0000000181DEE270-0x0000000181DEE5D0
	}
}
