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
	internal class RequestStream : Stream // TypeDefIndex: 13285
	{
		// Fields
		private long _bodyLeft; // 0x28
		private int _count; // 0x30
		private bool _disposed; // 0x34
		private byte[] _initialBuffer; // 0x38
		private Stream _innerStream; // 0x40
		private int _offset; // 0x48
	
		// Properties
		internal int Count { get; } // 0x000000018260AD30-0x000000018260AD40 
		internal byte[] InitialBuffer { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
		internal int Offset { get; } // 0x000000018260AD40-0x000000018260AD50 
		public override bool CanRead { get; } // 0x00000001825FCB20-0x00000001825FCB30 
		public override bool CanSeek { get; } // 0x00000001825EF940-0x00000001825EF950 
		public override bool CanWrite { get; } // 0x00000001825EF940-0x00000001825EF950 
		public override long Length { get; } // 0x00000001826137E0-0x0000000182613820 
		public override long Position { get; set; } // 0x0000000182613820-0x0000000182613860 0x0000000182613860-0x00000001826138A0
	
		// Constructors
		internal RequestStream(Stream innerStream, byte[] initialBuffer, int offset, int count, long contentLength); // 0x00000001826136B0-0x0000000182613740
	
		// Methods
		private int fillFromInitialBuffer(byte[] buffer, int offset, int count); // 0x0000000182613740-0x00000001826137E0
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000182612DB0-0x0000000182613100
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000182613100-0x0000000182613140
		public override void Close(); // 0x0000000182613140-0x0000000182613150
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000182613150-0x0000000182613330
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000182613330-0x0000000182613370
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000182613370-0x00000001826135F0
		public override long Seek(long offset, SeekOrigin origin); // 0x00000001826135F0-0x0000000182613630
		public override void SetLength(long value); // 0x0000000182613630-0x0000000182613670
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000182613670-0x00000001826136B0
	}
}
