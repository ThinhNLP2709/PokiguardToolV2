/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	internal sealed class CompletionActionInvoker : IThreadPoolWorkItem // TypeDefIndex: 2653
	{
		// Fields
		private readonly ITaskCompletionAction m_action; // 0x10
		private readonly Task m_completingTask; // 0x18
	
		// Constructors
		internal CompletionActionInvoker(ITaskCompletionAction action, Task completingTask); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		void IThreadPoolWorkItem.ExecuteWorkItem(); // 0x000000018167DAC0-0x000000018167DB10
		public void MarkAborted(ThreadAbortException e); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
