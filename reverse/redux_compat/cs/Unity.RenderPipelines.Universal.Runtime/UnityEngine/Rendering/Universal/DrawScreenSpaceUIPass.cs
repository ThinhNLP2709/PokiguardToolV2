/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DrawScreenSpaceUIPass : ScriptableRenderPass // TypeDefIndex: 9555
	{
		// Fields
		private readonly Material m_UIBackdropFilterCompositeMaterial; // 0x60
		private readonly Material m_SeedBlitMaterial; // 0x68
		private const int k_CompositePassIndex = 0; // Metadata: 0x0069EC2A
		private bool m_RequiresComposition; // 0x70
		private RTHandle m_OverlayCompositeBuffer; // 0x78
		private RTHandle m_OverlayCompositeBufferBefore; // 0x80
		private RTHandle m_OverlayDepthStencilBuffer; // 0x88
		private TextureHandle m_OverlayCompositeBufferHandle; // 0x90
		private TextureHandle m_OverlayCompositeBufferBeforeHandle; // 0xA0
		private TextureHandle m_OverlayDepthStencilBufferHandle; // 0xB0
		private static readonly int s_BlitTextureBeforeId; // 0x00
	
		// Nested types
		private class PassData // TypeDefIndex: 9556
		{
			// Fields
			internal RendererListHandle rendererList; // 0x10
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class UnsafePassData // TypeDefIndex: 9557
		{
			// Fields
			internal RendererListHandle rendererList; // 0x10
			internal TextureHandle colorTarget; // 0x1C
			internal TextureHandle depthTarget; // 0x2C
			internal TextureHandle bufferBefore; // 0x3C
	
			// Constructors
			public UnsafePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class ViewportBlitPassData // TypeDefIndex: 9558
		{
			// Fields
			internal TextureHandle source; // 0x10
			internal TextureHandle destination; // 0x20
			internal Rect viewport; // 0x30
			internal Material material; // 0x40
			internal int passIndex; // 0x48
	
			// Constructors
			public ViewportBlitPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class CompositePassData // TypeDefIndex: 9559
		{
			// Fields
			internal TextureHandle source; // 0x10
			internal TextureHandle sourceBefore; // 0x20
			internal TextureHandle destination; // 0x30
			internal Material material; // 0x40
			internal int passIndex; // 0x48
	
			// Constructors
			public CompositePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9560
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<ViewportBlitPassData, RasterGraphContext> __9__23_0; // 0x08
			public static BaseRenderFunc<CompositePassData, RasterGraphContext> __9__26_0; // 0x10
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__27_0; // 0x18
			public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> __9__27_1; // 0x20
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__29_0; // 0x28
			public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> __9__30_0; // 0x30
			public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> __9__31_0; // 0x38
	
			// Constructors
			static __c(); // 0x0000000181F9B3A0-0x0000000181F9B410
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _AddViewportBlitPass_b__23_0(ViewportBlitPassData data, RasterGraphContext context); // 0x0000000181F99B60-0x0000000181F99D40
			internal void _AddUIBackdropFilterCompositePass_b__26_0(CompositePassData data, RasterGraphContext context); // 0x0000000181F999D0-0x0000000181F99B60
			internal void _RenderOffscreen_b__27_0(PassData data, RasterGraphContext context); // 0x0000000181F9A730-0x0000000181F9A830
			internal void _RenderOffscreen_b__27_1(UnsafePassData data, UnsafeGraphContext context); // 0x0000000181F9A830-0x0000000181F9A9A0
			internal void _RenderOverlayUIToolkitAndUGUI_b__29_0(PassData data, RasterGraphContext context); // 0x0000000181F9ADA0-0x0000000181F9AE70
			internal void _RenderOverlayUIToolkitAndUGUIComposite_b__30_0(UnsafePassData data, UnsafeGraphContext context); // 0x0000000181F9AB10-0x0000000181F9ADA0
			internal void _RenderOverlayIMGUI_b__31_0(UnsafePassData data, UnsafeGraphContext context); // 0x0000000181F9A9A0-0x0000000181F9AB10
		}
	
		// Constructors
		public DrawScreenSpaceUIPass(RenderPassEvent evt, Material uiBackdropFilterCompositeMaterial = null, Material seedBlitMaterial = null); // 0x0000000181F8EE60-0x0000000181F8F020
		static DrawScreenSpaceUIPass(); // 0x0000000181F8EE10-0x0000000181F8EE60
	
		// Methods
		internal void Setup(UniversalCameraData cameraData); // 0x0000000181F8ED40-0x0000000181F8EE10
		internal bool RequiresComposition(); // 0x0000000180643BD0-0x0000000180643BE0
		internal static void ConfigureOffscreenUITextureDesc(ref TextureDesc textureDesc); // 0x0000000181F8D160-0x0000000181F8D1A0
		private static void ConfigureDepthDescriptor(ref RenderTextureDescriptor descriptor, GraphicsFormat depthStencilFormat, int screenWidth, int screenHeight); // 0x0000000181F8D100-0x0000000181F8D160
		private static void ExecutePass(RasterCommandBuffer commandBuffer, PassData passData, RendererList rendererList); // 0x0000000181F7AC10-0x0000000181F7AC50
		private static void ExecutePass(UnsafeCommandBuffer commandBuffer, UnsafePassData passData, RendererList rendererList); // 0x0000000181F7AC10-0x0000000181F7AC50
		public void Dispose(); // 0x0000000181F8D1A0-0x0000000181F8D230
		internal void BlitCameraColorToOverlayCompositeBuffer(RenderGraph renderGraph, UniversalResourceData resourceData, Rect viewport, GraphicsFormat cameraDepthAttachmentFormat); // 0x0000000181F8D010-0x0000000181F8D100
		private void ImportOverlayCompositeTextures(RenderGraph renderGraph, UniversalResourceData resourceData, GraphicsFormat cameraDepthAttachmentFormat); // 0x0000000181F8D230-0x0000000181F8D6A0
		internal void AddViewportBlitPass(RenderGraph renderGraph, TextureHandle source, TextureHandle destination, Rect viewport, ProfilingSampler sampler, string passName); // 0x0000000181F8CBB0-0x0000000181F8D010
		internal void AddUIBackdropFilterCompositePass(RenderGraph renderGraph, TextureHandle source, TextureHandle sourceBefore, TextureHandle destination, ProfilingSampler sampler, string passName); // 0x0000000181F8C720-0x0000000181F8CBB0
		internal void RenderOffscreen(RenderGraph renderGraph, ContextContainer frameData, GraphicsFormat depthStencilFormat, TextureHandle overlayUITexture); // 0x0000000181F8D6A0-0x0000000181F8DFF0
		internal void RenderOverlay(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle colorBuffer, [IsReadOnly] in TextureHandle depthBuffer); // 0x0000000181F8ECC0-0x0000000181F8ED40
		internal void RenderOverlayUIToolkitAndUGUI(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle colorBuffer, [IsReadOnly] in TextureHandle depthBuffer); // 0x0000000181F8E830-0x0000000181F8ECC0
		internal void RenderOverlayUIToolkitAndUGUIComposite(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle destinationColor); // 0x0000000181F8E330-0x0000000181F8E830
		internal void RenderOverlayIMGUI(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle colorBuffer, [IsReadOnly] in TextureHandle depthBuffer); // 0x0000000181F8DFF0-0x0000000181F8E330
	}
}
