/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	internal class DateTimeFormatInfoScanner // TypeDefIndex: 3400
	{
		// Fields
		internal List<string> m_dateWords; // 0x10
		private static Dictionary<string, string> s_knownWords; // 0x00
		private FoundDatePattern _ymdFlags; // 0x18
	
		// Properties
		private static Dictionary<string, string> KnownWords { get; } // 0x00000001815496B0-0x0000000181549AD0 
	
		// Nested types
		private enum FoundDatePattern // TypeDefIndex: 3401
		{
			None = 0,
			FoundYearPatternFlag = 1,
			FoundMonthPatternFlag = 2,
			FoundDayPatternFlag = 4,
			FoundYMDPatternFlag = 7
		}
	
		// Constructors
		public DateTimeFormatInfoScanner(); // 0x0000000181549630-0x00000001815496B0
	
		// Methods
		internal static int SkipWhiteSpacesAndNonLetter(string pattern, int currentIndex); // 0x0000000181549570-0x0000000181549630
		internal void AddDateWordOrPostfix(string formatPostfix, string str); // 0x0000000181548450-0x0000000181548680
		internal int AddDateWords(string pattern, int index, string formatPostfix); // 0x0000000181548680-0x00000001815488A0
		internal static int ScanRepeatChar(string pattern, char ch, int index, out int count); // 0x0000000181549500-0x0000000181549570
		internal void AddIgnorableSymbols(string text); // 0x00000001815488A0-0x00000001815489F0
		internal void ScanDateWord(string pattern); // 0x00000001815492E0-0x0000000181549500
		internal string[] GetDateWordsOfDTFI(DateTimeFormatInfo dtfi); // 0x0000000181548DB0-0x00000001815490A0
		internal static FORMATFLAGS GetFormatFlagGenitiveMonth(string[] monthNames, string[] genitveMonthNames, string[] abbrevMonthNames, string[] genetiveAbbrevMonthNames); // 0x00000001815490A0-0x00000001815491D0
		internal static FORMATFLAGS GetFormatFlagUseSpaceInMonthNames(string[] monthNames, string[] genitveMonthNames, string[] abbrevMonthNames, string[] genetiveAbbrevMonthNames); // 0x0000000181549220-0x00000001815492E0
		internal static FORMATFLAGS GetFormatFlagUseSpaceInDayNames(string[] dayNames, string[] abbrevDayNames); // 0x00000001815491E0-0x0000000181549220
		internal static FORMATFLAGS GetFormatFlagUseHebrewCalendar(int calID); // 0x00000001815491D0-0x00000001815491E0
		private static bool EqualStringArrays(string[] array1, string[] array2); // 0x0000000181548D00-0x0000000181548DB0
		private static bool ArrayElementsHaveSpace(string[] array); // 0x0000000181548C40-0x0000000181548D00
		private static bool ArrayElementsBeginWithDigit(string[] array); // 0x00000001815489F0-0x0000000181548C40
	}
}
