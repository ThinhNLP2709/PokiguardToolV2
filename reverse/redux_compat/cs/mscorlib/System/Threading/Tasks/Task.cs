/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	[DebuggerDisplay("Id = {Id}, Status = {Status}, Method = {DebuggerDisplayMethodDescription}")]
	[DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskDebugView))]
	public class Task : IThreadPoolWorkItem, IAsyncResult, IDisposable // TypeDefIndex: 2648
	{
		// Fields
		internal static int s_taskIdCounter; // 0x00
		private int m_taskId; // 0x10
		internal Delegate m_action; // 0x18
		internal object m_stateObject; // 0x20
		internal TaskScheduler m_taskScheduler; // 0x28
		internal readonly Task m_parent; // 0x30
		internal int m_stateFlags; // 0x38
		private object m_continuationObject; // 0x40
		private static readonly object s_taskCompletionSentinel; // 0x08
		internal static bool s_asyncDebuggingEnabled; // 0x10
		internal ContingentProperties m_contingentProperties; // 0x48
		private static readonly Action<object> s_taskCancelCallback; // 0x18
		[ThreadStatic]
		internal static Task t_currentTask; // 0x80000000
		[ThreadStatic]
		private static StackGuard t_stackGuard; // 0x80000008
		private static readonly Func<ContingentProperties> s_createContingentProperties; // 0x20
		[CompilerGenerated]
		private static readonly TaskFactory _Factory_k__BackingField; // 0x28
		[CompilerGenerated]
		private static readonly Task _CompletedTask_k__BackingField; // 0x30
		private static readonly Predicate<Task> s_IsExceptionObservedByParentPredicate; // 0x38
		private static ContextCallback s_ecCallback; // 0x40
		private static readonly Predicate<object> s_IsTaskContinuationNullPredicate; // 0x48
		private static readonly Dictionary<int, Task> s_currentActiveTasks; // 0x50
		private static readonly object s_activeTasksLock; // 0x58
	
		// Properties
		internal TaskCreationOptions Options { get; } // 0x000000018168EE70-0x000000018168EEC0 
		internal bool IsWaitNotificationEnabledOrNotRanToCompletion { get; } // 0x000000018168EE20-0x000000018168EE50 
		internal virtual bool ShouldNotifyDebuggerOfWaitCompletion { get; } // 0x000000018168EE50-0x000000018168EE70 
		internal bool IsWaitNotificationEnabled { get; } // 0x000000018168EE50-0x000000018168EE70 
		public int Id { get; } // 0x000000018168EB70-0x000000018168EC10 
		internal static Task InternalCurrent { get; } // 0x000000018168EC10-0x000000018168EC60 
		internal static StackGuard CurrentStackGuard { get; } // 0x000000018168E9B0-0x000000018168EA60 
		public AggregateException Exception { get; } // 0x000000018168EAD0-0x000000018168EB20 
		public TaskStatus Status { get; } // 0x000000018168EEC0-0x000000018168EF50 
		public bool IsCanceled { get; } // 0x000000018168EC60-0x000000018168EC90 
		internal bool IsCancellationRequested { get; } // 0x000000018168ECB0-0x000000018168ED30 
		internal CancellationToken CancellationToken { get; } // 0x000000018168E6B0-0x000000018168E6E0 
		internal bool IsCancellationAcknowledged { get; } // 0x000000018168EC90-0x000000018168ECB0 
		public bool IsCompleted { get; } // 0x000000018168ED60-0x000000018168EDC0 
		public bool IsCompletedSuccessfully { get; } // 0x000000018168ED30-0x000000018168ED60 
		public TaskCreationOptions CreationOptions { get; } // 0x000000018168E960-0x000000018168E9B0 
		WaitHandle IAsyncResult.AsyncWaitHandle { get; } // 0x000000018168CED0-0x000000018168CF70 
		public object AsyncState { get; } // 0x00000001802F8630-0x00000001802F8640 
		bool IAsyncResult.CompletedSynchronously { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal TaskScheduler ExecutingTaskScheduler { get; } // 0x000000018033D240-0x000000018033D250 
		public static TaskFactory Factory { [CompilerGenerated] get; } // 0x000000018168EB20-0x000000018168EB70 
		public static Task CompletedTask { [CompilerGenerated] get; } // 0x000000018168E910-0x000000018168E960 
		internal ManualResetEventSlim CompletedEvent { get; } // 0x000000018168E760-0x000000018168E910 
		internal bool ExceptionRecorded { get; } // 0x000000018168EA60-0x000000018168EAD0 
		public bool IsFaulted { get; } // 0x000000018168EE00-0x000000018168EE20 
		internal ExecutionContext CapturedContext { get; set; } // 0x000000018168E6E0-0x000000018168E760 0x000000018168EF50-0x000000018168EFE0
		internal bool IsExceptionObservedByParent { get; } // 0x000000018168EDE0-0x000000018168EE00 
		internal bool IsDelegateInvoked { get; } // 0x000000018168EDC0-0x000000018168EDE0 
	
		// Nested types
		internal class ContingentProperties // TypeDefIndex: 2649
		{
			// Fields
			internal ExecutionContext m_capturedContext; // 0x10
			internal ManualResetEventSlim m_completionEvent; // 0x18
			internal TaskExceptionHolder m_exceptionsHolder; // 0x20
			internal CancellationToken m_cancellationToken; // 0x28
			internal object m_cancellationRegistration; // 0x30
			internal int m_internalCancellationRequested; // 0x38
			internal int m_completionCountdown; // 0x3C
			internal LowLevelListWithIList<Task> m_exceptionalChildren; // 0x40
	
			// Constructors
			public ContingentProperties(); // 0x000000018167DBF0-0x000000018167DC20
	
			// Methods
			internal void SetCompleted(); // 0x000000018167DB10-0x000000018167DB40
			internal void UnregisterCancellationCallback(); // 0x000000018167DB40-0x000000018167DBF0
		}
	
		private sealed class SetOnInvokeMres : ManualResetEventSlim, ITaskCompletionAction // TypeDefIndex: 2650
		{
			// Properties
			public bool InvokeMayRunArbitraryCode { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			internal SetOnInvokeMres(); // 0x00000001816842E0-0x0000000181684330
	
			// Methods
			public void Invoke(Task completingTask); // 0x00000001816842D0-0x00000001816842E0
		}
	
		private sealed class DelayPromise : Task<VoidTaskResult> // TypeDefIndex: 2651
		{
			// Fields
			internal readonly CancellationToken Token; // 0x58
			internal CancellationTokenRegistration Registration; // 0x60
			internal Timer Timer; // 0x78
	
			// Constructors
			internal DelayPromise(CancellationToken token); // 0x0000000181680F80-0x0000000181681000
	
			// Methods
			internal void Complete(); // 0x0000000181680E90-0x0000000181680F80
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2652
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<object> __9__247_0; // 0x08
			public static TimerCallback __9__247_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181693340-0x00000001816933B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Delay_b__247_0(object state); // 0x0000000181692D30-0x0000000181692DA0
			internal void _Delay_b__247_1(object state); // 0x0000000181692DA0-0x0000000181692E10
			internal ContingentProperties _.cctor_b__271_0(); // 0x0000000181692F70-0x0000000181692FC0
			internal bool _.cctor_b__271_1(Task t); // 0x0000000181692FC0-0x0000000181692FF0
			internal bool _.cctor_b__271_2(object tc); // 0x000000018054DF70-0x000000018054DF80
		}
	
		// Constructors
		internal Task(bool canceled, TaskCreationOptions creationOptions, CancellationToken ct); // 0x000000018168E2D0-0x000000018168E3A0
		internal Task(); // 0x000000018168E490-0x000000018168E4C0
		internal Task(object state, TaskCreationOptions creationOptions, bool promiseStyle); // 0x000000018168E4C0-0x000000018168E600
		public Task(Action action, CancellationToken cancellationToken); // 0x000000018168E600-0x000000018168E6B0
		internal Task(Delegate action, object state, Task parent, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler); // 0x000000018168E3A0-0x000000018168E490
		static Task(); // 0x000000018168DED0-0x000000018168E2D0
	
		// Methods
		internal void TaskConstructorCore(Delegate action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions, TaskScheduler scheduler); // 0x000000018168D050-0x000000018168D330
		private void AssignCancellationToken(CancellationToken cancellationToken, Task antecedent, TaskContinuation continuation); // 0x0000000181688120-0x00000001816883B0
		private static void TaskCancelCallback(object o); // 0x000000018168CF80-0x000000018168D050
		internal bool TrySetCanceled(CancellationToken tokenToRecord); // 0x000000018168D380-0x000000018168D390
		internal bool TrySetCanceled(CancellationToken tokenToRecord, object cancellationException); // 0x000000018168D390-0x000000018168D480
		internal bool TrySetException(object exceptionObject); // 0x000000018168D480-0x000000018168D580
		internal static TaskCreationOptions OptionsMethod(int flags); // 0x0000000181565B10-0x0000000181565B20
		internal bool AtomicStateUpdate(int newBits, int illegalBits); // 0x0000000181688480-0x0000000181688530
		internal bool AtomicStateUpdate(int newBits, int illegalBits, ref int oldFlags); // 0x00000001816883B0-0x0000000181688480
		internal void SetNotificationForWaitCompletion(bool enabled); // 0x000000018168C9C0-0x000000018168CA70
		internal bool NotifyDebuggerOfWaitCompletionIfNecessary(); // 0x000000018168B9E0-0x000000018168BA40
		private void NotifyDebuggerOfWaitCompletion(); // 0x000000018168BA40-0x000000018168BA70
		internal bool MarkStarted(); // 0x000000018168B9C0-0x000000018168B9E0
		internal void AddNewChild(); // 0x0000000181687B90-0x0000000181687C90
		internal void DisregardChild(); // 0x00000001816897B0-0x0000000181689870
		internal static Task InternalStartNew(Task creatingTask, Delegate action, object state, CancellationToken cancellationToken, TaskScheduler scheduler, TaskCreationOptions options, InternalTaskOptions internalOptions); // 0x000000018168B1F0-0x000000018168B390
		internal static Task InternalCurrentIfAttached(TaskCreationOptions creationOptions); // 0x000000018168B150-0x000000018168B1F0
		internal ContingentProperties EnsureContingentPropertiesInitialized(bool needsProtection); // 0x0000000181689960-0x0000000181689A60
		private ContingentProperties EnsureContingentPropertiesInitializedCore(bool needsProtection); // 0x0000000181689870-0x0000000181689960
		private static bool IsCompletedMethod(int flags); // 0x000000018168B970-0x000000018168B980
		public void Dispose(); // 0x0000000181689740-0x00000001816897B0
		protected virtual void Dispose(bool disposing); // 0x00000001816895D0-0x0000000181689740
		internal void ScheduleAndStart(bool needsProtection); // 0x000000018168C680-0x000000018168C800
		internal void AddException(object exceptionObject); // 0x00000001816877F0-0x0000000181687800
		internal void AddException(object exceptionObject, bool representsCancellation); // 0x00000001816874A0-0x00000001816877F0
		private AggregateException GetExceptions(bool includeTaskCanceledExceptions); // 0x000000018168ABD0-0x000000018168ADD0
		internal ReadOnlyCollection<ExceptionDispatchInfo> GetExceptionDispatchInfos(); // 0x000000018168A9F0-0x000000018168ABD0
		internal ExceptionDispatchInfo GetCancellationExceptionDispatchInfo(); // 0x000000018168A9B0-0x000000018168A9F0
		internal void ThrowIfExceptional(bool includeTaskCanceledExceptions); // 0x000000018168D330-0x000000018168D380
		internal void UpdateExceptionObservedStatus(); // 0x000000018168D580-0x000000018168D690
		internal void Finish(bool bUserDelegateExecuted); // 0x000000018168A670-0x000000018168A810
		internal void FinishStageTwo(); // 0x000000018168A540-0x000000018168A670
		internal void FinishStageThree(); // 0x000000018168A490-0x000000018168A540
		internal void ProcessChildCompletion(Task childTask); // 0x000000018168BA70-0x000000018168BC70
		internal void AddExceptionsFromChildren(); // 0x0000000181687800-0x0000000181687B90
		private void Execute(); // 0x0000000181689E40-0x0000000181689E80
		void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x000000018168CF70-0x000000018168CF80
		internal bool ExecuteEntry(bool bPreventDoubleExecution); // 0x0000000181689A60-0x0000000181689C10
		private static void ExecutionContextCallback(object obj); // 0x0000000181689E80-0x0000000181689F10
		internal virtual void InnerInvoke(); // 0x000000018168AEE0-0x000000018168AF80
		private void HandleException(Exception unhandledException); // 0x000000018168ADD0-0x000000018168AEE0
		public TaskAwaiter GetAwaiter(); // 0x0000000180E10430-0x0000000180E10450
		public ConfiguredTaskAwaitable ConfigureAwait(bool continueOnCapturedContext); // 0x0000000180E0BF80-0x0000000180E0BFA0
		internal void SetContinuationForAwait(Action continuationAction, bool continueOnCapturedContext, bool flowExecutionContext); // 0x000000018168C830-0x000000018168C9C0
		public static YieldAwaitable Yield(); // 0x00000001802E7840-0x00000001802E7850
		public void Wait(); // 0x000000018168D690-0x000000018168D790
		public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken); // 0x000000018168D790-0x000000018168D900
		private bool WrappedTryRunInline(); // 0x000000018168DE30-0x000000018168DED0
		internal bool InternalWait(int millisecondsTimeout, CancellationToken cancellationToken); // 0x000000018168B390-0x000000018168B970
		private bool SpinThenBlockingWait(int millisecondsTimeout, CancellationToken cancellationToken); // 0x000000018168CA70-0x000000018168CDA0
		private bool SpinWait(int millisecondsTimeout); // 0x000000018168CDA0-0x000000018168CED0
		internal bool InternalCancel(bool bCancelNonExecutingOnly); // 0x000000018168AF80-0x000000018168B150
		internal void RecordInternalCancellationRequest(); // 0x000000018168BDC0-0x000000018168BE80
		internal void RecordInternalCancellationRequest(CancellationToken tokenToRecord); // 0x000000018168BD30-0x000000018168BDC0
		internal void RecordInternalCancellationRequest(CancellationToken tokenToRecord, object cancellationException); // 0x000000018168BC70-0x000000018168BD30
		internal void CancellationCleanupLogic(); // 0x0000000181688530-0x00000001816885E0
		private void SetCancellationAcknowledged(); // 0x000000018168C800-0x000000018168C830
		internal void FinishContinuations(); // 0x0000000181689F10-0x000000018168A490
		private void LogFinishCompletionNotification(); // 0x000000018168B980-0x000000018168B9C0
		public Task ContinueWith(Action<Task> continuationAction); // 0x0000000181688850-0x0000000181688940
		private Task ContinueWith(Action<Task> continuationAction, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions); // 0x0000000181688940-0x0000000181688BF0
		public Task ContinueWith(Action<Task, object> continuationAction, object state, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions, TaskScheduler scheduler); // 0x0000000181688820-0x0000000181688850
		private Task ContinueWith(Action<Task, object> continuationAction, object state, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions continuationOptions); // 0x0000000181688BF0-0x0000000181688EA0
		internal static void CreationOptionsFromContinuationOptions(TaskContinuationOptions continuationOptions, out TaskCreationOptions creationOptions, out InternalTaskOptions internalOptions); // 0x0000000181688EA0-0x0000000181689000
		internal void ContinueWithCore(Task continuationTask, TaskScheduler scheduler, CancellationToken cancellationToken, TaskContinuationOptions options); // 0x00000001816885E0-0x0000000181688820
		internal void AddCompletionAction(ITaskCompletionAction action); // 0x00000001816873B0-0x0000000181687420
		private void AddCompletionAction(ITaskCompletionAction action, bool addBeforeOthers); // 0x0000000181687420-0x00000001816874A0
		private bool AddTaskContinuationComplex(object tc, bool addBeforeOthers); // 0x0000000181687C90-0x0000000181687F20
		private bool AddTaskContinuation(object tc, bool addBeforeOthers); // 0x0000000181687F20-0x0000000181687FE0
		internal void RemoveContinuation(object continuationObject); // 0x000000018168BE80-0x000000018168C0C0
		public static Task<TResult> FromResult<TResult>(TResult result);
		public static Task FromException(Exception exception); // 0x000000018168A950-0x000000018168A9B0
		public static Task<TResult> FromException<TResult>(Exception exception);
		internal static Task FromCancellation(CancellationToken cancellationToken); // 0x000000018168A860-0x000000018168A950
		public static Task FromCanceled(CancellationToken cancellationToken); // 0x000000018168A810-0x000000018168A860
		internal static Task<TResult> FromCancellation<TResult>(CancellationToken cancellationToken);
		public static Task<TResult> FromCanceled<TResult>(CancellationToken cancellationToken);
		internal static Task<TResult> FromCancellation<TResult>(OperationCanceledException exception);
		public static Task Run(Action action); // 0x000000018168C1E0-0x000000018168C3D0
		public static Task<TResult> Run<TResult>(Func<TResult> function);
		public static Task Run(Func<Task> function); // 0x000000018168C3D0-0x000000018168C420
		public static Task Run(Func<Task> function, CancellationToken cancellationToken); // 0x000000018168C420-0x000000018168C680
		public static Task<TResult> Run<TResult>(Func<Task<TResult>> function);
		public static Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken);
		public static Task Delay(int millisecondsDelay); // 0x0000000181689000-0x0000000181689050
		public static Task Delay(int millisecondsDelay, CancellationToken cancellationToken); // 0x0000000181689050-0x00000001816895D0
		public static Task<Task> WhenAny(params Task[] tasks); // 0x000000018168DBE0-0x000000018168DE30
		public static Task<Task> WhenAny(IEnumerable<Task> tasks); // 0x000000018168D900-0x000000018168DBE0
		[FriendAccessAllowed]
		internal static bool AddToActiveTasks(Task task); // 0x0000000181687FE0-0x0000000181688120
		[FriendAccessAllowed]
		internal static void RemoveFromActiveTasks(int taskId); // 0x000000018168C0C0-0x000000018168C1E0
		public void MarkAborted(ThreadAbortException e); // 0x00000001802E76C0-0x00000001802E76D0
		private void ExecuteWithThreadLocal(ref Task currentTaskSlot); // 0x0000000181689C10-0x0000000181689E40
	}
}
