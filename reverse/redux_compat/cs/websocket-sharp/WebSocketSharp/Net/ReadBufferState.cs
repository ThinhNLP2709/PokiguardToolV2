/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal class ReadBufferState // TypeDefIndex: 13297
	{
		// Fields
		private HttpStreamAsyncResult _asyncResult; // 0x10
		private byte[] _buffer; // 0x18
		private int _count; // 0x20
		private int _initialCount; // 0x24
		private int _offset; // 0x28
	
		// Properties
		public HttpStreamAsyncResult AsyncResult { get; set; } // 0x00000001825D8700-0x00000001825D8710 0x00000001803780D0-0x00000001803780E0
		public byte[] Buffer { get; set; } // 0x00000001825D8710-0x00000001825D8720 0x00000001802FAF70-0x00000001802FAF80
		public int Count { get; set; } // 0x00000001825EE1B0-0x00000001825EE1C0 0x0000000180E332D0-0x0000000180E332E0
		public int InitialCount { get; set; } // 0x000000018260AC90-0x000000018260ACA0 0x0000000180E02560-0x0000000180E02570
		public int Offset { get; set; } // 0x0000000182612DA0-0x0000000182612DB0 0x0000000180378100-0x0000000180378110
	
		// Constructors
		public ReadBufferState(byte[] buffer, int offset, int count, HttpStreamAsyncResult asyncResult); // 0x0000000182612D30-0x0000000182612DA0
	}
}
