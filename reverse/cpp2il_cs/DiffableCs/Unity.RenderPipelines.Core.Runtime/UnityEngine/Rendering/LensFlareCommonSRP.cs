namespace UnityEngine.Rendering;

public sealed class LensFlareCommonSRP
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass50_0
	{
		public LensFlareComponentSRP newData; //Field offset: 0x10

		public <>c__DisplayClass50_0() { }

		internal bool <AddData>b__0(LensFlareCompInfo x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public LensFlareComponentSRP data; //Field offset: 0x10

		public <>c__DisplayClass51_0() { }

		internal bool <RemoveData>b__0(LensFlareCompInfo x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass74_0
	{
		public Vector2 screenPos; //Field offset: 0x0
		public float position; //Field offset: 0x8
		public float globalCos0; //Field offset: 0xC
		public float globalSin0; //Field offset: 0x10
		public Vector2 vScreenRatio; //Field offset: 0x14
		public LensFlareDataElementSRP element; //Field offset: 0x20
		public float combinedScale; //Field offset: 0x28
		public float usedAspectRatio; //Field offset: 0x2C

	}

	public class LensFlareCompInfo
	{
		internal int index; //Field offset: 0x10
		internal LensFlareComponentSRP comp; //Field offset: 0x18

		internal LensFlareCompInfo(int idx, LensFlareComponentSRP cmp) { }

	}

	private static LensFlareCommonSRP m_Instance; //Field offset: 0x0
	private static readonly object m_Padlock; //Field offset: 0x8
	private static List<LensFlareCompInfo> m_Data; //Field offset: 0x10
	private static List<Int32> m_AvailableIndicies; //Field offset: 0x18
	public static int maxLensFlareWithOcclusion; //Field offset: 0x20
	public static int maxLensFlareWithOcclusionTemporalSample; //Field offset: 0x24
	public static int mergeNeeded; //Field offset: 0x28
	public static RTHandle occlusionRT; //Field offset: 0x30
	private static int frameIdx; //Field offset: 0x38
	internal static readonly int _FlareOcclusionPermutation; //Field offset: 0x3C
	internal static readonly int _FlareOcclusionRemapTex; //Field offset: 0x40
	internal static readonly int _FlareOcclusionTex; //Field offset: 0x44
	internal static readonly int _FlareOcclusionIndex; //Field offset: 0x48
	internal static readonly int _FlareCloudOpacity; //Field offset: 0x4C
	internal static readonly int _FlareSunOcclusionTex; //Field offset: 0x50
	internal static readonly int _FlareTex; //Field offset: 0x54
	internal static readonly int _FlareColorValue; //Field offset: 0x58
	internal static readonly int _FlareData0; //Field offset: 0x5C
	internal static readonly int _FlareData1; //Field offset: 0x60
	internal static readonly int _FlareData2; //Field offset: 0x64
	internal static readonly int _FlareData3; //Field offset: 0x68
	internal static readonly int _FlareData4; //Field offset: 0x6C
	internal static readonly int _FlareData5; //Field offset: 0x70
	internal static readonly int _FlareRadialTint; //Field offset: 0x74
	internal static readonly int _ViewId; //Field offset: 0x78
	internal static readonly int _LensFlareScreenSpaceBloomMipTexture; //Field offset: 0x7C
	internal static readonly int _LensFlareScreenSpaceResultTexture; //Field offset: 0x80
	internal static readonly int _LensFlareScreenSpaceSpectralLut; //Field offset: 0x84
	internal static readonly int _LensFlareScreenSpaceStreakTex; //Field offset: 0x88
	internal static readonly int _LensFlareScreenSpaceMipLevel; //Field offset: 0x8C
	internal static readonly int _LensFlareScreenSpaceTintColor; //Field offset: 0x90
	internal static readonly int _LensFlareScreenSpaceParams1; //Field offset: 0x94
	internal static readonly int _LensFlareScreenSpaceParams2; //Field offset: 0x98
	internal static readonly int _LensFlareScreenSpaceParams3; //Field offset: 0x9C
	internal static readonly int _LensFlareScreenSpaceParams4; //Field offset: 0xA0
	internal static readonly int _LensFlareScreenSpaceParams5; //Field offset: 0xA4
	private static readonly bool s_SupportsLensFlare16bitsFormat; //Field offset: 0xA8
	private static readonly bool s_SupportsLensFlare32bitsFormat; //Field offset: 0xA9

	private List<LensFlareCompInfo> Data
	{
		private get { } //Length: 79
	}

	public static LensFlareCommonSRP Instance
	{
		 get { } //Length: 402
	}

	private static LensFlareCommonSRP() { }

	private LensFlareCommonSRP() { }

	[CompilerGenerated]
	internal static Vector2 <ProcessLensFlareSRPElementsSingle>g__ComputeLocalSize|74_0(Vector2 rayOff, Vector2 rayOff0, Vector2 curSize, AnimationCurve distortionCurve, ref <>c__DisplayClass74_0 unnamed_param_4) { }

	[CompilerGenerated]
	internal static float <ProcessLensFlareSRPElementsSingle>g__RandomRange|74_1(float min, float max) { }

	[CompilerGenerated]
	internal static float <ShapeAttenuationAreaTubeLight>g__DiffLineIntegral|57_2(Vector3 p1, Vector3 p2) { }

	[CompilerGenerated]
	internal static float <ShapeAttenuationAreaTubeLight>g__Fpo|57_0(float d, float l) { }

	[CompilerGenerated]
	internal static float <ShapeAttenuationAreaTubeLight>g__Fwt|57_1(float d, float l) { }

	public void AddData(LensFlareComponentSRP newData) { }

	private static Vector2 CalcCropExtents(float actualWidth, float actualHeight, float fieldOfView, float d) { }

	private static Vector2 CalcViewExtents(float actualWidth, float actualHeight, float fieldOfView) { }

	public static void ComputeOcclusion(Material lensFlareShader, Camera cam, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, CommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture) { }

	[Obsolete("Use ComputeOcclusion without _FlareOcclusionTex.._FlareData4 parameters.")]
	public static void ComputeOcclusion(Material lensFlareShader, Camera cam, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, CommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, int _FlareOcclusionTex, int _FlareCloudOpacity, int _FlareOcclusionIndex, int _FlareTex, int _FlareColorValue, int _FlareSunOcclusionTex, int _FlareData0, int _FlareData1, int _FlareData2, int _FlareData3, int _FlareData4) { }

	public static void ComputeOcclusion(Material lensFlareShader, Camera cam, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, UnsafeCommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture) { }

	[Obsolete("Use ComputeOcclusion without _FlareOcclusionTex.._FlareData4 parameters.")]
	public static void ComputeOcclusion(Material lensFlareShader, Camera cam, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, UnsafeCommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, int _FlareOcclusionTex, int _FlareCloudOpacity, int _FlareOcclusionIndex, int _FlareTex, int _FlareColorValue, int _FlareSunOcclusionTex, int _FlareData0, int _FlareData1, int _FlareData2, int _FlareData3, int _FlareData4) { }

	public static void Dispose() { }

	public static void DoLensFlareDataDrivenCommon(Material lensFlareShader, Camera cam, Rect viewport, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, UnsafeCommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, RenderTargetIdentifier colorBuffer, Func<Light, Camera, Vector3, Single> GetLensFlareLightAttenuation, bool debugView) { }

	[Obsolete("Use DoLensFlareDataDrivenCommon without _FlareOcclusionRemapTex.._FlareData4 parameters.")]
	public static void DoLensFlareDataDrivenCommon(Material lensFlareShader, Camera cam, Rect viewport, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, UnsafeCommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, RenderTargetIdentifier colorBuffer, Func<Light, Camera, Vector3, Single> GetLensFlareLightAttenuation, int _FlareOcclusionRemapTex, int _FlareOcclusionTex, int _FlareOcclusionIndex, int _FlareCloudOpacity, int _FlareSunOcclusionTex, int _FlareTex, int _FlareColorValue, int _FlareData0, int _FlareData1, int _FlareData2, int _FlareData3, int _FlareData4, bool debugView) { }

	[Obsolete("Use DoLensFlareDataDrivenCommon without _FlareOcclusionRemapTex.._FlareData4 parameters.")]
	public static void DoLensFlareDataDrivenCommon(Material lensFlareShader, Camera cam, Rect viewport, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, CommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, RenderTargetIdentifier colorBuffer, Func<Light, Camera, Vector3, Single> GetLensFlareLightAttenuation, int _FlareOcclusionRemapTex, int _FlareOcclusionTex, int _FlareOcclusionIndex, int _FlareCloudOpacity, int _FlareSunOcclusionTex, int _FlareTex, int _FlareColorValue, int _FlareData0, int _FlareData1, int _FlareData2, int _FlareData3, int _FlareData4, bool debugView) { }

	public static void DoLensFlareDataDrivenCommon(Material lensFlareShader, Camera cam, Rect viewport, XRPass xr, int xrIndex, float actualWidth, float actualHeight, bool usePanini, float paniniDistance, float paniniCropToFit, bool isCameraRelative, Vector3 cameraPositionWS, Matrix4x4 viewProjMatrix, CommandBuffer cmd, bool taaEnabled, bool hasCloudLayer, Texture cloudOpacityTexture, Texture sunOcclusionTexture, RenderTargetIdentifier colorBuffer, Func<Light, Camera, Vector3, Single> GetLensFlareLightAttenuation, bool debugView) { }

	public static void DoLensFlareScreenSpaceCommon(Material lensFlareShader, Camera cam, float actualWidth, float actualHeight, Color tintColor, Texture originalBloomTexture, Texture bloomMipTexture, Texture spectralLut, Texture streakTextureTmp, Texture streakTextureTmp2, Vector4 parameters1, Vector4 parameters2, Vector4 parameters3, Vector4 parameters4, Vector4 parameters5, CommandBuffer cmd, RTHandle result, bool debugView) { }

	[Obsolete("Use DoLensFlareScreenSpaceCommon without _Shader IDs parameters.")]
	public static void DoLensFlareScreenSpaceCommon(Material lensFlareShader, Camera cam, float actualWidth, float actualHeight, Color tintColor, Texture originalBloomTexture, Texture bloomMipTexture, Texture spectralLut, Texture streakTextureTmp, Texture streakTextureTmp2, Vector4 parameters1, Vector4 parameters2, Vector4 parameters3, Vector4 parameters4, Vector4 parameters5, CommandBuffer cmd, RTHandle result, int _LensFlareScreenSpaceBloomMipTexture, int _LensFlareScreenSpaceResultTexture, int _LensFlareScreenSpaceSpectralLut, int _LensFlareScreenSpaceStreakTex, int _LensFlareScreenSpaceMipLevel, int _LensFlareScreenSpaceTintColor, int _LensFlareScreenSpaceParams1, int _LensFlareScreenSpaceParams2, int _LensFlareScreenSpaceParams3, int _LensFlareScreenSpaceParams4, int _LensFlareScreenSpaceParams5, bool debugView) { }

	public static void DoLensFlareScreenSpaceCommon(Material lensFlareShader, Camera cam, float actualWidth, float actualHeight, Color tintColor, Texture originalBloomTexture, Texture bloomMipTexture, Texture spectralLut, Texture streakTextureTmp, Texture streakTextureTmp2, Vector4 parameters1, Vector4 parameters2, Vector4 parameters3, Vector4 parameters4, Vector4 parameters5, UnsafeCommandBuffer cmd, RTHandle result, bool debugView) { }

	private static Vector2 DoPaniniProjection(Vector2 screenPos, float actualWidth, float actualHeight, float fieldOfView, float paniniProjectionCropToFit, float paniniProjectionDistance) { }

	private static bool ForceSingleElement(LensFlareDataElementSRP element) { }

	private List<LensFlareCompInfo> get_Data() { }

	public static LensFlareCommonSRP get_Instance() { }

	public static Vector4 GetFlareData0(Vector2 screenPos, Vector2 translationScale, Vector2 rayOff0, Vector2 vLocalScreenRatio, float angleDeg, float position, float angularOffset, Vector2 positionOffset, bool autoRotate) { }

	private static Vector2 GetLensFlareRayOffset(Vector2 screenPos, float position, float globalCos0, float globalSin0, Vector2 vAspectRatio) { }

	private int GetNextAvailableIndex() { }

	private static GraphicsFormat GetOcclusionRTFormat() { }

	public static void Initialize() { }

	public static bool IsCloudLayerOpacityNeeded(Camera cam) { }

	public bool IsEmpty() { }

	private static bool IsLensFlareSRPHidden(Camera cam, LensFlareComponentSRP comp, LensFlareDataSRP data) { }

	public static bool IsOcclusionRTCompatible() { }

	private static Vector2 Panini_Generic_Inv(Vector2 projPos, float d) { }

	private static void ProcessLensFlareSRPElements(ref LensFlareDataElementSRP[] elements, CommandBuffer cmd, Color globalColorModulation, Light light, float compIntensity, float scale, Material lensFlareShader, Vector2 screenPos, bool compAllowOffScreen, Vector2 vScreenRatio, Vector4 flareData1, bool preview, int depth) { }

	public static void ProcessLensFlareSRPElementsSingle(LensFlareDataElementSRP element, CommandBuffer cmd, Color globalColorModulation, Light light, float compIntensity, float scale, Material lensFlareShader, Vector2 screenPos, bool compAllowOffScreen, Vector2 vScreenRatio, Vector4 flareData1, bool preview, int depth) { }

	public void RemoveData(LensFlareComponentSRP data) { }

	private static void SetOcclusionPermutation(CommandBuffer cmd, bool useFogOpacityOcclusion, int _FlareSunOcclusionTex, Texture sunOcclusionTexture) { }

	private static float ShapeAttenuateForwardLight(Vector3 forward, Vector3 wo) { }

	public static float ShapeAttenuationAreaDiscLight(Vector3 forward, Vector3 wo) { }

	public static float ShapeAttenuationAreaRectangleLight(Vector3 forward, Vector3 wo) { }

	public static float ShapeAttenuationAreaTubeLight(Vector3 lightPositionWS, Vector3 lightSide, float lightWidth, Camera cam) { }

	public static float ShapeAttenuationDirLight(Vector3 forward, Vector3 wo) { }

	public static float ShapeAttenuationPointLight() { }

	public static float ShapeAttenuationSpotBoxLight(Vector3 forward, Vector3 wo) { }

	public static float ShapeAttenuationSpotConeLight(Vector3 forward, Vector3 wo, float spotAngle, float innerSpotPercent01) { }

	public static float ShapeAttenuationSpotPyramidLight(Vector3 forward, Vector3 wo) { }

	private static Vector3 WorldToViewport(Camera camera, bool isLocalLight, bool isCameraRelative, Matrix4x4 viewProjMatrix, Vector3 positionWS) { }

	private static Vector3 WorldToViewportDistance(Camera cam, Vector3 positionWS) { }

	private static Vector3 WorldToViewportLocal(bool isCameraRelative, Matrix4x4 viewProjMatrix, Vector3 cameraPosWS, Vector3 positionWS) { }

}

