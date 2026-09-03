/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct FrustumPlaneCuller // TypeDefIndex: 12978
	{
		// Fields
		public NativeList<PlanePacket4> planePackets; // 0x00
		public NativeList<SplitInfo> splitInfos; // 0x08
	
		// Nested types
		internal struct PlanePacket4 // TypeDefIndex: 12979
		{
			// Fields
			public float4 nx; // 0x00
			public float4 ny; // 0x10
			public float4 nz; // 0x20
			public float4 d; // 0x30
			public float4 nxAbs; // 0x40
			public float4 nyAbs; // 0x50
			public float4 nzAbs; // 0x60
	
			// Constructors
			public PlanePacket4(NativeArray<Plane> planes, int offset, int limit); // 0x0000000181F4FA40-0x0000000181F4FD00
		}
	
		internal struct SplitInfo // TypeDefIndex: 12980
		{
			// Fields
			public int packetCount; // 0x00
		}
	
		// Methods
		internal void Dispose(JobHandle job); // 0x0000000181F4E360-0x0000000181F4E3C0
		internal static FrustumPlaneCuller Create([IsReadOnly] in BatchCullingContext cc, NativeArray<Plane> receiverPlanes, [IsReadOnly] in ReceiverSphereCuller receiverSphereCuller, Allocator allocator); // 0x0000000181F4DF30-0x0000000181F4E360
		internal static uint ComputeSplitVisibilityMask(NativeArray<PlanePacket4> planePackets, NativeArray<SplitInfo> splitInfos, [IsReadOnly] in AABB bounds); // 0x0000000181F4DAA0-0x0000000181F4DF30
	}
}
