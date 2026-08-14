namespace UnityEngine.UIElements;

public class Slider : BaseSlider<Single>
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<Slider, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits<Single, UxmlFloatAttributeDescription>
	{
		private UxmlFloatAttributeDescription m_LowValue; //Field offset: 0xA0
		private UxmlFloatAttributeDescription m_HighValue; //Field offset: 0xA8
		private UxmlFloatAttributeDescription m_PageSize; //Field offset: 0xB0
		private UxmlBoolAttributeDescription m_ShowInputField; //Field offset: 0xB8
		private UxmlEnumAttributeDescription<SliderDirection> m_Direction; //Field offset: 0xC0
		private UxmlBoolAttributeDescription m_Inverted; //Field offset: 0xC8

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	public static readonly string ussClassName; //Field offset: 0x0
	public static readonly string labelUssClassName; //Field offset: 0x8
	public static readonly string inputUssClassName; //Field offset: 0x10

	private static Slider() { }

	public Slider() { }

	public Slider(float start, float end, SliderDirection direction = 0, float pageSize = 0) { }

	public Slider(string label, float start = 0, float end = 10, SliderDirection direction = 0, float pageSize = 0) { }

	public virtual void ApplyInputDeviceDelta(Vector3 delta, DeltaSpeed speed, float startValue) { }

	internal virtual void ComputeValueFromKey(SliderKey<Single> sliderKey, bool isShift) { }

	internal virtual float ParseStringToValue(string previousValue, string newValue) { }

	internal virtual float SliderLerpUnclamped(float a, float b, float interpolant) { }

	internal virtual float SliderNormalizeValue(float currentValue, float lowerValue, float higherValue) { }

	internal virtual float SliderRange() { }

}

