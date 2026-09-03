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
	[CategoryInfo(Name = "R: Runtime Textures", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class UniversalRenderPipelineRuntimeTextures : IRenderPipelineResources // TypeDefIndex: 9697
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Textures/BlueNoise64/L/LDR_LLL1_0.png", SearchType.ProjectPath)]
		[SerializeField]
		private Texture2D m_BlueNoise64LTex; // 0x18
		[ResourcePath("Textures/BayerMatrix.png", SearchType.ProjectPath)]
		[SerializeField]
		private Texture2D m_BayerMatrixTex; // 0x20
		[ResourcePath("Textures/DebugFont.tga", SearchType.ProjectPath)]
		[SerializeField]
		private Texture2D m_DebugFontTex; // 0x28
		private Texture2D m_StencilDitherTex; // 0x30
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Texture2D blueNoise64LTex { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD7FC0-0x0000000181FD8030
		public Texture2D bayerMatrixTex { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FD7F50-0x0000000181FD7FC0
		public Texture2D debugFontTexture { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181FD8030-0x0000000181FD80A0
		public Texture2D stencilDitherTex { get; } // 0x0000000181FD7DB0-0x0000000181FD7F50 
	
		// Constructors
		public UniversalRenderPipelineRuntimeTextures(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
