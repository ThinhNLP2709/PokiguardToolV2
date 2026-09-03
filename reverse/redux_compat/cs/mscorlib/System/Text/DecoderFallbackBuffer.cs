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
	public abstract class DecoderFallbackBuffer // TypeDefIndex: 2699
	{
		// Fields
		internal unsafe byte* byteStart; // 0x10
		internal unsafe char* charEnd; // 0x18
	
		// Properties
		public abstract int Remaining { get; }
	
		// Constructors
		protected DecoderFallbackBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract bool Fallback(byte[] bytesUnknown, int index);
		public abstract char GetNextChar();
		public virtual void Reset(); // 0x000000018167EA30-0x000000018167EA70
		internal void InternalReset(); // 0x000000018167EA10-0x000000018167EA30
		internal unsafe void InternalInitialize(byte* byteStart, char* charEnd); // 0x000000018167EA00-0x000000018167EA10
		internal virtual unsafe bool InternalFallback(byte[] bytes, byte* pBytes, ref char* chars); // 0x000000018167E7E0-0x000000018167EA00
		internal virtual unsafe int InternalFallback(byte[] bytes, byte* pBytes); // 0x000000018167E5C0-0x000000018167E7E0
		internal void ThrowLastBytesRecursive(byte[] bytesUnknown); // 0x000000018167EA70-0x000000018167ECA0
	}
}
