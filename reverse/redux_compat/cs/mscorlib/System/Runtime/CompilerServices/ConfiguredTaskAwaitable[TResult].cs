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
	public struct ConfiguredTaskAwaitable<TResult> // TypeDefIndex: 3222
	{
		// Fields
		private readonly ConfiguredTaskAwaiter m_configuredTaskAwaiter;
	
		// Nested types
		[IsReadOnly]
		public struct ConfiguredTaskAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3223
		{
			// Fields
			private readonly Task<TResult> m_task;
			private readonly bool m_continueOnCapturedContext;
	
			// Properties
			public bool IsCompleted { get; }
	
			// Constructors
			internal ConfiguredTaskAwaiter(Task<TResult> task, bool continueOnCapturedContext);
	
			// Methods
			public void OnCompleted(Action continuation);
			public void UnsafeOnCompleted(Action continuation);
			[StackTraceHidden]
			public TResult GetResult();
		}
	
		// Constructors
		internal ConfiguredTaskAwaitable(Task<TResult> task, bool continueOnCapturedContext);
	
		// Methods
		public ConfiguredTaskAwaiter GetAwaiter();
	}
}
