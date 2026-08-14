namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerPanel : MonoBehaviour
{
	public Text nameLabel; //Field offset: 0x20
	public ScrollRect scrollRect; //Field offset: 0x28
	public RectTransform viewport; //Field offset: 0x30
	public DebugUIHandlerCanvas Canvas; //Field offset: 0x38
	private RectTransform m_ScrollTransform; //Field offset: 0x40
	private RectTransform m_ContentTransform; //Field offset: 0x48
	private RectTransform m_MaskTransform; //Field offset: 0x50
	private DebugUIHandlerWidget m_ScrollTarget; //Field offset: 0x58
	protected private Panel m_Panel; //Field offset: 0x60

	public DebugUIHandlerPanel() { }

	internal DebugUIHandlerWidget GetFirstItem() { }

	internal Panel GetPanel() { }

	private float GetYPosInScroll(RectTransform target) { }

	private void OnEnable() { }

	public void OnScrollbarClicked() { }

	public void ResetDebugManager() { }

	public void SelectNextItem() { }

	public void SelectPreviousItem() { }

	internal void SetPanel(Panel panel) { }

	internal void SetScrollTarget(DebugUIHandlerWidget target) { }

	internal void UpdateScroll() { }

}

