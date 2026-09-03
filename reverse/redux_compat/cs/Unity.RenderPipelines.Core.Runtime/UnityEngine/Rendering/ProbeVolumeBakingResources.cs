/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[CategoryInfo(Name = "R: Adaptive Probe Volumes", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal class ProbeVolumeBakingResources : IRenderPipelineResources // TypeDefIndex: 5612
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[Header("Baking")]
		[ResourcePath("Editor/Lighting/ProbeVolume/ProbeVolumeCellDilation.compute", SearchType.ProjectPath)]
		public ComputeShader dilationShader; // 0x18
		[ResourcePath("Editor/Lighting/ProbeVolume/ProbeVolumeSubdivide.compute", SearchType.ProjectPath)]
		public ComputeShader subdivideSceneCS; // 0x20
		[ResourcePath("Editor/Lighting/ProbeVolume/VoxelizeScene.shader", SearchType.ProjectPath)]
		public Shader voxelizeSceneShader; // 0x28
		[ResourcePath("Editor/Lighting/ProbeVolume/VirtualOffset/TraceVirtualOffset.urtshader", SearchType.ProjectPath)]
		public ComputeShader traceVirtualOffsetCS; // 0x30
		[ResourcePath("Editor/Lighting/ProbeVolume/VirtualOffset/TraceVirtualOffset.urtshader", SearchType.ProjectPath)]
		public RayTracingShader traceVirtualOffsetRT; // 0x38
		[ResourcePath("Editor/Lighting/ProbeVolume/DynamicGI/DynamicGISkyOcclusion.urtshader", SearchType.ProjectPath)]
		public ComputeShader skyOcclusionCS; // 0x40
		[ResourcePath("Editor/Lighting/ProbeVolume/DynamicGI/DynamicGISkyOcclusion.urtshader", SearchType.ProjectPath)]
		public RayTracingShader skyOcclusionRT; // 0x48
		[ResourcePath("Editor/Lighting/ProbeVolume/RenderingLayerMask/TraceRenderingLayerMask.urtshader", SearchType.ProjectPath)]
		public ComputeShader renderingLayerCS; // 0x50
		[ResourcePath("Editor/Lighting/ProbeVolume/RenderingLayerMask/TraceRenderingLayerMask.urtshader", SearchType.ProjectPath)]
		public RayTracingShader renderingLayerRT; // 0x58
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public ProbeVolumeBakingResources(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
