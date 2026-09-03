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
	internal sealed class TaskSchedulerAwaitTaskContinuation : AwaitTaskContinuation // TypeDefIndex: 2670
	{
		// Fields
		private readonly TaskScheduler m_scheduler; // 0x20
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2671
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<object> __9__2_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181693260-0x00000001816932D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Run_b__2_0(object state); // 0x0000000181692E70-0x0000000181692EF0
		}
	
		// Constructors
		internal TaskSchedulerAwaitTaskContinuation(TaskScheduler scheduler, Action action, bool flowExecutionContext); // 0x0000000181684960-0x00000001816849A0
	
		// Methods
		internal sealed override void Run(Task ignored, bool canInlineContinuationTask); // 0x0000000181686290-0x00000001816865F0
	}
}
