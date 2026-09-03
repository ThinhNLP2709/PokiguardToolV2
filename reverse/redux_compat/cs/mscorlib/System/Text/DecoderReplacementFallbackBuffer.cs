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
	public sealed class DecoderReplacementFallbackBuffer : DecoderFallbackBuffer // TypeDefIndex: 2702
	{
		// Fields
		private string _strDefault; // 0x20
		private int _fallbackCount; // 0x28
		private int _fallbackIndex; // 0x2C
	
		// Properties
		public override int Remaining { get; } // 0x000000018167FCB0-0x000000018167FCC0 
	
		// Constructors
		public DecoderReplacementFallbackBuffer(DecoderReplacementFallback fallback); // 0x000000018167FC60-0x000000018167FCB0
	
		// Methods
		public override bool Fallback(byte[] bytesUnknown, int index); // 0x000000018167FB80-0x000000018167FBD0
		public override char GetNextChar(); // 0x000000018167FBD0-0x000000018167FC20
		public override void Reset(); // 0x000000018167FC40-0x000000018167FC60
		internal override unsafe int InternalFallback(byte[] bytes, byte* pBytes); // 0x000000018167FC20-0x000000018167FC40
	}
}
