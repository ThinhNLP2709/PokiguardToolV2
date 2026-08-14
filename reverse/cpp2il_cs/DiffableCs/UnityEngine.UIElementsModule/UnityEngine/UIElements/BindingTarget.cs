namespace UnityEngine.UIElements;

[IsReadOnly]
internal struct BindingTarget
{
	public readonly VisualElement element; //Field offset: 0x0
	public readonly BindingId bindingId; //Field offset: 0x8

	public BindingTarget(VisualElement element, in BindingId bindingId) { }

}

