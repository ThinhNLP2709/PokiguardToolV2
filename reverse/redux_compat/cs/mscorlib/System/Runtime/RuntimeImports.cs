/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime
{
	public static class RuntimeImports // TypeDefIndex: 2868
	{
		// Methods
		internal static void RhZeroMemory(ref byte b, ulong byteLength); // 0x00000001814C6500-0x00000001814C6510
		private static unsafe void ZeroMemory(void* p, uint byteLength); // 0x00000001814C6500-0x00000001814C6510
		internal static unsafe void Memmove(byte* dest, byte* src, uint len); // 0x00000001814C64E0-0x00000001814C64F0
		internal static unsafe void Memmove_wbarrier(byte* dest, byte* src, uint len, IntPtr type_handle); // 0x00000001814C64F0-0x00000001814C6500
		internal static unsafe void _ecvt_s(byte* buffer, int sizeInBytes, double value, int count, int* dec, int* sign); // 0x00000001814C6510-0x00000001814C6520
	}
}
