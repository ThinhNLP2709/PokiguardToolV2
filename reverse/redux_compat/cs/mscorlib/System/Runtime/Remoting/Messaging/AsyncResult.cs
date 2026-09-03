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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[ComVisible(true)]
	public class AsyncResult : IAsyncResult, IMessageSink, IThreadPoolWorkItem // TypeDefIndex: 2968
	{
		// Fields
		private object async_state; // 0x10
		private WaitHandle handle; // 0x18
		private object async_delegate; // 0x20
		private IntPtr data; // 0x28
		private object object_data; // 0x30
		private bool sync_completed; // 0x38
		private bool completed; // 0x39
		private bool endinvoke_called; // 0x3A
		private object async_callback; // 0x40
		private ExecutionContext current; // 0x48
		private ExecutionContext original; // 0x50
		private long add_time; // 0x58
		private MonoMethodMessage call_message; // 0x60
		private IMessageCtrl message_ctrl; // 0x68
		private IMessage reply_message; // 0x70
		private WaitCallback orig_cb; // 0x78
	
		// Properties
		public virtual object AsyncState { get; } // 0x0000000180377550-0x0000000180377560 
		public virtual WaitHandle AsyncWaitHandle { get; } // 0x00000001814CFE30-0x00000001814CFF20 
		public virtual bool CompletedSynchronously { get; } // 0x0000000180476380-0x0000000180476390 
		public virtual bool IsCompleted { get; } // 0x00000001814CFF30-0x00000001814CFF40 
		public bool EndInvokeCalled { get; set; } // 0x00000001814CFF20-0x00000001814CFF30 0x00000001814CFF40-0x00000001814CFF50
		public virtual object AsyncDelegate { get; } // 0x00000001802F8630-0x00000001802F8640 
		public IMessageSink NextSink { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal MonoMethodMessage CallMessage { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
	
		// Constructors
		internal AsyncResult(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink); // 0x00000001814CFB50-0x00000001814CFB90
		public virtual IMessage GetReplyMessage(); // 0x000000018033D4D0-0x000000018033D4E0
		public virtual void SetMessageCtrl(IMessageCtrl mc); // 0x0000000180316A40-0x0000000180316A50
		internal void SetCompletedSynchronously(bool completed); // 0x00000001804763A0-0x00000001804763B0
		internal IMessage EndInvoke(); // 0x00000001814CFB90-0x00000001814CFC90
		public virtual IMessage SyncProcessMessage(IMessage msg); // 0x00000001814CFCA0-0x00000001814CFE30
		void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x00000001814CFC90-0x00000001814CFCA0
		void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae); // 0x00000001802E76C0-0x00000001802E76D0
		internal object Invoke(); // 0x00000001814CFC90-0x00000001814CFCA0
	}
}
