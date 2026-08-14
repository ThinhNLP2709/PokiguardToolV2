namespace UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceIndexer
{
	private const string m_FeatureName = "Indexer"; //Field offset: 0x0
	private List<AdaptivePerformanceScaler> m_UnappliedScalers; //Field offset: 0x10
	private List<AdaptivePerformanceScaler> m_AppliedScalers; //Field offset: 0x18
	private List<AdaptivePerformanceScaler> m_DisabledScalers; //Field offset: 0x20
	private ThermalStateTracker m_ThermalStateTracker; //Field offset: 0x28
	private PerformanceStateTracker m_PerformanceStateTracker; //Field offset: 0x30
	private AdaptivePerformanceScalerEfficiencyTracker m_ScalerEfficiencyTracker; //Field offset: 0x38
	private IAdaptivePerformanceSettings m_Settings; //Field offset: 0x40
	[CompilerGenerated]
	private float <TimeUntilNextAction>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private StateAction <ThermalAction>k__BackingField; //Field offset: 0x4C
	[CompilerGenerated]
	private StateAction <PerformanceAction>k__BackingField; //Field offset: 0x50

	public private StateAction PerformanceAction
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private StateAction ThermalAction
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private float TimeUntilNextAction
	{
		[CompilerGenerated]
		 get { } //Length: 6
		[CompilerGenerated]
		private set { } //Length: 6
	}

	internal AdaptivePerformanceIndexer(ref IAdaptivePerformanceSettings settings, PerformanceStateTracker tracker) { }

	private void ActivateEnabledScalers() { }

	internal void AddScaler(AdaptivePerformanceScaler scaler) { }

	private bool ApplyLowestCostScaler() { }

	private void ApplyScaler(AdaptivePerformanceScaler scaler) { }

	private void CollectProfilerStats() { }

	private void DeactivateDisabledScalers() { }

	protected override float DeltaTime() { }

	[CompilerGenerated]
	public StateAction get_PerformanceAction() { }

	[CompilerGenerated]
	public StateAction get_ThermalAction() { }

	[CompilerGenerated]
	public float get_TimeUntilNextAction() { }

	public void GetAllRegisteredScalers(ref List<AdaptivePerformanceScaler>& scalers) { }

	public void GetAppliedScalers(ref List<AdaptivePerformanceScaler>& scalers) { }

	public void GetDisabledScalers(ref List<AdaptivePerformanceScaler>& scalers) { }

	public void GetUnappliedScalers(ref List<AdaptivePerformanceScaler>& scalers) { }

	internal void RemoveScaler(AdaptivePerformanceScaler scaler) { }

	[CompilerGenerated]
	private void set_PerformanceAction(StateAction value) { }

	[CompilerGenerated]
	private void set_ThermalAction(StateAction value) { }

	[CompilerGenerated]
	private void set_TimeUntilNextAction(float value) { }

	public void UnapplyAllScalers() { }

	private bool UnapplyHighestCostScaler() { }

	private void UnapplyScaler(AdaptivePerformanceScaler scaler) { }

	internal void Update() { }

	internal void UpdateOverrideLevel(AdaptivePerformanceScaler scaler) { }

}

