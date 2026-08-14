namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerGroup : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Transform header; //Field offset: 0x68
	private Container m_Field; //Field offset: 0x70
	private DebugUIHandlerContainer m_Container; //Field offset: 0x78

	public DebugUIHandlerGroup() { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

}

