namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerToggle : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Toggle valueToggle; //Field offset: 0x68
	public Image checkmarkImage; //Field offset: 0x70
	protected private BoolField m_Field; //Field offset: 0x78

	public DebugUIHandlerToggle() { }

	public virtual void OnAction() { }

	public virtual void OnDeselection() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void OnToggleValueChanged(bool value) { }

	internal virtual void SetWidget(Widget widget) { }

	protected private override void UpdateValueLabel() { }

}

