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
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[ComVisible(true)]
	public abstract class WaitHandle : MarshalByRefObject, IDisposable // TypeDefIndex: 2606
	{
		// Fields
		public const int WaitTimeout = 258; // Metadata: 0x0064EA29
		private const int MAX_WAITHANDLES = 64; // Metadata: 0x0064EA2B
		private IntPtr waitHandle; // 0x18
		internal SafeWaitHandle safeWaitHandle; // 0x20
		internal bool hasThreadAffinity; // 0x28
		private const int WAIT_OBJECT_0 = 0; // Metadata: 0x0064EA2D
		private const int WAIT_ABANDONED = 128; // Metadata: 0x0064EA2E
		private const int WAIT_FAILED = 2147483647; // Metadata: 0x0064EA30
		private const int ERROR_TOO_MANY_POSTS = 298; // Metadata: 0x0064EA31
		private const int ERROR_NOT_OWNED_BY_CALLER = 299; // Metadata: 0x0064EA33
		protected static readonly IntPtr InvalidHandle; // 0x00
		internal const int MaxWaitHandles = 64; // Metadata: 0x0064EA35
	
		// Properties
		[Obsolete("Use the SafeWaitHandle property instead.")]
		public virtual IntPtr Handle { set; } // 0x0000000181695420-0x0000000181695520
		public SafeWaitHandle SafeWaitHandle { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] get; } // 0x0000000181695350-0x0000000181695420 
	
		// Constructors
		protected WaitHandle(); // 0x00000001816952D0-0x0000000181695350
		static WaitHandle(); // 0x0000000181695280-0x00000001816952D0
	
		// Methods
		private void Init(); // 0x0000000181694220-0x00000001816942A0
		internal void SetHandleInternal(SafeWaitHandle handle); // 0x00000001816943B0-0x0000000181694400
		public virtual bool WaitOne(int millisecondsTimeout, bool exitContext); // 0x0000000181694FA0-0x0000000181695030
		public virtual bool WaitOne(TimeSpan timeout, bool exitContext); // 0x0000000181695180-0x0000000181695270
		public virtual bool WaitOne(); // 0x0000000181694F80-0x0000000181694FA0
		public virtual bool WaitOne(int millisecondsTimeout); // 0x0000000181694F60-0x0000000181694F80
		public virtual bool WaitOne(TimeSpan timeout); // 0x0000000181429E80-0x0000000181429EA0
		private bool WaitOne(long timeout, bool exitContext); // 0x0000000181695030-0x0000000181695180
		internal static bool InternalWaitOne(SafeHandle waitableSafeHandle, long millisecondsTimeout, bool hasThreadAffinity, bool exitContext); // 0x00000001816942A0-0x00000001816943B0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext); // 0x00000001816945C0-0x0000000181694980
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static int WaitAny(WaitHandle[] waitHandles, TimeSpan timeout, bool exitContext); // 0x00000001816944A0-0x00000001816945C0
		private static void ThrowAbandonedMutexException(); // 0x0000000181694460-0x00000001816944A0
		private static void ThrowAbandonedMutexException(int location, WaitHandle handle); // 0x0000000181694400-0x0000000181694460
		public virtual void Close(); // 0x00000001816940F0-0x0000000181694160
		protected virtual void Dispose(bool explicitDisposing); // 0x00000001816941D0-0x0000000181694220
		public void Dispose(); // 0x0000000181694160-0x00000001816941D0
		private static int WaitOneNative(SafeHandle waitableSafeHandle, uint millisecondsTimeout, bool hasThreadAffinity, bool exitContext); // 0x0000000181694D30-0x0000000181694F60
		private static int WaitMultiple(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext, bool WaitAll); // 0x0000000181694980-0x0000000181694D30
		internal static unsafe int Wait_internal(IntPtr* handles, int numHandles, bool waitAll, int ms); // 0x0000000181695270-0x0000000181695280
	}
}
