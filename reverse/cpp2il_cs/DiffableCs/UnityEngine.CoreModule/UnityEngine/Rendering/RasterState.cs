namespace UnityEngine.Rendering;

public struct RasterState : IEquatable<RasterState>
{
	public static readonly RasterState defaultValue; //Field offset: 0x0
	private CullMode m_CullingMode; //Field offset: 0x0
	private int m_OffsetUnits; //Field offset: 0x4
	private float m_OffsetFactor; //Field offset: 0x8
	private byte m_DepthClip; //Field offset: 0xC
	private byte m_Conservative; //Field offset: 0xD
	private byte m_Padding1; //Field offset: 0xE
	private byte m_Padding2; //Field offset: 0xF

	private static RasterState() { }

	public RasterState(CullMode cullingMode = 2, int offsetUnits = 0, float offsetFactor = 0, bool depthClip = true) { }

	public override bool Equals(RasterState other) { }

	public virtual bool Equals(object obj) { }

	public virtual int GetHashCode() { }

}

