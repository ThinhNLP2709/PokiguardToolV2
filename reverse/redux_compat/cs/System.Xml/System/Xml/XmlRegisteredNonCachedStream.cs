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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlRegisteredNonCachedStream : Stream // TypeDefIndex: 6875
	{
		// Fields
		protected Stream stream; // 0x28
		private XmlDownloadManager downloadManager; // 0x30
		private string host; // 0x38
	
		// Properties
		public override bool CanRead { get; } // 0x0000000180DFE670-0x0000000180DFE6A0 
		public override bool CanSeek { get; } // 0x0000000181AA6620-0x0000000181AA6650 
		public override bool CanWrite { get; } // 0x0000000181AA6650-0x0000000181AA6680 
		public override long Length { get; } // 0x0000000181813E90-0x0000000181813EC0 
		public override long Position { get; set; } // 0x0000000181813FE0-0x0000000181814010 0x0000000181AA6680-0x0000000181AA66B0
	
		// Constructors
		internal XmlRegisteredNonCachedStream(Stream stream, XmlDownloadManager downloadManager, string host); // 0x0000000181AA6590-0x0000000181AA6620
	
		// Methods
		~XmlRegisteredNonCachedStream(); // 0x0000000181AA6430-0x0000000181AA64D0
		protected override void Dispose(bool disposing); // 0x0000000181AA62D0-0x0000000181AA6400
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181AA6250-0x0000000181AA6290
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state); // 0x0000000181AA6290-0x0000000181AA62D0
		public override int EndRead(IAsyncResult asyncResult); // 0x0000000181AA6400-0x0000000181AA6430
		public override void EndWrite(IAsyncResult asyncResult); // 0x00000001815B2DE0-0x00000001815B2E10
		public override void Flush(); // 0x0000000181812060-0x0000000181812090
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000181AA6500-0x0000000181AA6530
		public override int ReadByte(); // 0x0000000181AA64D0-0x0000000181AA6500
		public override long Seek(long offset, SeekOrigin origin); // 0x0000000181AA6530-0x0000000181AA6560
		public override void SetLength(long value); // 0x00000001818136A0-0x00000001818136D0
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000181AA6560-0x0000000181AA6590
		public override void WriteByte(byte value); // 0x0000000181A35B20-0x0000000181A35B50
	}
}
