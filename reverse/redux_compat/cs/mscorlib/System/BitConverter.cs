/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Buffers;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	public static class BitConverter // TypeDefIndex: 2220
	{
		// Fields
		[Intrinsic]
		public static readonly bool IsLittleEndian; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2221
		{
			// Fields
			public static readonly __c __9; // 0x00
			[TupleElementNames(new string[3] {"value", "startIndex", "length" })]
			public static SpanAction<char, ValueTuple<byte[], int, int>> __9__38_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181577620-0x0000000181577690
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ToString_b__38_0(Span<char> dst, [TupleElementNames(new string[3] {"value", "startIndex", "length" })] ValueTuple<byte[], int, int> state); // 0x00000001815772C0-0x00000001815774C0
		}
	
		// Constructors
		static BitConverter(); // 0x000000018155E070-0x000000018155E0B0
	
		// Methods
		public static byte[] GetBytes(bool value); // 0x000000018155DA20-0x000000018155DA80
		public static byte[] GetBytes(char value); // 0x000000018155D840-0x000000018155D8A0
		public static byte[] GetBytes(short value); // 0x000000018155D7E0-0x000000018155D840
		public static byte[] GetBytes(int value); // 0x000000018155DAE0-0x000000018155DB40
		public static byte[] GetBytes(long value); // 0x000000018155D9C0-0x000000018155DA20
		[CLSCompliant(false)]
		public static byte[] GetBytes(ushort value); // 0x000000018155D8A0-0x000000018155D900
		[CLSCompliant(false)]
		public static byte[] GetBytes(uint value); // 0x000000018155D960-0x000000018155D9C0
		[CLSCompliant(false)]
		public static bool TryWriteBytes(Span<byte> destination, uint value); // 0x000000018155E030-0x000000018155E070
		[CLSCompliant(false)]
		public static byte[] GetBytes(ulong value); // 0x000000018155D900-0x000000018155D960
		public static byte[] GetBytes(float value); // 0x000000018155DA80-0x000000018155DAE0
		public static byte[] GetBytes(double value); // 0x000000018155DB40-0x000000018155DBA0
		public static short ToInt16(byte[] value, int startIndex); // 0x000000018155DBC0-0x000000018155DC40
		public static int ToInt32(byte[] value, int startIndex); // 0x000000018155DC40-0x000000018155DCC0
		public static long ToInt64(byte[] value, int startIndex); // 0x000000018155DCC0-0x000000018155DD40
		[CLSCompliant(false)]
		public static ushort ToUInt16(byte[] value, int startIndex); // 0x000000018155DBC0-0x000000018155DC40
		[CLSCompliant(false)]
		public static uint ToUInt32(byte[] value, int startIndex); // 0x000000018155DC40-0x000000018155DCC0
		[CLSCompliant(false)]
		public static ulong ToUInt64(byte[] value, int startIndex); // 0x000000018155DCC0-0x000000018155DD40
		public static string ToString(byte[] value, int startIndex, int length); // 0x000000018155DD70-0x000000018155E030
		public static string ToString(byte[] value); // 0x000000018155DD40-0x000000018155DD70
		public static long DoubleToInt64Bits(double value); // 0x000000018155D7D0-0x000000018155D7E0
		public static int SingleToInt32Bits(float value); // 0x000000018155DBB0-0x000000018155DBC0
		public static float Int32BitsToSingle(int value); // 0x000000018155DBA0-0x000000018155DBB0
	}
}
