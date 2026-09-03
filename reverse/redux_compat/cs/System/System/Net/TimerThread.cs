/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal static class TimerThread // TypeDefIndex: 9072
	{
		// Fields
		private static LinkedList<WeakReference> s_Queues; // 0x00
		private static LinkedList<WeakReference> s_NewQueues; // 0x08
		private static int s_ThreadState; // 0x10
		private static AutoResetEvent s_ThreadReadyEvent; // 0x18
		private static ManualResetEvent s_ThreadShutdownEvent; // 0x20
		private static WaitHandle[] s_ThreadEvents; // 0x28
		private static int s_CacheScanIteration; // 0x30
		private static Hashtable s_QueuesCache; // 0x38
	
		// Nested types
		internal abstract class Queue // TypeDefIndex: 9073
		{
			// Fields
			private readonly int m_DurationMilliseconds; // 0x10
	
			// Properties
			internal int Duration { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
			// Constructors
			internal Queue(int durationMilliseconds); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			internal abstract Timer CreateTimer(Callback callback, object context);
		}
	
		internal abstract class Timer : IDisposable // TypeDefIndex: 9074
		{
			// Fields
			private readonly int m_StartTimeMilliseconds; // 0x10
			private readonly int m_DurationMilliseconds; // 0x14
	
			// Properties
			internal int StartTime { get; } // 0x00000001802E64B0-0x00000001802E64C0 
			internal int Expiration { get; } // 0x0000000181C137D0-0x0000000181C137E0 
			internal abstract bool HasExpired { get; }
	
			// Constructors
			internal Timer(int durationMilliseconds); // 0x0000000181C137A0-0x0000000181C137D0
	
			// Methods
			internal abstract bool Cancel();
			public void Dispose(); // 0x00000001819D61B0-0x00000001819D61D0
		}
	
		internal delegate void Callback(Timer timer, int timeNoticed, object context); // TypeDefIndex: 9075; 0x0000000180A72B30-0x0000000180A72B50
	
		private class TimerQueue : Queue // TypeDefIndex: 9076
		{
			// Fields
			private IntPtr m_ThisHandle; // 0x18
			private readonly TimerNode m_Timers; // 0x20
	
			// Constructors
			internal TimerQueue(int durationMilliseconds); // 0x0000000181C11EE0-0x0000000181C11FA0
	
			// Methods
			internal override Timer CreateTimer(Callback callback, object context); // 0x0000000181C119C0-0x0000000181C11D30
			internal bool Fire(out int nextExpiration); // 0x0000000181C11D30-0x0000000181C11EE0
		}
	
		private class InfiniteTimerQueue : Queue // TypeDefIndex: 9077
		{
			// Constructors
			internal InfiniteTimerQueue(); // 0x0000000181C0FC00-0x0000000181C0FC20
	
			// Methods
			internal override Timer CreateTimer(Callback callback, object context); // 0x0000000181C0FBA0-0x0000000181C0FC00
		}
	
		private class TimerNode : Timer // TypeDefIndex: 9078
		{
			// Fields
			private TimerState m_TimerState; // 0x18
			private Callback m_Callback; // 0x20
			private object m_Context; // 0x28
			private object m_QueueLock; // 0x30
			private TimerNode next; // 0x38
			private TimerNode prev; // 0x40
	
			// Properties
			internal override bool HasExpired { get; } // 0x0000000181C119B0-0x0000000181C119C0 
			internal TimerNode Next { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
			internal TimerNode Prev { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
			// Nested types
			private enum TimerState // TypeDefIndex: 9079
			{
				Ready = 0,
				Fired = 1,
				Cancelled = 2,
				Sentinel = 3
			}
	
			// Constructors
			internal TimerNode(Callback callback, object context, int durationMilliseconds, object queueLock); // 0x0000000181C11920-0x0000000181C119B0
			internal TimerNode(); // 0x0000000181C118F0-0x0000000181C11920
	
			// Methods
			internal override bool Cancel(); // 0x0000000181C11500-0x0000000181C11660
			internal bool Fire(); // 0x0000000181C11660-0x0000000181C118F0
		}
	
		private class InfiniteTimer : Timer // TypeDefIndex: 9080
		{
			// Fields
			private int cancelled; // 0x18
	
			// Properties
			internal override bool HasExpired { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			internal InfiniteTimer(); // 0x0000000181C0FC30-0x0000000181C0FC60
	
			// Methods
			internal override bool Cancel(); // 0x0000000181C0FC20-0x0000000181C0FC30
		}
	
		// Constructors
		static TimerThread(); // 0x0000000181C13470-0x0000000181C137A0
	
		// Methods
		internal static Queue CreateQueue(int durationMilliseconds); // 0x0000000181C11FA0-0x0000000181C121C0
		internal static Queue GetOrCreateQueue(int durationMilliseconds); // 0x0000000181C121C0-0x0000000181C129F0
		private static void Prod(); // 0x0000000181C12AC0-0x0000000181C12BD0
		private static void ThreadProc(); // 0x0000000181C12C50-0x0000000181C13470
		private static void StopTimerThread(); // 0x0000000181C12BD0-0x0000000181C12C50
		private static bool IsTickBetween(int start, int end, int comparand); // 0x0000000181C129F0-0x0000000181C12A10
		private static void OnDomainUnload(object sender, EventArgs e); // 0x0000000181C12A10-0x0000000181C12AC0
	}
}
