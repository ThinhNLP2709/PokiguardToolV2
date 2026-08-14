namespace UnityEngine.XR.WindowsMR.Input;

[InputControlLayout(displayName = "Windows MR Headset", hideInUI = True)]
public class WMRHMD : XRHMD
{
	[CompilerGenerated]
	private ButtonControl <userPresence>k__BackingField; //Field offset: 0x1E0

	[InputControl]
	[InputControl(name = "devicePosition", layout = "Vector3", aliases = new IL2CPP_TYPE_STRING[] {"HeadPosition"})]
	[InputControl(name = "deviceRotation", layout = "Quaternion", aliases = new IL2CPP_TYPE_STRING[] {"HeadRotation"})]
	public ButtonControl userPresence
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public WMRHMD() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_userPresence() { }

	[CompilerGenerated]
	protected void set_userPresence(ButtonControl value) { }

}

