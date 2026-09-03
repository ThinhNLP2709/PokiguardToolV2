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

namespace System.Net.Sockets
{
	public class NetworkStream : Stream // TypeDefIndex: 9210
	{
		// Fields
		private readonly Socket _streamSocket; // 0x28
		private readonly bool _ownsSocket; // 0x30
		private bool _readable; // 0x31
		private bool _writeable; // 0x32
		private int _closeTimeout; // 0x34
		private bool _cleanedUp; // 0x38
		private int _currentReadTimeout; // 0x3C
		private int _currentWriteTimeout; // 0x40
	
		// Properties
		public override bool CanRead { get; } // 0x0000000180634F10-0x0000000180634F20 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanWrite { get; } // 0x0000000181B14850-0x0000000181B14860 
		public override bool CanTimeout { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override int ReadTimeout { get; set; } // 0x0000000181B297F0-0x0000000181B29850 0x0000000181B29900-0x0000000181B299A0
		public override int WriteTimeout { get; set; } // 0x0000000181B29850-0x0000000181B298B0 0x0000000181B299A0-0x0000000181B29A40
		public override long Length { get; } // 0x0000000181B29750-0x0000000181B297A0 
		public override long Position { get; set; } // 0x0000000181B297A0-0x0000000181B297F0 0x0000000181B298B0-0x0000000181B29900
		internal Socket InternalSocket { get; } // 0x0000000181B296B0-0x0000000181B29750 
	
		// Constructors
		public NetworkStream(Socket socket); // 0x0000000181B29480-0x0000000181B294A0
		public NetworkStream(Socket socket, bool ownsSocket); // 0x0000000181B294A0-0x0000000181B294D0
		public NetworkStream(Socket socket, FileAccess access, bool ownsSocket); // 0x0000000181B294D0-0x0000000181B296B0
	
		// Methods
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181B286A0-0x0000000181B286F0
		public override int Read(byte[] buffer, int offset, int size); // 0x0000000181B28370-0x0000000181B286A0
		public override int Read(Span<byte> destination); // 0x0000000181B28080-0x0000000181B28370
		public override int ReadByte(); // 0x0000000181B28020-0x0000000181B28080
		public override void Write(byte[] buffer, int offset, int size); // 0x0000000181B29150-0x0000000181B29480
		public override void Write(ReadOnlySpan<byte> source); // 0x0000000181B28EC0-0x0000000181B29150
		public override void WriteByte(byte value); // 0x0000000181B28E70-0x0000000181B28EC0
		public void Close(int timeout); // 0x0000000181B27570-0x0000000181B275E0
		protected override void Dispose(bool disposing); // 0x0000000181B275E0-0x0000000181B276D0
		~NetworkStream(); // 0x00000001815B2680-0x00000001815B2700
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181B26F90-0x0000000181B27280
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181B276D0-0x0000000181B27860
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181B27280-0x0000000181B27570
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181B27860-0x0000000181B279F0
		public override Task<int> ReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B27A80-0x0000000181B27E10
		public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken); // 0x0000000181B27E10-0x0000000181B28020
		public override Task WriteAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B288D0-0x0000000181B28C60
		public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken); // 0x0000000181B28C60-0x0000000181B28E70
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x0000000181B279F0-0x0000000181B27A80
		public override void SetLength(long value); // 0x0000000181B286F0-0x0000000181B28740
		internal void SetSocketTimeoutOption(SocketShutdown mode, int timeout, bool silent); // 0x0000000181B28740-0x0000000181B288D0
	}
}
