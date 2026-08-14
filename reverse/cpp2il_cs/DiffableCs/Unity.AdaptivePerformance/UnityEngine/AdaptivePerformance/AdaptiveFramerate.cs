namespace UnityEngine.AdaptivePerformance;

public class AdaptiveFramerate : AdaptivePerformanceScaler
{
	private int m_DefaultFPS; //Field offset: 0x50
	private int m_FirstTimeStart; //Field offset: 0x54

	public AdaptiveFramerate() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevelDecrease() { }

	protected virtual void OnLevelIncrease() { }

}

