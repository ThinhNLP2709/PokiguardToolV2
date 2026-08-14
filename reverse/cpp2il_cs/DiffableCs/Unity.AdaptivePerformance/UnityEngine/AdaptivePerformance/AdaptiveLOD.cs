namespace UnityEngine.AdaptivePerformance;

public class AdaptiveLOD : AdaptivePerformanceScaler
{
	private float m_DefaultLodBias; //Field offset: 0x50

	public AdaptiveLOD() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

