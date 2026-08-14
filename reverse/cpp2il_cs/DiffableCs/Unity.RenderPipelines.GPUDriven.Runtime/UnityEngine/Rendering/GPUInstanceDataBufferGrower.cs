namespace UnityEngine.Rendering;

internal struct GPUInstanceDataBufferGrower : IDisposable
{
	private static class CopyInstancesKernelIDs
	{
		public static readonly int _InputValidComponentCounts; //Field offset: 0x0
		public static readonly int _InstanceCounts; //Field offset: 0x4
		public static readonly int _InstanceOffset; //Field offset: 0x8
		public static readonly int _OutputInstanceOffset; //Field offset: 0xC
		public static readonly int _ValidComponentIndices; //Field offset: 0x10
		public static readonly int _ComponentByteCounts; //Field offset: 0x14
		public static readonly int _InputComponentAddresses; //Field offset: 0x18
		public static readonly int _OutputComponentAddresses; //Field offset: 0x1C
		public static readonly int _InputComponentInstanceIndexRanges; //Field offset: 0x20
		public static readonly int _InputBuffer; //Field offset: 0x24
		public static readonly int _OutputBuffer; //Field offset: 0x28

		private static CopyInstancesKernelIDs() { }

	}

	internal struct GPUResources : IDisposable
	{
		public ComputeShader cs; //Field offset: 0x0
		public int kernelId; //Field offset: 0x8

		public void CreateResources() { }

		public override void Dispose() { }

		public void LoadShaders(GPUResidentDrawerResources resources) { }

	}

	private GPUInstanceDataBuffer m_SrcBuffer; //Field offset: 0x0
	private GPUInstanceDataBuffer m_DstBuffer; //Field offset: 0x8

	public GPUInstanceDataBufferGrower(GPUInstanceDataBuffer sourceBuffer, in InstanceNumInfo instanceNumInfo) { }

	public override void Dispose() { }

	public GPUInstanceDataBuffer SubmitToGpu(ref GPUResources gpuResources) { }

}

