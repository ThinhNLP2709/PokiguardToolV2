/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public struct Unicode // TypeDefIndex: 11654
	{
		// Fields
		public const int kMaximumValidCodePoint = 1114111; // Metadata: 0x006A1C8C
	
		// Properties
		public static Rune ReplacementCharacter { get; } // 0x0000000181CAA1E0-0x0000000181CAA1F0 
		public static Rune BadRune { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Nested types
		[GenerateTestsForBurstCompatibility]
		public struct Rune // TypeDefIndex: 11655
		{
			// Fields
			public int value; // 0x00
	
			// Constructors
			public Rune(int codepoint); // 0x0000000180732D50-0x0000000180732D60
	
			// Methods
			public static implicit operator Rune(char codepoint); // 0x0000000181565B10-0x0000000181565B20
			public static bool operator ==(Rune lhs, Rune rhs); // 0x0000000180A2DD00-0x0000000180A2DD10
			[ExcludeFromBurstCompatTesting("Takes managed object")]
			public override bool Equals(object obj); // 0x0000000181CA6690-0x0000000181CA6710
			public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
			public static bool operator !=(Rune lhs, Rune rhs); // 0x0000000181CA6840-0x0000000181CA6850
			public static bool IsDigit(Rune r); // 0x0000000181CA6730-0x0000000181CA6740
			internal bool IsAscii(); // 0x0000000181CA6710-0x0000000181CA6720
			internal bool IsLatin1(); // 0x0000000181CA6740-0x0000000181CA6750
			internal bool IsDigit(); // 0x0000000181CA6720-0x0000000181CA6730
			internal bool IsWhiteSpace(); // 0x0000000181CA6750-0x0000000181CA67C0
			internal Rune ToLowerAscii(); // 0x0000000181CA6800-0x0000000181CA6820
			internal Rune ToUpperAscii(); // 0x0000000181CA6820-0x0000000181CA6840
			public int LengthInUtf8Bytes(); // 0x0000000181CA67C0-0x0000000181CA6800
		}
	
		// Methods
		public static bool IsValidCodePoint(int codepoint); // 0x0000000181CA9970-0x0000000181CA9980
		public static bool NotTrailer(byte b); // 0x0000000181CA9980-0x0000000181CA9990
		public static unsafe ConversionError Utf8ToUcs(out Rune rune, byte* buffer, ref int index, int capacity); // 0x0000000181CA9DD0-0x0000000181CAA020
		private static unsafe int FindUtf8CharStartInReverse(byte* ptr, ref int index); // 0x0000000181CA9940-0x0000000181CA9970
		internal static unsafe ConversionError Utf8ToUcsReverse(out Rune rune, byte* buffer, ref int index, int capacity); // 0x0000000181CA9D60-0x0000000181CA9DD0
		private static bool IsLeadingSurrogate(char c); // 0x0000000181560D90-0x0000000181560DB0
		private static bool IsTrailingSurrogate(char c); // 0x0000000181561050-0x0000000181561070
		public static unsafe ConversionError Utf16ToUcs(out Rune rune, char* buffer, ref int index, int capacity); // 0x0000000181CA9B70-0x0000000181CA9C30
		internal static unsafe ConversionError UcsToUcs(out Rune rune, Rune* buffer, ref int index, int capacity); // 0x0000000181CA9990-0x0000000181CA99C0
		public static unsafe ConversionError UcsToUtf8(byte* buffer, ref int index, int capacity, Rune rune); // 0x0000000181CA9A60-0x0000000181CA9B70
		public static unsafe ConversionError UcsToUtf16(char* buffer, ref int index, int capacity, Rune rune); // 0x0000000181CA99C0-0x0000000181CA9A60
		public static unsafe ConversionError Utf16ToUtf8(char* utf16Buffer, int utf16Length, byte* utf8Buffer, out int utf8Length, int utf8Capacity); // 0x0000000181CA9C30-0x0000000181CA9D60
		public static unsafe ConversionError Utf8ToUtf8(byte* srcBuffer, int srcLength, byte* destBuffer, out int destLength, int destCapacity); // 0x0000000181CAA120-0x0000000181CAA1E0
		public static unsafe ConversionError Utf8ToUtf16(byte* utf8Buffer, int utf8Length, char* utf16Buffer, out int utf16Length, int utf16Capacity); // 0x0000000181CAA020-0x0000000181CAA120
		private static unsafe int CountRunes(byte* utf8Buffer, int utf8Length, int maxRunes = 2147483647 /* Metadata: 0x006A1C8B */); // 0x0000000181CA9900-0x0000000181CA9940
	}
}
