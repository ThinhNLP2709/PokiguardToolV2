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

namespace System.Runtime.CompilerServices
{
	public struct AsyncTaskMethodBuilder<TResult> // TypeDefIndex: 3227
	{
		// Fields
		internal static readonly Task<TResult> s_defaultResultTask;
		private AsyncMethodBuilderCore m_coreState;
		private Task<TResult> m_task;
	
		// Properties
		public Task<TResult> Task { get; }
	
		// Constructors
		static AsyncTaskMethodBuilder();
	
		// Methods
		public static AsyncTaskMethodBuilder<TResult> Create();
		[DebuggerStepThrough]
		public void Start<TStateMachine>(ref ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine;
		public void SetStateMachine(IAsyncStateMachine stateMachine);
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref ref TAwaiter awaiter, ref ref TStateMachine stateMachine)
			where TAwaiter : INotifyCompletion
			where TStateMachine : IAsyncStateMachine;
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref ref TAwaiter awaiter, ref ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine;
		public void SetResult(TResult result);
		internal void SetResult(Task<TResult> completedTask);
		public void SetException(Exception exception);
		internal static Task<TResult> GetTaskForResult(TResult result);
	}
}
