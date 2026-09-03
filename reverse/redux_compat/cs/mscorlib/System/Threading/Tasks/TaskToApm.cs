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
	internal static class TaskToApm // TypeDefIndex: 2628
	{
		// Nested types
		private sealed class TaskWrapperAsyncResult : IAsyncResult // TypeDefIndex: 2629
		{
			// Fields
			internal readonly Task Task; // 0x10
			private readonly object _state; // 0x18
			private readonly bool _completedSynchronously; // 0x20
	
			// Properties
			object IAsyncResult.AsyncState { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			bool IAsyncResult.CompletedSynchronously { get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
			bool IAsyncResult.IsCompleted { get; } // 0x0000000181687350-0x00000001816873B0 
			WaitHandle IAsyncResult.AsyncWaitHandle { get; } // 0x0000000181687290-0x0000000181687350 
	
			// Constructors
			internal TaskWrapperAsyncResult(Task task, object state, bool completedSynchronously); // 0x00000001815014B0-0x0000000181501520
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 2630
		{
			// Fields
			public AsyncCallback callback; // 0x10
			public IAsyncResult asyncResult; // 0x18
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _InvokeCallbackWhenTaskCompletes_b__0(); // 0x0000000181681950-0x0000000181681980
		}
	
		// Methods
		public static IAsyncResult Begin(Task task, AsyncCallback callback, object state); // 0x0000000181686E40-0x0000000181687070
		public static void End(IAsyncResult asyncResult); // 0x0000000181687070-0x0000000181687170
		public static TResult End<TResult>(IAsyncResult asyncResult);
		private static void InvokeCallbackWhenTaskCompletes(Task antecedent, AsyncCallback callback, IAsyncResult asyncResult); // 0x0000000181687170-0x0000000181687290
	}
}
