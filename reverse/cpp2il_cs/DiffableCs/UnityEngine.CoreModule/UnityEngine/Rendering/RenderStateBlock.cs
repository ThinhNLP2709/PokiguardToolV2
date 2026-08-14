namespace UnityEngine.Rendering;

public struct RenderStateBlock : IEquatable<RenderStateBlock>
{
	private BlendState m_BlendState; //Field offset: 0x0
	private RasterState m_RasterState; //Field offset: 0x44
	private DepthState m_DepthState; //Field offset: 0x54
	private StencilState m_StencilState; //Field offset: 0x56
	private int m_StencilReference; //Field offset: 0x64
	private RenderStateMask m_Mask; //Field offset: 0x68

	public BlendState blendState
	{
		 set { } //Length: 37
	}

	public DepthState depthState
	{
		 get { } //Length: 7
		 set { } //Length: 5
	}

	public RenderStateMask mask
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public RasterState rasterState
	{
		 set { } //Length: 8
	}

	public int stencilReference
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public StencilState stencilState
	{
		 get { } //Length: 19
		 set { } //Length: 16
	}

	public RenderStateBlock(RenderStateMask mask) { }

	public override bool Equals(RenderStateBlock other) { }

	public virtual bool Equals(object obj) { }

	public DepthState get_depthState() { }

	public RenderStateMask get_mask() { }

	public int get_stencilReference() { }

	public StencilState get_stencilState() { }

	public virtual int GetHashCode() { }

	public void set_blendState(BlendState value) { }

	public void set_depthState(DepthState value) { }

	public void set_mask(RenderStateMask value) { }

	public void set_rasterState(RasterState value) { }

	public void set_stencilReference(int value) { }

	public void set_stencilState(StencilState value) { }

}

