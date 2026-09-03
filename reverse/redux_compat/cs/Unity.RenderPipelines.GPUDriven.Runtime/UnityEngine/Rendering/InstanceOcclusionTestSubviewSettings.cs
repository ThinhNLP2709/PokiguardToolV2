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
	internal struct InstanceOcclusionTestSubviewSettings // TypeDefIndex: 12874
	{
		// Fields
		public int testCount; // 0x00
		public int occluderSubviewIndices; // 0x04
		public int occluderSubviewMask; // 0x08
		public int cullingSplitIndices; // 0x0C
		public int cullingSplitMask; // 0x10
	
		// Methods
		public static InstanceOcclusionTestSubviewSettings FromSpan(ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests); // 0x0000000181F39A20-0x0000000181F39AD0
	}
}
