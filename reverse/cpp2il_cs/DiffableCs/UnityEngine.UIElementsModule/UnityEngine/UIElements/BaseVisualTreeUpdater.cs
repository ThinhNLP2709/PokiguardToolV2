namespace UnityEngine.UIElements;

internal abstract class BaseVisualTreeUpdater : IVisualTreeUpdater, IDisposable
{
	private long frameCount; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<BaseVisualElementPanel> panelChanged; //Field offset: 0x18
	private BaseVisualElementPanel m_Panel; //Field offset: 0x20

	public event Action<BaseVisualElementPanel> panelChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public override BaseVisualElementPanel panel
	{
		 get { } //Length: 7
		 set { } //Length: 68
	}

	public abstract ProfilerMarker profilerMarker
	{
		 get { } //Length: 0
	}

	private override long UnityEngine.UIElements.IVisualTreeUpdater.FrameCount
	{
		private get { } //Length: 7
		private set { } //Length: 5
	}

	public VisualElement visualTree
	{
		 get { } //Length: 42
	}

	protected BaseVisualTreeUpdater() { }

	[CompilerGenerated]
	public void add_panelChanged(Action<BaseVisualElementPanel> value) { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	public override BaseVisualElementPanel get_panel() { }

	public abstract ProfilerMarker get_profilerMarker() { }

	public VisualElement get_visualTree() { }

	public abstract void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType) { }

	[CompilerGenerated]
	public void remove_panelChanged(Action<BaseVisualElementPanel> value) { }

	public override void set_panel(BaseVisualElementPanel value) { }

	private override long UnityEngine.UIElements.IVisualTreeUpdater.get_FrameCount() { }

	private override void UnityEngine.UIElements.IVisualTreeUpdater.set_FrameCount(long value) { }

	public abstract void Update() { }

}

