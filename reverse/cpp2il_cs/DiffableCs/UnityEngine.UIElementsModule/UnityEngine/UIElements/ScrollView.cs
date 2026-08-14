namespace UnityEngine.UIElements;

public class ScrollView : VisualElement
{
	internal enum NestedInteractionKind
	{
		Default = 0,
		StopScrolling = 1,
		ForwardScrolling = 2,
	}

	internal enum TouchScrollBehavior
	{
		Unrestricted = 0,
		Elastic = 1,
		Clamped = 2,
	}

	public enum TouchScrollingResult
	{
		Apply = 0,
		Forward = 1,
		Block = 2,
	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<ScrollView, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlEnumAttributeDescription<ScrollViewMode> m_ScrollViewMode; //Field offset: 0x88
		private UxmlEnumAttributeDescription<NestedInteractionKind> m_NestedInteractionKind; //Field offset: 0x90
		private UxmlBoolAttributeDescription m_ShowHorizontal; //Field offset: 0x98
		private UxmlBoolAttributeDescription m_ShowVertical; //Field offset: 0xA0
		private UxmlEnumAttributeDescription<ScrollerVisibility> m_HorizontalScrollerVisibility; //Field offset: 0xA8
		private UxmlEnumAttributeDescription<ScrollerVisibility> m_VerticalScrollerVisibility; //Field offset: 0xB0
		private UxmlFloatAttributeDescription m_HorizontalPageSize; //Field offset: 0xB8
		private UxmlFloatAttributeDescription m_VerticalPageSize; //Field offset: 0xC0
		private UxmlFloatAttributeDescription m_MouseWheelScrollSize; //Field offset: 0xC8
		private UxmlEnumAttributeDescription<TouchScrollBehavior> m_TouchScrollBehavior; //Field offset: 0xD0
		private UxmlFloatAttributeDescription m_ScrollDecelerationRate; //Field offset: 0xD8
		private UxmlFloatAttributeDescription m_Elasticity; //Field offset: 0xE0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId horizontalScrollerVisibilityProperty; //Field offset: 0x0
	internal static readonly BindingId verticalScrollerVisibilityProperty; //Field offset: 0x98
	internal static readonly BindingId scrollOffsetProperty; //Field offset: 0x130
	internal static readonly BindingId horizontalPageSizeProperty; //Field offset: 0x1C8
	internal static readonly BindingId verticalPageSizeProperty; //Field offset: 0x260
	internal static readonly BindingId mouseWheelScrollSizeProperty; //Field offset: 0x2F8
	internal static readonly BindingId scrollDecelerationRateProperty; //Field offset: 0x390
	internal static readonly BindingId elasticityProperty; //Field offset: 0x428
	internal static readonly BindingId touchScrollBehaviorProperty; //Field offset: 0x4C0
	internal static readonly BindingId nestedInteractionKindProperty; //Field offset: 0x558
	internal static readonly BindingId modeProperty; //Field offset: 0x5F0
	internal static readonly BindingId elasticAnimationIntervalMsProperty; //Field offset: 0x688
	private static readonly float k_DefaultScrollDecelerationRate; //Field offset: 0x720
	private static readonly float k_DefaultElasticity; //Field offset: 0x724
	public static readonly string ussClassName; //Field offset: 0x728
	public static readonly string viewportUssClassName; //Field offset: 0x730
	public static readonly string horizontalVariantViewportUssClassName; //Field offset: 0x738
	public static readonly string verticalVariantViewportUssClassName; //Field offset: 0x740
	public static readonly string verticalHorizontalVariantViewportUssClassName; //Field offset: 0x748
	public static readonly string contentAndVerticalScrollUssClassName; //Field offset: 0x750
	public static readonly string contentUssClassName; //Field offset: 0x758
	public static readonly string horizontalVariantContentUssClassName; //Field offset: 0x760
	public static readonly string verticalVariantContentUssClassName; //Field offset: 0x768
	public static readonly string verticalHorizontalVariantContentUssClassName; //Field offset: 0x770
	public static readonly string hScrollerUssClassName; //Field offset: 0x778
	public static readonly string vScrollerUssClassName; //Field offset: 0x780
	public static readonly string horizontalVariantUssClassName; //Field offset: 0x788
	public static readonly string verticalVariantUssClassName; //Field offset: 0x790
	public static readonly string verticalHorizontalVariantUssClassName; //Field offset: 0x798
	public static readonly string scrollVariantUssClassName; //Field offset: 0x7A0
	private int m_FirstLayoutPass; //Field offset: 0x4A8
	private ScrollerVisibility m_HorizontalScrollerVisibility; //Field offset: 0x4AC
	private ScrollerVisibility m_VerticalScrollerVisibility; //Field offset: 0x4B0
	private long m_ElasticAnimationIntervalMs; //Field offset: 0x4B8
	private VisualElement m_AttachedRootVisualContainer; //Field offset: 0x4C0
	private float m_SingleLineHeight; //Field offset: 0x4C8
	internal bool m_MouseWheelScrollSizeIsInline; //Field offset: 0x4CC
	private float m_HorizontalPageSize; //Field offset: 0x4D0
	private float m_VerticalPageSize; //Field offset: 0x4D4
	private float m_MouseWheelScrollSize; //Field offset: 0x4D8
	private float m_ScrollDecelerationRate; //Field offset: 0x4DC
	private float k_ScaledPixelsPerPointMultiplier; //Field offset: 0x4E0
	private float k_TouchScrollInertiaBaseTimeInterval; //Field offset: 0x4E4
	private float m_Elasticity; //Field offset: 0x4E8
	private TouchScrollBehavior m_TouchScrollBehavior; //Field offset: 0x4EC
	private NestedInteractionKind m_NestedInteractionKind; //Field offset: 0x4F0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly VisualElement <contentViewport>k__BackingField; //Field offset: 0x4F8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Scroller <horizontalScroller>k__BackingField; //Field offset: 0x500
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Scroller <verticalScroller>k__BackingField; //Field offset: 0x508
	private VisualElement m_ContentContainer; //Field offset: 0x510
	private VisualElement m_ContentAndVerticalScrollContainer; //Field offset: 0x518
	private float previousVerticalTouchScrollTimeStamp; //Field offset: 0x520
	private float previousHorizontalTouchScrollTimeStamp; //Field offset: 0x524
	private float elapsedTimeSinceLastVerticalTouchScroll; //Field offset: 0x528
	private float elapsedTimeSinceLastHorizontalTouchScroll; //Field offset: 0x52C
	private ScrollViewMode m_Mode; //Field offset: 0x530
	private IVisualElementScheduledItem m_ScheduledLayoutPassResetItem; //Field offset: 0x538
	private Vector2 m_StartPosition; //Field offset: 0x540
	private Vector2 m_PointerStartPosition; //Field offset: 0x548
	private Vector2 m_Velocity; //Field offset: 0x550
	private Vector2 m_SpringBackVelocity; //Field offset: 0x558
	private Vector2 m_LowBounds; //Field offset: 0x560
	private Vector2 m_HighBounds; //Field offset: 0x568
	private float m_LastVelocityLerpTime; //Field offset: 0x570
	private bool m_StartedMoving; //Field offset: 0x574
	private bool m_TouchPointerMoveAllowed; //Field offset: 0x575
	private bool m_TouchStoppedVelocity; //Field offset: 0x576
	private VisualElement m_CapturedTarget; //Field offset: 0x578
	private EventCallback<PointerMoveEvent> m_CapturedTargetPointerMoveCallback; //Field offset: 0x580
	private EventCallback<PointerUpEvent> m_CapturedTargetPointerUpCallback; //Field offset: 0x588
	internal IVisualElementScheduledItem m_PostPointerUpAnimation; //Field offset: 0x590

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 10
	}

	public VisualElement contentViewport
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CreateProperty]
	public long elasticAnimationIntervalMs
	{
		 get { } //Length: 10
		 set { } //Length: 328
	}

	[CreateProperty]
	public float elasticity
	{
		 get { } //Length: 11
		 set { } //Length: 264
	}

	private bool hasInertia
	{
		private get { } //Length: 20
	}

	[CreateProperty]
	public float horizontalPageSize
	{
		 get { } //Length: 11
		 set { } //Length: 171
	}

	public Scroller horizontalScroller
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CreateProperty]
	public ScrollerVisibility horizontalScrollerVisibility
	{
		 get { } //Length: 9
		 set { } //Length: 263
	}

	internal bool isHorizontalScrollDisplayed
	{
		internal get { } //Length: 97
	}

	internal bool isVerticalScrollDisplayed
	{
		internal get { } //Length: 97
	}

	[CreateProperty]
	public ScrollViewMode mode
	{
		 get { } //Length: 7
		 set { } //Length: 147
	}

	[CreateProperty]
	public float mouseWheelScrollSize
	{
		 get { } //Length: 11
		 set { } //Length: 198
	}

	internal bool needsHorizontal
	{
		internal get { } //Length: 70
	}

	internal bool needsVertical
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 70
	}

	[CreateProperty]
	public NestedInteractionKind nestedInteractionKind
	{
		 get { } //Length: 7
		 set { } //Length: 126
	}

	internal float scrollableHeight
	{
		internal get { } //Length: 110
	}

	internal float scrollableWidth
	{
		internal get { } //Length: 110
	}

	[CreateProperty]
	public float scrollDecelerationRate
	{
		 get { } //Length: 11
		 set { } //Length: 264
	}

	[CreateProperty]
	public Vector2 scrollOffset
	{
		 get { } //Length: 127
		 set { } //Length: 424
	}

	[Obsolete("showHorizontal is obsolete. Use horizontalScrollerVisibility instead")]
	public bool showHorizontal
	{
		 set { } //Length: 28
	}

	[Obsolete("showVertical is obsolete. Use verticalScrollerVisibility instead")]
	public bool showVertical
	{
		 set { } //Length: 28
	}

	[CreateProperty]
	public TouchScrollBehavior touchScrollBehavior
	{
		 get { } //Length: 9
		 set { } //Length: 271
	}

	[CreateProperty]
	public float verticalPageSize
	{
		 get { } //Length: 11
		 set { } //Length: 171
	}

	public Scroller verticalScroller
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CreateProperty]
	public ScrollerVisibility verticalScrollerVisibility
	{
		 get { } //Length: 9
		 set { } //Length: 279
	}

	private static ScrollView() { }

	public ScrollView(ScrollViewMode scrollViewMode) { }

	public ScrollView() { }

	[CompilerGenerated]
	private void <.ctor>b__138_0(float value) { }

	[CompilerGenerated]
	private void <.ctor>b__138_1(float value) { }

	private void AdjustScrollers() { }

	internal void ApplyScrollInertia() { }

	private bool ApplyTouchScrolling(Vector2 newScrollOffset) { }

	private static float ComputeElasticOffset(float deltaPointer, float initialScrollOffset, float lowLimit, float hardLowLimit, float highLimit, float hardHighLimit) { }

	private void ComputeInitialSpringBackVelocity() { }

	internal TouchScrollingResult ComputeTouchScrolling(Vector2 position) { }

	private void ExecuteElasticSpringAnimation() { }

	public virtual VisualElement get_contentContainer() { }

	[CompilerGenerated]
	public VisualElement get_contentViewport() { }

	public long get_elasticAnimationIntervalMs() { }

	public float get_elasticity() { }

	private bool get_hasInertia() { }

	public float get_horizontalPageSize() { }

	[CompilerGenerated]
	public Scroller get_horizontalScroller() { }

	public ScrollerVisibility get_horizontalScrollerVisibility() { }

	internal bool get_isHorizontalScrollDisplayed() { }

	internal bool get_isVerticalScrollDisplayed() { }

	public ScrollViewMode get_mode() { }

	public float get_mouseWheelScrollSize() { }

	internal bool get_needsHorizontal() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool get_needsVertical() { }

	public NestedInteractionKind get_nestedInteractionKind() { }

	internal float get_scrollableHeight() { }

	internal float get_scrollableWidth() { }

	public float get_scrollDecelerationRate() { }

	public Vector2 get_scrollOffset() { }

	public TouchScrollBehavior get_touchScrollBehavior() { }

	public float get_verticalPageSize() { }

	[CompilerGenerated]
	public Scroller get_verticalScroller() { }

	public ScrollerVisibility get_verticalScrollerVisibility() { }

	private float GetDeltaDistance(float viewMin, float viewMax, float childBoundaryMin, float childBoundaryMax) { }

	private float GetXDeltaOffset(VisualElement child) { }

	private float GetYDeltaOffset(VisualElement child) { }

	internal void InitTouchScrolling(Vector2 position) { }

	private void OnAttachToPanel(AttachToPanelEvent evt) { }

	private void OnDetachFromPanel(DetachFromPanelEvent evt) { }

	private void OnGeometryChanged(GeometryChangedEvent evt) { }

	private void OnHorizontalScrollDragElementChanged(GeometryChangedEvent evt) { }

	private void OnPointerCancel(PointerCancelEvent evt) { }

	private void OnPointerCapture(PointerCaptureEvent evt) { }

	private void OnPointerCaptureOut(PointerCaptureOutEvent evt) { }

	private void OnPointerDown(PointerDownEvent evt) { }

	private void OnPointerMove(PointerMoveEvent evt) { }

	private void OnPointerUp(PointerUpEvent evt) { }

	private void OnRootCustomStyleResolved(CustomStyleResolvedEvent evt) { }

	private void OnRootPointerUp(PointerUpEvent evt) { }

	private void OnScrollersGeometryChanged(GeometryChangedEvent evt) { }

	private void OnScrollWheel(WheelEvent evt) { }

	private void OnVerticalScrollDragElementChanged(GeometryChangedEvent evt) { }

	private void PostPointerUpAnimation() { }

	private void ReadSingleLineHeight() { }

	private bool ReleaseScrolling(int pointerId, IEventHandler target) { }

	private void ResetLayoutPass() { }

	private void ScheduleResetLayoutPass() { }

	public void ScrollTo(VisualElement child) { }

	public void set_elasticAnimationIntervalMs(long value) { }

	public void set_elasticity(float value) { }

	public void set_horizontalPageSize(float value) { }

	public void set_horizontalScrollerVisibility(ScrollerVisibility value) { }

	public void set_mode(ScrollViewMode value) { }

	public void set_mouseWheelScrollSize(float value) { }

	public void set_nestedInteractionKind(NestedInteractionKind value) { }

	public void set_scrollDecelerationRate(float value) { }

	public void set_scrollOffset(Vector2 value) { }

	public void set_showHorizontal(bool value) { }

	public void set_showVertical(bool value) { }

	public void set_touchScrollBehavior(TouchScrollBehavior value) { }

	public void set_verticalPageSize(float value) { }

	public void set_verticalScrollerVisibility(ScrollerVisibility value) { }

	private void SetScrollViewMode(ScrollViewMode mode) { }

	private void SpringBack() { }

	internal void UpdateContentViewTransform() { }

	private void UpdateElasticBehaviour() { }

	private void UpdateHorizontalSliderPageSize() { }

	internal void UpdateScrollers(bool displayHorizontal, bool displayVertical) { }

	private void UpdateVerticalSliderPageSize() { }

}

