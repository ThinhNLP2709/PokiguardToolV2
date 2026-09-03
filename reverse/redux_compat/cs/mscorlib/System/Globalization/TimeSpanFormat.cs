/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	internal static class TimeSpanFormat // TypeDefIndex: 3412
	{
		// Fields
		internal static readonly FormatLiterals PositiveInvariantFormatLiterals; // 0x00
		internal static readonly FormatLiterals NegativeInvariantFormatLiterals; // 0x28
	
		// Nested types
		internal enum Pattern // TypeDefIndex: 3413
		{
			None = 0,
			Minimum = 1,
			Full = 2
		}
	
		internal struct FormatLiterals // TypeDefIndex: 3414
		{
			// Fields
			internal string AppCompatLiteral; // 0x00
			internal int dd; // 0x08
			internal int hh; // 0x0C
			internal int mm; // 0x10
			internal int ss; // 0x14
			internal int ff; // 0x18
			private string[] _literals; // 0x20
	
			// Properties
			internal string Start { get; } // 0x00000001815518B0-0x00000001815518E0 
			internal string DayHourSep { get; } // 0x00000001815517C0-0x00000001815517F0 
			internal string HourMinuteSep { get; } // 0x0000000181551820-0x0000000181551850 
			internal string MinuteSecondSep { get; } // 0x0000000181551850-0x0000000181551880 
			internal string SecondFractionSep { get; } // 0x0000000181551880-0x00000001815518B0 
			internal string End { get; } // 0x00000001815517F0-0x0000000181551820 
	
			// Methods
			internal static FormatLiterals InitInvariant(bool isNegative); // 0x00000001815511A0-0x00000001815513F0
			internal void Init(ReadOnlySpan<char> format, bool useInvariantFieldLengths); // 0x00000001815513F0-0x00000001815517C0
		}
	
		// Constructors
		static TimeSpanFormat(); // 0x00000001815539F0-0x0000000181553AB0
	
		// Methods
		private static void AppendNonNegativeInt32(StringBuilder sb, int n, int digits); // 0x0000000181552690-0x0000000181552780
		internal static string Format(TimeSpan value, string format, IFormatProvider formatProvider); // 0x0000000181553830-0x00000001815538F0
		internal static bool TryFormat(TimeSpan value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider); // 0x00000001815538F0-0x00000001815539F0
		private static StringBuilder FormatToBuilder(TimeSpan value, ReadOnlySpan<char> format, IFormatProvider formatProvider); // 0x0000000181553570-0x0000000181553830
		private static StringBuilder FormatStandard(TimeSpan value, bool isInvariant, ReadOnlySpan<char> format, Pattern pattern); // 0x0000000181553020-0x0000000181553570
		private static StringBuilder FormatCustomized(TimeSpan value, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, StringBuilder result); // 0x0000000181552780-0x0000000181553020
	}
}
