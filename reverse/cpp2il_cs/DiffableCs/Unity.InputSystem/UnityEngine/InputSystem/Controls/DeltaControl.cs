namespace UnityEngine.InputSystem.Controls;

[Preserve]
public class DeltaControl : Vector2Control
{
	[CompilerGenerated]
	private AxisControl <up>k__BackingField; //Field offset: 0x120
	[CompilerGenerated]
	private AxisControl <down>k__BackingField; //Field offset: 0x128
	[CompilerGenerated]
	private AxisControl <left>k__BackingField; //Field offset: 0x130
	[CompilerGenerated]
	private AxisControl <right>k__BackingField; //Field offset: 0x138

	[InputControl(useStateFrom = "y", parameters = "clamp=1,clampMin=-3.402823E+38,clampMax=0,invert", synthetic = True, displayName = "Down")]
	[Preserve]
	public AxisControl down
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(useStateFrom = "x", parameters = "clamp=1,clampMin=-3.402823E+38,clampMax=0,invert", synthetic = True, displayName = "Left")]
	[Preserve]
	public AxisControl left
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(useStateFrom = "x", parameters = "clamp=1,clampMin=0,clampMax=3.402823E+38", synthetic = True, displayName = "Right")]
	[Preserve]
	public AxisControl right
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(useStateFrom = "y", parameters = "clamp=1,clampMin=0,clampMax=3.402823E+38", synthetic = True, displayName = "Up")]
	[Preserve]
	public AxisControl up
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public DeltaControl() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_down() { }

	[CompilerGenerated]
	public AxisControl get_left() { }

	[CompilerGenerated]
	public AxisControl get_right() { }

	[CompilerGenerated]
	public AxisControl get_up() { }

	[CompilerGenerated]
	public void set_down(AxisControl value) { }

	[CompilerGenerated]
	public void set_left(AxisControl value) { }

	[CompilerGenerated]
	public void set_right(AxisControl value) { }

	[CompilerGenerated]
	public void set_up(AxisControl value) { }

}

