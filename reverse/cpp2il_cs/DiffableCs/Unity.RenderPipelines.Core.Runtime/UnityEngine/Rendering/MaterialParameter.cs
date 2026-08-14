namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class MaterialParameter : VolumeParameter<Material>
{

	public MaterialParameter(Material value, bool overrideState = false) { }

}

