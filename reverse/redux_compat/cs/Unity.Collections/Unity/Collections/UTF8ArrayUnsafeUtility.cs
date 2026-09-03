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
	public static class UTF8ArrayUnsafeUtility // TypeDefIndex: 11648
	{
		// Nested types
		internal struct Comparison // TypeDefIndex: 11649
		{
			// Fields
			public bool terminates; // 0x00
			public int result; // 0x04
	
			// Constructors
			public Comparison(Unicode.Rune runeA, ConversionError errorA, Unicode.Rune runeB, ConversionError errorB); // 0x0000000181CA1190-0x0000000181CA11C0
		}
	
		// Methods
		public static unsafe CopyError Copy(byte* dest, out int destLength, int destUTF8MaxLengthInBytes, char* src, int srcLength); // 0x0000000181CA8F80-0x0000000181CA8FC0
		public static unsafe CopyError Copy(byte* dest, out ushort destLength, ushort destUTF8MaxLengthInBytes, char* src, int srcLength); // 0x0000000181CA91C0-0x0000000181CA9220
		public static unsafe CopyError Copy(byte* dest, out int destLength, int destUTF8MaxLengthInBytes, byte* src, int srcLength); // 0x0000000181CA90E0-0x0000000181CA91C0
		public static unsafe CopyError Copy(byte* dest, out ushort destLength, ushort destUTF8MaxLengthInBytes, byte* src, ushort srcLength); // 0x0000000181CA9000-0x0000000181CA90E0
		public static unsafe CopyError Copy(char* dest, out int destLength, int destUCS2MaxLengthInChars, byte* src, int srcLength); // 0x0000000181CA8FC0-0x0000000181CA9000
		public static unsafe CopyError Copy(char* dest, out ushort destLength, ushort destUCS2MaxLengthInChars, byte* src, ushort srcLength); // 0x0000000181CA9220-0x0000000181CA9280
		public static unsafe FormatError AppendUTF8Bytes(byte* dest, ref int destLength, int destCapacity, byte* src, int srcLength); // 0x0000000181CA8D70-0x0000000181CA8DD0
		public static unsafe CopyError Append(byte* dest, ref ushort destLength, ushort destUTF8MaxLengthInBytes, byte* src, ushort srcLength); // 0x0000000181CA8E90-0x0000000181CA8F80
		public static unsafe CopyError Append(byte* dest, ref ushort destLength, ushort destUTF8MaxLengthInBytes, char* src, int srcLength); // 0x0000000181CA8DD0-0x0000000181CA8E30
		public static unsafe CopyError Append(char* dest, ref ushort destLength, ushort destUCS2MaxLengthInChars, byte* src, ushort srcLength); // 0x0000000181CA8E30-0x0000000181CA8E90
		public static unsafe int StrCmp(byte* utf8BufferA, int utf8LengthInBytesA, byte* utf8BufferB, int utf8LengthInBytesB); // 0x0000000181CA9840-0x0000000181CA9900
		internal static unsafe int StrCmp(byte* utf8BufferA, int utf8LengthInBytesA, Unicode.Rune* runeBufferB, int lengthInRunesB); // 0x0000000181CA9780-0x0000000181CA9840
		public static unsafe int StrCmp(char* utf16BufferA, int utf16LengthInCharsA, char* utf16BufferB, int utf16LengthInCharsB); // 0x0000000181CA95E0-0x0000000181CA9780
		public static unsafe bool EqualsUTF8Bytes(byte* aBytes, int aLength, byte* bBytes, int bLength); // 0x0000000181CA9280-0x0000000181CA9360
		public static unsafe int StrCmp(byte* utf8Buffer, int utf8LengthInBytes, char* utf16Buffer, int utf16LengthInChars); // 0x0000000181CA94A0-0x0000000181CA95E0
		public static unsafe int StrCmp(char* utf16Buffer, int utf16LengthInChars, byte* utf8Buffer, int utf8LengthInBytes); // 0x0000000181CA9360-0x0000000181CA94A0
	}
}
