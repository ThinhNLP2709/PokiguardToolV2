namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerFloatField : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Text valueLabel; //Field offset: 0x68
	private FloatField m_Field; //Field offset: 0x70

	public DebugUIHandlerFloatField() { }

	private void ChangeValue(bool fast, float multiplier) { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

	private void UpdateValueLabel() { }

}

