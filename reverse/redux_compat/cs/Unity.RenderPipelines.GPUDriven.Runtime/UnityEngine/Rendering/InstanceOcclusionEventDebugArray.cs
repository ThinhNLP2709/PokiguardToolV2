/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct InstanceOcclusionEventDebugArray : IDisposable // TypeDefIndex: 12850
	{
		// Fields
		private const int InitialPassCount = 4; // Metadata: 0x006A75F4
		private const int MaxPassCount = 64; // Metadata: 0x006A75F5
		private GraphicsBuffer m_CounterBuffer; // 0x00
		private UnsafeList<Info> m_PendingInfo; // 0x08
		private NativeQueue<Request> m_Requests; // 0x20
		private UnsafeList<Info> m_LatestInfo; // 0x28
		private NativeArray<int> m_LatestCounters; // 0x40
		private bool m_HasLatest; // 0x50
	
		// Properties
		public GraphicsBuffer CounterBuffer { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Nested types
		internal struct Info // TypeDefIndex: 12851
		{
			// Fields
			public EntityId viewID; // 0x00
			public InstanceOcclusionEventType eventType; // 0x08
			public int occluderVersion; // 0x0C
			public int subviewMask; // 0x10
			public OcclusionTest occlusionTest; // 0x14
	
			// Methods
			public bool HasVersion(); // 0x0000000181F22700-0x0000000181F22720
		}
	
		internal struct Request // TypeDefIndex: 12852
		{
			// Fields
			public UnsafeList<Info> info; // 0x00
			public AsyncGPUReadbackRequest readback; // 0x18
		}
	
		// Methods
		public void Init(); // 0x0000000181F27910-0x0000000181F27A00
		public void Dispose(); // 0x0000000181F27810-0x0000000181F27910
		public int TryAdd(EntityId viewID, InstanceOcclusionEventType eventType, int occluderVersion, int subviewMask, OcclusionTest occlusionTest); // 0x0000000181F27EE0-0x0000000181F27FB0
		public void MoveToDebugStatsAndClear(DebugRendererBatcherStats debugStats); // 0x0000000181F27A00-0x0000000181F27EE0
	}
}
