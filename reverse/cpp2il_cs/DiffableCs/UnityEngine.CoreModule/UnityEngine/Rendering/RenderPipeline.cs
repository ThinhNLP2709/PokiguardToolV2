namespace UnityEngine.Rendering;

public abstract class RenderPipeline
{
	internal class StandardRequest
	{
		public RenderTexture destination; //Field offset: 0x10
		public int mipLevel; //Field offset: 0x18
		public CubemapFace face; //Field offset: 0x1C
		public int slice; //Field offset: 0x20

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x10

	public override RenderPipelineGlobalSettings defaultSettings
	{
		 get { } //Length: 5
	}

	public private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	protected RenderPipeline() { }

	protected static void BeginCameraRendering(ScriptableRenderContext context, Camera camera) { }

	protected static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras) { }

	internal void Dispose() { }

	protected override void Dispose(bool disposing) { }

	protected static void EndCameraRendering(ScriptableRenderContext context, Camera camera) { }

	protected static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras) { }

	public override RenderPipelineGlobalSettings get_defaultSettings() { }

	[CompilerGenerated]
	public bool get_disposed() { }

	internal void InternalProcessRenderRequests(ScriptableRenderContext context, Camera camera, RequestData renderRequest) { }

	internal void InternalRender(ScriptableRenderContext context, List<Camera> cameras) { }

	protected private override bool IsRenderRequestSupported(Camera camera, RequestData data) { }

	protected override void ProcessRenderRequests(ScriptableRenderContext context, Camera camera, RequestData renderRequest) { }

	protected abstract void Render(ScriptableRenderContext context, Camera[] cameras) { }

	protected override void Render(ScriptableRenderContext context, List<Camera> cameras) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

}

