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

namespace System.Net
{
	internal class LazyAsyncResult : IAsyncResult // TypeDefIndex: 9069
	{
		// Fields
		[ThreadStatic]
		private static ThreadContext t_ThreadContext; // 0x80000000
		private object m_AsyncObject; // 0x10
		private object m_AsyncState; // 0x18
		private AsyncCallback m_AsyncCallback; // 0x20
		private object m_Result; // 0x28
		private int m_IntCompleted; // 0x30
		private bool m_EndCalled; // 0x34
		private bool m_UserEvent; // 0x35
		private object m_Event; // 0x38
	
		// Properties
		private static ThreadContext CurrentThreadContext { get; } // 0x0000000181C10570-0x0000000181C10610 
		internal object AsyncObject { get; } // 0x0000000180377550-0x0000000180377560 
		public object AsyncState { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		protected AsyncCallback AsyncCallback { get; } // 0x00000001802F8630-0x00000001802F8640 
		public WaitHandle AsyncWaitHandle { get; } // 0x0000000181C104C0-0x0000000181C10550 
		public bool CompletedSynchronously { get; } // 0x0000000181C10550-0x0000000181C10570 
		public bool IsCompleted { get; } // 0x0000000181C10620-0x0000000181C10650 
		internal bool InternalPeekCompleted { get; } // 0x0000000181C10610-0x0000000181C10620 
		internal bool EndCalled { get; set; } // 0x00000001816DAFD0-0x00000001816DAFE0 0x0000000181C10650-0x0000000181C10660
	
		// Nested types
		private class ThreadContext // TypeDefIndex: 9070
		{
			// Fields
			internal int m_NestedIOCount; // 0x10
	
			// Constructors
			public ThreadContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		internal LazyAsyncResult(object myObject, object myState, AsyncCallback myCallBack); // 0x0000000181C10410-0x0000000181C104C0
	
		// Methods
		private bool LazilyCreateEvent(out ManualResetEvent waitHandle); // 0x0000000181C0FEB0-0x0000000181C10030
		protected void ProtectedInvokeCallback(object result, IntPtr userToken); // 0x0000000181C10030-0x0000000181C10180
		internal void InvokeCallback(object result); // 0x0000000181C0FEA0-0x0000000181C0FEB0
		internal void InvokeCallback(); // 0x0000000181C0FE90-0x0000000181C0FEA0
		protected virtual void Complete(IntPtr userToken); // 0x0000000181C0FC60-0x0000000181C0FE80
		private void WorkerThreadComplete(object state); // 0x0000000181C10370-0x0000000181C10410
		protected virtual void Cleanup(); // 0x00000001802E76C0-0x00000001802E76D0
		internal object InternalWaitForCompletion(); // 0x0000000181C0FE80-0x0000000181C0FE90
		private object WaitForCompletion(bool snap); // 0x0000000181C10180-0x0000000181C10370
	}
}
