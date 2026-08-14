namespace UnityEngine.Rendering.Universal.Internal;

public class CopyColorPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__23_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RenderInternal>b__23_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle source; //Field offset: 0x10
		internal TextureHandle destination; //Field offset: 0x20
		internal bool useProceduralBlit; //Field offset: 0x30
		internal Material samplingMaterial; //Field offset: 0x38
		internal Material copyColorMaterial; //Field offset: 0x40
		internal Downsampling downsamplingMethod; //Field offset: 0x48
		internal int sampleOffsetShaderHandle; //Field offset: 0x4C

		public PassData() { }

	}

	private int m_SampleOffsetShaderHandle; //Field offset: 0xB8
	private Material m_SamplingMaterial; //Field offset: 0xC0
	private Downsampling m_DownsamplingMethod; //Field offset: 0xC8
	private Material m_CopyColorMaterial; //Field offset: 0xD0
	[CompilerGenerated]
	private RTHandle <source>k__BackingField; //Field offset: 0xD8
	[CompilerGenerated]
	private RTHandle <destination>k__BackingField; //Field offset: 0xE0
	private PassData m_PassData; //Field offset: 0xE8

	private RTHandle destination
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	private RTHandle source
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public CopyColorPass(RenderPassEvent evt, Material samplingMaterial, Material copyColorMaterial = null, string customPassName = null) { }

	public static void ConfigureDescriptor(Downsampling downsamplingMethod, ref RenderTextureDescriptor descriptor, out FilterMode filterMode) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RTHandle source, bool useDrawProceduralBlit) { }

	[CompilerGenerated]
	private RTHandle get_destination() { }

	[CompilerGenerated]
	private RTHandle get_source() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	internal TextureHandle Render(RenderGraph renderGraph, ContextContainer frameData, out TextureHandle destination, in TextureHandle source, Downsampling downsampling) { }

	private void RenderInternal(RenderGraph renderGraph, in TextureHandle destination, in TextureHandle source, bool useProceduralBlit) { }

	internal void RenderToExistingTexture(RenderGraph renderGraph, ContextContainer frameData, in TextureHandle destination, in TextureHandle source, Downsampling downsampling = 0) { }

	[CompilerGenerated]
	private void set_destination(RTHandle value) { }

	[CompilerGenerated]
	private void set_source(RTHandle value) { }

	[Obsolete("Use RTHandles for source and destination.", True)]
	public void Setup(RenderTargetIdentifier source, RenderTargetHandle destination, Downsampling downsampling) { }

	public void Setup(RTHandle source, RTHandle destination, Downsampling downsampling) { }

}

