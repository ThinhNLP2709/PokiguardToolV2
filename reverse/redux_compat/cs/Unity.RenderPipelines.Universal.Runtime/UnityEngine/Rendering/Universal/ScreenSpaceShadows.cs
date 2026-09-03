/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[DisallowMultipleRendererFeature("Screen Space Shadows")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Screen Space Shadows")]
	internal class ScreenSpaceShadows : ScriptableRendererFeature // TypeDefIndex: 9756
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private Shader m_Shader; // 0x28
		[SerializeField]
		private ScreenSpaceShadowsSettings m_Settings; // 0x30
		private Material m_Material; // 0x38
		private ScreenSpaceShadowsPass m_SSShadowsPass; // 0x40
		private ScreenSpaceShadowsPostPass m_SSShadowsPostPass; // 0x48
		private const string k_ShaderName = "Hidden/Universal Render Pipeline/ScreenSpaceShadows"; // Metadata: 0x0069F047
	
		// Nested types
		private class ScreenSpaceShadowsPass : ScriptableRenderPass // TypeDefIndex: 9757
		{
			// Fields
			private Material m_Material; // 0x60
			private ScreenSpaceShadowsSettings m_CurrentSettings; // 0x68
			private int m_ScreenSpaceShadowmapTextureID; // 0x70
	
			// Nested types
			private class PassData // TypeDefIndex: 9758
			{
				// Fields
				internal TextureHandle target; // 0x10
				internal TextureHandle cameraDepthTexture; // 0x20
				internal TextureHandle activeTarget; // 0x30
				internal Material material; // 0x40
				internal UniversalCameraData cameraData; // 0x48
	
				// Constructors
				public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 9759
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static BaseRenderFunc<PassData, UnsafeGraphContext> __9__7_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181FF43F0-0x0000000181FF4460
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _RecordRenderGraph_b__7_0(PassData data, UnsafeGraphContext rgContext); // 0x0000000181FF3E90-0x0000000181FF3EA0
			}
	
			// Constructors
			internal ScreenSpaceShadowsPass(); // 0x0000000181FE3A80-0x0000000181FE3B50
	
			// Methods
			internal bool Setup(ScreenSpaceShadowsSettings featureSettings, Material material); // 0x0000000181FE39F0-0x0000000181FE3A80
			private void InitPassData(ref PassData passData, [IsReadOnly] in TextureHandle cameraDepthTexture, [IsReadOnly] in TextureHandle activeTarget, UniversalCameraData cameraData); // 0x0000000181FE3020-0x0000000181FE30A0
			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FE30A0-0x0000000181FE39F0
			private static void ExecutePass(UnsafeGraphContext rgContext, PassData data); // 0x0000000181FE2CF0-0x0000000181FE3020
		}
	
		private class ScreenSpaceShadowsPostPass : ScriptableRenderPass // TypeDefIndex: 9760
		{
			// Nested types
			internal class PassData // TypeDefIndex: 9761
			{
				// Fields
				internal UniversalShadowData shadowData; // 0x10
	
				// Constructors
				public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 9762
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static BaseRenderFunc<PassData, RasterGraphContext> __9__3_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181FF4380-0x0000000181FF43F0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _RecordRenderGraph_b__3_0(PassData data, RasterGraphContext rgContext); // 0x0000000181FF3D90-0x0000000181FF3E90
			}
	
			// Constructors
			internal ScreenSpaceShadowsPostPass(); // 0x0000000181FE4060-0x0000000181FE40E0
	
			// Methods
			private static void ExecutePass(RasterCommandBuffer cmd, UniversalShadowData shadowData); // 0x0000000181FE3B50-0x0000000181FE3C40
			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FE3C40-0x0000000181FE4060
		}
	
		// Constructors
		public ScreenSpaceShadows(); // 0x0000000181FE4730-0x0000000181FE47E0
	
		// Methods
		public override void Create(); // 0x0000000181FE43C0-0x0000000181FE45B0
		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181FE40E0-0x0000000181FE43C0
		protected override void Dispose(bool disposing); // 0x0000000181FE45B0-0x0000000181FE4610
		private bool LoadMaterial(); // 0x0000000181FE4610-0x0000000181FE4730
	}
}
