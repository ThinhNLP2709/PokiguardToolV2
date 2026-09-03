/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	public class TaskFactory // TypeDefIndex: 2674
	{
		// Fields
		private readonly CancellationToken m_defaultCancellationToken; // 0x10
		private readonly TaskScheduler m_defaultScheduler; // 0x18
		private readonly TaskCreationOptions m_defaultCreationOptions; // 0x20
		private readonly TaskContinuationOptions m_defaultContinuationOptions; // 0x24
	
		// Nested types
		internal sealed class CompleteOnInvokePromise : Task<Task>, ITaskCompletionAction // TypeDefIndex: 2675
		{
			// Fields
			private IList<Task> _tasks; // 0x58
	
			// Properties
			public bool InvokeMayRunArbitraryCode { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public CompleteOnInvokePromise(IList<Task> tasks); // 0x000000018167DA40-0x000000018167DAC0
	
			// Methods
			public void Invoke(Task completingTask); // 0x000000018167D8B0-0x000000018167DA40
		}
	
		// Constructors
		public TaskFactory(); // 0x0000000181686060-0x00000001816860B0
		public TaskFactory(CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler); // 0x00000001816860B0-0x0000000181686290
	
		// Methods
		internal static void CheckCreationOptions(TaskCreationOptions creationOptions); // 0x00000001816857C0-0x0000000181685830
		public Task StartNew(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler); // 0x0000000181685EA0-0x0000000181686060
		public Task StartNew(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler); // 0x0000000181685CD0-0x0000000181685EA0
		public Task<TResult> StartNew<TResult>(Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
		public Task<TResult> StartNew<TResult>(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
		public Task FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state);
		public Task FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, object state, TaskCreationOptions creationOptions);
		public Task FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state);
		public Task FromAsync<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Action<IAsyncResult> endMethod, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);
		internal static void CheckFromAsyncOptions(TaskCreationOptions creationOptions, bool hasBeginMethod); // 0x0000000181685830-0x0000000181685960
		internal static Task<Task> CommonCWAnyLogic(IList<Task> tasks); // 0x0000000181685AA0-0x0000000181685CD0
		internal static void CheckMultiTaskContinuationOptions(TaskContinuationOptions continuationOptions); // 0x0000000181685960-0x0000000181685AA0
	}
}
