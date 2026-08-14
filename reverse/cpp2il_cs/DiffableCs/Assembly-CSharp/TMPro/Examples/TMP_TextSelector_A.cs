namespace TMPro.Examples;

public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private TextMeshPro m_TextMeshPro; //Field offset: 0x20
	private Camera m_Camera; //Field offset: 0x28
	private bool m_isHoveringObject; //Field offset: 0x30
	private int m_selectedLink; //Field offset: 0x34
	private int m_lastCharIndex; //Field offset: 0x38
	private int m_lastWordIndex; //Field offset: 0x3C

	public TMP_TextSelector_A() { }

	private void Awake() { }

	private void LateUpdate() { }

	public override void OnPointerEnter(PointerEventData eventData) { }

	public override void OnPointerExit(PointerEventData eventData) { }

}

