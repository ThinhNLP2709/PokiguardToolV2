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

namespace System.IO
{
	internal class FileStreamAsyncResult : IAsyncResult // TypeDefIndex: 3702
	{
		// Fields
		private object state; // 0x10
		private bool completed; // 0x18
		private ManualResetEvent wh; // 0x20
		private AsyncCallback cb; // 0x28
		private bool completedSynch; // 0x30
		public int Count; // 0x34
		public int OriginalCount; // 0x38
		public int BytesRead; // 0x3C
		private AsyncCallback realcb; // 0x40
	
		// Properties
		public object AsyncState { get; } // 0x0000000180377550-0x0000000180377560 
		public bool CompletedSynchronously { get; } // 0x00000001802E8950-0x00000001802E8960 
		public WaitHandle AsyncWaitHandle { get; } // 0x00000001802F8630-0x00000001802F8640 
		public bool IsCompleted { get; } // 0x0000000180F9E350-0x0000000180F9E360 
	
		// Constructors
		public FileStreamAsyncResult(AsyncCallback cb, object state); // 0x00000001815C0940-0x00000001815C0A20
	
		// Methods
		private static void CBWrapper(IAsyncResult ares); // 0x00000001815C08B0-0x00000001815C0940
	}
}
