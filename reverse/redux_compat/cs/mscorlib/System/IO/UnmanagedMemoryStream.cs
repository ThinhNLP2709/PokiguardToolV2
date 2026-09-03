/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	public class UnmanagedMemoryStream : Stream // TypeDefIndex: 3671
	{
		// Fields
		private SafeBuffer _buffer; // 0x28
		private unsafe byte* _mem; // 0x30
		private long _length; // 0x38
		private long _capacity; // 0x40
		private long _position; // 0x48
		private long _offset; // 0x50
		private FileAccess _access; // 0x58
		internal bool _isOpen; // 0x5C
		private Task<int> _lastReadTask; // 0x60
	
		// Properties
		public override bool CanRead { get; } // 0x00000001815D7CF0-0x00000001815D7D00 
		public override bool CanSeek { get; } // 0x00000001815D7D00-0x00000001815D7D10 
		public override bool CanWrite { get; } // 0x00000001815D7D10-0x00000001815D7D30 
		public override long Length { get; } // 0x00000001815D7D30-0x00000001815D7D80 
		public override long Position { get; set; } // 0x00000001815D7E70-0x00000001815D7ED0 0x00000001815D7ED0-0x00000001815D7F90
		[CLSCompliant(false)]
		public unsafe byte* PositionPointer { get; } // 0x00000001815D7D80-0x00000001815D7E70 
	
		// Constructors
		protected UnmanagedMemoryStream(); // 0x00000001815D7CB0-0x00000001815D7CF0
		[CLSCompliant(false)]
		public unsafe UnmanagedMemoryStream(byte* pointer, long length, long capacity, FileAccess access); // 0x00000001815D7C40-0x00000001815D7CB0
	
		// Methods
		[CLSCompliant(false)]
		protected unsafe void Initialize(byte* pointer, long length, long capacity, FileAccess access); // 0x00000001815D5BB0-0x00000001815D5E40
		protected override void Dispose(bool disposing); // 0x00000001815D5970-0x00000001815D5980
		private void EnsureNotClosed(); // 0x00000001815D5980-0x00000001815D59C0
		private void EnsureReadable(); // 0x00000001815D59C0-0x00000001815D5A10
		private void EnsureWriteable(); // 0x00000001815D5A10-0x00000001815D5A60
		public override void Flush(); // 0x00000001815D5980-0x00000001815D59C0
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x00000001815D5A60-0x00000001815D5BB0
		public override int Read(byte[] buffer, int offset, int count); // 0x00000001815D68C0-0x00000001815D6AC0
		public override int Read(Span<byte> buffer); // 0x00000001815D6840-0x00000001815D68C0
		internal int ReadCore(Span<byte> buffer); // 0x00000001815D65A0-0x00000001815D6840
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815D60F0-0x00000001815D6400
		public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815D5E40-0x00000001815D60F0
		public override int ReadByte(); // 0x00000001815D6400-0x00000001815D65A0
		public override long Seek(long offset, SeekOrigin loc); // 0x00000001815D6AC0-0x00000001815D6C90
		public override void SetLength(long value); // 0x00000001815D6C90-0x00000001815D6E70
		public override void Write(byte[] buffer, int offset, int count); // 0x00000001815D79A0-0x00000001815D7BC0
		public override void Write(ReadOnlySpan<byte> buffer); // 0x00000001815D7BC0-0x00000001815D7C40
		internal void WriteCore(ReadOnlySpan<byte> buffer); // 0x00000001815D7630-0x00000001815D79A0
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815D6E70-0x00000001815D7120
		public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815D7120-0x00000001815D7360
		public override void WriteByte(byte value); // 0x00000001815D7360-0x00000001815D7630
	}
}
