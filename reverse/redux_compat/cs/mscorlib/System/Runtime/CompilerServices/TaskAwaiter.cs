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
	public struct TaskAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3217
	{
		// Fields
		internal readonly Task m_task; // 0x00
	
		// Properties
		public bool IsCompleted { get; } // 0x0000000180DE29E0-0x0000000180DE2A00 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_0 // TypeDefIndex: 3218
		{
			// Fields
			public Task task; // 0x10
			public Action continuation; // 0x18
	
			// Constructors
			public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _OutputWaitEtwEvents_b__0(); // 0x000000018151BF70-0x000000018151C100
		}
	
		// Constructors
		internal TaskAwaiter(Task task); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		public void OnCompleted(Action continuation); // 0x000000018151B710-0x000000018151B7C0
		public void UnsafeOnCompleted(Action continuation); // 0x000000018151BB20-0x000000018151BBD0
		[StackTraceHidden]
		public void GetResult(); // 0x000000018150AF00-0x000000018150AF50
		[StackTraceHidden]
		internal static void ValidateEnd(Task task); // 0x000000018151BBD0-0x000000018151BC20
		[StackTraceHidden]
		private static void HandleNonSuccessAndDebuggerNotification(Task task); // 0x000000018151B4B0-0x000000018151B640
		[StackTraceHidden]
		private static void ThrowForNonSuccess(Task task); // 0x000000018151B9C0-0x000000018151BB20
		internal static void OnCompletedInternal(Task task, Action continuation, bool continueOnCapturedContext, bool flowExecutionContext); // 0x000000018151B640-0x000000018151B710
		private static Action OutputWaitEtwEvents(Task task, Action continuation); // 0x000000018151B7C0-0x000000018151B9C0
	}
}
