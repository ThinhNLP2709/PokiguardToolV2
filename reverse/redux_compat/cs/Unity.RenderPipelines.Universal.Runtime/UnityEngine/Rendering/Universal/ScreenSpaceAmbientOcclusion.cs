/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[DisallowMultipleRendererFeature("Screen Space Ambient Occlusion")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("The Ambient Occlusion effect darkens creases, holes, intersections and surfaces that are close to each other.")]
	public class ScreenSpaceAmbientOcclusion : ScriptableRendererFeature // TypeDefIndex: 9733
	{
		// Fields
		[SerializeField]
		private ScreenSpaceAmbientOcclusionSettings m_Settings; // 0x28
		private AAOPass m_AAOPass; // 0x30
		private Shader m_RasterizationShader; // 0x38
		private Texture2D[] m_BlueNoise256Textures; // 0x40
	
		// Properties
		internal ref ScreenSpaceAmbientOcclusionSettings settings { get; } // 0x0000000181FC2D50-0x0000000181FC2D60 
	
		// Nested types
		private struct FeatureSettings // TypeDefIndex: 9734
		{
			// Fields
			public bool afterOpaque; // 0x00
			public bool isDepthNormalsSource; // 0x01
			public RenderPassEvent passEvent; // 0x04
			public ScriptableRenderPassInput requirements; // 0x08
			public ScreenSpaceAmbientOcclusionSettings.DepthSource effectiveDepthSource; // 0x0C
		}
	
		// Constructors
		public ScreenSpaceAmbientOcclusion(); // 0x0000000181FCDBE0-0x0000000181FCDC80
	
		// Methods
		public override void Create(); // 0x0000000181FCD6E0-0x0000000181FCD950
		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181FCD320-0x0000000181FCD6E0
		private static FeatureSettings ResolveFeatureSettings(ScreenSpaceAmbientOcclusionSettings settings, bool usesDeferred); // 0x0000000181FCD990-0x0000000181FCDA10
		protected override void Dispose(bool disposing); // 0x0000000181FCD950-0x0000000181FCD990
		private bool TryPrepareResources(); // 0x0000000181FCDA10-0x0000000181FCDBE0
	}
}
