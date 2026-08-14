namespace UnityEngine.InputSystem.XR.Haptics;

public struct BufferedRumble
{
	[CompilerGenerated]
	private HapticCapabilities <capabilities>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private InputDevice <device>k__BackingField; //Field offset: 0x18

	public private HapticCapabilities capabilities
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private InputDevice device
	{
		[CompilerGenerated]
		[IsReadOnly]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public BufferedRumble(InputDevice device) { }

	public void EnqueueRumble(Byte[] samples) { }

	[CompilerGenerated]
	[IsReadOnly]
	public HapticCapabilities get_capabilities() { }

	[CompilerGenerated]
	[IsReadOnly]
	private InputDevice get_device() { }

	[CompilerGenerated]
	private void set_capabilities(HapticCapabilities value) { }

	[CompilerGenerated]
	private void set_device(InputDevice value) { }

}

