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
	[CategoryInfo(Name = "R: Adaptive Probe Volumes", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal class ProbeVolumeDebugResources : IRenderPipelineResources // TypeDefIndex: 5611
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_Version; // 0x10
		[Header("Debug")]
		[ResourcePath("Runtime/Debug/ProbeVolumeDebug.shader", SearchType.ProjectPath)]
		public Shader probeVolumeDebugShader; // 0x18
		[ResourcePath("Runtime/Debug/ProbeVolumeFragmentationDebug.shader", SearchType.ProjectPath)]
		public Shader probeVolumeFragmentationDebugShader; // 0x20
		[ResourcePath("Runtime/Debug/ProbeVolumeSamplingDebug.shader", SearchType.ProjectPath)]
		public Shader probeVolumeSamplingDebugShader; // 0x28
		[ResourcePath("Runtime/Debug/ProbeVolumeOffsetDebug.shader", SearchType.ProjectPath)]
		public Shader probeVolumeOffsetDebugShader; // 0x30
		[ResourcePath("Runtime/Debug/ProbeSamplingDebugMesh.fbx", SearchType.ProjectPath)]
		public Mesh probeSamplingDebugMesh; // 0x38
		[ResourcePath("Runtime/Debug/ProbeVolumeNumbersDisplayTex.png", SearchType.ProjectPath)]
		public Texture2D numbersDisplayTex; // 0x40
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public ProbeVolumeDebugResources(); // 0x0000000181501E90-0x0000000181501EA0
	}
}
