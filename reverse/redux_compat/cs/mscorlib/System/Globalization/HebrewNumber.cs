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

namespace System.Globalization
{
	internal class HebrewNumber // TypeDefIndex: 3406
	{
		// Fields
		private static readonly HebrewValue[] s_hebrewValues; // 0x00
		private static char s_maxHebrewNumberCh; // 0x08
		private static readonly HS[] s_numberPasingState; // 0x10
	
		// Nested types
		private enum HebrewToken : short // TypeDefIndex: 3407
		{
			Invalid = -1,
			Digit400 = 0,
			Digit200_300 = 1,
			Digit100 = 2,
			Digit10 = 3,
			Digit1 = 4,
			Digit6_7 = 5,
			Digit7 = 6,
			Digit9 = 7,
			SingleQuote = 8,
			DoubleQuote = 9
		}
	
		private struct HebrewValue // TypeDefIndex: 3408
		{
			// Fields
			internal HebrewToken token; // 0x00
			internal short value; // 0x02
	
			// Constructors
			internal HebrewValue(HebrewToken token, short value); // 0x0000000181552300-0x0000000181552310
		}
	
		internal enum HS : sbyte // TypeDefIndex: 3409
		{
			Start = 0,
			S400 = 1,
			S400_400 = 2,
			S400_X00 = 3,
			S400_X0 = 4,
			X00_DQ = 5,
			S400_X00_X0 = 6,
			X0_DQ = 7,
			X = 8,
			X0 = 9,
			X00 = 10,
			S400_DQ = 11,
			S400_400_DQ = 12,
			S400_400_100 = 13,
			S9 = 14,
			X00_S9 = 15,
			S9_DQ = 16,
			END = 100,
			_err = 255
		}
	
		// Constructors
		static HebrewNumber(); // 0x0000000181551ED0-0x0000000181552300
	
		// Methods
		internal static string ToString(int Number); // 0x0000000181551C30-0x0000000181551ED0
		internal static HebrewNumberParsingState ParseByChar(char ch, ref HebrewNumberParsingContext context); // 0x0000000181551AE0-0x0000000181551C30
		internal static bool IsDigit(char ch); // 0x0000000181551A30-0x0000000181551AE0
	}
}
