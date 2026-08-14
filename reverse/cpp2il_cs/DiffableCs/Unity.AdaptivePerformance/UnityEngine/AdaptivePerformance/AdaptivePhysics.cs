namespace UnityEngine.AdaptivePerformance;

public class AdaptivePhysics : AdaptivePerformanceScaler
{
	private float m_fixedDeltaTimeDefault; //Field offset: 0x50

	public AdaptivePhysics() { }

	protected virtual void Awake() { }

	protected virtual void OnDisabled() { }

	protected virtual void OnEnabled() { }

	protected virtual void OnLevel() { }

}

