//Type is in global namespace

public class FullScreenPassRendererFeature : ScriptableRendererFeature, ISerializationCallbackReceiver
{
	public class FullScreenRenderPass : ScriptableRenderPass
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static BaseRenderFunc<CopyPassData, RasterGraphContext> <>9__14_0; //Field offset: 0x8
			public static BaseRenderFunc<MainPassData, RasterGraphContext> <>9__14_1; //Field offset: 0x10

			private static <>c() { }

			public <>c() { }

			internal void <RecordRenderGraph>b__14_0(CopyPassData data, RasterGraphContext rgContext) { }

			internal void <RecordRenderGraph>b__14_1(MainPassData data, RasterGraphContext rgContext) { }

		}

		private class CopyPassData
		{
			internal TextureHandle inputTexture; //Field offset: 0x10

			public CopyPassData() { }

		}

		private class MainPassData
		{
			internal Material material; //Field offset: 0x10
			internal int passIndex; //Field offset: 0x18
			internal TextureHandle inputTexture; //Field offset: 0x1C

			public MainPassData() { }

		}

		private static MaterialPropertyBlock s_SharedPropertyBlock; //Field offset: 0x0
		private Material m_Material; //Field offset: 0xB8
		private int m_PassIndex; //Field offset: 0xC0
		private bool m_FetchActiveColor; //Field offset: 0xC4
		private bool m_BindDepthStencilAttachment; //Field offset: 0xC5
		private RTHandle m_CopiedColor; //Field offset: 0xC8

		private static FullScreenRenderPass() { }

		public FullScreenRenderPass(string passName) { }

		public void Dispose() { }

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
		public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

		private static void ExecuteCopyColorPass(RasterCommandBuffer cmd, RTHandle sourceTexture) { }

		private static void ExecuteMainPass(RasterCommandBuffer cmd, RTHandle sourceTexture, Material material, int passIndex) { }

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
		public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

		internal void ReAllocate(RenderTextureDescriptor desc) { }

		public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

		public void SetupMembers(Material material, int passIndex, bool fetchActiveColor, bool bindDepthStencilAttachment) { }

	}

	internal enum InjectionPoint
	{
		BeforeRenderingTransparents = 450,
		BeforeRenderingPostProcessing = 550,
		AfterRenderingPostProcessing = 600,
	}

	private enum Version
	{
		Uninitialised = -1,
		Initial = 0,
		AddFetchColorBufferCheckbox = 1,
		Count = 2,
		Latest = 1,
	}

	public InjectionPoint injectionPoint; //Field offset: 0x20
	public bool fetchColorBuffer; //Field offset: 0x24
	public ScriptableRenderPassInput requirements; //Field offset: 0x28
	public Material passMaterial; //Field offset: 0x30
	public int passIndex; //Field offset: 0x38
	public bool bindDepthStencilAttachment; //Field offset: 0x3C
	private FullScreenRenderPass m_FullScreenPass; //Field offset: 0x40
	[HideInInspector]
	[SerializeField]
	private Version m_Version; //Field offset: 0x48

	public FullScreenPassRendererFeature() { }

	public virtual void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) { }

	public virtual void Create() { }

	protected virtual void Dispose(bool disposing) { }

	internal virtual bool RequireRenderingLayers(bool isDeferred, bool needsGBufferAccurateNormals, out Event atEvent, out MaskSize maskSize) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

	private void UpgradeIfNeeded() { }

}

