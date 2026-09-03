/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[ComVisible(true)]
	public static class Buffer // TypeDefIndex: 2412
	{
		// Methods
		internal static bool InternalBlockCopy(Array src, int srcOffsetBytes, Array dst, int dstOffsetBytes, int byteCount); // 0x000000018162E1C0-0x000000018162E1D0
		internal static unsafe int IndexOfByte(byte* src, byte value, int index, int count); // 0x000000018162E110-0x000000018162E1C0
		private static int _ByteLength(Array array); // 0x000000018162E690-0x000000018162E6A0
		internal static unsafe void ZeroMemory(byte* src, long len); // 0x000000018162E670-0x000000018162E690
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal static unsafe void Memcpy(byte* pDest, int destIndex, byte[] src, int srcIndex, int len); // 0x000000018162E4D0-0x000000018162E520
		internal static unsafe void InternalMemcpy(byte* dest, byte* src, int count); // 0x000000018162E1D0-0x000000018162E1E0
		public static int ByteLength(Array array); // 0x000000018162E060-0x000000018162E110
		public static void BlockCopy(Array src, int srcOffset, Array dst, int dstOffset, int count); // 0x000000018162DDD0-0x000000018162E060
		[CLSCompliant(false)]
		public static unsafe void MemoryCopy(void* source, void* destination, long destinationSizeInBytes, long sourceBytesToCopy); // 0x000000018162E550-0x000000018162E670
		internal static unsafe void memcpy4(byte* dest, byte* src, int size); // 0x000000018162E7D0-0x000000018162E870
		internal static unsafe void memcpy2(byte* dest, byte* src, int size); // 0x000000018162E750-0x000000018162E7D0
		private static unsafe void memcpy1(byte* dest, byte* src, int size); // 0x000000018162E6A0-0x000000018162E750
		internal static unsafe void Memcpy(byte* dest, byte* src, int len); // 0x000000018162E1E0-0x000000018162E4D0
		internal static unsafe void Memmove(byte* dest, byte* src, uint len); // 0x000000018162E520-0x000000018162E550
		internal static void Memmove<T>(ref ref T destination, ref ref T source, ulong elementCount);
	}
}
