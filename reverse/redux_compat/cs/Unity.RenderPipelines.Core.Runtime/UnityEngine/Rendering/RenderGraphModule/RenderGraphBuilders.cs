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
	internal class RenderGraphBuilders : IComputeRenderGraphBuilder, IRasterRenderGraphBuilder, IUnsafeRenderGraphBuilder // TypeDefIndex: 5924
	{
		// Fields
		private RenderGraphPass m_RenderPass; // 0x10
		private RenderGraphResourceRegistry m_Resources; // 0x18
		private RenderGraph m_RenderGraph; // 0x20
		private RenderGraphValidationLayer m_AdditionalValidationLayer; // 0x28
		private bool m_Disposed; // 0x30
	
		// Properties
		internal RenderGraphValidationLayer additionalValidationLayer { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public RenderGraphBuilders(); // 0x0000000181EE0220-0x0000000181EE0290
	
		// Methods
		public void Setup(RenderGraphPass renderPass, RenderGraphResourceRegistry resources, RenderGraph renderGraph, RenderGraphValidationLayer validationLayer); // 0x0000000181EDF7D0-0x0000000181EDF890
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckInputAttachment(int index, bool isDepth); // 0x0000000181EDB370-0x0000000181EDB660
		public void EnableAsyncCompute(bool value); // 0x0000000181EDED80-0x0000000181EDEDA0
		public void AllowPassCulling(bool value); // 0x0000000181EDB190-0x0000000181EDB1C0
		public void AllowGlobalStateModification(bool value); // 0x0000000181EDB160-0x0000000181EDB190
		public void EnableFoveatedRasterization(bool value); // 0x0000000181EDEDA0-0x0000000181EDEDC0
		public BufferHandle CreateTransientBuffer([IsReadOnly] in BufferDesc desc); // 0x0000000181EDE6B0-0x0000000181EDE7A0
		public BufferHandle CreateTransientBuffer([IsReadOnly] in BufferHandle computebuffer); // 0x0000000181EDE650-0x0000000181EDE6B0
		public TextureHandle CreateTransientTexture([IsReadOnly] in TextureDesc desc); // 0x0000000181EDE7A0-0x0000000181EDE880
		public TextureHandle CreateTransientTexture([IsReadOnly] in TextureHandle texture); // 0x0000000181EDE880-0x0000000181EDE8E0
		public void GenerateDebugData(bool value); // 0x0000000181EDEDC0-0x0000000181EDEDE0
		public void Dispose(); // 0x0000000181EDED60-0x0000000181EDED80
		protected virtual void Dispose(bool disposing); // 0x0000000181EDE8E0-0x0000000181EDED60
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckWriteTo([IsReadOnly] in ResourceHandle handle); // 0x0000000181EDE070-0x0000000181EDE650
		private ResourceHandle UseTransientResource([IsReadOnly] in ResourceHandle inputHandle); // 0x0000000181EE0160-0x0000000181EE0220
		private ResourceHandle UseResource([IsReadOnly] in ResourceHandle inputHandle, AccessFlags flags); // 0x0000000181EDFE40-0x0000000181EE00D0
		public BufferHandle UseBuffer([IsReadOnly] in BufferHandle input, AccessFlags flags); // 0x0000000181EDF8F0-0x0000000181EDF930
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUseFragment([IsReadOnly] in TextureHandle tex); // 0x0000000181EDB660-0x0000000181EDBA70
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckTextureUVOriginIsValid([IsReadOnly] in ResourceHandle handle, TextureResource texRes); // 0x0000000181EDC1B0-0x0000000181EDC3F0
		public void UseTexture([IsReadOnly] in TextureHandle input, AccessFlags flags); // 0x0000000181EE00D0-0x0000000181EE0160
		public void UseGlobalTexture(int propertyId, AccessFlags flags); // 0x0000000181EDFAE0-0x0000000181EDFE40
		public void UseAllGlobalTextures(bool enable); // 0x0000000181EDF960-0x0000000181EDF980
		public void SetGlobalTextureAfterPass([IsReadOnly] in TextureHandle input, int propertyId); // 0x0000000181EDEE00-0x0000000181EDEF00
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckUseFragment([IsReadOnly] in TextureHandle tex, bool isDepth, int depthSlice); // 0x0000000181EDC3F0-0x0000000181EDE070
		public void SetRenderAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181EDF440-0x0000000181EDF660
		public void SetInputAttachment(TextureHandle tex, int index, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181EDEF00-0x0000000181EDF1A0
		public void SetRenderAttachmentDepth(TextureHandle tex, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181EDF250-0x0000000181EDF440
		public TextureHandle SetRandomAccessAttachment(TextureHandle input, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C1B */); // 0x0000000181EDF1A0-0x0000000181EDF250
		public void SetShadingRateImageAttachment([IsReadOnly] in TextureHandle tex); // 0x0000000181EDF710-0x0000000181EDF7D0
		public BufferHandle UseBufferRandomAccess(BufferHandle input, int index, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C1C */); // 0x0000000181EDF980-0x0000000181EDFA30
		public BufferHandle UseBufferRandomAccess(BufferHandle input, int index, bool preserveCounterValue, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C1D */); // 0x0000000181EDFA30-0x0000000181EDFAE0
		public void SetRenderFunc<PassData>(BaseRenderFunc<PassData, ComputeGraphContext> renderFunc)
			where PassData : class, new();
		public void SetRenderFunc<PassData>(BaseRenderFunc<PassData, RasterGraphContext> renderFunc)
			where PassData : class, new();
		public void SetRenderFunc<PassData>(BaseRenderFunc<PassData, UnsafeGraphContext> renderFunc)
			where PassData : class, new();
		public void UseRendererList([IsReadOnly] in RendererListHandle input); // 0x0000000181EDF930-0x0000000181EDF950
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckResource([IsReadOnly] in ResourceHandle res, bool checkTransientReadWrite = false /* Metadata: 0x00662C1E */); // 0x0000000181EDBA70-0x0000000181EDC1B0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckFrameBufferFetchEmulationIsSupported([IsReadOnly] in TextureHandle tex); // 0x0000000181EDB1C0-0x0000000181EDB370
		public void SetShadingRateFragmentSize(ShadingRateFragmentSize shadingRateFragmentSize); // 0x0000000181EDF6D0-0x0000000181EDF710
		public void SetShadingRateCombiner(ShadingRateCombinerStage stage, ShadingRateCombiner combiner); // 0x0000000181EDF660-0x0000000181EDF6D0
		public void SetExtendedFeatureFlags(ExtendedFeatureFlags extendedFeatureFlags); // 0x0000000181EDEDE0-0x0000000181EDEE00
		void IRasterRenderGraphBuilder.SetShadingRateImageAttachment([IsReadOnly] in TextureHandle tex); // 0x0000000181EDF710-0x0000000181EDF7D0
		void IBaseRenderGraphBuilder.UseTexture([IsReadOnly] in TextureHandle input, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C1F */); // 0x0000000181EDF950-0x0000000181EDF960
		void IBaseRenderGraphBuilder.SetGlobalTextureAfterPass([IsReadOnly] in TextureHandle input, int propertyId); // 0x0000000181EDEE00-0x0000000181EDEF00
		BufferHandle IBaseRenderGraphBuilder.UseBuffer([IsReadOnly] in BufferHandle input, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00662C20 */); // 0x0000000181EDF8F0-0x0000000181EDF930
		TextureHandle IBaseRenderGraphBuilder.CreateTransientTexture([IsReadOnly] in TextureDesc desc); // 0x0000000181EDF8C0-0x0000000181EDF8F0
		TextureHandle IBaseRenderGraphBuilder.CreateTransientTexture([IsReadOnly] in TextureHandle texture); // 0x0000000181EDE880-0x0000000181EDE8E0
		BufferHandle IBaseRenderGraphBuilder.CreateTransientBuffer([IsReadOnly] in BufferDesc desc); // 0x0000000181EDF890-0x0000000181EDF8C0
		BufferHandle IBaseRenderGraphBuilder.CreateTransientBuffer([IsReadOnly] in BufferHandle computebuffer); // 0x0000000181EDE650-0x0000000181EDE6B0
		void IBaseRenderGraphBuilder.UseRendererList([IsReadOnly] in RendererListHandle input); // 0x0000000181EDF930-0x0000000181EDF950
	}
}
