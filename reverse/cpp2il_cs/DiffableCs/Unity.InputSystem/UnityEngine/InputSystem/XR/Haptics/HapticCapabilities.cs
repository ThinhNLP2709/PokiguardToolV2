namespace UnityEngine.InputSystem.XR.Haptics;

public struct HapticCapabilities
{
	[CompilerGenerated]
	private readonly uint <numChannels>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly bool <supportsImpulse>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	private readonly bool <supportsBuffer>k__BackingField; //Field offset: 0x5
	[CompilerGenerated]
	private readonly uint <frequencyHz>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private readonly uint <maxBufferSize>k__BackingField; //Field offset: 0xC
	[CompilerGenerated]
	private readonly uint <optimalBufferSize>k__BackingField; //Field offset: 0x10

	public uint frequencyHz
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	public uint maxBufferSize
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	public uint numChannels
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
	}

	public uint optimalBufferSize
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
	}

	public bool supportsBuffer
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
	}

	public bool supportsImpulse
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
	}

	public HapticCapabilities(uint numChannels, bool supportsImpulse, bool supportsBuffer, uint frequencyHz, uint maxBufferSize, uint optimalBufferSize) { }

	public HapticCapabilities(uint numChannels, uint frequencyHz, uint maxBufferSize) { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_frequencyHz() { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_maxBufferSize() { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_numChannels() { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_optimalBufferSize() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_supportsBuffer() { }

	[CompilerGenerated]
	[IsReadOnly]
	public bool get_supportsImpulse() { }

}

