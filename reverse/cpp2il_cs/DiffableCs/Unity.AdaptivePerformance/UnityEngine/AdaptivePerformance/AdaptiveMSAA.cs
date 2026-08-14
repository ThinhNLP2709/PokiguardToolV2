namespace UnityEngine.AdaptivePerformance;

public class AdaptiveMSAA : AdaptivePerformanceScaler
{
	private int m_DefaultAA; //Field offset: 0x50

	public AdaptiveMSAA() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

