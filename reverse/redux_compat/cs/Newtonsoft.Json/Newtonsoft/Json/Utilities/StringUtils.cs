/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class StringUtils // TypeDefIndex: 10184
	{
		// Fields
		public const string CarriageReturnLineFeed = "\r\n"; // Metadata: 0x006A0D70
		public const string Empty = ""; // Metadata: 0x006A0D73
		public const char CarriageReturn = '\x000d'; // Metadata: 0x006A0D74
		public const char LineFeed = '\x000a'; // Metadata: 0x006A0D76
		public const char Tab = '\x0009'; // Metadata: 0x006A0D78
	
		// Nested types
		[NullableContext(0)]
		private enum SeparatedCaseState // TypeDefIndex: 10185
		{
			Start = 0,
			Lower = 1,
			Upper = 2,
			NewWord = 3
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0<TSource> // TypeDefIndex: 10186
		{
			// Fields
			[Nullable(new byte[3] {0, 0, 1 })]
			public Func<TSource, string> valueSelector;
			[Nullable(0)]
			public string testValue;
	
			// Constructors
			public __c__DisplayClass14_0();
	
			// Methods
			[NullableContext(0)]
			internal bool _ForgivingCaseSensitiveFind_b__0(TSource s);
			[NullableContext(0)]
			internal bool _ForgivingCaseSensitiveFind_b__1(TSource s);
		}
	
		// Methods
		[NullableContext(2)]
		public static bool IsNullOrEmpty([NotNullWhen(false)] string value); // 0x000000018171BD50-0x000000018171BD60
		public static bool IsWhiteSpace(string s); // 0x000000018171BD60-0x000000018171BE30
		public static StringWriter CreateStringWriter(int capacity); // 0x000000018171B470-0x000000018171B510
		public static void ToCharAsUnicode(char c, char[] buffer); // 0x000000018171C010-0x000000018171C0C0
		public static string ToCamelCase(string s); // 0x000000018171BE90-0x000000018171C010
		private static char ToLower(char c); // 0x000000018171C0D0-0x000000018171C130
		public static string ToSnakeCase(string s); // 0x000000018171C420-0x000000018171C430
		public static string ToKebabCase(string s); // 0x000000018171C0C0-0x000000018171C0D0
		private static string ToSeparatedCase(string s, char separator); // 0x000000018171C130-0x000000018171C420
		public static bool IsHighSurrogate(char c); // 0x000000018171BCF0-0x000000018171BD20
		public static bool IsLowSurrogate(char c); // 0x000000018171BD20-0x000000018171BD50
		public static int IndexOf(string s, char c); // 0x000000018171BCD0-0x000000018171BCF0
		public static string Replace(string s, string oldValue, string newValue); // 0x000000018171BE30-0x000000018171BE50
	
		// Extension methods
		public static string FormatWith(this string format, IFormatProvider provider, [Nullable(2)] object arg0); // 0x000000018171BA10-0x000000018171BB40
		public static string FormatWith(this string format, IFormatProvider provider, [Nullable(2)] object arg0, [Nullable(2)] object arg1); // 0x000000018171BB40-0x000000018171BCD0
		public static string FormatWith(this string format, IFormatProvider provider, [Nullable(2)] object arg0, [Nullable(2)] object arg1, [Nullable(2)] object arg2); // 0x000000018171B830-0x000000018171BA10
		[NullableContext(2)]
		public static string FormatWith([Nullable(1)] this string format, [Nullable(1)] IFormatProvider provider, object arg0, object arg1, object arg2, object arg3); // 0x000000018171B600-0x000000018171B830
		private static string FormatWith(this string format, IFormatProvider provider, params [Nullable(new byte[2] {1, 2 })] object[] args); // 0x000000018171B550-0x000000018171B600
		public static TSource ForgivingCaseSensitiveFind<TSource>(this IEnumerable<TSource> source, Func<TSource, string> valueSelector, string testValue);
		public static bool StartsWith(this string source, char value); // 0x000000018171BE50-0x000000018171BE90
		public static bool EndsWith(this string source, char value); // 0x000000018171B510-0x000000018171B550
		public static string Trim(this string s, int start, int length); // 0x000000018171C430-0x000000018171C660
	}
}
