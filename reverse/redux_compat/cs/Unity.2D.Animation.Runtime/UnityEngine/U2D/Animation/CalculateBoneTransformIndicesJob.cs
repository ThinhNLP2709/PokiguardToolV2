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
	internal struct CalculateBoneTransformIndicesJob : IJob // TypeDefIndex: 14347
	{
		// Fields
		[ReadOnly]
		public NativeArray<bool> isSpriteSkinValidForDeformArray; // 0x00
		[ReadOnly]
		public NativeArray<SpriteSkinData> spriteSkinData; // 0x10
		[WriteOnly]
		public NativeArray<int> boneTransformIndices; // 0x20
	
		// Methods
		public void Execute(); // 0x0000000181C1A3D0-0x0000000181C1A440
	}
}
