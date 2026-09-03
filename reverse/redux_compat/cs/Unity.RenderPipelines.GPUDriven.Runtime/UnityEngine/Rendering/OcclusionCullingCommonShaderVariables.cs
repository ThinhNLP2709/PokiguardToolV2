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
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\GPUDriven\\Culling\\OcclusionCullingCommonShaderVariables.cs", needAccessors = false, generateCBuffer = true)]
	internal struct OcclusionCullingCommonShaderVariables // TypeDefIndex: 12897
	{
		// Fields
		[HLSLArray(8, typeof(ShaderGenUInt4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ uint _OccluderMipBounds[0]; // 0x00
		[HLSLArray(6, typeof(Matrix4x4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ float _ViewProjMatrix[0]; // 0x80
		[HLSLArray(6, typeof(Vector4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ float _ViewOriginWorldSpace[0]; // 0x200
		[HLSLArray(6, typeof(Vector4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ float _FacingDirWorldSpace[0]; // 0x260
		[HLSLArray(6, typeof(Vector4))]
		public unsafe fixed /* 0x00000000-0x00000000 */ float _RadialDirWorldSpace[0]; // 0x2C0
		public Vector4 _DepthSizeInOccluderPixels; // 0x320
		public Vector4 _OccluderDepthPyramidSize; // 0x330
		public uint _OccluderMipLayoutSizeX; // 0x340
		public uint _OccluderMipLayoutSizeY; // 0x344
		public uint _OcclusionTestDebugFlags; // 0x348
		public uint _OcclusionCullingCommonPad0; // 0x34C
		public int _OcclusionTestCount; // 0x350
		public int _OccluderSubviewIndices; // 0x354
		public int _CullingSplitIndices; // 0x358
		public int _CullingSplitMask; // 0x35C
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __FacingDirWorldSpace_e__FixedBuffer // TypeDefIndex: 12898
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __OccluderMipBounds_e__FixedBuffer // TypeDefIndex: 12899
		{
			// Fields
			public uint FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __RadialDirWorldSpace_e__FixedBuffer // TypeDefIndex: 12900
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __ViewOriginWorldSpace_e__FixedBuffer // TypeDefIndex: 12901
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct __ViewProjMatrix_e__FixedBuffer // TypeDefIndex: 12902
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		// Constructors
		internal unsafe OcclusionCullingCommonShaderVariables([IsReadOnly] in OccluderContext occluderCtx, [IsReadOnly] in InstanceOcclusionTestSubviewSettings subviewSettings, bool occlusionOverlayCountVisible, bool overrideOcclusionTestToAlwaysPass); // 0x0000000181F42120-0x0000000181F42550
	}
}
