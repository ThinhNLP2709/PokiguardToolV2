namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal interface IVisualTreeUpdater : IDisposable
{

	public long FrameCount
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public BaseVisualElementPanel panel
	{
		 set { } //Length: 0
	}

	public ProfilerMarker profilerMarker
	{
		 get { } //Length: 0
	}

	public long get_FrameCount() { }

	public ProfilerMarker get_profilerMarker() { }

	public void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType) { }

	public void set_FrameCount(long value) { }

	public void set_panel(BaseVisualElementPanel value) { }

	public void Update() { }

}

