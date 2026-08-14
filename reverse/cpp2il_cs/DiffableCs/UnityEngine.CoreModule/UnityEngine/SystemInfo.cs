namespace UnityEngine;

[NativeHeader("Runtime/Shaders/GraphicsCapsScriptBindings.h")]
[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
[NativeHeader("Runtime/Misc/SystemInfo.h")]
[NativeHeader("Runtime/Misc/SystemInfoMemory.h")]
[NativeHeader("Runtime/Graphics/GraphicsFormatUtility.bindings.h")]
[NativeHeader("Runtime/Camera/RenderLoops/MotionVectorRenderLoop.h")]
[NativeHeader("Runtime/Input/GetInput.h")]
public sealed class SystemInfo
{

	public static CopyTextureSupport copyTextureSupport
	{
		 get { } //Length: 42
	}

	public static string deviceModel
	{
		 get { } //Length: 9
	}

	public static DeviceType deviceType
	{
		 get { } //Length: 42
	}

	public static string deviceUniqueIdentifier
	{
		 get { } //Length: 9
	}

	public static FoveatedRenderingCaps foveatedRenderingCaps
	{
		 get { } //Length: 42
	}

	public static string graphicsDeviceName
	{
		 get { } //Length: 9
	}

	public static GraphicsDeviceType graphicsDeviceType
	{
		 get { } //Length: 42
	}

	public static string graphicsDeviceVendor
	{
		 get { } //Length: 9
	}

	public static int graphicsDeviceVendorID
	{
		 get { } //Length: 42
	}

	public static bool graphicsMultiThreaded
	{
		 get { } //Length: 42
	}

	public static int graphicsShaderLevel
	{
		 get { } //Length: 42
	}

	public static bool graphicsUVStartsAtTop
	{
		 get { } //Length: 42
	}

	public static bool hasHiddenSurfaceRemovalOnGPU
	{
		 get { } //Length: 42
	}

	public static HDRDisplaySupportFlags hdrDisplaySupportFlags
	{
		 get { } //Length: 42
	}

	public static long maxGraphicsBufferSize
	{
		 get { } //Length: 42
	}

	internal static int maxRenderTextureSize
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
		internal get { } //Length: 42
	}

	public static int maxTextureSize
	{
		 get { } //Length: 42
	}

	public static string operatingSystem
	{
		 get { } //Length: 9
	}

	public static OperatingSystemFamily operatingSystemFamily
	{
		 get { } //Length: 42
	}

	public static string processorType
	{
		 get { } //Length: 9
	}

	public static RenderingThreadingMode renderingThreadingMode
	{
		 get { } //Length: 42
	}

	public static int supportedRenderTargetCount
	{
		 get { } //Length: 42
	}

	public static bool supportsComputeShaders
	{
		 get { } //Length: 42
	}

	public static bool supportsGraphicsFence
	{
		 get { } //Length: 42
	}

	public static bool supportsIndirectArgumentsBuffer
	{
		 get { } //Length: 42
	}

	public static bool supportsInstancing
	{
		 get { } //Length: 42
	}

	public static bool supportsMultisampleAutoResolve
	{
		 get { } //Length: 42
	}

	public static int supportsMultisampledTextures
	{
		 get { } //Length: 42
	}

	public static bool supportsMultisampleResolveDepth
	{
		 get { } //Length: 42
	}

	public static bool supportsMultisampleResolveStencil
	{
		 get { } //Length: 42
	}

	public static bool supportsMultiview
	{
		 get { } //Length: 42
	}

	public static bool supportsRenderTargetArrayIndexFromVertexShader
	{
		 get { } //Length: 42
	}

	public static bool supportsShadows
	{
		 get { } //Length: 42
	}

	public static bool supportsStoreAndResolveAction
	{
		 get { } //Length: 42
	}

	public static bool usesLoadStoreActions
	{
		 get { } //Length: 42
	}

	public static bool usesReversedZBuffer
	{
		 get { } //Length: 42
	}

	public static CopyTextureSupport get_copyTextureSupport() { }

	public static string get_deviceModel() { }

	public static DeviceType get_deviceType() { }

	public static string get_deviceUniqueIdentifier() { }

	public static FoveatedRenderingCaps get_foveatedRenderingCaps() { }

	public static string get_graphicsDeviceName() { }

	public static GraphicsDeviceType get_graphicsDeviceType() { }

	public static string get_graphicsDeviceVendor() { }

	public static int get_graphicsDeviceVendorID() { }

	public static bool get_graphicsMultiThreaded() { }

	public static int get_graphicsShaderLevel() { }

	public static bool get_graphicsUVStartsAtTop() { }

	public static bool get_hasHiddenSurfaceRemovalOnGPU() { }

	public static HDRDisplaySupportFlags get_hdrDisplaySupportFlags() { }

	public static long get_maxGraphicsBufferSize() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static int get_maxRenderTextureSize() { }

	public static int get_maxTextureSize() { }

	public static string get_operatingSystem() { }

	public static OperatingSystemFamily get_operatingSystemFamily() { }

	public static string get_processorType() { }

	public static RenderingThreadingMode get_renderingThreadingMode() { }

	public static int get_supportedRenderTargetCount() { }

	public static bool get_supportsComputeShaders() { }

	public static bool get_supportsGraphicsFence() { }

	public static bool get_supportsIndirectArgumentsBuffer() { }

	public static bool get_supportsInstancing() { }

	public static bool get_supportsMultisampleAutoResolve() { }

	public static int get_supportsMultisampledTextures() { }

	public static bool get_supportsMultisampleResolveDepth() { }

	public static bool get_supportsMultisampleResolveStencil() { }

	public static bool get_supportsMultiview() { }

	public static bool get_supportsRenderTargetArrayIndexFromVertexShader() { }

	public static bool get_supportsShadows() { }

	public static bool get_supportsStoreAndResolveAction() { }

	public static bool get_usesLoadStoreActions() { }

	public static bool get_usesReversedZBuffer() { }

	[FreeFunction("ScriptingGraphicsCaps::GetCompatibleFormat")]
	public static GraphicsFormat GetCompatibleFormat(GraphicsFormat format, GraphicsFormatUsage usage) { }

	[FreeFunction("ScriptingGraphicsCaps::GetCopyTextureSupport")]
	private static CopyTextureSupport GetCopyTextureSupport() { }

	[FreeFunction("systeminfo::GetDeviceModel")]
	private static string GetDeviceModel() { }

	private static void GetDeviceModel_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("systeminfo::GetDeviceType")]
	private static DeviceType GetDeviceType() { }

	[FreeFunction("systeminfo::GetDeviceUniqueIdentifier")]
	private static string GetDeviceUniqueIdentifier() { }

	private static void GetDeviceUniqueIdentifier_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("ScriptingGraphicsCaps::GetFoveatedRenderingCaps")]
	private static FoveatedRenderingCaps GetFoveatedRenderingCaps() { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceName")]
	private static string GetGraphicsDeviceName() { }

	private static void GetGraphicsDeviceName_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceType")]
	private static GraphicsDeviceType GetGraphicsDeviceType() { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceVendor")]
	private static string GetGraphicsDeviceVendor() { }

	private static void GetGraphicsDeviceVendor_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsDeviceVendorID")]
	private static int GetGraphicsDeviceVendorID() { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsFormat")]
	public static GraphicsFormat GetGraphicsFormat(DefaultFormat format) { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsMultiThreaded")]
	private static bool GetGraphicsMultiThreaded() { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsShaderLevel")]
	private static int GetGraphicsShaderLevel() { }

	[FreeFunction("ScriptingGraphicsCaps::GetGraphicsUVStartsAtTop")]
	private static bool GetGraphicsUVStartsAtTop() { }

	[FreeFunction("ScriptingGraphicsCaps::GetHDRDisplaySupportFlags")]
	private static HDRDisplaySupportFlags GetHDRDisplaySupportFlags() { }

	[FreeFunction("ScriptingGraphicsCaps::GetMaxRenderTextureSize")]
	private static int GetMaxRenderTextureSize() { }

	[FreeFunction("ScriptingGraphicsCaps::GetMaxTextureSize")]
	private static int GetMaxTextureSize() { }

	[FreeFunction("systeminfo::GetOperatingSystem")]
	private static string GetOperatingSystem() { }

	private static void GetOperatingSystem_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("systeminfo::GetOperatingSystemFamily")]
	private static OperatingSystemFamily GetOperatingSystemFamily() { }

	[FreeFunction("systeminfo::GetProcessorType")]
	private static string GetProcessorType() { }

	private static void GetProcessorType_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("ScriptingGraphicsCaps::GetRenderingThreadingMode")]
	private static RenderingThreadingMode GetRenderingThreadingMode() { }

	[FreeFunction("ScriptingGraphicsCaps::GetRenderTextureSupportedMSAASampleCount")]
	public static int GetRenderTextureSupportedMSAASampleCount(RenderTextureDescriptor desc) { }

	private static int GetRenderTextureSupportedMSAASampleCount_Injected(in RenderTextureDescriptor desc) { }

	[FreeFunction("ScriptingGraphicsCaps::HasHiddenSurfaceRemovalOnGPU")]
	private static bool HasHiddenSurfaceRemovalOnGPU() { }

	[FreeFunction("ScriptingGraphicsCaps::HasRenderTexture")]
	private static bool HasRenderTextureNative(RenderTextureFormat format) { }

	[FreeFunction("ScriptingGraphicsCaps::IsFormatSupported")]
	public static bool IsFormatSupported(GraphicsFormat format, GraphicsFormatUsage usage) { }

	private static bool IsValidEnumValue(Enum value) { }

	[FreeFunction("ScriptingGraphicsCaps::MaxGraphicsBufferSize")]
	private static long MaxGraphicsBufferSize() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportedRenderTargetCount")]
	private static int SupportedRenderTargetCount() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsComputeShaders")]
	private static bool SupportsComputeShaders() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsGPUFence")]
	private static bool SupportsGPUFence() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsIndirectArgumentsBuffer")]
	private static bool SupportsIndirectArgumentsBuffer() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsInstancing")]
	private static bool SupportsInstancing() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampleAutoResolve")]
	private static bool SupportsMultisampleAutoResolve() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampledTextures")]
	private static int SupportsMultisampledTextures() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampleResolveDepth")]
	private static bool SupportsMultisampleResolveDepth() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsMultisampleResolveStencil")]
	private static bool SupportsMultisampleResolveStencil() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsMultiview")]
	private static bool SupportsMultiview() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsRenderTargetArrayIndexFromVertexShader")]
	private static bool SupportsRenderTargetArrayIndexFromVertexShader() { }

	public static bool SupportsRenderTextureFormat(RenderTextureFormat format) { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsShadows")]
	private static bool SupportsShadows() { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsStoreAndResolveAction")]
	private static bool SupportsStoreAndResolveAction() { }

	public static bool SupportsTextureFormat(TextureFormat format) { }

	[FreeFunction("ScriptingGraphicsCaps::SupportsTextureFormat")]
	private static bool SupportsTextureFormatNative(TextureFormat format) { }

	[FreeFunction("ScriptingGraphicsCaps::UsesLoadStoreActions")]
	private static bool UsesLoadStoreActions() { }

	[FreeFunction("ScriptingGraphicsCaps::UsesReversedZBuffer")]
	private static bool UsesReversedZBuffer() { }

}

