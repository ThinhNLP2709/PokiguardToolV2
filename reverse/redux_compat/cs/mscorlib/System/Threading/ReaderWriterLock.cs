/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[ComVisible(true)]
	public sealed class ReaderWriterLock : CriticalFinalizerObject // TypeDefIndex: 2611
	{
		// Fields
		private int seq_num; // 0x10
		private int state; // 0x14
		private int readers; // 0x18
		private int writer_lock_owner; // 0x1C
		private LockQueue writer_queue; // 0x20
		private Hashtable reader_locks; // 0x28
	
		// Constructors
		public ReaderWriterLock(); // 0x0000000181682A00-0x0000000181682AE0
	
		// Methods
		~ReaderWriterLock(); // 0x0000000181682750-0x00000001816827A0
		public void AcquireWriterLock(int millisecondsTimeout); // 0x0000000181682740-0x0000000181682750
		private void AcquireWriterLock(int millisecondsTimeout, int initialLockCount); // 0x0000000181682510-0x0000000181682740
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void ReleaseWriterLock(); // 0x0000000181682810-0x00000001816829A0
		private void ReleaseWriterLock(int releaseCount); // 0x00000001816829A0-0x0000000181682A00
		private bool HasWriterLock(); // 0x00000001816827A0-0x0000000181682810
	}
}
