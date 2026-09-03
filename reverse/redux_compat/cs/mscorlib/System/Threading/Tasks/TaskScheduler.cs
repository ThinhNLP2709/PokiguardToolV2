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
	[DebuggerDisplay("Id={Id}")]
	[DebuggerTypeProxy(typeof(SystemThreadingTasks_TaskSchedulerDebugView))]
	public abstract class TaskScheduler // TypeDefIndex: 2676
	{
		// Fields
		private static readonly TaskScheduler s_defaultTaskScheduler; // 0x00
		internal static int s_taskSchedulerIdCounter; // 0x08
		private int m_taskSchedulerId; // 0x10
		private static EventHandler<UnobservedTaskExceptionEventArgs> _unobservedTaskException; // 0x10
		private static readonly Lock _unobservedTaskExceptionLockObject; // 0x18
	
		// Properties
		internal virtual bool RequiresAtomicStartTransition { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public static TaskScheduler Default { get; } // 0x0000000181686C70-0x0000000181686CC0 
		public static TaskScheduler Current { get; } // 0x0000000181686BE0-0x0000000181686C70 
		internal static TaskScheduler InternalCurrent { get; } // 0x0000000181686D60-0x0000000181686E40 
		public int Id { get; } // 0x0000000181686CC0-0x0000000181686D60 
	
		// Nested types
		internal sealed class SystemThreadingTasks_TaskSchedulerDebugView // TypeDefIndex: 2677
		{
		}
	
		// Constructors
		protected TaskScheduler(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static TaskScheduler(); // 0x0000000181686AE0-0x0000000181686BE0
	
		// Methods
		protected internal abstract void QueueTask(Task task);
		protected abstract bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued);
		internal bool TryRunInline(Task task, bool taskWasPreviouslyQueued); // 0x0000000181686800-0x0000000181686AE0
		protected internal virtual bool TryDequeue(Task task); // 0x00000001802E7840-0x00000001802E7850
		internal virtual void NotifyWorkItemProgress(); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void PublishUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs ueea); // 0x00000001816866B0-0x0000000181686800
	}
}
