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
	[DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}, Result = {DebuggerDisplayResultDescription}")]
	[DebuggerTypeProxy(typeof(SystemThreadingTasks_FutureDebugView<TResult>))]
	public class Task<TResult> : Task // TypeDefIndex: 2640
	{
		// Fields
		internal TResult m_result;
		private static TaskFactory<TResult> s_defaultFactory;
	
		// Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TResult Result { get; }
		internal TResult ResultOnSuccess { get; }
		public static new TaskFactory<TResult> Factory { get; }
	
		// Constructors
		internal Task();
		internal Task(object state, TaskCreationOptions options);
		internal Task(TResult result);
		internal Task(bool canceled, TResult result, TaskCreationOptions creationOptions, CancellationToken ct);
		public Task(Func<TResult> function, CancellationToken cancellationToken);
		public Task(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions);
		internal Task(Func<TResult> valueSelector, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler);
		internal Task(Delegate valueSelector, object state, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler);
	
		// Methods
		internal static Task<TResult> StartNew(Task parent, Func<TResult> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler);
		internal static Task<TResult> StartNew(Task parent, Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler);
		internal bool TrySetResult(TResult result);
		internal void DangerousSetResult(TResult result);
		internal TResult GetResultCore(bool waitCompletionNotification);
		internal override void InnerInvoke();
		public new TaskAwaiter<TResult> GetAwaiter();
		public new ConfiguredTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);
		public Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler);
		internal Task ContinueWith(Action<Task<TResult>> continuationAction, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions);
		public Tasks.Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskContinuationOptions continuationOptions);
		internal Tasks.Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions);
	}
}
