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
	public class TaskFactory<TResult> // TypeDefIndex: 2642
	{
		// Fields
		private CancellationToken m_defaultCancellationToken;
		private TaskScheduler m_defaultScheduler;
		private TaskCreationOptions m_defaultCreationOptions;
		private TaskContinuationOptions m_defaultContinuationOptions;
	
		// Nested types
		private sealed class FromAsyncTrimPromise<TInstance> : Task<TResult> // TypeDefIndex: 2643
			where TInstance : class
		{
			// Fields
			internal static readonly AsyncCallback s_completeFromAsyncResult;
			private TInstance m_thisRef;
			private Func<TInstance, IAsyncResult, TResult> m_endMethod;
	
			// Constructors
			internal FromAsyncTrimPromise(TInstance thisRef, Func<TInstance, IAsyncResult, TResult> endMethod);
			static FromAsyncTrimPromise();
	
			// Methods
			internal static void CompleteFromAsyncResult(IAsyncResult asyncResult);
			internal void Complete(TInstance thisRef, Func<TInstance, IAsyncResult, TResult> endMethod, IAsyncResult asyncResult, bool requiresSynchronization);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass35_0 // TypeDefIndex: 2644
		{
			// Fields
			public Func<IAsyncResult, TResult> endFunction;
			public Action<IAsyncResult> endAction;
			public Task<TResult> promise;
	
			// Constructors
			public __c__DisplayClass35_0();
	
			// Methods
			internal void _FromAsyncImpl_b__0(IAsyncResult iar);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass38_0<TArg1> // TypeDefIndex: 2645
		{
			// Fields
			public Func<IAsyncResult, TResult> endFunction;
			public Action<IAsyncResult> endAction;
			public Task<TResult> promise;
	
			// Constructors
			public __c__DisplayClass38_0();
	
			// Methods
			internal void _FromAsyncImpl_b__0(IAsyncResult iar);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass41_0<TArg1, TArg2> // TypeDefIndex: 2646
		{
			// Fields
			public Func<IAsyncResult, TResult> endFunction;
			public Action<IAsyncResult> endAction;
			public Task<TResult> promise;
	
			// Constructors
			public __c__DisplayClass41_0();
	
			// Methods
			internal void _FromAsyncImpl_b__0(IAsyncResult iar);
		}
	
		// Constructors
		public TaskFactory();
		public TaskFactory(CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskContinuationOptions continuationOptions, TaskScheduler scheduler);
	
		// Methods
		public Task<TResult> StartNew(Func<object, TResult> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions, TaskScheduler scheduler);
		private static void FromAsyncCoreLogic(IAsyncResult iar, Func<IAsyncResult, TResult> endFunction, Action<IAsyncResult> endAction, Task<TResult> promise, bool requiresSynchronization);
		public Task<TResult> FromAsync(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, object state);
		internal static Task<TResult> FromAsyncImpl(Func<AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endFunction, Action<IAsyncResult> endAction, object state, TaskCreationOptions creationOptions);
		public Task<TResult> FromAsync<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endMethod, TArg1 arg1, object state);
		internal static Task<TResult> FromAsyncImpl<TArg1>(Func<TArg1, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endFunction, Action<IAsyncResult> endAction, TArg1 arg1, object state, TaskCreationOptions creationOptions);
		internal static Task<TResult> FromAsyncImpl<TArg1, TArg2>(Func<TArg1, TArg2, AsyncCallback, object, IAsyncResult> beginMethod, Func<IAsyncResult, TResult> endFunction, Action<IAsyncResult> endAction, TArg1 arg1, TArg2 arg2, object state, TaskCreationOptions creationOptions);
		internal static Task<TResult> FromAsyncTrim<TInstance, TArgs>(TInstance thisRef, TArgs args, Func<TInstance, TArgs, AsyncCallback, object, IAsyncResult> beginMethod, Func<TInstance, IAsyncResult, TResult> endMethod)
			where TInstance : class;
	}
}
