namespace UnityEngine.UIElements;

public class TwoPaneSplitView : VisualElement
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<TwoPaneSplitView, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlIntAttributeDescription m_FixedPaneIndex; //Field offset: 0x88
		private UxmlIntAttributeDescription m_FixedPaneInitialDimension; //Field offset: 0x90
		private UxmlEnumAttributeDescription<TwoPaneSplitViewOrientation> m_Orientation; //Field offset: 0x98

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId fixedPaneIndexProperty; //Field offset: 0x0
	internal static readonly BindingId fixedPaneInitialDimensionProperty; //Field offset: 0x98
	internal static readonly BindingId orientationProperty; //Field offset: 0x130
	private static readonly string s_UssClassName; //Field offset: 0x1C8
	private static readonly string s_ContentContainerClassName; //Field offset: 0x1D0
	private static readonly string s_HandleDragLineClassName; //Field offset: 0x1D8
	private static readonly string s_HandleDragLineVerticalClassName; //Field offset: 0x1E0
	private static readonly string s_HandleDragLineHorizontalClassName; //Field offset: 0x1E8
	private static readonly string s_HandleDragLineAnchorClassName; //Field offset: 0x1F0
	private static readonly string s_HandleDragLineAnchorVerticalClassName; //Field offset: 0x1F8
	private static readonly string s_HandleDragLineAnchorHorizontalClassName; //Field offset: 0x200
	private static readonly string s_VerticalClassName; //Field offset: 0x208
	private static readonly string s_HorizontalClassName; //Field offset: 0x210
	private VisualElement m_LeftPane; //Field offset: 0x4A8
	private VisualElement m_RightPane; //Field offset: 0x4B0
	private VisualElement m_FixedPane; //Field offset: 0x4B8
	private VisualElement m_FlexedPane; //Field offset: 0x4C0
	[DontCreateProperty]
	[SerializeField]
	private float m_FixedPaneDimension; //Field offset: 0x4C8
	private VisualElement m_DragLine; //Field offset: 0x4D0
	private VisualElement m_DragLineAnchor; //Field offset: 0x4D8
	private bool m_CollapseMode; //Field offset: 0x4E0
	private bool m_PendingCollapseToExecute; //Field offset: 0x4E1
	private int m_CollapsedChildIndex; //Field offset: 0x4E4
	private VisualElement m_Content; //Field offset: 0x4E8
	private TwoPaneSplitViewOrientation m_Orientation; //Field offset: 0x4F0
	private int m_FixedPaneIndex; //Field offset: 0x4F4
	private float m_FixedPaneInitialDimension; //Field offset: 0x4F8
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal TwoPaneSplitViewResizer m_Resizer; //Field offset: 0x500

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 10
	}

	internal VisualElement dragLine
	{
		internal get { } //Length: 8
	}

	public VisualElement fixedPane
	{
		 get { } //Length: 8
	}

	internal float fixedPaneDimension
	{
		internal get { } //Length: 52
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal set { } //Length: 27
	}

	[CreateProperty]
	public int fixedPaneIndex
	{
		 get { } //Length: 7
		 set { } //Length: 156
	}

	[CreateProperty]
	public float fixedPaneInitialDimension
	{
		 get { } //Length: 9
		 set { } //Length: 167
	}

	public VisualElement flexedPane
	{
		 get { } //Length: 8
	}

	[CreateProperty]
	public TwoPaneSplitViewOrientation orientation
	{
		 get { } //Length: 7
		 set { } //Length: 163
	}

	private static TwoPaneSplitView() { }

	public TwoPaneSplitView() { }

	public void CollapseChild(int index) { }

	public virtual VisualElement get_contentContainer() { }

	internal VisualElement get_dragLine() { }

	public VisualElement get_fixedPane() { }

	internal float get_fixedPaneDimension() { }

	public int get_fixedPaneIndex() { }

	public float get_fixedPaneInitialDimension() { }

	public VisualElement get_flexedPane() { }

	public TwoPaneSplitViewOrientation get_orientation() { }

	private void IdentifyLeftAndRightPane() { }

	internal override void Init(int fixedPaneIndex, float fixedPaneInitialDimension, TwoPaneSplitViewOrientation orientation) { }

	private void OnPostDisplaySetup(GeometryChangedEvent evt) { }

	private void OnSizeChange(GeometryChangedEvent evt) { }

	internal virtual void OnViewDataReady() { }

	private void PostDisplaySetup() { }

	private void ReplacePanesBasedOnAnchor() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void set_fixedPaneDimension(float value) { }

	public void set_fixedPaneIndex(int value) { }

	public void set_fixedPaneInitialDimension(float value) { }

	public void set_orientation(TwoPaneSplitViewOrientation value) { }

	private void SetDragLineOffset(float offset) { }

	private void SetFixedPaneDimension(float dimension) { }

	private void SetupSplitView() { }

	private void UpdateLayout(bool updateFixedPane, bool updateDragLine) { }

}

