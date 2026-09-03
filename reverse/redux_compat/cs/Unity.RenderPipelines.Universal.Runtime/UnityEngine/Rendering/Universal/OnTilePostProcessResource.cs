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
	[CategoryInfo(Name = "R: On Tile Post Process Resources", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	internal class OnTilePostProcessResource : IRenderPipelineResources // TypeDefIndex: 9717
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Runtime/RendererFeatures/OnTileUberPost.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_UberPostShader; // 0x18
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Shader uberPostShader { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FC43F0-0x0000000181FC4460
	
		// Constructors
		public OnTilePostProcessResource(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
