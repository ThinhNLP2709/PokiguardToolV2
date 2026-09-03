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
	[DisallowMultipleRendererFeature("Screen Space Reflection")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("The Screen Space Reflection produces realtime reflections without the need for reflection probes.")]
	public class ScreenSpaceReflectionRendererFeature : ScriptableRendererFeature // TypeDefIndex: 9746
	{
		// Fields
		[Tooltip("Whether to apply screen space reflections after the opaque pass or before the opaque pass. Enabling this feature may improve performance on low-end platforms, but will result in less physically correct reflections.")]
		public bool afterOpaque; // 0x28
		private ScreenSpaceReflectionDepthNormalOnlyTransparentPass m_TransparentDepthNormalPass; // 0x30
		private ScreenSpaceReflectionPass m_SSRPass; // 0x38
		private Shader m_Shader; // 0x40
		private Material m_Material; // 0x48
		private Shader m_BlitShader; // 0x50
		private Material m_BlitMaterial; // 0x58
	
		// Constructors
		public ScreenSpaceReflectionRendererFeature(); // 0x0000000181FD3CD0-0x0000000181FD3CE0
	
		// Methods
		public override void Create(); // 0x0000000181FD34E0-0x0000000181FD36D0
		protected override void Dispose(bool disposing); // 0x0000000181FD36D0-0x0000000181FD3780
		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181FD3250-0x0000000181FD34E0
		private bool TryPrepareResources(LayerMask transparentLayerMask, ScreenSpaceReflectionVolumeSettings settings); // 0x0000000181FD3780-0x0000000181FD3CD0
	}
}
