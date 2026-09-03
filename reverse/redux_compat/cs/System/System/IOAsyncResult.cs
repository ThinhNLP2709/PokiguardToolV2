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
	internal abstract class IOAsyncResult : IAsyncResult // TypeDefIndex: 8683
	{
		// Fields
		private AsyncCallback async_callback; // 0x10
		private object async_state; // 0x18
		private ManualResetEvent wait_handle; // 0x20
		private bool completed_synchronously; // 0x28
		private bool completed; // 0x29
	
		// Properties
		public AsyncCallback AsyncCallback { get; } // 0x0000000180377550-0x0000000180377560 
		public object AsyncState { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public WaitHandle AsyncWaitHandle { get; } // 0x0000000181B5F530-0x0000000181B5F620 
		public bool CompletedSynchronously { get; protected set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public bool IsCompleted { get; protected set; } // 0x000000018052D500-0x000000018052D510 0x0000000181B5F620-0x0000000181B5F6E0
	
		// Constructors
		protected IOAsyncResult(); // 0x00000001802E5CB0-0x00000001802E5CC0
		protected IOAsyncResult(AsyncCallback async_callback, object async_state); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		protected void Init(AsyncCallback async_callback, object async_state); // 0x0000000181B5F4E0-0x0000000181B5F530
		internal abstract void CompleteDisposed();
	}
}
