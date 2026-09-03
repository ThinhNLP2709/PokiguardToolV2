/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(2)]
	internal struct StringBuffer // TypeDefIndex: 10181
	{
		// Fields
		private char[] _buffer; // 0x00
		private int _position; // 0x08
	
		// Properties
		public int Position { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public bool IsEmpty { get; } // 0x0000000180E87410-0x0000000180E87420 
		public char[] InternalBuffer { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		public StringBuffer(IArrayPool<char> bufferPool, int initalSize); // 0x000000018171B1F0-0x000000018171B230
		[NullableContext(1)]
		private StringBuffer(char[] buffer); // 0x000000018171B230-0x000000018171B250
	
		// Methods
		public void Append(IArrayPool<char> bufferPool, char value); // 0x000000018171AF40-0x000000018171B000
		[NullableContext(1)]
		public void Append([Nullable(2)] IArrayPool<char> bufferPool, char[] buffer, int startIndex, int count); // 0x000000018171B000-0x000000018171B0D0
		public void Clear(IArrayPool<char> bufferPool); // 0x000000018171B0D0-0x000000018171B120
		private void EnsureSize(IArrayPool<char> bufferPool, int appendLength); // 0x000000018171B120-0x000000018171B190
		[NullableContext(1)]
		public override string ToString(); // 0x000000018171B190-0x000000018171B1C0
		[NullableContext(1)]
		public string ToString(int start, int length); // 0x000000018171B1C0-0x000000018171B1F0
	}
}
