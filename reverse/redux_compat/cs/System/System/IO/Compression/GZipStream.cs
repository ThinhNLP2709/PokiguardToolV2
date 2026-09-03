/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.IO.Compression
{
	public class GZipStream : Stream // TypeDefIndex: 8985
	{
		// Fields
		private DeflateStream _deflateStream; // 0x28
	
		// Properties
		public override bool CanRead { get; } // 0x0000000181BC9E10-0x0000000181BC9E30 
		public override bool CanWrite { get; } // 0x0000000181BC9E50-0x0000000181BC9E70 
		public override bool CanSeek { get; } // 0x0000000181BC9E30-0x0000000181BC9E50 
		public override long Length { get; } // 0x0000000181BC9E70-0x0000000181BC9EC0 
		public override long Position { get; set; } // 0x0000000181BC9EC0-0x0000000181BC9F10 0x0000000181BC9F10-0x0000000181BC9F60
	
		// Constructors
		public GZipStream(Stream stream, CompressionMode mode); // 0x0000000181BC9CA0-0x0000000181BC9D50
		public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen); // 0x0000000181BC9D50-0x0000000181BC9E10
	
		// Methods
		public override void Flush(); // 0x0000000181BC9620-0x0000000181BC9650
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181BC9950-0x0000000181BC99A0
		public override void SetLength(long value); // 0x0000000181BC99A0-0x0000000181BC99F0
		public override int ReadByte(); // 0x0000000181BC9760-0x0000000181BC9790
		public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState); // 0x0000000181BC9380-0x0000000181BC9430
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181BC95B0-0x0000000181BC95F0
		public override int Read(byte[] array, int offset, int count); // 0x0000000181BC9790-0x0000000181BC97D0
		public override int Read(Span<byte> buffer); // 0x0000000181BC97D0-0x0000000181BC9950
		public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState); // 0x0000000181BC9430-0x0000000181BC94E0
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181475360-0x0000000181475370
		public override void Write(byte[] array, int offset, int count); // 0x0000000181BC9B60-0x0000000181BC9BA0
		public override void Write(ReadOnlySpan<byte> buffer); // 0x0000000181BC9BA0-0x0000000181BC9CA0
		protected override void Dispose(bool disposing); // 0x0000000181BC9500-0x0000000181BC95B0
		public override Task<int> ReadAsync(byte[] array, int offset, int count, CancellationToken cancellationToken); // 0x0000000181BC9650-0x0000000181BC9690
		public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default); // 0x0000000181BC9690-0x0000000181BC9760
		public override Task WriteAsync(byte[] array, int offset, int count, CancellationToken cancellationToken); // 0x0000000181BC9A50-0x0000000181BC9A90
		public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default); // 0x0000000181BC9A90-0x0000000181BC9B60
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x0000000181BC95F0-0x0000000181BC9620
		private void CheckDeflateStream(); // 0x0000000181BC94E0-0x0000000181BC9500
		private static void ThrowStreamClosedException(); // 0x0000000181BC99F0-0x0000000181BC9A50
	}
}
