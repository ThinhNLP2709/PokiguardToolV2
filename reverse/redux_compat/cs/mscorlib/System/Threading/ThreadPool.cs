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

namespace System.Threading
{
	public static class ThreadPool // TypeDefIndex: 2604
	{
		// Properties
		internal static bool IsThreadPoolThread { get; } // 0x0000000181691490-0x00000001816914F0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0<TState> // TypeDefIndex: 2605
		{
			// Fields
			public Action<TState> callBack;
	
			// Constructors
			public __c__DisplayClass17_0();
	
			// Methods
			internal void _QueueUserWorkItem_b__0(object x);
		}
	
		// Methods
		private static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, uint millisecondsTimeOutInterval, bool executeOnlyOnce, ref StackCrawlMark stackMark, bool compressStack); // 0x0000000181691050-0x00000001816912D0
		public static RegisteredWaitHandle RegisterWaitForSingleObject(WaitHandle waitObject, WaitOrTimerCallback callBack, object state, TimeSpan timeout, bool executeOnlyOnce); // 0x0000000181690ED0-0x0000000181691050
		public static bool QueueUserWorkItem(WaitCallback callBack, object state); // 0x0000000181690EA0-0x0000000181690ED0
		public static bool QueueUserWorkItem(WaitCallback callBack); // 0x0000000181690E70-0x0000000181690EA0
		public static bool UnsafeQueueUserWorkItem(WaitCallback callBack, object state); // 0x0000000181691460-0x0000000181691490
		public static bool QueueUserWorkItem<TState>(Action<TState> callBack, TState state, bool preferLocal);
		private static bool QueueUserWorkItemHelper(WaitCallback callBack, object state, ref StackCrawlMark stackMark, bool compressStack, bool forceGlobal = true /* Metadata: 0x0064EA28 */); // 0x0000000181690CF0-0x0000000181690E70
		internal static void UnsafeQueueCustomWorkItem(IThreadPoolWorkItem workItem, bool forceGlobal); // 0x00000001816913C0-0x0000000181691460
		internal static bool TryPopCustomWorkItem(IThreadPoolWorkItem workItem); // 0x00000001816912E0-0x00000001816913C0
		internal static bool RequestWorkerThread(); // 0x00000001816912D0-0x00000001816912E0
		private static void EnsureVMInitialized(); // 0x0000000181690C30-0x0000000181690CC0
		internal static bool NotifyWorkItemComplete(); // 0x0000000181690CD0-0x0000000181690CE0
		internal static void ReportThreadStatus(bool isWorking); // 0x0000000181536B00-0x0000000181536B10
		internal static void NotifyWorkItemProgress(); // 0x000000018168F5A0-0x000000018168F5C0
		internal static void NotifyWorkItemProgressNative(); // 0x0000000181690CE0-0x0000000181690CF0
		internal static void NotifyWorkItemQueued(); // 0x0000000181539480-0x0000000181539490
		private static void InitializeVMTp(ref bool enableWorkerTracking); // 0x0000000181690CC0-0x0000000181690CD0
	}
}
