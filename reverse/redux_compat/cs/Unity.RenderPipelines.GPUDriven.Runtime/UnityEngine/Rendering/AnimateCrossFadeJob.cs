/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct AnimateCrossFadeJob : IJobParallelFor // TypeDefIndex: 12838
	{
		// Fields
		public const int k_BatchSize = 512; // Metadata: 0x006A75C3
		public const byte k_MeshLodTransitionToLowerLodBit = 128; // Metadata: 0x006A75C5
		private const byte k_LODFadeOff = 255; // Metadata: 0x006A75C6
		private const float k_CrossfadeAnimationTimeS = 0.333f; // Metadata: 0x006A75C7
		[ReadOnly]
		public float deltaTime; // 0x00
		public NativeArray<byte> crossFadeArray; // 0x08
	
		// Methods
		public void Execute(int instanceIndex); // 0x0000000181F1DC90-0x0000000181F1DCF0
	}
}
