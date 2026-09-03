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
	public abstract class Decoder // TypeDefIndex: 2692
	{
		// Fields
		internal DecoderFallback _fallback; // 0x10
		internal DecoderFallbackBuffer _fallbackBuffer; // 0x18
	
		// Properties
		public DecoderFallback Fallback { get; } // 0x0000000180377550-0x0000000180377560 
		public DecoderFallbackBuffer FallbackBuffer { get; } // 0x0000000181680E10-0x0000000181680E90 
		internal bool InternalHasFallbackBuffer { get; } // 0x0000000180DAB6D0-0x0000000180DAB6E0 
	
		// Constructors
		protected Decoder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Reset(); // 0x0000000181680D00-0x0000000181680E10
		public abstract int GetCharCount(byte[] bytes, int index, int count);
		public virtual int GetCharCount(byte[] bytes, int index, int count, bool flush); // 0x00000001816809F0-0x0000000181680A10
		[CLSCompliant(false)]
		public virtual unsafe int GetCharCount(byte* bytes, int count, bool flush); // 0x0000000181680860-0x00000001816809F0
		public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
		public virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush); // 0x0000000181680A10-0x0000000181680A30
		[CLSCompliant(false)]
		public virtual unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush); // 0x0000000181680A30-0x0000000181680C90
		public virtual int GetChars(ReadOnlySpan<byte> bytes, Span<char> chars, bool flush); // 0x0000000181680C90-0x0000000181680D00
		public virtual void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed); // 0x0000000181680210-0x00000001816805F0
		[CLSCompliant(false)]
		public virtual unsafe void Convert(byte* bytes, int byteCount, char* chars, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed); // 0x00000001816805F0-0x0000000181680860
	}
}
