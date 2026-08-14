namespace UnityEngine.Rendering.Universal;

internal class TransparentSettingsPass : ScriptableRenderPass
{
	private bool m_shouldReceiveShadows; //Field offset: 0xB8

	public TransparentSettingsPass(RenderPassEvent evt, bool shadowReceiveSupported) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	public static void ExecutePass(RasterCommandBuffer cmd, bool shouldReceiveShadows) { }

	public bool Setup() { }

}

