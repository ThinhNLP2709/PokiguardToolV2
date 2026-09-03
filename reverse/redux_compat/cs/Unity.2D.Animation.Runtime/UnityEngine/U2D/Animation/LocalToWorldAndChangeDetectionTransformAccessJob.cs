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
	internal struct LocalToWorldAndChangeDetectionTransformAccessJob : IJobParallelForTransform // TypeDefIndex: 14355
	{
		// Fields
		public NativeArray<float4x4> outMatrix; // 0x00
		[WriteOnly]
		public NativeArray<bool> hasChanged; // 0x10
	
		// Methods
		public void Execute(int index, TransformAccess transform); // 0x0000000181C1E8C0-0x0000000181C1EC40
	}
}
