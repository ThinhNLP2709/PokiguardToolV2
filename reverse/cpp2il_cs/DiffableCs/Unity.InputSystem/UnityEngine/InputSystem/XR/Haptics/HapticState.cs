namespace UnityEngine.InputSystem.XR.Haptics;

public struct HapticState
{
	[CompilerGenerated]
	private uint <samplesQueued>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private uint <samplesAvailable>k__BackingField; //Field offset: 0x4

	public private uint samplesAvailable
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private uint samplesQueued
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		private set { } //Length: 3
	}

	public HapticState(uint samplesQueued, uint samplesAvailable) { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_samplesAvailable() { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_samplesQueued() { }

	[CompilerGenerated]
	private void set_samplesAvailable(uint value) { }

	[CompilerGenerated]
	private void set_samplesQueued(uint value) { }

}

