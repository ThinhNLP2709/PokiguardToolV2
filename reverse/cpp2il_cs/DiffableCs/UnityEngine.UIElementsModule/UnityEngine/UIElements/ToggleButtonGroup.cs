namespace UnityEngine.UIElements;

public class ToggleButtonGroup : BaseField<ToggleButtonGroupState>
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<ToggleButtonGroup, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits<ToggleButtonGroupState>
	{
		private UxmlBoolAttributeDescription m_IsMultipleSelection; //Field offset: 0x98
		private UxmlBoolAttributeDescription m_AllowEmptySelection; //Field offset: 0xA0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	private static readonly string k_MaxToggleButtonGroupMessage; //Field offset: 0x0
	internal static readonly BindingId isMultipleSelectionProperty; //Field offset: 0x8
	internal static readonly BindingId allowEmptySelectionProperty; //Field offset: 0xA0
	public static readonly string ussClassName; //Field offset: 0x138
	public static readonly string containerUssClassName; //Field offset: 0x140
	public static readonly string buttonGroupClassName; //Field offset: 0x148
	public static readonly string buttonClassName; //Field offset: 0x150
	public static readonly string buttonLeftClassName; //Field offset: 0x158
	public static readonly string buttonMidClassName; //Field offset: 0x160
	public static readonly string buttonRightClassName; //Field offset: 0x168
	public static readonly string buttonStandaloneClassName; //Field offset: 0x170
	public static readonly string emptyStateLabelClassName; //Field offset: 0x178
	private VisualElement m_ButtonGroupContainer; //Field offset: 0x530
	private List<Button> m_Buttons; //Field offset: 0x538
	private VisualElement m_EmptyLabel; //Field offset: 0x540
	private bool m_IsMultipleSelection; //Field offset: 0x548
	private bool m_AllowEmptySelection; //Field offset: 0x549

	[CreateProperty]
	public bool allowEmptySelection
	{
		 get { } //Length: 8
		 set { } //Length: 607
	}

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 18
	}

	[CreateProperty]
	public bool isMultipleSelection
	{
		 get { } //Length: 8
		 set { } //Length: 477
	}

	private static ToggleButtonGroup() { }

	public ToggleButtonGroup(string label, ToggleButtonGroupState toggleButtonGroupState) { }

	public ToggleButtonGroup() { }

	public ToggleButtonGroup(string label) { }

	public bool get_allowEmptySelection() { }

	public virtual VisualElement get_contentContainer() { }

	public bool get_isMultipleSelection() { }

	private void OnButtonGroupContainerElementAdded(VisualElement ve) { }

	private void OnButtonGroupContainerElementRemoved(VisualElement ve) { }

	private void OnOptionChange(EventBase evt) { }

	internal virtual void OnViewDataReady() { }

	public void set_allowEmptySelection(bool value) { }

	public void set_isMultipleSelection(bool value) { }

	public virtual void SetValueWithoutNotify(ToggleButtonGroupState newValue) { }

	private void UpdateButtonsStyling() { }

	private void UpdateButtonStates(ToggleButtonGroupState options) { }

	protected virtual void UpdateMixedValueContent() { }

}

