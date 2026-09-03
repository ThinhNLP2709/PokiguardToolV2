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
	public sealed class DecoderFallbackException : ArgumentException // TypeDefIndex: 2697
	{
		// Fields
		private byte[] _bytesUnknown; // 0x98
		private int _index; // 0xA0
	
		// Constructors
		public DecoderFallbackException(); // 0x000000018167ECF0-0x000000018167ED40
		public DecoderFallbackException(string message, byte[] bytesUnknown, int index); // 0x000000018167ECA0-0x000000018167ECF0
		private DecoderFallbackException(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181461A00-0x0000000181461A20
	}
}
