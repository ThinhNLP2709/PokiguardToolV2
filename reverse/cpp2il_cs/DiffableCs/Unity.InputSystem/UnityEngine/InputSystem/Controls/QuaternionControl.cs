namespace UnityEngine.InputSystem.Controls;

public class QuaternionControl : InputControl<Quaternion>
{
	[CompilerGenerated]
	private AxisControl <x>k__BackingField; //Field offset: 0x120
	[CompilerGenerated]
	private AxisControl <y>k__BackingField; //Field offset: 0x128
	[CompilerGenerated]
	private AxisControl <z>k__BackingField; //Field offset: 0x130
	[CompilerGenerated]
	private AxisControl <w>k__BackingField; //Field offset: 0x138

	[InputControl(displayName = "W")]
	public AxisControl w
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(displayName = "X")]
	public AxisControl x
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(displayName = "Y")]
	public AxisControl y
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(displayName = "Z")]
	public AxisControl z
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public QuaternionControl() { }

	protected virtual FourCC CalculateOptimizedControlDataType() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_w() { }

	[CompilerGenerated]
	public AxisControl get_x() { }

	[CompilerGenerated]
	public AxisControl get_y() { }

	[CompilerGenerated]
	public AxisControl get_z() { }

	public virtual Quaternion ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_w(AxisControl value) { }

	[CompilerGenerated]
	public void set_x(AxisControl value) { }

	[CompilerGenerated]
	public void set_y(AxisControl value) { }

	[CompilerGenerated]
	public void set_z(AxisControl value) { }

	public virtual void WriteValueIntoState(Quaternion value, Void* statePtr) { }

}

