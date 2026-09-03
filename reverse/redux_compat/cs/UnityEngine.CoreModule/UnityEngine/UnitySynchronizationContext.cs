/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal sealed class UnitySynchronizationContext : SynchronizationContext // TypeDefIndex: 7789
	{
		// Fields
		private readonly List<WorkRequest> m_AsyncWorkQueue; // 0x18
		private readonly List<WorkRequest> m_CurrentFrameWork; // 0x20
		private readonly int m_MainThreadID; // 0x28
		private int m_TrackedCount; // 0x2C
	
		// Properties
		internal int MainThreadId { get; } // 0x0000000180377930-0x0000000180377940 
	
		// Nested types
		private struct WorkRequest // TypeDefIndex: 7790
		{
			// Fields
			private readonly SendOrPostCallback m_DelagateCallback; // 0x00
			private readonly object m_DelagateState; // 0x08
			private readonly ManualResetEvent m_WaitHandle; // 0x10
	
			// Constructors
			public WorkRequest(SendOrPostCallback callback, object state, ManualResetEvent waitHandle = null); // 0x0000000180F466A0-0x0000000180F466F0
	
			// Methods
			public void Invoke(); // 0x00000001822293A0-0x0000000182229450
		}
	
		// Constructors
		private UnitySynchronizationContext(int mainThreadID); // 0x00000001821FBF90-0x00000001821FC050
		private UnitySynchronizationContext(List<WorkRequest> queue, int mainThreadID); // 0x00000001821FBEE0-0x00000001821FBF90
	
		// Methods
		public override void Send(SendOrPostCallback callback, object state); // 0x00000001821FBC20-0x00000001821FBEE0
		public override void OperationStarted(); // 0x00000001821FBA50-0x00000001821FBA60
		public override void OperationCompleted(); // 0x00000001821FBA40-0x00000001821FBA50
		public override void Post(SendOrPostCallback callback, object state); // 0x00000001821FBA60-0x00000001821FBC20
		public override SynchronizationContext CreateCopy(); // 0x00000001821FB480-0x00000001821FB560
		public void Exec(); // 0x00000001821FB560-0x00000001821FB700
		private bool HasPendingTasks(); // 0x00000001821FB850-0x00000001821FB880
		[RequiredByNativeCode]
		private static void InitializeSynchronizationContext(); // 0x00000001821FB880-0x00000001821FBA40
		[RequiredByNativeCode]
		private static void ExecuteTasks(); // 0x00000001821FB7F0-0x00000001821FB850
		[RequiredByNativeCode]
		private static bool ExecutePendingTasks(uint millisecondsTimeout); // 0x00000001821FB700-0x00000001821FB7F0
	}
}
