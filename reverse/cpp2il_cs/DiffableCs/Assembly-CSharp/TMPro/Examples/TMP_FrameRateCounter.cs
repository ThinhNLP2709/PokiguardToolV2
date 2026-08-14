namespace TMPro.Examples;

public class TMP_FrameRateCounter : MonoBehaviour
{
	internal enum FpsCounterAnchorPositions
	{
		TopLeft = 0,
		BottomLeft = 1,
		TopRight = 2,
		BottomRight = 3,
	}

	private const string fpsLabel = "{0:2}</color> <#8080ff>FPS 
<#FF8000>{1:2} <#8080ff>MS"; //Field offset: 0x0
	public float UpdateInterval; //Field offset: 0x20
	private float m_LastInterval; //Field offset: 0x24
	private int m_Frames; //Field offset: 0x28
	public FpsCounterAnchorPositions AnchorPosition; //Field offset: 0x2C
	private string htmlColorTag; //Field offset: 0x30
	private TextMeshPro m_TextMeshPro; //Field offset: 0x38
	private Transform m_frameCounter_transform; //Field offset: 0x40
	private Camera m_camera; //Field offset: 0x48
	private FpsCounterAnchorPositions last_AnchorPosition; //Field offset: 0x50

	public TMP_FrameRateCounter() { }

	private void Awake() { }

	private void Set_FrameCounter_Position(FpsCounterAnchorPositions anchor_position) { }

	private void Start() { }

	private void Update() { }

}

