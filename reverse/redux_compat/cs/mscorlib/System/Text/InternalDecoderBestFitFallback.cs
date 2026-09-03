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
	internal sealed class InternalDecoderBestFitFallback : DecoderFallback // TypeDefIndex: 2693
	{
		// Fields
		internal Encoding _encoding; // 0x10
		internal char[] _arrayBestFit; // 0x18
		internal char _cReplacement; // 0x20
	
		// Properties
		public override int MaxCharCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		internal InternalDecoderBestFitFallback(Encoding encoding); // 0x0000000181681870-0x00000001816818B0
	
		// Methods
		public override DecoderFallbackBuffer CreateFallbackBuffer(); // 0x0000000181681750-0x00000001816817B0
		public override bool Equals(object value); // 0x00000001816817B0-0x0000000181681870
		public override int GetHashCode(); // 0x0000000181465D40-0x0000000181465D70
	}
}
