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
	internal struct AsyncMethodBuilderCore // TypeDefIndex: 3229
	{
		// Fields
		internal IAsyncStateMachine m_stateMachine; // 0x00
		internal Action m_defaultContextAction; // 0x08
	
		// Nested types
		internal sealed class MoveNextRunner // TypeDefIndex: 3230
		{
			// Fields
			private readonly ExecutionContext m_context; // 0x10
			internal IAsyncStateMachine m_stateMachine; // 0x18
			private static ContextCallback s_invokeMoveNext; // 0x00
	
			// Constructors
			internal MoveNextRunner(ExecutionContext context, IAsyncStateMachine stateMachine); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			internal void Run(); // 0x0000000181511AB0-0x0000000181511C60
			private static void InvokeMoveNext(object stateMachine); // 0x0000000181511A10-0x0000000181511AB0
		}
	
		private class ContinuationWrapper // TypeDefIndex: 3231
		{
			// Fields
			internal readonly Action m_continuation; // 0x10
			private readonly Action m_invokeAction; // 0x18
			internal readonly Task m_innerTask; // 0x20
	
			// Constructors
			internal ContinuationWrapper(Action continuation, Action invokeAction, Task innerTask); // 0x000000018150B650-0x000000018150B720
	
			// Methods
			internal void Invoke(); // 0x00000001804EAA50-0x00000001804EAA80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 3232
		{
			// Fields
			public Task innerTask; // 0x10
			public Action continuation; // 0x18
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _OutputAsyncCausalityEvents_b__0(); // 0x000000018151C100-0x000000018151C160
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3233
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static SendOrPostCallback __9__7_0; // 0x08
			public static WaitCallback __9__7_1; // 0x10
	
			// Constructors
			static __c(); // 0x000000018151C240-0x000000018151C2B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ThrowAsync_b__7_0(object state); // 0x000000018151BE40-0x000000018151BEA0
			internal void _ThrowAsync_b__7_1(object state); // 0x000000018151BEA0-0x000000018151BF00
		}
	
		// Methods
		public void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181509EB0-0x0000000181509F80
		internal Action GetCompletionAction(Task taskForTracing, ref MoveNextRunner runnerToInitialize); // 0x00000001815098F0-0x0000000181509B10
		private Action OutputAsyncCausalityEvents(Task innerTask, Action continuation); // 0x0000000181509B10-0x0000000181509CF0
		internal void PostBoxInitialization(IAsyncStateMachine stateMachine, MoveNextRunner runner, Task builtTask); // 0x0000000181509CF0-0x0000000181509EB0
		internal static void ThrowAsync(Exception exception, SynchronizationContext targetContext); // 0x0000000181509F80-0x000000018150A250
		internal static Action CreateContinuationWrapper(Action continuation, Action invokeAction, Task innerTask = null); // 0x00000001815097B0-0x00000001815098F0
		internal static Task TryGetContinuationTask(Action action); // 0x000000018150A250-0x000000018150A2D0
	}
}
