/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Jobs;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal struct WorldToLocalTransformAccessJob : IJobParallelForTransform // TypeDefIndex: 14356
	{
		// Fields
		[WriteOnly]
		public NativeArray<float4x4> outMatrix; // 0x00
	
		// Methods
		public void Execute(int index, TransformAccess transform); // 0x0000000181C2F7A0-0x0000000181C2F9D0
	}
}
