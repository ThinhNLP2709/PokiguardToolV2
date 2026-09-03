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
	public class UTF8Encoding : Encoding // TypeDefIndex: 2727
	{
		// Fields
		internal static readonly UTF8EncodingSealed s_default; // 0x00
		internal static readonly byte[] s_preamble; // 0x08
		internal readonly bool _emitUTF8Identifier; // 0x38
		private bool _isThrowException; // 0x39
	
		// Properties
		public override ReadOnlySpan<byte> Preamble { get; } // 0x0000000181474440-0x0000000181474A10 
	
		// Nested types
		internal sealed class UTF8EncodingSealed : UTF8Encoding // TypeDefIndex: 2728
		{
			// Properties
			public override ReadOnlySpan<byte> Preamble { get; } // 0x0000000181487230-0x0000000181487300 
	
			// Constructors
			public UTF8EncodingSealed(bool encoderShouldEmitUTF8Identifier); // 0x00000001814871D0-0x0000000181487230
		}
	
		[Serializable]
		private sealed class UTF8Encoder : EncoderNLS // TypeDefIndex: 2729
		{
			// Fields
			internal int surrogateChar; // 0x38
	
			// Properties
			internal override bool HasState { get; } // 0x000000018047EE00-0x000000018047EE10 
	
			// Constructors
			public UTF8Encoder(UTF8Encoding encoding); // 0x00000001814871C0-0x00000001814871D0
	
			// Methods
			public override void Reset(); // 0x0000000181487190-0x00000001814871C0
		}
	
		[Serializable]
		private sealed class UTF8Decoder : DecoderNLS // TypeDefIndex: 2730
		{
			// Fields
			internal int bits; // 0x30
	
			// Properties
			internal override bool HasState { get; } // 0x0000000181487180-0x0000000181487190 
	
			// Constructors
			public UTF8Decoder(UTF8Encoding encoding); // 0x00000001814610F0-0x0000000181461100
	
			// Methods
			public override void Reset(); // 0x0000000181487150-0x0000000181487180
		}
	
		// Constructors
		public UTF8Encoding(); // 0x00000001814743E0-0x0000000181474410
		public UTF8Encoding(bool encoderShouldEmitUTF8Identifier); // 0x0000000181474410-0x0000000181474440
		public UTF8Encoding(bool encoderShouldEmitUTF8Identifier, bool throwOnInvalidBytes); // 0x0000000181474380-0x00000001814743E0
		static UTF8Encoding(); // 0x00000001814742A0-0x0000000181474380
	
		// Methods
		internal override void SetDefaultFallbacks(); // 0x00000001814741B0-0x00000001814742A0
		public override int GetByteCount(char[] chars, int index, int count); // 0x00000001814713C0-0x0000000181471570
		public override int GetByteCount(string chars); // 0x0000000181470BF0-0x0000000181470C90
		[CLSCompliant(false)]
		public override unsafe int GetByteCount(char* chars, int count); // 0x0000000181471570-0x0000000181471670
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x0000000181472280-0x0000000181472510
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x0000000181472510-0x00000001814727C0
		[CLSCompliant(false)]
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x0000000181472140-0x0000000181472280
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x0000000181472DD0-0x0000000181472F80
		[CLSCompliant(false)]
		public override unsafe int GetCharCount(byte* bytes, int count); // 0x0000000181472CD0-0x0000000181472DD0
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181472F80-0x0000000181473230
		[CLSCompliant(false)]
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x0000000181473A20-0x0000000181473B60
		public override string GetString(byte[] bytes, int index, int count); // 0x0000000181473FD0-0x0000000181474180
		internal override unsafe int GetByteCount(char* chars, int count, EncoderNLS baseEncoder); // 0x0000000181470C90-0x00000001814713C0
		private static unsafe int PtrDiff(char* a, char* b); // 0x00000001814741A0-0x00000001814741B0
		private static unsafe int PtrDiff(byte* a, byte* b); // 0x0000000181474190-0x00000001814741A0
		private static bool InRange(int ch, int start, int end); // 0x0000000181474180-0x0000000181474190
		internal override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS baseEncoder); // 0x00000001814718D0-0x0000000181472140
		internal override unsafe int GetCharCount(byte* bytes, int count, DecoderNLS baseDecoder); // 0x00000001814727C0-0x0000000181472CD0
		internal override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS baseDecoder); // 0x0000000181473230-0x0000000181473A20
		private unsafe bool FallbackInvalidByteSequence(ref byte* pSrc, int ch, DecoderFallbackBuffer fallback, ref char* pTarget); // 0x0000000181470B70-0x0000000181470BF0
		private unsafe int FallbackInvalidByteSequence(byte* pSrc, int ch, DecoderFallbackBuffer fallback); // 0x0000000181470B20-0x0000000181470B70
		private unsafe byte[] GetBytesUnknown(ref byte* pSrc, int ch); // 0x0000000181471670-0x00000001814718D0
		public override Decoder GetDecoder(); // 0x0000000181473B60-0x0000000181473BC0
		public override Encoder GetEncoder(); // 0x0000000181473BC0-0x0000000181473C20
		public override int GetMaxByteCount(int charCount); // 0x0000000181473C90-0x0000000181473DD0
		public override int GetMaxCharCount(int byteCount); // 0x0000000181473DD0-0x0000000181473F10
		public override byte[] GetPreamble(); // 0x0000000181473F10-0x0000000181473FD0
		public override bool Equals(object value); // 0x0000000181470A50-0x0000000181470B20
		public override int GetHashCode(); // 0x0000000181473C20-0x0000000181473C90
	}
}
