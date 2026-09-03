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
	[CategoryInfo(Name = "R: SSR Resources", Order = 1010)]
	[ElementInfo(Order = 0)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	internal class ScreenSpaceReflectionPersistentResources : IRenderPipelineResources // TypeDefIndex: 9745
	{
		// Fields
		[ResourcePath("Shaders/Utils/ComputeScreenSpaceReflection.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_Shader; // 0x10
		[ResourcePath("Shaders/Utils/BlitFullPrecision.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_BlitShader; // 0x18
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x20
	
		// Properties
		public Shader Shader { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181FD31E0-0x0000000181FD3250
		public Shader BlitShader { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD3170-0x0000000181FD31E0
		public bool isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public int version { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		public ScreenSpaceReflectionPersistentResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
