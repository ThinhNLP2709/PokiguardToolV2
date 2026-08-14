namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerObject : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Text valueLabel; //Field offset: 0x68

	public DebugUIHandlerObject() { }

	public virtual void OnDeselection() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

}

