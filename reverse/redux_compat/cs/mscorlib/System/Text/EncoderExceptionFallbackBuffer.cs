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
	public sealed class EncoderExceptionFallbackBuffer : EncoderFallbackBuffer // TypeDefIndex: 2707
	{
		// Properties
		public override int Remaining { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public EncoderExceptionFallbackBuffer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override bool Fallback(char charUnknown, int index); // 0x0000000181461110-0x00000001814611C0
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index); // 0x00000001814611C0-0x0000000181461410
		public override char GetNextChar(); // 0x00000001802E7860-0x00000001802E7870
		public override bool MovePrevious(); // 0x00000001802E7840-0x00000001802E7850
	}
}
