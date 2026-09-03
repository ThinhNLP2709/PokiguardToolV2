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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal sealed class FileWebStream : FileStream, ICloseEx // TypeDefIndex: 9098
	{
		// Fields
		private FileWebRequest m_request; // 0x70
	
		// Constructors
		public FileWebStream(FileWebRequest request, string path, FileMode mode, FileAccess access, FileShare sharing); // 0x0000000181C0B1A0-0x0000000181C0B240
		public FileWebStream(FileWebRequest request, string path, FileMode mode, FileAccess access, FileShare sharing, int length, bool async); // 0x0000000181C0B240-0x0000000181C0B2F0
	
		// Methods
		protected override void Dispose(bool disposing); // 0x0000000181C0AF10-0x0000000181C0AFB0
		void ICloseEx.CloseEx(CloseExState closeState); // 0x0000000181C0B0C0-0x0000000181C0B110
		public override int Read(byte[] buffer, int offset, int size); // 0x0000000181C0B030-0x0000000181C0B0C0
		public override void Write(byte[] buffer, int offset, int size); // 0x0000000181C0B110-0x0000000181C0B1A0
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181C0AD10-0x0000000181C0ADC0
		public override int EndRead(IAsyncResult ar); // 0x0000000181C0AFB0-0x0000000181C0AFF0
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int size, AsyncCallback callback, object state); // 0x0000000181C0ADC0-0x0000000181C0AE70
		public override void EndWrite(IAsyncResult ar); // 0x0000000181C0AFF0-0x0000000181C0B030
		private void CheckError(); // 0x0000000181C0AE70-0x0000000181C0AF10
	}
}
