/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Internal.Runtime.Augments;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Internal.Threading.Tasks.Tracing
{
	internal static class TaskTrace // TypeDefIndex: 2164
	{
		// Fields
		private static TaskTraceCallbacks s_callbacks; // 0x00
	
		// Properties
		public static bool Enabled { get; } // 0x0000000181460CC0-0x0000000181460D20 
	
		// Methods
		public static void TaskWaitBegin_Asynchronous(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID); // 0x0000000181460B40-0x0000000181460BC0
		public static void TaskWaitBegin_Synchronous(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID); // 0x0000000181460BC0-0x0000000181460C40
		public static void TaskWaitEnd(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID); // 0x0000000181460C40-0x0000000181460CC0
		public static void TaskScheduled(int OriginatingTaskSchedulerID, int OriginatingTaskID, int TaskID, int CreatingTaskID, int TaskCreationOptions); // 0x0000000181460AA0-0x0000000181460B40
	}
}
