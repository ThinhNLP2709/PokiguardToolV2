namespace UnityEngine.UIElements;

[IsReadOnly]
public struct DataSourceContextChanged
{
	private readonly VisualElement m_TargetElement; //Field offset: 0x0
	private readonly BindingId m_BindingId; //Field offset: 0x8
	private readonly DataSourceContext m_PreviousContext; //Field offset: 0xA0
	private readonly DataSourceContext m_NewContext; //Field offset: 0x138

	internal DataSourceContextChanged(VisualElement element, in BindingId bindingId, in DataSourceContext previousContext, in DataSourceContext newContext) { }

}

