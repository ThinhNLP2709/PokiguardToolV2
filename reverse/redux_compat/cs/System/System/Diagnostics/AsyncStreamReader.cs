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
using System.Text;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Diagnostics
{
	internal class AsyncStreamReader // TypeDefIndex: 8738
	{
		// Fields
		private Stream stream; // 0x10
		private Encoding encoding; // 0x18
		private Decoder decoder; // 0x20
		private byte[] byteBuffer; // 0x28
		private char[] charBuffer; // 0x30
		private bool cancelOperation; // 0x38
		private ManualResetEvent eofEvent; // 0x40
		private object syncObject; // 0x48
		private IAsyncResult asyncReadResult; // 0x50
	
		// Methods
		public virtual void Close(); // 0x0000000181B386B0-0x0000000181B386D0
		protected virtual void Dispose(bool disposing); // 0x0000000181B74650-0x0000000181B74980
		internal void CancelOperation(); // 0x00000001805629E0-0x00000001805629F0
	}
}
