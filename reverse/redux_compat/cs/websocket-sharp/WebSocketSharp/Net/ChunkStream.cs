/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal class ChunkStream // TypeDefIndex: 13268
	{
		// Fields
		private int _chunkRead; // 0x10
		private int _chunkSize; // 0x14
		private List<Chunk> _chunks; // 0x18
		private int _count; // 0x20
		private byte[] _endBuffer; // 0x28
		private bool _gotIt; // 0x30
		private WebHeaderCollection _headers; // 0x38
		private int _offset; // 0x40
		private StringBuilder _saved; // 0x48
		private bool _sawCr; // 0x50
		private InputChunkState _state; // 0x54
		private int _trailerState; // 0x58
	
		// Properties
		internal int Count { get; } // 0x00000001825EE1B0-0x00000001825EE1C0 
		internal byte[] EndBuffer { get; } // 0x00000001825EE1C0-0x00000001825EE1D0 
		internal int Offset { get; } // 0x00000001825EE1E0-0x00000001825EE1F0 
		public WebHeaderCollection Headers { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
		public bool WantsMore { get; } // 0x00000001825EE1F0-0x00000001825EE200 
	
		// Constructors
		public ChunkStream(WebHeaderCollection headers); // 0x00000001825EE0F0-0x00000001825EE1B0
	
		// Methods
		private int read(byte[] buffer, int offset, int count); // 0x00000001825EE200-0x00000001825EE2E0
		private InputChunkState seekCrLf(byte[] buffer, ref int offset, int length); // 0x00000001825EE2E0-0x00000001825EE3B0
		private InputChunkState setChunkSize(byte[] buffer, ref int offset, int length); // 0x00000001825EE3B0-0x00000001825EE5A0
		private InputChunkState setTrailer(byte[] buffer, ref int offset, int length); // 0x00000001825EE5A0-0x00000001825EE7B0
		private static void throwProtocolViolation(string message); // 0x00000001825EE7B0-0x00000001825EE810
		private void write(byte[] buffer, int offset, int length); // 0x00000001825EE960-0x00000001825EECA0
		private InputChunkState writeData(byte[] buffer, ref int offset, int length); // 0x00000001825EE810-0x00000001825EE960
		internal void ResetChunkStore(); // 0x00000001825EE080-0x00000001825EE0D0
		public int Read(byte[] buffer, int offset, int count); // 0x00000001825EDF90-0x00000001825EE080
		public void Write(byte[] buffer, int offset, int count); // 0x00000001825EE0D0-0x00000001825EE0F0
	}
}
