namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerHBox : DebugUIHandlerWidget
{
	private DebugUIHandlerContainer m_Container; //Field offset: 0x60

	public DebugUIHandlerHBox() { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

}

