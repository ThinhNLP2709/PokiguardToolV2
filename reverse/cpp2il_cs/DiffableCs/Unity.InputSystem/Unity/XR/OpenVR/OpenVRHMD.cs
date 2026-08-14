namespace Unity.XR.OpenVR;

[InputControlLayout(displayName = "OpenVR Headset", hideInUI = True)]
public class OpenVRHMD : XRHMD
{
	[CompilerGenerated]
	private Vector3Control <deviceVelocity>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private Vector3Control <deviceAngularVelocity>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private Vector3Control <leftEyeVelocity>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private Vector3Control <leftEyeAngularVelocity>k__BackingField; //Field offset: 0x1F8
	[CompilerGenerated]
	private Vector3Control <rightEyeVelocity>k__BackingField; //Field offset: 0x200
	[CompilerGenerated]
	private Vector3Control <rightEyeAngularVelocity>k__BackingField; //Field offset: 0x208
	[CompilerGenerated]
	private Vector3Control <centerEyeVelocity>k__BackingField; //Field offset: 0x210
	[CompilerGenerated]
	private Vector3Control <centerEyeAngularVelocity>k__BackingField; //Field offset: 0x218

	[InputControl(noisy = True)]
	public Vector3Control centerEyeAngularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control centerEyeVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control deviceAngularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control deviceVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control leftEyeAngularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control leftEyeVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control rightEyeAngularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control rightEyeVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public OpenVRHMD() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_centerEyeAngularVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_centerEyeVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_deviceAngularVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_deviceVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_leftEyeAngularVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_leftEyeVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_rightEyeAngularVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_rightEyeVelocity() { }

	[CompilerGenerated]
	protected void set_centerEyeAngularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_centerEyeVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceAngularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_leftEyeAngularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_leftEyeVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_rightEyeAngularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_rightEyeVelocity(Vector3Control value) { }

}

