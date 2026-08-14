namespace UnityEngine.Rendering.Universal;

[MovedFrom(True, "UnityEngine.Experimental.Rendering.Universal", null, null)]
public class RenderObjectsPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__33_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__33_0(PassData data, RasterGraphContext rgContext) { }

	}

	private class PassData
	{
		internal CustomCameraSettings cameraSettings; //Field offset: 0x10
		internal RenderPassEvent renderPassEvent; //Field offset: 0x18
		internal TextureHandle color; //Field offset: 0x1C
		internal RendererListHandle rendererListHdl; //Field offset: 0x2C
		internal DebugRendererLists debugRendererLists; //Field offset: 0x38
		internal UniversalCameraData cameraData; //Field offset: 0x40
		internal RendererList rendererList; //Field offset: 0x48

		public PassData() { }

	}

	private RenderQueueType renderQueueType; //Field offset: 0xB8
	private FilteringSettings m_FilteringSettings; //Field offset: 0xBC
	private CustomCameraSettings m_CameraSettings; //Field offset: 0xE0
	[CompilerGenerated]
	private Material <overrideMaterial>k__BackingField; //Field offset: 0xE8
	[CompilerGenerated]
	private int <overrideMaterialPassIndex>k__BackingField; //Field offset: 0xF0
	[CompilerGenerated]
	private Shader <overrideShader>k__BackingField; //Field offset: 0xF8
	[CompilerGenerated]
	private int <overrideShaderPassIndex>k__BackingField; //Field offset: 0x100
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0x108
	private PassData m_PassData; //Field offset: 0x110
	private RenderStateBlock m_RenderStateBlock; //Field offset: 0x118

	public Material overrideMaterial
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public int overrideMaterialPassIndex
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public Shader overrideShader
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public int overrideShaderPassIndex
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	internal RenderObjectsPass(URPProfileId profileId, RenderPassEvent renderPassEvent, String[] shaderTags, RenderQueueType renderQueueType, int layerMask, CustomCameraSettings cameraSettings) { }

	public RenderObjectsPass(string profilerTag, RenderPassEvent renderPassEvent, String[] shaderTags, RenderQueueType renderQueueType, int layerMask, CustomCameraSettings cameraSettings) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(PassData passData, RasterCommandBuffer cmd, RendererList rendererList, bool isYFlipped) { }

	[CompilerGenerated]
	public Material get_overrideMaterial() { }

	[CompilerGenerated]
	public int get_overrideMaterialPassIndex() { }

	[CompilerGenerated]
	public Shader get_overrideShader() { }

	[CompilerGenerated]
	public int get_overrideShaderPassIndex() { }

	internal void Init(RenderPassEvent renderPassEvent, String[] shaderTags, RenderQueueType renderQueueType, int layerMask, CustomCameraSettings cameraSettings) { }

	private void InitPassData(UniversalCameraData cameraData, ref PassData passData) { }

	private void InitRendererLists(UniversalRenderingData renderingData, UniversalLightData lightData, ref PassData passData, ScriptableRenderContext context, RenderGraph renderGraph, bool useRenderGraph) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

	[CompilerGenerated]
	public void set_overrideMaterial(Material value) { }

	[CompilerGenerated]
	public void set_overrideMaterialPassIndex(int value) { }

	[CompilerGenerated]
	public void set_overrideShader(Shader value) { }

	[CompilerGenerated]
	public void set_overrideShaderPassIndex(int value) { }

	public void SetDepthState(bool writeEnabled, CompareFunction function = 2) { }

	[Obsolete("Use SetDepthState instead", True)]
	public void SetDetphState(bool writeEnabled, CompareFunction function = 2) { }

	public void SetStencilState(int reference, CompareFunction compareFunction, StencilOp passOp, StencilOp failOp, StencilOp zFailOp) { }

}

