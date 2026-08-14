namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class Vector4Parameter : VolumeParameter<Vector4>
{

	public Vector4Parameter(Vector4 value, bool overrideState = false) { }

	public virtual void Interp(Vector4 from, Vector4 to, float t) { }

}

