namespace UnityEngine.InputSystem.XR;

[InputControlLayout(isGenericTypeOfDevice = True, displayName = "XR HMD", canRunInBackground = True)]
public class XRHMD : TrackedDevice
{
	[CompilerGenerated]
	private Vector3Control <leftEyePosition>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private QuaternionControl <leftEyeRotation>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private Vector3Control <rightEyePosition>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private QuaternionControl <rightEyeRotation>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private Vector3Control <centerEyePosition>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private QuaternionControl <centerEyeRotation>k__BackingField; //Field offset: 0x1D8

	[InputControl(noisy = True)]
	public Vector3Control centerEyePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public QuaternionControl centerEyeRotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control leftEyePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public QuaternionControl leftEyeRotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control rightEyePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public QuaternionControl rightEyeRotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public XRHMD() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_centerEyePosition() { }

	[CompilerGenerated]
	public QuaternionControl get_centerEyeRotation() { }

	[CompilerGenerated]
	public Vector3Control get_leftEyePosition() { }

	[CompilerGenerated]
	public QuaternionControl get_leftEyeRotation() { }

	[CompilerGenerated]
	public Vector3Control get_rightEyePosition() { }

	[CompilerGenerated]
	public QuaternionControl get_rightEyeRotation() { }

	[CompilerGenerated]
	protected void set_centerEyePosition(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_centerEyeRotation(QuaternionControl value) { }

	[CompilerGenerated]
	protected void set_leftEyePosition(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_leftEyeRotation(QuaternionControl value) { }

	[CompilerGenerated]
	protected void set_rightEyePosition(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_rightEyeRotation(QuaternionControl value) { }

}

