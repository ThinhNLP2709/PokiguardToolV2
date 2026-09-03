/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	internal class CancellationCallbackInfo // TypeDefIndex: 2556
	{
		// Fields
		internal readonly Action<object> Callback; // 0x10
		internal readonly object StateForCallback; // 0x18
		internal readonly ExecutionContext TargetExecutionContext; // 0x20
		internal readonly CancellationTokenSource CancellationTokenSource; // 0x28
		private static ContextCallback s_executionContextCallback; // 0x00
	
		// Nested types
		internal sealed class WithSyncContext : CancellationCallbackInfo // TypeDefIndex: 2557
		{
			// Fields
			internal readonly SynchronizationContext TargetSyncContext; // 0x30
	
			// Constructors
			internal WithSyncContext(Action<object> callback, object stateForCallback, ExecutionContext targetExecutionContext, CancellationTokenSource cancellationTokenSource, SynchronizationContext targetSyncContext); // 0x000000018167A330-0x000000018167A3C0
		}
	
		// Constructors
		internal CancellationCallbackInfo(Action<object> callback, object stateForCallback, ExecutionContext targetExecutionContext, CancellationTokenSource cancellationTokenSource); // 0x0000000180DFE190-0x0000000180DFE210
	
		// Methods
		internal void ExecuteCallback(); // 0x0000000181663F10-0x0000000181664290
		private static void ExecutionContextCallback(object obj); // 0x0000000181664290-0x0000000181664310
	}
}
