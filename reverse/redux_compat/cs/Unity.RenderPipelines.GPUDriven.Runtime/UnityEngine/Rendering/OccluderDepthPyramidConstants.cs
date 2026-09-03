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
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\GPUDriven\\Culling\\OccluderDepthPyramidConstants.cs", needAccessors = false, generateCBuffer = true)]
	internal struct OccluderDepthPyramidConstants // TypeDefIndex: 12878
	{
		// Fields
		[HLSLArray(6, typeof(Matrix4x4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ float _InvViewProjMatrix[0]; // 0x00
		[HLSLArray(6, typeof(Vector4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ float _SilhouettePlanes[0]; // 0x180
		[HLSLArray(6, typeof(ShaderGenUInt4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ uint _SrcOffset[0]; // 0x1E0
		[HLSLArray(5, typeof(ShaderGenUInt4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ uint _MipOffsetAndSize[0]; // 0x240
		public uint _OccluderMipLayoutSizeX; // 0x290
		public uint _OccluderMipLayoutSizeY; // 0x294
		public uint _OccluderDepthPyramidPad0; // 0x298
		public uint _OccluderDepthPyramidPad1; // 0x29C
		public uint _SrcSliceIndices; // 0x2A0
		public uint _DstSubviewIndices; // 0x2A4
		public uint _MipCount; // 0x2A8
		public uint _SilhouettePlaneCount; // 0x2AC
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __InvViewProjMatrix_e__FixedBuffer // TypeDefIndex: 12879
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __MipOffsetAndSize_e__FixedBuffer // TypeDefIndex: 12880
		{
			// Fields
			public uint FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __SilhouettePlanes_e__FixedBuffer // TypeDefIndex: 12881
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __SrcOffset_e__FixedBuffer // TypeDefIndex: 12882
		{
			// Fields
			public uint FixedElementField; // 0x00
		}
	}
}
