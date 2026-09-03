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
	internal sealed class InternalEncoderBestFitFallbackBuffer : EncoderFallbackBuffer // TypeDefIndex: 2705
	{
		// Fields
		private char _cBestFit; // 0x30
		private InternalEncoderBestFitFallback _oFallback; // 0x38
		private int _iCount; // 0x40
		private int _iSize; // 0x44
		private static object s_InternalSyncObject; // 0x00
	
		// Properties
		private static object InternalSyncObject { get; } // 0x0000000181465B80-0x0000000181465C10 
		public override int Remaining { get; } // 0x0000000181465C10-0x0000000181465C20 
	
		// Constructors
		public InternalEncoderBestFitFallbackBuffer(InternalEncoderBestFitFallback fallback); // 0x00000001814659B0-0x0000000181465B80
	
		// Methods
		public override bool Fallback(char charUnknown, int index); // 0x0000000181465540-0x0000000181465670
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index); // 0x0000000181465670-0x0000000181465830
		public override char GetNextChar(); // 0x0000000181465830-0x0000000181465860
		public override bool MovePrevious(); // 0x0000000181465860-0x0000000181465880
		public override void Reset(); // 0x0000000181465880-0x00000001814658A0
		private char TryBestFit(char cUnknown); // 0x00000001814658A0-0x00000001814659B0
	}
}
