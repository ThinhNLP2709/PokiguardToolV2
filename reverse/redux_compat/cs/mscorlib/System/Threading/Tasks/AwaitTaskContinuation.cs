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

namespace System.Threading.Tasks
{
	internal class AwaitTaskContinuation : TaskContinuation, IThreadPoolWorkItem // TypeDefIndex: 2672
	{
		// Fields
		private readonly ExecutionContext m_capturedContext; // 0x10
		protected readonly Action m_action; // 0x18
		private static ContextCallback s_invokeActionCallback; // 0x00
	
		// Properties
		internal static bool IsValidLocationForInlining { get; } // 0x000000018167D7A0-0x000000018167D8B0 
	
		// Constructors
		internal AwaitTaskContinuation(Action action, bool flowExecutionContext); // 0x000000018167D710-0x000000018167D7A0
	
		// Methods
		protected Task CreateTask(Action<object> action, object state, TaskScheduler scheduler); // 0x000000018167D080-0x000000018167D160
		internal override void Run(Task ignored, bool canInlineContinuationTask); // 0x000000018167D4D0-0x000000018167D590
		void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x000000018167D590-0x000000018167D630
		private static void InvokeAction(object state); // 0x000000018167D210-0x000000018167D280
		protected static ContextCallback GetInvokeActionCallback(); // 0x000000018167D160-0x000000018167D210
		protected void RunCallback(ContextCallback callback, object state, ref Task currentTask); // 0x000000018167D280-0x000000018167D3A0
		internal static void RunOrScheduleAction(Action action, bool allowInlining, ref Task currentTask); // 0x000000018167D3A0-0x000000018167D4D0
		internal static void UnsafeScheduleAction(Action action); // 0x000000018167D680-0x000000018167D710
		protected static void ThrowAsyncIfNecessary(Exception exc); // 0x000000018167D630-0x000000018167D680
		public void MarkAborted(ThreadAbortException e); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
