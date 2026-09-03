/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class MeshModifierScheduler : IDisposable // TypeDefIndex: 5109
	{
		// Fields
		private static readonly ProfilerMarker k_RunMarker; // 0x00
		private readonly List<Entry> m_DrawBuffer; // 0x10
		private readonly List<ElementState> m_ActiveStates; // 0x18
		private readonly Stack<ElementState> m_StatePool; // 0x20
		private readonly JobMerger m_CallbackScratch; // 0x28
	
		// Nested types
		private enum SchedulerState // TypeDefIndex: 5110
		{
			Ready = 0,
			AwaitingJob = 1,
			Complete = 2
		}
	
		private sealed class ElementState // TypeDefIndex: 5111
		{
			// Fields
			public Entry rootEntry; // 0x10
			public VisualElement element; // 0x18
			public List<MeshModifierRegistration> chain; // 0x20
			public int chainIndex; // 0x28
			public JobHandle combined; // 0x30
			public SchedulerState state; // 0x40
	
			// Constructors
			public ElementState(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public MeshModifierScheduler(); // 0x00000001824250E0-0x0000000182425230
		static MeshModifierScheduler(); // 0x0000000182425070-0x00000001824250E0
	
		// Methods
		public void RegisterDirtyElement(Entry rootEntry, RenderData renderData); // 0x0000000182424A40-0x0000000182424BE0
		public void Run(TempMeshAllocatorImpl allocator, ExtraVertexChannels panelExtras); // 0x0000000182424DB0-0x0000000182425070
		private void DriveStateMachine(TempMeshAllocatorImpl allocator, ExtraVertexChannels panelExtras); // 0x0000000182424760-0x00000001824248C0
		private bool DrainReady(TempMeshAllocatorImpl allocator, ExtraVertexChannels panelExtras); // 0x00000001824246A0-0x0000000182424760
		private void AdvanceElement(ElementState state, TempMeshAllocatorImpl allocator, ExtraVertexChannels panelExtras); // 0x0000000182424250-0x00000001824244D0
		private bool PromoteCompletedWaiters(); // 0x0000000182424980-0x0000000182424A40
		private void BlockOnFirstWaiter(); // 0x00000001824244D0-0x0000000182424560
		private void RemoveAtSwapBack(int i); // 0x0000000182424C90-0x0000000182424DB0
		private void ReleaseActiveStates(); // 0x0000000182424BE0-0x0000000182424C90
		private void PoolState(ElementState s); // 0x00000001824248E0-0x0000000182424980
		private ElementState AcquireState(); // 0x00000001824241D0-0x0000000182424250
		private static void CollectDrawEntries(Entry e, List<Entry> buffer); // 0x0000000182424560-0x0000000182424680
		private static bool IsDrawEntry(EntryType type); // 0x00000001824248C0-0x00000001824248E0
		public void Dispose(); // 0x0000000182424680-0x00000001824246A0
	}
}
