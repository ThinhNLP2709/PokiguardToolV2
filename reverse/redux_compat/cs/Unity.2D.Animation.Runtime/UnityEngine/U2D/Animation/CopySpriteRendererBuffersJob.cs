/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal struct CopySpriteRendererBuffersJob : IJobParallelFor // TypeDefIndex: 14346
	{
		// Fields
		[ReadOnly]
		public NativeArray<bool> isSpriteSkinValidForDeformArray; // 0x00
		[ReadOnly]
		public NativeArray<SpriteSkinData> spriteSkinData; // 0x10
		[NativeDisableUnsafePtrRestriction]
		[ReadOnly]
		public IntPtr ptrVertices; // 0x20
		[WriteOnly]
		public NativeArray<IntPtr> buffers; // 0x28
		[WriteOnly]
		public NativeArray<int> bufferSizes; // 0x38
	
		// Methods
		public void Execute(int i); // 0x0000000181C1A440-0x0000000181C1A4D0
	}
}
