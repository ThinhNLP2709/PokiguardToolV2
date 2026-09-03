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
	[Serializable]
	public class MemoryStream : Stream // TypeDefIndex: 3649
	{
		// Fields
		private byte[] _buffer; // 0x28
		private int _origin; // 0x30
		private int _position; // 0x34
		private int _length; // 0x38
		private int _capacity; // 0x3C
		private bool _expandable; // 0x40
		private bool _writable; // 0x41
		private bool _exposable; // 0x42
		private bool _isOpen; // 0x43
		[NonSerialized]
		private Task<int> _lastReadTask; // 0x48
	
		// Properties
		public override bool CanRead { get; } // 0x00000001815B1180-0x00000001815B1190 
		public override bool CanSeek { get; } // 0x00000001815B1180-0x00000001815B1190 
		public override bool CanWrite { get; } // 0x00000001815B1190-0x00000001815B11A0 
		public virtual int Capacity { get; set; } // 0x00000001815B11A0-0x00000001815B11E0 0x00000001815B1280-0x00000001815B1430
		public override long Length { get; } // 0x00000001815B11E0-0x00000001815B1230 
		public override long Position { get; set; } // 0x00000001815B1230-0x00000001815B1280 0x00000001815B1430-0x00000001815B1550
	
		// Constructors
		public MemoryStream(); // 0x00000001815B0F60-0x00000001815B1030
		public MemoryStream(int capacity); // 0x00000001815B1030-0x00000001815B1180
		public MemoryStream(byte[] buffer); // 0x00000001815B0E90-0x00000001815B0F60
		public MemoryStream(byte[] buffer, bool writable); // 0x00000001815B0DB0-0x00000001815B0E90
		public MemoryStream(byte[] buffer, int index, int count); // 0x00000001815B0B70-0x00000001815B0BA0
		public MemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible); // 0x00000001815B0BA0-0x00000001815B0DB0
	
		// Methods
		private void EnsureNotClosed(); // 0x00000001815AECB0-0x00000001815AECF0
		private void EnsureWriteable(); // 0x00000001815AECF0-0x00000001815AED40
		protected override void Dispose(bool disposing); // 0x00000001815AEB40-0x00000001815AEBF0
		private bool EnsureCapacity(int value); // 0x00000001815AEBF0-0x00000001815AECB0
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x00000001815AED40-0x00000001815AEE90
		public virtual byte[] GetBuffer(); // 0x00000001815AEE90-0x00000001815AEF00
		internal byte[] InternalGetBuffer(); // 0x000000018033D240-0x000000018033D250
		internal int InternalGetPosition(); // 0x000000018033D0F0-0x000000018033D100
		internal int InternalReadInt32(); // 0x00000001815AEF60-0x00000001815AF050
		internal int InternalEmulateRead(int count); // 0x00000001815AEF00-0x00000001815AEF60
		public override int Read(byte[] buffer, int offset, int count); // 0x00000001815AF700-0x00000001815AF980
		public override int Read(Span<byte> buffer); // 0x00000001815AF980-0x00000001815AFB20
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815AF330-0x00000001815AF680
		public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815AF050-0x00000001815AF330
		public override int ReadByte(); // 0x00000001815AF680-0x00000001815AF700
		public override long Seek(long offset, SeekOrigin loc); // 0x00000001815AFB20-0x00000001815AFD70
		public override void SetLength(long value); // 0x00000001815AFD70-0x00000001815AFEE0
		public virtual byte[] ToArray(); // 0x00000001815AFEE0-0x00000001815AFFC0
		public override void Write(byte[] buffer, int offset, int count); // 0x00000001815B0860-0x00000001815B0B70
		public override void Write(ReadOnlySpan<byte> buffer); // 0x00000001815B0640-0x00000001815B0860
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815B0230-0x00000001815B0520
		public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default); // 0x00000001815AFFC0-0x00000001815B0230
		public override void WriteByte(byte value); // 0x00000001815B0520-0x00000001815B0640
	}
}
