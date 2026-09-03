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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class FtpDataStream : Stream, ICloseEx // TypeDefIndex: 9017
	{
		// Fields
		private FtpWebRequest _request; // 0x28
		private NetworkStream _networkStream; // 0x30
		private bool _writeable; // 0x38
		private bool _readable; // 0x39
		private bool _isFullyRead; // 0x3A
		private bool _closing; // 0x3B
	
		// Properties
		public override bool CanRead { get; } // 0x00000001814CFF30-0x00000001814CFF40 
		public override bool CanSeek { get; } // 0x00000001815D15A0-0x00000001815D15D0 
		public override bool CanWrite { get; } // 0x0000000180476380-0x0000000180476390 
		public override long Length { get; } // 0x00000001815D1AC0-0x00000001815D1AF0 
		public override long Position { get; set; } // 0x00000001815D1AF0-0x00000001815D1B20 0x0000000181506B30-0x0000000181506B60
		public override bool CanTimeout { get; } // 0x0000000181BE71F0-0x0000000181BE7220 
		public override int ReadTimeout { get; set; } // 0x0000000181BE7220-0x0000000181BE7250 0x0000000181506CD0-0x0000000181506D00
		public override int WriteTimeout { get; set; } // 0x0000000181BE7250-0x0000000181BE7280 0x0000000181508950-0x0000000181508980
	
		// Constructors
		internal FtpDataStream(NetworkStream networkStream, FtpWebRequest request, TriState writeOnly); // 0x0000000181BE7100-0x0000000181BE71F0
	
		// Methods
		protected override void Dispose(bool disposing); // 0x0000000181BE6780-0x0000000181BE6850
		void ICloseEx.CloseEx(CloseExState closeState); // 0x0000000181BE6CC0-0x0000000181BE7060
		private void CheckError(); // 0x0000000181BE6730-0x0000000181BE6780
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181BE6B90-0x0000000181BE6C30
		public override int Read(byte[] buffer, int offset, int size); // 0x0000000181BE6AC0-0x0000000181BE6B90
		public override void Write(byte[] buffer, int offset, int size); // 0x0000000181BE7060-0x0000000181BE7100
		private void AsyncReadCallback(IAsyncResult ar); // 0x0000000181BE6380-0x0000000181BE64F0
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181BE64F0-0x0000000181BE6670
		public override int EndRead(IAsyncResult ar); // 0x0000000181BE6850-0x0000000181BE69D0
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181BE6670-0x0000000181BE6730
		public override void EndWrite(IAsyncResult asyncResult); // 0x0000000181BE69D0-0x0000000181BE6A90
		public override void Flush(); // 0x0000000181BE6A90-0x0000000181BE6AC0
		public override void SetLength(long value); // 0x0000000181BE6C30-0x0000000181BE6C60
		internal void SetSocketTimeoutOption(int timeout); // 0x0000000181BE6C60-0x0000000181BE6CC0
	}
}
