namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Camera/GraphicsSettings.h")]
[StaticAccessor("GetGraphicsSettings()", StaticAccessorType::Dot (0))]
public sealed class GraphicsSettings : object
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal RenderPipelineGlobalSettings <.cctor>b__93_0() { }

	}

	private static Lazy<RenderPipelineGlobalSettings> s_CurrentRenderPipelineGlobalSettings; //Field offset: 0x0

	public static RenderPipelineAsset currentRenderPipeline
	{
		 get { } //Length: 147
	}

	public static Type currentRenderPipelineAssetType
	{
		 get { } //Length: 318
	}

	[NativeName("CurrentRenderPipeline")]
	private static ScriptableObject INTERNAL_currentRenderPipeline
	{
		private get { } //Length: 117
	}

	public static bool isScriptableRenderPipelineEnabled
	{
		 get { } //Length: 224
	}

	public static bool lightsUseColorTemperature
	{
		 set { } //Length: 51
	}

	public static bool lightsUseLinearIntensity
	{
		 get { } //Length: 42
		 set { } //Length: 51
	}

	public static bool useScriptableRenderPipelineBatching
	{
		 set { } //Length: 51
	}

	private static GraphicsSettings() { }

	public static RenderPipelineAsset get_currentRenderPipeline() { }

	public static Type get_currentRenderPipelineAssetType() { }

	private static ScriptableObject get_INTERNAL_currentRenderPipeline() { }

	private static IntPtr get_INTERNAL_currentRenderPipeline_Injected() { }

	public static bool get_isScriptableRenderPipelineEnabled() { }

	public static bool get_lightsUseLinearIntensity() { }

	[RequiredByNativeCode]
	[VisibleToOtherModules]
	internal static Material GetDefaultMaterial(DefaultMaterialType type) { }

	[RequiredByNativeCode]
	[VisibleToOtherModules]
	internal static Shader GetDefaultShader(DefaultShaderType type) { }

	public static T GetRenderPipelineSettings() { }

	public static RenderPipelineGlobalSettings GetSettingsForRenderPipeline() { }

	public static bool HasShaderDefine(GraphicsTier tier, BuiltinShaderDefine defineHash) { }

	public static bool HasShaderDefine(BuiltinShaderDefine defineHash) { }

	private static RenderPipelineGlobalSettings Internal_GetCurrentRenderPipelineGlobalSettings() { }

	[NativeName("GetSettingsForRenderPipeline")]
	private static object Internal_GetSettingsForRenderPipeline(string renderpipelineName) { }

	private static IntPtr Internal_GetSettingsForRenderPipeline_Injected(ref ManagedSpanWrapper renderpipelineName) { }

	public static void set_lightsUseColorTemperature(bool value) { }

	public static void set_lightsUseLinearIntensity(bool value) { }

	public static void set_useScriptableRenderPipelineBatching(bool value) { }

	public static bool TryGetCurrentRenderPipelineGlobalSettings(out RenderPipelineGlobalSettings asset) { }

	public static bool TryGetRenderPipelineSettings(out T settings) { }

}

