namespace UnityEngine.InputSystem.Interactions;

public class MultiTapInteraction : IInputInteraction<Single>, IInputInteraction
{
	private enum TapPhase
	{
		None = 0,
		WaitingForNextRelease = 1,
		WaitingForNextPress = 2,
	}

	[Tooltip("The maximum time (in seconds) allowed to elapse between pressing and releasing a control for it to register as a tap.")]
	public float tapTime; //Field offset: 0x10
	[Tooltip("The maximum delay (in seconds) allowed between each tap. If this time is exceeded, the multi-tap is canceled.")]
	public float tapDelay; //Field offset: 0x14
	[Tooltip("How many taps need to be performed in succession. Two means double-tap, three means triple-tap, and so on.")]
	public int tapCount; //Field offset: 0x18
	public float pressPoint; //Field offset: 0x1C
	private TapPhase m_CurrentTapPhase; //Field offset: 0x20
	private int m_CurrentTapCount; //Field offset: 0x24
	private double m_CurrentTapStartTime; //Field offset: 0x28
	private double m_LastTapReleaseTime; //Field offset: 0x30

	private float pressPointOrDefault
	{
		private get { } //Length: 83
	}

	private float releasePointOrDefault
	{
		private get { } //Length: 118
	}

	internal float tapDelayOrDefault
	{
		internal get { } //Length: 108
	}

	private float tapTimeOrDefault
	{
		private get { } //Length: 108
	}

	public MultiTapInteraction() { }

	private float get_pressPointOrDefault() { }

	private float get_releasePointOrDefault() { }

	internal float get_tapDelayOrDefault() { }

	private float get_tapTimeOrDefault() { }

	public override void Process(ref InputInteractionContext context) { }

	public override void Reset() { }

}

