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
	internal class InternalEncoderBestFitFallback : EncoderFallback // TypeDefIndex: 2704
	{
		// Fields
		internal Encoding _encoding; // 0x10
		internal char[] _arrayBestFit; // 0x18
	
		// Properties
		public override int MaxCharCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		internal InternalEncoderBestFitFallback(Encoding encoding); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public override EncoderFallbackBuffer CreateFallbackBuffer(); // 0x0000000181465C20-0x0000000181465C80
		public override bool Equals(object value); // 0x0000000181465C80-0x0000000181465D40
		public override int GetHashCode(); // 0x0000000181465D40-0x0000000181465D70
	}
}
