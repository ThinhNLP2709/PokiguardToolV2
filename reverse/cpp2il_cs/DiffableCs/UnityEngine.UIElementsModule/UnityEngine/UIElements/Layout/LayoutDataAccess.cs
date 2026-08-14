namespace UnityEngine.UIElements.Layout;

[IsReadOnly]
[RequiredByNativeCode]
internal struct LayoutDataAccess
{
	private readonly int m_Manager; //Field offset: 0x0
	private readonly LayoutDataStore m_Nodes; //Field offset: 0x8
	private readonly LayoutDataStore m_Configs; //Field offset: 0x18

	public bool IsValid
	{
		 get { } //Length: 34
	}

	internal LayoutDataAccess(int manager, LayoutDataStore nodes, LayoutDataStore configs) { }

	public bool get_IsValid() { }

	public LayoutBaselineFunction GetBaselineFunction(LayoutHandle handle) { }

	public LayoutComputedData GetComputedData(LayoutHandle handle) { }

	public LayoutConfigData GetConfigData(LayoutHandle handle) { }

	public LayoutMeasureFunction GetMeasureFunction(LayoutHandle handle) { }

	public LayoutNodeData GetNodeData(LayoutHandle handle) { }

	public VisualElement GetOwner(LayoutHandle handle) { }

	public LayoutStyleData GetStyleData(LayoutHandle handle) { }

	private T GetTypedConfigDataRef(LayoutHandle handle, LayoutConfigDataType type) { }

	private T GetTypedNodeDataRef(LayoutHandle handle, LayoutNodeDataType type) { }

	public void SetMeasureFunction(LayoutHandle handle, LayoutMeasureFunction value) { }

	public void SetOwner(LayoutHandle handle, VisualElement value) { }

}

