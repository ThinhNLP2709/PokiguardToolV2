namespace UnityEngine.AdaptivePerformance;

[RequireDerived]
public abstract class AdaptivePerformanceScaler : ScriptableObject
{
	private AdaptivePerformanceIndexer m_Indexer; //Field offset: 0x18
	[CompilerGenerated]
	private int <CurrentLevel>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private int <GpuImpact>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	private int <CpuImpact>k__BackingField; //Field offset: 0x28
	private int m_OverrideLevel; //Field offset: 0x2C
	private AdaptivePerformanceScalerSettingsBase m_defaultSetting; //Field offset: 0x30
	private AdaptivePerformanceScalerEvent m_ScalerEvent; //Field offset: 0x38
	protected IAdaptivePerformanceSettings m_Settings; //Field offset: 0x48

	public internal int CpuImpact
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public private int CurrentLevel
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public override bool Enabled
	{
		 get { } //Length: 27
		 set { } //Length: 31
	}

	public internal int GpuImpact
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public bool IsMaxLevel
	{
		 get { } //Length: 39
	}

	public override float MaxBound
	{
		 get { } //Length: 28
		 set { } //Length: 40
	}

	public override int MaxLevel
	{
		 get { } //Length: 26
		 set { } //Length: 31
	}

	public override float MinBound
	{
		 get { } //Length: 28
		 set { } //Length: 40
	}

	public override string Name
	{
		 get { } //Length: 27
		 set { } //Length: 82
	}

	public bool NotLeveled
	{
		 get { } //Length: 8
	}

	public int OverrideLevel
	{
		 get { } //Length: 4
		 set { } //Length: 194
	}

	public override float Scale
	{
		 get { } //Length: 28
		 set { } //Length: 40
	}

	public override ScalerTarget Target
	{
		 get { } //Length: 26
		 set { } //Length: 31
	}

	public override ScalerVisualImpact VisualImpact
	{
		 get { } //Length: 26
		 set { } //Length: 31
	}

	protected AdaptivePerformanceScaler() { }

	internal void Activate() { }

	public void ApplyDefaultSetting(AdaptivePerformanceScalerSettingsBase defaultSetting) { }

	protected override void Awake() { }

	public int CalculateCost() { }

	internal void Deactivate() { }

	internal void DecreaseLevel() { }

	[CompilerGenerated]
	public int get_CpuImpact() { }

	[CompilerGenerated]
	public int get_CurrentLevel() { }

	public override bool get_Enabled() { }

	[CompilerGenerated]
	public int get_GpuImpact() { }

	public bool get_IsMaxLevel() { }

	public override float get_MaxBound() { }

	public override int get_MaxLevel() { }

	public override float get_MinBound() { }

	public override string get_Name() { }

	public bool get_NotLeveled() { }

	public int get_OverrideLevel() { }

	public override float get_Scale() { }

	public override ScalerTarget get_Target() { }

	public override ScalerVisualImpact get_VisualImpact() { }

	internal void IncreaseLevel() { }

	private void OnDisable() { }

	protected override void OnDisabled() { }

	private void OnEnable() { }

	protected override void OnEnabled() { }

	protected override void OnLevel() { }

	protected override void OnLevelDecrease() { }

	protected override void OnLevelIncrease() { }

	protected bool ScaleChanged() { }

	[CompilerGenerated]
	internal void set_CpuImpact(int value) { }

	[CompilerGenerated]
	private void set_CurrentLevel(int value) { }

	public override void set_Enabled(bool value) { }

	[CompilerGenerated]
	internal void set_GpuImpact(int value) { }

	public override void set_MaxBound(float value) { }

	public override void set_MaxLevel(int value) { }

	public override void set_MinBound(float value) { }

	public override void set_Name(string value) { }

	public void set_OverrideLevel(int value) { }

	public override void set_Scale(float value) { }

	public override void set_Target(ScalerTarget value) { }

	public override void set_VisualImpact(ScalerVisualImpact value) { }

}

