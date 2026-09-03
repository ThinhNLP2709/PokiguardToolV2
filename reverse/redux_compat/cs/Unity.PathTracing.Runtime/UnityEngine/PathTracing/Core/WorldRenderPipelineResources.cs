/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	[Serializable]
	[CategoryInfo(Name = "R: Path Tracing Core World", Order = 1000)]
	[HideInInspector]
	[SupportedOnRenderPipeline(new Type[0])]
	internal sealed class WorldRenderPipelineResources : IRenderPipelineResources // TypeDefIndex: 13619
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int _version; // 0x10
		[ResourcePath("Runtime/PathTracing/Shaders/BlitCubemap.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader _blitCubemap; // 0x18
		[ResourcePath("Runtime/PathTracing/Shaders/BlitCookie.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader _blitGrayScaleCookie; // 0x20
		[ResourcePath("Runtime/PathTracing/Shaders/SetAlphaChannel.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader _setAlphaChannelShader; // 0x28
		[FormerlySerializedAs("_pathTracingSkySamplingDataShader")]
		[ResourcePath("Runtime/PathTracing/Environment/EnvironmentImportanceSamplingBuild.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader _environmentImportanceSamplingBuild; // 0x30
		[ResourcePath("Runtime/PathTracing/Meshes/SkyBoxMesh.mesh", SearchType.ProjectPath)]
		[SerializeField]
		private Mesh _skyBoxMesh; // 0x38
		[ResourcePath("Runtime/PathTracing/Meshes/6FaceSkyboxMesh.mesh", SearchType.ProjectPath)]
		[SerializeField]
		private Mesh _sixFaceSkyBoxMesh; // 0x40
		[ResourcePath("Runtime/PathTracing/Shaders/BuildLightGrid.compute", SearchType.ProjectPath)]
		[SerializeField]
		private ComputeShader _buildLightGridShader; // 0x48
		[ResourcePath("Runtime/PathTracing/Environment/SolidColor.shader", SearchType.ProjectPath)]
		[SerializeField]
		private Shader _solidColorShader; // 0x50
	
		// Properties
		public int version { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public ComputeShader BlitCubemap { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181E181C0-0x0000000181E18230
		public ComputeShader BlitGrayScaleCookie { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181E18230-0x0000000181E182A0
		public ComputeShader SetAlphaChannelShader { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181E18380-0x0000000181E183F0
		public ComputeShader EnvironmentImportanceSamplingBuild { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181E18310-0x0000000181E18380
		public Mesh SkyBoxMesh { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x0000000181E18460-0x0000000181E184D0
		public Mesh SixFaceSkyBoxMesh { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181E183F0-0x0000000181E18460
		public ComputeShader BuildLightGridShader { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x0000000181E182A0-0x0000000181E18310
		public Shader SolidColorShader { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x0000000181E184D0-0x0000000181E18540
	
		// Constructors
		public WorldRenderPipelineResources(); // 0x0000000181E181B0-0x0000000181E181C0
	}
}
