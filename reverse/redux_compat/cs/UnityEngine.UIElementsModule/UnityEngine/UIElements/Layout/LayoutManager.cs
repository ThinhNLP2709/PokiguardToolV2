/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	internal class LayoutManager : IDisposable // TypeDefIndex: 5176
	{
		// Fields
		private static SharedManagerState s_Initialized; // 0x00
		private static LayoutManager s_SharedInstance; // 0x08
		private static readonly List<LayoutManager> s_Managers; // 0x10
		private readonly int m_Index; // 0x10
		private UnmanagedDataStore m_Nodes; // 0x18
		private UnmanagedDataStore m_Configs; // 0x30
		private readonly ConcurrentQueue<UnmanagedDataHandle> m_NodesToFree; // 0x48
		private readonly UnmanagedDataHandle m_DefaultConfig; // 0x50
		private readonly ManagedObjectStore<LayoutMeasureFunction> m_ManagedMeasureFunctions; // 0x58
		private readonly ManagedObjectStore<LayoutBaselineFunction> m_ManagedBaselineFunctions; // 0x60
		private readonly ProfilerMarker m_CollectMarker; // 0x68
		private int m_HighMark; // 0x70
	
		// Properties
		public static bool IsSharedManagerCreated { get; } // 0x000000018243BED0-0x000000018243BF30 
		public static LayoutManager SharedManager { get; } // 0x000000018243BF30-0x000000018243C1D0 
		private static int DefaultCapacity { get; } // 0x00000001808F5E70-0x00000001808F5E80 
		internal UnmanagedDataStore Nodes { get; } // 0x0000000180A628D0-0x0000000180A628F0 
		internal UnmanagedDataStore Configs { get; } // 0x0000000181C2D300-0x0000000181C2D320 
	
		// Nested types
		private enum SharedManagerState // TypeDefIndex: 5177
		{
			Uninitialized = 0,
			Initialized = 1,
			Shutdown = 2
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 5178
		{
			// Fields
			public static Action _0___Shutdown; // 0x00
		}
	
		// Constructors
		public LayoutManager(Allocator allocator); // 0x000000018243B240-0x000000018243B350
		public LayoutManager(Allocator allocator, int initialNodeCapacity, ComputedStyle initialStyle); // 0x000000018243B350-0x000000018243BED0
		static LayoutManager(); // 0x000000018243B1B0-0x000000018243B240
	
		// Methods
		private static void Initialize(); // 0x000000018243AB40-0x000000018243AD90
		private static void Shutdown(); // 0x000000018243AE20-0x000000018243AFF0
		internal static LayoutManager GetManager(int index); // 0x000000018243AA70-0x000000018243AAF0
		public void Dispose(); // 0x000000018243A600-0x000000018243A760
		private LayoutDataAccess GetAccess(); // 0x000000018243A980-0x000000018243A9C0
		public LayoutConfig GetDefaultConfig(); // 0x000000018243AA10-0x000000018243AA70
		public LayoutConfig CreateConfig(); // 0x000000018243A270-0x000000018243A310
		public void DestroyConfig(ref LayoutConfig config); // 0x000000018243A560-0x000000018243A600
		public LayoutNode CreateNode(); // 0x000000018243A430-0x000000018243A560
		private LayoutNode CreateNodeInternal(); // 0x000000018243A310-0x000000018243A430
		private void TryRecycleSingleNode(); // 0x000000018243B160-0x000000018243B1B0
		private void TryRecycleNodes(); // 0x000000018243AFF0-0x000000018243B160
		public void EnqueueNodeForRecycling(ref LayoutNode node); // 0x000000018243A760-0x000000018243A870
		private void FreeNode(UnmanagedDataHandle handle); // 0x000000018243A870-0x000000018243A980
		public void Collect(); // 0x000000018243A190-0x000000018243A270
		public LayoutMeasureFunction GetMeasureFunction(UnmanagedDataHandle handle); // 0x000000018243AAF0-0x000000018243AB40
		public void SetMeasureFunction(UnmanagedDataHandle handle, LayoutMeasureFunction value); // 0x000000018243AD90-0x000000018243AE20
		public LayoutBaselineFunction GetBaselineFunction(UnmanagedDataHandle handle); // 0x000000018243A9C0-0x000000018243AA10
	}
}
