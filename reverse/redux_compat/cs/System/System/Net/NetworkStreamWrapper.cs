/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class NetworkStreamWrapper : Stream // TypeDefIndex: 9028
	{
		// Fields
		private TcpClient _client; // 0x28
		private NetworkStream _networkStream; // 0x30
	
		// Properties
		protected bool UsingSecureStream { get; } // 0x0000000181BF3BA0-0x0000000181BF3C20 
		internal IPAddress ServerAddress { get; } // 0x0000000181BF3AF0-0x0000000181BF3B80 
		internal Socket Socket { get; } // 0x0000000181BF3B80-0x0000000181BF3BA0 
		internal NetworkStream NetworkStream { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public override bool CanRead { get; } // 0x0000000181506D00-0x0000000181506D30 
		public override bool CanSeek { get; } // 0x00000001815D15A0-0x00000001815D15D0 
		public override bool CanWrite { get; } // 0x00000001815D16E0-0x00000001815D1710 
		public override bool CanTimeout { get; } // 0x0000000181BE71F0-0x0000000181BE7220 
		public override int ReadTimeout { get; set; } // 0x0000000181BE7220-0x0000000181BE7250 0x0000000181506CD0-0x0000000181506D00
		public override int WriteTimeout { get; set; } // 0x0000000181BE7250-0x0000000181BE7280 0x0000000181508950-0x0000000181508980
		public override long Length { get; } // 0x00000001815D1AC0-0x00000001815D1AF0 
		public override long Position { get; set; } // 0x00000001815D1AF0-0x00000001815D1B20 0x0000000181506B30-0x0000000181506B60
	
		// Constructors
		internal NetworkStreamWrapper(TcpClient client); // 0x0000000181BF3A80-0x0000000181BF3AF0
	
		// Methods
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181BF39F0-0x0000000181BF3A20
		public override int Read(byte[] buffer, int offset, int size); // 0x0000000181BF39C0-0x0000000181BF39F0
		public override void Write(byte[] buffer, int offset, int size); // 0x0000000181BF3A50-0x0000000181BF3A80
		protected override void Dispose(bool disposing); // 0x0000000181BF38A0-0x0000000181BF3960
		internal void CloseSocket(); // 0x0000000181BF3820-0x0000000181BF3860
		public void Close(int timeout); // 0x0000000181BF3860-0x0000000181BF38A0
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181BF37A0-0x0000000181BF37E0
		public override int EndRead(IAsyncResult asyncResult); // 0x00000001815088A0-0x00000001815088D0
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181BF3990-0x0000000181BF39C0
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181BF37E0-0x0000000181BF3820
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181BF3960-0x0000000181BF3990
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x0000000181BF3A20-0x0000000181BF3A50
		public override void Flush(); // 0x0000000181BE6A90-0x0000000181BE6AC0
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x00000001815089B0-0x00000001815089E0
		public override void SetLength(long value); // 0x0000000181BE6C30-0x0000000181BE6C60
		internal void SetSocketTimeoutOption(int timeout); // 0x0000000181BE6C60-0x0000000181BE6CC0
	}
}
