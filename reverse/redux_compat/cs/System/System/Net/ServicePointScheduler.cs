/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class ServicePointScheduler // TypeDefIndex: 9147
	{
		// Fields
		[CompilerGenerated]
		private ServicePoint _ServicePoint_k__BackingField; // 0x10
		private int running; // 0x18
		private int maxIdleTime; // 0x1C
		private AsyncManualResetEvent schedulerEvent; // 0x20
		private ConnectionGroup defaultGroup; // 0x28
		private Dictionary<string, ConnectionGroup> groups; // 0x30
		private LinkedList<ValueTuple<ConnectionGroup, WebOperation>> operations; // 0x38
		private LinkedList<ValueTuple<ConnectionGroup, WebConnection, Task>> idleConnections; // 0x40
		private int currentConnections; // 0x48
		private int connectionLimit; // 0x4C
		private DateTime idleSince; // 0x50
		private static int nextId; // 0x00
		public readonly int ID; // 0x58
	
		// Properties
		private ServicePoint ServicePoint { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public int MaxIdleTime { get; } // 0x0000000180B232F0-0x0000000180B23300 
	
		// Nested types
		private class ConnectionGroup // TypeDefIndex: 9148
		{
			// Fields
			[CompilerGenerated]
			private readonly ServicePointScheduler _Scheduler_k__BackingField; // 0x10
			[CompilerGenerated]
			private readonly string _Name_k__BackingField; // 0x18
			private static int nextId; // 0x00
			public readonly int ID; // 0x20
			private LinkedList<WebConnection> connections; // 0x28
			private LinkedList<WebOperation> queue; // 0x30
	
			// Properties
			public ServicePointScheduler Scheduler { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
			// Constructors
			public ConnectionGroup(ServicePointScheduler scheduler, string name); // 0x0000000181B0F560-0x0000000181B0F650
	
			// Methods
			public bool IsEmpty(); // 0x0000000181B0F480-0x0000000181B0F4C0
			public void RemoveConnection(WebConnection connection); // 0x0000000181B0F4C0-0x0000000181B0F560
			public void Cleanup(); // 0x0000000181B0EDB0-0x0000000181B0EE80
			public void EnqueueOperation(WebOperation operation); // 0x0000000181B0F030-0x0000000181B0F090
			public WebOperation GetNextOperation(); // 0x0000000181B0F390-0x0000000181B0F480
			public WebConnection FindIdleConnection(WebOperation operation); // 0x0000000181B0F090-0x0000000181B0F390
			public ValueTuple<WebConnection, bool> CreateOrReuseConnection(WebOperation operation, bool force); // 0x0000000181B0EE80-0x0000000181B0F030
		}
	
		private class AsyncManualResetEvent // TypeDefIndex: 9149
		{
			// Fields
			private TaskCompletionSource<bool> m_tcs; // 0x10
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 9150
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Func<object, bool> __9__4_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181B1D4D0-0x0000000181B1D540
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _Set_b__4_0(object s); // 0x0000000181B1D3E0-0x0000000181B1D460
			}
	
			// Constructors
			public AsyncManualResetEvent(bool state); // 0x0000000181B0E860-0x0000000181B0E900
	
			// Methods
			public Task<bool> WaitAsync(int millisecondTimeout); // 0x0000000181B0E740-0x0000000181B0E860
			public void Set(); // 0x0000000181B0E4F0-0x0000000181B0E740
			public void Reset(); // 0x0000000181B0E430-0x0000000181B0E4F0
		}
	
		[CompilerGenerated]
		private struct _RunScheduler_d__32 : IAsyncStateMachine // TypeDefIndex: 9151
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public ServicePointScheduler __4__this; // 0x20
			private ValueTuple<ConnectionGroup, WebOperation>[] _operationArray_5__2; // 0x28
			private ValueTuple<ConnectionGroup, WebConnection, Task>[] _idleArray_5__3; // 0x30
			private List<Task> _taskList_5__4; // 0x38
			private Task<bool> _schedulerTask_5__5; // 0x40
			private bool _finalCleanup_5__6; // 0x48
			private ConfiguredTaskAwaitable<Task> __u__1; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181B1AF40-0x0000000181B1BF90
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1BF90-0x0000000181B1BFF0
		}
	
		[CompilerGenerated]
		private struct _WaitAsync_d__46 : IAsyncStateMachine // TypeDefIndex: 9152
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			public int millisecondTimeout; // 0x20
			public Task workerTask; // 0x28
			private CancellationTokenSource _cts_5__2; // 0x30
			private Task _timeoutTask_5__3; // 0x38
			private ConfiguredTaskAwaitable<Task> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181B1D540-0x0000000181B1DA60
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1DA60-0x0000000181B1DAC0
		}
	
		// Constructors
		public ServicePointScheduler(ServicePoint servicePoint, int connectionLimit, int maxIdleTime); // 0x0000000181B13960-0x0000000181B13B70
	
		// Methods
		public void Run(); // 0x0000000181B13420-0x0000000181B134E0
		private async Task RunScheduler(); // 0x0000000181B13350-0x0000000181B13420
		private void Cleanup(); // 0x0000000181B12710-0x0000000181B128D0
		private void RunSchedulerIteration(); // 0x0000000181B13160-0x0000000181B13350
		private bool OperationCompleted(ConnectionGroup group, WebOperation operation); // 0x0000000181B12D50-0x0000000181B13020
		private void CloseIdleConnection(ConnectionGroup group, WebConnection connection); // 0x0000000181B128D0-0x0000000181B12990
		private bool SchedulerIteration(ConnectionGroup group); // 0x0000000181B134E0-0x0000000181B136B0
		private void RemoveOperation(WebOperation operation); // 0x0000000181B130C0-0x0000000181B13160
		private void RemoveIdleConnection(WebConnection connection); // 0x0000000181B13020-0x0000000181B130C0
		private void FinalCleanup(); // 0x0000000181B12990-0x0000000181B12AE0
		public void SendRequest(WebOperation operation, string groupName); // 0x0000000181B136B0-0x0000000181B13860
		private ConnectionGroup GetConnectionGroup(string name); // 0x0000000181B12AE0-0x0000000181B12D10
		private void OnConnectionCreated(WebConnection connection); // 0x0000000181B12D40-0x0000000181B12D50
		private void OnConnectionClosed(WebConnection connection); // 0x0000000181B12D10-0x0000000181B12D40
		public static async Task<bool> WaitAsync(Task workerTask, int millisecondTimeout); // 0x0000000181B13860-0x0000000181B13960
		[CompilerGenerated]
		private Task _Run_b__31_0(); // 0x0000000181B13350-0x0000000181B13420
	}
}
