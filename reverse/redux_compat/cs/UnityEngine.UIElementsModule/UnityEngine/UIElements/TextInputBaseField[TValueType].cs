/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[UxmlElement]
	public abstract class TextInputBaseField<TValueType> : BaseField<TValueType>, IDelayedField // TypeDefIndex: 3898
	{
		// Fields
		internal static readonly BindingId autoCorrectionProperty;
		internal static readonly BindingId hideMobileInputProperty;
		internal static readonly BindingId hideSoftKeyboardProperty;
		internal static readonly BindingId hidePlaceholderOnFocusProperty;
		internal static readonly BindingId keyboardTypeProperty;
		internal static readonly BindingId isReadOnlyProperty;
		internal static readonly BindingId isPasswordFieldProperty;
		internal static readonly BindingId textSelectionProperty;
		internal static readonly BindingId textEditionProperty;
		internal static readonly BindingId placeholderTextProperty;
		internal static readonly BindingId cursorIndexProperty;
		internal static readonly BindingId cursorPositionProperty;
		internal static readonly BindingId selectIndexProperty;
		internal static readonly BindingId selectAllOnFocusProperty;
		internal static readonly BindingId selectAllOnMouseUpProperty;
		internal static readonly BindingId maxLengthProperty;
		internal static readonly BindingId doubleClickSelectsWordProperty;
		internal static readonly BindingId tripleClickSelectsLineProperty;
		internal static readonly BindingId emojiFallbackSupportProperty;
		internal static readonly BindingId isDelayedProperty;
		internal static readonly BindingId maskCharProperty;
		internal static readonly BindingId verticalScrollerVisibilityProperty;
		private static CustomStyleProperty<Color> s_SelectionColorProperty;
		private static CustomStyleProperty<Color> s_CursorColorProperty;
		public static readonly string ussClassName;
		internal static readonly UniqueStyleString ussClassNameUnique;
		public static readonly string labelUssClassName;
		internal static readonly UniqueStyleString labelUssClassNameUnique;
		public static readonly string inputUssClassName;
		internal static readonly UniqueStyleString inputUssClassNameUnique;
		internal static readonly string multilineContainerClassName;
		internal static readonly UniqueStyleString multilineContainerClassNameUnique;
		public static readonly string singleLineInputUssClassName;
		internal static readonly UniqueStyleString singleLineInputUssClassNameUnique;
		public static readonly string multilineInputUssClassName;
		internal static readonly UniqueStyleString multilineInputUssClassNameUnique;
		public static readonly string placeholderUssClassName;
		internal static readonly UniqueStyleString placeholderUssClassNameUnique;
		internal static readonly string multilineInputWithScrollViewUssClassName;
		internal static readonly UniqueStyleString multilineInputWithScrollViewUssClassNameUnique;
		public static readonly string textInputUssName;
		internal static readonly UniqueStyleString k_TextInputUssName;
		private TextInputBase m_TextInputBase;
		internal bool m_UpdateTextFromValue;
	
		// Properties
		[CreateProperty]
		[Delayed]
		[UxmlAttribute(obsoleteNames = new string[1] {"maxLength" })]
		public int maxLength { get; set; }
		[CreateProperty]
		[UxmlAttribute("password")]
		public bool isPasswordField { get; set; }
		[CreateProperty]
		[UxmlAttribute("mask-character", obsoleteNames = new string[1] {"maskCharacter" })]
		public char maskChar { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		internal string placeholderText { get; [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] set; }
		[CreateProperty]
		[UxmlAttribute]
		internal bool hidePlaceholderOnFocus { get; set; }
		[CreateProperty]
		[UxmlAttribute("readonly")]
		public bool isReadOnly { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool isDelayed { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public ScrollerVisibility verticalScrollerVisibility { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool selectAllOnMouseUp { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool selectAllOnFocus { get; set; }
		[CreateProperty]
		[UxmlAttribute("select-word-by-double-click")]
		public bool doubleClickSelectsWord { get; set; }
		[CreateProperty]
		[UxmlAttribute("select-line-by-triple-click")]
		public bool tripleClickSelectsLine { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool emojiFallbackSupport { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool hideSoftKeyboard { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool hideMobileInput { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public TouchScreenKeyboardType keyboardType { get; set; }
		[CreateProperty]
		[UxmlAttribute]
		public bool autoCorrection { get; set; }
		protected internal TextInputBase textInputBase { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] get; }
		[CreateProperty(ReadOnly = true)]
		public ITextSelection textSelection { get; }
		[CreateProperty(ReadOnly = true)]
		public ITextEdition textEdition { get; }
		[CreateProperty]
		public int cursorIndex { get; set; }
		[CreateProperty(ReadOnly = true)]
		public Vector2 cursorPosition { get; }
		[CreateProperty]
		public int selectIndex { get; set; }
		public string text { get; [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] protected internal set; }
		private protected override bool canSwitchToMixedValue { get; }
	
		// Nested types
		private static class Callbacks // TypeDefIndex: 3899
		{
			// Fields
			public static readonly EventCallbackDefinition<TextInputBaseField<TValueType>> OnFieldCustomStyleResolved;
			public static readonly EventCallbackDefinition<TextInputBaseField<TValueType>> OnChangeEventUpdatePlaceholderClassList;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3900
			{
				// Fields
				public static readonly __c<TValueType> __9;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal void _.cctor_b__2_0(CustomStyleResolvedEvent e, TextInputBaseField<TValueType> self);
				internal void _.cctor_b__2_1(ChangeEvent<TValueType> e, TextInputBaseField<TValueType> self);
			}
	
			// Constructors
			static Callbacks();
		}
	
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		protected internal abstract class TextInputBase : VisualElement // TypeDefIndex: 3901
		{
			// Fields
			[CompilerGenerated]
			private TextElement _textElement_k__BackingField;
			internal ScrollView scrollView;
			internal VisualElement multilineContainer;
			public static readonly string innerComponentsModifierName;
			internal static readonly UniqueStyleString k_InnerComponentsModifierName;
			public static readonly string innerTextElementUssClassName;
			internal static readonly UniqueStyleString innerTextElementUssClassNameUnique;
			internal static readonly string innerTextElementWithScrollViewUssClassName;
			internal static readonly UniqueStyleString innerTextElementWithScrollViewUssClassNameUnique;
			public static readonly string horizontalVariantInnerTextElementUssClassName;
			internal static readonly UniqueStyleString horizontalVariantInnerTextElementUssClassNameUnique;
			public static readonly string verticalVariantInnerTextElementUssClassName;
			internal static readonly UniqueStyleString verticalVariantInnerTextElementUssClassNameUnique;
			public static readonly string verticalHorizontalVariantInnerTextElementUssClassName;
			internal static readonly UniqueStyleString verticalHorizontalVariantInnerTextElementUssClassNameUnique;
			public static readonly string innerScrollviewUssClassName;
			internal static readonly UniqueStyleString innerScrollviewUssClassNameUnique;
			public static readonly string innerViewportUssClassName;
			internal static readonly UniqueStyleString innerViewportUssClassNameUnique;
			public static readonly string innerContentContainerUssClassName;
			internal static readonly UniqueStyleString innerContentContainerUssClassNameUnique;
			internal Vector2 scrollOffset;
			private bool m_ScrollViewWasClamped;
			private Vector2 lastCursorPos;
			internal ScrollerVisibility verticalScrollerVisibility;
	
			// Properties
			internal TextElement textElement { [VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })] [CompilerGenerated] get; [CompilerGenerated] private set; }
			public ITextSelection textSelection { get; }
			public ITextEdition textEdition { get; }
			public string text { get; set; }
	
			// Nested types
			private static class Callbacks // TypeDefIndex: 3902
			{
				// Fields
				public static readonly EventCallbackDefinition<TextInputBase<TValueType>> OnInputCustomStyleResolved;
				public static readonly EventCallbackDefinition<TextElement> OnTextElementGeometryChangedEvent;
				public static readonly EventCallbackDefinition<VisualElement> OnScrollViewGeometryChangedEvent;
				public static readonly EventCallbackDefinition<Slider> OnScrollViewSliderValueChangedMakeSureScrollViewDoesNotLeakEvents;
	
				// Nested types
				[Serializable]
				[CompilerGenerated]
				private sealed class __c // TypeDefIndex: 3903
				{
					// Fields
					public static readonly __c<TValueType> __9;
	
					// Constructors
					static __c();
					public __c();
	
					// Methods
					internal void _.cctor_b__5_0(CustomStyleResolvedEvent e, TextInputBase<TValueType> self);
					internal void _.cctor_b__5_1(GeometryChangedEvent e, TextElement textElement);
					internal void _.cctor_b__5_2(GeometryChangedEvent e, VisualElement scrollView);
					internal void _.cctor_b__5_3(ChangeEvent<float> e, Slider slider);
				}
	
				// Constructors
				static Callbacks();
	
				// Methods
				private static TextInputBase<TValueType> GetTextInputBase(VisualElement child);
			}
	
			// Constructors
			internal TextInputBase();
			static TextInputBase();
	
			// Methods
			internal void UpdateValueFromText();
			internal void UpdateTextFromValue();
			internal void MoveFocusToCompositeRoot();
			private void MakeSureScrollViewDoesNotLeakEvents(ChangeEvent<float> evt);
			internal void SetSingleLine();
			internal void SetMultiline();
			private void ScrollViewOnGeometryChangedEvent(GeometryChangedEvent e);
			private void TextElementOnGeometryChangedEvent(GeometryChangedEvent e);
			internal void OnInputCustomStyleResolved(CustomStyleResolvedEvent e);
			private string GetDefaultValueType();
			internal virtual bool AcceptCharacter(char c);
			internal void UpdateScrollOffset(bool isBackspace = false /* Metadata: 0x0066048F */);
			internal void UpdateScrollOffset(bool isBackspace, bool widthChanged);
			internal void SetScrollViewMode();
			private void SetMultilineContainerStyle();
			private void RemoveSingleLineComponents();
			private void RemoveMultilineComponents();
			internal bool SetVerticalScrollerVisibility(ScrollerVisibility sv);
		}
	
		// Constructors
		protected TextInputBaseField(string label, int maxLength, char maskChar, TextInputBase textInputBase);
		static TextInputBaseField();
	
		// Methods
		[EventInterest(new Type[5] {typeof(NavigationSubmitEvent), typeof(FocusInEvent), typeof(FocusEvent), typeof(FocusOutEvent), typeof(BlurEvent) })]
		protected override void HandleEventBubbleUp(EventBase evt);
		public override void SetValueWithoutNotify(TValueType newValue);
		protected abstract string ValueToString(TValueType value);
		protected abstract TValueType StringToValue(string str);
		protected override void UpdateMixedValueContent();
		internal void OnPlaceholderChanged();
		internal void UpdatePlaceholderClassList(ChangeEvent<TValueType> evt = null);
		internal virtual void UpdateValueFromText();
		internal virtual void UpdateTextFromValue();
		private void OnFieldCustomStyleResolved(CustomStyleResolvedEvent e);
	}
}
