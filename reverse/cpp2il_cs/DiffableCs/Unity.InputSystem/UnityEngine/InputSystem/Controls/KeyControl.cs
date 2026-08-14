namespace UnityEngine.InputSystem.Controls;

public class KeyControl : ButtonControl
{
	[CompilerGenerated]
	private Key <keyCode>k__BackingField; //Field offset: 0x148
	private int m_ScanCode; //Field offset: 0x14C

	public Key keyCode
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public int scanCode
	{
		 get { } //Length: 28
	}

	public KeyControl() { }

	[CompilerGenerated]
	public Key get_keyCode() { }

	public int get_scanCode() { }

	protected virtual void RefreshConfiguration() { }

	[CompilerGenerated]
	public void set_keyCode(Key value) { }

}

