/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal struct BoneTransformsChangeDetectionJob : IJobParallelFor // TypeDefIndex: 14335
	{
		// Fields
		[ReadOnly]
		public NativeArray<bool> transformChanged; // 0x00
		[ReadOnly]
		public NativeArray<SpriteSkinData> spriteSkinData; // 0x10
		[ReadOnly]
		public NativeHashMap<EntityId, TransformAccessJob.TransformData> boneTransformIndex; // 0x20
		[WriteOnly]
		public NativeArray<bool> hasBoneTransformsChanged; // 0x28
	
		// Methods
		public void Execute(int skinIndex); // 0x0000000181C19530-0x0000000181C19670
	}
}
