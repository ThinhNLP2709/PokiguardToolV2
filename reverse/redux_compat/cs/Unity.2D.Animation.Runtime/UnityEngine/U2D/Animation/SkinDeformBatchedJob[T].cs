/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal struct SkinDeformBatchedJob<T> : IJobParallelFor // TypeDefIndex: 14344
		where T : struct, IDeformationMode
	{
		// Fields
		public NativeSlice<byte> vertices;
		public NativeSlice<byte> previousVertices;
		[ReadOnly]
		public NativeArray<SpriteSkinData> spriteSkinData;
		[ReadOnly]
		public NativeArray<PerSkinJobData> perSkinJobData;
		[ReadOnly]
		public NativeArray<float4x4> finalBoneTransforms;
		[ReadOnly]
		public NativeArray<bool> isSpriteSkinValidForDeformArray;
		[ReadOnly]
		public NativeArray<bool> isOutlineDataRequiredArray;
		[ReadOnly]
		public NativeArray<bool> hasBoneTransformsChanged;
		[WriteOnly]
		public NativeArray<Bounds> bounds;
		[WriteOnly]
		public NativeArray<int> lastDeformedFrame;
		public int frameCount;
	
		// Methods
		[BurstCompile]
		private static unsafe void CopyBuffer(byte* currentPosStart, byte* previousPosStart, int streamSize, int vertexCount);
		public void Execute(int spriteIndex);
		private static float3 RotateExtents(float3 extents, float4x4 rotation);
	}
}
