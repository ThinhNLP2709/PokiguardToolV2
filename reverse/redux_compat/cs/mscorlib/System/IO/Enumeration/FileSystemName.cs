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

namespace System.IO.Enumeration
{
	public static class FileSystemName // TypeDefIndex: 3725
	{
		// Fields
		private static readonly char[] s_wildcardChars; // 0x00
		private static readonly char[] s_simpleWildcardChars; // 0x08
	
		// Constructors
		static FileSystemName(); // 0x00000001815DB610-0x00000001815DB710
	
		// Methods
		public static string TranslateWin32Expression(string expression); // 0x00000001815DB370-0x00000001815DB610
		public static bool MatchesWin32Expression(ReadOnlySpan<char> expression, ReadOnlySpan<char> name, bool ignoreCase = true /* Metadata: 0x0064F123 */); // 0x00000001815DB2E0-0x00000001815DB370
		public static bool MatchesSimpleExpression(ReadOnlySpan<char> expression, ReadOnlySpan<char> name, bool ignoreCase = true /* Metadata: 0x0064F124 */); // 0x00000001815DB250-0x00000001815DB2E0
		private static bool MatchPattern(ReadOnlySpan<char> expression, ReadOnlySpan<char> name, bool ignoreCase, bool useExtendedWildcards); // 0x00000001815DAA30-0x00000001815DB250
	}
}
