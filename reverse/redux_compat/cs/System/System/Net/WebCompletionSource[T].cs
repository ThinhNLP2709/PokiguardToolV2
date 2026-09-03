/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class WebCompletionSource<T> // TypeDefIndex: 9153
	{
		// Fields
		private TaskCompletionSource<Result> completion;
		private Result currentResult;
	
		// Properties
		internal Result CurrentResult { get; }
		internal Task Task { get; }
	
		// Nested types
		internal enum Status // TypeDefIndex: 9154
		{
			Running = 0,
			Completed = 1,
			Canceled = 2,
			Faulted = 3
		}
	
		internal class Result // TypeDefIndex: 9155
		{
			// Fields
			[CompilerGenerated]
			private readonly Status<T> _Status_k__BackingField;
			[CompilerGenerated]
			private readonly ExceptionDispatchInfo _Error_k__BackingField;
			[CompilerGenerated]
			private readonly T _Argument_k__BackingField;
	
			// Properties
			public Status<T> Status { [CompilerGenerated] get; }
			public bool Success { get; }
			public ExceptionDispatchInfo Error { [CompilerGenerated] get; }
			public T Argument { [CompilerGenerated] get; }
	
			// Constructors
			public Result(T argument);
			public Result(Status<T> state, ExceptionDispatchInfo error);
		}
	
		[CompilerGenerated]
		private struct _WaitForCompletion_d__15 : IAsyncStateMachine // TypeDefIndex: 9156
		{
			// Fields
			public int __1__state;
			public AsyncTaskMethodBuilder<T> __t__builder;
			public WebCompletionSource<T> __4__this;
			private ConfiguredTaskAwaitable<Result<T>> __u__1;
	
			// Methods
			private void MoveNext();
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine);
		}
	
		// Constructors
		public WebCompletionSource(bool runAsync = true /* Metadata: 0x0069E33B */);
	
		// Methods
		public bool TrySetCompleted(T argument);
		public bool TrySetCompleted();
		public bool TrySetCanceled();
		public bool TrySetCanceled(OperationCanceledException error);
		public bool TrySetException(Exception error);
		public void ThrowOnError();
		public async Task<T> WaitForCompletion();
	}
}
