/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Sampling;
using UnityEngine.Rendering.UnifiedRayTracing;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class Util // TypeDefIndex: 13601
	{
		// Nested types
		internal static class ShaderProperties // TypeDefIndex: 13602
		{
			// Fields
			public static readonly int ScramblingTileXSPP; // 0x00
			public static readonly int RankingTileXSPP; // 0x04
			public static readonly int ScramblingTexture; // 0x08
			public static readonly int OwenScrambledTexture; // 0x0C
			public static readonly int NumLights; // 0x10
			public static readonly int NumEmissiveMeshes; // 0x14
			public static readonly int LightList; // 0x18
			public static readonly int MainDirectionalLight; // 0x1C
			public static readonly int HasMainDirectionalLight; // 0x20
			public static readonly int HasEnvironmentLight; // 0x24
			public static readonly int LightFalloff; // 0x28
			public static readonly int LightFalloffLUTRange; // 0x2C
			public static readonly int LightFalloffLUTLength; // 0x30
			public static readonly int MaterialList; // 0x34
			public static readonly int AlbedoTextures; // 0x38
			public static readonly int EmissionTextures; // 0x3C
			public static readonly int TransmissionTextures; // 0x40
			public static readonly int AtlasTexelSize; // 0x44
			public static readonly int EnvironmentCdfConditionalResolution; // 0x48
			public static readonly int EnvironmentCdfMarginalResolution; // 0x4C
			public static readonly int EnvironmentCdfConditionalBuffer; // 0x50
			public static readonly int EnvironmentCdfMarginalBuffer; // 0x54
			public static readonly int SceneAccelStruct; // 0x58
			public static readonly int EnvTex; // 0x5C
			public static readonly int LightEvaluations; // 0x60
			public static readonly int PathtracerAsGiPreviewMode; // 0x64
			public static readonly int RenderedInstances; // 0x68
			public static readonly int PreExpose; // 0x6C
			public static readonly int BounceCount; // 0x70
			public static readonly int MaxIntensity; // 0x74
			public static readonly int ExposureScale; // 0x78
			public static readonly int LightPickingMethod; // 0x7C
			public static readonly int IndirectScale; // 0x80
			public static readonly int FrameIndex; // 0x84
			public static readonly int EnableSubPixelJittering; // 0x88
			public static readonly int AlbedoBoost; // 0x8C
			public static readonly int EnvIntensityMultiplier; // 0x90
			public static readonly int ExposureTexture; // 0x94
			public static readonly int CookieAtlas; // 0x98
			public static readonly int CubemapAtlas; // 0x9C
	
			// Constructors
			static ShaderProperties(); // 0x0000000181E13610-0x0000000181E13D10
		}
	
		// Constructors
		public Util(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static void BindLightBuffers(CommandBuffer cmd, IRayTracingShader shader, World world); // 0x0000000181E15D40-0x0000000181E162E0
		internal static void BindMaterials(CommandBuffer cmd, IRayTracingShader shader, World world); // 0x0000000181E163B0-0x0000000181E16470
		internal static void BindTextures(CommandBuffer cmd, IRayTracingShader shader, World world); // 0x0000000181E16830-0x0000000181E16C80
		internal static void BindMaterialsAndTextures(CommandBuffer cmd, IRayTracingShader shader, World world); // 0x0000000181E162E0-0x0000000181E163B0
		internal static void SetEnvSamplingShaderParams(CommandBuffer cmd, IRayTracingShader shader, EnvironmentCDF envCDF); // 0x0000000181E17C10-0x0000000181E17D80
		internal static void BindAccelerationStructure(CommandBuffer cmd, IRayTracingShader shader, AccelStructAdapter accel); // 0x0000000181E15CD0-0x0000000181E15D40
		internal static void BindWorld(CommandBuffer cmd, IRayTracingShader shader, World world); // 0x0000000181E16C80-0x0000000181E170E0
		internal static void BindPathTracingInputs(CommandBuffer cmd, IRayTracingShader shader, uint risCandidateCount, bool preExpose, int bounces, float environmentIntensityMultiplier, RenderedGameObjectsFilter renderedGameObjectsFilter, SamplingResources samplingResources, RTHandle emptyTexture); // 0x0000000181E16470-0x0000000181E16830
		internal static void SetLightSamplingKeyword(CommandBuffer cmd, IRayTracingShader shader, LightSamplingMode lightSamplingMode); // 0x0000000181E17D80-0x0000000181E18080
		internal static void SetEmissiveSamplingKeyword(CommandBuffer cmd, IRayTracingShader shader, EmissiveSamplingMode lightSamplingMode); // 0x0000000181E17910-0x0000000181E17C10
		internal static void SetTerrainRayMarchingKeyword(CommandBuffer cmd, IRayTracingShader shader, bool enableTerrain); // 0x0000000181E18080-0x0000000181E181B0
		internal static RayTracingResources LoadOrCreateRayTracingResources(); // 0x0000000181E178C0-0x0000000181E17910
		internal static bool IsStatic(GameObject obj); // 0x0000000181E178A0-0x0000000181E178C0
		internal static bool IsCookieValid(uint cookieTextureIndex); // 0x0000000181E17870-0x0000000181E17880
		internal static bool IsPunctualLightType(LightType lightType); // 0x0000000181E17880-0x0000000181E178A0
		internal static World.LightDescriptor[] ConvertUnityLightsToLightDescriptors(Light[] lights, bool multiplyPunctualLightIntensityByPI); // 0x0000000181E170E0-0x0000000181E17450
		private static Color RGBMultiplied(Color color, float multiplier); // 0x0000000180351740-0x0000000180351770
		internal static Vector3 GetLinearLightColor(Light light); // 0x0000000181E17630-0x0000000181E17670
		internal static Vector3 GetLinearLightColor(Light light, float intensityMultiplier); // 0x0000000181E17450-0x0000000181E17630
		internal static Material[] GetMaterials(MeshRenderer renderer); // 0x0000000181E17670-0x0000000181E17870
		internal static ulong EntityIDToUlong(EntityId id); // 0x0000000180370C60-0x0000000180370C70
	}
}
