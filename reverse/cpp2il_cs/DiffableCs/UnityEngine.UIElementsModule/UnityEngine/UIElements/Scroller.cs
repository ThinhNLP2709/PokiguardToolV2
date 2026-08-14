namespace UnityEngine.UIElements;

public class Scroller : VisualElement
{
	private class ScrollerSlider : Slider
	{

		public ScrollerSlider(float start, float end, SliderDirection direction, float pageSize) { }

		internal virtual float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue) { }

	}

	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<Scroller, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlFloatAttributeDescription m_LowValue; //Field offset: 0x88
		private UxmlFloatAttributeDescription m_HighValue; //Field offset: 0x90
		private UxmlEnumAttributeDescription<SliderDirection> m_Direction; //Field offset: 0x98
		private UxmlFloatAttributeDescription m_Value; //Field offset: 0xA0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId valueProperty; //Field offset: 0x0
	internal static readonly BindingId lowValueProperty; //Field offset: 0x98
	internal static readonly BindingId highValueProperty; //Field offset: 0x130
	internal static readonly BindingId directionProperty; //Field offset: 0x1C8
	public static readonly string ussClassName; //Field offset: 0x260
	public static readonly string horizontalVariantUssClassName; //Field offset: 0x268
	public static readonly string verticalVariantUssClassName; //Field offset: 0x270
	public static readonly string sliderUssClassName; //Field offset: 0x278
	public static readonly string lowButtonUssClassName; //Field offset: 0x280
	public static readonly string highButtonUssClassName; //Field offset: 0x288
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Single> valueChanged; //Field offset: 0x4A8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly Slider <slider>k__BackingField; //Field offset: 0x4B0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly RepeatButton <lowButton>k__BackingField; //Field offset: 0x4B8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly RepeatButton <highButton>k__BackingField; //Field offset: 0x4C0

	public event Action<Single> valueChanged
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	[CreateProperty]
	public SliderDirection direction
	{
		 get { } //Length: 93
		 set { } //Length: 579
	}

	public RepeatButton highButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CreateProperty]
	public float highValue
	{
		 get { } //Length: 71
		 set { } //Length: 255
	}

	public RepeatButton lowButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CreateProperty]
	public float lowValue
	{
		 get { } //Length: 71
		 set { } //Length: 255
	}

	public Slider slider
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CreateProperty]
	public float value
	{
		 get { } //Length: 45
		 set { } //Length: 245
	}

	private static Scroller() { }

	public Scroller(float lowValue, float highValue, Action<Single> valueChanged, SliderDirection direction = 1) { }

	public Scroller() { }

	[CompilerGenerated]
	public void add_valueChanged(Action<Single> value) { }

	public void Adjust(float factor) { }

	public SliderDirection get_direction() { }

	[CompilerGenerated]
	public RepeatButton get_highButton() { }

	public float get_highValue() { }

	[CompilerGenerated]
	public RepeatButton get_lowButton() { }

	public float get_lowValue() { }

	[CompilerGenerated]
	public Slider get_slider() { }

	public float get_value() { }

	private void OnSliderValueChange(ChangeEvent<Single> evt) { }

	[CompilerGenerated]
	public void remove_valueChanged(Action<Single> value) { }

	public void ScrollPageDown() { }

	public void ScrollPageDown(float factor) { }

	public void ScrollPageUp(float factor) { }

	public void ScrollPageUp() { }

	public void set_direction(SliderDirection value) { }

	public void set_highValue(float value) { }

	public void set_lowValue(float value) { }

	public void set_value(float value) { }

}

