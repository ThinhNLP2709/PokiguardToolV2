namespace UnityEngine.Rendering.Universal;

internal class InvokeOnRenderObjectCallbackPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, UnsafeGraphContext> <>9__3_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__3_0(PassData data, UnsafeGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle colorTarget; //Field offset: 0x10
		internal TextureHandle depthTarget; //Field offset: 0x20

		public PassData() { }

	}


	public InvokeOnRenderObjectCallbackPass(RenderPassEvent evt) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	internal void Render(RenderGraph renderGraph, TextureHandle colorTarget, TextureHandle depthTarget) { }

}

