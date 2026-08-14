namespace UnityEngine.InputSystem.XR;

public class EyesControl : InputControl<Eyes>
{
	[CompilerGenerated]
	private Vector3Control <leftEyePosition>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private QuaternionControl <leftEyeRotation>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private Vector3Control <rightEyePosition>k__BackingField; //Field offset: 0x1A8
	[CompilerGenerated]
	private QuaternionControl <rightEyeRotation>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private Vector3Control <fixationPoint>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private AxisControl <leftEyeOpenAmount>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private AxisControl <rightEyeOpenAmount>k__BackingField; //Field offset: 0x1C8

	[InputControl(offset = 56, displayName = "FixationPoint")]
	public Vector3Control fixationPoint
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 68, displayName = "LeftEyeOpenAmount")]
	public AxisControl leftEyeOpenAmount
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 0, displayName = "LeftEyePosition")]
	public Vector3Control leftEyePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 12, displayName = "LeftEyeRotation")]
	public QuaternionControl leftEyeRotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 72, displayName = "RightEyeOpenAmount")]
	public AxisControl rightEyeOpenAmount
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 28, displayName = "RightEyePosition")]
	public Vector3Control rightEyePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(offset = 40, displayName = "RightEyeRotation")]
	public QuaternionControl rightEyeRotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public EyesControl() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_fixationPoint() { }

	[CompilerGenerated]
	public AxisControl get_leftEyeOpenAmount() { }

	[CompilerGenerated]
	public Vector3Control get_leftEyePosition() { }

	[CompilerGenerated]
	public QuaternionControl get_leftEyeRotation() { }

	[CompilerGenerated]
	public AxisControl get_rightEyeOpenAmount() { }

	[CompilerGenerated]
	public Vector3Control get_rightEyePosition() { }

	[CompilerGenerated]
	public QuaternionControl get_rightEyeRotation() { }

	public virtual Eyes ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_fixationPoint(Vector3Control value) { }

	[CompilerGenerated]
	public void set_leftEyeOpenAmount(AxisControl value) { }

	[CompilerGenerated]
	public void set_leftEyePosition(Vector3Control value) { }

	[CompilerGenerated]
	public void set_leftEyeRotation(QuaternionControl value) { }

	[CompilerGenerated]
	public void set_rightEyeOpenAmount(AxisControl value) { }

	[CompilerGenerated]
	public void set_rightEyePosition(Vector3Control value) { }

	[CompilerGenerated]
	public void set_rightEyeRotation(QuaternionControl value) { }

	public virtual void WriteValueIntoState(Eyes value, Void* statePtr) { }

}

