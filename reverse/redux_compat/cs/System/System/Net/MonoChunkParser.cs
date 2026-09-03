/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class MonoChunkParser // TypeDefIndex: 9137
	{
		// Fields
		private WebHeaderCollection headers; // 0x10
		private int chunkSize; // 0x18
		private int chunkRead; // 0x1C
		private int totalWritten; // 0x20
		private State state; // 0x24
		private StringBuilder saved; // 0x28
		private bool sawCR; // 0x30
		private bool gotit; // 0x31
		private int trailerState; // 0x34
		private ArrayList chunks; // 0x38
	
		// Properties
		public bool WantMore { get; } // 0x0000000181B11270-0x0000000181B11290 
		public bool DataAvailable { get; } // 0x0000000181B11160-0x0000000181B11270 
		public int ChunkLeft { get; } // 0x0000000181B11150-0x0000000181B11160 
	
		// Nested types
		private enum State // TypeDefIndex: 9138
		{
			None = 0,
			PartialSize = 1,
			Body = 2,
			BodyFinished = 3,
			Trailer = 4
		}
	
		private class Chunk // TypeDefIndex: 9139
		{
			// Fields
			public byte[] Bytes; // 0x10
			public int Offset; // 0x18
	
			// Constructors
			public Chunk(byte[] chunk); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			public int Read(byte[] buffer, int offset, int size); // 0x0000000181B0ED40-0x0000000181B0EDB0
		}
	
		// Constructors
		public MonoChunkParser(WebHeaderCollection headers); // 0x0000000181B11090-0x0000000181B11150
	
		// Methods
		public int Read(byte[] buffer, int offset, int size); // 0x0000000181B10FA0-0x0000000181B10FB0
		private int ReadFromChunks(byte[] buffer, int offset, int size); // 0x0000000181B10A80-0x0000000181B10D40
		public void Write(byte[] buffer, int offset, int size); // 0x0000000181B11060-0x0000000181B11090
		private void InternalWrite(byte[] buffer, ref int offset, int size); // 0x0000000181B10590-0x0000000181B10860
		private State ReadBody(byte[] buffer, ref int offset, int size); // 0x0000000181B10860-0x0000000181B109A0
		private State GetChunkSize(byte[] buffer, ref int offset, int size); // 0x0000000181B102A0-0x0000000181B10590
		private static string RemoveChunkExtension(string input); // 0x0000000181B10FB0-0x0000000181B11000
		private State ReadCRLF(byte[] buffer, ref int offset, int size); // 0x0000000181B109A0-0x0000000181B10A80
		private State ReadTrailer(byte[] buffer, ref int offset, int size); // 0x0000000181B10D40-0x0000000181B10FA0
		private static void ThrowProtocolViolation(string message); // 0x0000000181B11000-0x0000000181B11060
	}
}
