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
	public class UnicodeEncoding : Encoding // TypeDefIndex: 2731
	{
		// Fields
		internal static readonly UnicodeEncoding s_bigEndianDefault; // 0x00
		internal static readonly UnicodeEncoding s_littleEndianDefault; // 0x08
		private static readonly byte[] s_bigEndianPreamble; // 0x10
		private static readonly byte[] s_littleEndianPreamble; // 0x18
		internal bool isThrowException; // 0x38
		internal bool bigEndian; // 0x39
		internal bool byteOrderMark; // 0x3A
		private static readonly ulong highLowPatternMask; // 0x20
	
		// Properties
		public override ReadOnlySpan<byte> Preamble { get; } // 0x000000018148B3E0-0x000000018148B550 
	
		// Nested types
		[Serializable]
		private sealed class Decoder : DecoderNLS // TypeDefIndex: 2732
		{
			// Fields
			internal int lastByte; // 0x30
			internal char lastChar; // 0x34
	
			// Properties
			internal override bool HasState { get; } // 0x0000000181476770-0x0000000181476790 
	
			// Constructors
			public Decoder(UnicodeEncoding encoding); // 0x0000000181476760-0x0000000181476770
	
			// Methods
			public override void Reset(); // 0x0000000181476730-0x0000000181476760
		}
	
		// Constructors
		public UnicodeEncoding(); // 0x000000018148B3B0-0x000000018148B3E0
		public UnicodeEncoding(bool bigEndian, bool byteOrderMark); // 0x000000018148B360-0x000000018148B3B0
		public UnicodeEncoding(bool bigEndian, bool byteOrderMark, bool throwOnInvalidBytes); // 0x000000018148B2E0-0x000000018148B360
		static UnicodeEncoding(); // 0x000000018148B110-0x000000018148B2E0
	
		// Methods
		internal override void SetDefaultFallbacks(); // 0x000000018148B020-0x000000018148B110
		public override int GetByteCount(char[] chars, int index, int count); // 0x0000000181487420-0x00000001814875D0
		public override int GetByteCount(string s); // 0x0000000181487D70-0x0000000181487E10
		[CLSCompliant(false)]
		public override unsafe int GetByteCount(char* chars, int count); // 0x0000000181487E10-0x0000000181487F10
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x0000000181487F10-0x00000001814881A0
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x0000000181488B30-0x0000000181488DE0
		[CLSCompliant(false)]
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x0000000181488DE0-0x0000000181488F20
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x00000001814898D0-0x0000000181489A80
		[CLSCompliant(false)]
		public override unsafe int GetCharCount(byte* bytes, int count); // 0x00000001814897D0-0x00000001814898D0
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x000000018148A6F0-0x000000018148A9A0
		[CLSCompliant(false)]
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x000000018148A5B0-0x000000018148A6F0
		public override string GetString(byte[] bytes, int index, int count); // 0x000000018148AE70-0x000000018148B020
		internal override unsafe int GetByteCount(char* chars, int count, EncoderNLS encoder); // 0x00000001814875D0-0x0000000181487D70
		internal override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS encoder); // 0x00000001814881A0-0x0000000181488B30
		internal override unsafe int GetCharCount(byte* bytes, int count, DecoderNLS baseDecoder); // 0x0000000181488F20-0x00000001814897D0
		internal override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS baseDecoder); // 0x0000000181489A80-0x000000018148A5B0
		public override Encoder GetEncoder(); // 0x000000018148AA00-0x000000018148AA60
		public override Decoder GetDecoder(); // 0x000000018148A9A0-0x000000018148AA00
		public override byte[] GetPreamble(); // 0x000000018148AD90-0x000000018148AE70
		public override int GetMaxByteCount(int charCount); // 0x000000018148AB00-0x000000018148AC40
		public override int GetMaxCharCount(int byteCount); // 0x000000018148AC40-0x000000018148AD90
		public override bool Equals(object value); // 0x0000000181487300-0x0000000181487420
		public override int GetHashCode(); // 0x000000018148AA60-0x000000018148AB00
	}
}
