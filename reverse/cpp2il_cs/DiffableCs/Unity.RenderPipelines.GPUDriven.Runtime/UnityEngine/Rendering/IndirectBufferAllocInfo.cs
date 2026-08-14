namespace UnityEngine.Rendering;

internal struct IndirectBufferAllocInfo
{
	public int drawAllocIndex; //Field offset: 0x0
	public int drawCount; //Field offset: 0x4
	public int instanceAllocIndex; //Field offset: 0x8
	public int instanceCount; //Field offset: 0xC

	public int GetExtraDrawInfoSlotIndex() { }

	public bool IsEmpty() { }

	public bool IsWithinLimits(in IndirectBufferLimits limits) { }

}

