namespace UnityEngine.UIElements;

public class Foldout : BindableElement, INotifyValueChanged<Boolean>
{
	[Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlFactory : UxmlFactory<Foldout, UxmlTraits>
	{

		public UxmlFactory() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : UxmlTraits
	{
		private UxmlStringAttributeDescription m_Text; //Field offset: 0x90
		private UxmlBoolAttributeDescription m_Value; //Field offset: 0x98

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId textProperty; //Field offset: 0x0
	internal static readonly BindingId toggleOnLabelClickProperty; //Field offset: 0x98
	internal static readonly BindingId valueProperty; //Field offset: 0x130
	public static readonly string ussClassName; //Field offset: 0x1C8
	public static readonly string toggleUssClassName; //Field offset: 0x1D0
	public static readonly string contentUssClassName; //Field offset: 0x1D8
	public static readonly string inputUssClassName; //Field offset: 0x1E0
	public static readonly string checkmarkUssClassName; //Field offset: 0x1E8
	public static readonly string textUssClassName; //Field offset: 0x1F0
	internal static readonly string toggleInspectorUssClassName; //Field offset: 0x1F8
	internal static readonly string ussFoldoutDepthClassName; //Field offset: 0x200
	internal static readonly int ussFoldoutMaxDepth; //Field offset: 0x208
	private readonly Toggle m_Toggle; //Field offset: 0x4B8
	private VisualElement m_Container; //Field offset: 0x4C0
	[DontCreateProperty]
	[SerializeField]
	private bool m_Value; //Field offset: 0x4C8
	private KeyboardNavigationManipulator m_NavigationManipulator; //Field offset: 0x4D0

	public virtual VisualElement contentContainer
	{
		 get { } //Length: 8
	}

	public virtual bool focusable
	{
		 get { } //Length: 5
		 set { } //Length: 75
	}

	[CreateProperty]
	public string text
	{
		 get { } //Length: 32
		 set { } //Length: 426
	}

	internal Toggle toggle
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 8
	}

	[CreateProperty]
	public bool toggleOnLabelClick
	{
		 get { } //Length: 33
		 set { } //Length: 144
	}

	[CreateProperty]
	public override bool value
	{
		 get { } //Length: 8
		 set { } //Length: 396
	}

	private static Foldout() { }

	public Foldout() { }

	[CompilerGenerated]
	private void <.ctor>b__39_0(ChangeEvent<Boolean> evt) { }

	private bool Apply(KeyboardNavigationOperation op) { }

	private void Apply(KeyboardNavigationOperation op, EventBase sourceEvent) { }

	public virtual VisualElement get_contentContainer() { }

	public virtual bool get_focusable() { }

	public string get_text() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Toggle get_toggle() { }

	public bool get_toggleOnLabelClick() { }

	public override bool get_value() { }

	private void OnAttachToPanel(AttachToPanelEvent evt) { }

	internal virtual void OnViewDataReady() { }

	public virtual void set_focusable(bool value) { }

	public void set_text(string value) { }

	public void set_toggleOnLabelClick(bool value) { }

	public override void set_value(bool value) { }

	public override void SetValueWithoutNotify(bool newValue) { }

}

