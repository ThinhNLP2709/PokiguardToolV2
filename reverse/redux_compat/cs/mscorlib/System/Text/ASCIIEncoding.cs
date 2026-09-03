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
	public class ASCIIEncoding : Encoding // TypeDefIndex: 2690
	{
		// Fields
		internal static readonly ASCIIEncodingSealed s_default; // 0x00
	
		// Nested types
		internal sealed class ASCIIEncodingSealed : ASCIIEncoding // TypeDefIndex: 2691
		{
			// Constructors
			public ASCIIEncodingSealed(); // 0x000000018167ACA0-0x000000018167ACF0
		}
	
		// Constructors
		public ASCIIEncoding(); // 0x000000018167D070-0x000000018167D080
		static ASCIIEncoding(); // 0x000000018167CFC0-0x000000018167D070
	
		// Methods
		internal override void SetDefaultFallbacks(); // 0x000000018167CF80-0x000000018167CFC0
		public override int GetByteCount(char[] chars, int index, int count); // 0x000000018167B120-0x000000018167B2D0
		public override int GetByteCount(string chars); // 0x000000018167B2D0-0x000000018167B370
		[CLSCompliant(false)]
		public override unsafe int GetByteCount(char* chars, int count); // 0x000000018167ACF0-0x000000018167ADF0
		public override int GetBytes(string chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x000000018167BC50-0x000000018167BEE0
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x000000018167B9A0-0x000000018167BC50
		[CLSCompliant(false)]
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x000000018167B860-0x000000018167B9A0
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x000000018167BEE0-0x000000018167C090
		[CLSCompliant(false)]
		public override unsafe int GetCharCount(byte* bytes, int count); // 0x000000018167C090-0x000000018167C190
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x000000018167C7A0-0x000000018167CA50
		[CLSCompliant(false)]
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x000000018167C330-0x000000018167C470
		public override string GetString(byte[] bytes, int byteIndex, int byteCount); // 0x000000018167CDD0-0x000000018167CF80
		internal override unsafe int GetByteCount(char* chars, int charCount, EncoderNLS encoder); // 0x000000018167ADF0-0x000000018167B120
		internal override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS encoder); // 0x000000018167B370-0x000000018167B860
		internal override unsafe int GetCharCount(byte* bytes, int count, DecoderNLS decoder); // 0x000000018167C190-0x000000018167C330
		internal override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS decoder); // 0x000000018167C470-0x000000018167C7A0
		public override int GetMaxByteCount(int charCount); // 0x000000018167CB50-0x000000018167CC90
		public override int GetMaxCharCount(int byteCount); // 0x000000018167CC90-0x000000018167CDD0
		public override Decoder GetDecoder(); // 0x000000018167CA50-0x000000018167CAF0
		public override Encoder GetEncoder(); // 0x000000018167CAF0-0x000000018167CB50
	}
}
