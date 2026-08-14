namespace UnityEngine.InputSystem.Controls;

public class Vector3Control : InputControl<Vector3>
{
	[CompilerGenerated]
	private AxisControl <x>k__BackingField; //Field offset: 0x118
	[CompilerGenerated]
	private AxisControl <y>k__BackingField; //Field offset: 0x120
	[CompilerGenerated]
	private AxisControl <z>k__BackingField; //Field offset: 0x128

	[InputControl(offset = 0, displayName = "X")]
	public AxisControl x
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 4, displayName = "Y")]
	public AxisControl y
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 8, displayName = "Z")]
	public AxisControl z
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector3Control() { }

	protected virtual FourCC CalculateOptimizedControlDataType() { }

	public virtual float EvaluateMagnitude(Void* statePtr) { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_x() { }

	[CompilerGenerated]
	public AxisControl get_y() { }

	[CompilerGenerated]
	public AxisControl get_z() { }

	public virtual Vector3 ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_x(AxisControl value) { }

	[CompilerGenerated]
	public void set_y(AxisControl value) { }

	[CompilerGenerated]
	public void set_z(AxisControl value) { }

	public virtual void WriteValueIntoState(Vector3 value, Void* statePtr) { }

}

