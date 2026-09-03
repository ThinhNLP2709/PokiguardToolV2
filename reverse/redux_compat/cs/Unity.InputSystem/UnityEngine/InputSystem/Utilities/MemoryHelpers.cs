/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	internal static class MemoryHelpers // TypeDefIndex: 6609
	{
		// Nested types
		public struct BitRegion // TypeDefIndex: 6610
		{
			// Fields
			public uint bitOffset; // 0x00
			public uint sizeInBits; // 0x04
	
			// Properties
			public bool isEmpty { get; } // 0x0000000181CF8440-0x0000000181CF8450 
	
			// Constructors
			public BitRegion(uint bitOffset, uint sizeInBits); // 0x0000000180C55C70-0x0000000180C55C80
			public BitRegion(uint byteOffset, uint bitOffset, uint sizeInBits); // 0x0000000181CF8430-0x0000000181CF8440
	
			// Methods
			public BitRegion Overlap(BitRegion other); // 0x0000000181CF8380-0x0000000181CF8430
		}
	
		// Methods
		public static unsafe bool Compare(void* ptr1, void* ptr2, BitRegion region); // 0x0000000181CF8CA0-0x0000000181CF8D20
		public static uint ComputeFollowingByteOffset(uint byteOffset, uint sizeInBits); // 0x0000000181CF8D20-0x0000000181CF8D40
		public static unsafe void WriteSingleBit(void* ptr, uint bitOffset, bool value); // 0x0000000181CF9770-0x0000000181CF97A0
		public static unsafe bool ReadSingleBit(void* ptr, uint bitOffset); // 0x0000000181CF9400-0x0000000181CF9430
		public static unsafe void MemCpyBitRegion(void* destination, void* source, uint bitOffset, uint bitCount); // 0x0000000181CF8EC0-0x0000000181CF8FC0
		public static unsafe bool MemCmpBitRegion(void* ptr1, void* ptr2, uint bitOffset, uint bitCount, void* mask = null); // 0x0000000181CF8D40-0x0000000181CF8EC0
		public static unsafe void MemSet(void* destination, int numBytes, byte value); // 0x0000000181CF90C0-0x0000000181CF9190
		public static unsafe void MemCpyMasked(void* destination, void* source, int numBytes, void* mask); // 0x0000000181CF8FC0-0x0000000181CF90C0
		public static unsafe uint ReadMultipleBitsAsUInt(void* ptr, uint bitOffset, uint bitCount); // 0x0000000181CF9230-0x0000000181CF9400
		public static unsafe void WriteUIntAsMultipleBits(void* ptr, uint bitOffset, uint bitCount, uint value); // 0x0000000181CF97A0-0x0000000181CF99A0
		public static unsafe int ReadTwosComplementMultipleBitsAsInt(void* ptr, uint bitOffset, uint bitCount); // 0x0000000181CF9430-0x0000000181CF9440
		public static unsafe void WriteIntAsTwosComplementMultipleBits(void* ptr, uint bitOffset, uint bitCount, int value); // 0x0000000181CF9700-0x0000000181CF9710
		public static unsafe int ReadExcessKMultipleBitsAsInt(void* ptr, uint bitOffset, uint bitCount); // 0x0000000181CF9190-0x0000000181CF91C0
		public static unsafe void WriteIntAsExcessKMultipleBits(void* ptr, uint bitOffset, uint bitCount, int value); // 0x0000000181CF96D0-0x0000000181CF9700
		public static unsafe float ReadMultipleBitsAsNormalizedUInt(void* ptr, uint bitOffset, uint bitCount); // 0x0000000181CF91C0-0x0000000181CF9230
		public static unsafe void WriteNormalizedUIntAsMultipleBits(void* ptr, uint bitOffset, uint bitCount, float value); // 0x0000000181CF9710-0x0000000181CF9770
		public static unsafe void SetBitsInBuffer(void* buffer, int byteOffset, int bitOffset, int sizeInBits, bool value); // 0x0000000181CF9440-0x0000000181CF96D0
		public static void Swap<TValue>(ref ref TValue a, ref ref TValue b);
		public static uint AlignNatural(uint offset, uint sizeInBytes); // 0x0000000181CF8C20-0x0000000181CF8CA0
	}
}
