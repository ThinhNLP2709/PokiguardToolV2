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
	[ComVisible(false)]
	[DebuggerDisplay("IsHeld = {IsHeld}")]
	[DebuggerTypeProxy(typeof(SystemThreading_SpinLockDebugView))]
	public struct SpinLock // TypeDefIndex: 2566
	{
		// Fields
		private int m_owner; // 0x00
		private static int MAXIMUM_WAITERS; // 0x00
	
		// Properties
		public bool IsHeldByCurrentThread { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x0000000181675370-0x0000000181675450 
		public bool IsThreadOwnerTrackingEnabled { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x0000000181675450-0x0000000181675470 
	
		// Nested types
		internal class SystemThreading_SpinLockDebugView // TypeDefIndex: 2567
		{
		}
	
		// Constructors
		public SpinLock(bool enableThreadOwnerTracking); // 0x0000000181675330-0x0000000181675370
		static SpinLock(); // 0x00000001816752F0-0x0000000181675330
	
		// Methods
		public void Enter(ref bool lockTaken); // 0x0000000181674E70-0x0000000181674F20
		public void TryEnter(int millisecondsTimeout, ref bool lockTaken); // 0x0000000181675220-0x00000001816752F0
		private void ContinueTryEnter(int millisecondsTimeout, ref bool lockTaken); // 0x0000000181674910-0x0000000181674D80
		private void DecrementWaiters(); // 0x0000000181674D80-0x0000000181674E70
		private void ContinueTryEnterWithThreadTracking(int millisecondsTimeout, uint startTime, ref bool lockTaken); // 0x00000001816746D0-0x0000000181674910
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Exit(); // 0x0000000181675190-0x0000000181675220
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Exit(bool useMemoryBarrier); // 0x0000000181675100-0x0000000181675190
		private void ExitSlowPath(bool useMemoryBarrier); // 0x0000000181674F20-0x0000000181675100
	}
}
