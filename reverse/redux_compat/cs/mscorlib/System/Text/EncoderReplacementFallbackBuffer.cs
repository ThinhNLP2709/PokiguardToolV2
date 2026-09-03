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
	public sealed class EncoderReplacementFallbackBuffer : EncoderFallbackBuffer // TypeDefIndex: 2713
	{
		// Fields
		private string _strDefault; // 0x30
		private int _fallbackCount; // 0x38
		private int _fallbackIndex; // 0x3C
	
		// Properties
		public override int Remaining { get; } // 0x0000000181462C40-0x0000000181462C50 
	
		// Constructors
		public EncoderReplacementFallbackBuffer(EncoderReplacementFallback fallback); // 0x0000000181462BE0-0x0000000181462C40
	
		// Methods
		public override bool Fallback(char charUnknown, int index); // 0x0000000181462A50-0x0000000181462B50
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index); // 0x0000000181462850-0x0000000181462A50
		public override char GetNextChar(); // 0x0000000181462B50-0x0000000181462BA0
		public override bool MovePrevious(); // 0x0000000181462BA0-0x0000000181462BC0
		public override void Reset(); // 0x0000000181462BC0-0x0000000181462BE0
	}
}
