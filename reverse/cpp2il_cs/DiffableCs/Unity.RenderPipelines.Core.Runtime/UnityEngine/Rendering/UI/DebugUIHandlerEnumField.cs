namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerEnumField : DebugUIHandlerField<EnumField>
{

	public DebugUIHandlerEnumField() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnIncrement(bool fast) { }

	public virtual void UpdateValueLabel() { }

}

