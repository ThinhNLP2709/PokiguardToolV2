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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.CompilerServices
{
	public struct AsyncVoidMethodBuilder // TypeDefIndex: 3225
	{
		// Fields
		private SynchronizationContext m_synchronizationContext; // 0x00
		private AsyncMethodBuilderCore m_coreState; // 0x08
		private Task m_task; // 0x18
	
		// Properties
		internal Task Task { get; } // 0x000000018150AB50-0x000000018150ABC0 
	
		// Methods
		public static AsyncVoidMethodBuilder Create(); // 0x000000018150A830-0x000000018150A8A0
		[DebuggerStepThrough]
		public void Start<TStateMachine>(ref ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine;
		public void SetStateMachine(IAsyncStateMachine stateMachine); // 0x000000018150AA80-0x000000018150AB50
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref ref TAwaiter awaiter, ref ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine;
		public void SetResult(); // 0x000000018150AA20-0x000000018150AA80
		public void SetException(Exception exception); // 0x000000018150A8F0-0x000000018150AA20
		private void NotifySynchronizationContextOfCompletion(); // 0x000000018150A8A0-0x000000018150A8F0
	}
}
