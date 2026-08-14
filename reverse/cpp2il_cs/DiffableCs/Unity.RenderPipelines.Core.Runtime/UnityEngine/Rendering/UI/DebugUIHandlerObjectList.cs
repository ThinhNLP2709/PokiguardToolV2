namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerObjectList : DebugUIHandlerField<ObjectListField>
{
	private int m_Index; //Field offset: 0x88

	public DebugUIHandlerObjectList() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnIncrement(bool fast) { }

	internal virtual void SetWidget(Widget widget) { }

	public virtual void UpdateValueLabel() { }

}

