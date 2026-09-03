/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[Serializable]
	[CategoryInfo(Name = "R: GPU Resident Drawers", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal class GPUResidentDrawerResources : IRenderPipelineResources // TypeDefIndex: 12925
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x10
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceDataBufferCopyKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_InstanceDataBufferCopyKernels; // 0x18
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceDataBufferUploadKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_InstanceDataBufferUploadKernels; // 0x20
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceTransformUpdateKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_TransformUpdaterKernels; // 0x28
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceWindDataUpdateKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		public ComputeShader m_WindDataUpdaterKernels; // 0x30
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/OccluderDepthPyramidKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_OccluderDepthPyramidKernels; // 0x38
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/InstanceOcclusionCullingKernels.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_InstanceOcclusionCullingKernels; // 0x40
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/OcclusionCullingDebug.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_OcclusionCullingDebugKernels; // 0x48
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/DebugOcclusionTest.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_DebugOcclusionTestPS; // 0x50
		[ResourcePath("Runtime/RenderPipelineResources/GPUDriven/DebugOccluder.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_DebugOccluderPS; // 0x58
	
		// Properties
		int IRenderPipelineGraphicsSettings.version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public ComputeShader instanceDataBufferCopyKernels { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181F348B0-0x0000000181F34920
		public ComputeShader instanceDataBufferUploadKernels { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181F34920-0x0000000181F34990
		public ComputeShader transformUpdaterKernels { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181F34AE0-0x0000000181F34B50
		public ComputeShader windDataUpdaterKernels { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181F34B50-0x0000000181F34BC0
		public ComputeShader occluderDepthPyramidKernels { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181F34A00-0x0000000181F34A70
		public ComputeShader instanceOcclusionCullingKernels { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181F34990-0x0000000181F34A00
		public ComputeShader occlusionCullingDebugKernels { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x0000000181F34A70-0x0000000181F34AE0
		public Shader debugOcclusionTestPS { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x0000000181F34840-0x0000000181F348B0
		public Shader debugOccluderPS { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x0000000181F347D0-0x0000000181F34840
	
		// Nested types
		public enum Version // TypeDefIndex: 12926
		{
			Initial = 0,
			Latest = 0,
			Count = 1
		}
	
		// Constructors
		public GPUResidentDrawerResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
