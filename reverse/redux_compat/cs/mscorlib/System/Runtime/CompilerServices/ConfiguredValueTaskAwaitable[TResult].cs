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
	public struct ConfiguredValueTaskAwaitable<TResult> // TypeDefIndex: 3188
	{
		// Fields
		private readonly ValueTask<TResult> _value;
	
		// Nested types
		[IsReadOnly]
		public struct ConfiguredValueTaskAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3189
		{
			// Fields
			private readonly ValueTask<TResult> _value;
	
			// Properties
			public bool IsCompleted { get; }
	
			// Constructors
			internal ConfiguredValueTaskAwaiter(ValueTask<TResult> value);
	
			// Methods
			[StackTraceHidden]
			public TResult GetResult();
			public void OnCompleted(Action continuation);
			public void UnsafeOnCompleted(Action continuation);
		}
	
		// Constructors
		internal ConfiguredValueTaskAwaitable(ValueTask<TResult> value);
	
		// Methods
		public ConfiguredValueTaskAwaiter GetAwaiter();
	}
}
