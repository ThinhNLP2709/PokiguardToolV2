namespace UnityEngine.Rendering;

public struct RenderTargetBinding
{
	private RenderTargetIdentifier[] m_ColorRenderTargets; //Field offset: 0x0
	private RenderTargetIdentifier m_DepthRenderTarget; //Field offset: 0x8
	private RenderBufferLoadAction[] m_ColorLoadActions; //Field offset: 0x30
	private RenderBufferStoreAction[] m_ColorStoreActions; //Field offset: 0x38
	private RenderBufferLoadAction m_DepthLoadAction; //Field offset: 0x40
	private RenderBufferStoreAction m_DepthStoreAction; //Field offset: 0x44
	private RenderTargetFlags m_Flags; //Field offset: 0x48

	public RenderBufferLoadAction[] colorLoadActions
	{
		 get { } //Length: 7
	}

	public RenderTargetIdentifier[] colorRenderTargets
	{
		 get { } //Length: 6
	}

	public RenderBufferStoreAction[] colorStoreActions
	{
		 get { } //Length: 7
	}

	public RenderBufferLoadAction depthLoadAction
	{
		 get { } //Length: 6
	}

	public RenderTargetIdentifier depthRenderTarget
	{
		 get { } //Length: 29
	}

	public RenderBufferStoreAction depthStoreAction
	{
		 get { } //Length: 6
	}

	public RenderTargetFlags flags
	{
		 get { } //Length: 6
	}

	public RenderBufferLoadAction[] get_colorLoadActions() { }

	public RenderTargetIdentifier[] get_colorRenderTargets() { }

	public RenderBufferStoreAction[] get_colorStoreActions() { }

	public RenderBufferLoadAction get_depthLoadAction() { }

	public RenderTargetIdentifier get_depthRenderTarget() { }

	public RenderBufferStoreAction get_depthStoreAction() { }

	public RenderTargetFlags get_flags() { }

}

