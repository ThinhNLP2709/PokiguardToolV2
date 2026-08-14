namespace UnityEngine.Rendering.RenderGraphModule;

internal struct RenderGraphLogIndent : IDisposable
{
	private int m_Indentation; //Field offset: 0x0
	private RenderGraphLogger m_Logger; //Field offset: 0x8
	private bool m_Disposed; //Field offset: 0x10

	public RenderGraphLogIndent(RenderGraphLogger logger, int indentation = 1) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

}

