/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public sealed class LensFlareCommonSRP // TypeDefIndex: 5637
	{
		// Fields
		private static LensFlareCommonSRP s_Instance; // 0x00
		private static readonly object s_Padlock; // 0x08
		private const int k_DefaultMaxLensFlareWithOcclusion = 128; // Metadata: 0x00661754
		private const int k_DefaultMaxFlareWithOcclusionTemporalSample = 8; // Metadata: 0x00661756
		private const int k_DefaultMergeNeeded = 1; // Metadata: 0x00661757
		public static int maxLensFlareWithOcclusion; // 0x10
		public static int maxLensFlareWithOcclusionTemporalSample; // 0x14
		public static int mergeNeeded; // 0x18
		private RTHandle m_OcclusionRT; // 0x10
		private List<LensFlareCompInfo> m_Data; // 0x18
		private List<int> m_AvailableIndicies; // 0x20
		private int frameIdx; // 0x28
		internal static readonly int _FlareOcclusionPermutation; // 0x1C
		internal static readonly int _FlareOcclusionRemapTex; // 0x20
		internal static readonly int _FlareOcclusionTex; // 0x24
		internal static readonly int _FlareOcclusionIndex; // 0x28
		internal static readonly int _FlareCloudOpacity; // 0x2C
		internal static readonly int _FlareSunOcclusionTex; // 0x30
		internal static readonly int _FlareTex; // 0x34
		internal static readonly int _FlareColorValue; // 0x38
		internal static readonly int _FlareData0; // 0x3C
		internal static readonly int _FlareData1; // 0x40
		internal static readonly int _FlareData2; // 0x44
		internal static readonly int _FlareData3; // 0x48
		internal static readonly int _FlareData4; // 0x4C
		internal static readonly int _FlareData5; // 0x50
		internal static readonly int _FlareData6; // 0x54
		internal static readonly int _FlareRadialTint; // 0x58
		internal static readonly int _ViewId; // 0x5C
		internal static readonly int _LensFlareScreenSpaceBloomMipTexture; // 0x60
		internal static readonly int _LensFlareScreenSpaceResultTexture; // 0x64
		internal static readonly int _LensFlareScreenSpaceSpectralLut; // 0x68
		internal static readonly int _LensFlareScreenSpaceStreakTex; // 0x6C
		internal static readonly int _LensFlareScreenSpaceMipLevel; // 0x70
		internal static readonly int _LensFlareScreenSpaceTintColor; // 0x74
		internal static readonly int _LensFlareScreenSpaceParams1; // 0x78
		internal static readonly int _LensFlareScreenSpaceParams2; // 0x7C
		internal static readonly int _LensFlareScreenSpaceParams3; // 0x80
		internal static readonly int _LensFlareScreenSpaceParams4; // 0x84
		internal static readonly int _LensFlareScreenSpaceParams5; // 0x88
		private static readonly bool s_SupportsLensFlare16bitsFormat; // 0x8C
		private static readonly bool s_SupportsLensFlare32bitsFormat; // 0x8D
		private static readonly bool s_SupportsLensFlare16bitsFormatWithLoadStore; // 0x8E
		private static readonly bool s_SupportsLensFlare32bitsFormatWithLoadStore; // 0x8F
	
		// Properties
		public static RTHandle occlusionRT { get; } // 0x0000000181E80030-0x0000000181E80080 
		private static bool requireOcclusionRTRandomWrite { get; } // 0x0000000181E80080-0x0000000181E800E0 
		public static LensFlareCommonSRP Instance { get; } // 0x0000000181E7FE30-0x0000000181E80030 
	
		// Nested types
		[IsReadOnly]
		internal struct LensFlareCompInfo // TypeDefIndex: 5638
		{
			// Fields
			internal readonly int index; // 0x00
			internal readonly LensFlareComponentSRP comp; // 0x08
	
			// Constructors
			internal LensFlareCompInfo(int idx, LensFlareComponentSRP cmp); // 0x0000000180F37790-0x0000000180F377B0
		}
	
		[CompilerGenerated]
		private struct __c__DisplayClass85_0 // TypeDefIndex: 5639
		{
			// Fields
			public Vector2 screenPos; // 0x00
			public float position; // 0x08
			public float globalCos0; // 0x0C
			public float globalSin0; // 0x10
			public LensFlareDataElementSRP element; // 0x18
			public float combinedScale; // 0x20
			public float usedAspectRatio; // 0x24
		}
	
		// Constructors
		private LensFlareCommonSRP(); // 0x0000000181E7FD70-0x0000000181E7FE30
		static LensFlareCommonSRP(); // 0x0000000181E7F730-0x0000000181E7FD70
	
		// Methods
		private static bool CheckOcclusionBasedOnDeviceType(); // 0x0000000181E77C40-0x0000000181E77C70
		public static bool IsOcclusionRTCompatible(); // 0x0000000181E7BCC0-0x0000000181E7BDD0
		private static GraphicsFormat GetOcclusionRTFormat(); // 0x0000000181E7B320-0x0000000181E7B3D0
		public static void Initialize(); // 0x0000000181E7B6F0-0x0000000181E7B750
		private void Init(); // 0x0000000181E7B3D0-0x0000000181E7B6F0
		public static void Dispose(); // 0x0000000181E78B30-0x0000000181E78C60
		private void Cleanup(); // 0x0000000181E77C70-0x0000000181E77D60
		public bool IsEmpty(); // 0x0000000181DFD910-0x0000000181DFD930
		private int GetNextAvailableIndex(); // 0x0000000181E7B2A0-0x0000000181E7B320
		public void AddData(LensFlareComponentSRP newData); // 0x0000000181E77870-0x0000000181E77AD0
		public void RemoveData(LensFlareComponentSRP data); // 0x0000000181E7DF40-0x0000000181E7E110
		public static float ShapeAttenuationPointLight(); // 0x0000000181E471E0-0x0000000181E471F0
		public static float ShapeAttenuationDirLight(Vector3 forward, Vector3 wo); // 0x0000000181E7E680-0x0000000181E7E6E0
		public static float ShapeAttenuationSpotConeLight(Vector3 forward, Vector3 wo, float spotAngle, float innerSpotPercent01); // 0x0000000181E7E740-0x0000000181E7E850
		public static float ShapeAttenuationSpotBoxLight(Vector3 forward, Vector3 wo); // 0x0000000181E7E6E0-0x0000000181E7E740
		public static float ShapeAttenuationSpotPyramidLight(Vector3 forward, Vector3 wo); // 0x0000000181E7E850-0x0000000181E7E900
		public static float ShapeAttenuationAreaTubeLight(Vector3 lightPositionWS, Vector3 lightSide, float lightWidth, Camera cam); // 0x0000000181E7E280-0x0000000181E7E680
		private static float ShapeAttenuateForwardLight(Vector3 forward, Vector3 wo); // 0x0000000181E7E110-0x0000000181E7E160
		public static float ShapeAttenuationAreaRectangleLight(Vector3 forward, Vector3 wo); // 0x0000000181E7E1F0-0x0000000181E7E280
		public static float ShapeAttenuationAreaDiscLight(Vector3 forward, Vector3 wo); // 0x0000000181E7E160-0x0000000181E7E1F0
		private static bool IsLensFlareSRPHidden(Camera cam, LensFlareComponentSRP comp, LensFlareDataSRP data); // 0x0000000181E7BB80-0x0000000181E7BCC0
		private static Vector4 InternalGetFlareData0(Vector2 screenPos, Vector2 translationScale, Vector2 rayOff0, Vector2 vLocalScreenRatio, float angleDeg, float position, float angularOffset, Vector2 positionOffset, bool autoRotate); // 0x0000000181E7B750-0x0000000181E7B970
		[Obsolete("This is now deprecated as a public API. Call ComputeOcclusion() or DoLensFlareDataDrivenCommon() instead. #from(6000.3)")]
		public static Vector4 GetFlareData0(Vector2 screenPos, Vector2 translationScale, Vector2 rayOff0, Vector2 vLocalScreenRatio, float angleDeg, float position, float angularOffset, Vector2 positionOffset, bool autoRotate); // 0x0000000181E7B130-0x0000000181E7B230
		private static Vector2 GetLensFlareRayOffset(Vector2 screenPos, float position, float globalCos0, float globalSin0); // 0x0000000181E7B230-0x0000000181E7B2A0
		private static Vector3 WorldToViewport(Camera camera, bool isLocalLight, bool isCameraRelative, Matrix4x4 viewProjMatrix, Vector3 positionWS); // 0x0000000181E7F560-0x0000000181E7F730
		private static Vector3 WorldToViewportLocal(bool isCameraRelative, Matrix4x4 viewProjMatrix, Vector3 cameraPosWS, Vector3 positionWS, bool isPerspective); // 0x0000000181E7F350-0x0000000181E7F560
		private static Vector3 WorldToViewportDistance(Camera cam, Vector3 positionWS, bool isPerspective); // 0x0000000181E7F030-0x0000000181E7F350
		public static bool IsCloudLayerOpacityNeeded(Camera cam); // 0x0000000181E7B970-0x0000000181E7BB80
		public static void ComputeOcclusion(Material lensFlareShader, Camera cam, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, UnsafeCommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture); // 0x0000000181E78970-0x0000000181E78B30
		private static bool ForceSingleElement(LensFlareDataElementSRP element); // 0x0000000181E7B0F0-0x0000000181E7B130
		private static bool PreDrawSetup(bool occlusionOnly, bool clearRenderTarget, RenderTargetIdentifier rt, Camera cam, XRPass xr, int xrIndex, CommandBuffer cmd); // 0x0000000181E7BE60-0x0000000181E7C090
		private static bool DoComponent(bool occlusionOnly, [IsReadOnly] in LensFlareCompInfo info, Camera cam, Vector3 cameraPositionWS, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Matrix4x4 viewProjMatrix, CommandBuffer cmd, out Vector3 flarePosWS, out Vector3 flarePosViewport, out Vector2 flarePosScreen, out Vector3 camToFlare, out Light light, out bool isDirLight, out float flareIntensity, out float distanceAttenuation); // 0x0000000181E78C60-0x0000000181E796A0
		public static void ComputeOcclusion(Material lensFlareShader, Camera cam, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, CommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture); // 0x0000000181E77D60-0x0000000181E78970
		public static void ProcessLensFlareSRPElementsSingle(LensFlareDataElementSRP element, CommandBuffer cmd, Color globalColorModulation, Light light, float compIntensity, float scale, Material lensFlareShader, Vector2 screenPos, bool compAllowOffScreen, Vector2 vScreenRatio, Vector3 flareData1, bool preview, int depth); // 0x0000000181E7C090-0x0000000181E7DCD0
		private static void ProcessLensFlareSRPElements(ref LensFlareDataElementSRP[] elements, CommandBuffer cmd, Color globalColorModulation, Light light, float compIntensity, float scale, Material lensFlareShader, Vector2 screenPos, bool compAllowOffScreen, float aspect, Vector4 flareData6, bool preview, int depth); // 0x0000000181E7DCD0-0x0000000181E7DF40
		public static void DoLensFlareDataDrivenCommon(Material lensFlareShader, Camera cam, Rect viewport, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, UnsafeCommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, RenderTargetIdentifier colorBuffer, Func<Light, Camera, Vector3, float> GetLensFlareLightAttenuation, bool debugView); // 0x0000000181E796A0-0x0000000181E798D0
		public static void DoLensFlareDataDrivenCommon(Material lensFlareShader, Camera cam, Rect viewport, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, CommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, RenderTargetIdentifier colorBuffer, Func<Light, Camera, Vector3, float> GetLensFlareLightAttenuation, bool debugView); // 0x0000000181E798D0-0x0000000181E7A2C0
		public static void DoLensFlareScreenSpaceCommon(Material lensFlareShader, Camera cam, float actualWidth, float actualHeight, Color tintColor, Texture originalBloomTexture, Texture bloomMipTexture, Texture spectralLut, Texture streakTextureTmp, Texture streakTextureTmp2, Vector4 parameters1, Vector4 parameters2, Vector4 parameters3, Vector4 parameters4, Vector4 parameters5, UnsafeCommandBuffer cmd, RTHandle result, bool debugView); // 0x0000000181E7A2C0-0x0000000181E7A4A0
		public static void DoLensFlareScreenSpaceCommon(Material lensFlareShader, Camera cam, float actualWidth, float actualHeight, Color tintColor, Texture originalBloomTexture, Texture bloomMipTexture, Texture spectralLut, Texture streakTextureTmp, Texture streakTextureTmp2, Vector4 parameters1, Vector4 parameters2, Vector4 parameters3, Vector4 parameters4, Vector4 parameters5, CommandBuffer cmd, RTHandle result, bool debugView); // 0x0000000181E7A4A0-0x0000000181E7AE40
		private static Vector2 DoPaniniProjection(Vector2 screenPos, float actualWidth, float actualHeight, float fieldOfView, float paniniProjectionCropToFit, float paniniProjectionDistance); // 0x0000000181E7AE40-0x0000000181E7B0F0
		private static Vector2 CalcViewExtents(float actualWidth, float actualHeight, float fieldOfView); // 0x0000000181E77BF0-0x0000000181E77C40
		private static Vector2 CalcCropExtents(float actualWidth, float actualHeight, float fieldOfView, float d); // 0x0000000181E77AD0-0x0000000181E77BF0
		private static Vector2 Panini_Generic_Inv(Vector2 projPos, float d); // 0x0000000181E7BDD0-0x0000000181E7BE60
		[CompilerGenerated]
		internal static float _ShapeAttenuationAreaTubeLight_g__Fpo_68_0(float d, float l); // 0x0000000181E7EFB0-0x0000000181E7F010
		[CompilerGenerated]
		internal static float _ShapeAttenuationAreaTubeLight_g__Fwt_68_1(float d, float l); // 0x0000000181E7F010-0x0000000181E7F030
		[CompilerGenerated]
		internal static float _ShapeAttenuationAreaTubeLight_g__DiffLineIntegral_68_2(Vector3 p1, Vector3 p2); // 0x0000000181E7EB40-0x0000000181E7EFB0
		[CompilerGenerated]
		internal static Vector2 _ProcessLensFlareSRPElementsSingle_g__ComputeLocalSize_85_0(Vector2 rayOff, Vector2 rayOff0, Vector2 curSize, AnimationCurve distortionCurve, ref __c__DisplayClass85_0 param_00009624); // 0x0000000181E7E900-0x0000000181E7EB30
		[CompilerGenerated]
		internal static float _ProcessLensFlareSRPElementsSingle_g__RandomRange_85_1(float min, float max); // 0x0000000181E7EB30-0x0000000181E7EB40
	}
}
