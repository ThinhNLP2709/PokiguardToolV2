namespace UnityEngine.UIElements;

public abstract class AbstractProgressBar : BindableElement, INotifyValueChanged<Single>
{
	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlFloatAttributeDescription m_LowValue; //Field offset: 0x90
		private UxmlFloatAttributeDescription m_HighValue; //Field offset: 0x98
		private UxmlFloatAttributeDescription m_Value; //Field offset: 0xA0
		private UxmlStringAttributeDescription m_Title; //Field offset: 0xA8

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId titleProperty; //Field offset: 0x0
	internal static readonly BindingId lowValueProperty; //Field offset: 0x98
	internal static readonly BindingId highValueProperty; //Field offset: 0x130
	internal static readonly BindingId valueProperty; //Field offset: 0x1C8
	public static readonly string ussClassName; //Field offset: 0x260
	public static readonly string containerUssClassName; //Field offset: 0x268
	public static readonly string titleUssClassName; //Field offset: 0x270
	public static readonly string titleContainerUssClassName; //Field offset: 0x278
	public static readonly string progressUssClassName; //Field offset: 0x280
	public static readonly string backgroundUssClassName; //Field offset: 0x288
	private readonly VisualElement m_Background; //Field offset: 0x4B8
	private readonly VisualElement m_Progress; //Field offset: 0x4C0
	private readonly Label m_Title; //Field offset: 0x4C8
	private float m_LowValue; //Field offset: 0x4D0
	private float m_HighValue; //Field offset: 0x4D4
	private float m_Value; //Field offset: 0x4D8

	[CreateProperty]
	public float highValue
	{
		 get { } //Length: 9
		 set { } //Length: 180
	}

	[CreateProperty]
	public float lowValue
	{
		 get { } //Length: 9
		 set { } //Length: 180
	}

	[CreateProperty]
	public string title
	{
		 get { } //Length: 45
		 set { } //Length: 245
	}

	[CreateProperty]
	public override float value
	{
		 get { } //Length: 11
		 set { } //Length: 803
	}

	private static AbstractProgressBar() { }

	public AbstractProgressBar() { }

	private float CalculateProgressWidth(float width) { }

	public float get_highValue() { }

	public float get_lowValue() { }

	public string get_title() { }

	public override float get_value() { }

	private void OnGeometryChanged(GeometryChangedEvent e) { }

	public void set_highValue(float value) { }

	public void set_lowValue(float value) { }

	public void set_title(string value) { }

	public override void set_value(float value) { }

	private void SetProgress(float p) { }

	public override void SetValueWithoutNotify(float newValue) { }

}

