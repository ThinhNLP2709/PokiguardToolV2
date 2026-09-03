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

namespace System.Text
{
	[Serializable]
	public sealed class UTF32Encoding : Encoding // TypeDefIndex: 2720
	{
		// Fields
		internal static readonly UTF32Encoding s_default; // 0x00
		internal static readonly UTF32Encoding s_bigEndianDefault; // 0x08
		private static readonly byte[] s_bigEndianPreamble; // 0x10
		private static readonly byte[] s_littleEndianPreamble; // 0x18
		private bool _emitUTF32ByteOrderMark; // 0x38
		private bool _isThrowException; // 0x39
		private bool _bigEndian; // 0x3A
	
		// Properties
		public override ReadOnlySpan<byte> Preamble { get; } // 0x000000018146E860-0x000000018146E9D0 
	
		// Nested types
		[Serializable]
		private sealed class UTF32Decoder : DecoderNLS // TypeDefIndex: 2721
		{
			// Fields
			internal int iChar; // 0x30
			internal int readByteCount; // 0x34
	
			// Properties
			internal override bool HasState { get; } // 0x0000000180D0DE70-0x0000000180D0DE80 
	
			// Constructors
			public UTF32Decoder(UTF32Encoding encoding); // 0x00000001814610F0-0x0000000181461100
	
			// Methods
			public override void Reset(); // 0x000000018146BC40-0x000000018146BC70
		}
	
		// Constructors
		public UTF32Encoding(); // 0x000000018146E770-0x000000018146E7A0
		public UTF32Encoding(bool bigEndian, bool byteOrderMark); // 0x000000018146E810-0x000000018146E860
		public UTF32Encoding(bool bigEndian, bool byteOrderMark, bool throwOnInvalidCharacters); // 0x000000018146E7A0-0x000000018146E810
		static UTF32Encoding(); // 0x000000018146E5D0-0x000000018146E770
	
		// Methods
		internal override void SetDefaultFallbacks(); // 0x000000018146E4E0-0x000000018146E5D0
		public override int GetByteCount(char[] chars, int index, int count); // 0x000000018146C0D0-0x000000018146C280
		public override int GetByteCount(string s); // 0x000000018146C280-0x000000018146C320
		[CLSCompliant(false)]
		public override unsafe int GetByteCount(char* chars, int count); // 0x000000018146C320-0x000000018146C420
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x000000018146C810-0x000000018146CAA0
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x000000018146C420-0x000000018146C6D0
		[CLSCompliant(false)]
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x000000018146C6D0-0x000000018146C810
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x000000018146D400-0x000000018146D5B0
		[CLSCompliant(false)]
		public override unsafe int GetCharCount(byte* bytes, int count); // 0x000000018146D300-0x000000018146D400
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x000000018146D6F0-0x000000018146D9A0
		[CLSCompliant(false)]
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x000000018146D5B0-0x000000018146D6F0
		public override string GetString(byte[] bytes, int index, int count); // 0x000000018146E310-0x000000018146E4C0
		internal override unsafe int GetByteCount(char* chars, int count, EncoderNLS encoder); // 0x000000018146BD40-0x000000018146C0D0
		internal override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS encoder); // 0x000000018146CAA0-0x000000018146CFB0
		internal override unsafe int GetCharCount(byte* bytes, int count, DecoderNLS baseDecoder); // 0x000000018146CFB0-0x000000018146D300
		internal override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS baseDecoder); // 0x000000018146D9A0-0x000000018146DE20
		private uint GetSurrogate(char cHigh, char cLow); // 0x000000018146E4C0-0x000000018146E4E0
		private char GetHighSurrogate(uint iChar); // 0x000000018146DFD0-0x000000018146DFF0
		private char GetLowSurrogate(uint iChar); // 0x000000018146DFF0-0x000000018146E010
		public override Decoder GetDecoder(); // 0x000000018146DE20-0x000000018146DE80
		public override Encoder GetEncoder(); // 0x000000018146DE80-0x000000018146DF20
		public override int GetMaxByteCount(int charCount); // 0x000000018146E010-0x000000018146E150
		public override int GetMaxCharCount(int byteCount); // 0x000000018146E150-0x000000018146E230
		public override byte[] GetPreamble(); // 0x000000018146E230-0x000000018146E310
		public override bool Equals(object value); // 0x000000018146BC70-0x000000018146BD40
		public override int GetHashCode(); // 0x000000018146DF20-0x000000018146DFD0
	}
}
