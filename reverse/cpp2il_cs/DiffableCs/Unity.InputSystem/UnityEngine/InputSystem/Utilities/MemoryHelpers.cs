namespace UnityEngine.InputSystem.Utilities;

internal static class MemoryHelpers
{
	internal struct BitRegion
	{
		public uint bitOffset; //Field offset: 0x0
		public uint sizeInBits; //Field offset: 0x4

		public bool isEmpty
		{
			 get { } //Length: 8
		}

		public BitRegion(uint bitOffset, uint sizeInBits) { }

		public BitRegion(uint byteOffset, uint bitOffset, uint sizeInBits) { }

		public bool get_isEmpty() { }

		public BitRegion Overlap(BitRegion other) { }

	}


	public static uint AlignNatural(uint offset, uint sizeInBytes) { }

	public static bool Compare(Void* ptr1, Void* ptr2, BitRegion region) { }

	public static uint ComputeFollowingByteOffset(uint byteOffset, uint sizeInBits) { }

	public static bool MemCmpBitRegion(Void* ptr1, Void* ptr2, uint bitOffset, uint bitCount, Void* mask = null) { }

	public static void MemCpyBitRegion(Void* destination, Void* source, uint bitOffset, uint bitCount) { }

	public static void MemCpyMasked(Void* destination, Void* source, int numBytes, Void* mask) { }

	public static void MemSet(Void* destination, int numBytes, byte value) { }

	public static int ReadExcessKMultipleBitsAsInt(Void* ptr, uint bitOffset, uint bitCount) { }

	public static float ReadMultipleBitsAsNormalizedUInt(Void* ptr, uint bitOffset, uint bitCount) { }

	public static uint ReadMultipleBitsAsUInt(Void* ptr, uint bitOffset, uint bitCount) { }

	public static bool ReadSingleBit(Void* ptr, uint bitOffset) { }

	public static int ReadTwosComplementMultipleBitsAsInt(Void* ptr, uint bitOffset, uint bitCount) { }

	public static void SetBitsInBuffer(Void* buffer, int byteOffset, int bitOffset, int sizeInBits, bool value) { }

	public static void Swap(ref TValue a, ref TValue b) { }

	public static void WriteIntAsExcessKMultipleBits(Void* ptr, uint bitOffset, uint bitCount, int value) { }

	public static void WriteIntAsTwosComplementMultipleBits(Void* ptr, uint bitOffset, uint bitCount, int value) { }

	public static void WriteNormalizedUIntAsMultipleBits(Void* ptr, uint bitOffset, uint bitCount, float value) { }

	public static void WriteSingleBit(Void* ptr, uint bitOffset, bool value) { }

	public static void WriteUIntAsMultipleBits(Void* ptr, uint bitOffset, uint bitCount, uint value) { }

}

