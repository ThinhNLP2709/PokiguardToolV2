namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerButton : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	private Button m_Field; //Field offset: 0x68

	public DebugUIHandlerButton() { }

	public virtual void OnAction() { }

	public virtual void OnDeselection() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

}

