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
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal abstract class AsyncProtocolRequest // TypeDefIndex: 8547
	{
		// Fields
		[CompilerGenerated]
		private readonly MobileAuthenticatedStream _Parent_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly bool _RunSynchronously_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _UserResult_k__BackingField; // 0x1C
		private int Started; // 0x20
		private int RequestedSize; // 0x24
		private int WriteRequested; // 0x28
		private readonly object locker; // 0x30
	
		// Properties
		public MobileAuthenticatedStream Parent { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public bool RunSynchronously { [CompilerGenerated] get; } // 0x0000000180F9E350-0x0000000180F9E360 
		public string Name { get; } // 0x000000018180F650-0x000000018180F680 
		public int UserResult { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
	
		// Nested types
		[CompilerGenerated]
		private struct _StartOperation_d__23 : IAsyncStateMachine // TypeDefIndex: 8548
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<AsyncProtocolResult> __t__builder; // 0x08
			public AsyncProtocolRequest __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181822990-0x0000000181822D80
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181822D80-0x0000000181822DE0
		}
	
		[CompilerGenerated]
		private struct _ProcessOperation_d__24 : IAsyncStateMachine // TypeDefIndex: 8549
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public AsyncProtocolRequest __4__this; // 0x28
			private AsyncOperationStatus _status_5__2; // 0x30
			private AsyncOperationStatus _newStatus_5__3; // 0x34
			private ConfiguredTaskAwaitable<int?> __u__1; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181822300-0x0000000181822930
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181822930-0x0000000181822990
		}
	
		[CompilerGenerated]
		private struct _InnerRead_d__25 : IAsyncStateMachine // TypeDefIndex: 8550
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int?> __t__builder; // 0x08
			public AsyncProtocolRequest __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private int? _totalRead_5__2; // 0x30
			private int _requestedSize_5__3; // 0x38
			private ConfiguredTaskAwaitable<int> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181820D30-0x0000000181821120
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181821120-0x0000000181821180
		}
	
		// Constructors
		public AsyncProtocolRequest(MobileAuthenticatedStream parent, bool sync); // 0x000000018180F5D0-0x000000018180F650
	
		// Methods
		internal void RequestRead(int size); // 0x000000018180F3B0-0x000000018180F450
		internal void RequestWrite(); // 0x000000018180F450-0x000000018180F460
		internal async Task<AsyncProtocolResult> StartOperation(CancellationToken cancellationToken); // 0x000000018180F460-0x000000018180F560
		private async Task ProcessOperation(CancellationToken cancellationToken); // 0x000000018180F2B0-0x000000018180F3B0
		private async Task<int?> InnerRead(CancellationToken cancellationToken); // 0x000000018180F1A0-0x000000018180F2B0
		protected abstract AsyncOperationStatus Run(AsyncOperationStatus status);
		public override string ToString(); // 0x000000018180F560-0x000000018180F5D0
	}
}
