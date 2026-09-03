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
	internal sealed class InternalDecoderBestFitFallbackBuffer : DecoderFallbackBuffer // TypeDefIndex: 2694
	{
		// Fields
		private char _cBestFit; // 0x20
		private int _iCount; // 0x24
		private int _iSize; // 0x28
		private InternalDecoderBestFitFallback _oFallback; // 0x30
		private static object s_InternalSyncObject; // 0x00
	
		// Properties
		private static object InternalSyncObject { get; } // 0x00000001816816C0-0x0000000181681750 
		public override int Remaining { get; } // 0x0000000181460FF0-0x0000000181461000 
	
		// Constructors
		public InternalDecoderBestFitFallbackBuffer(InternalDecoderBestFitFallback fallback); // 0x00000001816814F0-0x00000001816816C0
	
		// Methods
		public override bool Fallback(byte[] bytesUnknown, int index); // 0x00000001816812C0-0x0000000181681310
		public override char GetNextChar(); // 0x0000000181681310-0x0000000181681340
		public override void Reset(); // 0x0000000181460FD0-0x0000000181460FE0
		internal override unsafe int InternalFallback(byte[] bytes, byte* pBytes); // 0x0000000180472790-0x00000001804727A0
		private char TryBestFit(byte[] bytesCheck); // 0x0000000181681340-0x00000001816814F0
	}
}
