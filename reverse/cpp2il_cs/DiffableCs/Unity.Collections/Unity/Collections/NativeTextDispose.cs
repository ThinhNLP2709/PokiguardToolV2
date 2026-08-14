namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
[NativeContainer]
internal struct NativeTextDispose
{
	[NativeDisableUnsafePtrRestriction]
	public UnsafeText* m_TextData; //Field offset: 0x0

	public void Dispose() { }

}

