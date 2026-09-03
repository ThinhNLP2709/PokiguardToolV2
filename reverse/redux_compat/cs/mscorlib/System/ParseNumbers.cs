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

namespace System
{
	internal static class ParseNumbers // TypeDefIndex: 2323
	{
		// Methods
		public static long StringToLong(ReadOnlySpan<char> s, int radix, int flags); // 0x0000000181619240-0x0000000181619270
		public static long StringToLong(ReadOnlySpan<char> s, int radix, int flags, ref int currPos); // 0x0000000181618D90-0x0000000181619240
		public static int StringToInt(ReadOnlySpan<char> s, int radix, int flags); // 0x0000000181618810-0x0000000181618840
		public static int StringToInt(ReadOnlySpan<char> s, int radix, int flags, ref int currPos); // 0x0000000181618840-0x0000000181618D90
		public static string IntToString(int n, int radix, int width, char paddingChar, int flags); // 0x0000000181618010-0x0000000181618390
		public static string LongToString(long n, int radix, int width, char paddingChar, int flags); // 0x00000001816183F0-0x0000000181618810
		private static void EatWhiteSpace(ReadOnlySpan<char> s, ref int i); // 0x0000000181617BE0-0x0000000181617C90
		private static long GrabLongs(int radix, ReadOnlySpan<char> s, ref int i, bool isUnsigned); // 0x0000000181617E60-0x0000000181618010
		private static int GrabInts(int radix, ReadOnlySpan<char> s, ref int i, bool isUnsigned); // 0x0000000181617C90-0x0000000181617E60
		private static void ThrowOverflowInt32Exception(); // 0x0000000181619270-0x00000001816192C0
		private static void ThrowOverflowInt64Exception(); // 0x00000001816192C0-0x0000000181619310
		private static void ThrowOverflowUInt32Exception(); // 0x0000000181619310-0x0000000181619360
		private static void ThrowOverflowUInt64Exception(); // 0x0000000181619360-0x00000001816193B0
		private static bool IsDigit(char c, int radix, out int result); // 0x0000000181618390-0x00000001816183F0
	}
}
