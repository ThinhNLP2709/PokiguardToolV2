/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[CategoryInfo(Name = "R: Debug Shaders", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class UniversalRenderPipelineDebugShaders : IRenderPipelineResources // TypeDefIndex: 9693
	{
		// Fields
		[ResourcePath("Shaders/Debug/DebugReplacement.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_DebugReplacementPS; // 0x10
		[ResourcePath("Shaders/Debug/HDRDebugView.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_HdrDebugViewPS; // 0x18
		[ResourcePath("Shaders/Debug/ProbeVolumeSamplingDebugPositionNormal.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_ProbeVolumeSamplingDebugComputeShader; // 0x20
		[ResourcePath("Shaders/Debug/BatchingTypeDebug.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_BatchingTypeDebugPS; // 0x28
	
		// Properties
		public int version { get; } // 0x00000001802E7860-0x00000001802E7870 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Shader debugReplacementPS { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181FD7340-0x0000000181FD73B0
		public Shader hdrDebugViewPS { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD73B0-0x0000000181FD7420
		public ComputeShader probeVolumeSamplingDebugComputeShader { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FD7420-0x0000000181FD7490
		public Shader batchingTypeDebugPS { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181FD72D0-0x0000000181FD7340
	
		// Constructors
		public UniversalRenderPipelineDebugShaders(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
