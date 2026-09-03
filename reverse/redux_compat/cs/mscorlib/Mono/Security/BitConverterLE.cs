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

namespace Mono.Security
{
	internal sealed class BitConverterLE // TypeDefIndex: 2120
	{
		// Methods
		private static unsafe byte[] GetUIntBytes(byte* bytes); // 0x000000018142DC60-0x000000018142DCE0
		private static unsafe byte[] GetULongBytes(byte* bytes); // 0x000000018142DCE0-0x000000018142DDA0
		internal static byte[] GetBytes(float value); // 0x000000018142DB00-0x000000018142DB90
		internal static byte[] GetBytes(double value); // 0x000000018142DB90-0x000000018142DC60
		private static unsafe void UIntFromBytes(byte* dst, byte[] src, int startIndex); // 0x0000000181401460-0x00000001814014D0
		private static unsafe void ULongFromBytes(byte* dst, byte[] src, int startIndex); // 0x000000018142DE80-0x000000018142DED0
		internal static float ToSingle(byte[] value, int startIndex); // 0x000000018142DE00-0x000000018142DE80
		internal static double ToDouble(byte[] value, int startIndex); // 0x000000018142DDA0-0x000000018142DE00
	}
}
