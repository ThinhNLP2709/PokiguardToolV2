namespace UnityEngine.Rendering;

public struct GPUPrefixSum
{
	internal struct DirectArgs
	{
		public bool exclusive; //Field offset: 0x0
		public int inputCount; //Field offset: 0x4
		public GraphicsBuffer input; //Field offset: 0x8
		public SupportResources supportResources; //Field offset: 0x10

	}

	internal struct IndirectDirectArgs
	{
		public bool exclusive; //Field offset: 0x0
		public int inputCountBufferByteOffset; //Field offset: 0x4
		public ComputeBuffer inputCountBuffer; //Field offset: 0x8
		public GraphicsBuffer input; //Field offset: 0x10
		public SupportResources supportResources; //Field offset: 0x18

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\Utilities\\GPUPrefixSum\\GPUPrefixSum.Data.cs")]
	internal struct LevelOffsets
	{
		public uint count; //Field offset: 0x0
		public uint offset; //Field offset: 0x4
		public uint parentOffset; //Field offset: 0x8

	}

	internal struct RenderGraphResources
	{
		internal int alignedElementCount; //Field offset: 0x0
		internal int maxBufferCount; //Field offset: 0x4
		internal int maxLevelCount; //Field offset: 0x8
		internal BufferHandle prefixBuffer0; //Field offset: 0xC
		internal BufferHandle prefixBuffer1; //Field offset: 0x18
		internal BufferHandle totalLevelCountBuffer; //Field offset: 0x24
		internal BufferHandle levelOffsetBuffer; //Field offset: 0x30
		internal BufferHandle indirectDispatchArgsBuffer; //Field offset: 0x3C

		public BufferHandle output
		{
			 get { } //Length: 19
		}

		public static RenderGraphResources Create(int newMaxElementCount, RenderGraph renderGraph, RenderGraphBuilder builder, bool outputIsTemp = false) { }

		public BufferHandle get_output() { }

		private void Initialize(int newMaxElementCount, RenderGraph renderGraph, RenderGraphBuilder builder, bool outputIsTemp = false) { }

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\Utilities\\GPUPrefixSum\\GPUPrefixSum.Data.cs")]
	public static class ShaderDefs
	{
		public const int GroupSize = 128; //Field offset: 0x0
		public const int ArgsBufferStride = 16; //Field offset: 0x0
		public const int ArgsBufferUpper = 0; //Field offset: 0x0
		public const int ArgsBufferLower = 8; //Field offset: 0x0

		public static int AlignUpGroup(int value) { }

		public static void CalculateTotalBufferSize(int maxElementCount, out int totalSize, out int levelCounts) { }

		public static int DivUpGroup(int value) { }

	}

	private static class ShaderIDs
	{
		public static readonly int _InputBuffer; //Field offset: 0x0
		public static readonly int _OutputBuffer; //Field offset: 0x4
		public static readonly int _InputCountBuffer; //Field offset: 0x8
		public static readonly int _TotalLevelsBuffer; //Field offset: 0xC
		public static readonly int _OutputTotalLevelsBuffer; //Field offset: 0x10
		public static readonly int _OutputDispatchLevelArgsBuffer; //Field offset: 0x14
		public static readonly int _LevelsOffsetsBuffer; //Field offset: 0x18
		public static readonly int _OutputLevelsOffsetsBuffer; //Field offset: 0x1C
		public static readonly int _PrefixSumIntArgs; //Field offset: 0x20

		private static ShaderIDs() { }

	}

	internal struct SupportResources
	{
		internal bool ownsResources; //Field offset: 0x0
		internal int alignedElementCount; //Field offset: 0x4
		internal int maxBufferCount; //Field offset: 0x8
		internal int maxLevelCount; //Field offset: 0xC
		internal GraphicsBuffer prefixBuffer0; //Field offset: 0x10
		internal GraphicsBuffer prefixBuffer1; //Field offset: 0x18
		internal GraphicsBuffer totalLevelCountBuffer; //Field offset: 0x20
		internal GraphicsBuffer levelOffsetBuffer; //Field offset: 0x28
		internal GraphicsBuffer indirectDispatchArgsBuffer; //Field offset: 0x30

		public GraphicsBuffer output
		{
			 get { } //Length: 5
		}

		[CompilerGenerated]
		internal static void <Dispose>g__TryFreeBuffer|15_0(GraphicsBuffer resource) { }

		public static SupportResources Create(int maxElementCount) { }

		public void Dispose() { }

		public GraphicsBuffer get_output() { }

		public static SupportResources Load(RenderGraphResources shaderGraphResources) { }

		private void LoadFromShaderGraph(RenderGraphResources shaderGraphResources) { }

		internal void Resize(int newMaxElementCount) { }

	}

	internal struct SystemResources
	{
		public ComputeShader computeAsset; //Field offset: 0x0
		internal int kernelCalculateLevelDispatchArgsFromConst; //Field offset: 0x8
		internal int kernelCalculateLevelDispatchArgsFromBuffer; //Field offset: 0xC
		internal int kernelPrefixSumOnGroup; //Field offset: 0x10
		internal int kernelPrefixSumOnGroupExclusive; //Field offset: 0x14
		internal int kernelPrefixSumNextInput; //Field offset: 0x18
		internal int kernelPrefixSumResolveParent; //Field offset: 0x1C
		internal int kernelPrefixSumResolveParentExclusive; //Field offset: 0x20

		internal void LoadKernels() { }

	}

	private SystemResources resources; //Field offset: 0x0

	public GPUPrefixSum(SystemResources resources) { }

	public void DispatchDirect(CommandBuffer cmdBuffer, in DirectArgs arguments) { }

	public void DispatchIndirect(CommandBuffer cmdBuffer, in IndirectDirectArgs arguments) { }

	internal void ExecuteCommonIndirect(CommandBuffer cmdBuffer, GraphicsBuffer inputBuffer, in SupportResources supportResources, bool isExclusive) { }

	private Vector4 PackPrefixSumArgs(int a, int b, int c, int d) { }

}

