/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering
{
	[Serializable]
	[CategoryInfo(Name = "R: Mip Generator Resources", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal sealed class MipGenRenderPipelineRuntimeResources : IRenderPipelineResources // TypeDefIndex: 9296
	{
		// Fields
		[ResourcePath("Runtime/MipGen/Shaders/ColorPyramidPS.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_ColorPyramidPS; // 0x10
		[ResourcePath("Runtime/MipGen/Shaders/ColorPyramid.compute", SearchType.ProjectPath)]
		[SerializeField]
		public ComputeShader m_ColorPyramidCS; // 0x18
		[ResourcePath("Runtime/MipGen/Shaders/DepthPyramid.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader m_DepthPyramidCS; // 0x20
	
		// Properties
		public int version { get; } // 0x00000001802E7860-0x00000001802E7870 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Shader colorPyramidPS { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181F571A0-0x0000000181F57210
		public ComputeShader colorPyramidCS { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181F57130-0x0000000181F571A0
		public ComputeShader depthPyramidCS { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181F57210-0x0000000181F57280
	
		// Constructors
		public MipGenRenderPipelineRuntimeResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
