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
	public abstract class DecoderFallback // TypeDefIndex: 2698
	{
		// Fields
		private static DecoderFallback s_replacementFallback; // 0x00
		private static DecoderFallback s_exceptionFallback; // 0x08
	
		// Properties
		public static DecoderFallback ReplacementFallback { get; } // 0x000000018167EE00-0x000000018167EEB0 
		public static DecoderFallback ExceptionFallback { get; } // 0x000000018167ED40-0x000000018167EE00 
		public abstract int MaxCharCount { get; }
	
		// Constructors
		protected DecoderFallback(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract DecoderFallbackBuffer CreateFallbackBuffer();
	}
}
