namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
[GenerateTestsForBurstCompatibility]
[GenerateTestsForBurstCompatibility]
[GenerateTestsForBurstCompatibility]
public static class FixedStringMethods
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, Rune rune) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static FormatError Append(ref T fs, char a, char b) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	[Extension]
	public static FormatError Append(ref T fs, string s) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, Byte* utf8Bytes, int utf8BytesLength) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static FormatError Append(ref T fs, char a, char b, char c) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, float input, char decimalSeparator = .) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, uint input) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, in T2 input) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, int input) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, long input) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, Rune rune, int count) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static FormatError Append(ref T fs, char a, char b, char c, char d, char e, char f, char g, char h) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, char ch) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Append(ref T fs, ulong input) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static FormatError AppendFormat(ref T dest, in U format, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError AppendRawByte(ref T fs, byte a) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static FormatError AppendScientific(ref T fs, Char* source, int sourceLength, int decimalExponent, char decimalSeparator = .) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	internal static void CheckSubstringInRange(int strLength, int startIndex, int length) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static int CompareTo(ref T fs, in T2 other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int CompareTo(ref T fs, Byte* bytes, int bytesLen) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int ComputeHashCode(ref T fs) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static bool Contains(ref T fs, in T2 other) { }

	[ExcludeFromBurstCompatTesting("Returns managed string")]
	[Extension]
	public static string ConvertToString(ref T fs) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	[Extension]
	public static CopyError CopyFrom(ref T fs, string s) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static CopyError CopyFrom(ref T fs, in T2 input) { }

	[ExcludeFromBurstCompatTesting("Takes managed string")]
	[Extension]
	public static CopyError CopyFromTruncated(ref T fs, string s) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static CopyError CopyFromTruncated(ref T fs, in T2 input) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int EffectiveSizeOf(ref T fs) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static bool EndsWith(ref T fs, Rune rune) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static bool EndsWith(ref T fs, in U other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static bool Equals(ref T fs, in T2 other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static bool Equals(ref T fs, Byte* bytes, int bytesLen) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static bool Found(ref T fs, ref int offset, char a, char b, char c, char d, char e, char f, char g, char h) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static bool Found(ref T fs, ref int offset, char a, char b, char c) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int IndexOf(ref T fs, Rune rune) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int IndexOf(ref T fs, Byte* bytes, int bytesLen) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int IndexOf(ref T fs, Byte* bytes, int bytesLen, int startIndex, int distance = 2147483647) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static int IndexOf(ref T fs, in T2 other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static int IndexOf(ref T fs, in T2 other, int startIndex, int distance = 2147483647) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static int LastIndexOf(ref T fs, in T2 other, int startIndex, int distance = 2147483647) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int LastIndexOf(ref T fs, Byte* bytes, int bytesLen, int startIndex, int distance = 2147483647) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int LastIndexOf(ref T fs, Byte* bytes, int bytesLen) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static int LastIndexOf(ref T fs, Rune rune) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static int LastIndexOf(ref T fs, in T2 other) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static ParseError Parse(ref T fs, ref int offset, ref uint output) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static ParseError Parse(ref T fs, ref int offset, ref int output) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static ParseError Parse(ref T fs, ref int offset, ref float output, char decimalSeparator = .) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static bool ParseLongInternal(ref T fs, ref int offset, out long value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static Rune Peek(ref T fs, int index) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static Rune Read(ref T fs, ref int index) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static bool StartsWith(ref T fs, Rune rune) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes), typeof(FixedString128Bytes)})]
	public static bool StartsWith(ref T fs, in U other) { }

	[Extension]
	public static NativeText Substring(ref NativeText str, int startIndex, int length) { }

	[Extension]
	public static NativeText Substring(ref NativeText str, int startIndex, AllocatorHandle allocator) { }

	[Extension]
	public static NativeText Substring(ref NativeText str, int startIndex, int length, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T Substring(ref T str, int startIndex) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T Substring(ref T str, int startIndex, int length) { }

	[Extension]
	public static NativeText Substring(ref NativeText str, int startIndex) { }

	[Extension]
	public static NativeText ToLowerAscii(ref NativeText fs, AllocatorHandle allocator) { }

	[Extension]
	public static UnsafeText ToLowerAscii(ref UnsafeText fs, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T ToLowerAscii(ref T fs) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T ToUpperAscii(ref T fs) { }

	[Extension]
	public static NativeText ToUpperAscii(ref NativeText fs, AllocatorHandle allocator) { }

	[Extension]
	public static UnsafeText ToUpperAscii(ref UnsafeText fs, AllocatorHandle allocator) { }

	[Extension]
	public static NativeText Trim(ref NativeText fs, AllocatorHandle allocator, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	public static UnsafeText Trim(ref UnsafeText fs, AllocatorHandle allocator, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T Trim(ref T fs, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	public static NativeText Trim(ref NativeText fs, AllocatorHandle allocator) { }

	[Extension]
	public static UnsafeText Trim(ref UnsafeText fs, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T Trim(ref T fs) { }

	[Extension]
	public static UnsafeText TrimEnd(ref UnsafeText fs, AllocatorHandle allocator, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T TrimEnd(ref T fs, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	public static NativeText TrimEnd(ref NativeText fs, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T TrimEnd(ref T fs) { }

	[Extension]
	public static NativeText TrimEnd(ref NativeText fs, AllocatorHandle allocator, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	public static UnsafeText TrimEnd(ref UnsafeText fs, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static int TrimEndIndex(ref T fs) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static int TrimEndIndex(ref T fs, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	public static UnsafeText TrimStart(ref UnsafeText fs, AllocatorHandle allocator, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T TrimStart(ref T fs, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	public static NativeText TrimStart(ref NativeText fs, AllocatorHandle allocator) { }

	[Extension]
	public static UnsafeText TrimStart(ref UnsafeText fs, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static T TrimStart(ref T fs) { }

	[Extension]
	public static NativeText TrimStart(ref NativeText fs, AllocatorHandle allocator, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static int TrimStartIndex(ref T fs, ReadOnlySpan<Rune> trimRunes) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	internal static int TrimStartIndex(ref T fs) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(FixedString128Bytes)})]
	public static FormatError Write(ref T fs, ref int index, Rune rune) { }

}

