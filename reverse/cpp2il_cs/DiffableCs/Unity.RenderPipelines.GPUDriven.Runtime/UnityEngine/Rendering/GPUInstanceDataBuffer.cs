namespace UnityEngine.Rendering;

internal class GPUInstanceDataBuffer : IDisposable
{
	[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
	private struct ConvertCPUInstancesToGPUInstancesJob : IJobParallelFor
	{
		public const int k_BatchSize = 512; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<Int32> instancesNumPrefixSum; //Field offset: 0x0
		[ReadOnly]
		public NativeArray<InstanceHandle> instances; //Field offset: 0x10
		[WriteOnly]
		public NativeArray<GPUInstanceIndex> gpuInstanceIndices; //Field offset: 0x20

		public override void Execute(int index) { }

	}

	[IsReadOnly]
	public struct ReadOnly
	{
		private readonly NativeArray<Int32> instancesNumPrefixSum; //Field offset: 0x0

		public ReadOnly(GPUInstanceDataBuffer buffer) { }

		public void CPUInstanceArrayToGPUInstanceArray(NativeArray<InstanceHandle> instances, NativeArray<GPUInstanceIndex> gpuInstanceIndices) { }

		public GPUInstanceIndex CPUInstanceToGPUInstance(InstanceHandle instance) { }

	}

	private static int s_NextLayoutVersion; //Field offset: 0x0
	public InstanceNumInfo instanceNumInfo; //Field offset: 0x10
	public NativeArray<Int32> instancesNumPrefixSum; //Field offset: 0x18
	public NativeArray<Int32> instancesSpan; //Field offset: 0x28
	public int byteSize; //Field offset: 0x38
	public int perInstanceComponentCount; //Field offset: 0x3C
	public int version; //Field offset: 0x40
	public int layoutVersion; //Field offset: 0x44
	public GraphicsBuffer gpuBuffer; //Field offset: 0x48
	public GraphicsBuffer validComponentsIndicesGpuBuffer; //Field offset: 0x50
	public GraphicsBuffer componentAddressesGpuBuffer; //Field offset: 0x58
	public GraphicsBuffer componentInstanceIndexRangesGpuBuffer; //Field offset: 0x60
	public GraphicsBuffer componentByteCountsGpuBuffer; //Field offset: 0x68
	public NativeArray<GPUInstanceComponentDesc> descriptions; //Field offset: 0x70
	public NativeArray<MetadataValue> defaultMetadata; //Field offset: 0x80
	public NativeArray<Int32> gpuBufferComponentAddress; //Field offset: 0x90
	public NativeParallelHashMap<Int32, Int32> nameToMetadataMap; //Field offset: 0xA0

	public bool valid
	{
		 get { } //Length: 51
	}

	public GPUInstanceDataBuffer() { }

	public ReadOnly AsReadOnly() { }

	public void CPUInstanceArrayToGPUInstanceArray(NativeArray<InstanceHandle> instances, NativeArray<GPUInstanceIndex> gpuInstanceIndices) { }

	private static GPUInstanceIndex CPUInstanceToGPUInstance(in NativeArray<Int32>& instancesNumPrefixSum, InstanceHandle instance) { }

	public GPUInstanceIndex CPUInstanceToGPUInstance(InstanceHandle instance) { }

	public override void Dispose() { }

	public bool get_valid() { }

	public int GetGpuAddress(string strName, bool assertOnFail = true) { }

	public int GetGpuAddress(int propertyID, bool assertOnFail = true) { }

	public int GetPropertyIndex(int propertyID, bool assertOnFail = true) { }

	public InstanceHandle GPUInstanceToCPUInstance(GPUInstanceIndex gpuInstanceIndex) { }

	public static int NextVersion() { }

}

