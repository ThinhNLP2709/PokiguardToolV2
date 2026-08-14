namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
internal struct Spinner
{
	private int m_Lock; //Field offset: 0x0

	internal void Acquire() { }

	internal void Release() { }

	internal bool TryAcquire() { }

	internal bool TryAcquire(bool spin) { }

}

