namespace UnityEngine.Rendering.Universal;

[DisallowMultipleRendererFeature("Screen Space Shadows")]
[SupportedOnRenderer(typeof(UniversalRendererData))]
[Tooltip("Screen Space Shadows")]
internal class ScreenSpaceShadows : ScriptableRendererFeature
{
	private class ScreenSpaceShadowsPass : ScriptableRenderPass
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static BaseRenderFunc<PassData, RasterGraphContext> <>9__11_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal void <RecordRenderGraph>b__11_0(PassData data, RasterGraphContext rgContext) { }

		}

		private class PassData
		{
			internal TextureHandle target; //Field offset: 0x10
			internal Material material; //Field offset: 0x20
			internal int shadowmapID; //Field offset: 0x28

			public PassData() { }

		}

		private Material m_Material; //Field offset: 0xB8
		private ScreenSpaceShadowsSettings m_CurrentSettings; //Field offset: 0xC0
		private RTHandle m_RenderTarget; //Field offset: 0xC8
		private int m_ScreenSpaceShadowmapTextureID; //Field offset: 0xD0
		private PassData m_PassData; //Field offset: 0xD8

		internal ScreenSpaceShadowsPass() { }

		public void Dispose() { }

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
		public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

		private static void ExecutePass(RasterCommandBuffer cmd, PassData data, RTHandle target) { }

		private void InitPassData(ref PassData passData) { }

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
		public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

		public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

		internal bool Setup(ScreenSpaceShadowsSettings featureSettings, Material material) { }

	}

	private class ScreenSpaceShadowsPostPass : ScriptableRenderPass
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static BaseRenderFunc<PassData, RasterGraphContext> <>9__6_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal void <RecordRenderGraph>b__6_0(PassData data, RasterGraphContext rgContext) { }

		}

		public class PassData
		{
			internal ScreenSpaceShadowsPostPass pass; //Field offset: 0x10
			internal UniversalShadowData shadowData; //Field offset: 0x18

			public PassData() { }

		}

		private static readonly RTHandle k_CurrentActive; //Field offset: 0x0

		private static ScreenSpaceShadowsPostPass() { }

		internal ScreenSpaceShadowsPostPass() { }

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
		public virtual void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) { }

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
		public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

		private static void ExecutePass(RasterCommandBuffer cmd, UniversalShadowData shadowData) { }

		public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

	}

	private const string k_ShaderName = "Hidden/Universal Render Pipeline/ScreenSpaceShadows"; //Field offset: 0x0
	[HideInInspector]
	[SerializeField]
	private Shader m_Shader; //Field offset: 0x20
	[SerializeField]
	private ScreenSpaceShadowsSettings m_Settings; //Field offset: 0x28
	private Material m_Material; //Field offset: 0x30
	private ScreenSpaceShadowsPass m_SSShadowsPass; //Field offset: 0x38
	private ScreenSpaceShadowsPostPass m_SSShadowsPostPass; //Field offset: 0x40

	public ScreenSpaceShadows() { }

	public virtual void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) { }

	public virtual void Create() { }

	protected virtual void Dispose(bool disposing) { }

	private bool LoadMaterial() { }

}

