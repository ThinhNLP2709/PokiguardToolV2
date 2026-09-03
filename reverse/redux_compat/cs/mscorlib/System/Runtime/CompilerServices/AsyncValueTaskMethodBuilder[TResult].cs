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
	public struct AsyncValueTaskMethodBuilder<TResult> // TypeDefIndex: 3181
	{
		// Fields
		private AsyncTaskMethodBuilder<TResult> _methodBuilder;
		private TResult _result;
		private bool _haveResult;
		private bool _useBuilder;
	
		// Properties
		public ValueTask<TResult> Task { get; }
	
		// Methods
		public static AsyncValueTaskMethodBuilder<TResult> Create();
		public void Start<TStateMachine>(ref ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine;
		public void SetStateMachine(IAsyncStateMachine stateMachine);
		public void SetResult(TResult result);
		public void SetException(Exception exception);
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref ref TAwaiter awaiter, ref ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine;
	}
}
