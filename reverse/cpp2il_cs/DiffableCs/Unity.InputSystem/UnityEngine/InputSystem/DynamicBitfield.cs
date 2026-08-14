namespace UnityEngine.InputSystem;

internal struct DynamicBitfield
{
	public InlinedArray<UInt64> array; //Field offset: 0x0
	public int length; //Field offset: 0x18

	public bool AnyBitIsSet() { }

	private static int BitCountToULongCount(int bitCount) { }

	public void ClearBit(int bitIndex) { }

	public void SetBit(int bitIndex) { }

	public void SetLength(int newLength) { }

	public bool TestBit(int bitIndex) { }

}

