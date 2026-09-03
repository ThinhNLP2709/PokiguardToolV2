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
	[DebuggerDisplay("Set = {IsSet}")]
	public class ManualResetEventSlim : IDisposable // TypeDefIndex: 2544
	{
		// Fields
		private object m_lock; // 0x10
		private ManualResetEvent m_eventObj; // 0x18
		private int m_combinedState; // 0x20
		private static Action<object> s_cancellationTokenCallback; // 0x00
	
		// Properties
		public WaitHandle WaitHandle { get; } // 0x0000000181671630-0x00000001816716D0 
		public bool IsSet { get; private set; } // 0x0000000181671570-0x00000001816715D0 0x0000000181671720-0x0000000181671750
		public int SpinCount { get; private set; } // 0x00000001816715D0-0x0000000181671630 0x0000000181671750-0x0000000181671790
		private int Waiters { get; set; } // 0x00000001816716D0-0x0000000181671720 0x0000000181671790-0x0000000181671840
	
		// Constructors
		public ManualResetEventSlim(bool initialState); // 0x0000000181671350-0x0000000181671450
		public ManualResetEventSlim(bool initialState, int spinCount); // 0x0000000181671450-0x0000000181671570
		static ManualResetEventSlim(); // 0x00000001816712C0-0x0000000181671350
	
		// Methods
		private void Initialize(bool initialState, int spinCount); // 0x0000000181670140-0x0000000181670200
		private void EnsureLockObjectCreated(); // 0x00000001816700C0-0x0000000181670120
		private bool LazyInitializeEvent(); // 0x0000000181670200-0x0000000181670520
		public void Set(); // 0x0000000181670520-0x0000000181670530
		private void Set(bool duringCancellation); // 0x0000000181670530-0x00000001816708F0
		public bool Wait(int millisecondsTimeout, CancellationToken cancellationToken); // 0x0000000181670A40-0x00000001816712C0
		public void Dispose(); // 0x000000018166FED0-0x000000018166FF40
		protected virtual void Dispose(bool disposing); // 0x000000018166FF40-0x00000001816700C0
		private void ThrowIfDisposed(); // 0x00000001816708F0-0x0000000181670960
		private static void CancellationTokenCallback(object obj); // 0x000000018166FC90-0x000000018166FED0
		private void UpdateStateAtomically(int newBits, int updateBitsMask); // 0x0000000181670960-0x0000000181670A40
		private static int ExtractStatePortionAndShiftRight(int state, int mask, int rightBitShiftCount); // 0x0000000181670120-0x0000000181670130
		private static int ExtractStatePortion(int state, int mask); // 0x0000000181670130-0x0000000181670140
	}
}
