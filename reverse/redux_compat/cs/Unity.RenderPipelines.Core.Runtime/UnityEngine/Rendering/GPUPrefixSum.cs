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
	public struct GPUPrefixSum // TypeDefIndex: 5754
	{
		// Fields
		private SystemResources resources; // 0x00
	
		// Nested types
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\Utilities\\GPUPrefixSum\\GPUPrefixSum.Data.cs")]
		internal static class ShaderDefs // TypeDefIndex: 5755
		{
			// Fields
			public const int GroupSize = 128; // Metadata: 0x00661A98
			public const int ArgsBufferStride = 16; // Metadata: 0x00661A9A
			public const int ArgsBufferUpper = 0; // Metadata: 0x00661A9B
			public const int ArgsBufferLower = 8; // Metadata: 0x00661A9C
	
			// Methods
			public static int DivUpGroup(int value); // 0x0000000181E58830-0x0000000181E58840
			public static int AlignUpGroup(int value); // 0x0000000181EB9440-0x0000000181EB9450
			public static void CalculateTotalBufferSize(int maxElementCount, out int totalSize, out int levelCounts); // 0x0000000181EB9450-0x0000000181EB9490
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\Utilities\\GPUPrefixSum\\GPUPrefixSum.Data.cs")]
		public struct LevelOffsets // TypeDefIndex: 5756
		{
			// Fields
			public uint count; // 0x00
			public uint offset; // 0x04
			public uint parentOffset; // 0x08
		}
	
		public struct RenderGraphResources // TypeDefIndex: 5757
		{
			// Fields
			internal int alignedElementCount; // 0x00
			internal int maxBufferCount; // 0x04
			internal int maxLevelCount; // 0x08
			internal BufferHandle prefixBuffer0; // 0x0C
			internal BufferHandle prefixBuffer1; // 0x18
			internal BufferHandle totalLevelCountBuffer; // 0x24
			internal BufferHandle levelOffsetBuffer; // 0x30
			internal BufferHandle indirectDispatchArgsBuffer; // 0x3C
	
			// Properties
			public BufferHandle output { get; } // 0x0000000181EB8370-0x0000000181EB8390 
	
			// Methods
			[Obsolete("This Create signature is deprecated and will be removed in the future. Please use Create(IBaseRenderGraphBuilder) instead. #from(6000.5)", true)]
			public static RenderGraphResources Create(int newMaxElementCount, RenderGraph renderGraph, RenderGraphBuilder builder, bool outputIsTemp = false /* Metadata: 0x00661A9D */); // 0x0000000180CC8D60-0x0000000180CC8D80
			public static RenderGraphResources Create(int newMaxElementCount, RenderGraph renderGraph, IBaseRenderGraphBuilder builder, bool outputIsTemp = false /* Metadata: 0x00661A9E */); // 0x0000000181EB7CE0-0x0000000181EB7D20
			private void Initialize(int newMaxElementCount, RenderGraph renderGraph, IBaseRenderGraphBuilder builder, bool outputIsTemp = false /* Metadata: 0x00661A9F */); // 0x0000000181EB7D20-0x0000000181EB8370
		}
	
		public struct SupportResources // TypeDefIndex: 5758
		{
			// Fields
			internal bool ownsResources; // 0x00
			internal int alignedElementCount; // 0x04
			internal int maxBufferCount; // 0x08
			internal int maxLevelCount; // 0x0C
			internal GraphicsBuffer prefixBuffer0; // 0x10
			internal GraphicsBuffer prefixBuffer1; // 0x18
			internal GraphicsBuffer totalLevelCountBuffer; // 0x20
			internal GraphicsBuffer levelOffsetBuffer; // 0x28
			internal GraphicsBuffer indirectDispatchArgsBuffer; // 0x30
	
			// Properties
			public GraphicsBuffer output { get; } // 0x0000000180377550-0x0000000180377560 
	
			// Methods
			public static SupportResources Create(int maxElementCount); // 0x0000000181EB9840-0x0000000181EB9890
			public static SupportResources Load(RenderGraphResources shaderGraphResources); // 0x0000000181EB9BB0-0x0000000181EB9E20
			internal void Resize(int newMaxElementCount); // 0x0000000181EB9F00-0x0000000181EBA1E0
			private void LoadFromShaderGraph(RenderGraphResources shaderGraphResources); // 0x0000000181EB9970-0x0000000181EB9BB0
			public void Dispose(); // 0x0000000181EB9890-0x0000000181EB9910
			[CompilerGenerated]
			internal static void _Dispose_g__TryFreeBuffer_15_0(GraphicsBuffer resource); // 0x0000000181EB0730-0x0000000181EB0740
		}
	
		public struct DirectArgs // TypeDefIndex: 5759
		{
			// Fields
			public bool exclusive; // 0x00
			public int inputCount; // 0x04
			public GraphicsBuffer input; // 0x08
			public SupportResources supportResources; // 0x10
		}
	
		public struct IndirectDirectArgs // TypeDefIndex: 5760
		{
			// Fields
			public bool exclusive; // 0x00
			public int inputCountBufferByteOffset; // 0x04
			public ComputeBuffer inputCountBuffer; // 0x08
			public GraphicsBuffer input; // 0x10
			public SupportResources supportResources; // 0x18
		}
	
		public struct SystemResources // TypeDefIndex: 5761
		{
			// Fields
			public ComputeShader computeAsset; // 0x00
			internal int kernelCalculateLevelDispatchArgsFromConst; // 0x08
			internal int kernelCalculateLevelDispatchArgsFromBuffer; // 0x0C
			internal int kernelPrefixSumOnGroup; // 0x10
			internal int kernelPrefixSumOnGroupExclusive; // 0x14
			internal int kernelPrefixSumNextInput; // 0x18
			internal int kernelPrefixSumResolveParent; // 0x1C
			internal int kernelPrefixSumResolveParentExclusive; // 0x20
	
			// Methods
			internal void LoadKernels(); // 0x0000000181EBA1E0-0x0000000181EBA360
		}
	
		private static class ShaderIDs // TypeDefIndex: 5762
		{
			// Fields
			public static readonly int _InputBuffer; // 0x00
			public static readonly int _OutputBuffer; // 0x04
			public static readonly int _InputCountBuffer; // 0x08
			public static readonly int _TotalLevelsBuffer; // 0x0C
			public static readonly int _OutputTotalLevelsBuffer; // 0x10
			public static readonly int _OutputDispatchLevelArgsBuffer; // 0x14
			public static readonly int _LevelsOffsetsBuffer; // 0x18
			public static readonly int _OutputLevelsOffsetsBuffer; // 0x1C
			public static readonly int _PrefixSumIntArgs; // 0x20
	
			// Constructors
			static ShaderIDs(); // 0x0000000181EB9490-0x0000000181EB9640
		}
	
		// Constructors
		public GPUPrefixSum(SystemResources resources); // 0x0000000181EB5410-0x0000000181EB55B0
	
		// Methods
		private Vector4 PackPrefixSumArgs(int a, int b, int c, int d); // 0x0000000181EB53E0-0x0000000181EB5410
		internal void ExecuteCommonIndirect(CommandBuffer cmdBuffer, GraphicsBuffer inputBuffer, [IsReadOnly] in SupportResources supportResources, bool isExclusive); // 0x0000000181EB4EC0-0x0000000181EB53E0
		public void DispatchDirect(IComputeCommandBuffer cmdBuffer, [IsReadOnly] in DirectArgs arguments); // 0x0000000181EB4850-0x0000000181EB48E0
		public void DispatchDirect(CommandBuffer cmdBuffer, [IsReadOnly] in DirectArgs arguments); // 0x0000000181EB48E0-0x0000000181EB4B90
		public void DispatchIndirect(IComputeCommandBuffer cmdBuffer, [IsReadOnly] in IndirectDirectArgs arguments); // 0x0000000181EB4E30-0x0000000181EB4EC0
		public void DispatchIndirect(CommandBuffer cmdBuffer, [IsReadOnly] in IndirectDirectArgs arguments); // 0x0000000181EB4B90-0x0000000181EB4E30
	}
}
