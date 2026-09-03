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
	internal class Chunk // TypeDefIndex: 13298
	{
		// Fields
		private byte[] _data; // 0x10
		private int _offset; // 0x18
	
		// Properties
		public int ReadLeft { get; } // 0x0000000182606F00-0x0000000182606F20 
	
		// Constructors
		public Chunk(byte[] data); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public int Read(byte[] buffer, int offset, int count); // 0x0000000182606E90-0x0000000182606F00
	}
}
