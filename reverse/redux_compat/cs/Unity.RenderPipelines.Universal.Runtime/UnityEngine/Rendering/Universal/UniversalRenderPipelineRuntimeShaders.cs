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
	public class UniversalRenderPipelineRuntimeShaders : IRenderPipelineResources // TypeDefIndex: 9695
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Shaders/Utils/FallbackError.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_FallbackErrorShader; // 0x18
		[ResourcePath("Shaders/Utils/BlitHDROverlay.shader", SearchType.ProjectPath)]
		[SerializeField]
		internal Shader m_BlitHDROverlay; // 0x20
		[ResourcePath("Shaders/Utils/CoreBlit.shader", SearchType.ProjectPath)]
		[SerializeField]
		internal Shader m_CoreBlitPS; // 0x28
		[ResourcePath("Shaders/Utils/CoreBlitColorAndDepth.shader", SearchType.ProjectPath)]
		[SerializeField]
		internal Shader m_CoreBlitColorAndDepthPS; // 0x30
		[ResourcePath("Shaders/Utils/UIBackdropFilterComposite.shader", SearchType.ProjectPath)]
		[SerializeField]
		internal Shader m_UIBackdropFilterCompositePS; // 0x38
		[ResourcePath("Shaders/Utils/Sampling.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_SamplingPS; // 0x40
		[Header("Terrain")]
		[HideInInspector]
		[SerializeField]
		private Shader m_TerrainDetailLit; // 0x48
		[HideInInspector]
		[SerializeField]
		private Shader m_TerrainDetailGrassBillboard; // 0x50
		[HideInInspector]
		[SerializeField]
		private Shader m_TerrainDetailGrass; // 0x58
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Shader fallbackErrorShader { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD7820-0x0000000181FD7890
		public Shader blitHDROverlay { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FD76D0-0x0000000181FD7740
		public Shader coreBlitPS { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181FD77B0-0x0000000181FD7820
		public Shader coreBlitColorAndDepthPS { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181FD7740-0x0000000181FD77B0
		internal Shader uiBackdropFilterCompositePS { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181FD7B70-0x0000000181FD7BE0
		public Shader samplingPS { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181FD7890-0x0000000181FD7900
		[Obsolete("terrainDetailLitShader is obsolete. Use UniversalRenderPipelineRuntimeTerrainShaders.terrainDetailLitShader instead.", false)]
		public Shader terrainDetailLitShader { get; set; } // 0x0000000181FD7650-0x0000000181FD76D0 0x0000000181FD7AA0-0x0000000181FD7B70
		[Obsolete("terrainDetailGrassBillboardShader is obsolete. Use UniversalRenderPipelineRuntimeTerrainShaders.terrainDetailGrassBillboardShader instead.", false)]
		public Shader terrainDetailGrassBillboardShader { get; set; } // 0x0000000181FD7550-0x0000000181FD75D0 0x0000000181FD7900-0x0000000181FD79D0
		[Obsolete("terrainDetailGrassShader is obsolete; Use UniversalRenderPipelineRuntimeTerrainShaders.terrainDetailGrassShader instead.)", false)]
		public Shader terrainDetailGrassShader { get; set; } // 0x0000000181FD75D0-0x0000000181FD7650 0x0000000181FD79D0-0x0000000181FD7AA0
	
		// Constructors
		public UniversalRenderPipelineRuntimeShaders(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal Shader GetOriginalTerrainDetailLitShader(); // 0x00000001803272B0-0x00000001803272C0
		internal Shader GetOriginalTerrainDetailGrassBillboardShader(); // 0x00000001806CCC00-0x00000001806CCC10
		internal Shader GetOriginalTerrainDetailGrassShader(); // 0x00000001802F4000-0x00000001802F4010
		internal void ClearOriginalTerrainDetailShaders(); // 0x0000000181FD7500-0x0000000181FD7550
	}
}
