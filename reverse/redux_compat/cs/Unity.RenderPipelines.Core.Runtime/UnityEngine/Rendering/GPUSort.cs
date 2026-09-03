/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public struct GPUSort // TypeDefIndex: 5763
	{
		// Fields
		private const uint kWorkGroupSize = 1024; // Metadata: 0x00661AA0
		private LocalKeyword[] m_Keywords; // 0x00
		private static readonly ProfilingSampler k_LocalBMS; // 0x00
		private static readonly ProfilingSampler k_LocalDisperse; // 0x08
		private static readonly ProfilingSampler k_BigFlip; // 0x10
		private static readonly ProfilingSampler k_BigDisperse; // 0x18
		private static readonly ProfilingSampler[] k_StageMarkers; // 0x20
		private SystemResources resources; // 0x08
	
		// Nested types
		public struct Args // TypeDefIndex: 5764
		{
			// Fields
			public uint count; // 0x00
			public uint maxDepth; // 0x04
			public GraphicsBuffer inputKeys; // 0x08
			public GraphicsBuffer inputValues; // 0x10
			public SupportResources resources; // 0x18
			internal int workGroupCount; // 0x28
		}
	
		public struct RenderGraphResources // TypeDefIndex: 5765
		{
			// Fields
			public BufferHandle sortBufferKeys; // 0x00
			public BufferHandle sortBufferValues; // 0x0C
	
			// Methods
			[Obsolete("This Create signature is deprecated and will be removed in the future. Please use Create(IBaseRenderGraphBuilder) instead. #from(6000.3)")]
			public static RenderGraphResources Create(int count, RenderGraph renderGraph, RenderGraphBuilder builder); // 0x0000000181EB7980-0x0000000181EB7AB0
			public static RenderGraphResources Create(int count, RenderGraph renderGraph, IBaseRenderGraphBuilder builder); // 0x0000000181EB7AB0-0x0000000181EB7CE0
		}
	
		public struct SupportResources // TypeDefIndex: 5766
		{
			// Fields
			public GraphicsBuffer sortBufferKeys; // 0x00
			public GraphicsBuffer sortBufferValues; // 0x08
	
			// Methods
			public static SupportResources Load(RenderGraphResources renderGraphResources); // 0x0000000181EB9E20-0x0000000181EB9F00
			public void Dispose(); // 0x0000000181EB9910-0x0000000181EB9970
		}
	
		public struct SystemResources // TypeDefIndex: 5767
		{
			// Fields
			public ComputeShader computeAsset; // 0x00
		}
	
		private enum Stage // TypeDefIndex: 5768
		{
			LocalBMS = 0,
			LocalDisperse = 1,
			BigFlip = 2,
			BigDisperse = 3
		}
	
		// Constructors
		public GPUSort(SystemResources resources); // 0x0000000181EB6100-0x0000000181EB6300
		static GPUSort(); // 0x0000000181EB5DE0-0x0000000181EB6100
	
		// Methods
		private void DispatchStage(CommandBuffer cmd, Args args, uint h, Stage stage); // 0x0000000181EB5780-0x0000000181EB5A70
		private void CopyBuffer(CommandBuffer cmd, GraphicsBuffer src, GraphicsBuffer dst); // 0x0000000181EB55B0-0x0000000181EB5780
		internal static int DivRoundUp(int x, int y); // 0x0000000181E58550-0x0000000181E58560
		public void Dispatch(IComputeCommandBuffer cmd, Args args); // 0x0000000181EB5D10-0x0000000181EB5DE0
		public void Dispatch(CommandBuffer cmd, Args args); // 0x0000000181EB5A70-0x0000000181EB5D10
	}
}
