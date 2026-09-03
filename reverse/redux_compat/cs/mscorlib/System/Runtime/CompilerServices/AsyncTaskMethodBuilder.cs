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
	public struct AsyncTaskMethodBuilder // TypeDefIndex: 3226
	{
		// Fields
		private static readonly Task<VoidTaskResult> s_cachedCompleted; // 0x00
		private AsyncTaskMethodBuilder<VoidTaskResult> m_builder; // 0x00
	
		// Properties
		public Task Task { get; } // 0x000000018150A7D0-0x000000018150A830 
	
		// Constructors
		static AsyncTaskMethodBuilder(); // 0x000000018150A750-0x000000018150A7D0
	
		// Methods
		public static AsyncTaskMethodBuilder Create(); // 0x0000000180A69590-0x0000000180A695A0
		[DebuggerStepThrough]
		public void Start<TStateMachine>(ref ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine;
		public void SetStateMachine(IAsyncStateMachine stateMachine); // 0x000000018150A6F0-0x000000018150A750
		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref ref TAwaiter awaiter, ref ref TStateMachine stateMachine)
			where TAwaiter : INotifyCompletion
			where TStateMachine : IAsyncStateMachine;
		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref ref TAwaiter awaiter, ref ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine;
		public void SetResult(); // 0x000000018150A650-0x000000018150A6F0
		public void SetException(Exception exception); // 0x000000018150A5E0-0x000000018150A650
	}
}
