/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	internal struct Bitwise // TypeDefIndex: 11473
	{
		// Methods
		internal static int AlignDown(int value, int alignPow2); // 0x0000000181C8AC60-0x0000000181C8AC70
		internal static long AlignDown(long value, int alignPow2); // 0x0000000181C8AC50-0x0000000181C8AC60
		internal static int AlignUp(int value, int alignPow2); // 0x0000000181C8AC90-0x0000000181C8ACA0
		internal static long AlignUp(long value, int alignPow2); // 0x0000000181C8AC70-0x0000000181C8AC90
		internal static int FromBool(bool value); // 0x0000000180815D60-0x0000000180815D70
		internal static uint ExtractBits(uint input, int pos, uint mask); // 0x0000000181C8AE50-0x0000000181C8AE60
		internal static uint ReplaceBits(uint input, int pos, uint mask, uint value); // 0x0000000181C8C040-0x0000000181C8C060
		internal static uint SetBits(uint input, int pos, uint mask, bool value); // 0x0000000181C8C060-0x0000000181C8C080
		internal static ulong ExtractBits(ulong input, int pos, ulong mask); // 0x0000000181C8AE40-0x0000000181C8AE50
		internal static ulong ReplaceBits(ulong input, int pos, ulong mask, ulong value); // 0x0000000181C8C010-0x0000000181C8C040
		internal static ulong SetBits(ulong input, int pos, ulong mask, bool value); // 0x0000000181C8C080-0x0000000181C8C0B0
		internal static int lzcnt(byte value); // 0x0000000181C8C2D0-0x0000000181C8C320
		internal static int tzcnt(byte value); // 0x0000000181C8C380-0x0000000181C8C3D0
		internal static int lzcnt(ushort value); // 0x0000000181C8C320-0x0000000181C8C370
		internal static int tzcnt(ushort value); // 0x0000000181C8C3D0-0x0000000181C8C420
		private static unsafe int FindUlong(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8B170-0x0000000181C8B350
		private static unsafe int FindUint(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8AFC0-0x0000000181C8B170
		private static unsafe int FindUshort(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8B600-0x0000000181C8B750
		private static unsafe int FindByte(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8AE60-0x0000000181C8AFC0
		private static unsafe int FindUpto14bits(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8B350-0x0000000181C8B480
		private static ushort sar(ushort val, int shift); // 0x0000000181C8C370-0x0000000181C8C380
		private static unsafe int FindUpto6bits(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8B480-0x0000000181C8B600
		internal static unsafe int FindWithBeginEnd(ulong* ptr, int beginBit, int endBit, int numBits); // 0x0000000181C8B750-0x0000000181C8BF40
		internal static unsafe int Find(ulong* ptr, int pos, int count, int numBits); // 0x0000000181C8BF40-0x0000000181C8BF60
		internal static unsafe bool TestNone(ulong* ptr, int length, int pos, int numBits = 1 /* Metadata: 0x006A1BC3 */); // 0x0000000181C8C220-0x0000000181C8C2D0
		internal static unsafe bool TestAny(ulong* ptr, int length, int pos, int numBits = 1 /* Metadata: 0x006A1BC4 */); // 0x0000000181C8C170-0x0000000181C8C220
		internal static unsafe bool TestAll(ulong* ptr, int length, int pos, int numBits = 1 /* Metadata: 0x006A1BC5 */); // 0x0000000181C8C0B0-0x0000000181C8C170
		internal static unsafe int CountBits(ulong* ptr, int length, int pos, int numBits = 1 /* Metadata: 0x006A1BC6 */); // 0x0000000181C8ACA0-0x0000000181C8AE40
		internal static unsafe bool IsSet(ulong* ptr, int pos); // 0x0000000181C8BFF0-0x0000000181C8C010
		internal static unsafe ulong GetBits(ulong* ptr, int length, int pos, int numBits = 1 /* Metadata: 0x006A1BC7 */); // 0x0000000181C8BF60-0x0000000181C8BFF0
	}
}
