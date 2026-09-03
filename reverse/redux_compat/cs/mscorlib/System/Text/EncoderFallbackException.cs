/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Text
{
	[Serializable]
	public sealed class EncoderFallbackException : ArgumentException // TypeDefIndex: 2708
	{
		// Fields
		private char _charUnknown; // 0x98
		private char _charUnknownHigh; // 0x9A
		private char _charUnknownLow; // 0x9C
		private int _index; // 0xA0
	
		// Constructors
		public EncoderFallbackException(); // 0x00000001814617A0-0x00000001814617F0
		internal EncoderFallbackException(string message, char charUnknown, int index); // 0x00000001814619C0-0x0000000181461A00
		internal EncoderFallbackException(string message, char charUnknownHigh, char charUnknownLow, int index); // 0x00000001814617F0-0x00000001814619C0
		private EncoderFallbackException(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181461A00-0x0000000181461A20
	}
}
