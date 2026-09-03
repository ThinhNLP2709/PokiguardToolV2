/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct __DTString // TypeDefIndex: 2255
	{
		// Fields
		internal ReadOnlySpan<char> Value; // 0x00
		internal int Index; // 0x10
		internal char m_current; // 0x14
		private CompareInfo m_info; // 0x18
		private bool m_checkDigitToken; // 0x20
		private static readonly char[] WhiteSpaceChecks; // 0x00
	
		// Properties
		internal int Length { get; } // 0x0000000180732D20-0x0000000180732D30 
		internal CompareInfo CompareInfo { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		internal __DTString(ReadOnlySpan<char> str, DateTimeFormatInfo dtfi, bool checkDigitToken); // 0x0000000181610110-0x00000001816101F0
		internal __DTString(ReadOnlySpan<char> str, DateTimeFormatInfo dtfi); // 0x00000001816101F0-0x0000000181610570
		static __DTString(); // 0x0000000181610090-0x0000000181610110
	
		// Methods
		internal bool GetNext(); // 0x000000018160EB80-0x000000018160EC00
		internal bool AtEnd(); // 0x000000018160E9A0-0x000000018160EA00
		internal bool Advance(int count); // 0x000000018160E920-0x000000018160E9A0
		internal void GetRegularToken(out TokenType tokenType, out int tokenValue, DateTimeFormatInfo dtfi); // 0x000000018160EC00-0x000000018160EE90
		internal TokenType GetSeparatorToken(DateTimeFormatInfo dtfi, out int indexBeforeSeparator, out char charBeforeSeparator); // 0x000000018160EF50-0x000000018160F100
		internal bool MatchSpecifiedWord(string target); // 0x000000018160F350-0x000000018160F450
		internal bool MatchSpecifiedWords(string target, bool checkWordBoundary, ref int matchLength); // 0x000000018160F450-0x000000018160F870
		internal bool Match(string str); // 0x000000018160F870-0x000000018160F980
		internal bool Match(char ch); // 0x000000018160F980-0x000000018160FA20
		internal int MatchLongestWords(string[] words, ref int maxMatchStrLen); // 0x000000018160F250-0x000000018160F350
		internal int GetRepeatCount(); // 0x000000018160EE90-0x000000018160EF50
		internal bool GetNextDigit(); // 0x000000018160EAD0-0x000000018160EB80
		internal char GetChar(); // 0x000000018160EA80-0x000000018160EAA0
		internal int GetDigit(); // 0x000000018160EAA0-0x000000018160EAD0
		internal void SkipWhiteSpaces(); // 0x000000018160FEE0-0x000000018160FFA0
		internal bool SkipWhiteSpaceCurrent(); // 0x000000018160FE20-0x000000018160FEE0
		internal void TrimTail(); // 0x000000018160FFA0-0x0000000181610090
		internal void RemoveTrailingInQuoteSpaces(); // 0x000000018160FC40-0x000000018160FE20
		internal void RemoveLeadingInQuoteSpaces(); // 0x000000018160FA20-0x000000018160FC40
		internal DTSubString GetSubString(); // 0x000000018160F100-0x000000018160F250
		internal void ConsumeSubString(DTSubString sub); // 0x000000018160EA00-0x000000018160EA80
	}
}
