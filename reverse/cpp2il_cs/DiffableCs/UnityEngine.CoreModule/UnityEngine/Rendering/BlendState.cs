namespace UnityEngine.Rendering;

public struct BlendState : IEquatable<BlendState>
{
	private RenderTargetBlendState m_BlendState0; //Field offset: 0x0
	private RenderTargetBlendState m_BlendState1; //Field offset: 0x8
	private RenderTargetBlendState m_BlendState2; //Field offset: 0x10
	private RenderTargetBlendState m_BlendState3; //Field offset: 0x18
	private RenderTargetBlendState m_BlendState4; //Field offset: 0x20
	private RenderTargetBlendState m_BlendState5; //Field offset: 0x28
	private RenderTargetBlendState m_BlendState6; //Field offset: 0x30
	private RenderTargetBlendState m_BlendState7; //Field offset: 0x38
	private byte m_SeparateMRTBlendStates; //Field offset: 0x40
	private byte m_AlphaToMask; //Field offset: 0x41
	private short m_Padding; //Field offset: 0x42

	public RenderTargetBlendState blendState0
	{
		 set { } //Length: 4
	}

	public static BlendState defaultValue
	{
		 get { } //Length: 125
	}

	public BlendState(bool separateMRTBlend = false, bool alphaToMask = false) { }

	public override bool Equals(BlendState other) { }

	public virtual bool Equals(object obj) { }

	public static BlendState get_defaultValue() { }

	public virtual int GetHashCode() { }

	public void set_blendState0(RenderTargetBlendState value) { }

}

