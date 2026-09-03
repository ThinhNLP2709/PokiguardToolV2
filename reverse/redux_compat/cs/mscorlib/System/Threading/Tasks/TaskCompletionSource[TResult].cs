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

namespace System.Threading.Tasks
{
	public class TaskCompletionSource<TResult> // TypeDefIndex: 2626
	{
		// Fields
		private readonly Task<TResult> _task;
	
		// Properties
		public Task<TResult> Task { get; }
	
		// Constructors
		public TaskCompletionSource();
		public TaskCompletionSource(TaskCreationOptions creationOptions);
		public TaskCompletionSource(object state);
		public TaskCompletionSource(object state, TaskCreationOptions creationOptions);
	
		// Methods
		private void SpinUntilCompleted();
		public bool TrySetException(Exception exception);
		public bool TrySetResult(TResult result);
		public void SetResult(TResult result);
	}
}
