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
	public class PostProcessData : ScriptableObject // TypeDefIndex: 9307
	{
		// Fields
		public ShaderResources shaders; // 0x18
		public TextureResources textures; // 0x20
	
		// Nested types
		[Serializable]
		[CategoryInfo(Name = "R: Default PostProcess Shaders", Order = 1000)]
		[ElementInfo(Order = 0)]
		[HideInInspector]
		[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
		public sealed class ShaderResources : IRenderPipelineResources // TypeDefIndex: 9308
		{
			// Fields
			[ResourcePath("Shaders/PostProcessing/StopNaN.shader", SearchType.ProjectPath)]
			public Shader stopNanPS; // 0x10
			[ResourcePath("Shaders/PostProcessing/SubpixelMorphologicalAntialiasing.shader", SearchType.ProjectPath)]
			public Shader subpixelMorphologicalAntialiasingPS; // 0x18
			[ResourcePath("Shaders/PostProcessing/GaussianDepthOfField.shader", SearchType.ProjectPath)]
			public Shader gaussianDepthOfFieldPS; // 0x20
			[ResourcePath("Shaders/PostProcessing/BokehDepthOfField.shader", SearchType.ProjectPath)]
			public Shader bokehDepthOfFieldPS; // 0x28
			[ResourcePath("Shaders/PostProcessing/CameraMotionBlur.shader", SearchType.ProjectPath)]
			public Shader cameraMotionBlurPS; // 0x30
			[ResourcePath("Shaders/PostProcessing/PaniniProjection.shader", SearchType.ProjectPath)]
			public Shader paniniProjectionPS; // 0x38
			[ResourcePath("Shaders/PostProcessing/LutBuilderLdr.shader", SearchType.ProjectPath)]
			public Shader lutBuilderLdrPS; // 0x40
			[ResourcePath("Shaders/PostProcessing/LutBuilderHdr.shader", SearchType.ProjectPath)]
			public Shader lutBuilderHdrPS; // 0x48
			[ResourcePath("Shaders/PostProcessing/Bloom.shader", SearchType.ProjectPath)]
			public Shader bloomPS; // 0x50
			[ResourcePath("Shaders/PostProcessing/TemporalAA.shader", SearchType.ProjectPath)]
			public Shader temporalAntialiasingPS; // 0x58
			[ResourcePath("Shaders/PostProcessing/LensFlareDataDriven.shader", SearchType.ProjectPath)]
			public Shader LensFlareDataDrivenPS; // 0x60
			[ResourcePath("Shaders/PostProcessing/LensFlareScreenSpace.shader", SearchType.ProjectPath)]
			public Shader LensFlareScreenSpacePS; // 0x68
			[ResourcePath("Shaders/PostProcessing/ScalingSetup.shader", SearchType.ProjectPath)]
			public Shader scalingSetupPS; // 0x70
			[ResourcePath("Shaders/PostProcessing/EdgeAdaptiveSpatialUpsampling.shader", SearchType.ProjectPath)]
			public Shader easuPS; // 0x78
			[ResourcePath("Shaders/PostProcessing/UberPost.shader", SearchType.ProjectPath)]
			public Shader uberPostPS; // 0x80
			[ResourcePath("Shaders/PostProcessing/FinalPost.shader", SearchType.ProjectPath)]
			public Shader finalPostPassPS; // 0x88
			[HideInInspector]
			[SerializeField]
			private int m_ShaderResourcesVersion; // 0x90
	
			// Properties
			public int version { get; } // 0x000000018169CBC0-0x000000018169CBD0 
			public bool isAvailableInPlayerBuild { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public ShaderResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CategoryInfo(Name = "R: Default PostProcess Textures", Order = 1000)]
		[ElementInfo(Order = 0)]
		[HideInInspector]
		[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
		public sealed class TextureResources : IRenderPipelineResources // TypeDefIndex: 9309
		{
			// Fields
			[ResourceFormattedPaths("Textures/BlueNoise16/L/LDR_LLL1_{0}.png", 0, 32, SearchType.ProjectPath)]
			public Texture2D[] blueNoise16LTex; // 0x10
			[Obsolete("Film grain textures have been moved to FilmGrainResources in GraphicsSettings. This field is no longer used. #from(6000.6)", false)]
			public Texture2D[] filmGrainTex; // 0x18
			[ResourcePath("Textures/SMAA/AreaTex.tga", SearchType.ProjectPath)]
			public Texture2D smaaAreaTex; // 0x20
			[ResourcePath("Textures/SMAA/SearchTex.tga", SearchType.ProjectPath)]
			public Texture2D smaaSearchTex; // 0x28
			[HideInInspector]
			[SerializeField]
			private int m_TexturesResourcesVersion; // 0x30
	
			// Properties
			public int version { get; } // 0x000000018033D100-0x000000018033D110 
			public bool isAvailableInPlayerBuild { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public TextureResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public PostProcessData(); // 0x00000001805F5FD0-0x00000001805F5FE0
	}
}
