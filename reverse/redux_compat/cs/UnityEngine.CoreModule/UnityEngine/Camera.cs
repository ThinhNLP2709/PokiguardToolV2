/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Camera", PersistentTypeId = 20)]
	[NativeHeader("Runtime/Camera/RenderManager.h")]
	[NativeHeader("Runtime/Camera/Camera.h")]
	[NativeHeader("Runtime/Misc/GameObjectUtility.h")]
	[NativeHeader("Runtime/Shaders/Shader.h")]
	[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
	[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
	[NativeHeader("Runtime/Graphics/RenderTexture.h")]
	[RequireComponent(typeof(Transform))]
	[UsedByNativeCode]
	public sealed class Camera : Behaviour // TypeDefIndex: 7498
	{
		// Fields
		public const float kMinAperture = 0.7f; // Metadata: 0x0069D245
		public const float kMaxAperture = 32f; // Metadata: 0x0069D249
		public const int kMinBladeCount = 3; // Metadata: 0x0069D24D
		public const int kMaxBladeCount = 11; // Metadata: 0x0069D24E
		internal uint m_NonSerializedVersion; // 0x18
		[AutoStaticsCleanupOnCodeReload]
		public static CameraCallback onPreCull; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		public static CameraCallback onPreRender; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		public static CameraCallback onPostRender; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Properties
		[NativeProperty("Near")]
		public float nearClipPlane { get; set; } // 0x00000001821841F0-0x0000000182184280 0x0000000182187D50-0x0000000182187DF0
		[NativeProperty("Far")]
		public float farClipPlane { get; set; } // 0x00000001821838F0-0x0000000182183980 0x0000000182187290-0x0000000182187330
		[NativeProperty("VerticalFieldOfView")]
		public float fieldOfView { get; set; } // 0x00000001821839C0-0x0000000182183A50 0x0000000182187380-0x0000000182187420
		public RenderingPath renderingPath { get; set; } // 0x0000000182184E40-0x0000000182184ED0 0x0000000182188690-0x0000000182188730
		public RenderingPath actualRenderingPath { [NativeName("CalculateRenderingPath")] get; } // 0x0000000182182370-0x0000000182182400 
		public bool allowHDR { get; set; } // 0x00000001821826A0-0x0000000182182730 0x0000000182186300-0x00000001821863A0
		public bool allowMSAA { get; set; } // 0x0000000182182770-0x0000000182182800 0x00000001821863F0-0x0000000182186490
		public bool allowDynamicResolution { get; set; } // 0x00000001821825D0-0x0000000182182660 0x0000000182186210-0x00000001821862B0
		[NativeProperty("ForceIntoRT")]
		public bool forceIntoRenderTexture { get; set; } // 0x0000000182183C30-0x0000000182183CC0 0x0000000182187650-0x00000001821876F0
		public float orthographicSize { get; set; } // 0x0000000182184490-0x0000000182184520 0x0000000182188010-0x00000001821880B0
		public bool orthographic { get; set; } // 0x0000000182184560-0x00000001821845F0 0x0000000182188100-0x00000001821881A0
		public OpaqueSortMode opaqueSortMode { get; set; } // 0x00000001821843C0-0x0000000182184450 0x0000000182187F20-0x0000000182187FC0
		public TransparencySortMode transparencySortMode { get; set; } // 0x0000000182185BF0-0x0000000182185C80 0x00000001821890F0-0x0000000182189190
		public Vector3 transparencySortAxis { get; set; } // 0x0000000182185B00-0x0000000182185BB0 0x0000000182189010-0x00000001821890B0
		public float depth { get; set; } // 0x0000000182183750-0x00000001821837E0 0x00000001821870C0-0x0000000182187160
		public float aspect { get; set; } // 0x0000000182182AB0-0x0000000182182B40 0x00000001821866C0-0x0000000182186760
		public Vector3 velocity { get; } // 0x0000000182186010-0x00000001821860C0 
		public int cullingMask { get; set; } // 0x0000000182183260-0x00000001821832F0 0x0000000182186D10-0x0000000182186DB0
		public int eventMask { get; set; } // 0x0000000182183820-0x00000001821838B0 0x00000001821871A0-0x0000000182187240
		public bool layerCullSpherical { get; set; } // 0x0000000182183F80-0x0000000182184010 0x0000000182187AF0-0x0000000182187C10
		[NativeProperty("LayerCullSpherical")]
		internal bool layerCullSphericalInternal { get; set; } // 0x0000000182183F80-0x0000000182184010 0x0000000182187A50-0x0000000182187AF0
		public CameraType cameraType { get; set; } // 0x0000000182182F20-0x0000000182182FB0 0x0000000182186A60-0x0000000182186B00
		internal Material skyboxMaterial { get; } // 0x0000000182185430-0x00000001821854E0 
		[NativeConditional("UNITY_EDITOR")]
		public ulong overrideSceneCullingMask { get; set; } // 0x0000000182184630-0x00000001821846C0 0x00000001821881F0-0x0000000182188290
		[NativeConditional("UNITY_EDITOR")]
		internal ulong sceneCullingMask { get; } // 0x00000001821850B0-0x0000000182185140 
		[NativeConditional("UNITY_EDITOR")]
		internal bool useInteractiveLightBakingData { get; set; } // 0x0000000182185CC0-0x0000000182185D50 0x00000001821891E0-0x0000000182189280
		public float[] layerCullDistances { get; set; } // 0x0000000182183F30-0x0000000182183F40 0x00000001821878B0-0x0000000182187A00
		[Obsolete("PreviewCullingLayer is obsolete. Use scene culling masks instead.", false)]
		internal static int PreviewCullingLayer { get; } // 0x0000000181AEE450-0x0000000181AEE460 
		public bool useOcclusionCulling { get; set; } // 0x0000000182185E60-0x0000000182185EF0 0x00000001821893C0-0x0000000182189460
		public Matrix4x4 cullingMatrix { get; set; } // 0x0000000182183340-0x00000001821833F0 0x0000000182186E00-0x0000000182186EA0
		public Color backgroundColor { get; set; } // 0x0000000182182B90-0x0000000182182C40 0x00000001821867B0-0x0000000182186850
		public CameraClearFlags clearFlags { get; set; } // 0x0000000182182FF0-0x0000000182183080 0x0000000182186B40-0x0000000182186BE0
		public DepthTextureMode depthTextureMode { get; set; } // 0x0000000182183680-0x0000000182183710 0x0000000182186FD0-0x0000000182187070
		public bool clearStencilAfterLightingPass { get; set; } // 0x00000001821830C0-0x0000000182183150 0x0000000182186C30-0x0000000182186CD0
		internal ProjectionMatrixMode projectionMatrixMode { get; } // 0x0000000182184AA0-0x0000000182184B30 
		public bool usePhysicalProperties { get; set; } // 0x0000000182185F30-0x0000000182185FC0 0x00000001821894B0-0x0000000182189550
		public int iso { get; set; } // 0x0000000182183EA0-0x0000000182183F30 0x0000000182187810-0x00000001821878B0
		public float shutterSpeed { get; set; } // 0x0000000182185360-0x00000001821853F0 0x0000000182188960-0x0000000182188A00
		public float aperture { get; set; } // 0x0000000182182910-0x00000001821829A0 0x00000001821865D0-0x0000000182186670
		public float focusDistance { get; set; } // 0x0000000182183B60-0x0000000182183BF0 0x0000000182187560-0x0000000182187600
		public float focalLength { get; set; } // 0x0000000182183A90-0x0000000182183B20 0x0000000182187470-0x0000000182187510
		public int bladeCount { get; set; } // 0x0000000182182D50-0x0000000182182DE0 0x0000000182186980-0x0000000182186A20
		public Vector2 curvature { get; set; } // 0x00000001821835A0-0x0000000182183640 0x0000000182186EF0-0x0000000182186F90
		public float barrelClipping { get; set; } // 0x0000000182182C80-0x0000000182182D10 0x00000001821868A0-0x0000000182186940
		public float anamorphism { get; set; } // 0x0000000182182840-0x00000001821828D0 0x00000001821864E0-0x0000000182186580
		public Vector2 sensorSize { get; set; } // 0x0000000182185280-0x0000000182185320 0x0000000182188870-0x0000000182188910
		public Vector2 lensShift { get; set; } // 0x0000000182184060-0x0000000182184100 0x0000000182187C60-0x0000000182187D00
		public GateFitMode gateFit { get; set; } // 0x0000000182183D00-0x0000000182183D90 0x0000000182187730-0x00000001821877D0
		[NativeProperty("NormalizedViewportRect")]
		public Rect rect { get; set; } // 0x0000000182184C80-0x0000000182184D30 0x00000001821884C0-0x0000000182188560
		[NativeProperty("ScreenViewportRect")]
		public Rect pixelRect { get; set; } // 0x00000001821847E0-0x0000000182184890 0x00000001821882E0-0x0000000182188380
		public int pixelWidth { [FreeFunction("CameraScripting::GetPixelWidth", HasExplicitThis = true)] get; } // 0x00000001821848D0-0x0000000182184960 
		public int pixelHeight { [FreeFunction("CameraScripting::GetPixelHeight", HasExplicitThis = true)] get; } // 0x0000000182184700-0x0000000182184790 
		public int scaledPixelWidth { [FreeFunction("CameraScripting::GetScaledPixelWidth", HasExplicitThis = true)] get; } // 0x0000000182184FE0-0x0000000182185070 
		public int scaledPixelHeight { [FreeFunction("CameraScripting::GetScaledPixelHeight", HasExplicitThis = true)] get; } // 0x0000000182184F10-0x0000000182184FA0 
		public RenderTexture targetTexture { get; set; } // 0x0000000182185A00-0x0000000182185AB0 0x0000000182188F00-0x0000000182188FC0
		public RenderTexture activeTexture { [NativeName("GetCurrentTargetTexture")] get; } // 0x0000000182182280-0x0000000182182330 
		public int targetDisplay { get; set; } // 0x0000000182185930-0x00000001821859C0 0x0000000182188E10-0x0000000182188EB0
		public Matrix4x4 cameraToWorldMatrix { get; } // 0x0000000182182E30-0x0000000182182EE0 
		public Matrix4x4 worldToCameraMatrix { get; set; } // 0x0000000182186110-0x00000001821861C0 0x00000001821895A0-0x0000000182189640
		public Matrix4x4 projectionMatrix { get; set; } // 0x0000000182184B80-0x0000000182184C30 0x00000001821883D0-0x0000000182188470
		public Matrix4x4 nonJitteredProjectionMatrix { get; set; } // 0x00000001821842D0-0x0000000182184380 0x0000000182187E40-0x0000000182187EE0
		[NativeProperty("UseJitteredProjectionMatrixForTransparent")]
		public bool useJitteredProjectionMatrixForTransparentRendering { get; set; } // 0x0000000182185D90-0x0000000182185E20 0x00000001821892D0-0x0000000182189370
		public Matrix4x4 previousViewProjectionMatrix { get; } // 0x00000001821849B0-0x0000000182184A60 
		public static Camera main { [FreeFunction("FindMainCamera")] get; } // 0x0000000182184130-0x00000001821841B0 
		public static Camera current { get; } // 0x00000001821834A0-0x0000000182183550 
		private static Camera currentInternal { [FreeFunction("GetCurrentCameraPPtr")] get; } // 0x0000000182183420-0x00000001821834A0 
		public Scene scene { [FreeFunction("CameraScripting::GetScene", HasExplicitThis = true)] get; [FreeFunction("CameraScripting::SetScene", HasExplicitThis = true)] set; } // 0x0000000182185190-0x0000000182185230 0x0000000182188780-0x0000000182188820
		public bool stereoEnabled { [NativeMethod("GetStereoEnabledForBuiltInOrSRP")] get; } // 0x00000001821856C0-0x0000000182185750 
		public float stereoSeparation { get; set; } // 0x0000000182185790-0x0000000182185820 0x0000000182188B40-0x0000000182188BE0
		public float stereoConvergence { get; set; } // 0x00000001821855F0-0x0000000182185680 0x0000000182188A50-0x0000000182188AF0
		public bool areVRStereoViewMatricesWithinSingleCullTolerance { [NativeName("AreVRStereoViewMatricesWithinSingleCullTolerance")] get; } // 0x00000001821829E0-0x0000000182182A70 
		public StereoTargetEyeMask stereoTargetEye { get; set; } // 0x0000000182185860-0x00000001821858F0 0x0000000182188CC0-0x0000000182188DD0
		[NativeProperty("StereoTargetEye")]
		internal StereoTargetEyeMask stereoTargetEyeInternal { get; set; } // 0x0000000182185860-0x00000001821858F0 0x0000000182188C20-0x0000000182188CC0
		public MonoOrStereoscopicEye stereoActiveEye { [FreeFunction("CameraScripting::GetStereoActiveEye", HasExplicitThis = true)] get; } // 0x0000000182185520-0x00000001821855B0 
		public static int allCamerasCount { get; } // 0x0000000182182400-0x0000000182182460 
		public static Camera[] allCameras { get; } // 0x0000000182182460-0x0000000182182590 
		[NativeConditional("UNITY_EDITOR")]
		public SceneViewFilterMode sceneViewFilterMode { get; } // 0x000000018217E0E0-0x000000018217E170 
		[NativeConditional("UNITY_EDITOR")]
		public bool renderCloudsInSceneView { get; set; } // 0x0000000182184D70-0x0000000182184E00 0x00000001821885B0-0x0000000182188650
		public bool isProcessingRenderRequest { [NativeMethod("IsProcessingRenderRequest")] get; } // 0x0000000182183DD0-0x0000000182183E60 
		public int commandBufferCount { get; } // 0x0000000182183190-0x0000000182183220 
	
		// Nested types
		internal enum ProjectionMatrixMode // TypeDefIndex: 7499
		{
			Explicit = 0,
			Implicit = 1,
			PhysicalPropertiesBased = 2
		}
	
		public enum GateFitMode // TypeDefIndex: 7500
		{
			None = 0,
			Vertical = 1,
			Horizontal = 2,
			Fill = 3,
			Overscan = 4
		}
	
		public struct GateFitParameters // TypeDefIndex: 7501
		{
			// Fields
			[CompilerGenerated]
			private GateFitMode _mode_k__BackingField; // 0x00
			[CompilerGenerated]
			private float _aspect_k__BackingField; // 0x04
	
			// Properties
			public GateFitMode mode { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000180732D10-0x0000000180732D20 
			public float aspect { [IsReadOnly] [CompilerGenerated] get; } // 0x000000018035C790-0x000000018035C7A0 
		}
	
		public enum StereoscopicEye // TypeDefIndex: 7502
		{
			Left = 0,
			Right = 1
		}
	
		public enum MonoOrStereoscopicEye // TypeDefIndex: 7503
		{
			Left = 0,
			Right = 1,
			Mono = 2
		}
	
		public enum SceneViewFilterMode // TypeDefIndex: 7504
		{
			Off = 0,
			ShowFiltered = 1
		}
	
		public delegate void CameraCallback(Camera cam); // TypeDefIndex: 7505; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public Camera(); // 0x00000001802E7A70-0x00000001802E7BC0
		static Camera(); // 0x0000000182182120-0x0000000182182240
	
		// Methods
		public void Reset(); // 0x000000018217FFE0-0x0000000182180070
		public void ResetTransparencySortSettings(); // 0x000000018217FE40-0x000000018217FED0
		public void ResetAspect(); // 0x000000018217F960-0x000000018217F9F0
		[FreeFunction("CameraScripting::GetLayerCullDistances", HasExplicitThis = true)]
		private float[] GetLayerCullDistances(); // 0x000000018217E490-0x000000018217E5C0
		[FreeFunction("CameraScripting::SetLayerCullDistances", HasExplicitThis = true)]
		private void SetLayerCullDistances([NotNull] float[] d); // 0x0000000182180740-0x0000000182180860
		public void ResetCullingMatrix(); // 0x000000018217FA30-0x000000018217FAC0
		public void SetReplacementShader(Shader shader, string replacementTag); // 0x00000001821808C0-0x0000000182180A90
		public void ResetReplacementShader(); // 0x000000018217FBD0-0x000000018217FC60
		public float GetGateFittedFieldOfView(); // 0x000000018217E2C0-0x000000018217E350
		public Vector2 GetGateFittedLensShift(); // 0x000000018217E3A0-0x000000018217E440
		internal Vector3 GetLocalSpaceAim(); // 0x000000018217E610-0x000000018217E6C0
		[FreeFunction("CameraScripting::SetTargetBuffers", HasExplicitThis = true)]
		private void SetTargetBuffersImpl(RenderBuffer color, RenderBuffer depth); // 0x0000000182180CF0-0x0000000182180DA0
		public void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer); // 0x0000000182180F10-0x0000000182180FC0
		[FreeFunction("CameraScripting::SetTargetBuffers", HasExplicitThis = true)]
		private void SetTargetBuffersMRTImpl(RenderBuffer[] color, RenderBuffer depth); // 0x0000000182180E00-0x0000000182180F10
		public void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer); // 0x0000000182180FC0-0x00000001821810C0
		internal string[] GetCameraBufferWarnings(); // 0x000000018217DD10-0x000000018217DDA0
		public void ResetWorldToCameraMatrix(); // 0x000000018217FF10-0x000000018217FFA0
		public void ResetProjectionMatrix(); // 0x000000018217FB00-0x000000018217FB90
		[FreeFunction("CameraScripting::CalculateObliqueMatrix", HasExplicitThis = true)]
		public Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane); // 0x000000018217D330-0x000000018217D3F0
		public Vector3 WorldToScreenPoint(Vector3 position, MonoOrStereoscopicEye eye); // 0x0000000182181D50-0x0000000182181E20
		public Vector3 WorldToViewportPoint(Vector3 position, MonoOrStereoscopicEye eye); // 0x0000000182181F70-0x0000000182182040
		public Vector3 ViewportToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye); // 0x0000000182181B30-0x0000000182181C00
		public Vector3 ScreenToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye); // 0x0000000182180540-0x0000000182180610
		public Vector3 WorldToScreenPoint(Vector3 position); // 0x0000000182181C70-0x0000000182181D50
		public Vector3 WorldToViewportPoint(Vector3 position); // 0x0000000182181E90-0x0000000182181F70
		public Vector3 ViewportToWorldPoint(Vector3 position); // 0x0000000182181A50-0x0000000182181B30
		public Vector3 ScreenToWorldPoint(Vector3 position); // 0x0000000182180610-0x00000001821806F0
		public Vector3 ScreenToViewportPoint(Vector3 position); // 0x0000000182180410-0x00000001821804D0
		public Vector3 ViewportToScreenPoint(Vector3 position); // 0x0000000182181920-0x00000001821819E0
		internal Vector2 GetFrustumPlaneSizeAt(float distance); // 0x000000018217E1D0-0x000000018217E280
		private Ray ViewportPointToRay(Vector2 pos, MonoOrStereoscopicEye eye); // 0x00000001821815F0-0x00000001821816C0
		public Ray ViewportPointToRay(Vector3 pos, MonoOrStereoscopicEye eye); // 0x00000001821817C0-0x00000001821818C0
		public Ray ViewportPointToRay(Vector3 pos); // 0x00000001821816C0-0x00000001821817C0
		private Ray ScreenPointToRay(Vector2 pos, MonoOrStereoscopicEye eye); // 0x00000001821802E0-0x00000001821803B0
		public Ray ScreenPointToRay(Vector3 pos, MonoOrStereoscopicEye eye); // 0x00000001821801E0-0x00000001821802E0
		public Ray ScreenPointToRay(Vector3 pos); // 0x00000001821800E0-0x00000001821801E0
		[FreeFunction("CameraScripting::CalculateViewportRayVectors", HasExplicitThis = true)]
		private void CalculateFrustumCornersInternal(Rect viewport, float z, MonoOrStereoscopicEye eye, out Vector3[] outCorners); // 0x000000018217CFB0-0x000000018217D0E0
		public void CalculateFrustumCorners(Rect viewport, float z, MonoOrStereoscopicEye eye, Vector3[] outCorners); // 0x000000018217D0E0-0x000000018217D2D0
		[NativeName("CalculateProjectionMatrixFromPhysicalProperties")]
		private static void CalculateProjectionMatrixFromPhysicalPropertiesInternal(out Matrix4x4 output, float focalLength, Vector2 sensorSize, Vector2 lensShift, float nearClip, float farClip, float gateAspect, GateFitMode gateFitMode); // 0x000000018217D460-0x000000018217D520
		public static void CalculateProjectionMatrixFromPhysicalProperties(out Matrix4x4 output, float focalLength, Vector2 sensorSize, Vector2 lensShift, float nearClip, float farClip, GateFitParameters gateFitParameters = default); // 0x000000018217D520-0x000000018217D650
		[NativeName("FocalLengthToFieldOfView_Safe")]
		public static float FocalLengthToFieldOfView(float focalLength, float sensorSize); // 0x000000018217D9E0-0x000000018217DA30
		[NativeName("FieldOfViewToFocalLength_Safe")]
		public static float FieldOfViewToFocalLength(float fieldOfView, float sensorSize); // 0x000000018217D840-0x000000018217D890
		[NativeName("HorizontalToVerticalFieldOfView_Safe")]
		public static float HorizontalToVerticalFieldOfView(float horizontalFieldOfView, float aspectRatio); // 0x000000018217E9F0-0x000000018217EA40
		public static float VerticalToHorizontalFieldOfView(float verticalFieldOfView, float aspectRatio); // 0x0000000182181530-0x0000000182181580
		public Matrix4x4 GetStereoNonJitteredProjectionMatrix(StereoscopicEye eye); // 0x000000018217E710-0x000000018217E7D0
		[FreeFunction("CameraScripting::GetStereoViewMatrix", HasExplicitThis = true)]
		public Matrix4x4 GetStereoViewMatrix(StereoscopicEye eye); // 0x000000018217E930-0x000000018217E9F0
		public void CopyStereoDeviceProjectionMatrixToNonJittered(StereoscopicEye eye); // 0x000000018217D7A0-0x000000018217D840
		[FreeFunction("CameraScripting::GetStereoProjectionMatrix", HasExplicitThis = true)]
		public Matrix4x4 GetStereoProjectionMatrix(StereoscopicEye eye); // 0x000000018217E820-0x000000018217E8E0
		public void SetStereoProjectionMatrix(StereoscopicEye eye, Matrix4x4 matrix); // 0x0000000182180AE0-0x0000000182180B90
		public void ResetStereoProjectionMatrices(); // 0x000000018217FCA0-0x000000018217FD30
		public void SetStereoViewMatrix(StereoscopicEye eye, Matrix4x4 matrix); // 0x0000000182180BE0-0x0000000182180C90
		public void ResetStereoViewMatrices(); // 0x000000018217FD70-0x000000018217FE00
		[FreeFunction("CameraScripting::GetAllCamerasCount")]
		private static int GetAllCamerasCount(); // 0x000000018217DA30-0x000000018217DA60
		[FreeFunction("CameraScripting::GetAllCameras")]
		private static int GetAllCamerasImpl([NotNull] out Camera[] cam); // 0x000000018217DAA0-0x000000018217DB30
		public static int GetAllCameras(Camera[] cameras); // 0x000000018217DB30-0x000000018217DCD0
		[FreeFunction("CameraScripting::RenderToCubemap", HasExplicitThis = true)]
		private bool RenderToCubemapImpl(Texture tex, [DefaultValue("63")] int faceMask); // 0x000000018217F490-0x000000018217F560
		public bool RenderToCubemap(Cubemap cubemap, int faceMask); // 0x000000018217F490-0x000000018217F560
		public bool RenderToCubemap(Cubemap cubemap); // 0x000000018217F560-0x000000018217F620
		public bool RenderToCubemap(RenderTexture cubemap, int faceMask); // 0x000000018217F490-0x000000018217F560
		public bool RenderToCubemap(RenderTexture cubemap); // 0x000000018217F560-0x000000018217F620
		[NativeConditional("UNITY_EDITOR")]
		private int GetFilterMode(); // 0x000000018217E0E0-0x000000018217E170
		[NativeName("RenderToCubemap")]
		private bool RenderToCubemapEyeImpl(RenderTexture cubemap, int faceMask, MonoOrStereoscopicEye stereoEye); // 0x000000018217F360-0x000000018217F430
		public bool RenderToCubemap(RenderTexture cubemap, int faceMask, MonoOrStereoscopicEye stereoEye); // 0x000000018217F360-0x000000018217F430
		[FreeFunction("CameraScripting::Render", HasExplicitThis = true)]
		public void Render(); // 0x000000018217F890-0x000000018217F920
		[FreeFunction("CameraScripting::RenderWithShader", HasExplicitThis = true)]
		public void RenderWithShader(Shader shader, string replacementTag); // 0x000000018217F680-0x000000018217F850
		[FreeFunction("CameraScripting::RenderDontRestore", HasExplicitThis = true)]
		public void RenderDontRestore(); // 0x000000018217F260-0x000000018217F2F0
		public void SubmitRenderRequest<RequestData>(RequestData renderRequest);
		[FreeFunction("CameraScripting::SubmitRenderRequests", HasExplicitThis = true)]
		private void SubmitRenderRequestsInternal(object requests); // 0x0000000182181300-0x00000001821813A0
		[FreeFunction("CameraScripting::SubmitBuiltInObjectIDRenderRequest", HasExplicitThis = true)]
		[NativeConditional("UNITY_EDITOR")]
		private Object[] SubmitBuiltInObjectIDRenderRequest(RenderTexture target, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x00000001821811E0-0x00000001821812B0
		[FreeFunction("CameraScripting::SetupCurrent")]
		public static void SetupCurrent(Camera cur); // 0x0000000182181100-0x0000000182181170
		[FreeFunction("CameraScripting::CopyFrom", HasExplicitThis = true)]
		public void CopyFrom(Camera other); // 0x000000018217D6A0-0x000000018217D760
		[NativeName("RemoveCommandBuffers")]
		private void RemoveCommandBuffersImpl(CameraEvent evt); // 0x000000018217F060-0x000000018217F100
		[NativeName("RemoveAllCommandBuffers")]
		private void RemoveAllCommandBuffersImpl(); // 0x000000018217EB00-0x000000018217EB90
		private static void LogWarningOnlyBuiltIn([CallerMemberName] string memberName = "" /* Metadata: 0x0069D244 */); // 0x000000018217EA40-0x000000018217EAC0
		public void RemoveCommandBuffers(CameraEvent evt); // 0x000000018217F100-0x000000018217F220
		public void RemoveAllCommandBuffers(); // 0x000000018217EB90-0x000000018217EC90
		[NativeName("AddCommandBuffer")]
		private void AddCommandBufferImpl(CameraEvent evt, [NotNull] CommandBuffer buffer); // 0x000000018217CBE0-0x000000018217CCD0
		[NativeName("AddCommandBufferAsync")]
		private void AddCommandBufferAsyncImpl(CameraEvent evt, [NotNull] CommandBuffer buffer, ComputeQueueType queueType); // 0x000000018217C830-0x000000018217C940
		[NativeName("RemoveCommandBuffer")]
		private void RemoveCommandBufferImpl(CameraEvent evt, [NotNull] CommandBuffer buffer); // 0x000000018217ECE0-0x000000018217EDD0
		public void AddCommandBuffer(CameraEvent evt, CommandBuffer buffer); // 0x000000018217CCD0-0x000000018217CF20
		public void AddCommandBufferAsync(CameraEvent evt, CommandBuffer buffer, ComputeQueueType queueType); // 0x000000018217C940-0x000000018217CB90
		public void RemoveCommandBuffer(CameraEvent evt, CommandBuffer buffer); // 0x000000018217EDD0-0x000000018217F020
		public CommandBuffer[] GetCommandBuffers(CameraEvent evt); // 0x000000018217DE80-0x000000018217DF90
		[FreeFunction("CameraScripting::GetCommandBuffers", HasExplicitThis = true)]
		internal CommandBuffer[] GetCommandBuffersImpl(CameraEvent evt); // 0x000000018217DDE0-0x000000018217DE80
		[RequiredByNativeCode]
		private static void FireOnPreCull(Camera cam); // 0x000000018217D900-0x000000018217D970
		[RequiredByNativeCode]
		private static void FireOnPreRender(Camera cam); // 0x000000018217D970-0x000000018217D9E0
		[RequiredByNativeCode]
		private static void FireOnPostRender(Camera cam); // 0x000000018217D890-0x000000018217D900
		[RequiredByNativeCode]
		private static void BumpNonSerializedVersion(Camera cam); // 0x000000018217CF20-0x000000018217CF40
		internal void OnlyUsedForTesting1(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void OnlyUsedForTesting2(); // 0x00000001802E76C0-0x00000001802E76D0
		public bool TryGetCullingParameters(out ScriptableCullingParameters cullingParameters); // 0x0000000182181470-0x0000000182181530
		public bool TryGetCullingParameters(bool stereoAware, out ScriptableCullingParameters cullingParameters); // 0x00000001821813A0-0x0000000182181470
		[FreeFunction("ScriptableRenderPipeline_Bindings::GetCullingParameters_Internal")]
		[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
		private static bool GetCullingParameters_Internal(Camera camera, bool stereoAware, out ScriptableCullingParameters cullingParameters, int managedCullingParametersSize); // 0x000000018217E000-0x000000018217E0A0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182182040-0x0000000182182120
		private static float get_nearClipPlane_Injected(IntPtr _unity_self); // 0x00000001821841B0-0x00000001821841F0
		private static void set_nearClipPlane_Injected(IntPtr _unity_self, float value); // 0x0000000182187D00-0x0000000182187D50
		private static float get_farClipPlane_Injected(IntPtr _unity_self); // 0x00000001821838B0-0x00000001821838F0
		private static void set_farClipPlane_Injected(IntPtr _unity_self, float value); // 0x0000000182187240-0x0000000182187290
		private static float get_fieldOfView_Injected(IntPtr _unity_self); // 0x0000000182183980-0x00000001821839C0
		private static void set_fieldOfView_Injected(IntPtr _unity_self, float value); // 0x0000000182187330-0x0000000182187380
		private static RenderingPath get_renderingPath_Injected(IntPtr _unity_self); // 0x0000000182184E00-0x0000000182184E40
		private static void set_renderingPath_Injected(IntPtr _unity_self, RenderingPath value); // 0x0000000182188650-0x0000000182188690
		private static RenderingPath get_actualRenderingPath_Injected(IntPtr _unity_self); // 0x0000000182182330-0x0000000182182370
		private static void Reset_Injected(IntPtr _unity_self); // 0x000000018217FFA0-0x000000018217FFE0
		private static bool get_allowHDR_Injected(IntPtr _unity_self); // 0x0000000182182660-0x00000001821826A0
		private static void set_allowHDR_Injected(IntPtr _unity_self, bool value); // 0x00000001821862B0-0x0000000182186300
		private static bool get_allowMSAA_Injected(IntPtr _unity_self); // 0x0000000182182730-0x0000000182182770
		private static void set_allowMSAA_Injected(IntPtr _unity_self, bool value); // 0x00000001821863A0-0x00000001821863F0
		private static bool get_allowDynamicResolution_Injected(IntPtr _unity_self); // 0x0000000182182590-0x00000001821825D0
		private static void set_allowDynamicResolution_Injected(IntPtr _unity_self, bool value); // 0x00000001821861C0-0x0000000182186210
		private static bool get_forceIntoRenderTexture_Injected(IntPtr _unity_self); // 0x0000000182183BF0-0x0000000182183C30
		private static void set_forceIntoRenderTexture_Injected(IntPtr _unity_self, bool value); // 0x0000000182187600-0x0000000182187650
		private static float get_orthographicSize_Injected(IntPtr _unity_self); // 0x0000000182184450-0x0000000182184490
		private static void set_orthographicSize_Injected(IntPtr _unity_self, float value); // 0x0000000182187FC0-0x0000000182188010
		private static bool get_orthographic_Injected(IntPtr _unity_self); // 0x0000000182184520-0x0000000182184560
		private static void set_orthographic_Injected(IntPtr _unity_self, bool value); // 0x00000001821880B0-0x0000000182188100
		private static OpaqueSortMode get_opaqueSortMode_Injected(IntPtr _unity_self); // 0x0000000182184380-0x00000001821843C0
		private static void set_opaqueSortMode_Injected(IntPtr _unity_self, OpaqueSortMode value); // 0x0000000182187EE0-0x0000000182187F20
		private static TransparencySortMode get_transparencySortMode_Injected(IntPtr _unity_self); // 0x0000000182185BB0-0x0000000182185BF0
		private static void set_transparencySortMode_Injected(IntPtr _unity_self, TransparencySortMode value); // 0x00000001821890B0-0x00000001821890F0
		private static void get_transparencySortAxis_Injected(IntPtr _unity_self, ); // 0x0000000182185AB0-0x0000000182185B00
		private static void set_transparencySortAxis_Injected(IntPtr _unity_self, in Vector3 value); // 0x0000000182188FC0-0x0000000182189010
		private static void ResetTransparencySortSettings_Injected(IntPtr _unity_self); // 0x000000018217FE00-0x000000018217FE40
		private static float get_depth_Injected(IntPtr _unity_self); // 0x0000000182183710-0x0000000182183750
		private static void set_depth_Injected(IntPtr _unity_self, float value); // 0x0000000182187070-0x00000001821870C0
		private static float get_aspect_Injected(IntPtr _unity_self); // 0x0000000182182A70-0x0000000182182AB0
		private static void set_aspect_Injected(IntPtr _unity_self, float value); // 0x0000000182186670-0x00000001821866C0
		private static void ResetAspect_Injected(IntPtr _unity_self); // 0x000000018217F920-0x000000018217F960
		private static void get_velocity_Injected(IntPtr _unity_self, ); // 0x0000000182185FC0-0x0000000182186010
		private static int get_cullingMask_Injected(IntPtr _unity_self); // 0x0000000182183220-0x0000000182183260
		private static void set_cullingMask_Injected(IntPtr _unity_self, int value); // 0x0000000182186CD0-0x0000000182186D10
		private static int get_eventMask_Injected(IntPtr _unity_self); // 0x00000001821837E0-0x0000000182183820
		private static void set_eventMask_Injected(IntPtr _unity_self, int value); // 0x0000000182187160-0x00000001821871A0
		private static bool get_layerCullSphericalInternal_Injected(IntPtr _unity_self); // 0x0000000182183F40-0x0000000182183F80
		private static void set_layerCullSphericalInternal_Injected(IntPtr _unity_self, bool value); // 0x0000000182187A00-0x0000000182187A50
		private static CameraType get_cameraType_Injected(IntPtr _unity_self); // 0x0000000182182EE0-0x0000000182182F20
		private static void set_cameraType_Injected(IntPtr _unity_self, CameraType value); // 0x0000000182186A20-0x0000000182186A60
		private static IntPtr get_skyboxMaterial_Injected(IntPtr _unity_self); // 0x00000001821853F0-0x0000000182185430
		private static ulong get_overrideSceneCullingMask_Injected(IntPtr _unity_self); // 0x00000001821845F0-0x0000000182184630
		private static void set_overrideSceneCullingMask_Injected(IntPtr _unity_self, ulong value); // 0x00000001821881A0-0x00000001821881F0
		private static ulong get_sceneCullingMask_Injected(IntPtr _unity_self); // 0x0000000182185070-0x00000001821850B0
		private static bool get_useInteractiveLightBakingData_Injected(IntPtr _unity_self); // 0x0000000182185C80-0x0000000182185CC0
		private static void set_useInteractiveLightBakingData_Injected(IntPtr _unity_self, bool value); // 0x0000000182189190-0x00000001821891E0
		private static void GetLayerCullDistances_Injected(IntPtr _unity_self, ); // 0x000000018217E440-0x000000018217E490
		private static void SetLayerCullDistances_Injected(IntPtr _unity_self, ref ManagedSpanWrapper d); // 0x00000001821806F0-0x0000000182180740
		private static bool get_useOcclusionCulling_Injected(IntPtr _unity_self); // 0x0000000182185E20-0x0000000182185E60
		private static void set_useOcclusionCulling_Injected(IntPtr _unity_self, bool value); // 0x0000000182189370-0x00000001821893C0
		private static void get_cullingMatrix_Injected(IntPtr _unity_self, ); // 0x00000001821832F0-0x0000000182183340
		private static void set_cullingMatrix_Injected(IntPtr _unity_self, in Matrix4x4 value); // 0x0000000182186DB0-0x0000000182186E00
		private static void ResetCullingMatrix_Injected(IntPtr _unity_self); // 0x000000018217F9F0-0x000000018217FA30
		private static void get_backgroundColor_Injected(IntPtr _unity_self, ); // 0x0000000182182B40-0x0000000182182B90
		private static void set_backgroundColor_Injected(IntPtr _unity_self, in Color value); // 0x0000000182186760-0x00000001821867B0
		private static CameraClearFlags get_clearFlags_Injected(IntPtr _unity_self); // 0x0000000182182FB0-0x0000000182182FF0
		private static void set_clearFlags_Injected(IntPtr _unity_self, CameraClearFlags value); // 0x0000000182186B00-0x0000000182186B40
		private static DepthTextureMode get_depthTextureMode_Injected(IntPtr _unity_self); // 0x0000000182183640-0x0000000182183680
		private static void set_depthTextureMode_Injected(IntPtr _unity_self, DepthTextureMode value); // 0x0000000182186F90-0x0000000182186FD0
		private static bool get_clearStencilAfterLightingPass_Injected(IntPtr _unity_self); // 0x0000000182183080-0x00000001821830C0
		private static void set_clearStencilAfterLightingPass_Injected(IntPtr _unity_self, bool value); // 0x0000000182186BE0-0x0000000182186C30
		private static void SetReplacementShader_Injected(IntPtr _unity_self, IntPtr shader, ref ManagedSpanWrapper replacementTag); // 0x0000000182180860-0x00000001821808C0
		private static void ResetReplacementShader_Injected(IntPtr _unity_self); // 0x000000018217FB90-0x000000018217FBD0
		private static ProjectionMatrixMode get_projectionMatrixMode_Injected(IntPtr _unity_self); // 0x0000000182184A60-0x0000000182184AA0
		private static bool get_usePhysicalProperties_Injected(IntPtr _unity_self); // 0x0000000182185EF0-0x0000000182185F30
		private static void set_usePhysicalProperties_Injected(IntPtr _unity_self, bool value); // 0x0000000182189460-0x00000001821894B0
		private static int get_iso_Injected(IntPtr _unity_self); // 0x0000000182183E60-0x0000000182183EA0
		private static void set_iso_Injected(IntPtr _unity_self, int value); // 0x00000001821877D0-0x0000000182187810
		private static float get_shutterSpeed_Injected(IntPtr _unity_self); // 0x0000000182185320-0x0000000182185360
		private static void set_shutterSpeed_Injected(IntPtr _unity_self, float value); // 0x0000000182188910-0x0000000182188960
		private static float get_aperture_Injected(IntPtr _unity_self); // 0x00000001821828D0-0x0000000182182910
		private static void set_aperture_Injected(IntPtr _unity_self, float value); // 0x0000000182186580-0x00000001821865D0
		private static float get_focusDistance_Injected(IntPtr _unity_self); // 0x0000000182183B20-0x0000000182183B60
		private static void set_focusDistance_Injected(IntPtr _unity_self, float value); // 0x0000000182187510-0x0000000182187560
		private static float get_focalLength_Injected(IntPtr _unity_self); // 0x0000000182183A50-0x0000000182183A90
		private static void set_focalLength_Injected(IntPtr _unity_self, float value); // 0x0000000182187420-0x0000000182187470
		private static int get_bladeCount_Injected(IntPtr _unity_self); // 0x0000000182182D10-0x0000000182182D50
		private static void set_bladeCount_Injected(IntPtr _unity_self, int value); // 0x0000000182186940-0x0000000182186980
		private static void get_curvature_Injected(IntPtr _unity_self, ); // 0x0000000182183550-0x00000001821835A0
		private static void set_curvature_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182186EA0-0x0000000182186EF0
		private static float get_barrelClipping_Injected(IntPtr _unity_self); // 0x0000000182182C40-0x0000000182182C80
		private static void set_barrelClipping_Injected(IntPtr _unity_self, float value); // 0x0000000182186850-0x00000001821868A0
		private static float get_anamorphism_Injected(IntPtr _unity_self); // 0x0000000182182800-0x0000000182182840
		private static void set_anamorphism_Injected(IntPtr _unity_self, float value); // 0x0000000182186490-0x00000001821864E0
		private static void get_sensorSize_Injected(IntPtr _unity_self, ); // 0x0000000182185230-0x0000000182185280
		private static void set_sensorSize_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182188820-0x0000000182188870
		private static void get_lensShift_Injected(IntPtr _unity_self, ); // 0x0000000182184010-0x0000000182184060
		private static void set_lensShift_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182187C10-0x0000000182187C60
		private static GateFitMode get_gateFit_Injected(IntPtr _unity_self); // 0x0000000182183CC0-0x0000000182183D00
		private static void set_gateFit_Injected(IntPtr _unity_self, GateFitMode value); // 0x00000001821876F0-0x0000000182187730
		private static float GetGateFittedFieldOfView_Injected(IntPtr _unity_self); // 0x000000018217E280-0x000000018217E2C0
		private static void GetGateFittedLensShift_Injected(IntPtr _unity_self, ); // 0x000000018217E350-0x000000018217E3A0
		private static void GetLocalSpaceAim_Injected(IntPtr _unity_self, ); // 0x000000018217E5C0-0x000000018217E610
		private static void get_rect_Injected(IntPtr _unity_self, ); // 0x0000000182184C30-0x0000000182184C80
		private static void set_rect_Injected(IntPtr _unity_self, in Rect value); // 0x0000000182188470-0x00000001821884C0
		private static void get_pixelRect_Injected(IntPtr _unity_self, ); // 0x0000000182184790-0x00000001821847E0
		private static void set_pixelRect_Injected(IntPtr _unity_self, in Rect value); // 0x0000000182188290-0x00000001821882E0
		private static int get_pixelWidth_Injected(IntPtr _unity_self); // 0x0000000182184890-0x00000001821848D0
		private static int get_pixelHeight_Injected(IntPtr _unity_self); // 0x00000001821846C0-0x0000000182184700
		private static int get_scaledPixelWidth_Injected(IntPtr _unity_self); // 0x0000000182184FA0-0x0000000182184FE0
		private static int get_scaledPixelHeight_Injected(IntPtr _unity_self); // 0x0000000182184ED0-0x0000000182184F10
		private static IntPtr get_targetTexture_Injected(IntPtr _unity_self); // 0x00000001821859C0-0x0000000182185A00
		private static void set_targetTexture_Injected(IntPtr _unity_self, IntPtr value); // 0x0000000182188EB0-0x0000000182188F00
		private static IntPtr get_activeTexture_Injected(IntPtr _unity_self); // 0x0000000182182240-0x0000000182182280
		private static int get_targetDisplay_Injected(IntPtr _unity_self); // 0x00000001821858F0-0x0000000182185930
		private static void set_targetDisplay_Injected(IntPtr _unity_self, int value); // 0x0000000182188DD0-0x0000000182188E10
		private static void SetTargetBuffersImpl_Injected(IntPtr _unity_self, in RenderBuffer color, in RenderBuffer depth); // 0x0000000182180C90-0x0000000182180CF0
		private static void SetTargetBuffersMRTImpl_Injected(IntPtr _unity_self, ref ManagedSpanWrapper color, in RenderBuffer depth); // 0x0000000182180DA0-0x0000000182180E00
		private static string[] GetCameraBufferWarnings_Injected(IntPtr _unity_self); // 0x000000018217DCD0-0x000000018217DD10
		private static void get_cameraToWorldMatrix_Injected(IntPtr _unity_self, ); // 0x0000000182182DE0-0x0000000182182E30
		private static void get_worldToCameraMatrix_Injected(IntPtr _unity_self, ); // 0x00000001821860C0-0x0000000182186110
		private static void set_worldToCameraMatrix_Injected(IntPtr _unity_self, in Matrix4x4 value); // 0x0000000182189550-0x00000001821895A0
		private static void get_projectionMatrix_Injected(IntPtr _unity_self, ); // 0x0000000182184B30-0x0000000182184B80
		private static void set_projectionMatrix_Injected(IntPtr _unity_self, in Matrix4x4 value); // 0x0000000182188380-0x00000001821883D0
		private static void get_nonJitteredProjectionMatrix_Injected(IntPtr _unity_self, ); // 0x0000000182184280-0x00000001821842D0
		private static void set_nonJitteredProjectionMatrix_Injected(IntPtr _unity_self, in Matrix4x4 value); // 0x0000000182187DF0-0x0000000182187E40
		private static bool get_useJitteredProjectionMatrixForTransparentRendering_Injected(IntPtr _unity_self); // 0x0000000182185D50-0x0000000182185D90
		private static void set_useJitteredProjectionMatrixForTransparentRendering_Injected(IntPtr _unity_self, bool value); // 0x0000000182189280-0x00000001821892D0
		private static void get_previousViewProjectionMatrix_Injected(IntPtr _unity_self, ); // 0x0000000182184960-0x00000001821849B0
		private static void ResetWorldToCameraMatrix_Injected(IntPtr _unity_self); // 0x000000018217FED0-0x000000018217FF10
		private static void ResetProjectionMatrix_Injected(IntPtr _unity_self); // 0x000000018217FAC0-0x000000018217FB00
		private static void CalculateObliqueMatrix_Injected(IntPtr _unity_self, in Vector4 clipPlane, ); // 0x000000018217D2D0-0x000000018217D330
		private static void WorldToScreenPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, ); // 0x0000000182181C00-0x0000000182181C70
		private static void WorldToViewportPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, ); // 0x0000000182181E20-0x0000000182181E90
		private static void ViewportToWorldPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, ); // 0x00000001821819E0-0x0000000182181A50
		private static void ScreenToWorldPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, ); // 0x00000001821804D0-0x0000000182180540
		private static void ScreenToViewportPoint_Injected(IntPtr _unity_self, in Vector3 position, ); // 0x00000001821803B0-0x0000000182180410
		private static void ViewportToScreenPoint_Injected(IntPtr _unity_self, in Vector3 position, ); // 0x00000001821818C0-0x0000000182181920
		private static void GetFrustumPlaneSizeAt_Injected(IntPtr _unity_self, float distance, ); // 0x000000018217E170-0x000000018217E1D0
		private static void ViewportPointToRay_Injected(IntPtr _unity_self, in Vector2 pos, MonoOrStereoscopicEye eye, ); // 0x0000000182181580-0x00000001821815F0
		private static void ScreenPointToRay_Injected(IntPtr _unity_self, in Vector2 pos, MonoOrStereoscopicEye eye, ); // 0x0000000182180070-0x00000001821800E0
		private static void CalculateFrustumCornersInternal_Injected(IntPtr _unity_self, in Rect viewport, float z, MonoOrStereoscopicEye eye, out BlittableArrayWrapper outCorners); // 0x000000018217CF40-0x000000018217CFB0
		private static void CalculateProjectionMatrixFromPhysicalPropertiesInternal_Injected(out Matrix4x4 output, float focalLength, in Vector2 sensorSize, in Vector2 lensShift, float nearClip, float farClip, float gateAspect, GateFitMode gateFitMode); // 0x000000018217D3F0-0x000000018217D460
		private static IntPtr get_main_Injected(); // 0x0000000182184100-0x0000000182184130
		private static IntPtr get_currentInternal_Injected(); // 0x00000001821833F0-0x0000000182183420
		private static void get_scene_Injected(IntPtr _unity_self, ); // 0x0000000182185140-0x0000000182185190
		private static void set_scene_Injected(IntPtr _unity_self, in Scene value); // 0x0000000182188730-0x0000000182188780
		private static bool get_stereoEnabled_Injected(IntPtr _unity_self); // 0x0000000182185680-0x00000001821856C0
		private static float get_stereoSeparation_Injected(IntPtr _unity_self); // 0x0000000182185750-0x0000000182185790
		private static void set_stereoSeparation_Injected(IntPtr _unity_self, float value); // 0x0000000182188AF0-0x0000000182188B40
		private static float get_stereoConvergence_Injected(IntPtr _unity_self); // 0x00000001821855B0-0x00000001821855F0
		private static void set_stereoConvergence_Injected(IntPtr _unity_self, float value); // 0x0000000182188A00-0x0000000182188A50
		private static bool get_areVRStereoViewMatricesWithinSingleCullTolerance_Injected(IntPtr _unity_self); // 0x00000001821829A0-0x00000001821829E0
		private static StereoTargetEyeMask get_stereoTargetEyeInternal_Injected(IntPtr _unity_self); // 0x0000000182185820-0x0000000182185860
		private static void set_stereoTargetEyeInternal_Injected(IntPtr _unity_self, StereoTargetEyeMask value); // 0x0000000182188BE0-0x0000000182188C20
		private static MonoOrStereoscopicEye get_stereoActiveEye_Injected(IntPtr _unity_self); // 0x00000001821854E0-0x0000000182185520
		private static void GetStereoNonJitteredProjectionMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, ); // 0x000000018217E6C0-0x000000018217E710
		private static void GetStereoViewMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, ); // 0x000000018217E8E0-0x000000018217E930
		private static void CopyStereoDeviceProjectionMatrixToNonJittered_Injected(IntPtr _unity_self, StereoscopicEye eye); // 0x000000018217D760-0x000000018217D7A0
		private static void GetStereoProjectionMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, ); // 0x000000018217E7D0-0x000000018217E820
		private static void SetStereoProjectionMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, in Matrix4x4 matrix); // 0x0000000182180A90-0x0000000182180AE0
		private static void ResetStereoProjectionMatrices_Injected(IntPtr _unity_self); // 0x000000018217FC60-0x000000018217FCA0
		private static void SetStereoViewMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, in Matrix4x4 matrix); // 0x0000000182180B90-0x0000000182180BE0
		private static void ResetStereoViewMatrices_Injected(IntPtr _unity_self); // 0x000000018217FD30-0x000000018217FD70
		private static int GetAllCamerasImpl_Injected(out Camera[] cam); // 0x000000018217DA60-0x000000018217DAA0
		private static bool RenderToCubemapImpl_Injected(IntPtr _unity_self, IntPtr tex, [DefaultValue("63")] int faceMask); // 0x000000018217F430-0x000000018217F490
		private static int GetFilterMode_Injected(IntPtr _unity_self); // 0x000000018217E0A0-0x000000018217E0E0
		private static bool get_renderCloudsInSceneView_Injected(IntPtr _unity_self); // 0x0000000182184D30-0x0000000182184D70
		private static void set_renderCloudsInSceneView_Injected(IntPtr _unity_self, bool value); // 0x0000000182188560-0x00000001821885B0
		private static bool RenderToCubemapEyeImpl_Injected(IntPtr _unity_self, IntPtr cubemap, int faceMask, MonoOrStereoscopicEye stereoEye); // 0x000000018217F2F0-0x000000018217F360
		private static void Render_Injected(IntPtr _unity_self); // 0x000000018217F850-0x000000018217F890
		private static void RenderWithShader_Injected(IntPtr _unity_self, IntPtr shader, ref ManagedSpanWrapper replacementTag); // 0x000000018217F620-0x000000018217F680
		private static void RenderDontRestore_Injected(IntPtr _unity_self); // 0x000000018217F220-0x000000018217F260
		private static void SubmitRenderRequestsInternal_Injected(IntPtr _unity_self, object requests); // 0x00000001821812B0-0x0000000182181300
		private static Object[] SubmitBuiltInObjectIDRenderRequest_Injected(IntPtr _unity_self, IntPtr target, int mipLevel, CubemapFace cubemapFace, int depthSlice); // 0x0000000182181170-0x00000001821811E0
		private static bool get_isProcessingRenderRequest_Injected(IntPtr _unity_self); // 0x0000000182183D90-0x0000000182183DD0
		private static void SetupCurrent_Injected(IntPtr cur); // 0x00000001821810C0-0x0000000182181100
		private static void CopyFrom_Injected(IntPtr _unity_self, IntPtr other); // 0x000000018217D650-0x000000018217D6A0
		private static int get_commandBufferCount_Injected(IntPtr _unity_self); // 0x0000000182183150-0x0000000182183190
		private static void RemoveCommandBuffersImpl_Injected(IntPtr _unity_self, CameraEvent evt); // 0x000000018217F020-0x000000018217F060
		private static void RemoveAllCommandBuffersImpl_Injected(IntPtr _unity_self); // 0x000000018217EAC0-0x000000018217EB00
		private static void AddCommandBufferImpl_Injected(IntPtr _unity_self, CameraEvent evt, IntPtr buffer); // 0x000000018217CB90-0x000000018217CBE0
		private static void AddCommandBufferAsyncImpl_Injected(IntPtr _unity_self, CameraEvent evt, IntPtr buffer, ComputeQueueType queueType); // 0x000000018217C7D0-0x000000018217C830
		private static void RemoveCommandBufferImpl_Injected(IntPtr _unity_self, CameraEvent evt, IntPtr buffer); // 0x000000018217EC90-0x000000018217ECE0
		private static CommandBuffer[] GetCommandBuffersImpl_Injected(IntPtr _unity_self, CameraEvent evt); // 0x000000018217DDA0-0x000000018217DDE0
		private static bool GetCullingParameters_Internal_Injected(IntPtr camera, bool stereoAware, out ScriptableCullingParameters cullingParameters, int managedCullingParametersSize); // 0x000000018217DF90-0x000000018217E000
	}
}
