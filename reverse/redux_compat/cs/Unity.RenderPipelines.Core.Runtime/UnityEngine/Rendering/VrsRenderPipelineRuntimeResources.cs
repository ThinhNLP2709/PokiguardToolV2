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
	[CategoryInfo(Name = "VRS - Runtime Resources", Order = 1000)]
	[SupportedOnRenderPipeline(new Type[0])]
	public sealed class VrsRenderPipelineRuntimeResources : IRenderPipelineResources // TypeDefIndex: 5861
	{
		// Fields
		[ResourcePath("Runtime/Vrs/Shaders/VrsTexture.compute", SearchType.ProjectPath)]
		[SerializeField]
		[Tooltip("Compute shader used for converting textures to shading rate values")]
		private ComputeShader m_TextureComputeShader; // 0x10
		[ResourcePath("Runtime/Vrs/Shaders/VrsVisualization.shader", SearchType.ProjectPath)]
		[SerializeField]
		[Tooltip("Shader used when visualizing shading rate values as a color image")]
		private Shader m_VisualizationShader; // 0x18
		[SerializeField]
		[Tooltip("Colors to visualize the shading rates")]
		private VrsLut m_VisualizationLookupTable; // 0x20
		[SerializeField]
		[Tooltip("Colors to convert between shading rates and textures")]
		private VrsLut m_ConversionLookupTable; // 0x28
	
		// Properties
		public int version { get; } // 0x00000001802E7860-0x00000001802E7870 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public ComputeShader textureComputeShader { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181ED22E0-0x0000000181ED2350
		public Shader visualizationShader { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181ED23C0-0x0000000181ED2430
		public VrsLut visualizationLookupTable { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181ED2350-0x0000000181ED23C0
		public VrsLut conversionLookupTable { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181ED2270-0x0000000181ED22E0
	
		// Constructors
		public VrsRenderPipelineRuntimeResources(); // 0x0000000181ED2220-0x0000000181ED2270
	}
}
