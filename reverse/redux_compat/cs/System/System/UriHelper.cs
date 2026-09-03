/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	internal static class UriHelper // TypeDefIndex: 8672
	{
		// Fields
		private static readonly char[] HexUpperChars; // 0x00
	
		// Constructors
		static UriHelper(); // 0x0000000181B58A10-0x0000000181B58AA0
	
		// Methods
		internal static unsafe bool TestForSubPath(char* pMe, ushort meLength, char* pShe, ushort sheLength, bool ignoreCase); // 0x0000000181B57D40-0x0000000181B57ED0
		internal static char[] EscapeString(string input, int start, int end, char[] dest, ref int destPos, bool isUriString, char force1, char force2, char rsvd); // 0x0000000181B56BF0-0x0000000181B57430
		private static unsafe char[] EnsureDestinationSize(char* pStr, char[] dest, int currentInputPos, short charsToAdd, short minReallocateChars, ref int destPos, int prevInputPos); // 0x0000000181B569E0-0x0000000181B56AE0
		internal static char[] UnescapeString(string input, int start, int end, char[] dest, ref int destPosition, char rsvd1, char rsvd2, char rsvd3, UnescapeMode unescapeMode, UriParser syntax, bool isQuery); // 0x0000000181B57ED0-0x0000000181B57FB0
		internal static unsafe char[] UnescapeString(char* pStr, int start, int end, char[] dest, ref int destPosition, char rsvd1, char rsvd2, char rsvd3, UnescapeMode unescapeMode, UriParser syntax, bool isQuery); // 0x0000000181B57FB0-0x0000000181B58A10
		internal static unsafe void MatchUTF8Sequence(char* pDest, char[] dest, ref int destOffset, char[] unescapedChars, int charCount, byte[] bytes, int byteCount, bool isQuery, bool iriParsing); // 0x0000000181B57820-0x0000000181B57D40
		internal static void EscapeAsciiChar(char ch, char[] to, ref int pos); // 0x0000000181B56AE0-0x0000000181B56BF0
		internal static char EscapedAscii(char digit, char next); // 0x0000000181B57430-0x0000000181B574D0
		internal static bool IsNotSafeForUnescape(char ch); // 0x0000000181B57560-0x0000000181B575B0
		private static bool IsReservedUnreservedOrHash(char c); // 0x0000000181B575B0-0x0000000181B576F0
		internal static bool IsUnreserved(char c); // 0x0000000181B576F0-0x0000000181B57820
		internal static bool Is3986Unreserved(char c); // 0x0000000181B574D0-0x0000000181B57560
	}
}
