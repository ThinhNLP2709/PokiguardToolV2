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
	[ComVisible(true)]
	public sealed class RegisteredWaitHandle : MarshalByRefObject // TypeDefIndex: 2612
	{
		// Fields
		private WaitHandle _waitObject; // 0x18
		private WaitOrTimerCallback _callback; // 0x20
		private object _state; // 0x28
		private WaitHandle _finalEvent; // 0x30
		private ManualResetEvent _cancelEvent; // 0x38
		private TimeSpan _timeout; // 0x40
		private int _callsInProcess; // 0x48
		private bool _executeOnlyOnce; // 0x4C
		private bool _unregistered; // 0x4D
	
		// Constructors
		internal RegisteredWaitHandle(WaitHandle waitObject, WaitOrTimerCallback callback, object state, TimeSpan timeout, bool executeOnlyOnce); // 0x0000000181683290-0x0000000181683360
	
		// Methods
		internal void Wait(object state); // 0x0000000181682CA0-0x0000000181683290
		private void DoCallBack(object timedOut); // 0x0000000181682AE0-0x0000000181682BA0
		[ComVisible(true)]
		public bool Unregister(WaitHandle waitObject); // 0x0000000181682BA0-0x0000000181682CA0
	}
}
