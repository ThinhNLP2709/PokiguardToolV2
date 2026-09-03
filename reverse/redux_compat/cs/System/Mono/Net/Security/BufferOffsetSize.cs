/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal class BufferOffsetSize // TypeDefIndex: 8543
	{
		// Fields
		public byte[] Buffer; // 0x10
		public int Offset; // 0x18
		public int Size; // 0x1C
		public int TotalBytes; // 0x20
		public bool Complete; // 0x24
	
		// Properties
		public int EndOffset { get; } // 0x0000000181810230-0x0000000181810240 
		public int Remaining { get; } // 0x0000000181810240-0x0000000181810270 
	
		// Constructors
		public BufferOffsetSize(byte[] buffer, int offset, int size); // 0x00000001818100D0-0x0000000181810230
	
		// Methods
		public override string ToString(); // 0x0000000181810050-0x00000001818100D0
	}
}
