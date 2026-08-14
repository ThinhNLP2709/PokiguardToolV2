namespace UnityEngine.InputSystem.Controls;

public class StickControl : Vector2Control
{
	[CompilerGenerated]
	private ButtonControl <up>k__BackingField; //Field offset: 0x120
	[CompilerGenerated]
	private ButtonControl <down>k__BackingField; //Field offset: 0x128
	[CompilerGenerated]
	private ButtonControl <left>k__BackingField; //Field offset: 0x130
	[CompilerGenerated]
	private ButtonControl <right>k__BackingField; //Field offset: 0x138

	[InputControl(useStateFrom = "y", processors = "axisDeadzone", parameters = "clamp=2,clampMin=-1,clampMax=0,invert", synthetic = True, displayName = "Down")]
	public ButtonControl down
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(useStateFrom = "x", processors = "axisDeadzone", parameters = "clamp=2,clampMin=-1,clampMax=0,invert", synthetic = True, displayName = "Left")]
	public ButtonControl left
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(useStateFrom = "x", processors = "axisDeadzone", parameters = "clamp=2,clampMin=0,clampMax=1", synthetic = True, displayName = "Right")]
	public ButtonControl right
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(useStateFrom = "y", processors = "axisDeadzone", parameters = "clamp=2,clampMin=0,clampMax=1", synthetic = True, displayName = "Up")]
	[InputControl(name = "x", minValue = -1, maxValue = 1, layout = "Axis", processors = "axisDeadzone")]
	[InputControl(name = "y", minValue = -1, maxValue = 1, layout = "Axis", processors = "axisDeadzone")]
	public ButtonControl up
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public StickControl() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_down() { }

	[CompilerGenerated]
	public ButtonControl get_left() { }

	[CompilerGenerated]
	public ButtonControl get_right() { }

	[CompilerGenerated]
	public ButtonControl get_up() { }

	[CompilerGenerated]
	public void set_down(ButtonControl value) { }

	[CompilerGenerated]
	public void set_left(ButtonControl value) { }

	[CompilerGenerated]
	public void set_right(ButtonControl value) { }

	[CompilerGenerated]
	public void set_up(ButtonControl value) { }

}

