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
	public class SynchronizationContext // TypeDefIndex: 2583
	{
		// Fields
		private SynchronizationContextProperties _props; // 0x10
	
		// Properties
		public static SynchronizationContext Current { get; } // 0x0000000181675CD0-0x0000000181675D10 
		internal static SynchronizationContext CurrentNoFlow { [FriendAccessAllowed] get; } // 0x0000000181675D10-0x0000000181675D50 
		internal static SynchronizationContext CurrentExplicit { get; } // 0x0000000181675CD0-0x0000000181675D10 
	
		// Constructors
		public SynchronizationContext(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public bool IsWaitNotificationRequired(); // 0x0000000181675A10-0x0000000181675A20
		public virtual void Send(SendOrPostCallback d, object state); // 0x0000000181675AA0-0x0000000181675AD0
		public virtual void Post(SendOrPostCallback d, object state); // 0x0000000181675A20-0x0000000181675AA0
		public virtual void OperationStarted(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OperationCompleted(); // 0x00000001802E76C0-0x00000001802E76D0
		[CLSCompliant(false)]
		[PrePrepareMethod]
		public virtual int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout); // 0x0000000181675BE0-0x0000000181675CD0
		[CLSCompliant(false)]
		[PrePrepareMethod]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected static int WaitHelper(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout); // 0x0000000181675B30-0x0000000181675BE0
		public static void SetSynchronizationContext(SynchronizationContext syncContext); // 0x0000000181675AD0-0x0000000181675B30
		private static SynchronizationContext GetThreadLocalContext(); // 0x0000000181675870-0x0000000181675A10
		public virtual SynchronizationContext CreateCopy(); // 0x0000000181675820-0x0000000181675870
	}
}
