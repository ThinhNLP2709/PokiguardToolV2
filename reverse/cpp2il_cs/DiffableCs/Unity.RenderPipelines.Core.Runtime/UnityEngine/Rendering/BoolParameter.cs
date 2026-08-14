namespace UnityEngine.Rendering;

[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
public class BoolParameter : VolumeParameter<Boolean>
{
	internal enum DisplayType
	{
		Checkbox = 0,
		EnumPopup = 1,
	}

	public DisplayType displayType; //Field offset: 0x20

	public BoolParameter(bool value, bool overrideState = false) { }

	public BoolParameter(bool value, DisplayType displayType, bool overrideState = false) { }

}

