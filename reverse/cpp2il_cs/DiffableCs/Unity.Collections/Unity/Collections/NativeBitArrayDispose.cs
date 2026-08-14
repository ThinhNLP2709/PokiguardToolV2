namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
[NativeContainer]
internal struct NativeBitArrayDispose
{
	[NativeDisableUnsafePtrRestriction]
	public UnsafeBitArray* m_BitArrayData; //Field offset: 0x0
	public AllocatorHandle m_Allocator; //Field offset: 0x8

	public void Dispose() { }

}

