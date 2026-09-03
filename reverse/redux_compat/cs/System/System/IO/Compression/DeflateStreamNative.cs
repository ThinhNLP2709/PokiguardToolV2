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
using Mono.Util;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.IO.Compression
{
	internal class DeflateStreamNative // TypeDefIndex: 8989
	{
		// Fields
		private UnmanagedReadOrWrite feeder; // 0x10
		private Stream base_stream; // 0x18
		private SafeDeflateStreamHandle z_stream; // 0x20
		private GCHandle data; // 0x28
		private bool disposed; // 0x30
		private byte[] io_buffer; // 0x38
		private Exception last_error; // 0x40
	
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int UnmanagedReadOrWrite(IntPtr buffer, int length, IntPtr data); // TypeDefIndex: 8990; 0x0000000180A72B30-0x0000000180A72B50
	
		private sealed class SafeDeflateStreamHandle : SafeHandle // TypeDefIndex: 8991
		{
			// Properties
			public override bool IsInvalid { get; } // 0x00000001813DEED0-0x00000001813DEEE0 
	
			// Constructors
			private SafeDeflateStreamHandle(); // 0x0000000181453050-0x0000000181453060
	
			// Methods
			protected override bool ReleaseHandle(); // 0x0000000181BD4430-0x0000000181BD4450
		}
	
		// Constructors
		private DeflateStreamNative(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static DeflateStreamNative Create(Stream compressedStream, CompressionMode mode, bool gzip); // 0x0000000181BC5BA0-0x0000000181BC5E20
		~DeflateStreamNative(); // 0x0000000181BC5F20-0x0000000181BC5F90
		public void Dispose(bool disposing); // 0x0000000181BC5E20-0x0000000181BC5F20
		public void Flush(); // 0x0000000181BC5F90-0x0000000181BC6040
		public int ReadZStream(IntPtr buffer, int length); // 0x0000000181BC60B0-0x0000000181BC6170
		public void WriteZStream(IntPtr buffer, int length); // 0x0000000181BC6710-0x0000000181BC67D0
		[MonoPInvokeCallback(typeof(UnmanagedReadOrWrite))]
		private static int UnmanagedRead(IntPtr buffer, int length, IntPtr data); // 0x0000000181BC61F0-0x0000000181BC6300
		private int UnmanagedRead(IntPtr buffer, int length); // 0x0000000181BC6300-0x0000000181BC6460
		[MonoPInvokeCallback(typeof(UnmanagedReadOrWrite))]
		private static int UnmanagedWrite(IntPtr buffer, int length, IntPtr data); // 0x0000000181BC6600-0x0000000181BC6710
		private int UnmanagedWrite(IntPtr buffer, int length); // 0x0000000181BC6460-0x0000000181BC6600
		private void CheckResult(int result, string where); // 0x0000000181BC59B0-0x0000000181BC5B00
		private static extern SafeDeflateStreamHandle CreateZStream(CompressionMode compress, bool gzip, UnmanagedReadOrWrite feeder, IntPtr data); // 0x0000000181BC5B10-0x0000000181BC5BA0
		private static extern int CloseZStream(IntPtr stream); // 0x0000000181BC5B00-0x0000000181BC5B10
		private static extern int Flush(SafeDeflateStreamHandle stream); // 0x0000000181BC6040-0x0000000181BC60B0
		private static extern int ReadZStream(SafeDeflateStreamHandle stream, IntPtr buffer, int length); // 0x0000000181BC6170-0x0000000181BC61F0
		private static extern int WriteZStream(SafeDeflateStreamHandle stream, IntPtr buffer, int length); // 0x0000000181BC67D0-0x0000000181BC6850
	}
}
