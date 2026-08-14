namespace UnityEngine.Experimental.Rendering;

public static class XRSystem
{
	[CompilerGenerated]
	private struct <>c__DisplayClass44_0
	{
		public Camera camera; //Field offset: 0x0

	}

	private static XRLayoutStack s_Layout; //Field offset: 0x0
	private static Func<XRPassCreateInfo, XRPass> s_PassAllocator; //Field offset: 0x8
	private static List<XRDisplaySubsystem> s_DisplayList; //Field offset: 0x10
	private static XRDisplaySubsystem s_Display; //Field offset: 0x18
	private static MSAASamples s_MSAASamples; //Field offset: 0x20
	private static float s_OcclusionMeshScaling; //Field offset: 0x24
	private static Material s_OcclusionMeshMaterial; //Field offset: 0x28
	private static Material s_MirrorViewMaterial; //Field offset: 0x30
	private static Action<XRLayout, Camera> s_LayoutOverride; //Field offset: 0x38
	public static readonly XRPass emptyPass; //Field offset: 0x40
	[CompilerGenerated]
	private static bool <singlePassAllowed>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private static FoveatedRenderingCaps <foveatedRenderingCaps>k__BackingField; //Field offset: 0x4C
	[CompilerGenerated]
	private static bool <dumpDebugInfo>k__BackingField; //Field offset: 0x50

	public static bool displayActive
	{
		 get { } //Length: 134
	}

	public static bool dumpDebugInfo
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		 set { } //Length: 84
	}

	public static FoveatedRenderingCaps foveatedRenderingCaps
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		 set { } //Length: 83
	}

	public static bool isHDRDisplayOutputActive
	{
		 get { } //Length: 183
	}

	public static bool singlePassAllowed
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		 set { } //Length: 84
	}

	private static XRSystem() { }

	[CompilerGenerated]
	internal static void <CreateDefaultLayout>g__AddViewToPass|44_0(XRPass xrPass, XRRenderPass renderPass, int renderParamIndex, ref <>c__DisplayClass44_0 unnamed_param_3) { }

	private static XRPassCreateInfo BuildPass(XRRenderPass xrRenderPass, ScriptableCullingParameters cullingParameters, XRLayout layout) { }

	private static XRView BuildView(XRRenderPass renderPass, XRRenderParameter renderParameter) { }

	private static bool CanUseSinglePass(Camera camera, XRRenderPass renderPass) { }

	internal static void CreateDefaultLayout(Camera camera, XRLayout layout) { }

	public static void Dispose() { }

	public static void EndLayout() { }

	public static bool get_displayActive() { }

	[CompilerGenerated]
	public static bool get_dumpDebugInfo() { }

	[CompilerGenerated]
	public static FoveatedRenderingCaps get_foveatedRenderingCaps() { }

	public static bool get_isHDRDisplayOutputActive() { }

	[CompilerGenerated]
	public static bool get_singlePassAllowed() { }

	public static XRDisplaySubsystem GetActiveDisplay() { }

	public static MSAASamples GetDisplayMSAASamples() { }

	internal static int GetMirrorViewMode() { }

	internal static float GetOcclusionMeshScale() { }

	public static float GetRenderViewportScale() { }

	public static void Initialize(Func<XRPassCreateInfo, XRPass> passAllocator, Shader occlusionMeshPS, Shader mirrorViewPS) { }

	public static XRLayout NewLayout() { }

	internal static void ReconfigurePass(XRPass xrPass, Camera camera) { }

	private static void RefreshDeviceInfo() { }

	public static void RenderMirrorView(CommandBuffer cmd, Camera camera) { }

	[CompilerGenerated]
	public static void set_dumpDebugInfo(bool value) { }

	[CompilerGenerated]
	public static void set_foveatedRenderingCaps(FoveatedRenderingCaps value) { }

	[CompilerGenerated]
	public static void set_singlePassAllowed(bool value) { }

	public static void SetDisplayMSAASamples(MSAASamples msaaSamples) { }

	internal static void SetDisplayZRange(float zNear, float zFar) { }

	private static void SetLayoutOverride(Action<XRLayout, Camera> action) { }

	internal static void SetMirrorViewMode(int mirrorBlitMode) { }

	internal static void SetOcclusionMeshScale(float occlusionMeshScale) { }

	public static void SetRenderScale(float renderScale) { }

	private static RenderTextureDescriptor XrRenderTextureDescToUnityRenderTextureDesc(RenderTextureDescriptor xrDesc) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSplashScreen (3))]
	private static void XRSystemInit() { }

}

