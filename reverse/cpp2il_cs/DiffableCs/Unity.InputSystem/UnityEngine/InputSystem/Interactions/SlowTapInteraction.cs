namespace UnityEngine.InputSystem.Interactions;

[DisplayName("Long Tap")]
public class SlowTapInteraction : IInputInteraction
{
	public float duration; //Field offset: 0x10
	public float pressPoint; //Field offset: 0x14
	private double m_SlowTapStartTime; //Field offset: 0x18

	private float durationOrDefault
	{
		private get { } //Length: 108
	}

	private float pressPointOrDefault
	{
		private get { } //Length: 83
	}

	public SlowTapInteraction() { }

	private float get_durationOrDefault() { }

	private float get_pressPointOrDefault() { }

	public override void Process(ref InputInteractionContext context) { }

	public override void Reset() { }

}

