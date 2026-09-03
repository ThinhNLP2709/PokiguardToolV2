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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[ComVisible(true)]
	public sealed class Timer : MarshalByRefObject, IDisposable // TypeDefIndex: 2614
	{
		// Fields
		private TimerCallback callback; // 0x18
		private object state; // 0x20
		private long due_time_ms; // 0x28
		private long period_ms; // 0x30
		private long next_run; // 0x38
		private bool disposed; // 0x40
		private bool is_dead; // 0x41
		private bool is_added; // 0x42
	
		// Properties
		private static Scheduler scheduler { get; } // 0x0000000181692CA0-0x0000000181692D30 
	
		// Nested types
		private struct TimerComparer : IComparer, IComparer<Timer> // TypeDefIndex: 2615
		{
			// Methods
			int IComparer.Compare(object x, object y); // 0x0000000181692590-0x0000000181692680
			public int Compare(Timer tx, Timer ty); // 0x0000000181692520-0x0000000181692590
		}
	
		private sealed class Scheduler // TypeDefIndex: 2616
		{
			// Fields
			private static readonly Scheduler instance; // 0x00
			private bool needReSort; // 0x10
			private List<Timer> list; // 0x18
			private long current_next_run; // 0x20
			private ManualResetEvent changed; // 0x28
	
			// Properties
			public static Scheduler Instance { get; } // 0x0000000181684280-0x00000001816842D0 
	
			// Constructors
			private Scheduler(); // 0x0000000181684050-0x0000000181684280
			static Scheduler(); // 0x0000000181683FE0-0x0000000181684050
	
			// Methods
			private void InitScheduler(); // 0x0000000181683770-0x0000000181683920
			private void WakeupScheduler(); // 0x0000000181683FC0-0x0000000181683FE0
			private void SchedulerThread(); // 0x0000000181683D80-0x0000000181683F40
			public void Remove(Timer timer); // 0x0000000181683950-0x0000000181683A00
			public void Change(Timer timer, long new_next_run); // 0x0000000181683440-0x00000001816836A0
			private void Add(Timer timer); // 0x0000000181683360-0x0000000181683440
			private void InternalRemove(Timer timer); // 0x0000000181683920-0x0000000181683950
			private static void TimerCB(object o); // 0x0000000181683F40-0x0000000181683FC0
			private void FireTimer(Timer timer); // 0x00000001816836A0-0x0000000181683770
			private int RunSchedulerLoop(); // 0x0000000181683A00-0x0000000181683D80
		}
	
		// Constructors
		public Timer(TimerCallback callback, object state, int dueTime, int period); // 0x0000000181692AB0-0x0000000181692B80
		public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period); // 0x0000000181692B80-0x0000000181692CA0
	
		// Methods
		private void Init(TimerCallback callback, object state, long dueTime, long period); // 0x00000001816929F0-0x0000000181692AB0
		public bool Change(int dueTime, int period); // 0x00000001816928F0-0x0000000181692910
		public bool Change(TimeSpan dueTime, TimeSpan period); // 0x0000000181692910-0x00000001816929A0
		public void Dispose(); // 0x00000001816929A0-0x00000001816929E0
		private bool Change(long dueTime, long period, bool first); // 0x0000000181692680-0x00000001816928F0
		internal void KeepRootedWhileScheduled(); // 0x00000001802E76C0-0x00000001802E76D0
		private static long GetTimeMonotonic(); // 0x00000001816929E0-0x00000001816929F0
	}
}
