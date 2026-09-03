/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal struct FillPerSkinJobSingleThread : IJob // TypeDefIndex: 14345
	{
		// Fields
		public PerSkinJobData combinedSkinBatch; // 0x00
		[ReadOnly]
		public NativeArray<bool> isSpriteSkinValidForDeformArray; // 0x18
		public NativeArray<SpriteSkinData> spriteSkinDataArray; // 0x28
		public NativeArray<PerSkinJobData> perSkinJobDataArray; // 0x38
		public NativeArray<PerSkinJobData> combinedSkinBatchArray; // 0x48
	
		// Methods
		public void Execute(); // 0x0000000181C1C5C0-0x0000000181C1C760
	}
}
