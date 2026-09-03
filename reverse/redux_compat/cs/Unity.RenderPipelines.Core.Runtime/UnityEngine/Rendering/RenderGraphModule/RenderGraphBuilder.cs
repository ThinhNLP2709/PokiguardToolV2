/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	[Obsolete("RenderGraphBuilder is deprecated, use IComputeRenderGraphBuilder/IRasterRenderGraphBuilder/IUnsafeRenderGraphBuilder instead.", true)]
	public struct RenderGraphBuilder : IDisposable // TypeDefIndex: 5902
	{
		// Fields
		private RenderGraphPass m_RenderPass; // 0x00
		private RenderGraphResourceRegistry m_Resources; // 0x08
		private RenderGraph m_RenderGraph; // 0x10
		private bool m_Disposed; // 0x18
	
		// Constructors
		internal RenderGraphBuilder(RenderGraphPass renderPass, RenderGraphResourceRegistry resources, RenderGraph renderGraph); // 0x0000000181EDB100-0x0000000181EDB160
	
		// Methods
		public TextureHandle UseColorBuffer([IsReadOnly] in TextureHandle input, int index); // 0x0000000181EDAD20-0x0000000181EDAE40
		public TextureHandle UseDepthBuffer([IsReadOnly] in TextureHandle input, DepthAccess flags); // 0x0000000181EDAE40-0x0000000181EDAF60
		public TextureHandle ReadTexture([IsReadOnly] in TextureHandle input); // 0x0000000181EDAB10-0x0000000181EDACA0
		public TextureHandle WriteTexture([IsReadOnly] in TextureHandle input); // 0x0000000181EDB0A0-0x0000000181EDB100
		public TextureHandle ReadWriteTexture([IsReadOnly] in TextureHandle input); // 0x0000000181EDACA0-0x0000000181EDAD20
		public TextureHandle CreateTransientTexture([IsReadOnly] in TextureDesc desc); // 0x0000000181EDA970-0x0000000181EDA9E0
		public TextureHandle CreateTransientTexture([IsReadOnly] in TextureHandle texture); // 0x0000000181EDA8E0-0x0000000181EDA970
		public RayTracingAccelerationStructureHandle WriteRayTracingAccelerationStructure([IsReadOnly] in RayTracingAccelerationStructureHandle input); // 0x0000000181EDB030-0x0000000181EDB0A0
		public RayTracingAccelerationStructureHandle ReadRayTracingAccelerationStructure([IsReadOnly] in RayTracingAccelerationStructureHandle input); // 0x0000000181EDAAC0-0x0000000181EDAB10
		public RendererListHandle UseRendererList([IsReadOnly] in RendererListHandle input); // 0x0000000181EDAF60-0x0000000181EDAFC0
		public BufferHandle ReadBuffer([IsReadOnly] in BufferHandle input); // 0x0000000181EDAAC0-0x0000000181EDAB10
		public BufferHandle WriteBuffer([IsReadOnly] in BufferHandle input); // 0x0000000181EDAFC0-0x0000000181EDB030
		public BufferHandle CreateTransientBuffer([IsReadOnly] in BufferDesc desc); // 0x0000000181EDA860-0x0000000181EDA8E0
		public BufferHandle CreateTransientBuffer([IsReadOnly] in BufferHandle graphicsbuffer); // 0x0000000181EDA7C0-0x0000000181EDA860
		public void SetRenderFunc<PassData>(BaseRenderFunc<PassData, RenderGraphContext> renderFunc)
			where PassData : class, new();
		public void EnableAsyncCompute(bool value); // 0x0000000181EDAA60-0x0000000181EDAA80
		public void AllowPassCulling(bool value); // 0x0000000181EDA470-0x0000000181EDA490
		public void EnableFoveatedRasterization(bool value); // 0x0000000181EDAA80-0x0000000181EDAAA0
		public void Dispose(); // 0x0000000181EDAA30-0x0000000181EDAA60
		public void AllowRendererListCulling(bool value); // 0x0000000181EDA490-0x0000000181EDA4B0
		public RendererListHandle DependsOn([IsReadOnly] in RendererListHandle input); // 0x0000000181EDA9E0-0x0000000181EDAA30
		private void Dispose(bool disposing); // 0x0000000181EDAA30-0x0000000181EDAA60
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckResource([IsReadOnly] in ResourceHandle res, bool checkTransientReadWrite = true /* Metadata: 0x00662BFC */); // 0x0000000181EDA4B0-0x0000000181EDA7C0
		internal void GenerateDebugData(bool value); // 0x0000000181EDAAA0-0x0000000181EDAAC0
	}
}
