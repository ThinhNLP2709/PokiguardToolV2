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
	public abstract class Encoder // TypeDefIndex: 2703
	{
		// Fields
		internal EncoderFallback _fallback; // 0x10
		internal EncoderFallbackBuffer _fallbackBuffer; // 0x18
	
		// Properties
		public EncoderFallback Fallback { get; } // 0x0000000180377550-0x0000000180377560 
		public EncoderFallbackBuffer FallbackBuffer { get; } // 0x0000000181463C70-0x0000000181463D80 
		internal bool InternalHasFallbackBuffer { get; } // 0x0000000180DAB6D0-0x0000000180DAB6E0 
	
		// Constructors
		protected Encoder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Reset(); // 0x0000000181463B90-0x0000000181463C70
		public abstract int GetByteCount(char[] chars, int index, int count, bool flush);
		[CLSCompliant(false)]
		public virtual unsafe int GetByteCount(char* chars, int count, bool flush); // 0x0000000181463750-0x00000001814638F0
		public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush);
		[CLSCompliant(false)]
		public virtual unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush); // 0x00000001814638F0-0x0000000181463B60
		public virtual void Convert(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed); // 0x0000000181463370-0x0000000181463750
		[CLSCompliant(false)]
		public virtual unsafe void Convert(char* chars, int charCount, byte* bytes, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed); // 0x0000000181463060-0x00000001814632D0
		public virtual void Convert(ReadOnlySpan<char> chars, Span<byte> bytes, bool flush, out int charsUsed, out int bytesUsed, out bool completed); // 0x00000001814632D0-0x0000000181463370
	}
}
