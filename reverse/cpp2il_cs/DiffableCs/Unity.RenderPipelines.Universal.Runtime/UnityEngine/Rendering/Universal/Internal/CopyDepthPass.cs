namespace UnityEngine.Rendering.Universal.Internal;

public class CopyDepthPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__38_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__38_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle source; //Field offset: 0x10
		internal UniversalCameraData cameraData; //Field offset: 0x20
		internal Material copyDepthMaterial; //Field offset: 0x28
		internal int msaaSamples; //Field offset: 0x30
		internal bool copyResolvedDepth; //Field offset: 0x34
		internal bool copyToDepth; //Field offset: 0x35
		internal bool isDstBackbuffer; //Field offset: 0x36

		public PassData() { }

	}

	private static class ShaderConstants
	{
		public static readonly int _CameraDepthAttachment; //Field offset: 0x0
		public static readonly int _CameraDepthTexture; //Field offset: 0x4
		public static readonly int _ZWriteShaderHandle; //Field offset: 0x8

		private static ShaderConstants() { }

	}

	[CompilerGenerated]
	private RTHandle <source>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private RTHandle <destination>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private int <MssaSamples>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private bool <CopyToDepth>k__BackingField; //Field offset: 0xCC
	[CompilerGenerated]
	private bool <CopyToDepthXR>k__BackingField; //Field offset: 0xCD
	[CompilerGenerated]
	private bool <CopyToBackbuffer>k__BackingField; //Field offset: 0xCE
	private Material m_CopyDepthMaterial; //Field offset: 0xD0
	internal bool m_CopyResolvedDepth; //Field offset: 0xD8
	internal bool m_ShouldClear; //Field offset: 0xD9
	private PassData m_PassData; //Field offset: 0xE0

	internal bool CopyToBackbuffer
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool CopyToDepth
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool CopyToDepthXR
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private RTHandle destination
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal int MssaSamples
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private RTHandle source
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public CopyDepthPass(RenderPassEvent evt, Shader copyDepthShader, bool shouldClear = false, bool copyToDepth = false, bool copyResolvedDepth = false, string customPassName = null) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RTHandle source) { }

	[CompilerGenerated]
	internal bool get_CopyToBackbuffer() { }

	[CompilerGenerated]
	internal bool get_CopyToDepth() { }

	[CompilerGenerated]
	internal bool get_CopyToDepthXR() { }

	[CompilerGenerated]
	private RTHandle get_destination() { }

	[CompilerGenerated]
	internal int get_MssaSamples() { }

	[CompilerGenerated]
	private RTHandle get_source() { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	public void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle destination, TextureHandle source, bool bindAsCameraDepth = false, string passName = "Copy Depth") { }

	public void Render(RenderGraph renderGraph, TextureHandle destination, TextureHandle source, UniversalResourceData resourceData, UniversalCameraData cameraData, bool bindAsCameraDepth = false, string passName = "Copy Depth") { }

	[CompilerGenerated]
	internal void set_CopyToBackbuffer(bool value) { }

	[CompilerGenerated]
	internal void set_CopyToDepth(bool value) { }

	[CompilerGenerated]
	internal void set_CopyToDepthXR(bool value) { }

	[CompilerGenerated]
	private void set_destination(RTHandle value) { }

	[CompilerGenerated]
	internal void set_MssaSamples(int value) { }

	[CompilerGenerated]
	private void set_source(RTHandle value) { }

	public void Setup(RTHandle source, RTHandle destination) { }

}

