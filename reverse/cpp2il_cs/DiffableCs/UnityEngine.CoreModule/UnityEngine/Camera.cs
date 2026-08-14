namespace UnityEngine;

[NativeHeader("Runtime/Shaders/Shader.h")]
[NativeHeader("Runtime/Camera/RenderManager.h")]
[NativeHeader("Runtime/Camera/Camera.h")]
[NativeHeader("Runtime/Misc/GameObjectUtility.h")]
[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
[NativeHeader("Runtime/Graphics/CommandBuffer/RenderingCommandBuffer.h")]
[NativeHeader("Runtime/Graphics/RenderTexture.h")]
[RequireComponent(typeof(Transform))]
[UsedByNativeCode]
public sealed class Camera : Behaviour
{
	internal sealed class CameraCallback : MulticastDelegate
	{

		public CameraCallback(object object, IntPtr method) { }

		public override void Invoke(Camera cam) { }

	}

	internal enum MonoOrStereoscopicEye
	{
		Left = 0,
		Right = 1,
		Mono = 2,
	}

	internal enum SceneViewFilterMode
	{
		Off = 0,
		ShowFiltered = 1,
	}

	internal enum StereoscopicEye
	{
		Left = 0,
		Right = 1,
	}

	public const float kMinAperture = 0.7; //Field offset: 0x0
	public const float kMaxAperture = 32; //Field offset: 0x0
	public const int kMinBladeCount = 3; //Field offset: 0x0
	public const int kMaxBladeCount = 11; //Field offset: 0x0
	public static CameraCallback onPreCull; //Field offset: 0x0
	public static CameraCallback onPreRender; //Field offset: 0x8
	public static CameraCallback onPostRender; //Field offset: 0x10
	internal uint m_NonSerializedVersion; //Field offset: 0x18

	public static Camera[] allCameras
	{
		 get { } //Length: 179
	}

	public static int allCamerasCount
	{
		 get { } //Length: 42
	}

	public bool allowDynamicResolution
	{
		 get { } //Length: 118
	}

	public bool allowHDR
	{
		 get { } //Length: 118
	}

	public bool allowMSAA
	{
		 get { } //Length: 118
	}

	public float aspect
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public Color backgroundColor
	{
		 get { } //Length: 142
		 set { } //Length: 133
	}

	public Matrix4x4 cameraToWorldMatrix
	{
		 get { } //Length: 154
	}

	public CameraType cameraType
	{
		 get { } //Length: 118
	}

	public CameraClearFlags clearFlags
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public int cullingMask
	{
		 get { } //Length: 118
	}

	public static Camera current
	{
		 get { } //Length: 84
	}

	private static Camera currentInternal
	{
		[FreeFunction("GetCurrentCameraPPtr")]
		private get { } //Length: 84
	}

	public float depth
	{
		 get { } //Length: 118
	}

	public DepthTextureMode depthTextureMode
	{
		 get { } //Length: 118
		 set { } //Length: 131
	}

	public int eventMask
	{
		 get { } //Length: 118
	}

	[NativeProperty("Far")]
	public float farClipPlane
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	[NativeProperty("VerticalFieldOfView")]
	public float fieldOfView
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public Single[] layerCullDistances
	{
		 get { } //Length: 9
		 set { } //Length: 355
	}

	public static Camera main
	{
		[FreeFunction("FindMainCamera")]
		 get { } //Length: 84
	}

	[NativeProperty("Near")]
	public float nearClipPlane
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public OpaqueSortMode opaqueSortMode
	{
		 get { } //Length: 118
	}

	public bool orthographic
	{
		 get { } //Length: 118
	}

	public float orthographicSize
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	public int pixelHeight
	{
		[FreeFunction("CameraScripting::GetPixelHeight", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	[NativeProperty("ScreenViewportRect")]
	public Rect pixelRect
	{
		 get { } //Length: 142
		 set { } //Length: 133
	}

	public int pixelWidth
	{
		[FreeFunction("CameraScripting::GetPixelWidth", HasExplicitThis = True)]
		 get { } //Length: 118
	}

	public Matrix4x4 projectionMatrix
	{
		 get { } //Length: 154
	}

	[NativeProperty("NormalizedViewportRect")]
	public Rect rect
	{
		 get { } //Length: 142
		 set { } //Length: 133
	}

	[NativeConditional("UNITY_EDITOR")]
	public SceneViewFilterMode sceneViewFilterMode
	{
		 get { } //Length: 118
	}

	public int targetDisplay
	{
		 get { } //Length: 118
	}

	public RenderTexture targetTexture
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	public bool usePhysicalProperties
	{
		 get { } //Length: 118
	}

	public Matrix4x4 worldToCameraMatrix
	{
		 get { } //Length: 154
	}

	[RequiredByNativeCode]
	private static void BumpNonSerializedVersion(Camera cam) { }

	[RequiredByNativeCode]
	private static void FireOnPostRender(Camera cam) { }

	[RequiredByNativeCode]
	private static void FireOnPreCull(Camera cam) { }

	[RequiredByNativeCode]
	private static void FireOnPreRender(Camera cam) { }

	public static Camera[] get_allCameras() { }

	public static int get_allCamerasCount() { }

	public bool get_allowDynamicResolution() { }

	private static bool get_allowDynamicResolution_Injected(IntPtr _unity_self) { }

	public bool get_allowHDR() { }

	private static bool get_allowHDR_Injected(IntPtr _unity_self) { }

	public bool get_allowMSAA() { }

	private static bool get_allowMSAA_Injected(IntPtr _unity_self) { }

	public float get_aspect() { }

	private static float get_aspect_Injected(IntPtr _unity_self) { }

	public Color get_backgroundColor() { }

	private static void get_backgroundColor_Injected(IntPtr _unity_self, out Color ret) { }

	public Matrix4x4 get_cameraToWorldMatrix() { }

	private static void get_cameraToWorldMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret) { }

	public CameraType get_cameraType() { }

	private static CameraType get_cameraType_Injected(IntPtr _unity_self) { }

	public CameraClearFlags get_clearFlags() { }

	private static CameraClearFlags get_clearFlags_Injected(IntPtr _unity_self) { }

	public int get_cullingMask() { }

	private static int get_cullingMask_Injected(IntPtr _unity_self) { }

	public static Camera get_current() { }

	[FreeFunction("GetCurrentCameraPPtr")]
	private static Camera get_currentInternal() { }

	private static IntPtr get_currentInternal_Injected() { }

	public float get_depth() { }

	private static float get_depth_Injected(IntPtr _unity_self) { }

	public DepthTextureMode get_depthTextureMode() { }

	private static DepthTextureMode get_depthTextureMode_Injected(IntPtr _unity_self) { }

	public int get_eventMask() { }

	private static int get_eventMask_Injected(IntPtr _unity_self) { }

	public float get_farClipPlane() { }

	private static float get_farClipPlane_Injected(IntPtr _unity_self) { }

	public float get_fieldOfView() { }

	private static float get_fieldOfView_Injected(IntPtr _unity_self) { }

	public Single[] get_layerCullDistances() { }

	[FreeFunction("FindMainCamera")]
	public static Camera get_main() { }

	private static IntPtr get_main_Injected() { }

	public float get_nearClipPlane() { }

	private static float get_nearClipPlane_Injected(IntPtr _unity_self) { }

	public OpaqueSortMode get_opaqueSortMode() { }

	private static OpaqueSortMode get_opaqueSortMode_Injected(IntPtr _unity_self) { }

	public bool get_orthographic() { }

	private static bool get_orthographic_Injected(IntPtr _unity_self) { }

	public float get_orthographicSize() { }

	private static float get_orthographicSize_Injected(IntPtr _unity_self) { }

	[FreeFunction("CameraScripting::GetPixelHeight", HasExplicitThis = True)]
	public int get_pixelHeight() { }

	private static int get_pixelHeight_Injected(IntPtr _unity_self) { }

	public Rect get_pixelRect() { }

	private static void get_pixelRect_Injected(IntPtr _unity_self, out Rect ret) { }

	[FreeFunction("CameraScripting::GetPixelWidth", HasExplicitThis = True)]
	public int get_pixelWidth() { }

	private static int get_pixelWidth_Injected(IntPtr _unity_self) { }

	public Matrix4x4 get_projectionMatrix() { }

	private static void get_projectionMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret) { }

	public Rect get_rect() { }

	private static void get_rect_Injected(IntPtr _unity_self, out Rect ret) { }

	public SceneViewFilterMode get_sceneViewFilterMode() { }

	public int get_targetDisplay() { }

	private static int get_targetDisplay_Injected(IntPtr _unity_self) { }

	public RenderTexture get_targetTexture() { }

	private static IntPtr get_targetTexture_Injected(IntPtr _unity_self) { }

	public bool get_usePhysicalProperties() { }

	private static bool get_usePhysicalProperties_Injected(IntPtr _unity_self) { }

	public Matrix4x4 get_worldToCameraMatrix() { }

	private static void get_worldToCameraMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret) { }

	public static int GetAllCameras(Camera[] cameras) { }

	[FreeFunction("CameraScripting::GetAllCamerasCount")]
	private static int GetAllCamerasCount() { }

	[FreeFunction("CameraScripting::GetAllCameras")]
	private static int GetAllCamerasImpl(out Camera[] cam) { }

	private static int GetAllCamerasImpl_Injected(out Camera[] cam) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::GetCullingParameters_Internal")]
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
	private static bool GetCullingParameters_Internal(Camera camera, bool stereoAware, out ScriptableCullingParameters cullingParameters, int managedCullingParametersSize) { }

	private static bool GetCullingParameters_Internal_Injected(IntPtr camera, bool stereoAware, out ScriptableCullingParameters cullingParameters, int managedCullingParametersSize) { }

	[NativeConditional("UNITY_EDITOR")]
	private int GetFilterMode() { }

	private static int GetFilterMode_Injected(IntPtr _unity_self) { }

	[FreeFunction("CameraScripting::GetLayerCullDistances", HasExplicitThis = True)]
	private Single[] GetLayerCullDistances() { }

	private static void GetLayerCullDistances_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret) { }

	public Ray ScreenPointToRay(Vector3 pos, MonoOrStereoscopicEye eye) { }

	public Ray ScreenPointToRay(Vector3 pos) { }

	private Ray ScreenPointToRay(Vector2 pos, MonoOrStereoscopicEye eye) { }

	private static void ScreenPointToRay_Injected(IntPtr _unity_self, in Vector2 pos, MonoOrStereoscopicEye eye, out Ray ret) { }

	public Vector3 ScreenToViewportPoint(Vector3 position) { }

	private static void ScreenToViewportPoint_Injected(IntPtr _unity_self, in Vector3 position, out Vector3 ret) { }

	public Vector3 ScreenToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye) { }

	public Vector3 ScreenToWorldPoint(Vector3 position) { }

	private static void ScreenToWorldPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, out Vector3 ret) { }

	public void set_aspect(float value) { }

	private static void set_aspect_Injected(IntPtr _unity_self, float value) { }

	public void set_backgroundColor(Color value) { }

	private static void set_backgroundColor_Injected(IntPtr _unity_self, in Color value) { }

	public void set_clearFlags(CameraClearFlags value) { }

	private static void set_clearFlags_Injected(IntPtr _unity_self, CameraClearFlags value) { }

	public void set_depthTextureMode(DepthTextureMode value) { }

	private static void set_depthTextureMode_Injected(IntPtr _unity_self, DepthTextureMode value) { }

	public void set_farClipPlane(float value) { }

	private static void set_farClipPlane_Injected(IntPtr _unity_self, float value) { }

	public void set_fieldOfView(float value) { }

	private static void set_fieldOfView_Injected(IntPtr _unity_self, float value) { }

	public void set_layerCullDistances(Single[] value) { }

	public void set_nearClipPlane(float value) { }

	private static void set_nearClipPlane_Injected(IntPtr _unity_self, float value) { }

	public void set_orthographicSize(float value) { }

	private static void set_orthographicSize_Injected(IntPtr _unity_self, float value) { }

	public void set_pixelRect(Rect value) { }

	private static void set_pixelRect_Injected(IntPtr _unity_self, in Rect value) { }

	public void set_rect(Rect value) { }

	private static void set_rect_Injected(IntPtr _unity_self, in Rect value) { }

	public void set_targetTexture(RenderTexture value) { }

	private static void set_targetTexture_Injected(IntPtr _unity_self, IntPtr value) { }

	[FreeFunction("CameraScripting::SetLayerCullDistances", HasExplicitThis = True)]
	private void SetLayerCullDistances(Single[] d) { }

	private static void SetLayerCullDistances_Injected(IntPtr _unity_self, ref ManagedSpanWrapper d) { }

	public void SetStereoProjectionMatrix(StereoscopicEye eye, Matrix4x4 matrix) { }

	private static void SetStereoProjectionMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, in Matrix4x4 matrix) { }

	public void SetStereoViewMatrix(StereoscopicEye eye, Matrix4x4 matrix) { }

	private static void SetStereoViewMatrix_Injected(IntPtr _unity_self, StereoscopicEye eye, in Matrix4x4 matrix) { }

	[FreeFunction("CameraScripting::SetupCurrent")]
	public static void SetupCurrent(Camera cur) { }

	private static void SetupCurrent_Injected(IntPtr cur) { }

	public bool TryGetCullingParameters(bool stereoAware, out ScriptableCullingParameters cullingParameters) { }

	public Vector3 ViewportToWorldPoint(Vector3 position, MonoOrStereoscopicEye eye) { }

	public Vector3 ViewportToWorldPoint(Vector3 position) { }

	private static void ViewportToWorldPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, out Vector3 ret) { }

	public Vector3 WorldToScreenPoint(Vector3 position, MonoOrStereoscopicEye eye) { }

	public Vector3 WorldToScreenPoint(Vector3 position) { }

	private static void WorldToScreenPoint_Injected(IntPtr _unity_self, in Vector3 position, MonoOrStereoscopicEye eye, out Vector3 ret) { }

}

