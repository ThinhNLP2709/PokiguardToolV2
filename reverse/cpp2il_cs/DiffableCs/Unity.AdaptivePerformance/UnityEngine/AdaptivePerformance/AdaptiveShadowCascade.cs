namespace UnityEngine.AdaptivePerformance;

public class AdaptiveShadowCascade : AdaptivePerformanceScaler
{
	private int m_DefaultCascadeCount; //Field offset: 0x50

	public AdaptiveShadowCascade() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

