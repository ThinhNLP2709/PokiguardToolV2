namespace UnityEngine.UIElements;

[IsReadOnly]
public struct BindingContext
{
	private readonly VisualElement m_TargetElement; //Field offset: 0x0
	private readonly BindingId m_BindingId; //Field offset: 0x8
	private readonly PropertyPath m_DataSourcePath; //Field offset: 0xA0
	private readonly object m_DataSource; //Field offset: 0x130

	public BindingId bindingId
	{
		 get { } //Length: 97
	}

	public object dataSource
	{
		 get { } //Length: 8
	}

	public PropertyPath dataSourcePath
	{
		 get { } //Length: 105
	}

	public VisualElement targetElement
	{
		 get { } //Length: 4
	}

	internal BindingContext(VisualElement targetElement, in BindingId bindingId, in PropertyPath resolvedDataSourcePath, object resolvedDataSource) { }

	public BindingId get_bindingId() { }

	public object get_dataSource() { }

	public PropertyPath get_dataSourcePath() { }

	public VisualElement get_targetElement() { }

}

