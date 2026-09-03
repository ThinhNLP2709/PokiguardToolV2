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
	internal struct SilhouettePlaneCache : IDisposable // TypeDefIndex: 12886
	{
		// Fields
		private const int kMaxSilhouettePlanes = 6; // Metadata: 0x006A7610
		private NativeParallelHashMap<EntityId, int> m_SubViewIDToIndexMap; // 0x00
		private NativeList<int> m_SlotFreeList; // 0x10
		private NativeList<Slot> m_Slots; // 0x18
		private NativeList<Plane> m_PlaneStorage; // 0x20
	
		// Nested types
		private struct Slot // TypeDefIndex: 12887
		{
			// Fields
			public bool isActive; // 0x00
			public EntityId viewID; // 0x08
			public int planeCount; // 0x10
			public int lastUsedFrameIndex; // 0x14
	
			// Constructors
			public Slot(EntityId viewID, int planeCount, int frameIndex); // 0x0000000181F48D80-0x0000000181F48D90
		}
	
		// Methods
		public void Init(); // 0x0000000181F48AB0-0x0000000181F48B90
		public void Dispose(); // 0x0000000181F48870-0x0000000181F488B0
		public void Update(EntityId viewID, NativeArray<Plane> planes, int frameIndex); // 0x0000000181F48B90-0x0000000181F48D80
		public void FreeUnusedSlots(int frameIndex, int maximumAge); // 0x0000000181F488B0-0x0000000181F489E0
		public NativeArray<Plane> GetSubArray(EntityId viewID); // 0x0000000181F489E0-0x0000000181F48AB0
	}
}
