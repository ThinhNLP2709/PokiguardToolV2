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
	public class UTF7Encoding : Encoding // TypeDefIndex: 2722
	{
		// Fields
		internal static readonly UTF7Encoding s_default; // 0x00
		private byte[] _base64Bytes; // 0x38
		private sbyte[] _base64Values; // 0x40
		private bool[] _directEncode; // 0x48
		private bool _allowOptionals; // 0x50
	
		// Nested types
		[Serializable]
		private sealed class Decoder : DecoderNLS // TypeDefIndex: 2723
		{
			// Fields
			internal int bits; // 0x30
			internal int bitCount; // 0x34
			internal bool firstByte; // 0x38
	
			// Properties
			internal override bool HasState { get; } // 0x0000000181461100-0x0000000181461110 
	
			// Constructors
			public Decoder(UTF7Encoding encoding); // 0x00000001814610F0-0x0000000181461100
	
			// Methods
			public override void Reset(); // 0x00000001814610B0-0x00000001814610F0
		}
	
		[Serializable]
		private sealed class Encoder : EncoderNLS // TypeDefIndex: 2724
		{
			// Fields
			internal int bits; // 0x38
			internal int bitCount; // 0x3C
	
			// Properties
			internal override bool HasState { get; } // 0x0000000181463D80-0x0000000181463DA0 
	
			// Constructors
			public Encoder(UTF7Encoding encoding); // 0x00000001814627D0-0x0000000181462840
	
			// Methods
			public override void Reset(); // 0x0000000181463B60-0x0000000181463B90
		}
	
		[Serializable]
		private sealed class DecoderUTF7Fallback : DecoderFallback // TypeDefIndex: 2725
		{
			// Properties
			public override int MaxCharCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
			// Constructors
			public DecoderUTF7Fallback(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override DecoderFallbackBuffer CreateFallbackBuffer(); // 0x0000000181461000-0x0000000181461050
			public override bool Equals(object value); // 0x0000000181461050-0x00000001814610A0
			public override int GetHashCode(); // 0x00000001814610A0-0x00000001814610B0
		}
	
		private sealed class DecoderUTF7FallbackBuffer : DecoderFallbackBuffer // TypeDefIndex: 2726
		{
			// Fields
			private char cFallback; // 0x20
			private int iCount; // 0x24
			private int iSize; // 0x28
	
			// Properties
			public override int Remaining { get; } // 0x0000000181460FF0-0x0000000181461000 
	
			// Constructors
			public DecoderUTF7FallbackBuffer(DecoderUTF7Fallback fallback); // 0x0000000181460FE0-0x0000000181460FF0
	
			// Methods
			public override bool Fallback(byte[] bytesUnknown, int index); // 0x0000000181460EE0-0x0000000181460F30
			public override char GetNextChar(); // 0x0000000181460F30-0x0000000181460F50
			public override void Reset(); // 0x0000000181460FD0-0x0000000181460FE0
			internal override unsafe int InternalFallback(byte[] bytes, byte* pBytes); // 0x0000000181460F50-0x0000000181460FD0
		}
	
		// Constructors
		public UTF7Encoding(); // 0x00000001814709E0-0x0000000181470A10
		public UTF7Encoding(bool allowOptionals); // 0x0000000181470A10-0x0000000181470A50
		static UTF7Encoding(); // 0x0000000181470960-0x00000001814709E0
	
		// Methods
		private void MakeTables(); // 0x0000000181470630-0x00000001814708B0
		internal override void SetDefaultFallbacks(); // 0x00000001814708B0-0x0000000181470960
		public override bool Equals(object value); // 0x000000018146E9D0-0x000000018146EAA0
		public override int GetHashCode(); // 0x0000000181470280-0x0000000181470300
		public override int GetByteCount(char[] chars, int index, int count); // 0x000000018146EC80-0x000000018146EE30
		public override int GetByteCount(string s); // 0x000000018146EBE0-0x000000018146EC80
		[CLSCompliant(false)]
		public override unsafe int GetByteCount(char* chars, int count); // 0x000000018146EAA0-0x000000018146EBA0
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x000000018146F0E0-0x000000018146F370
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x000000018146EE30-0x000000018146F0E0
		[CLSCompliant(false)]
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x000000018146F700-0x000000018146F840
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x000000018146F940-0x000000018146FAF0
		[CLSCompliant(false)]
		public override unsafe int GetCharCount(byte* bytes, int count); // 0x000000018146F840-0x000000018146F940
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x000000018146FD90-0x0000000181470040
		[CLSCompliant(false)]
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x0000000181470040-0x0000000181470180
		public override string GetString(byte[] bytes, int index, int count); // 0x0000000181470480-0x0000000181470630
		internal override unsafe int GetByteCount(char* chars, int count, EncoderNLS baseEncoder); // 0x000000018146EBA0-0x000000018146EBE0
		internal override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS baseEncoder); // 0x000000018146F370-0x000000018146F700
		internal override unsafe int GetCharCount(byte* bytes, int count, DecoderNLS baseDecoder); // 0x000000018146FAF0-0x000000018146FB30
		internal override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS baseDecoder); // 0x000000018146FB30-0x000000018146FD90
		public override Decoder GetDecoder(); // 0x0000000181470180-0x00000001814701E0
		public override Encoder GetEncoder(); // 0x00000001814701E0-0x0000000181470280
		public override int GetMaxByteCount(int charCount); // 0x0000000181470300-0x00000001814703F0
		public override int GetMaxCharCount(int byteCount); // 0x00000001814703F0-0x0000000181470480
	}
}
