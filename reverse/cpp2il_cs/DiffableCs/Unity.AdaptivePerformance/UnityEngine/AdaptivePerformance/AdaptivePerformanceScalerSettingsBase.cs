namespace UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceScalerSettingsBase
{
	[SerializeField]
	[Tooltip("Name of the scaler.")]
	private string m_Name; //Field offset: 0x10
	[SerializeField]
	[Tooltip("Active")]
	private bool m_Enabled; //Field offset: 0x18
	[SerializeField]
	[Tooltip("Scale to control the quality impact for the scaler. No quality change when 1, improved quality when >1, and lowered quality when <1.")]
	private float m_Scale; //Field offset: 0x1C
	[SerializeField]
	[Tooltip("Visual impact the scaler has on the application. The higher the value, the more impact the scaler has on the visuals.")]
	private ScalerVisualImpact m_VisualImpact; //Field offset: 0x20
	[SerializeField]
	[Tooltip("Application bottleneck that the scaler targets. The target selected has the most impact on the quality control of this scaler.")]
	private ScalerTarget m_Target; //Field offset: 0x24
	[SerializeField]
	[Tooltip("Maximum level for the scaler. This is tied to the implementation of the scaler to divide the levels into concrete steps.")]
	private int m_MaxLevel; //Field offset: 0x28
	[SerializeField]
	[Tooltip("Minimum value for the scale boundary.")]
	private float m_MinBound; //Field offset: 0x2C
	[SerializeField]
	[Tooltip("Maximum value for the scale boundary.")]
	private float m_MaxBound; //Field offset: 0x30

	public bool enabled
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public float maxBound
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public int maxLevel
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public float minBound
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public string name
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public float scale
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public ScalerTarget target
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public ScalerVisualImpact visualImpact
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public AdaptivePerformanceScalerSettingsBase() { }

	public bool get_enabled() { }

	public float get_maxBound() { }

	public int get_maxLevel() { }

	public float get_minBound() { }

	public string get_name() { }

	public float get_scale() { }

	public ScalerTarget get_target() { }

	public ScalerVisualImpact get_visualImpact() { }

	public void set_enabled(bool value) { }

	public void set_maxBound(float value) { }

	public void set_maxLevel(int value) { }

	public void set_minBound(float value) { }

	public void set_name(string value) { }

	public void set_scale(float value) { }

	public void set_target(ScalerTarget value) { }

	public void set_visualImpact(ScalerVisualImpact value) { }

}

