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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	internal class IOSelectorJob : IThreadPoolWorkItem // TypeDefIndex: 8684
	{
		// Fields
		private IOOperation operation; // 0x10
		private IOAsyncCallback callback; // 0x18
		private IOAsyncResult state; // 0x20
	
		// Constructors
		public IOSelectorJob(IOOperation operation, IOAsyncCallback callback, IOAsyncResult state); // 0x00000001810F81C0-0x00000001810F8220
	
		// Methods
		void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x0000000181B5F710-0x0000000181B5F740
		void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae); // 0x00000001802E76C0-0x00000001802E76D0
		public void MarkDisposed(); // 0x0000000181B5F6E0-0x0000000181B5F710
	}
}
