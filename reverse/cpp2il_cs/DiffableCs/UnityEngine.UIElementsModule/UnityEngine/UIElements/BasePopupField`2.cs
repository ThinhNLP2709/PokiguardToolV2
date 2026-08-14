namespace UnityEngine.UIElements;

[MovedFrom(True, "UnityEditor.UIElements", "UnityEditor.UIElementsModule", null)]
public abstract class BasePopupField : BaseField<TValueType>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TValueType, TValueChoice> <>9; //Field offset: 0x0
		public static EventCallback<MouseDownEvent> <>9__27_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__27_0(MouseDownEvent e) { }

	}

	private class PopupTextElement : TextElement
	{

		public PopupTextElement() { }

		protected private virtual Vector2 DoMeasure(float desiredWidth, MeasureMode widthMode, float desiredHeight, MeasureMode heightMode) { }

	}

	internal static readonly BindingId choicesProperty; //Field offset: 0x0
	internal static readonly BindingId textProperty; //Field offset: 0x0
	public static readonly string ussClassName; //Field offset: 0x0
	public static readonly string textUssClassName; //Field offset: 0x0
	public static readonly string arrowUssClassName; //Field offset: 0x0
	public static readonly string labelUssClassName; //Field offset: 0x0
	public static readonly string inputUssClassName; //Field offset: 0x0
	internal List<TValueChoice> m_Choices; //Field offset: 0x0
	private TextElement m_TextElement; //Field offset: 0x0
	private VisualElement m_ArrowElement; //Field offset: 0x0
	internal Func<TValueChoice, String> m_FormatSelectedValueCallback; //Field offset: 0x0
	internal Func<TValueChoice, String> m_FormatListItemCallback; //Field offset: 0x0
	internal Func<IGenericMenu> createMenuCallback; //Field offset: 0x0
	internal bool m_AutoCloseMenu; //Field offset: 0x0

	[CreateProperty]
	public override List<TValueChoice> choices
	{
		 get { } //Length: 10
		 set { } //Length: 262
	}

	[CreateProperty(ReadOnly = True)]
	public string text
	{
		 get { } //Length: 45
	}

	protected TextElement textElement
	{
		 get { } //Length: 10
	}

	private static BasePopupField`2() { }

	internal BasePopupField`2(string label) { }

	internal abstract void AddMenuItems(IGenericMenu menu) { }

	private bool ContainsPointer(int pointerId) { }

	public override List<TValueChoice> get_choices() { }

	public string get_text() { }

	protected TextElement get_textElement() { }

	internal abstract string GetListItemToDisplay(TValueType item) { }

	internal abstract string GetValueToDisplay() { }

	private void OnNavigationSubmit(NavigationSubmitEvent evt) { }

	private void OnPointerDownEvent(PointerDownEvent evt) { }

	private void OnPointerMoveEvent(PointerMoveEvent evt) { }

	private void ProcessPointerDown(PointerEventBase<T> evt) { }

	public override void set_choices(List<TValueChoice> value) { }

	public virtual void SetValueWithoutNotify(TValueType newValue) { }

	internal void ShowMenu() { }

	protected virtual void UpdateMixedValueContent() { }

}

