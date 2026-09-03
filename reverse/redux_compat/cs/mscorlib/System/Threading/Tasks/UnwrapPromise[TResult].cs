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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	internal sealed class UnwrapPromise<TResult> : Task<TResult>, ITaskCompletionAction // TypeDefIndex: 2661
	{
		// Fields
		private byte _state;
		private readonly bool _lookForOce;
	
		// Properties
		public bool InvokeMayRunArbitraryCode { get; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2662
		{
			// Fields
			public static readonly __c<TResult> __9;
			public static WaitCallback __9__8_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal void _InvokeCoreAsync_b__8_0(object state);
		}
	
		// Constructors
		public UnwrapPromise(Task outerTask, bool lookForOce);
	
		// Methods
		public void Invoke(Task completingTask);
		private void InvokeCore(Task completingTask);
		private void InvokeCoreAsync(Task completingTask);
		private void ProcessCompletedOuterTask(Task task);
		private bool TrySetFromTask(Task task, bool lookForOce);
		private void ProcessInnerTask(Task task);
	}
}
