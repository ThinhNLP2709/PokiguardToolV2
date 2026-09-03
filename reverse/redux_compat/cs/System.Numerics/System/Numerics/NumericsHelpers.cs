/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 44: System.Numerics.dll - Assembly: System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 15302-15314

namespace System.Numerics
{
	internal static class NumericsHelpers // TypeDefIndex: 15310
	{
		// Methods
		public static void GetDoubleParts(double dbl, out int sign, out int exp, out ulong man, out bool fFinite); // 0x000000018193C910-0x000000018193C9A0
		public static double GetDoubleFromParts(int sign, int exp, ulong man); // 0x000000018193C830-0x000000018193C910
		public static void DangerousMakeTwosComplement(uint[] d); // 0x000000018193C790-0x000000018193C830
		public static ulong MakeUlong(uint uHi, uint uLo); // 0x000000018193C9A0-0x000000018193C9B0
		public static uint Abs(int a); // 0x000000018193C740-0x000000018193C750
		public static uint CombineHash(uint u1, uint u2); // 0x000000018193C780-0x000000018193C790
		public static int CombineHash(int n1, int n2); // 0x000000018193C780-0x000000018193C790
		public static int CbitHighZero(uint u); // 0x000000018192F570-0x000000018192F5E0
		public static int CbitHighZero(ulong uu); // 0x000000018193C750-0x000000018193C780
	}
}
