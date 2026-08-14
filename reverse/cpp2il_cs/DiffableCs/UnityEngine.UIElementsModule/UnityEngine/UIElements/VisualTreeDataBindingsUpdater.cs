namespace UnityEngine.UIElements;

internal class VisualTreeDataBindingsUpdater : BaseVisualTreeHierarchyTrackerUpdater
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<VisualElement> <>9__27_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <ProcessDataSourceChangedRequests>b__27_0(VisualElement e) { }

	}

	[IsReadOnly]
	private struct VersionInfo
	{
		public readonly object source; //Field offset: 0x0
		public readonly long version; //Field offset: 0x8

		public VersionInfo(object source, long version) { }

	}

	private static readonly ProfilerMarker s_UpdateProfilerMarker; //Field offset: 0x0
	private static readonly ProfilerMarker s_ProcessBindingRequestsProfilerMarker; //Field offset: 0x8
	private static readonly ProfilerMarker s_ProcessDataSourcesProfilerMarker; //Field offset: 0x10
	private static readonly ProfilerMarker s_ShouldUpdateBindingProfilerMarker; //Field offset: 0x18
	private static readonly ProfilerMarker s_UpdateBindingProfilerMarker; //Field offset: 0x20
	private readonly BindingUpdater m_Updater; //Field offset: 0x40
	private readonly List<VisualElement> m_BindingRegistrationRequests; //Field offset: 0x48
	private readonly HashSet<VisualElement> m_DataSourceChangedRequests; //Field offset: 0x50
	private readonly HashSet<VisualElement> m_RemovedElements; //Field offset: 0x58
	private readonly List<VisualElement> m_BoundsElement; //Field offset: 0x60
	private readonly List<VersionInfo> m_VersionChanges; //Field offset: 0x68
	private readonly HashSet<Object> m_TrackedObjects; //Field offset: 0x70
	private readonly HashSet<Binding> m_RanUpdate; //Field offset: 0x78
	private readonly HashSet<Object> m_KnownSources; //Field offset: 0x80
	private readonly HashSet<Binding> m_DirtyBindings; //Field offset: 0x88

	private DataBindingManager bindingManager
	{
		private get { } //Length: 48
	}

	public virtual ProfilerMarker profilerMarker
	{
		 get { } //Length: 522
	}

	private static VisualTreeDataBindingsUpdater() { }

	public VisualTreeDataBindingsUpdater() { }

	private void CacheAndLogBindingResult(bool appliedOnUiCache, in BindingData bindingData, in BindingResult result) { }

	protected virtual void Dispose(bool disposing) { }

	private DataBindingManager get_bindingManager() { }

	public virtual ProfilerMarker get_profilerMarker() { }

	private ValueTuple<Boolean, Int64> GetDataSourceVersion(object source) { }

	private bool IsPrefix(in PropertyPath prefix, in PropertyPath path) { }

	private void LogResult(in BindingResult result) { }

	protected virtual void OnHierarchyChange(VisualElement ve, HierarchyChangeType type) { }

	public virtual void OnVersionChanged(VisualElement ve, VersionChangeType versionChangeType) { }

	private void ProcessAllBindingRequests() { }

	private void ProcessBindingRequests(VisualElement element) { }

	private void ProcessDataSourceChangedRequests() { }

	private void ProcessPropertyChangedEvents(HashSet<Binding> ranUpdate) { }

	public virtual void Update() { }

}

