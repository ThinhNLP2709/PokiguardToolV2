/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\GPUDriven\\Culling\\OcclusionCullingDebugShaderVariables.cs", needAccessors = false, generateCBuffer = true)]
	internal struct OcclusionCullingDebugShaderVariables // TypeDefIndex: 12903
	{
		// Fields
		public Vector4 _DepthSizeInOccluderPixels; // 0x00
		[HLSLArray(8, typeof(ShaderGenUInt4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ uint _OccluderMipBounds[0]; // 0x10
		public uint _OccluderMipLayoutSizeX; // 0x90
		public uint _OccluderMipLayoutSizeY; // 0x94
		public uint _OcclusionCullingDebugPad0; // 0x98
		public uint _OcclusionCullingDebugPad1; // 0x9C
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __OccluderMipBounds_e__FixedBuffer // TypeDefIndex: 12904
		{
			// Fields
			public uint FixedElementField; // 0x00
		}
	}
}
