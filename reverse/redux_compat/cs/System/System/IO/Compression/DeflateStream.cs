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
	public class DeflateStream : Stream // TypeDefIndex: 8986
	{
		// Fields
		private Stream base_stream; // 0x28
		private CompressionMode mode; // 0x30
		private bool leaveOpen; // 0x34
		private bool disposed; // 0x35
		private DeflateStreamNative native; // 0x38
	
		// Properties
		public override bool CanRead { get; } // 0x0000000181BC81E0-0x0000000181BC8220 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanWrite { get; } // 0x0000000181BC8220-0x0000000181BC8260 
		public override long Length { get; } // 0x0000000181BC8260-0x0000000181BC82A0 
		public override long Position { get; set; } // 0x0000000181BC82A0-0x0000000181BC82E0 0x0000000181BC82E0-0x0000000181BC8320
	
		// Nested types
		private delegate int ReadMethod(byte[] array, int offset, int count); // TypeDefIndex: 8987; 0x0000000180A72B30-0x0000000180A72B50
	
		private delegate void WriteMethod(byte[] array, int offset, int count); // TypeDefIndex: 8988; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		public DeflateStream(Stream stream, CompressionMode mode); // 0x0000000181BC8000-0x0000000181BC8020
		public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen); // 0x0000000181BC8020-0x0000000181BC8040
		internal DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen, int windowsBits); // 0x0000000181BC81C0-0x0000000181BC81E0
		internal DeflateStream(Stream compressedStream, CompressionMode mode, bool leaveOpen, bool gzip); // 0x0000000181BC8040-0x0000000181BC81C0
	
		// Methods
		~DeflateStream(); // 0x00000001815B2680-0x00000001815B2700
		protected override void Dispose(bool disposing); // 0x0000000181BC6FF0-0x0000000181BC70C0
		private int ReadInternal(byte[] array, int offset, int count); // 0x0000000181BC7690-0x0000000181BC77A0
		internal ValueTask<int> ReadAsyncMemory(Memory<byte> destination, CancellationToken cancellationToken); // 0x0000000181BC7570-0x0000000181BC75B0
		internal int ReadCore(Span<byte> destination); // 0x0000000181BC75B0-0x0000000181BC7690
		public override int Read(byte[] array, int offset, int count); // 0x0000000181BC77A0-0x0000000181BC7AC0
		private void WriteInternal(byte[] array, int offset, int count); // 0x0000000181BC7BF0-0x0000000181BC7CF0
		internal ValueTask WriteAsyncMemory(ReadOnlyMemory<byte> source, CancellationToken cancellationToken); // 0x0000000181BC7B40-0x0000000181BC7B80
		internal void WriteCore(ReadOnlySpan<byte> source); // 0x0000000181BC7B80-0x0000000181BC7BF0
		public override void Write(byte[] array, int offset, int count); // 0x0000000181BC7CF0-0x0000000181BC8000
		public override void Flush(); // 0x0000000181BC7430-0x0000000181BC7570
		public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState); // 0x0000000181BC6850-0x0000000181BC6C20
		public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState); // 0x0000000181BC6C20-0x0000000181BC6FF0
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181BC70C0-0x0000000181BC7280
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181BC7280-0x0000000181BC7430
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181BC7AC0-0x0000000181BC7B00
		public override void SetLength(long value); // 0x0000000181BC7B00-0x0000000181BC7B40
	}
}
