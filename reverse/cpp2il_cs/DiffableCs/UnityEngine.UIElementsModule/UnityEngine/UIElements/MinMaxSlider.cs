namespace UnityEngine.UIElements;

public class MinMaxSlider : BaseField<Vector2>
{
	private enum DragState
	{
		MinThumb = 0,
		MaxThumb = 1,
		MiddleThumb = 2,
		NoThumb = 3,
	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<MinMaxSlider, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits<Vector2>
	{
		private UxmlFloatAttributeDescription m_MinValue; //Field offset: 0x98
		private UxmlFloatAttributeDescription m_MaxValue; //Field offset: 0xA0
		private UxmlFloatAttributeDescription m_LowLimit; //Field offset: 0xA8
		private UxmlFloatAttributeDescription m_HighLimit; //Field offset: 0xB0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId minValueProperty; //Field offset: 0x0
	internal static readonly BindingId maxValueProperty; //Field offset: 0x98
	internal static readonly BindingId rangeProperty; //Field offset: 0x130
	internal static readonly BindingId lowLimitProperty; //Field offset: 0x1C8
	internal static readonly BindingId highLimitProperty; //Field offset: 0x260
	public static readonly string ussClassName; //Field offset: 0x2F8
	public static readonly string labelUssClassName; //Field offset: 0x300
	public static readonly string inputUssClassName; //Field offset: 0x308
	public static readonly string trackerUssClassName; //Field offset: 0x310
	public static readonly string draggerUssClassName; //Field offset: 0x318
	public static readonly string minThumbUssClassName; //Field offset: 0x320
	public static readonly string maxThumbUssClassName; //Field offset: 0x328
	public static readonly string movableUssClassName; //Field offset: 0x330
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <dragElement>k__BackingField; //Field offset: 0x528
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <dragMinThumb>k__BackingField; //Field offset: 0x530
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <dragMaxThumb>k__BackingField; //Field offset: 0x538
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ClampedDragger<Single> <clampedDragger>k__BackingField; //Field offset: 0x540
	private Vector2 m_DragElementStartPos; //Field offset: 0x548
	private Vector2 m_ValueStartPos; //Field offset: 0x550
	private DragState m_DragState; //Field offset: 0x558
	private float m_MinLimit; //Field offset: 0x55C
	private float m_MaxLimit; //Field offset: 0x560

	internal ClampedDragger<Single> clampedDragger
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal VisualElement dragElement
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal VisualElement dragMaxThumb
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal VisualElement dragMinThumb
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[CreateProperty]
	public float highLimit
	{
		 get { } //Length: 11
		 set { } //Length: 330
	}

	[CreateProperty]
	public float lowLimit
	{
		 get { } //Length: 11
		 set { } //Length: 326
	}

	[CreateProperty]
	public float maxValue
	{
		 get { } //Length: 39
		 set { } //Length: 277
	}

	[CreateProperty]
	public float minValue
	{
		 get { } //Length: 39
		 set { } //Length: 270
	}

	[CreateProperty(ReadOnly = True)]
	public float range
	{
		 get { } //Length: 114
	}

	public virtual Vector2 value
	{
		 get { } //Length: 58
		 set { } //Length: 91
	}

	private static MinMaxSlider() { }

	public MinMaxSlider() { }

	public MinMaxSlider(string label, float minValue = 0, float maxValue = 10, float minLimit = -3.4028235E+38, float maxLimit = 3.4028235E+38) { }

	private Vector2 ClampValues(Vector2 valueToClamp) { }

	private void ComputeValueFromDraggingThumb(float dragElementStartPos, float dragElementEndPos) { }

	private void ComputeValueFromKey(bool leftDirection, bool isShift, DragState moveState) { }

	private float ComputeValueFromPosition(float positionToConvert) { }

	[CompilerGenerated]
	internal ClampedDragger<Single> get_clampedDragger() { }

	[CompilerGenerated]
	internal VisualElement get_dragElement() { }

	[CompilerGenerated]
	internal VisualElement get_dragMaxThumb() { }

	[CompilerGenerated]
	internal VisualElement get_dragMinThumb() { }

	public float get_highLimit() { }

	public float get_lowLimit() { }

	public float get_maxValue() { }

	public float get_minValue() { }

	public float get_range() { }

	public virtual Vector2 get_value() { }

	private DragState GetNavigationState() { }

	[EventInterest(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(GeometryChangedEvent)})]
	protected virtual void HandleEventBubbleUp(EventBase evt) { }

	private void OnBlur(BlurEvent evt) { }

	private void OnFocusIn(FocusInEvent evt) { }

	private void OnNavigationMove(NavigationMoveEvent evt) { }

	private void OnNavigationSubmit(NavigationSubmitEvent evt) { }

	internal virtual void RegisterEditingCallbacks() { }

	[CompilerGenerated]
	private void set_clampedDragger(ClampedDragger<Single> value) { }

	[CompilerGenerated]
	private void set_dragElement(VisualElement value) { }

	[CompilerGenerated]
	private void set_dragMaxThumb(VisualElement value) { }

	[CompilerGenerated]
	private void set_dragMinThumb(VisualElement value) { }

	public void set_highLimit(float value) { }

	public void set_lowLimit(float value) { }

	public void set_maxValue(float value) { }

	public void set_minValue(float value) { }

	public virtual void set_value(Vector2 value) { }

	private void SetNavigationState(DragState newState) { }

	private void SetSliderValueFromClick() { }

	private void SetSliderValueFromDrag() { }

	public virtual void SetValueWithoutNotify(Vector2 newValue) { }

	internal float SliderLerpUnclamped(float a, float b, float interpolant) { }

	internal float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue) { }

	internal virtual void UnregisterEditingCallbacks() { }

	private void UpdateDragElementPosition() { }

	private void UpdateDragElementPosition(GeometryChangedEvent evt) { }

	protected virtual void UpdateMixedValueContent() { }

}

