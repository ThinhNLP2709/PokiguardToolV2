/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct InstanceCullerSplitDebugArray : IDisposable // TypeDefIndex: 12848
	{
		// Fields
		private const int MaxSplitCount = 64; // Metadata: 0x006A75F2
		private NativeList<Info> m_Info; // 0x00
		private NativeArray<int> m_Counters; // 0x08
		private NativeQueue<JobHandle> m_CounterSync; // 0x18
	
		// Properties
		public NativeArray<int> Counters { get; } // 0x0000000180C57230-0x0000000180C57240 
	
		// Nested types
		internal struct Info // TypeDefIndex: 12849
		{
			// Fields
			public BatchCullingViewType viewType; // 0x00
			public EntityId viewID; // 0x08
			public int splitIndex; // 0x10
		}
	
		// Methods
		public void Init(); // 0x0000000181F22A20-0x0000000181F22AC0
		public void Dispose(); // 0x0000000181F229C0-0x0000000181F22A20
		public int TryAddSplits(BatchCullingViewType viewType, EntityId viewID, int splitCount); // 0x0000000181F22C40-0x0000000181F22CF0
		public void AddSync(int baseIndex, JobHandle jobHandle); // 0x0000000181F22990-0x0000000181F229C0
		public void MoveToDebugStatsAndClear(DebugRendererBatcherStats debugStats); // 0x0000000181F22AC0-0x0000000181F22C40
	}
}
