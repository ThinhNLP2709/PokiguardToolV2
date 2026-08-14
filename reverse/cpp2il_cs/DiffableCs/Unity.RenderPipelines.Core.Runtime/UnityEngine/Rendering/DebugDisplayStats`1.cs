namespace UnityEngine.Rendering;

public abstract class DebugDisplayStats
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public TProfileId samplerId; //Field offset: 0x0
		public ProfilingSampler sampler; //Field offset: 0x0
		public DebugProfilingType<TProfileId> type; //Field offset: 0x0
		public DebugDisplayStats<TProfileId> <>4__this; //Field offset: 0x0

		public <>c__DisplayClass19_0() { }

		internal object <BuildProfilingSamplerWidgetList>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_1
	{
		public TProfileId samplerId; //Field offset: 0x0
		public DebugDisplayStats<TProfileId> <>4__this; //Field offset: 0x0

		public <>c__DisplayClass19_1() { }

		internal bool <BuildProfilingSamplerWidgetList>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_2
	{
		public ProfilingSampler sampler; //Field offset: 0x0
		public <>c__DisplayClass19_1<TProfileId> CS$<>8__locals1; //Field offset: 0x0

		public <>c__DisplayClass19_2() { }

		internal Value <BuildProfilingSamplerWidgetList>b__3(DebugProfilingType<TProfileId> e) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Type type; //Field offset: 0x0
		public Func<MemberInfo, Boolean> <>9__0; //Field offset: 0x0

		public <>c__DisplayClass6_0() { }

		internal bool <GetProfilerIdsToDisplay>b__0(MemberInfo m) { }

	}

	private class AccumulatedTiming
	{
		public float accumulatedValue; //Field offset: 0x0
		public float lastAverage; //Field offset: 0x0

		public AccumulatedTiming() { }

		internal void UpdateLastAverage(int frameCount) { }

	}

	private enum DebugProfilingType
	{
		CPU = 0,
		InlineCPU = 1,
		GPU = 2,
	}

	private static readonly String[] k_DetailedStatsColumnLabels; //Field offset: 0x0
	private const float k_AccumulationTimeInSeconds = 1; //Field offset: 0x0
	private Dictionary<TProfileId, AccumulatedTiming<TProfileId>>[] m_AccumulatedTiming; //Field offset: 0x0
	private float m_TimeSinceLastAvgValue; //Field offset: 0x0
	private int m_AccumulatedFrames; //Field offset: 0x0
	private HashSet<TProfileId> m_HiddenProfileIds; //Field offset: 0x0
	protected bool averageProfilerTimingsOverASecond; //Field offset: 0x0
	protected bool hideEmptyScopes; //Field offset: 0x0

	private static DebugDisplayStats`1() { }

	protected DebugDisplayStats`1() { }

	[CompilerGenerated]
	private Value <BuildProfilingSamplerWidgetList>g__CreateWidgetForSampler|19_0(TProfileId samplerId, ProfilingSampler sampler, DebugProfilingType<TProfileId> type) { }

	protected Widget BuildDetailedStatsList(string title, List<TProfileId> samplers) { }

	private ObservableList<Widget> BuildProfilingSamplerWidgetList(IEnumerable<TProfileId> samplers) { }

	public abstract void DisableProfilingRecorders() { }

	public abstract void EnableProfilingRecorders() { }

	protected List<TProfileId> GetProfilerIdsToDisplay() { }

	private float GetSamplerTiming(TProfileId samplerId, ProfilingSampler sampler, DebugProfilingType<TProfileId> type) { }

	public abstract void RegisterDebugUI(List<Widget> list) { }

	public abstract void Update() { }

	protected void UpdateDetailedStats(List<TProfileId> samplers) { }

	private void UpdateListOfAveragedProfilerTimings(bool needUpdatingAverages, List<TProfileId> samplers) { }

}

