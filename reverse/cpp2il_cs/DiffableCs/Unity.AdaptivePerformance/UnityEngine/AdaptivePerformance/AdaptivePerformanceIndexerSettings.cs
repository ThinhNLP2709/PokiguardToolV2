namespace UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceIndexerSettings
{
	private const string m_FeatureName = "Indexer"; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Active")]
	private bool m_Active; //Field offset: 0x10
	[SerializeField]
	[Tooltip("Thermal Action Delay")]
	private float m_ThermalActionDelay; //Field offset: 0x14
	[SerializeField]
	[Tooltip("Performance Action Delay")]
	private float m_PerformanceActionDelay; //Field offset: 0x18

	public bool active
	{
		 get { } //Length: 5
		 set { } //Length: 9
	}

	public float performanceActionDelay
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public float thermalActionDelay
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public AdaptivePerformanceIndexerSettings() { }

	public bool get_active() { }

	public float get_performanceActionDelay() { }

	public float get_thermalActionDelay() { }

	public void set_active(bool value) { }

	public void set_performanceActionDelay(float value) { }

	public void set_thermalActionDelay(float value) { }

}

