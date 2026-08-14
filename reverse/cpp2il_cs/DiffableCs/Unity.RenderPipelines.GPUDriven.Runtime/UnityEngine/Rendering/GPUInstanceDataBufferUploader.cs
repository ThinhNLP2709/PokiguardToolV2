namespace UnityEngine.Rendering;

internal struct GPUInstanceDataBufferUploader : IDisposable
{
	internal struct GPUResources : IDisposable
	{
		public ComputeBuffer instanceData; //Field offset: 0x0
		public ComputeBuffer instanceIndices; //Field offset: 0x8
		public ComputeBuffer inputComponentOffsets; //Field offset: 0x10
		public ComputeBuffer validComponentIndices; //Field offset: 0x18
		public ComputeShader cs; //Field offset: 0x20
		public int kernelId; //Field offset: 0x28
		private int m_InstanceDataByteSize; //Field offset: 0x2C
		private int m_InstanceCount; //Field offset: 0x30
		private int m_ComponentCounts; //Field offset: 0x34
		private int m_ValidComponentIndicesCount; //Field offset: 0x38

		public void CreateResources(int newInstanceCount, int sizePerInstance, int newComponentCounts, int validComponentIndicesCount) { }

		public override void Dispose() { }

		public void LoadShaders(GPUResidentDrawerResources resources) { }

	}

	private static class UploadKernelIDs
	{
		public static readonly int _InputValidComponentCounts; //Field offset: 0x0
		public static readonly int _InputInstanceCounts; //Field offset: 0x4
		public static readonly int _InputInstanceByteSize; //Field offset: 0x8
		public static readonly int _InputComponentOffsets; //Field offset: 0xC
		public static readonly int _InputInstanceData; //Field offset: 0x10
		public static readonly int _InputInstanceIndices; //Field offset: 0x14
		public static readonly int _InputValidComponentIndices; //Field offset: 0x18
		public static readonly int _InputComponentAddresses; //Field offset: 0x1C
		public static readonly int _InputComponentByteCounts; //Field offset: 0x20
		public static readonly int _InputComponentInstanceIndexRanges; //Field offset: 0x24
		public static readonly int _OutputBuffer; //Field offset: 0x28

		private static UploadKernelIDs() { }

	}

	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	public struct WriteInstanceDataParameterJob : IJobParallelFor
	{
		public const int k_BatchSize = 512; //Field offset: 0x0
		[ReadOnly]
		public bool gatherData; //Field offset: 0x0
		[ReadOnly]
		public int parameterIndex; //Field offset: 0x4
		[ReadOnly]
		public int uintPerParameter; //Field offset: 0x8
		[ReadOnly]
		public int uintPerInstance; //Field offset: 0xC
		[ReadOnly]
		public NativeArray<Int32> componentDataIndex; //Field offset: 0x10
		[ReadOnly]
		public NativeArray<Int32> gatherIndices; //Field offset: 0x20
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeArray<UInt32> instanceData; //Field offset: 0x30
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<UInt32> tmpDataBuffer; //Field offset: 0x40

		public override void Execute(int index) { }

	}

	private int m_UintPerInstance; //Field offset: 0x0
	private int m_Capacity; //Field offset: 0x4
	private int m_InstanceCount; //Field offset: 0x8
	private NativeArray<Boolean> m_ComponentIsInstanced; //Field offset: 0x10
	private NativeArray<Int32> m_ComponentDataIndex; //Field offset: 0x20
	private NativeArray<Int32> m_DescriptionsUintSize; //Field offset: 0x30
	private NativeArray<UInt32> m_TmpDataBuffer; //Field offset: 0x40
	private NativeList<Int32> m_WritenComponentIndices; //Field offset: 0x50
	private NativeArray<Int32> m_DummyArray; //Field offset: 0x58

	public GPUInstanceDataBufferUploader(in NativeArray<GPUInstanceComponentDesc>& descriptions, int capacity, InstanceType instanceType) { }

	public void AllocateUploadHandles(int handlesLength) { }

	public override void Dispose() { }

	public int GetParamUIntOffset(int parameterIndex) { }

	public int GetUIntPerInstance() { }

	public IntPtr GetUploadBufferPtr() { }

	public int PrepareParamWrite(int parameterIndex) { }

	public void SubmitToGpu(GPUInstanceDataBuffer instanceDataBuffer, NativeArray<GPUInstanceIndex> gpuInstanceIndices, ref GPUResources gpuResources, bool submitOnlyWrittenParams) { }

	public void SubmitToGpu(GPUInstanceDataBuffer instanceDataBuffer, NativeArray<InstanceHandle> instances, ref GPUResources gpuResources, bool submitOnlyWrittenParams) { }

	public JobHandle WriteInstanceDataJob(int parameterIndex, NativeArray<T> instanceData) { }

	public JobHandle WriteInstanceDataJob(int parameterIndex, NativeArray<T> instanceData, NativeArray<Int32> gatherIndices) { }

}

