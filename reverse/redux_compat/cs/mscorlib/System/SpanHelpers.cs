/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal static class SpanHelpers // TypeDefIndex: 2336
	{
		// Methods
		public static int IndexOfAny(ref byte searchSpace, int searchSpaceLength, ref byte value, int valueLength); // 0x000000018161C660-0x000000018161C6E0
		public static int IndexOf(ref byte searchSpace, byte value, int length); // 0x000000018161CF20-0x000000018161D1C0
		public static bool SequenceEqual(ref byte first, ref byte second, ulong length); // 0x000000018161DC80-0x000000018161DDE0
		public static int SequenceCompareTo(ref char first, int firstLength, ref char second, int secondLength); // 0x000000018161D8F0-0x000000018161DC80
		public static int IndexOf(ref char searchSpace, char value, int length); // 0x000000018161CAD0-0x000000018161CF20
		public static int LastIndexOf(ref char searchSpace, char value, int length); // 0x000000018161D1C0-0x000000018161D5E0
		private static int LocateFirstFoundChar(Vector<ushort> match); // 0x000000018161D600-0x000000018161D780
		private static int LocateFirstFoundChar(ulong match); // 0x000000018161D5E0-0x000000018161D600
		private static int LocateLastFoundChar(Vector<ushort> match); // 0x000000018161D780-0x000000018161D8D0
		private static int LocateLastFoundChar(ulong match); // 0x000000018161D8D0-0x000000018161D8F0
		public static int IndexOf<T>(ref ref T searchSpace, T value, int length)
			where T : IEquatable<T>;
		public static int IndexOfAny<T>(ref ref T searchSpace, int searchSpaceLength, ref ref T value, int valueLength)
			where T : IEquatable<T>;
		public static bool SequenceEqual<T>(ref ref T first, ref ref T second, int length)
			where T : IEquatable<T>;
		public static int IndexOfCultureHelper(ReadOnlySpan<char> span, ReadOnlySpan<char> value, CompareInfo compareInfo); // 0x000000018161C6E0-0x000000018161C820
		public static int IndexOfCultureIgnoreCaseHelper(ReadOnlySpan<char> span, ReadOnlySpan<char> value, CompareInfo compareInfo); // 0x000000018161C820-0x000000018161C960
		public static int IndexOfOrdinalHelper(ReadOnlySpan<char> span, ReadOnlySpan<char> value, bool ignoreCase); // 0x000000018161C960-0x000000018161CAD0
		public static bool EndsWithCultureHelper(ReadOnlySpan<char> span, ReadOnlySpan<char> value, CompareInfo compareInfo); // 0x000000018161C200-0x000000018161C3C0
		public static bool EndsWithCultureIgnoreCaseHelper(ReadOnlySpan<char> span, ReadOnlySpan<char> value, CompareInfo compareInfo); // 0x000000018161C3C0-0x000000018161C5A0
		public static bool EndsWithOrdinalIgnoreCaseHelper(ReadOnlySpan<char> span, ReadOnlySpan<char> value); // 0x000000018161C5A0-0x000000018161C660
		public static void ClearWithoutReferences(ref byte b, ulong byteLength); // 0x000000018161BE50-0x000000018161C200
		public static void ClearWithReferences(ref IntPtr ip, ulong pointerSizeLength); // 0x000000018161BD20-0x000000018161BE50
	}
}
