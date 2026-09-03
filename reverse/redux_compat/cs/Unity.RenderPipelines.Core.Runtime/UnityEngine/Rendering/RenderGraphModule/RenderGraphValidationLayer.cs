/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal class RenderGraphValidationLayer : IRasterRenderGraphBuilder // TypeDefIndex: 5973
	{
		// Nested types
		public struct RenderPassInfo // TypeDefIndex: 5974
		{
			// Fields
			public RenderGraphPassType type; // 0x00
			public string name; // 0x08
		}
	
		// Constructors
		public RenderGraphValidationLayer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void OnPassAddedBegin([IsReadOnly] in RenderPassInfo renderPassInfo); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnPassAddedDispose(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void Clear(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UseTexture([IsReadOnly] in TextureHandle input, AccessFlags flags); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UseGlobalTexture(int propertyId, AccessFlags flags); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UseAllGlobalTextures(bool enable); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetGlobalTextureAfterPass([IsReadOnly] in TextureHandle input, int propertyId); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual BufferHandle UseBuffer([IsReadOnly] in BufferHandle input, AccessFlags flags); // 0x0000000180F61100-0x0000000180F61120
		public virtual void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags, int mipLevel, int depthSlice); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice); // 0x00000001802E76C0-0x00000001802E76D0
		public TextureHandle CreateTransientTexture([IsReadOnly] in TextureDesc desc); // 0x0000000181EEE080-0x0000000181EEE120
		public TextureHandle CreateTransientTexture([IsReadOnly] in TextureHandle texture); // 0x0000000181EEE120-0x0000000181EEE1C0
		public BufferHandle CreateTransientBuffer([IsReadOnly] in BufferDesc desc); // 0x0000000181EEDF40-0x0000000181EEDFE0
		public BufferHandle CreateTransientBuffer([IsReadOnly] in BufferHandle computebuffer); // 0x0000000181EEDFE0-0x0000000181EEE080
		public void UseRendererList([IsReadOnly] in RendererListHandle input); // 0x00000001802E76C0-0x00000001802E76D0
		public void EnableAsyncCompute(bool value); // 0x00000001802E76C0-0x00000001802E76D0
		public void AllowPassCulling(bool value); // 0x00000001802E76C0-0x00000001802E76D0
		public void AllowGlobalStateModification(bool value); // 0x00000001802E76C0-0x00000001802E76D0
		public void EnableFoveatedRasterization(bool value); // 0x00000001802E76C0-0x00000001802E76D0
		public void GenerateDebugData(bool value); // 0x00000001802E76C0-0x00000001802E76D0
		public TextureHandle SetRandomAccessAttachment(TextureHandle tex, int index, AccessFlags flags); // 0x0000000181EEE1C0-0x0000000181EEE260
		public BufferHandle UseBufferRandomAccess(BufferHandle tex, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C5A */); // 0x0000000180F61100-0x0000000180F61120
		public BufferHandle UseBufferRandomAccess(BufferHandle tex, int index, bool preserveCounterValue, AccessFlags flags); // 0x0000000180F61100-0x0000000180F61120
		public void SetShadingRateImageAttachment([IsReadOnly] in TextureHandle tex); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetShadingRateFragmentSize(ShadingRateFragmentSize shadingRateFragmentSize); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetShadingRateCombiner(ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetExtendedFeatureFlags(ExtendedFeatureFlags extendedFeatureFlags); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetRenderFunc<PassData>(BaseRenderFunc<PassData, RasterGraphContext> renderFunc)
			where PassData : class, new();
		public virtual void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		void IRasterRenderGraphBuilder.SetShadingRateImageAttachment([IsReadOnly] in TextureHandle tex); // 0x00000001802E76C0-0x00000001802E76D0
		TextureHandle IBaseRenderGraphBuilder.CreateTransientTexture([IsReadOnly] in TextureDesc desc); // 0x0000000181EEE080-0x0000000181EEE120
		TextureHandle IBaseRenderGraphBuilder.CreateTransientTexture([IsReadOnly] in TextureHandle texture); // 0x0000000181EEE120-0x0000000181EEE1C0
		BufferHandle IBaseRenderGraphBuilder.CreateTransientBuffer([IsReadOnly] in BufferDesc desc); // 0x0000000181EEDF40-0x0000000181EEDFE0
		BufferHandle IBaseRenderGraphBuilder.CreateTransientBuffer([IsReadOnly] in BufferHandle computebuffer); // 0x0000000181EEDFE0-0x0000000181EEE080
		void IBaseRenderGraphBuilder.UseRendererList([IsReadOnly] in RendererListHandle input); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
