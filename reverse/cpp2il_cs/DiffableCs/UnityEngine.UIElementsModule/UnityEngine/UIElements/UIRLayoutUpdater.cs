namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class UIRLayoutUpdater : BaseVisualTreeUpdater
{
	private static readonly string s_Description; //Field offset: 0x0
	private static readonly ProfilerMarker s_ProfilerMarker; //Field offset: 0x8
	private static readonly ProfilerMarker k_ComputeLayoutMarker; //Field offset: 0x10
	private static readonly ProfilerMarker k_UpdateSubTreeMarker; //Field offset: 0x18
	private static readonly ProfilerMarker k_DispatchChangeEventsMarker; //Field offset: 0x20
	private List<ValueTuple`3<Rect, Rect, VisualElement>> changeEventsList; //Field offset: 0x28

	public virtual ProfilerMarker profilerMarker
	{
		 get { } //Length: 79
	}

	private static UIRLayoutUpdater() { }

	public UIRLayoutUpdater() { }

	private void DispatchChangeEvents(List<ValueTuple`3<Rect, Rect, VisualElement>> changeEvents, int currentLayoutPass) { }

	public virtual ProfilerMarker get_profilerMarker() { }

	public virtual void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType) { }

	public virtual void Update() { }

	private static bool UpdateHierarchyDisplayed(VisualElement ve, List<ValueTuple`3<Rect, Rect, VisualElement>> changeEvents, bool inheritedDisplayed = true) { }

	private void UpdateSubTree(VisualElement ve, List<ValueTuple`3<Rect, Rect, VisualElement>> changeEvents) { }

}

