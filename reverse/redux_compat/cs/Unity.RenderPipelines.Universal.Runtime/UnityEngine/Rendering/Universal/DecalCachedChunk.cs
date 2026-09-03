/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalCachedChunk : DecalChunk // TypeDefIndex: 9433
	{
		// Fields
		public MaterialPropertyBlock propertyBlock; // 0x28
		public int passIndexDBuffer; // 0x30
		public int passIndexEmissive; // 0x34
		public int passIndexScreenSpace; // 0x38
		public int passIndexGBuffer; // 0x3C
		public int drawOrder; // 0x40
		public bool isCreated; // 0x44
		public NativeArray<float4x4> decalToWorlds; // 0x48
		public NativeArray<float4x4> normalToWorlds; // 0x58
		public NativeArray<float4x4> sizeOffsets; // 0x68
		public NativeArray<float2> drawDistances; // 0x78
		public NativeArray<float2> angleFades; // 0x88
		public NativeArray<float4> uvScaleBias; // 0x98
		public NativeArray<int> layerMasks; // 0xA8
		public NativeArray<ulong> sceneLayerMasks; // 0xB8
		public NativeArray<float> fadeFactors; // 0xC8
		public NativeArray<BoundingSphere> boundingSpheres; // 0xD8
		public NativeArray<DecalScaleMode> scaleModes; // 0xE8
		public NativeArray<uint> renderingLayerMasks; // 0xF8
		public NativeArray<float3> positions; // 0x108
		public NativeArray<quaternion> rotation; // 0x118
		public NativeArray<float3> scales; // 0x128
		public NativeArray<bool> dirty; // 0x138
		public BoundingSphere[] boundingSphereArray; // 0x148
	
		// Constructors
		public DecalCachedChunk(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void RemoveAtSwapBack(int entityIndex); // 0x0000000181F72D70-0x0000000181F72F60
		public override void SetCapacity(int newCapacity); // 0x0000000181F72F60-0x0000000181F73190
		public override void Dispose(); // 0x0000000181F72B80-0x0000000181F72D70
	}
}
