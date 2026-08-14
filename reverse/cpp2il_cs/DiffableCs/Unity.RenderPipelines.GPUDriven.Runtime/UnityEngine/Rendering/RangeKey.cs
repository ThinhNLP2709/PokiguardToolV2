namespace UnityEngine.Rendering;

internal struct RangeKey : IEquatable<RangeKey>
{
	public byte layer; //Field offset: 0x0
	public uint renderingLayerMask; //Field offset: 0x4
	public MotionVectorGenerationMode motionMode; //Field offset: 0x8
	public ShadowCastingMode shadowCastingMode; //Field offset: 0xC
	public bool staticShadowCaster; //Field offset: 0x10
	public int rendererPriority; //Field offset: 0x14
	public bool supportsIndirect; //Field offset: 0x18

	public override bool Equals(RangeKey other) { }

	public virtual int GetHashCode() { }

}

