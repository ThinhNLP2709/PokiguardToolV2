/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct LODGroupCullingData // TypeDefIndex: 12817
	{
		// Fields
		public float3 worldSpaceReferencePoint; // 0x00
		public int lodCount; // 0x0C
		public unsafe fixed /* 0x00000000-0x00000000 */ float sqrDistances[0]; // 0x10
		public unsafe fixed /* 0x00000000-0x00000000 */ float transitionDistances[0]; // 0x30
		public float worldSpaceSize; // 0x50
		public unsafe fixed /* 0x00000000-0x00000000 */ bool percentageFlags[0]; // 0x54
		public byte forceLODMask; // 0x5C
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _percentageFlags_e__FixedBuffer // TypeDefIndex: 12818
		{
			// Fields
			public bool FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _sqrDistances_e__FixedBuffer // TypeDefIndex: 12819
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _transitionDistances_e__FixedBuffer // TypeDefIndex: 12820
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	}
}
