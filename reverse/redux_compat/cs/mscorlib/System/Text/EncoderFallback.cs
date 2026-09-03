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
	public abstract class EncoderFallback // TypeDefIndex: 2709
	{
		// Fields
		private static EncoderFallback s_replacementFallback; // 0x00
		private static EncoderFallback s_exceptionFallback; // 0x08
	
		// Properties
		public static EncoderFallback ReplacementFallback { get; } // 0x0000000181461AC0-0x0000000181461B80 
		public static EncoderFallback ExceptionFallback { get; } // 0x0000000181461A20-0x0000000181461AC0 
		public abstract int MaxCharCount { get; }
	
		// Constructors
		protected EncoderFallback(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract EncoderFallbackBuffer CreateFallbackBuffer();
	}
}
