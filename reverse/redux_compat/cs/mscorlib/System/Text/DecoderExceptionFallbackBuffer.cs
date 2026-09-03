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
	public sealed class DecoderExceptionFallbackBuffer : DecoderFallbackBuffer // TypeDefIndex: 2696
	{
		// Properties
		public override int Remaining { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public DecoderExceptionFallbackBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override bool Fallback(byte[] bytesUnknown, int index); // 0x000000018167E2E0-0x000000018167E2F0
		public override char GetNextChar(); // 0x00000001802E7860-0x00000001802E7870
		private void Throw(byte[] bytesUnknown, int index); // 0x000000018167E2F0-0x000000018167E510
	}
}
