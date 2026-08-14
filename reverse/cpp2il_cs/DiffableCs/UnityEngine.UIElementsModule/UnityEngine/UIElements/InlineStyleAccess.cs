namespace UnityEngine.UIElements;

internal class InlineStyleAccess : StyleValueCollection, IStyle
{
	public struct InlineRule
	{
		public StyleSheet sheet; //Field offset: 0x0
		public StyleRule rule; //Field offset: 0x8
		public StylePropertyId[] propertyIds; //Field offset: 0x10

	}

	private static StylePropertyReader s_StylePropertyReader; //Field offset: 0x0
	private List<StyleValueManaged> m_ValuesManaged; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <ve>k__BackingField; //Field offset: 0x20
	private bool m_HasInlineCursor; //Field offset: 0x28
	private StyleCursor m_InlineCursor; //Field offset: 0x30
	private bool m_HasInlineTextShadow; //Field offset: 0x50
	private StyleTextShadow m_InlineTextShadow; //Field offset: 0x54
	private bool m_HasInlineTransformOrigin; //Field offset: 0x74
	private StyleTransformOrigin m_InlineTransformOrigin; //Field offset: 0x78
	private bool m_HasInlineTranslate; //Field offset: 0x90
	private StyleTranslate m_InlineTranslateOperation; //Field offset: 0x94
	private bool m_HasInlineRotate; //Field offset: 0xB0
	private StyleRotate m_InlineRotateOperation; //Field offset: 0xB4
	private bool m_HasInlineScale; //Field offset: 0xD0
	private StyleScale m_InlineScale; //Field offset: 0xD4
	private bool m_HasInlineBackgroundSize; //Field offset: 0xE8
	public StyleBackgroundSize m_InlineBackgroundSize; //Field offset: 0xEC
	private InlineRule m_InlineRule; //Field offset: 0x108

	private override StyleEnum<Align> UnityEngine.UIElements.IStyle.alignContent
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleEnum<Align> UnityEngine.UIElements.IStyle.alignItems
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleEnum<Align> UnityEngine.UIElements.IStyle.alignSelf
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleColor UnityEngine.UIElements.IStyle.backgroundColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleBackground UnityEngine.UIElements.IStyle.backgroundImage
	{
		private get { } //Length: 77
		private set { } //Length: 97
	}

	private override StyleBackgroundPosition UnityEngine.UIElements.IStyle.backgroundPositionX
	{
		private get { } //Length: 49
		private set { } //Length: 77
	}

	private override StyleBackgroundPosition UnityEngine.UIElements.IStyle.backgroundPositionY
	{
		private get { } //Length: 49
		private set { } //Length: 77
	}

	private override StyleBackgroundRepeat UnityEngine.UIElements.IStyle.backgroundRepeat
	{
		private get { } //Length: 59
		private set { } //Length: 361
	}

	private override StyleBackgroundSize UnityEngine.UIElements.IStyle.backgroundSize
	{
		private get { } //Length: 104
		private set { } //Length: 364
	}

	private override StyleColor UnityEngine.UIElements.IStyle.borderBottomColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleLength UnityEngine.UIElements.IStyle.borderBottomLeftRadius
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleLength UnityEngine.UIElements.IStyle.borderBottomRightRadius
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.borderBottomWidth
	{
		private get { } //Length: 15
		private set { } //Length: 131
	}

	private override StyleColor UnityEngine.UIElements.IStyle.borderLeftColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.borderLeftWidth
	{
		private get { } //Length: 15
		private set { } //Length: 131
	}

	private override StyleColor UnityEngine.UIElements.IStyle.borderRightColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.borderRightWidth
	{
		private get { } //Length: 15
		private set { } //Length: 131
	}

	private override StyleColor UnityEngine.UIElements.IStyle.borderTopColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleLength UnityEngine.UIElements.IStyle.borderTopLeftRadius
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleLength UnityEngine.UIElements.IStyle.borderTopRightRadius
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.borderTopWidth
	{
		private get { } //Length: 15
		private set { } //Length: 131
	}

	private override StyleLength UnityEngine.UIElements.IStyle.bottom
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleColor UnityEngine.UIElements.IStyle.color
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleCursor UnityEngine.UIElements.IStyle.cursor
	{
		private get { } //Length: 132
		private set { } //Length: 471
	}

	private override StyleEnum<DisplayStyle> UnityEngine.UIElements.IStyle.display
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleLength UnityEngine.UIElements.IStyle.flexBasis
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleEnum<FlexDirection> UnityEngine.UIElements.IStyle.flexDirection
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.flexGrow
	{
		private get { } //Length: 15
		private set { } //Length: 131
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.flexShrink
	{
		private get { } //Length: 15
		private set { } //Length: 131
	}

	private override StyleEnum<Wrap> UnityEngine.UIElements.IStyle.flexWrap
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleLength UnityEngine.UIElements.IStyle.fontSize
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleLength UnityEngine.UIElements.IStyle.height
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleEnum<Justify> UnityEngine.UIElements.IStyle.justifyContent
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleLength UnityEngine.UIElements.IStyle.left
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.letterSpacing
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleLength UnityEngine.UIElements.IStyle.marginBottom
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.marginLeft
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.marginRight
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.marginTop
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.maxHeight
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.maxWidth
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.minHeight
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.minWidth
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.opacity
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleEnum<Overflow> UnityEngine.UIElements.IStyle.overflow
	{
		private get { } //Length: 126
		private set { } //Length: 274
	}

	private override StyleLength UnityEngine.UIElements.IStyle.paddingBottom
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.paddingLeft
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.paddingRight
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.paddingTop
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleEnum<Position> UnityEngine.UIElements.IStyle.position
	{
		private get { } //Length: 126
		private set { } //Length: 167
	}

	private override StyleLength UnityEngine.UIElements.IStyle.right
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleRotate UnityEngine.UIElements.IStyle.rotate
	{
		private get { } //Length: 122
		private set { } //Length: 423
	}

	private override StyleScale UnityEngine.UIElements.IStyle.scale
	{
		private get { } //Length: 95
		private set { } //Length: 356
	}

	private override StyleEnum<TextOverflow> UnityEngine.UIElements.IStyle.textOverflow
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleTextShadow UnityEngine.UIElements.IStyle.textShadow
	{
		private get { } //Length: 90
		private set { } //Length: 449
	}

	private override StyleLength UnityEngine.UIElements.IStyle.top
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleTransformOrigin UnityEngine.UIElements.IStyle.transformOrigin
	{
		private get { } //Length: 98
		private set { } //Length: 349
	}

	private override StyleList<TimeValue> UnityEngine.UIElements.IStyle.transitionDelay
	{
		private get { } //Length: 98
		private set { } //Length: 119
	}

	private override StyleList<TimeValue> UnityEngine.UIElements.IStyle.transitionDuration
	{
		private get { } //Length: 98
		private set { } //Length: 119
	}

	private override StyleList<StylePropertyName> UnityEngine.UIElements.IStyle.transitionProperty
	{
		private get { } //Length: 98
		private set { } //Length: 119
	}

	private override StyleList<EasingFunction> UnityEngine.UIElements.IStyle.transitionTimingFunction
	{
		private get { } //Length: 98
		private set { } //Length: 119
	}

	private override StyleTranslate UnityEngine.UIElements.IStyle.translate
	{
		private get { } //Length: 122
		private set { } //Length: 423
	}

	private override StyleColor UnityEngine.UIElements.IStyle.unityBackgroundImageTintColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleEnum<EditorTextRenderingMode> UnityEngine.UIElements.IStyle.unityEditorTextRenderingMode
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleFont UnityEngine.UIElements.IStyle.unityFont
	{
		private get { } //Length: 49
		private set { } //Length: 77
	}

	private override StyleFontDefinition UnityEngine.UIElements.IStyle.unityFontDefinition
	{
		private get { } //Length: 65
		private set { } //Length: 88
	}

	private override StyleEnum<FontStyle> UnityEngine.UIElements.IStyle.unityFontStyleAndWeight
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleEnum<OverflowClipBox> UnityEngine.UIElements.IStyle.unityOverflowClipBox
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleLength UnityEngine.UIElements.IStyle.unityParagraphSpacing
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private override StyleInt UnityEngine.UIElements.IStyle.unitySliceBottom
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleInt UnityEngine.UIElements.IStyle.unitySliceLeft
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleInt UnityEngine.UIElements.IStyle.unitySliceRight
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.unitySliceScale
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleInt UnityEngine.UIElements.IStyle.unitySliceTop
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleEnum<TextAnchor> UnityEngine.UIElements.IStyle.unityTextAlign
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleEnum<TextGeneratorType> UnityEngine.UIElements.IStyle.unityTextGenerator
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleColor UnityEngine.UIElements.IStyle.unityTextOutlineColor
	{
		private get { } //Length: 60
		private set { } //Length: 84
	}

	private override StyleFloat UnityEngine.UIElements.IStyle.unityTextOutlineWidth
	{
		private get { } //Length: 15
		private set { } //Length: 67
	}

	private override StyleEnum<TextOverflowPosition> UnityEngine.UIElements.IStyle.unityTextOverflowPosition
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleEnum<Visibility> UnityEngine.UIElements.IStyle.visibility
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleEnum<WhiteSpace> UnityEngine.UIElements.IStyle.whiteSpace
	{
		private get { } //Length: 126
		private set { } //Length: 109
	}

	private override StyleLength UnityEngine.UIElements.IStyle.width
	{
		private get { } //Length: 59
		private set { } //Length: 160
	}

	private override StyleLength UnityEngine.UIElements.IStyle.wordSpacing
	{
		private get { } //Length: 59
		private set { } //Length: 86
	}

	private VisualElement ve
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private static InlineStyleAccess() { }

	public InlineStyleAccess(VisualElement ve) { }

	private void ApplyFromComputedStyle(StylePropertyId id, ref ComputedStyle newStyle) { }

	public void ApplyInlineStyles(ref ComputedStyle computedStyle) { }

	private void ApplyStyleBackgroundSize(StyleBackgroundSize backgroundSize) { }

	private void ApplyStyleCursor(StyleCursor cursor) { }

	private void ApplyStyleRotate(StyleRotate rotate) { }

	private void ApplyStyleScale(StyleScale scale) { }

	private void ApplyStyleTextShadow(StyleTextShadow textShadow) { }

	private void ApplyStyleTransformOrigin(StyleTransformOrigin transformOrigin) { }

	private void ApplyStyleTranslate(StyleTranslate translate) { }

	private void ApplyStyleValue(StyleValueManaged value) { }

	private void ApplyStyleValue(StyleValue value) { }

	protected virtual void Finalize() { }

	[CompilerGenerated]
	private VisualElement get_ve() { }

	private StyleList<T> GetStyleList(StylePropertyId id) { }

	public bool IsValueSet(StylePropertyId id) { }

	private bool RemoveInlineStyle(StylePropertyId id) { }

	[CompilerGenerated]
	private void set_ve(VisualElement value) { }

	private bool SetInlineBackgroundSize(StyleBackgroundSize inlineValue) { }

	private bool SetInlineCursor(StyleCursor inlineValue) { }

	private bool SetInlineRotate(StyleRotate inlineValue) { }

	public void SetInlineRule(StyleSheet sheet, StyleRule rule) { }

	private bool SetInlineScale(StyleScale inlineValue) { }

	private bool SetInlineTextShadow(StyleTextShadow inlineValue) { }

	private bool SetInlineTransformOrigin(StyleTransformOrigin inlineValue) { }

	private bool SetInlineTranslate(StyleTranslate inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleList<T> inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleFontDefinition inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleBackground inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleEnum<T> inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleColor inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleInt inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleFloat inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleLength inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleBackgroundRepeat inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleBackgroundPosition inlineValue) { }

	private bool SetStyleValue(StylePropertyId id, StyleFont inlineValue) { }

	private void SetStyleValueManaged(StyleValueManaged value) { }

	public bool TryGetInlineBackgroundSize(ref StyleBackgroundSize value) { }

	public bool TryGetInlineCursor(ref StyleCursor value) { }

	public bool TryGetInlineRotate(ref StyleRotate value) { }

	public bool TryGetInlineScale(ref StyleScale value) { }

	public bool TryGetInlineTextShadow(ref StyleTextShadow value) { }

	public bool TryGetInlineTransformOrigin(ref StyleTransformOrigin value) { }

	public bool TryGetInlineTranslate(ref StyleTranslate value) { }

	private bool TryGetStyleValueManaged(StylePropertyId id, ref StyleValueManaged value) { }

	private override StyleEnum<Align> UnityEngine.UIElements.IStyle.get_alignContent() { }

	private override StyleEnum<Align> UnityEngine.UIElements.IStyle.get_alignItems() { }

	private override StyleEnum<Align> UnityEngine.UIElements.IStyle.get_alignSelf() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_backgroundColor() { }

	private override StyleBackground UnityEngine.UIElements.IStyle.get_backgroundImage() { }

	private override StyleBackgroundPosition UnityEngine.UIElements.IStyle.get_backgroundPositionX() { }

	private override StyleBackgroundPosition UnityEngine.UIElements.IStyle.get_backgroundPositionY() { }

	private override StyleBackgroundRepeat UnityEngine.UIElements.IStyle.get_backgroundRepeat() { }

	private override StyleBackgroundSize UnityEngine.UIElements.IStyle.get_backgroundSize() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_borderBottomColor() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_borderBottomLeftRadius() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_borderBottomRightRadius() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_borderBottomWidth() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_borderLeftColor() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_borderLeftWidth() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_borderRightColor() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_borderRightWidth() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_borderTopColor() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_borderTopLeftRadius() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_borderTopRightRadius() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_borderTopWidth() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_bottom() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_color() { }

	private override StyleCursor UnityEngine.UIElements.IStyle.get_cursor() { }

	private override StyleEnum<DisplayStyle> UnityEngine.UIElements.IStyle.get_display() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_flexBasis() { }

	private override StyleEnum<FlexDirection> UnityEngine.UIElements.IStyle.get_flexDirection() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_flexGrow() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_flexShrink() { }

	private override StyleEnum<Wrap> UnityEngine.UIElements.IStyle.get_flexWrap() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_fontSize() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_height() { }

	private override StyleEnum<Justify> UnityEngine.UIElements.IStyle.get_justifyContent() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_left() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_letterSpacing() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_marginBottom() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_marginLeft() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_marginRight() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_marginTop() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_maxHeight() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_maxWidth() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_minHeight() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_minWidth() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_opacity() { }

	private override StyleEnum<Overflow> UnityEngine.UIElements.IStyle.get_overflow() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_paddingBottom() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_paddingLeft() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_paddingRight() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_paddingTop() { }

	private override StyleEnum<Position> UnityEngine.UIElements.IStyle.get_position() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_right() { }

	private override StyleRotate UnityEngine.UIElements.IStyle.get_rotate() { }

	private override StyleScale UnityEngine.UIElements.IStyle.get_scale() { }

	private override StyleEnum<TextOverflow> UnityEngine.UIElements.IStyle.get_textOverflow() { }

	private override StyleTextShadow UnityEngine.UIElements.IStyle.get_textShadow() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_top() { }

	private override StyleTransformOrigin UnityEngine.UIElements.IStyle.get_transformOrigin() { }

	private override StyleList<TimeValue> UnityEngine.UIElements.IStyle.get_transitionDelay() { }

	private override StyleList<TimeValue> UnityEngine.UIElements.IStyle.get_transitionDuration() { }

	private override StyleList<StylePropertyName> UnityEngine.UIElements.IStyle.get_transitionProperty() { }

	private override StyleList<EasingFunction> UnityEngine.UIElements.IStyle.get_transitionTimingFunction() { }

	private override StyleTranslate UnityEngine.UIElements.IStyle.get_translate() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_unityBackgroundImageTintColor() { }

	private override StyleEnum<EditorTextRenderingMode> UnityEngine.UIElements.IStyle.get_unityEditorTextRenderingMode() { }

	private override StyleFont UnityEngine.UIElements.IStyle.get_unityFont() { }

	private override StyleFontDefinition UnityEngine.UIElements.IStyle.get_unityFontDefinition() { }

	private override StyleEnum<FontStyle> UnityEngine.UIElements.IStyle.get_unityFontStyleAndWeight() { }

	private override StyleEnum<OverflowClipBox> UnityEngine.UIElements.IStyle.get_unityOverflowClipBox() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_unityParagraphSpacing() { }

	private override StyleInt UnityEngine.UIElements.IStyle.get_unitySliceBottom() { }

	private override StyleInt UnityEngine.UIElements.IStyle.get_unitySliceLeft() { }

	private override StyleInt UnityEngine.UIElements.IStyle.get_unitySliceRight() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_unitySliceScale() { }

	private override StyleInt UnityEngine.UIElements.IStyle.get_unitySliceTop() { }

	private override StyleEnum<TextAnchor> UnityEngine.UIElements.IStyle.get_unityTextAlign() { }

	private override StyleEnum<TextGeneratorType> UnityEngine.UIElements.IStyle.get_unityTextGenerator() { }

	private override StyleColor UnityEngine.UIElements.IStyle.get_unityTextOutlineColor() { }

	private override StyleFloat UnityEngine.UIElements.IStyle.get_unityTextOutlineWidth() { }

	private override StyleEnum<TextOverflowPosition> UnityEngine.UIElements.IStyle.get_unityTextOverflowPosition() { }

	private override StyleEnum<Visibility> UnityEngine.UIElements.IStyle.get_visibility() { }

	private override StyleEnum<WhiteSpace> UnityEngine.UIElements.IStyle.get_whiteSpace() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_width() { }

	private override StyleLength UnityEngine.UIElements.IStyle.get_wordSpacing() { }

	private override void UnityEngine.UIElements.IStyle.set_alignContent(StyleEnum<Align> value) { }

	private override void UnityEngine.UIElements.IStyle.set_alignItems(StyleEnum<Align> value) { }

	private override void UnityEngine.UIElements.IStyle.set_alignSelf(StyleEnum<Align> value) { }

	private override void UnityEngine.UIElements.IStyle.set_backgroundColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_backgroundImage(StyleBackground value) { }

	private override void UnityEngine.UIElements.IStyle.set_backgroundPositionX(StyleBackgroundPosition value) { }

	private override void UnityEngine.UIElements.IStyle.set_backgroundPositionY(StyleBackgroundPosition value) { }

	private override void UnityEngine.UIElements.IStyle.set_backgroundRepeat(StyleBackgroundRepeat value) { }

	private override void UnityEngine.UIElements.IStyle.set_backgroundSize(StyleBackgroundSize value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderBottomColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderBottomLeftRadius(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderBottomRightRadius(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderBottomWidth(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderLeftColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderLeftWidth(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderRightColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderRightWidth(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderTopColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderTopLeftRadius(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderTopRightRadius(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_borderTopWidth(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_bottom(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_color(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_cursor(StyleCursor value) { }

	private override void UnityEngine.UIElements.IStyle.set_display(StyleEnum<DisplayStyle> value) { }

	private override void UnityEngine.UIElements.IStyle.set_flexBasis(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_flexDirection(StyleEnum<FlexDirection> value) { }

	private override void UnityEngine.UIElements.IStyle.set_flexGrow(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_flexShrink(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_flexWrap(StyleEnum<Wrap> value) { }

	private override void UnityEngine.UIElements.IStyle.set_fontSize(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_height(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_justifyContent(StyleEnum<Justify> value) { }

	private override void UnityEngine.UIElements.IStyle.set_left(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_letterSpacing(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_marginBottom(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_marginLeft(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_marginRight(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_marginTop(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_maxHeight(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_maxWidth(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_minHeight(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_minWidth(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_opacity(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_overflow(StyleEnum<Overflow> value) { }

	private override void UnityEngine.UIElements.IStyle.set_paddingBottom(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_paddingLeft(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_paddingRight(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_paddingTop(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_position(StyleEnum<Position> value) { }

	private override void UnityEngine.UIElements.IStyle.set_right(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_rotate(StyleRotate value) { }

	private override void UnityEngine.UIElements.IStyle.set_scale(StyleScale value) { }

	private override void UnityEngine.UIElements.IStyle.set_textOverflow(StyleEnum<TextOverflow> value) { }

	private override void UnityEngine.UIElements.IStyle.set_textShadow(StyleTextShadow value) { }

	private override void UnityEngine.UIElements.IStyle.set_top(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_transformOrigin(StyleTransformOrigin value) { }

	private override void UnityEngine.UIElements.IStyle.set_transitionDelay(StyleList<TimeValue> value) { }

	private override void UnityEngine.UIElements.IStyle.set_transitionDuration(StyleList<TimeValue> value) { }

	private override void UnityEngine.UIElements.IStyle.set_transitionProperty(StyleList<StylePropertyName> value) { }

	private override void UnityEngine.UIElements.IStyle.set_transitionTimingFunction(StyleList<EasingFunction> value) { }

	private override void UnityEngine.UIElements.IStyle.set_translate(StyleTranslate value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityBackgroundImageTintColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityEditorTextRenderingMode(StyleEnum<EditorTextRenderingMode> value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityFont(StyleFont value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityFontDefinition(StyleFontDefinition value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityFontStyleAndWeight(StyleEnum<FontStyle> value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityOverflowClipBox(StyleEnum<OverflowClipBox> value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityParagraphSpacing(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_unitySliceBottom(StyleInt value) { }

	private override void UnityEngine.UIElements.IStyle.set_unitySliceLeft(StyleInt value) { }

	private override void UnityEngine.UIElements.IStyle.set_unitySliceRight(StyleInt value) { }

	private override void UnityEngine.UIElements.IStyle.set_unitySliceScale(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_unitySliceTop(StyleInt value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityTextAlign(StyleEnum<TextAnchor> value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityTextGenerator(StyleEnum<TextGeneratorType> value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityTextOutlineColor(StyleColor value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityTextOutlineWidth(StyleFloat value) { }

	private override void UnityEngine.UIElements.IStyle.set_unityTextOverflowPosition(StyleEnum<TextOverflowPosition> value) { }

	private override void UnityEngine.UIElements.IStyle.set_visibility(StyleEnum<Visibility> value) { }

	private override void UnityEngine.UIElements.IStyle.set_whiteSpace(StyleEnum<WhiteSpace> value) { }

	private override void UnityEngine.UIElements.IStyle.set_width(StyleLength value) { }

	private override void UnityEngine.UIElements.IStyle.set_wordSpacing(StyleLength value) { }

}

