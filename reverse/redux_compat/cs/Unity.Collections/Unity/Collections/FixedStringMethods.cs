/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	[GenerateTestsForBurstCompatibility]
	[GenerateTestsForBurstCompatibility]
	[GenerateTestsForBurstCompatibility]
	public static class FixedStringMethods // TypeDefIndex: 11539
	{
		// Methods
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckSubstringInRange(int strLength, int startIndex, int length); // 0x0000000181C953A0-0x0000000181C95540
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static bool ParseLongInternal<T>(ref ref T fs, ref int offset, out long value)
			where T : struct, INativeList<byte>, IUTF8Bytes;
	
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, Unicode.Rune rune)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, char ch)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError AppendRawByte<T>(this ref ref T fs, byte a)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, Unicode.Rune rune, int count)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, long input)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, int input)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, ulong input)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, uint input)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Append<T>(this ref ref T fs, float input, char decimalSeparator = '.' /* Metadata: 0x006A1BFD */)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError Append<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 input)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static CopyError CopyFrom<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 input)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe FormatError Append<T>(this ref ref T fs, byte* utf8Bytes, int utf8BytesLength)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static FormatError Append<T>(this ref ref T fs, string s)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static CopyError CopyFrom<T>(this ref ref T fs, string s)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static CopyError CopyFromTruncated<T>(this ref ref T fs, string s)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static CopyError CopyFromTruncated<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 input)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[3] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[4] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[5] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[6] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[7] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3, T4>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3, [IsReadOnly] in ref T4 arg4)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes
			where T4 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[8] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3, T4, T5>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3, [IsReadOnly] in ref T4 arg4, [IsReadOnly] in ref T5 arg5)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes
			where T4 : struct, INativeList<byte>, IUTF8Bytes
			where T5 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[9] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3, [IsReadOnly] in ref T4 arg4, [IsReadOnly] in ref T5 arg5, [IsReadOnly] in ref T6 arg6)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes
			where T4 : struct, INativeList<byte>, IUTF8Bytes
			where T5 : struct, INativeList<byte>, IUTF8Bytes
			where T6 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[10] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6, T7>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3, [IsReadOnly] in ref T4 arg4, [IsReadOnly] in ref T5 arg5, [IsReadOnly] in ref T6 arg6, [IsReadOnly] in ref T7 arg7)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes
			where T4 : struct, INativeList<byte>, IUTF8Bytes
			where T5 : struct, INativeList<byte>, IUTF8Bytes
			where T6 : struct, INativeList<byte>, IUTF8Bytes
			where T7 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[11] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6, T7, T8>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3, [IsReadOnly] in ref T4 arg4, [IsReadOnly] in ref T5 arg5, [IsReadOnly] in ref T6 arg6, [IsReadOnly] in ref T7 arg7, [IsReadOnly] in ref T8 arg8)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes
			where T4 : struct, INativeList<byte>, IUTF8Bytes
			where T5 : struct, INativeList<byte>, IUTF8Bytes
			where T6 : struct, INativeList<byte>, IUTF8Bytes
			where T7 : struct, INativeList<byte>, IUTF8Bytes
			where T8 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[12] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static FormatError AppendFormat<T, U, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ref ref T dest, [IsReadOnly] in ref U format, [IsReadOnly] in ref T0 arg0, [IsReadOnly] in ref T1 arg1, [IsReadOnly] in ref T2 arg2, [IsReadOnly] in ref T3 arg3, [IsReadOnly] in ref T4 arg4, [IsReadOnly] in ref T5 arg5, [IsReadOnly] in ref T6 arg6, [IsReadOnly] in ref T7 arg7, [IsReadOnly] in ref T8 arg8, [IsReadOnly] in ref T9 arg9)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes
			where T0 : struct, INativeList<byte>, IUTF8Bytes
			where T1 : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes
			where T3 : struct, INativeList<byte>, IUTF8Bytes
			where T4 : struct, INativeList<byte>, IUTF8Bytes
			where T5 : struct, INativeList<byte>, IUTF8Bytes
			where T6 : struct, INativeList<byte>, IUTF8Bytes
			where T7 : struct, INativeList<byte>, IUTF8Bytes
			where T8 : struct, INativeList<byte>, IUTF8Bytes
			where T9 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static FormatError Append<T>(this ref ref T fs, char a, char b)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static FormatError Append<T>(this ref ref T fs, char a, char b, char c)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static FormatError Append<T>(this ref ref T fs, char a, char b, char c, char d, char e, char f, char g, char h)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static unsafe FormatError AppendScientific<T>(this ref ref T fs, char* source, int sourceLength, int decimalExponent, char decimalSeparator = '.' /* Metadata: 0x006A1BFF */)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static bool Found<T>(this ref ref T fs, ref int offset, char a, char b, char c)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static bool Found<T>(this ref ref T fs, ref int offset, char a, char b, char c, char d, char e, char f, char g, char h)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T Substring<T>(this ref ref T str, int startIndex, int length)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T Substring<T>(this ref ref T str, int startIndex)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static NativeText Substring(this ref NativeText str, int startIndex, int length, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95560-0x0000000181C955E0
		public static NativeText Substring(this ref NativeText str, int startIndex, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95540-0x0000000181C95560
		public static NativeText Substring(this ref NativeText str, int startIndex, int length); // 0x0000000181C955E0-0x0000000181C95670
		public static NativeText Substring(this ref NativeText str, int startIndex); // 0x0000000181C95540-0x0000000181C95560
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static int IndexOf<T>(this ref ref T fs, Unicode.Rune rune)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe int IndexOf<T>(this ref ref T fs, byte* bytes, int bytesLen)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe int IndexOf<T>(this ref ref T fs, byte* bytes, int bytesLen, int startIndex, int distance = 2147483647 /* Metadata: 0x006A1C01 */)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static int IndexOf<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static int IndexOf<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other, int startIndex, int distance = 2147483647 /* Metadata: 0x006A1C02 */)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static bool Contains<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static int LastIndexOf<T>(this ref ref T fs, Unicode.Rune rune)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe int LastIndexOf<T>(this ref ref T fs, byte* bytes, int bytesLen)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe int LastIndexOf<T>(this ref ref T fs, byte* bytes, int bytesLen, int startIndex, int distance = 2147483647 /* Metadata: 0x006A1C03 */)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static int LastIndexOf<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static int LastIndexOf<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other, int startIndex, int distance = 2147483647 /* Metadata: 0x006A1C04 */)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe int CompareTo<T>(this ref ref T fs, byte* bytes, int bytesLen)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static int CompareTo<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static unsafe bool Equals<T>(this ref ref T fs, byte* bytes, int bytesLen)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static bool Equals<T, T2>(this ref ref T fs, [IsReadOnly] in ref T2 other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where T2 : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static Unicode.Rune Peek<T>(this ref ref T fs, int index)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static Unicode.Rune Read<T>(this ref ref T fs, ref int index)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static FormatError Write<T>(this ref ref T fs, ref int index, Unicode.Rune rune)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[ExcludeFromBurstCompatTesting("Returns managed string")]
		public static string ConvertToString<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static int ComputeHashCode<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static int EffectiveSizeOf<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static bool StartsWith<T>(this ref ref T fs, Unicode.Rune rune)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static bool StartsWith<T, U>(this ref ref T fs, [IsReadOnly] in ref U other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static bool EndsWith<T>(this ref ref T fs, Unicode.Rune rune)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(FixedString128Bytes), typeof(FixedString128Bytes) })]
		public static bool EndsWith<T, U>(this ref ref T fs, [IsReadOnly] in ref U other)
			where T : struct, INativeList<byte>, IUTF8Bytes
			where U : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static int TrimStartIndex<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static int TrimStartIndex<T>(this ref ref T fs, ReadOnlySpan<Unicode.Rune> trimRunes)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static int TrimEndIndex<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		internal static int TrimEndIndex<T>(this ref ref T fs, ReadOnlySpan<Unicode.Rune> trimRunes)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T TrimStart<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText TrimStart(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95CB0-0x0000000181C95D40
		public static NativeText TrimStart(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95D40-0x0000000181C95DD0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T TrimStart<T>(this ref ref T fs, ReadOnlySpan<Unicode.Rune> trimRunes)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText TrimStart(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator, ReadOnlySpan<Unicode.Rune> trimRunes); // 0x0000000181C95B70-0x0000000181C95C10
		public static NativeText TrimStart(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator, ReadOnlySpan<Unicode.Rune> trimRunes); // 0x0000000181C95C10-0x0000000181C95CB0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T TrimEnd<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText TrimEnd(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95A60-0x0000000181C95AE0
		public static NativeText TrimEnd(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C959F0-0x0000000181C95A60
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T TrimEnd<T>(this ref ref T fs, ReadOnlySpan<Unicode.Rune> trimRunes)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText TrimEnd(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator, ReadOnlySpan<Unicode.Rune> trimRunes); // 0x0000000181C95AE0-0x0000000181C95B70
		public static NativeText TrimEnd(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator, ReadOnlySpan<Unicode.Rune> trimRunes); // 0x0000000181C95970-0x0000000181C959F0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T Trim<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText Trim(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95F40-0x0000000181C96040
		public static NativeText Trim(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95DD0-0x0000000181C95E80
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T Trim<T>(this ref ref T fs, ReadOnlySpan<Unicode.Rune> trimRunes)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText Trim(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator, ReadOnlySpan<Unicode.Rune> trimRunes); // 0x0000000181C96040-0x0000000181C96150
		public static NativeText Trim(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator, ReadOnlySpan<Unicode.Rune> trimRunes); // 0x0000000181C95E80-0x0000000181C95F40
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T ToLowerAscii<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText ToLowerAscii(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95670-0x0000000181C95740
		public static NativeText ToLowerAscii(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C95740-0x0000000181C957F0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static T ToUpperAscii<T>(this ref ref T fs)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		public static UnsafeText ToUpperAscii(this ref UnsafeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C957F0-0x0000000181C958C0
		public static NativeText ToUpperAscii(this ref NativeText fs, AllocatorManager.AllocatorHandle allocator); // 0x0000000181C958C0-0x0000000181C95970
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static ParseError Parse<T>(this ref ref T fs, ref int offset, ref int output)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static ParseError Parse<T>(this ref ref T fs, ref int offset, ref uint output)
			where T : struct, INativeList<byte>, IUTF8Bytes;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(FixedString128Bytes) })]
		public static ParseError Parse<T>(this ref ref T fs, ref int offset, ref float output, char decimalSeparator = '.' /* Metadata: 0x006A1C05 */)
			where T : struct, INativeList<byte>, IUTF8Bytes;
	}
}
