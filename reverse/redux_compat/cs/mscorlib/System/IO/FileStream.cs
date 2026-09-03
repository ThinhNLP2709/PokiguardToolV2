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
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[ComVisible(true)]
	public class FileStream : Stream // TypeDefIndex: 3699
	{
		// Fields
		private static byte[] buf_recycle; // 0x00
		private static readonly object buf_recycle_lock; // 0x08
		private byte[] buf; // 0x28
		private string name; // 0x30
		private SafeFileHandle safeHandle; // 0x38
		private bool isExposed; // 0x40
		private long append_startpos; // 0x48
		private FileAccess access; // 0x50
		private bool owner; // 0x54
		private bool async; // 0x55
		private bool canseek; // 0x56
		private bool anonymous; // 0x57
		private bool buf_dirty; // 0x58
		private int buf_size; // 0x5C
		private int buf_length; // 0x60
		private int buf_offset; // 0x64
		private long buf_start; // 0x68
	
		// Properties
		public override bool CanRead { get; } // 0x00000001815C4740-0x00000001815C4760 
		public override bool CanWrite { get; } // 0x00000001815C4770-0x00000001815C4790 
		public override bool CanSeek { get; } // 0x00000001815C4760-0x00000001815C4770 
		public virtual string Name { get; } // 0x000000018031E110-0x000000018031E120 
		public override long Length { get; } // 0x00000001815C4790-0x00000001815C4930 
		public override long Position { get; set; } // 0x00000001815C4930-0x00000001815C4AE0 0x00000001815C4B20-0x00000001815C4BC0
		public virtual SafeFileHandle SafeFileHandle { get; } // 0x00000001815C4AE0-0x00000001815C4B20 
	
		// Nested types
		private delegate int ReadDelegate(byte[] buffer, int offset, int count); // TypeDefIndex: 3700; 0x0000000180A72B30-0x0000000180A72B50
	
		private delegate void WriteDelegate(byte[] buffer, int offset, int count); // TypeDefIndex: 3701; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		internal FileStream(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize, bool isAsync, bool isConsoleWrapper); // 0x00000001815C3C30-0x00000001815C3DD0
		public FileStream(string path, FileMode mode, FileAccess access, FileShare share); // 0x00000001815C4680-0x00000001815C46B0
		public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize); // 0x00000001815C3BF0-0x00000001815C3C30
		public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync); // 0x00000001815C46B0-0x00000001815C4700
		public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options); // 0x00000001815C4700-0x00000001815C4740
		internal FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool anonymous, FileOptions options); // 0x00000001815C3DD0-0x00000001815C4680
		static FileStream(); // 0x00000001815C3B80-0x00000001815C3BF0
	
		// Methods
		private void Init(SafeFileHandle safeHandle, FileAccess access, bool ownsHandle, int bufferSize, bool isAsync, bool isConsoleWrapper); // 0x00000001815C2360-0x00000001815C26B0
		private void ExposeHandle(); // 0x00000001815C1A00-0x00000001815C1A30
		public override int ReadByte(); // 0x00000001815C26C0-0x00000001815C2830
		public override void WriteByte(byte value); // 0x00000001815C3470-0x00000001815C35E0
		public override int Read([In, Out] byte[] array, int offset, int count); // 0x00000001815C2AE0-0x00000001815C2E90
		private int ReadInternal(byte[] dest, int offset, int count); // 0x00000001815C2960-0x00000001815C2A30
		public override IAsyncResult BeginRead(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject); // 0x00000001815C0A20-0x00000001815C0E40
		public override int EndRead(IAsyncResult asyncResult); // 0x00000001815C1640-0x00000001815C1830
		public override void Write(byte[] array, int offset, int count); // 0x00000001815C38B0-0x00000001815C3B80
		private void WriteInternal(byte[] src, int offset, int count); // 0x00000001815C35E0-0x00000001815C3840
		public override IAsyncResult BeginWrite(byte[] array, int offset, int numBytes, AsyncCallback userCallback, object stateObject); // 0x00000001815C0E40-0x00000001815C1360
		public override void EndWrite(IAsyncResult asyncResult); // 0x00000001815C1830-0x00000001815C1A00
		public override long Seek(long offset, SeekOrigin origin); // 0x00000001815C2ED0-0x00000001815C31D0
		public override void SetLength(long value); // 0x00000001815C31D0-0x00000001815C3460
		public override void Flush(); // 0x00000001815C1EB0-0x00000001815C1F30
		~FileStream(); // 0x00000001815B2680-0x00000001815B2700
		protected override void Dispose(bool disposing); // 0x00000001815C1360-0x00000001815C1640
		public override Task FlushAsync(CancellationToken cancellationToken); // 0x00000001815C1A30-0x00000001815C1CA0
		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815C26B0-0x00000001815C26C0
		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken); // 0x00000001815C3460-0x00000001815C3470
		private int ReadSegment(byte[] dest, int dest_offset, int count); // 0x00000001815C2A30-0x00000001815C2AE0
		private int WriteSegment(byte[] src, int src_offset, int count); // 0x00000001815C3840-0x00000001815C38B0
		private void FlushBuffer(); // 0x00000001815C1CB0-0x00000001815C1EB0
		private void FlushBufferIfDirty(); // 0x00000001815C1CA0-0x00000001815C1CB0
		private void RefillBuffer(); // 0x00000001815C2E90-0x00000001815C2ED0
		private int ReadData(SafeHandle safeHandle, byte[] buf, int offset, int count); // 0x00000001815C2830-0x00000001815C2960
		private void InitBuffer(int size, bool isZeroSize); // 0x00000001815C20F0-0x00000001815C2360
		private string GetSecureFileName(string filename); // 0x00000001815C2020-0x00000001815C20F0
		private string GetSecureFileName(string filename, bool full); // 0x00000001815C1F30-0x00000001815C2020
	}
}
