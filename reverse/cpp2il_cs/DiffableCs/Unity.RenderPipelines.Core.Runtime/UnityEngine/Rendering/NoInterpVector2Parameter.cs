namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class NoInterpVector2Parameter : VolumeParameter<Vector2>
{

	public NoInterpVector2Parameter(Vector2 value, bool overrideState = false) { }

}

