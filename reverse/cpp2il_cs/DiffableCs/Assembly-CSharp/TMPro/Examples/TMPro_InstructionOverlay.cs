namespace TMPro.Examples;

public class TMPro_InstructionOverlay : MonoBehaviour
{
	internal enum FpsCounterAnchorPositions
	{
		TopLeft = 0,
		BottomLeft = 1,
		TopRight = 2,
		BottomRight = 3,
	}

	private const string instructions = "Camera Control - <#ffff00>Shift + RMB
</color>Zoom - <#ffff00>Mouse wheel."; //Field offset: 0x0
	public FpsCounterAnchorPositions AnchorPosition; //Field offset: 0x20
	private TextMeshPro m_TextMeshPro; //Field offset: 0x28
	private TextContainer m_textContainer; //Field offset: 0x30
	private Transform m_frameCounter_transform; //Field offset: 0x38
	private Camera m_camera; //Field offset: 0x40

	public TMPro_InstructionOverlay() { }

	private void Awake() { }

	private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position) { }

}

