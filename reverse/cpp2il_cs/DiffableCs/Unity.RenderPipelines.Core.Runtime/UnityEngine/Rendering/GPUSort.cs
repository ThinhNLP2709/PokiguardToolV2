namespace UnityEngine.Rendering;

public struct GPUSort
{
	internal struct Args
	{
		public uint count; //Field offset: 0x0
		public uint maxDepth; //Field offset: 0x4
		public GraphicsBuffer inputKeys; //Field offset: 0x8
		public GraphicsBuffer inputValues; //Field offset: 0x10
		public SupportResources resources; //Field offset: 0x18
		internal int workGroupCount; //Field offset: 0x28

	}

	internal struct RenderGraphResources
	{
		public BufferHandle sortBufferKeys; //Field offset: 0x0
		public BufferHandle sortBufferValues; //Field offset: 0xC

		public static RenderGraphResources Create(int count, RenderGraph renderGraph, RenderGraphBuilder builder) { }

	}

	private enum Stage
	{
		LocalBMS = 0,
		LocalDisperse = 1,
		BigFlip = 2,
		BigDisperse = 3,
	}

	internal struct SupportResources
	{
		public GraphicsBuffer sortBufferKeys; //Field offset: 0x0
		public GraphicsBuffer sortBufferValues; //Field offset: 0x8

		public void Dispose() { }

		public static SupportResources Load(RenderGraphResources renderGraphResources) { }

	}

	internal struct SystemResources
	{
		public ComputeShader computeAsset; //Field offset: 0x0

	}

	private const uint kWorkGroupSize = 1024; //Field offset: 0x0
	private LocalKeyword[] m_Keywords; //Field offset: 0x0
	private SystemResources resources; //Field offset: 0x8

	public GPUSort(SystemResources resources) { }

	private void CopyBuffer(CommandBuffer cmd, GraphicsBuffer src, GraphicsBuffer dst) { }

	public void Dispatch(CommandBuffer cmd, Args args) { }

	private void DispatchStage(CommandBuffer cmd, Args args, uint h, Stage stage) { }

	internal static int DivRoundUp(int x, int y) { }

}

