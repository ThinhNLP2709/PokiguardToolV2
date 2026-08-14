namespace UnityEngine.Rendering;

public struct RenderTargetBlendState : IEquatable<RenderTargetBlendState>
{
	private byte m_WriteMask; //Field offset: 0x0
	private byte m_SourceColorBlendMode; //Field offset: 0x1
	private byte m_DestinationColorBlendMode; //Field offset: 0x2
	private byte m_SourceAlphaBlendMode; //Field offset: 0x3
	private byte m_DestinationAlphaBlendMode; //Field offset: 0x4
	private byte m_ColorBlendOperation; //Field offset: 0x5
	private byte m_AlphaBlendOperation; //Field offset: 0x6
	private byte m_Padding; //Field offset: 0x7

	public static RenderTargetBlendState defaultValue
	{
		 get { } //Length: 15
	}

	public RenderTargetBlendState(ColorWriteMask writeMask = 15, BlendMode sourceColorBlendMode = 1, BlendMode destinationColorBlendMode = 0, BlendMode sourceAlphaBlendMode = 1, BlendMode destinationAlphaBlendMode = 0, BlendOp colorBlendOperation = 0, BlendOp alphaBlendOperation = 0) { }

	public override bool Equals(RenderTargetBlendState other) { }

	public virtual bool Equals(object obj) { }

	public static RenderTargetBlendState get_defaultValue() { }

	public virtual int GetHashCode() { }

}

