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

namespace System.Net
{
	internal abstract class WebConnectionStream : Stream // TypeDefIndex: 9164
	{
		// Fields
		protected bool closed; // 0x28
		private bool disposed; // 0x29
		private object locker; // 0x30
		private int read_timeout; // 0x38
		private int write_timeout; // 0x3C
		[CompilerGenerated]
		private readonly HttpWebRequest _Request_k__BackingField; // 0x40
		[CompilerGenerated]
		private readonly WebConnection _Connection_k__BackingField; // 0x48
		[CompilerGenerated]
		private readonly WebOperation _Operation_k__BackingField; // 0x50
	
		// Properties
		internal HttpWebRequest Request { [CompilerGenerated] get; } // 0x0000000180377940-0x0000000180377950 
		internal WebConnection Connection { [CompilerGenerated] get; } // 0x00000001803272B0-0x00000001803272C0 
		internal WebOperation Operation { [CompilerGenerated] get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal ServicePoint ServicePoint { get; } // 0x0000000181B20340-0x0000000181B20360 
		public override bool CanTimeout { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override int ReadTimeout { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x0000000181B203B0-0x0000000181B20420
		public override int WriteTimeout { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x0000000181B20420-0x0000000181B20490
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override long Length { get; } // 0x0000000181B202A0-0x0000000181B202F0 
		public override long Position { get; set; } // 0x0000000181B202F0-0x0000000181B20340 0x0000000181B20360-0x0000000181B203B0
	
		// Constructors
		protected WebConnectionStream(WebConnection cnc, WebOperation operation); // 0x0000000181B201D0-0x0000000181B202A0
	
		// Methods
		protected Exception GetException(Exception e); // 0x0000000181B1FAC0-0x0000000181B1FC30
		protected abstract bool TryReadFromBufferedContent(byte[] buffer, int offset, int count, out int result);
		public override int Read(byte[] buffer, int offset, int count); // 0x0000000181B1FC40-0x0000000181B1FEF0
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback cb, object state); // 0x0000000181B1F370-0x0000000181B1F5F0
		public override int EndRead(IAsyncResult r); // 0x0000000181B1F840-0x0000000181B1F910
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback cb, object state); // 0x0000000181B1F5F0-0x0000000181B1F820
		public override void EndWrite(IAsyncResult r); // 0x0000000181B1F910-0x0000000181B1F9C0
		public override void Write(byte[] buffer, int offset, int count); // 0x0000000181B1FF90-0x0000000181B201D0
		public override void Flush(); // 0x00000001802E76C0-0x00000001802E76D0
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x0000000181B1F9C0-0x0000000181B1FAC0
		internal void InternalClose(); // 0x0000000181B1FC30-0x0000000181B1FC40
		protected abstract void Close_internal(ref bool disposed);
		public override void Close(); // 0x0000000181B1F820-0x0000000181B1F840
		public override long Seek(long a, SeekOrigin b); // 0x0000000181B1FEF0-0x0000000181B1FF40
		public override void SetLength(long a); // 0x0000000181B1FF40-0x0000000181B1FF90
	}
}
