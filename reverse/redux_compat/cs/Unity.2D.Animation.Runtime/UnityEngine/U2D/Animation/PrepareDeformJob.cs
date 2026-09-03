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

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal struct PrepareDeformJob : IJob // TypeDefIndex: 14339
	{
		// Fields
		[ReadOnly]
		public NativeArray<PerSkinJobData> perSkinJobData; // 0x00
		[ReadOnly]
		public int batchDataSize; // 0x10
		[WriteOnly]
		public NativeArray<int2> boneLookupData; // 0x18
	
		// Methods
		public void Execute(); // 0x0000000181C1F700-0x0000000181C1F780
	}
}
