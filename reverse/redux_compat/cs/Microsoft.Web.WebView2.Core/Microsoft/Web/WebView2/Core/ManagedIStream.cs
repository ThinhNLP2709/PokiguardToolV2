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
	internal class ManagedIStream : IStream // TypeDefIndex: 10817
	{
		// Fields
		private Stream _ioStream; // 0x10
		private const int STGTY_STREAM = 2; // Metadata: 0x006A1519
		private const int STGM_READ = 0; // Metadata: 0x006A151A
		private const int STGM_WRITE = 1; // Metadata: 0x006A151B
		private const int STGM_READWRITE = 2; // Metadata: 0x006A151C
		private const int STREAM_SEEK_SET = 0; // Metadata: 0x006A151D
		private const int STREAM_SEEK_CUR = 1; // Metadata: 0x006A151E
		private const int STREAM_SEEK_END = 2; // Metadata: 0x006A151F
		private const int STATFLAG_DEFAULT = 0; // Metadata: 0x006A1520
		private const int STATFLAG_NONAME = 1; // Metadata: 0x006A1521
		private const int STATFLAG_NOOPEN = 2; // Metadata: 0x006A1522
	
		// Constructors
		internal ManagedIStream(Stream ioStream); // 0x00000001813FDCB0-0x00000001813FDD30
	
		// Methods
		void IStream.Read(byte[] buffer, int bufferSize, IntPtr bytesReadPtr); // 0x00000001813FD900-0x00000001813FD970
		void IStream.Seek(long offset, int origin, IntPtr newPositionPtr); // 0x00000001813FD9B0-0x00000001813FDA90
		void IStream.SetSize(long libNewSize); // 0x00000001813FDA90-0x00000001813FDAC0
		void IStream.Stat(out STATSTG streamStats, int grfStatFlag); // 0x00000001813FDAC0-0x00000001813FDC00
		void IStream.Write(byte[] buffer, int bufferSize, IntPtr bytesWrittenPtr); // 0x00000001813FDC40-0x00000001813FDCB0
		void IStream.Clone(out IStream streamCopy); // 0x00000001813FD7E0-0x00000001813FD840
		void IStream.CopyTo(IStream targetStream, long bufferSize, IntPtr buffer, IntPtr bytesWrittenPtr); // 0x00000001813FD880-0x00000001813FD8C0
		void IStream.Commit(int flags); // 0x00000001813FD840-0x00000001813FD880
		void IStream.LockRegion(long offset, long byteCount, int lockType); // 0x00000001813FD8C0-0x00000001813FD900
		void IStream.Revert(); // 0x00000001813FD970-0x00000001813FD9B0
		void IStream.UnlockRegion(long offset, long byteCount, int lockType); // 0x00000001813FDC00-0x00000001813FDC40
	}
}
