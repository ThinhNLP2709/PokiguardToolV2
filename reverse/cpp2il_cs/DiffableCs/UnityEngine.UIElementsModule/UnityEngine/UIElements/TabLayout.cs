namespace UnityEngine.UIElements;

internal class TabLayout
{
	private TabView m_TabView; //Field offset: 0x10
	private List<VisualElement> m_TabHeaders; //Field offset: 0x18
	private bool m_IsVertical; //Field offset: 0x20

	public TabLayout(TabView tabView, bool isVertical) { }

	public static float GetHeight(VisualElement t) { }

	public float GetTabOffset(VisualElement tab) { }

	public static float GetWidth(VisualElement t) { }

	private void InitOrderTabs() { }

	public void ReorderDisplay(int from, int to) { }

}

