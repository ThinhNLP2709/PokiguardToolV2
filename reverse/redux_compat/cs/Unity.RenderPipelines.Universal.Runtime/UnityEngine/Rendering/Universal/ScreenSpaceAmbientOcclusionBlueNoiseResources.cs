/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[CategoryInfo(Name = "R: SSAO Noise Textures", Order = 1000)]
	[ElementInfo(Order = 0)]
	[HideInInspector]
	[MovedFrom(false, null, null, "ScreenSpaceAmbientOcclusionDynamicResources")]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	internal class ScreenSpaceAmbientOcclusionBlueNoiseResources : IRenderPipelineResources // TypeDefIndex: 9732
	{
		// Fields
		[ResourceFormattedPaths("Textures/BlueNoise256/LDR_LLL1_{0}.png", 0, 7, SearchType.ProjectPath)]
		[SerializeField]
		private Texture2D[] m_BlueNoise256Textures; // 0x10
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x18
	
		// Properties
		public Texture2D[] BlueNoise256Textures { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181FCD200-0x0000000181FCD270
		public bool isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public int version { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public ScreenSpaceAmbientOcclusionBlueNoiseResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
