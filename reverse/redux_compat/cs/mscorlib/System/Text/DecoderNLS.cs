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
	internal class DecoderNLS : Decoder // TypeDefIndex: 2700
	{
		// Fields
		private Encoding _encoding; // 0x20
		private bool _mustFlush; // 0x28
		internal bool _throwOnOverflow; // 0x29
		internal int _bytesUsed; // 0x2C
	
		// Properties
		public bool MustFlush { get; } // 0x0000000180327270-0x0000000180327280 
		internal virtual bool HasState { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		internal DecoderNLS(Encoding encoding); // 0x000000018167FB10-0x000000018167FB80
	
		// Methods
		public override void Reset(); // 0x000000018167FAF0-0x000000018167FB10
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x00000001814767C0-0x00000001814767F0
		public override int GetCharCount(byte[] bytes, int index, int count, bool flush); // 0x000000018167F530-0x000000018167F6E0
		public override unsafe int GetCharCount(byte* bytes, int count, bool flush); // 0x000000018167F410-0x000000018167F530
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181476820-0x0000000181476860
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush); // 0x000000018167F840-0x000000018167FAF0
		public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush); // 0x000000018167F6E0-0x000000018167F840
		public override void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed); // 0x000000018167F0C0-0x000000018167F410
		public override unsafe void Convert(byte* bytes, int byteCount, char* chars, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed); // 0x000000018167EEC0-0x000000018167F0C0
		internal void ClearMustFlush(); // 0x000000018167EEB0-0x000000018167EEC0
	}
}
