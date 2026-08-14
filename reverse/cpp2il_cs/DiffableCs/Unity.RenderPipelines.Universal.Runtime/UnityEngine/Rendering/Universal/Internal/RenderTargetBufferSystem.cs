namespace UnityEngine.Rendering.Universal.Internal;

internal sealed class RenderTargetBufferSystem
{
	private struct SwapBuffer
	{
		public RTHandle rtMSAA; //Field offset: 0x0
		public RTHandle rtResolve; //Field offset: 0x8
		public string name; //Field offset: 0x10
		public int msaa; //Field offset: 0x18

	}

	private static bool m_AisBackBuffer; //Field offset: 0x0
	private static RenderTextureDescriptor m_Desc; //Field offset: 0x4
	private SwapBuffer m_A; //Field offset: 0x10
	private SwapBuffer m_B; //Field offset: 0x30
	private FilterMode m_FilterMode; //Field offset: 0x50
	private bool m_AllowMSAA; //Field offset: 0x54

	private SwapBuffer backBuffer
	{
		private get { } //Length: 99
	}

	private SwapBuffer frontBuffer
	{
		private get { } //Length: 99
	}

	private static RenderTargetBufferSystem() { }

	public RenderTargetBufferSystem(string name) { }

	public void Clear() { }

	public void Dispose() { }

	public void EnableMSAA(bool enable) { }

	private SwapBuffer get_backBuffer() { }

	private SwapBuffer get_frontBuffer() { }

	public RTHandle GetBackBuffer(CommandBuffer cmd) { }

	public RTHandle GetBufferA() { }

	public RTHandle GetFrontBuffer(CommandBuffer cmd) { }

	public RTHandle PeekBackBuffer() { }

	private void ReAllocate(CommandBuffer cmd) { }

	public void SetCameraSettings(RenderTextureDescriptor desc, FilterMode filterMode) { }

	public void Swap() { }

}

