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
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[BurstCompile]
	internal struct ReflectionProbeMinMaxZJob : IJobFor // TypeDefIndex: 9799
	{
		// Fields
		public Fixed2<float4x4> worldToViews; // 0x00
		[ReadOnly]
		public NativeArray<VisibleReflectionProbe> reflectionProbes; // 0x80
		[ReadOnly]
		public bool reflectionProbeRotation; // 0x90
		public NativeArray<float2> minMaxZs; // 0x98
	
		// Methods
		public void Execute(int index); // 0x0000000181FDBDD0-0x0000000181FDC170
	}
}
