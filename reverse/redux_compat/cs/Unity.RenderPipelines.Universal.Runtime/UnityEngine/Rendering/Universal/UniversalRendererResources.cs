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
	[CategoryInfo(Name = "R: Universal Renderer Shaders", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class UniversalRendererResources : IRenderPipelineResources // TypeDefIndex: 9699
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[ResourcePath("Shaders/Utils/CopyDepth.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_CopyDepthPS; // 0x18
		[ResourcePath("Shaders/CameraMotionVectors.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_CameraMotionVector; // 0x20
		[ResourcePath("Shaders/Utils/StencilDeferred.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_StencilDeferredPS; // 0x28
		[ResourcePath("Shaders/Utils/ClusterDeferred.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_ClusterDeferred; // 0x30
		[ResourcePath("Shaders/Utils/StencilDitherMaskSeed.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_StencilDitherMaskSeedPS; // 0x38
		[Header("Decal Renderer Feature Specific")]
		[ResourcePath("Runtime/Decal/DBuffer/DBufferClear.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_DBufferClear; // 0x40
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Shader copyDepthPS { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD8370-0x0000000181FD83E0
		public Shader cameraMotionVector { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FD8290-0x0000000181FD8300
		public Shader stencilDeferredPS { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181FD8450-0x0000000181FD84C0
		public Shader clusterDeferred { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181FD8300-0x0000000181FD8370
		public Shader stencilDitherMaskSeedPS { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181FD84C0-0x0000000181FD8530
		public Shader decalDBufferClear { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181FD83E0-0x0000000181FD8450
	
		// Constructors
		public UniversalRendererResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
