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
	public class EventWaitHandle : WaitHandle // TypeDefIndex: 2574
	{
		// Constructors
		public EventWaitHandle(bool initialState, EventResetMode mode); // 0x000000018166D9A0-0x000000018166D9C0
		public EventWaitHandle(bool initialState, EventResetMode mode, string name); // 0x000000018166D9C0-0x000000018166DCD0
	
		// Methods
		public bool Reset(); // 0x000000018166D8E0-0x000000018166D940
		public bool Set(); // 0x000000018166D940-0x000000018166D9A0
	}
}
