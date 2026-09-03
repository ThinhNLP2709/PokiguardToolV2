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
	[CategoryInfo(Name = "R: Runtime XR", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	public class UniversalRenderPipelineRuntimeXRResources : IRenderPipelineResources // TypeDefIndex: 9698
	{
		// Fields
		[ResourcePath("Shaders/XR/XROcclusionMesh.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_xrOcclusionMeshPS; // 0x10
		[ResourcePath("Shaders/XR/XRMirrorView.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_xrMirrorViewPS; // 0x18
		[ResourcePath("Shaders/XR/XRMotionVector.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader m_xrMotionVector; // 0x20
	
		// Properties
		public int version { get; } // 0x00000001802E7860-0x00000001802E7870 
		bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public Shader xrOcclusionMeshPS { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181FD8220-0x0000000181FD8290
		public Shader xrMirrorViewPS { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181FD8140-0x0000000181FD81B0
		public Shader xrMotionVector { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181FD81B0-0x0000000181FD8220
		internal bool valid { get; } // 0x0000000181FD80A0-0x0000000181FD8140 
	
		// Constructors
		public UniversalRenderPipelineRuntimeXRResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
