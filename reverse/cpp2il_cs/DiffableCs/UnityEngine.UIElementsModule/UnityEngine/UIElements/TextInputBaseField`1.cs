namespace UnityEngine.UIElements;

public abstract class TextInputBaseField : BaseField<TValueType>, IDelayedField
{
	private abstract class TextInputBase : VisualElement
	{
		public static readonly string verticalHorizontalVariantInnerTextElementUssClassName; //Field offset: 0x0
		public static readonly string innerComponentsModifierName; //Field offset: 0x0
		public static readonly string innerTextElementUssClassName; //Field offset: 0x0
		internal static readonly string innerTextElementWithScrollViewUssClassName; //Field offset: 0x0
		public static readonly string horizontalVariantInnerTextElementUssClassName; //Field offset: 0x0
		public static readonly string verticalVariantInnerTextElementUssClassName; //Field offset: 0x0
		public static readonly string innerScrollviewUssClassName; //Field offset: 0x0
		public static readonly string innerViewportUssClassName; //Field offset: 0x0
		public static readonly string innerContentContainerUssClassName; //Field offset: 0x0
		private bool m_ScrollViewWasClamped; //Field offset: 0x0
		internal Vector2 scrollOffset; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private bool <isDragging>k__BackingField; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private TextElement <textElement>k__BackingField; //Field offset: 0x0
		internal VisualElement multilineContainer; //Field offset: 0x0
		internal ScrollView scrollView; //Field offset: 0x0
		private Vector2 lastCursorPos; //Field offset: 0x0
		internal ScrollerVisibility verticalScrollerVisibility; //Field offset: 0x0

		internal bool isDragging
		{
			[CompilerGenerated]
			internal set { } //Length: 7
		}

		internal string originalText
		{
			internal get { } //Length: 33
		}

		public string text
		{
			 get { } //Length: 45
			 set { } //Length: 115
		}

		public ITextEdition textEdition
		{
			 get { } //Length: 32
		}

		internal TextElement textElement
		{
			[CompilerGenerated]
			internal get { } //Length: 8
			[CompilerGenerated]
			private set { } //Length: 19
		}

		public ITextSelection textSelection
		{
			 get { } //Length: 32
		}

		private static TextInputBase() { }

		internal TextInputBase() { }

		internal override bool AcceptCharacter(char c) { }

		internal string get_originalText() { }

		public string get_text() { }

		public ITextEdition get_textEdition() { }

		[CompilerGenerated]
		internal TextElement get_textElement() { }

		public ITextSelection get_textSelection() { }

		private string GetDefaultValueType() { }

		private Vector2 GetScrollOffset(float xOffset, float yOffset, float contentViewportWidth, bool isBackspace, bool widthChanged) { }

		private void MakeSureScrollViewDoesNotLeakEvents(ChangeEvent<Single> evt) { }

		internal void MoveFocusToCompositeRoot() { }

		internal void OnInputCustomStyleResolved(CustomStyleResolvedEvent e) { }

		private void RemoveMultilineComponents() { }

		private void RemoveSingleLineComponents() { }

		private void ScrollViewOnGeometryChangedEvent(GeometryChangedEvent e) { }

		[CompilerGenerated]
		internal void set_isDragging(bool value) { }

		public void set_text(string value) { }

		[CompilerGenerated]
		private void set_textElement(TextElement value) { }

		internal void SetMultiline() { }

		private void SetMultilineContainerStyle() { }

		internal void SetScrollViewMode() { }

		internal void SetSingleLine() { }

		internal bool SetVerticalScrollerVisibility(ScrollerVisibility sv) { }

		protected override TValueType StringToValue(string str) { }

		private void TextElementOnGeometryChangedEvent(GeometryChangedEvent e) { }

		internal void UpdateScrollOffset(bool isBackspace = false) { }

		internal void UpdateScrollOffset(bool isBackspace, bool widthChanged) { }

		internal void UpdateTextFromValue() { }

		internal void UpdateValueFromText() { }

	}

	[Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
	internal class UxmlTraits : BaseFieldTraits<String, UxmlStringAttributeDescription>
	{
		private UxmlIntAttributeDescription m_MaxLength; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_Password; //Field offset: 0x0
		private UxmlStringAttributeDescription m_MaskCharacter; //Field offset: 0x0
		private UxmlStringAttributeDescription m_PlaceholderText; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_HidePlaceholderOnFocus; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_IsReadOnly; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_IsDelayed; //Field offset: 0x0
		private UxmlEnumAttributeDescription<ScrollerVisibility> m_VerticalScrollerVisibility; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_SelectAllOnMouseUp; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_SelectAllOnFocus; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_SelectWordByDoubleClick; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_SelectLineByTripleClick; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_EmojiFallbackSupport; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_HideMobileInput; //Field offset: 0x0
		private UxmlEnumAttributeDescription<TouchScreenKeyboardType> m_KeyboardType; //Field offset: 0x0
		private UxmlBoolAttributeDescription m_AutoCorrection; //Field offset: 0x0

		public UxmlTraits() { }

		public virtual void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) { }

	}

	internal static readonly BindingId autoCorrectionProperty; //Field offset: 0x0
	internal static readonly BindingId emojiFallbackSupportProperty; //Field offset: 0x0
	internal static readonly BindingId isDelayedProperty; //Field offset: 0x0
	internal static readonly BindingId maskCharProperty; //Field offset: 0x0
	internal static readonly BindingId verticalScrollerVisibilityProperty; //Field offset: 0x0
	private static CustomStyleProperty<Color> s_SelectionColorProperty; //Field offset: 0x0
	private static CustomStyleProperty<Color> s_CursorColorProperty; //Field offset: 0x0
	internal static readonly BindingId tripleClickSelectsLineProperty; //Field offset: 0x0
	public static readonly string ussClassName; //Field offset: 0x0
	public static readonly string inputUssClassName; //Field offset: 0x0
	internal static readonly string multilineContainerClassName; //Field offset: 0x0
	public static readonly string singleLineInputUssClassName; //Field offset: 0x0
	public static readonly string multilineInputUssClassName; //Field offset: 0x0
	public static readonly string placeholderUssClassName; //Field offset: 0x0
	internal static readonly string multilineInputWithScrollViewUssClassName; //Field offset: 0x0
	public static readonly string labelUssClassName; //Field offset: 0x0
	public static readonly string textInputUssName; //Field offset: 0x0
	internal static readonly BindingId doubleClickSelectsWordProperty; //Field offset: 0x0
	internal static readonly BindingId selectAllOnMouseUpProperty; //Field offset: 0x0
	internal static readonly BindingId hideMobileInputProperty; //Field offset: 0x0
	internal static readonly BindingId hidePlaceholderOnFocusProperty; //Field offset: 0x0
	internal static readonly BindingId keyboardTypeProperty; //Field offset: 0x0
	internal static readonly BindingId isReadOnlyProperty; //Field offset: 0x0
	internal static readonly BindingId isPasswordFieldProperty; //Field offset: 0x0
	internal static readonly BindingId textSelectionProperty; //Field offset: 0x0
	internal static readonly BindingId maxLengthProperty; //Field offset: 0x0
	internal static readonly BindingId textEditionProperty; //Field offset: 0x0
	internal static readonly BindingId selectionColorProperty; //Field offset: 0x0
	internal static readonly BindingId cursorColorProperty; //Field offset: 0x0
	internal static readonly BindingId cursorIndexProperty; //Field offset: 0x0
	internal static readonly BindingId cursorPositionProperty; //Field offset: 0x0
	internal static readonly BindingId selectIndexProperty; //Field offset: 0x0
	internal static readonly BindingId selectAllOnFocusProperty; //Field offset: 0x0
	internal static readonly BindingId placeholderTextProperty; //Field offset: 0x0
	private TextInputBase<TValueType> m_TextInputBase; //Field offset: 0x0

	[CreateProperty]
	public bool autoCorrection
	{
		 get { } //Length: 103
		 set { } //Length: 321
	}

	[CreateProperty(ReadOnly = True)]
	public Color cursorColor
	{
		 get { } //Length: 239
	}

	[CreateProperty]
	public int cursorIndex
	{
		 get { } //Length: 103
		 set { } //Length: 325
	}

	[CreateProperty(ReadOnly = True)]
	public Vector2 cursorPosition
	{
		 get { } //Length: 103
	}

	[CreateProperty]
	public bool doubleClickSelectsWord
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public bool emojiFallbackSupport
	{
		 get { } //Length: 45
		 set { } //Length: 263
	}

	[CreateProperty]
	public bool hideMobileInput
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	internal bool hidePlaceholderOnFocus
	{
		internal get { } //Length: 103
		internal set { } //Length: 328
	}

	[CreateProperty]
	public override bool isDelayed
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public bool isPasswordField
	{
		 get { } //Length: 103
		 set { } //Length: 357
	}

	[CreateProperty]
	public bool isReadOnly
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public TouchScreenKeyboardType keyboardType
	{
		 get { } //Length: 103
		 set { } //Length: 325
	}

	[CreateProperty]
	public char maskChar
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public int maxLength
	{
		 get { } //Length: 103
		 set { } //Length: 325
	}

	protected Action<Boolean> onIsReadOnlyChanged
	{
		 get { } //Length: 45
		 set { } //Length: 56
	}

	internal bool password
	{
		internal set { } //Length: 119
	}

	[CreateProperty]
	internal string placeholderText
	{
		internal get { } //Length: 103
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal set { } //Length: 340
	}

	internal bool readOnly
	{
		internal set { } //Length: 340
	}

	[CreateProperty]
	public bool selectAllOnFocus
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public bool selectAllOnMouseUp
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public int selectIndex
	{
		 get { } //Length: 103
		 set { } //Length: 325
	}

	[CreateProperty(ReadOnly = True)]
	public Color selectionColor
	{
		 get { } //Length: 239
	}

	public private string text
	{
		 get { } //Length: 45
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		private set { } //Length: 45
	}

	[CreateProperty(ReadOnly = True)]
	public ITextEdition textEdition
	{
		 get { } //Length: 44
	}

	protected private TextInputBase<TValueType> textInputBase
	{
		private get { } //Length: 8
	}

	[CreateProperty(ReadOnly = True)]
	public ITextSelection textSelection
	{
		 get { } //Length: 44
	}

	[CreateProperty]
	public bool tripleClickSelectsLine
	{
		 get { } //Length: 103
		 set { } //Length: 328
	}

	[CreateProperty]
	public ScrollerVisibility verticalScrollerVisibility
	{
		 get { } //Length: 32
		 set { } //Length: 196
	}

	private static TextInputBaseField`1() { }

	protected TextInputBaseField`1(string label, int maxLength, char maskChar, TextInputBase<TValueType> textInputBase) { }

	public bool get_autoCorrection() { }

	public Color get_cursorColor() { }

	public int get_cursorIndex() { }

	public Vector2 get_cursorPosition() { }

	public bool get_doubleClickSelectsWord() { }

	public bool get_emojiFallbackSupport() { }

	public bool get_hideMobileInput() { }

	internal bool get_hidePlaceholderOnFocus() { }

	public override bool get_isDelayed() { }

	public bool get_isPasswordField() { }

	public bool get_isReadOnly() { }

	public TouchScreenKeyboardType get_keyboardType() { }

	public char get_maskChar() { }

	public int get_maxLength() { }

	protected Action<Boolean> get_onIsReadOnlyChanged() { }

	internal string get_placeholderText() { }

	public bool get_selectAllOnFocus() { }

	public bool get_selectAllOnMouseUp() { }

	public int get_selectIndex() { }

	public Color get_selectionColor() { }

	public string get_text() { }

	public ITextEdition get_textEdition() { }

	protected private TextInputBase<TValueType> get_textInputBase() { }

	public ITextSelection get_textSelection() { }

	public bool get_tripleClickSelectsLine() { }

	public ScrollerVisibility get_verticalScrollerVisibility() { }

	[EventInterest(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(NavigationSubmitEvent), typeof(FocusInEvent), typeof(FocusEvent), typeof(FocusOutEvent), typeof(BlurEvent)})]
	protected virtual void HandleEventBubbleUp(EventBase evt) { }

	private void OnFieldCustomStyleResolved(CustomStyleResolvedEvent e) { }

	internal void OnPlaceholderChanged() { }

	public void set_autoCorrection(bool value) { }

	public void set_cursorIndex(int value) { }

	public void set_doubleClickSelectsWord(bool value) { }

	public void set_emojiFallbackSupport(bool value) { }

	public void set_hideMobileInput(bool value) { }

	internal void set_hidePlaceholderOnFocus(bool value) { }

	public void set_isDelayed(bool value) { }

	public void set_isPasswordField(bool value) { }

	public void set_isReadOnly(bool value) { }

	public void set_keyboardType(TouchScreenKeyboardType value) { }

	public void set_maskChar(char value) { }

	public void set_maxLength(int value) { }

	protected void set_onIsReadOnlyChanged(Action<Boolean> value) { }

	internal void set_password(bool value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void set_placeholderText(string value) { }

	internal void set_readOnly(bool value) { }

	public void set_selectAllOnFocus(bool value) { }

	public void set_selectAllOnMouseUp(bool value) { }

	public void set_selectIndex(int value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	protected private void set_text(string value) { }

	public void set_tripleClickSelectsLine(bool value) { }

	public void set_verticalScrollerVisibility(ScrollerVisibility value) { }

	protected abstract TValueType StringToValue(string str) { }

	protected virtual void UpdateMixedValueContent() { }

	internal void UpdatePlaceholderClassList(ChangeEvent<TValueType> evt = null) { }

	internal override void UpdateTextFromValue() { }

	internal override void UpdateValueFromText() { }

	protected abstract string ValueToString(TValueType value) { }

}

