/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[ComVisible(false)]
	[DebuggerDisplay("Current Count = {m_currentCount}")]
	public class SemaphoreSlim : IDisposable // TypeDefIndex: 2563
	{
		// Fields
		private int m_currentCount; // 0x10
		private readonly int m_maxCount; // 0x14
		private int m_waitCount; // 0x18
		private object m_lockObj; // 0x20
		private ManualResetEvent m_waitHandle; // 0x28
		private TaskNode m_asyncHead; // 0x30
		private TaskNode m_asyncTail; // 0x38
		private static readonly Task<bool> s_trueTask; // 0x00
		private static readonly Task<bool> s_falseTask; // 0x08
		private static Action<object> s_cancellationTokenCanceledEventHandler; // 0x10
	
		// Properties
		public int CurrentCount { get; } // 0x00000001816746B0-0x00000001816746D0 
	
		// Nested types
		private sealed class TaskNode : Task<bool>, IThreadPoolWorkItem // TypeDefIndex: 2564
		{
			// Fields
			internal TaskNode Prev; // 0x58
			internal TaskNode Next; // 0x60
	
			// Constructors
			internal TaskNode(); // 0x0000000181675DD0-0x0000000181675DE0
	
			// Methods
			new void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x0000000181675DC0-0x0000000181675DD0
			void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		[CompilerGenerated]
		private struct _WaitUntilCountOrTimeoutAsync_d__32 : IAsyncStateMachine // TypeDefIndex: 2565
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public TaskNode asyncWaiter; // 0x28
			public int millisecondsTimeout; // 0x30
			public SemaphoreSlim __4__this; // 0x38
			private CancellationTokenSource _cts_5__2; // 0x40
			private object __7__wrap2; // 0x48
			private ConfiguredTaskAwaitable<Task> __u__1; // 0x50
			private ConfiguredTaskAwaitable<bool> __u__2; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001816784E0-0x0000000181678E50
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181678E50-0x0000000181678EB0
		}
	
		// Constructors
		public SemaphoreSlim(int initialCount); // 0x00000001816745A0-0x00000001816746B0
		public SemaphoreSlim(int initialCount, int maxCount); // 0x00000001816743E0-0x00000001816745A0
		static SemaphoreSlim(); // 0x0000000181674290-0x00000001816743E0
	
		// Methods
		public void Wait(); // 0x0000000181674280-0x0000000181674290
		public bool Wait(int millisecondsTimeout); // 0x0000000181673B80-0x0000000181673B90
		public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken); // 0x0000000181673B90-0x0000000181674280
		private bool WaitUntilCountOrTimeout(int millisecondsTimeout, uint startTime, CancellationToken cancellationToken); // 0x0000000181673A60-0x0000000181673B80
		public Task WaitAsync(); // 0x00000001816733A0-0x00000001816733B0
		public Task<bool> WaitAsync(int millisecondsTimeout, CancellationToken cancellationToken); // 0x00000001816733B0-0x0000000181673930
		private TaskNode CreateAndAddAsyncWaiter(); // 0x0000000181672CA0-0x0000000181672D50
		private bool RemoveAsyncWaiter(TaskNode task); // 0x00000001816732B0-0x00000001816733A0
		private async Task<bool> WaitUntilCountOrTimeoutAsync(TaskNode asyncWaiter, int millisecondsTimeout, CancellationToken cancellationToken); // 0x0000000181673930-0x0000000181673A60
		public int Release(); // 0x00000001816732A0-0x00000001816732B0
		public int Release(int releaseCount); // 0x0000000181672E90-0x00000001816732A0
		private static void QueueWaiterTask(TaskNode waiterTask); // 0x0000000181672E80-0x0000000181672E90
		public void Dispose(); // 0x0000000181672D50-0x0000000181672DC0
		protected virtual void Dispose(bool disposing); // 0x0000000181672DC0-0x0000000181672E70
		private static void CancellationTokenCanceledEventHandler(object obj); // 0x00000001816729E0-0x0000000181672C00
		private void CheckDispose(); // 0x0000000181672C00-0x0000000181672CA0
		private static string GetResourceString(string str); // 0x0000000181672E70-0x0000000181672E80
	}
}
