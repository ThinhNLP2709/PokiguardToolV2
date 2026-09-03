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
	internal sealed class ThreadPoolWorkQueueThreadLocals // TypeDefIndex: 2601
	{
		// Fields
		[ThreadStatic]
		public static ThreadPoolWorkQueueThreadLocals threadLocals; // 0x80000000
		public readonly ThreadPoolWorkQueue workQueue; // 0x10
		public readonly ThreadPoolWorkQueue.WorkStealingQueue workStealingQueue; // 0x18
		public readonly Random random; // 0x20
	
		// Constructors
		public ThreadPoolWorkQueueThreadLocals(ThreadPoolWorkQueue tpq); // 0x000000018168FC10-0x000000018168FE00
	
		// Methods
		private void CleanUp(); // 0x000000018168FA70-0x000000018168FB70
		~ThreadPoolWorkQueueThreadLocals(); // 0x000000018168FB70-0x000000018168FC10
	}
}
