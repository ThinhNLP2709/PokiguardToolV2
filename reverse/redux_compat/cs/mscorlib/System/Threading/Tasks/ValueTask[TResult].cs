/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Sources;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	[AsyncMethodBuilder(typeof(AsyncValueTaskMethodBuilder<TResult>))]
	[IsReadOnly]
	public struct ValueTask<TResult> : IEquatable<ValueTask<TResult>> // TypeDefIndex: 2634
	{
		// Fields
		private static Task<TResult> s_canceledTask;
		internal readonly object _obj;
		internal readonly TResult _result;
		internal readonly short _token;
		internal readonly bool _continueOnCapturedContext;
	
		// Properties
		public bool IsCompleted { get; }
		public bool IsCompletedSuccessfully { get; }
		public TResult Result { get; }
	
		// Nested types
		private sealed class ValueTaskSourceAsTask : Task<TResult> // TypeDefIndex: 2635
		{
			// Fields
			private static readonly Action<object> s_completionAction;
			private IValueTaskSource<TResult> _source;
			private readonly short _token;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 2636
			{
				// Fields
				public static readonly __c<TResult> __9;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal void _.cctor_b__4_0(object state);
			}
	
			// Constructors
			public ValueTaskSourceAsTask(IValueTaskSource<TResult> source, short token);
			static ValueTaskSourceAsTask();
		}
	
		// Constructors
		public ValueTask(TResult result);
		public ValueTask(Task<TResult> task);
		public ValueTask(IValueTaskSource<TResult> source, short token);
		private ValueTask(object obj, TResult result, short token, bool continueOnCapturedContext);
	
		// Methods
		public override int GetHashCode();
		public override bool Equals(object obj);
		public bool Equals(ValueTask<TResult> other);
		public Task<TResult> AsTask();
		private Task<TResult> GetTaskForValueTaskSource(IValueTaskSource<TResult> t);
		public ValueTaskAwaiter<TResult> GetAwaiter();
		public ConfiguredValueTaskAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);
		public override string ToString();
	}
}
