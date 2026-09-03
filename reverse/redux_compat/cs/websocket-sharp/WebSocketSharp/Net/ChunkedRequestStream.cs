/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal class ChunkedRequestStream : RequestStream // TypeDefIndex: 13300
	{
		// Fields
		private static readonly int _bufferLength; // 0x00
		private HttpListenerContext _context; // 0x50
		private ChunkStream _decoder; // 0x58
		private bool _disposed; // 0x60
		private bool _noMoreData; // 0x61
	
		// Properties
		internal bool HasRemainingBuffer { get; } // 0x0000000182607790-0x00000001826077C0 
		internal byte[] RemainingBuffer { get; } // 0x00000001826077C0-0x00000001826079C0 
	
		// Constructors
		static ChunkedRequestStream(); // 0x00000001826075F0-0x0000000182607630
		internal ChunkedRequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, HttpListenerContext context); // 0x0000000182607630-0x0000000182607790
	
		// Methods
		private void onRead(IAsyncResult asyncResult); // 0x00000001826079C0-0x0000000182607C40
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000182606F20-0x0000000182607370
		public override void Close(); // 0x0000000182607370-0x0000000182607380
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000182607380-0x00000001826075A0
		public override int Read(byte[] buffer, int offset, int count); // 0x00000001826075A0-0x00000001826075F0
	}
}
