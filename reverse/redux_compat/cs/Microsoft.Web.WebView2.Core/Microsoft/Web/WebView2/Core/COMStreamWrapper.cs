/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	internal class COMStreamWrapper : Stream // TypeDefIndex: 10818
	{
		// Fields
		private IStream _istream; // 0x28
		private IntPtr _mInt64; // 0x30
		private long _size; // 0x38
	
		// Properties
		public override bool CanRead { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool CanSeek { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool CanWrite { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override long Length { get; } // 0x00000001813DE680-0x00000001813DE760 
		public override long Position { get; set; } // 0x00000001813DE760-0x00000001813DE7A0 0x00000001813DE7A0-0x00000001813DE7E0
	
		// Constructors
		public COMStreamWrapper(IStream source); // 0x00000001813DE570-0x00000001813DE680
	
		// Methods
		~COMStreamWrapper(); // 0x00000001813DE040-0x00000001813DE140
		public override void Flush(); // 0x00000001813DE140-0x00000001813DE1F0
		public override int Read(byte[] buffer, int offset, int count); // 0x00000001813DE1F0-0x00000001813DE2D0
		public override long Seek(long offset, SeekOrigin origin); // 0x00000001813DE2D0-0x00000001813DE3E0
		public override void SetLength(long value); // 0x00000001813DE3E0-0x00000001813DE4B0
		public override void Write(byte[] buffer, int offset, int count); // 0x00000001813DE4B0-0x00000001813DE570
	}
}
