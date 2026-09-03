/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct IndirectBufferContext // TypeDefIndex: 12867
	{
		// Fields
		public JobHandle cullingJobHandle; // 0x00
		public BufferState bufferState; // 0x10
		public int occluderVersion; // 0x14
		public int subviewMask; // 0x18
	
		// Nested types
		public enum BufferState // TypeDefIndex: 12868
		{
			Pending = 0,
			Zeroed = 1,
			NoOcclusionTest = 2,
			AllInstancesOcclusionTested = 3,
			OccludedInstancesReTested = 4
		}
	
		// Constructors
		public IndirectBufferContext(JobHandle cullingJobHandle); // 0x0000000180F1B9C0-0x0000000180F1B9D0
	
		// Methods
		public bool Matches(BufferState bufferState, int occluderVersion, int subviewMask); // 0x0000000181F39A00-0x0000000181F39A20
	}
}
