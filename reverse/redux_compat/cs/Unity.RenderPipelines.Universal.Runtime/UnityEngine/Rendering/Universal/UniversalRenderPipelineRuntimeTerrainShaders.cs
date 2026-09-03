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
	[CategoryInfo(Name = "R: Runtime Shaders", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class UniversalRenderPipelineRuntimeTerrainShaders : IRenderPipelineResources // TypeDefIndex: 9696
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Shaders/Terrain/TerrainDetailLit.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_TerrainDetailLit; // 0x18
		[ResourcePath("Shaders/Terrain/WavingGrassBillboard.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_TerrainDetailGrassBillboard; // 0x20
		[ResourcePath("Shaders/Terrain/WavingGrass.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_TerrainDetailGrass; // 0x28
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x0000000181FD7BE0-0x0000000181FD7C60 
		public Shader terrainDetailLitShader { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD7D40-0x0000000181FD7DB0
		public Shader terrainDetailGrassBillboardShader { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FD7C60-0x0000000181FD7CD0
		public Shader terrainDetailGrassShader { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181FD7CD0-0x0000000181FD7D40
	
		// Constructors
		public UniversalRenderPipelineRuntimeTerrainShaders(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
