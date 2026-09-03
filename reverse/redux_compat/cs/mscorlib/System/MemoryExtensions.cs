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
	public static class MemoryExtensions // TypeDefIndex: 2302
	{
		// Methods
		private static bool IsTypeComparableAsBytes<T>(out ulong size);
	
		// Extension methods
		public static bool Contains(this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType); // 0x0000000181600430-0x0000000181600460
		internal static bool EqualsOrdinal(this ReadOnlySpan<char> span, ReadOnlySpan<char> value); // 0x0000000181600870-0x0000000181600980
		internal static bool EqualsOrdinalIgnoreCase(this ReadOnlySpan<char> span, ReadOnlySpan<char> value); // 0x00000001816007D0-0x0000000181600870
		internal static bool Contains(this ReadOnlySpan<char> source, char value); // 0x0000000181600460-0x00000001816004B0
		public static int IndexOf(this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType); // 0x0000000181600980-0x0000000181600BE0
		public static int ToUpperInvariant(this ReadOnlySpan<char> source, Span<char> destination); // 0x0000000181600BE0-0x0000000181600D80
		public static bool EndsWith(this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType); // 0x00000001816004B0-0x00000001816007D0
		public static Span<T> AsSpan<T>(this T[] array, int start);
		public static ReadOnlySpan<char> AsSpan(this string text); // 0x00000001816002A0-0x0000000181600300
		public static ReadOnlySpan<char> AsSpan(this string text, int start); // 0x00000001816003A0-0x0000000181600430
		public static ReadOnlySpan<char> AsSpan(this string text, int start, int length); // 0x0000000181600300-0x00000001816003A0
		public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span); // 0x0000000181600F30-0x0000000181601070
		public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span); // 0x0000000181600E50-0x0000000181600F30
		public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span); // 0x0000000181600D80-0x0000000181600E50
		public static bool SequenceEqual<T>(this Span<T> span, ReadOnlySpan<T> other)
			where T : IEquatable<T>;
		public static int IndexOf<T>(this ReadOnlySpan<T> span, T value)
			where T : IEquatable<T>;
		public static int IndexOfAny<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> values)
			where T : IEquatable<T>;
		public static bool SequenceEqual<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> other)
			where T : IEquatable<T>;
		public static bool StartsWith<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> value)
			where T : IEquatable<T>;
		public static bool EndsWith<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> value)
			where T : IEquatable<T>;
		public static Span<T> AsSpan<T>(this T[] array);
		public static Span<T> AsSpan<T>(this T[] array, int start, int length);
		public static void CopyTo<T>(this T[] source, Span<T> destination);
	}
}
