namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class LayerMaskParameter : VolumeParameter<LayerMask>
{

	public LayerMaskParameter(LayerMask value, bool overrideState = false) { }

}

