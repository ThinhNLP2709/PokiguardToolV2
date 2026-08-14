namespace UnityEngine.UIElements;

[IsReadOnly]
public struct BindingActivationContext
{
	private readonly VisualElement m_TargetElement; //Field offset: 0x0
	private readonly BindingId m_BindingId; //Field offset: 0x8

	internal BindingActivationContext(VisualElement element, in BindingId property) { }

}

