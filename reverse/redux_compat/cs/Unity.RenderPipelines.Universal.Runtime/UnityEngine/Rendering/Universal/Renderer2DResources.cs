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
	[CategoryInfo(Name = "R: 2D Renderer", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	internal class Renderer2DResources : IRenderPipelineResources // TypeDefIndex: 9692
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Shaders/2D/Light2D.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_LightShader; // 0x18
		[ResourcePath("Shaders/2D/RenderingLayerMask.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_RenderingLayerMaskShader; // 0x20
		[ResourcePath("Shaders/2D/Shadow2D-Projected.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_ProjectedShadowShader; // 0x28
		[ResourcePath("Shaders/2D/Shadow2D-Sprite.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_SpriteShadowShader; // 0x30
		[ResourcePath("Shaders/2D/Shadow2D-Geometry.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_GeometryShadowShader; // 0x38
		[ResourcePath("Shaders/Utils/CopyDepth.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_CopyDepthPS; // 0x40
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal Shader lightShader { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FCCE50-0x0000000181FCCEC0
		internal Shader renderingLayerMaskShader { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FCCF30-0x0000000181FCCFA0
		internal Shader projectedShadowShader { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181FCCEC0-0x0000000181FCCF30
		internal Shader spriteShadowShader { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181FCCFA0-0x0000000181FCD010
		internal Shader geometryShadowShader { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181FCCDE0-0x0000000181FCCE50
		internal Shader copyDepthPS { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181FCCD70-0x0000000181FCCDE0
	
		// Constructors
		public Renderer2DResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
