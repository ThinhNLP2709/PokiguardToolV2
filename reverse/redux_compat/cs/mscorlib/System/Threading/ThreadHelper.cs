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
	internal class ThreadHelper // TypeDefIndex: 2588
	{
		// Fields
		private Delegate _start; // 0x10
		private object _startArg; // 0x18
		private ExecutionContext _executionContext; // 0x20
		internal static ContextCallback _ccb; // 0x00
	
		// Constructors
		internal ThreadHelper(Delegate start); // 0x00000001803855F0-0x0000000180385630
		static ThreadHelper(); // 0x000000018168F380-0x000000018168F410
	
		// Methods
		internal void SetExecutionContextHelper(ExecutionContext ec); // 0x000000018033E830-0x000000018033E840
		private static void ThreadStart_Context(object state); // 0x000000018168F030-0x000000018168F150
		internal void ThreadStart(object obj); // 0x000000018168F150-0x000000018168F270
		internal void ThreadStart(); // 0x000000018168F270-0x000000018168F380
	}
}
