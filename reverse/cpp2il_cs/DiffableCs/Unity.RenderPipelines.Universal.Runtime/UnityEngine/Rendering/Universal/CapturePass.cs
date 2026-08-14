namespace UnityEngine.Rendering.Universal;

internal class CapturePass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> <>9__4_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__4_0(UnsafePassData data, UnsafeGraphContext unsafeContext) { }

	}

	private class UnsafePassData
	{
		internal TextureHandle source; //Field offset: 0x10
		public IEnumerator<Action`2<RenderTargetIdentifier, CommandBuffer>> captureActions; //Field offset: 0x20

		public UnsafePassData() { }

	}

	private RTHandle m_CameraColorHandle; //Field offset: 0xB8

	public CapturePass(RenderPassEvent evt) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

}

