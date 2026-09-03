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
	internal abstract class EncodingNLS : Encoding // TypeDefIndex: 2714
	{
		// Constructors
		protected EncodingNLS(int codePage); // 0x00000001814650C0-0x00000001814650D0
	
		// Methods
		public override int GetByteCount(char[] chars, int index, int count); // 0x0000000181463F40-0x00000001814640F0
		public override int GetByteCount(string s); // 0x0000000181463DA0-0x0000000181463E40
		public override unsafe int GetByteCount(char* chars, int count); // 0x0000000181463E40-0x0000000181463F40
		public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x00000001814640F0-0x0000000181464380
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x00000001814644C0-0x0000000181464770
		public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount); // 0x0000000181464380-0x00000001814644C0
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x0000000181464770-0x0000000181464920
		public override unsafe int GetCharCount(byte* bytes, int count); // 0x0000000181464920-0x0000000181464A20
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181464B60-0x0000000181464E10
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount); // 0x0000000181464A20-0x0000000181464B60
		public override string GetString(byte[] bytes, int index, int count); // 0x0000000181464F10-0x00000001814650C0
		public override Decoder GetDecoder(); // 0x0000000181464E10-0x0000000181464E70
		public override Encoder GetEncoder(); // 0x0000000181464E70-0x0000000181464F10
	}
}
