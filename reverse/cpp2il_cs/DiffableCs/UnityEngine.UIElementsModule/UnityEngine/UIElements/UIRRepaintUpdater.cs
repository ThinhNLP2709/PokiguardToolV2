namespace UnityEngine.UIElements;

internal class UIRRepaintUpdater : BaseVisualTreeUpdater, IPanelRenderer
{
	private static readonly string s_Description; //Field offset: 0x0
	private static readonly ProfilerMarker s_ProfilerMarker; //Field offset: 0x8
	private BaseVisualElementPanel attachedPanel; //Field offset: 0x28
	internal RenderChain renderChain; //Field offset: 0x30
	private bool m_ForceGammaRendering; //Field offset: 0x38
	private uint m_VertexBudget; //Field offset: 0x3C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <drawStats>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <breakBatches>k__BackingField; //Field offset: 0x41
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x42

	public bool breakBatches
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	protected private bool disposed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public bool drawStats
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public override bool forceGammaRendering
	{
		 get { } //Length: 5
		 set { } //Length: 16
	}

	public virtual ProfilerMarker profilerMarker
	{
		 get { } //Length: 79
	}

	public override uint vertexBudget
	{
		 get { } //Length: 4
		 set { } //Length: 16
	}

	private static UIRRepaintUpdater() { }

	public UIRRepaintUpdater() { }

	private void AttachToPanel() { }

	protected override RenderChain CreateRenderChain() { }

	private void DestroyRenderChain() { }

	private void DetachFromPanel() { }

	protected virtual void Dispose(bool disposing) { }

	[CompilerGenerated]
	public bool get_breakBatches() { }

	[CompilerGenerated]
	protected bool get_disposed() { }

	[CompilerGenerated]
	public bool get_drawStats() { }

	public override bool get_forceGammaRendering() { }

	public virtual ProfilerMarker get_profilerMarker() { }

	public override uint get_vertexBudget() { }

	private void InitRenderChain() { }

	private static void OnGraphicsResourcesRecreate(bool recreate) { }

	private void OnPanelAtlasChanged() { }

	private void OnPanelChanged(BaseVisualElementPanel obj) { }

	private void OnPanelDrawsInCamerasChanged() { }

	private void OnPanelHierarchyChanged(VisualElement ve, HierarchyChangeType changeType) { }

	private void OnPanelIsFlatChanged() { }

	public virtual void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType) { }

	public override void Render() { }

	public override void Reset() { }

	private void ResetAllElementsDataRecursive(VisualElement ve) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

	public override void set_forceGammaRendering(bool value) { }

	public override void set_vertexBudget(uint value) { }

	public virtual void Update() { }

}

