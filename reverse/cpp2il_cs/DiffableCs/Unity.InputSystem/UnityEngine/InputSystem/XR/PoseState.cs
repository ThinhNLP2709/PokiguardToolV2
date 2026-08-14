namespace UnityEngine.InputSystem.XR;

public struct PoseState : IInputStateTypeInfo
{
	internal const int kSizeInBytes = 60; //Field offset: 0x0
	internal static readonly FourCC s_Format; //Field offset: 0x0
	[InputControl(displayName = "Is Tracked", layout = "Button", sizeInBits = 8)]
	public bool isTracked; //Field offset: 0x0
	[InputControl(displayName = "Tracking State", layout = "Integer")]
	public InputTrackingState trackingState; //Field offset: 0x4
	[InputControl(displayName = "Position", noisy = True)]
	public Vector3 position; //Field offset: 0x8
	[InputControl(displayName = "Rotation", noisy = True)]
	public Quaternion rotation; //Field offset: 0x14
	[InputControl(displayName = "Velocity", noisy = True)]
	public Vector3 velocity; //Field offset: 0x24
	[InputControl(displayName = "Angular Velocity", noisy = True)]
	public Vector3 angularVelocity; //Field offset: 0x30

	public override FourCC format
	{
		 get { } //Length: 77
	}

	private static PoseState() { }

	public PoseState(bool isTracked, InputTrackingState trackingState, Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 angularVelocity) { }

	public override FourCC get_format() { }

}

