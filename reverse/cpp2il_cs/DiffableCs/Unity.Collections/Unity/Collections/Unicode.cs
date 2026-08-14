namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
public struct Unicode
{
	[GenerateTestsForBurstCompatibility]
	internal struct Rune
	{
		public int value; //Field offset: 0x0

		public Rune(int codepoint) { }

		[ExcludeFromBurstCompatTesting("Takes managed object")]
		public virtual bool Equals(object obj) { }

		public virtual int GetHashCode() { }

		internal bool IsAscii() { }

		public static bool IsDigit(Rune r) { }

		internal bool IsDigit() { }

		internal bool IsLatin1() { }

		internal bool IsWhiteSpace() { }

		public int LengthInUtf8Bytes() { }

		public static bool op_Equality(Rune lhs, Rune rhs) { }

		public static Rune op_Implicit(char codepoint) { }

		public static bool op_Inequality(Rune lhs, Rune rhs) { }

		internal Rune ToLowerAscii() { }

		internal Rune ToUpperAscii() { }

	}

	public const int kMaximumValidCodePoint = 1114111; //Field offset: 0x0

	public static Rune BadRune
	{
		 get { } //Length: 3
	}

	public static Rune ReplacementCharacter
	{
		 get { } //Length: 6
	}

	private static int CountRunes(Byte* utf8Buffer, int utf8Length, int maxRunes = 2147483647) { }

	private static int FindUtf8CharStartInReverse(Byte* ptr, ref int index) { }

	public static Rune get_BadRune() { }

	public static Rune get_ReplacementCharacter() { }

	private static bool IsLeadingSurrogate(char c) { }

	private static bool IsTrailingSurrogate(char c) { }

	public static bool IsValidCodePoint(int codepoint) { }

	public static bool NotTrailer(byte b) { }

	internal static ConversionError UcsToUcs(out Rune rune, Rune* buffer, ref int index, int capacity) { }

	public static ConversionError UcsToUtf16(Char* buffer, ref int index, int capacity, Rune rune) { }

	public static ConversionError UcsToUtf8(Byte* buffer, ref int index, int capacity, Rune rune) { }

	public static ConversionError Utf16ToUcs(out Rune rune, Char* buffer, ref int index, int capacity) { }

	public static ConversionError Utf16ToUtf8(Char* utf16Buffer, int utf16Length, Byte* utf8Buffer, out int utf8Length, int utf8Capacity) { }

	public static ConversionError Utf8ToUcs(out Rune rune, Byte* buffer, ref int index, int capacity) { }

	internal static ConversionError Utf8ToUcsReverse(out Rune rune, Byte* buffer, ref int index, int capacity) { }

	public static ConversionError Utf8ToUtf16(Byte* utf8Buffer, int utf8Length, Char* utf16Buffer, out int utf16Length, int utf16Capacity) { }

	public static ConversionError Utf8ToUtf8(Byte* srcBuffer, int srcLength, Byte* destBuffer, out int destLength, int destCapacity) { }

}

