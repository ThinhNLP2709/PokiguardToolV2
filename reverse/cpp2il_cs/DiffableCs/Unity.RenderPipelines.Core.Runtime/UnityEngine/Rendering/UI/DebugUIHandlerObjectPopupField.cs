namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerObjectPopupField : DebugUIHandlerField<ObjectPopupField>
{
	private int m_Index; //Field offset: 0x88

	public DebugUIHandlerObjectPopupField() { }

	private void ChangeSelectedObject() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnIncrement(bool fast) { }

	internal virtual void SetWidget(Widget widget) { }

	public virtual void UpdateValueLabel() { }

}

