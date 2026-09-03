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
	[IsReadOnly]
	public struct TaskAwaiter<TResult> : ICriticalNotifyCompletion // TypeDefIndex: 3219
	{
		// Fields
		private readonly Task<TResult> m_task;
	
		// Properties
		public bool IsCompleted { get; }
	
		// Constructors
		internal TaskAwaiter(Task<TResult> task);
	
		// Methods
		public void OnCompleted(Action continuation);
		public void UnsafeOnCompleted(Action continuation);
		[StackTraceHidden]
		public TResult GetResult();
	}
}
