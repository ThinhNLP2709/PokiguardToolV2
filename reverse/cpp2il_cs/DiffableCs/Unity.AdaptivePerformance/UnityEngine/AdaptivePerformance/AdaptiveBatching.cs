namespace UnityEngine.AdaptivePerformance;

public class AdaptiveBatching : AdaptivePerformanceScaler
{
	private bool m_DefaultState; //Field offset: 0x50

	public AdaptiveBatching() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

