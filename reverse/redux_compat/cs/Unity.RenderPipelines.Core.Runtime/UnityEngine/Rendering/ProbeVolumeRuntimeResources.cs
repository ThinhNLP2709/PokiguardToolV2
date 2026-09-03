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
	internal class ProbeVolumeRuntimeResources : IRenderPipelineResources // TypeDefIndex: 5610
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[Header("Runtime")]
		[ResourcePath("Runtime/Lighting/ProbeVolume/ProbeVolumeBlendStates.compute", SearchType.ProjectPath)]
		public ComputeShader probeVolumeBlendStatesCS; // 0x18
		[ResourcePath("Runtime/Lighting/ProbeVolume/ProbeVolumeUploadData.compute", SearchType.ProjectPath)]
		public ComputeShader probeVolumeUploadDataCS; // 0x20
		[ResourcePath("Runtime/Lighting/ProbeVolume/ProbeVolumeUploadDataL2.compute", SearchType.ProjectPath)]
		public ComputeShader probeVolumeUploadDataL2CS; // 0x28
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public ProbeVolumeRuntimeResources(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
