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
	internal class ResponseStream : Stream // TypeDefIndex: 13286
	{
		// Fields
		private MemoryStream _bodyBuffer; // 0x28
		private static readonly byte[] _crlf; // 0x00
		private bool _disposed; // 0x30
		private Stream _innerStream; // 0x38
		private static readonly byte[] _lastChunk; // 0x08
		private static readonly int _maxHeadersLength; // 0x10
		private HttpListenerResponse _response; // 0x40
		private bool _sendChunked; // 0x48
		private Action<byte[], int, int> _write; // 0x50
		private Action<byte[], int, int> _writeBody; // 0x58
		private Action<byte[], int, int> _writeChunked; // 0x60
	
		// Properties
		public override bool CanRead { get; } // 0x00000001825EF940-0x00000001825EF950 
		public override bool CanSeek { get; } // 0x00000001825EF940-0x00000001825EF950 
		public override bool CanWrite { get; } // 0x0000000182614960-0x0000000182614970 
		public override long Length { get; } // 0x0000000182614970-0x00000001826149B0 
		public override long Position { get; set; } // 0x00000001826149B0-0x00000001826149F0 0x00000001826149F0-0x0000000182614A30
	
		// Constructors
		static ResponseStream(); // 0x0000000182613E70-0x0000000182613F80
		internal ResponseStream(Stream innerStream, HttpListenerResponse response, bool ignoreWriteExceptions); // 0x0000000182613F80-0x0000000182614140
	
		// Methods
		private bool flush(bool closing); // 0x0000000182614840-0x00000001826148E0
		private void flushBody(bool closing); // 0x0000000182614140-0x0000000182614430
		private bool flushHeaders(); // 0x0000000182614430-0x0000000182614840
		private static byte[] getChunkSizeBytes(int size); // 0x00000001826148E0-0x0000000182614960
		private void writeChunked(byte[] buffer, int offset, int count); // 0x0000000182614BD0-0x0000000182614D50
		private void writeChunkedWithoutThrowingException(byte[] buffer, int offset, int count); // 0x0000000182614A30-0x0000000182614BD0
		private void writeWithoutThrowingException(byte[] buffer, int offset, int count); // 0x0000000182614D50-0x0000000182614D90
		internal void Close(bool force); // 0x0000000182613990-0x0000000182613B20
		internal void InternalWrite(byte[] buffer, int offset, int count); // 0x0000000182613CD0-0x0000000182613D00
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001826138A0-0x00000001826138E0
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x00000001826138E0-0x0000000182613990
		public override void Close(); // 0x0000000182613B20-0x0000000182613B30
		protected override void Dispose(bool disposing); // 0x0000000182613B30-0x0000000182613B40
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000182613B40-0x0000000182613B80
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000182613B80-0x0000000182613C30
		public override void Flush(); // 0x0000000182613C30-0x0000000182613CD0
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000182613D00-0x0000000182613D40
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000182613D40-0x0000000182613D80
		public override void SetLength(long value); // 0x0000000182613D80-0x0000000182613DC0
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000182613DC0-0x0000000182613E70
	}
}
