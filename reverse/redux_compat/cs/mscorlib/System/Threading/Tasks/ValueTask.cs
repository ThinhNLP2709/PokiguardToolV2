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
	[AsyncMethodBuilder(typeof(AsyncValueTaskMethodBuilder))]
	[IsReadOnly]
	public struct ValueTask : IEquatable<ValueTask> // TypeDefIndex: 2631
	{
		// Fields
		private static readonly Task s_canceledTask; // 0x00
		internal readonly object _obj; // 0x00
		internal readonly short _token; // 0x08
		internal readonly bool _continueOnCapturedContext; // 0x0A
	
		// Properties
		internal static Task CompletedTask { get; } // 0x0000000181693EA0-0x0000000181693F30 
		public bool IsCompleted { get; } // 0x0000000181693F30-0x0000000181694020 
	
		// Nested types
		private sealed class ValueTaskSourceAsTask : Task<VoidTaskResult> // TypeDefIndex: 2632
		{
			// Fields
			private static readonly Action<object> s_completionAction; // 0x00
			private IValueTaskSource _source; // 0x58
			private readonly short _token; // 0x60
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 2633
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001816933B0-0x0000000181693420
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.cctor_b__4_0(object state); // 0x0000000181692FF0-0x0000000181693180
			}
	
			// Constructors
			public ValueTaskSourceAsTask(IValueTaskSource source, short token); // 0x00000001816935D0-0x0000000181693720
			static ValueTaskSourceAsTask(); // 0x0000000181693500-0x00000001816935D0
		}
	
		// Constructors
		public ValueTask(Task task); // 0x0000000181693E50-0x0000000181693EA0
		public ValueTask(IValueTaskSource source, short token); // 0x0000000181693DC0-0x0000000181693E10
		private ValueTask(object obj, short token, bool continueOnCapturedContext); // 0x0000000181693E10-0x0000000181693E50
		static ValueTask(); // 0x0000000181693CF0-0x0000000181693DC0
	
		// Methods
		public override int GetHashCode(); // 0x0000000181693930-0x0000000181693950
		public override bool Equals(object obj); // 0x0000000181693860-0x0000000181693910
		public bool Equals(ValueTask other); // 0x0000000181693910-0x0000000181693930
		public Task AsTask(); // 0x0000000181693720-0x00000001816937F0
		private Task GetTaskForValueTaskSource(IValueTaskSource t); // 0x0000000181693950-0x0000000181693C50
		[StackTraceHidden]
		internal void ThrowIfCompletedUnsuccessfully(); // 0x0000000181693C50-0x0000000181693CF0
		public ValueTaskAwaiter GetAwaiter(); // 0x0000000180DE2BA0-0x0000000180DE2BC0
		public ConfiguredValueTaskAwaitable ConfigureAwait(bool continueOnCapturedContext); // 0x00000001816937F0-0x0000000181693860
	}
}
