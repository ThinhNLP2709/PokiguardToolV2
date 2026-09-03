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
	public abstract class EncoderFallbackBuffer // TypeDefIndex: 2710
	{
		// Fields
		internal unsafe char* charStart; // 0x10
		internal unsafe char* charEnd; // 0x18
		internal EncoderNLS encoder; // 0x20
		internal bool setEncoder; // 0x28
		internal bool bUsedEncoder; // 0x29
		internal bool bFallingBack; // 0x2A
		internal int iRecursionCount; // 0x2C
	
		// Properties
		public abstract int Remaining { get; }
	
		// Constructors
		protected EncoderFallbackBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract bool Fallback(char charUnknown, int index);
		public abstract bool Fallback(char charUnknownHigh, char charUnknownLow, int index);
		public abstract char GetNextChar();
		public abstract bool MovePrevious();
		public virtual void Reset(); // 0x00000001814616D0-0x0000000181461710
		internal void InternalReset(); // 0x00000001814616B0-0x00000001814616D0
		internal unsafe void InternalInitialize(char* charStart, char* charEnd, EncoderNLS encoder, bool setEncoder); // 0x0000000181461670-0x00000001814616B0
		internal char InternalGetNextChar(); // 0x0000000181461630-0x0000000181461670
		internal virtual unsafe bool InternalFallback(char ch, ref char* chars); // 0x00000001814614C0-0x0000000181461630
		internal void ThrowLastCharRecursive(int charRecursive); // 0x0000000181461710-0x00000001814617A0
	}
}
