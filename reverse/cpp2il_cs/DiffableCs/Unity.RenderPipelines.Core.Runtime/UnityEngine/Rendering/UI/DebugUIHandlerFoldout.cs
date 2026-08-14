namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerFoldout : DebugUIHandlerWidget
{
	private const float k_FoldoutXOffset = 215; //Field offset: 0x0
	private const float k_XOffset = 230; //Field offset: 0x0
	public Text nameLabel; //Field offset: 0x60
	public UIFoldout valueToggle; //Field offset: 0x68
	private Foldout m_Field; //Field offset: 0x70
	private DebugUIHandlerContainer m_Container; //Field offset: 0x78

	public DebugUIHandlerFoldout() { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual void OnAction() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

	private void UpdateValue() { }

}

