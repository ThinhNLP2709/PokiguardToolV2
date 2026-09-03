/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	[Serializable]
	[CategoryInfo(Name = "R: Unified Ray Tracing", Order = 1000)]
	[HideInInspector]
	[MovedFrom(true, "UnityEngine.Rendering.UnifiedRayTracing", "Unity.Rendering.LightTransport.Runtime", null)]
	[SupportedOnRenderPipeline(new Type[0])]
	public sealed class RayTracingRenderPipelineResources : IRenderPipelineResources // TypeDefIndex: 14325
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Runtime/UnifiedRayTracing/Common/GeometryPool/GeometryPoolKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_GeometryPoolKernels; // 0x18
		[ResourcePath("Runtime/UnifiedRayTracing/Common/Utilities/CopyBuffer.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_CopyBuffer; // 0x20
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/copyPositions.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_CopyPositions; // 0x28
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/bit_histogram.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_BitHistogram; // 0x30
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/block_reduce_part.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_BlockReducePart; // 0x38
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/block_scan.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_BlockScan; // 0x40
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/build_hlbvh.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_BuildHlbvh; // 0x48
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/restructure_bvh.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_RestructureBvh; // 0x50
		[ResourcePath("Runtime/UnifiedRayTracing/Compute/RadeonRays/kernels/scatter.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_Scatter; // 0x58
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public ComputeShader GeometryPoolKernels { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000182127C80-0x0000000182127CF0
		public ComputeShader CopyBuffer { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000182127BA0-0x0000000182127C10
		public ComputeShader CopyPositions { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000182127C10-0x0000000182127C80
		public ComputeShader BitHistogram { get; set; } // 0x000000018031E110-0x000000018031E120 0x00000001821279E0-0x0000000182127A50
		public ComputeShader BlockReducePart { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000182127A50-0x0000000182127AC0
		public ComputeShader BlockScan { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000182127AC0-0x0000000182127B30
		public ComputeShader BuildHlbvh { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x0000000182127B30-0x0000000182127BA0
		public ComputeShader RestructureBvh { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x0000000182127CF0-0x0000000182127D60
		public ComputeShader Scatter { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x0000000182127D60-0x0000000182127DD0
	
		// Constructors
		public RayTracingRenderPipelineResources(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
