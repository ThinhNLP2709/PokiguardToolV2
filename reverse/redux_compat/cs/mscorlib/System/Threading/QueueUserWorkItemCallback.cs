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
	internal sealed class QueueUserWorkItemCallback : IThreadPoolWorkItem // TypeDefIndex: 2603
	{
		// Fields
		private WaitCallback callback; // 0x10
		private ExecutionContext context; // 0x18
		private object state; // 0x20
		internal static ContextCallback ccb; // 0x00
	
		// Constructors
		internal QueueUserWorkItemCallback(WaitCallback waitCallback, object stateObj, bool compressStack, ref StackCrawlMark stackMark); // 0x0000000181682440-0x0000000181682510
		static QueueUserWorkItemCallback(); // 0x00000001816823B0-0x0000000181682440
	
		// Methods
		void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x0000000181682240-0x0000000181682330
		void IThreadPoolWorkItem.MarkAborted(ThreadAbortException tae); // 0x00000001802E76C0-0x00000001802E76D0
		private static void WaitCallback_Context(object state); // 0x0000000181682330-0x00000001816823B0
	}
}
