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
	public static class CharUnicodeInfo // TypeDefIndex: 3389
	{
		// Properties
		private static ReadOnlySpan<byte> CategoryLevel1Index { get; } // 0x0000000181542B80-0x0000000181542BC0 
		private static ReadOnlySpan<byte> CategoryLevel2Index { get; } // 0x0000000181542BC0-0x0000000181542C00 
		private static ReadOnlySpan<byte> CategoryLevel3Index { get; } // 0x0000000181542C00-0x0000000181542C40 
		private static ReadOnlySpan<byte> CategoriesValue { get; } // 0x0000000181542B40-0x0000000181542B80 
	
		// Methods
		internal static int InternalConvertToUtf32(string s, int index); // 0x0000000181542630-0x00000001815426D0
		internal static int InternalConvertToUtf32(string s, int index, out int charLength); // 0x00000001815426D0-0x0000000181542770
		public static UnicodeCategory GetUnicodeCategory(char ch); // 0x0000000181542620-0x0000000181542630
		public static UnicodeCategory GetUnicodeCategory(string s, int index); // 0x00000001815424F0-0x0000000181542620
		public static UnicodeCategory GetUnicodeCategory(int codePoint); // 0x00000001815423F0-0x00000001815424F0
		internal static byte InternalGetCategoryValue(int ch, int offset); // 0x0000000181542770-0x0000000181542880
		internal static UnicodeCategory InternalGetUnicodeCategory(string value, int index); // 0x0000000181542880-0x0000000181542910
		internal static UnicodeCategory InternalGetUnicodeCategory(string str, int index, out int charLength); // 0x0000000181542910-0x00000001815429C0
		internal static bool IsCombiningCategory(UnicodeCategory uc); // 0x00000001815429C0-0x00000001815429E0
		internal static bool IsWhiteSpace(string s, int index); // 0x0000000181542A00-0x0000000181542B40
		internal static bool IsWhiteSpace(char c); // 0x00000001815429E0-0x0000000181542A00
	}
}
