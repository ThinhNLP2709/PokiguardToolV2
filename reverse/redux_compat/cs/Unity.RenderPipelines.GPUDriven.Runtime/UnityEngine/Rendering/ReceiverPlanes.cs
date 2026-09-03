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
	internal struct ReceiverPlanes // TypeDefIndex: 12977
	{
		// Fields
		public NativeList<Plane> planes; // 0x00
		public int lightFacingPlaneCount; // 0x08
	
		// Methods
		private static bool IsSignBitSet(float x); // 0x000000018161AFD0-0x000000018161AFE0
		internal NativeArray<Plane> LightFacingFrustumPlaneSubArray(); // 0x0000000181F50770-0x0000000181F507D0
		internal NativeArray<Plane> SilhouettePlaneSubArray(); // 0x0000000181F507D0-0x0000000181F50840
		internal static ReceiverPlanes CreateEmptyForTesting(Allocator allocator); // 0x0000000181F4FD70-0x0000000181F4FDC0
		internal void Dispose(JobHandle job); // 0x0000000181F50740-0x0000000181F50770
		internal static ReceiverPlanes Create([IsReadOnly] in BatchCullingContext cc, Allocator allocator); // 0x0000000181F4FDC0-0x0000000181F50740
	}
}
