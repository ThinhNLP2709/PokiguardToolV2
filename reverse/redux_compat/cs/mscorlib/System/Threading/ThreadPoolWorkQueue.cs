/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	internal sealed class ThreadPoolWorkQueue // TypeDefIndex: 2597
	{
		// Fields
		internal QueueSegment queueHead; // 0x10
		internal QueueSegment queueTail; // 0x18
		internal static SparseArray<WorkStealingQueue> allThreadQueues; // 0x00
		private int numOutstandingThreadRequests; // 0x20
	
		// Nested types
		internal class SparseArray<T> // TypeDefIndex: 2598
			where T : class
		{
			// Fields
			private T[] m_array;
	
			// Properties
			internal T[] Current { get; }
	
			// Constructors
			internal SparseArray(int initialSize);
	
			// Methods
			internal int Add(T e);
			internal void Remove(T e);
		}
	
		internal class WorkStealingQueue // TypeDefIndex: 2599
		{
			// Fields
			internal IThreadPoolWorkItem[] m_array; // 0x10
			private int m_mask; // 0x18
			private int m_headIndex; // 0x1C
			private int m_tailIndex; // 0x20
			private SpinLock m_foreignLock; // 0x24
	
			// Constructors
			public WorkStealingQueue(); // 0x00000001816963B0-0x0000000181696450
	
			// Methods
			public void LocalPush(IThreadPoolWorkItem obj); // 0x0000000181695BA0-0x0000000181696110
			public bool LocalFindAndPop(IThreadPoolWorkItem obj); // 0x0000000181695520-0x0000000181695870
			public bool LocalPop(out IThreadPoolWorkItem obj); // 0x0000000181695870-0x0000000181695BA0
			public bool TrySteal(out IThreadPoolWorkItem obj, ref bool missedSteal); // 0x0000000181696390-0x00000001816963B0
			private bool TrySteal(out IThreadPoolWorkItem obj, ref bool missedSteal, int millisecondsTimeout); // 0x0000000181696110-0x0000000181696390
		}
	
		internal class QueueSegment // TypeDefIndex: 2600
		{
			// Fields
			internal readonly IThreadPoolWorkItem[] nodes; // 0x10
			private int indexes; // 0x18
			public QueueSegment Next; // 0x20
	
			// Constructors
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
			public QueueSegment(); // 0x00000001816821E0-0x0000000181682240
	
			// Methods
			private void GetIndexes(out int upper, out int lower); // 0x0000000181681F20-0x0000000181681F60
			private bool CompareExchangeIndexes(ref int prevUpper, int newUpper, ref int prevLower, int newLower); // 0x0000000181681EA0-0x0000000181681F20
			public bool IsUsedUp(); // 0x0000000181681F60-0x0000000181681FC0
			public bool TryEnqueue(IThreadPoolWorkItem node); // 0x0000000181682110-0x00000001816821E0
			public bool TryDequeue(out IThreadPoolWorkItem node); // 0x0000000181681FC0-0x0000000181682110
		}
	
		// Constructors
		public ThreadPoolWorkQueue(); // 0x0000000181690B70-0x0000000181690C30
		static ThreadPoolWorkQueue(); // 0x0000000181690AE0-0x0000000181690B70
	
		// Methods
		public ThreadPoolWorkQueueThreadLocals EnsureCurrentThreadHasQueue(); // 0x00000001816908F0-0x0000000181690990
		internal void EnsureThreadRequested(); // 0x0000000181690990-0x0000000181690A30
		internal void MarkThreadRequestSatisfied(); // 0x0000000181690A90-0x0000000181690AE0
		public void Enqueue(IThreadPoolWorkItem callback, bool forceGlobal); // 0x00000001816906B0-0x00000001816908F0
		internal bool LocalFindAndPop(IThreadPoolWorkItem callback); // 0x0000000181690A30-0x0000000181690A90
		public void Dequeue(ThreadPoolWorkQueueThreadLocals tl, out IThreadPoolWorkItem callback, out bool missedSteal); // 0x000000018168FE00-0x0000000181690170
		internal static bool Dispatch(); // 0x0000000181690170-0x00000001816906B0
	}
}
