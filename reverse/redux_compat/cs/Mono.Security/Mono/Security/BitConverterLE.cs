/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security
{
	internal sealed class BitConverterLE // TypeDefIndex: 13810
	{
		// Methods
		private static unsafe byte[] GetUIntBytes(byte* bytes); // 0x0000000181401260-0x00000001814012E0
		private static unsafe byte[] GetULongBytes(byte* bytes); // 0x00000001814012E0-0x00000001814013A0
		internal static byte[] GetBytes(int value); // 0x00000001814011D0-0x0000000181401260
		internal static byte[] GetBytes(long value); // 0x0000000181401100-0x00000001814011D0
		private static unsafe void UShortFromBytes(byte* dst, byte[] src, int startIndex); // 0x00000001814014D0-0x0000000181401510
		private static unsafe void UIntFromBytes(byte* dst, byte[] src, int startIndex); // 0x0000000181401460-0x00000001814014D0
		internal static int ToInt32(byte[] value, int startIndex); // 0x00000001814013A0-0x0000000181401410
		internal static ushort ToUInt16(byte[] value, int startIndex); // 0x0000000181401410-0x0000000181401460
		internal static uint ToUInt32(byte[] value, int startIndex); // 0x00000001814013A0-0x0000000181401410
	}
}
