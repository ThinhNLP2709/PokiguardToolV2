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
	internal sealed class ThreadPoolTaskScheduler : TaskScheduler // TypeDefIndex: 2679
	{
		// Fields
		private static readonly ParameterizedThreadStart s_longRunningThreadWork; // 0x00
	
		// Properties
		internal override bool RequiresAtomicStartTransition { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2680
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001816932D0-0x0000000181693340
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _.cctor_b__10_0(object s); // 0x0000000181692EF0-0x0000000181692F70
		}
	
		// Constructors
		internal ThreadPoolTaskScheduler(); // 0x000000018168FA20-0x000000018168FA70
		static ThreadPoolTaskScheduler(); // 0x000000018168F950-0x000000018168FA20
	
		// Methods
		protected internal override void QueueTask(Task task); // 0x000000018168F5C0-0x000000018168F860
		protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued); // 0x000000018168F870-0x000000018168F950
		protected internal override bool TryDequeue(Task task); // 0x000000018168F860-0x000000018168F870
		internal override void NotifyWorkItemProgress(); // 0x000000018168F5A0-0x000000018168F5C0
	}
}
