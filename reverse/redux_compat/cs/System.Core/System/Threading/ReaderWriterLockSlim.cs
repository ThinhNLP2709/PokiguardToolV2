/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Threading
{
	public class ReaderWriterLockSlim : IDisposable // TypeDefIndex: 12604
	{
		// Fields
		private bool fIsReentrant; // 0x10
		private int myLock; // 0x14
		private uint numWriteWaiters; // 0x18
		private uint numReadWaiters; // 0x1C
		private uint numWriteUpgradeWaiters; // 0x20
		private uint numUpgradeWaiters; // 0x24
		private bool fNoWaiters; // 0x28
		private int upgradeLockOwnerId; // 0x2C
		private int writeLockOwnerId; // 0x30
		private EventWaitHandle writeEvent; // 0x38
		private EventWaitHandle readEvent; // 0x40
		private EventWaitHandle upgradeEvent; // 0x48
		private EventWaitHandle waitUpgradeEvent; // 0x50
		private static long s_nextLockID; // 0x00
		private long lockID; // 0x58
		[ThreadStatic]
		private static ReaderWriterCount t_rwc; // 0x80000000
		private bool fUpgradeThreadHoldingRead; // 0x60
		private uint owners; // 0x64
		private bool fDisposed; // 0x68
	
		// Properties
		public bool IsReadLockHeld { get; } // 0x0000000181808CE0-0x0000000181808D60 
		public bool IsUpgradeableReadLockHeld { get; } // 0x0000000181808D60-0x0000000181808E00 
		public bool IsWriteLockHeld { get; } // 0x0000000181808E00-0x0000000181808EA0 
		public int RecursiveReadCount { get; } // 0x0000000181808EA0-0x0000000181808F10 
		public int RecursiveUpgradeCount { get; } // 0x0000000181808F10-0x0000000181808FD0 
		public int RecursiveWriteCount { get; } // 0x0000000181808FD0-0x0000000181809090 
		public int WaitingReadCount { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public int WaitingUpgradeCount { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public int WaitingWriteCount { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Nested types
		private struct TimeoutTracker // TypeDefIndex: 12605
		{
			// Fields
			private int m_total; // 0x00
			private int m_start; // 0x04
	
			// Properties
			public int RemainingMilliseconds { get; } // 0x00000001818095E0-0x0000000181809620 
			public bool IsExpired { get; } // 0x0000000181809590-0x00000001818095E0 
	
			// Constructors
			public TimeoutTracker(int millisecondsTimeout); // 0x0000000181809510-0x0000000181809590
		}
	
		// Constructors
		public ReaderWriterLockSlim(); // 0x0000000181808C80-0x0000000181808CE0
		public ReaderWriterLockSlim(LockRecursionPolicy recursionPolicy); // 0x0000000181808C10-0x0000000181808C80
	
		// Methods
		private void InitializeThreadCounts(); // 0x0000000181807A60-0x0000000181807A70
		private static bool IsRWEntryEmpty(ReaderWriterCount rwc); // 0x0000000181807A70-0x0000000181807AB0
		private bool IsRwHashEntryChanged(ReaderWriterCount lrwc); // 0x0000000181807AB0-0x0000000181807AD0
		private ReaderWriterCount GetThreadRWCount(bool dontAllocate); // 0x0000000181807920-0x0000000181807A60
		public void EnterReadLock(); // 0x0000000181807000-0x0000000181807020
		public bool TryEnterReadLock(int millisecondsTimeout); // 0x0000000181807FE0-0x0000000181808070
		private bool TryEnterReadLock(TimeoutTracker timeout); // 0x0000000181808070-0x0000000181808080
		private bool TryEnterReadLockCore(TimeoutTracker timeout); // 0x0000000181807C80-0x0000000181807FE0
		public void EnterWriteLock(); // 0x0000000181807040-0x0000000181807060
		public bool TryEnterWriteLock(int millisecondsTimeout); // 0x0000000181808A20-0x0000000181808AB0
		private bool TryEnterWriteLock(TimeoutTracker timeout); // 0x0000000181808A10-0x0000000181808A20
		private bool TryEnterWriteLockCore(TimeoutTracker timeout); // 0x0000000181808580-0x0000000181808A10
		public void EnterUpgradeableReadLock(); // 0x0000000181807020-0x0000000181807040
		public bool TryEnterUpgradeableReadLock(int millisecondsTimeout); // 0x00000001818084F0-0x0000000181808580
		private bool TryEnterUpgradeableReadLock(TimeoutTracker timeout); // 0x00000001818084E0-0x00000001818084F0
		private bool TryEnterUpgradeableReadLockCore(TimeoutTracker timeout); // 0x0000000181808080-0x00000001818084E0
		public void ExitReadLock(); // 0x0000000181807250-0x0000000181807430
		public void ExitWriteLock(); // 0x0000000181807720-0x0000000181807910
		public void ExitUpgradeableReadLock(); // 0x0000000181807430-0x0000000181807720
		private void LazyCreateEvent(ref EventWaitHandle waitEvent, bool makeAutoResetEvent); // 0x0000000181807AE0-0x0000000181807BD0
		private bool WaitOnEvent(EventWaitHandle waitEvent, ref uint numWaiters, TimeoutTracker timeout, bool isWriteWaiter); // 0x0000000181808AB0-0x0000000181808C10
		private void ExitAndWakeUpAppropriateWaiters(); // 0x0000000181807190-0x0000000181807230
		private void ExitAndWakeUpAppropriateWaitersPreferringWriters(); // 0x0000000181807100-0x0000000181807190
		private void ExitAndWakeUpAppropriateReadWaiters(); // 0x0000000181807060-0x0000000181807100
		private bool IsWriterAcquired(); // 0x0000000181807AD0-0x0000000181807AE0
		private void SetWriterAcquired(); // 0x0000000181807BE0-0x0000000181807BF0
		private void ClearWriterAcquired(); // 0x0000000181806BC0-0x0000000181806BD0
		private void SetWritersWaiting(); // 0x0000000181807BF0-0x0000000181807C00
		private void ClearWritersWaiting(); // 0x0000000181806BD0-0x0000000181806BE0
		private void SetUpgraderWaiting(); // 0x0000000181807BD0-0x0000000181807BE0
		private void ClearUpgraderWaiting(); // 0x0000000181806BB0-0x0000000181806BC0
		private uint GetNumReaders(); // 0x0000000181807910-0x0000000181807920
		private void EnterMyLock(); // 0x0000000181806FE0-0x0000000181807000
		private void EnterMyLockSpin(); // 0x0000000181806F20-0x0000000181806FE0
		private void ExitMyLock(); // 0x0000000181807230-0x0000000181807250
		private static void SpinWait(int SpinCount); // 0x0000000181807C00-0x0000000181807C80
		public void Dispose(); // 0x0000000181806F10-0x0000000181806F20
		private void Dispose(bool disposing); // 0x0000000181806BE0-0x0000000181806F10
	}
}
