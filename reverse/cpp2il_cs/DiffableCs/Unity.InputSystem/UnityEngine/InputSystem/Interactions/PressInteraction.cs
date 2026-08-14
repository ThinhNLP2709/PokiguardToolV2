namespace UnityEngine.InputSystem.Interactions;

[DisplayName("Press")]
public class PressInteraction : IInputInteraction
{
	[Tooltip("The amount of actuation a control requires before being considered pressed. If not set, default to 'Default Press Point' in the global input settings.")]
	public float pressPoint; //Field offset: 0x10
	[Tooltip("Determines how button presses trigger the action. By default (PressOnly), the action is performed on press. With ReleaseOnly, the action is performed on release. With PressAndRelease, the action is performed on press and release.")]
	public PressBehavior behavior; //Field offset: 0x14
	private bool m_WaitingForRelease; //Field offset: 0x18

	private float pressPointOrDefault
	{
		private get { } //Length: 83
	}

	private float releasePointOrDefault
	{
		private get { } //Length: 118
	}

	public PressInteraction() { }

	private float get_pressPointOrDefault() { }

	private float get_releasePointOrDefault() { }

	public override void Process(ref InputInteractionContext context) { }

	public override void Reset() { }

}

