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

namespace System.Threading.Tasks
{
	internal class StandardTaskContinuation : TaskContinuation // TypeDefIndex: 2667
	{
		// Fields
		internal readonly Task m_task; // 0x10
		internal readonly TaskContinuationOptions m_options; // 0x18
		private readonly TaskScheduler m_taskScheduler; // 0x20
	
		// Constructors
		internal StandardTaskContinuation(Task task, TaskContinuationOptions options, TaskScheduler scheduler); // 0x00000001816844B0-0x0000000181684560
	
		// Methods
		internal override void Run(Task completedTask, bool bCanInlineContinuationTask); // 0x0000000181684370-0x00000001816844B0
	}
}
