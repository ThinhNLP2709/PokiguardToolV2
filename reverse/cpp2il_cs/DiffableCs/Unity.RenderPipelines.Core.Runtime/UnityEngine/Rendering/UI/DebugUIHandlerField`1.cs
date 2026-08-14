namespace UnityEngine.Rendering.UI;

public abstract class DebugUIHandlerField : DebugUIHandlerWidget
{
	public Text nextButtonText; //Field offset: 0x0
	public Text previousButtonText; //Field offset: 0x0
	public Text nameLabel; //Field offset: 0x0
	public Text valueLabel; //Field offset: 0x0
	protected private T m_Field; //Field offset: 0x0

	protected DebugUIHandlerField`1() { }

	public virtual void OnAction() { }

	public virtual void OnDeselection() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	protected void SetLabelText(string text) { }

	internal virtual void SetWidget(Widget widget) { }

	public abstract void UpdateValueLabel() { }

}

