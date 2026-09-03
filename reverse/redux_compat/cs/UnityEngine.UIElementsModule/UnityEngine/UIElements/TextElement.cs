/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.TextCore;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[UxmlElement]
	public class TextElement : BindableElement, INotifyValueChanged<string>, ITextEdition, ITextSelection // TypeDefIndex: 4832
	{
		// Fields
		internal static readonly BindingId displayTooltipWhenElidedProperty; // 0x00
		internal static readonly BindingId emojiFallbackSupportProperty; // 0x98
		internal static readonly BindingId enableRichTextProperty; // 0x130
		internal static readonly BindingId isElidedProperty; // 0x1C8
		internal static readonly BindingId parseEscapeSequencesProperty; // 0x260
		internal static readonly BindingId textProperty; // 0x2F8
		internal static readonly BindingId valueProperty; // 0x390
		public static readonly string ussClassName; // 0x428
		internal static readonly UniqueStyleString ussClassNameUnique; // 0x430
		public static readonly string selectableUssClassName; // 0x438
		internal static readonly UniqueStyleString selectableUssClassNameUnique; // 0x440
		[CompilerGenerated]
		private Action<GlyphsEnumerable> _PostProcessTextVertices_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private UITKTextHandle _uitkTextHandle_k__BackingField; // 0x1C0
		private string m_Text; // 0x1C8
		private NativeTextBuffer m_TextBuffer; // 0x1D0
		private bool m_IsTextBufferDirty; // 0x1E8
		private bool m_EnableRichText; // 0x1E9
		private bool m_EmojiFallbackSupport; // 0x1EA
		private bool m_ParseEscapeSequences; // 0x1EB
		private bool m_DisplayTooltipWhenElided; // 0x1EC
		[CompilerGenerated]
		private bool _isElided_k__BackingField; // 0x1ED
		internal static readonly string k_EllipsisText; // 0x448
		internal string elidedText; // 0x1F0
		private bool m_WasElided; // 0x1F8
		[CompilerGenerated]
		private FontAsset _cachedFontAsset_k__BackingField; // 0x200
		internal static readonly BindingId autoCorrectionProperty; // 0x450
		internal static readonly BindingId hideSoftKeyboardProperty; // 0x4E8
		internal static readonly BindingId hideMobileInputProperty; // 0x580
		internal static readonly BindingId keyboardTypeProperty; // 0x618
		internal static readonly BindingId isReadOnlyProperty; // 0x6B0
		internal static readonly BindingId isPasswordProperty; // 0x748
		internal static readonly BindingId maxLengthProperty; // 0x7E0
		internal static readonly BindingId maskCharProperty; // 0x878
		[CompilerGenerated]
		private TextEditingManipulator _editingManipulator_k__BackingField; // 0x208
		internal bool isInputField; // 0x210
		private bool m_Multiline; // 0x211
		internal TouchScreenKeyboard m_TouchScreenKeyboard; // 0x218
		internal Action<bool> onIsReadOnlyChanged; // 0x220
		internal TouchScreenKeyboardType m_KeyboardType; // 0x228
		private bool m_HideSoftKeyboard; // 0x22C
		private bool m_HideMobileInput; // 0x22D
		private bool m_IsReadOnly; // 0x22E
		private int m_MaxLength; // 0x230
		private string m_PlaceholderText; // 0x238
		[CompilerGenerated]
		private bool _UnityEngine_UIElements_ITextEdition_isDelayed_k__BackingField; // 0x240
		[CompilerGenerated]
		private Func<char, bool> _UnityEngine_UIElements_ITextEdition_AcceptCharacter_k__BackingField; // 0x248
		[CompilerGenerated]
		private Action<bool> _UnityEngine_UIElements_ITextEdition_UpdateScrollOffset_k__BackingField; // 0x250
		[CompilerGenerated]
		private Action _UnityEngine_UIElements_ITextEdition_UpdateValueFromText_k__BackingField; // 0x258
		[CompilerGenerated]
		private Action _UnityEngine_UIElements_ITextEdition_UpdateTextFromValue_k__BackingField; // 0x260
		[CompilerGenerated]
		private Action _UnityEngine_UIElements_ITextEdition_MoveFocusToCompositeRoot_k__BackingField; // 0x268
		[CompilerGenerated]
		private Action _OnPlaceholderChanged_k__BackingField; // 0x270
		[CompilerGenerated]
		private Func<string> _UnityEngine_UIElements_ITextEdition_GetDefaultValueType_k__BackingField; // 0x278
		private string m_RenderedText; // 0x280
		private string m_OriginalText; // 0x288
		private char m_MaskChar; // 0x290
		private bool m_IsPassword; // 0x292
		private bool m_HidePlaceholderTextOnFocus; // 0x293
		private bool m_AutoCorrection; // 0x294
		internal static readonly BindingId isSelectableProperty; // 0x910
		internal static readonly BindingId cursorIndexProperty; // 0x9A8
		internal static readonly BindingId selectIndexProperty; // 0xA40
		internal static readonly BindingId doubleClickSelectsWordProperty; // 0xAD8
		internal static readonly BindingId tripleClickSelectsLineProperty; // 0xB70
		internal static readonly BindingId cursorPositionProperty; // 0xC08
		internal static readonly BindingId selectAllOnFocusProperty; // 0xCA0
		internal static readonly BindingId selectAllOnMouseUpProperty; // 0xD38
		internal static readonly BindingId selectionProperty; // 0xDD0
		private TextSelectingManipulator m_SelectingManipulator; // 0x298
		private bool m_IsSelectable; // 0x2A0
		private bool m_DoubleClickSelectsWord; // 0x2A1
		private bool m_TripleClickSelectsLine; // 0x2A2
		private bool m_SelectAllOnFocus; // 0x2A3
		private bool m_SelectAllOnMouseUp; // 0x2A4
		private Color m_SelectionColor; // 0x2A8
		private Color m_CursorColor; // 0x2B8
		private float m_CursorWidth; // 0x2C8
	
		// Properties
		public Action<GlyphsEnumerable> PostProcessTextVertices { [CompilerGenerated] get; } // 0x000000018033D6C0-0x000000018033D6D0 
		internal UITKTextHandle uitkTextHandle { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		internal ref NativeTextBuffer textBuffer { get; } // 0x00000001823C4280-0x00000001823C4290 
		[CreateProperty]
		public virtual string text { get; set; } // 0x00000001823C4290-0x00000001823C42D0 0x00000001823C4C50-0x00000001823C4CA0
		[CreateProperty]
		[UxmlAttribute]
		public bool enableRichText { get; set; } // 0x0000000181E816D0-0x0000000181E816E0 0x00000001823C4620-0x00000001823C46B0
		[CreateProperty]
		[UxmlAttribute]
		public bool emojiFallbackSupport { get; set; } // 0x00000001823C3740-0x00000001823C3750 0x00000001823C4590-0x00000001823C4620
		[CreateProperty]
		[UxmlAttribute]
		public bool parseEscapeSequences { get; set; } // 0x00000001823C3BC0-0x00000001823C3BD0 0x00000001823C4A20-0x00000001823C4AB0
		[CreateProperty]
		[SelectableTextElement]
		[UxmlAttribute("selectable")]
		internal bool isSelectable { get; set; } // 0x00000001823C3900-0x00000001823C3950 0x00000001823C4840-0x00000001823C48A0
		[CreateProperty]
		[UxmlAttribute(obsoleteNames = new string[2] {"selectWordByDoubleClick", "select-word-by-double-click" })]
		internal bool doubleClickSelectsWord { get; set; } // 0x00000001823C3690-0x00000001823C36E0 0x00000001823C4530-0x00000001823C4590
		[CreateProperty]
		[UxmlAttribute(obsoleteNames = new string[2] {"selectLineByTripleClick", "select-line-by-triple-click" })]
		internal bool tripleClickSelectsLine { get; set; } // 0x00000001823C42D0-0x00000001823C4320 0x00000001823C4CA0-0x00000001823C4D00
		[CreateProperty]
		[UxmlAttribute]
		public bool displayTooltipWhenElided { get; set; } // 0x00000001823C3680-0x00000001823C3690 0x00000001823C44A0-0x00000001823C4530
		[CreateProperty(ReadOnly = true)]
		public bool isElided { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001823C3850-0x00000001823C3860 0x00000001823C4770-0x00000001823C4780
		internal bool hasFocus { get; } // 0x00000001823C3750-0x00000001823C37B0 
		string UnityEngine.UIElements.INotifyValueChanged<System.String>.value { get; set; } // 0x00000001823C0270-0x00000001823C02D0 0x00000001823C02D0-0x00000001823C0530
		[CreateProperty]
		private string value { get; set; } // 0x00000001823C4320-0x00000001823C4360 0x00000001823C4D00-0x00000001823C4D50
		internal FontAsset cachedFontAsset { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		internal ITextEdition edition { get; } // 0x0000000180370C60-0x0000000180370C70 
		internal TextEditingManipulator editingManipulator { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181CC28E0-0x0000000181CC28F0 0x0000000181380170-0x0000000181380190
		bool ITextEdition.multiline { get; set; } // 0x00000001823C0920-0x00000001823C0930 0x00000001823C1050-0x00000001823C10D0
		TouchScreenKeyboard ITextEdition.touchScreenKeyboard { get; } // 0x0000000181CC2910-0x0000000181CC2920 
		TouchScreenKeyboardType ITextEdition.keyboardType { get; set; } // 0x00000001823C08F0-0x00000001823C0900 0x00000001823C0E30-0x00000001823C0EB0
		[CreateProperty]
		private TouchScreenKeyboardType keyboardType { get; set; } // 0x00000001823C3980-0x00000001823C39D0 0x00000001823C48A0-0x00000001823C4900
		bool ITextEdition.hideSoftKeyboard { get; set; } // 0x00000001823C0890-0x00000001823C08A0 0x00000001823C0A90-0x00000001823C0B10
		[CreateProperty]
		private bool hideSoftKeyboard { get; set; } // 0x00000001823C3800-0x00000001823C3850 0x00000001823C4710-0x00000001823C4770
		bool ITextEdition.hideMobileInput { get; set; } // 0x00000001823C0840-0x00000001823C0880 0x00000001823C09F0-0x00000001823C0A80
		[CreateProperty]
		private bool hideMobileInput { get; set; } // 0x00000001823C37B0-0x00000001823C3800 0x00000001823C46B0-0x00000001823C4710
		bool ITextEdition.isReadOnly { get; set; } // 0x00000001823C08C0-0x00000001823C08F0 0x00000001823C0BB0-0x00000001823C0E30
		[CreateProperty]
		private bool isReadOnly { get; set; } // 0x00000001823C38B0-0x00000001823C3900 0x00000001823C47E0-0x00000001823C4840
		int ITextEdition.maxLength { get; set; } // 0x00000001823C0910-0x00000001823C0920 0x00000001823C0F70-0x00000001823C1050
		[CreateProperty]
		private int maxLength { get; set; } // 0x00000001823C3A90-0x00000001823C3AE0 0x00000001823C49C0-0x00000001823C4A20
		string ITextEdition.placeholder { get; set; } // 0x000000018033D3D0-0x000000018033D3E0 0x00000001823C10D0-0x00000001823C12A0
		bool ITextEdition.isDelayed { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823C08A0-0x00000001823C08B0 0x00000001823C0B10-0x00000001823C0B20
		Func<char, bool> ITextEdition.AcceptCharacter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180BBD670-0x0000000180BBD680 0x0000000180BBDDE0-0x0000000180BBDE00
		Action<bool> ITextEdition.UpdateScrollOffset { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D3E0-0x000000018033D3F0 0x000000018033E940-0x000000018033E960
		Action ITextEdition.UpdateValueFromText { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180BBD6B0-0x0000000180BBD6C0 0x0000000180BBDE80-0x0000000180BBDEA0
		Action ITextEdition.UpdateTextFromValue { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180548570-0x0000000180548580 0x00000001823C0950-0x00000001823C0970
		Action ITextEdition.MoveFocusToCompositeRoot { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823C0820-0x00000001823C0830 0x00000001823C0930-0x00000001823C0950
		internal Action OnPlaceholderChanged { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823C3570-0x00000001823C3580 0x00000001813801B0-0x00000001813801D0
		Func<string> ITextEdition.GetDefaultValueType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180BBD620-0x0000000180BBD630 0x0000000180BBDB20-0x0000000180BBDB40
		char ITextEdition.maskChar { get; set; } // 0x00000001823C0900-0x00000001823C0910 0x00000001823C0EB0-0x00000001823C0F70
		[CreateProperty]
		private char maskChar { get; set; } // 0x00000001823C39D0-0x00000001823C3A90 0x00000001823C4900-0x00000001823C49C0
		private char effectiveMaskChar { get; } // 0x00000001823C36E0-0x00000001823C3740 
		bool ITextEdition.isPassword { get; set; } // 0x00000001823C08B0-0x00000001823C08C0 0x00000001823C0B20-0x00000001823C0BB0
		[CreateProperty]
		private bool isPassword { get; set; } // 0x00000001823C3860-0x00000001823C38B0 0x00000001823C4780-0x00000001823C47E0
		bool ITextEdition.hidePlaceholderOnFocus { get; set; } // 0x00000001823C0880-0x00000001823C0890 0x00000001823C0A80-0x00000001823C0A90
		internal bool needsPlaceholderIfTextIsEmpty { get; } // 0x00000001823C3AE0-0x00000001823C3BC0 
		internal bool showPlaceholderText { get; } // 0x00000001823C4160-0x00000001823C4280 
		bool ITextEdition.autoCorrection { get; set; } // 0x00000001823C0830-0x00000001823C0840 0x00000001823C0970-0x00000001823C09F0
		[CreateProperty]
		private bool autoCorrection { get; set; } // 0x00000001823C3580-0x00000001823C35D0 0x00000001823C4360-0x00000001823C43C0
		internal RenderedText renderedText { get; } // 0x00000001823C3D30-0x00000001823C3FE0 
		internal string renderedTextString { get; } // 0x00000001823C3BD0-0x00000001823C3D30 
		internal bool isTextEmpty { get; } // 0x00000001823C3950-0x00000001823C3980 
		[CreateProperty(ReadOnly = true)]
		public ITextSelection selection { get; } // 0x0000000180370C60-0x0000000180370C70 
		bool ITextSelection.isSelectable { get; set; } // 0x00000001823C1520-0x00000001823C1540 0x00000001823C1800-0x00000001823C18C0
		int ITextSelection.cursorIndex { get; set; } // 0x00000001823C1380-0x00000001823C1400 0x00000001823C1680-0x00000001823C1780
		[CreateProperty]
		private int cursorIndex { get; set; } // 0x00000001823C35E0-0x00000001823C3630 0x00000001823C4440-0x00000001823C44A0
		int ITextSelection.selectIndex { get; set; } // 0x00000001823C15F0-0x00000001823C1670 0x00000001823C19C0-0x00000001823C1AC0
		[CreateProperty]
		private int selectIndex { get; set; } // 0x00000001823C4080-0x00000001823C40D0 0x00000001823C4B70-0x00000001823C4BD0
		bool ITextSelection.doubleClickSelectsWord { get; set; } // 0x00000001823C1510-0x00000001823C1520 0x00000001823C1780-0x00000001823C1800
		bool ITextSelection.tripleClickSelectsLine { get; set; } // 0x00000001823C1670-0x00000001823C1680 0x00000001823C1AC0-0x00000001823C1B40
		bool ITextSelection.selectAllOnFocus { get; set; } // 0x00000001823C15D0-0x00000001823C15E0 0x00000001823C18C0-0x00000001823C1940
		[CreateProperty]
		private bool selectAllOnFocus { get; set; } // 0x00000001823C3FE0-0x00000001823C4030 0x00000001823C4AB0-0x00000001823C4B10
		bool ITextSelection.selectAllOnMouseUp { get; set; } // 0x00000001823C15E0-0x00000001823C15F0 0x00000001823C1940-0x00000001823C19C0
		[CreateProperty]
		private bool selectAllOnMouseUp { get; set; } // 0x00000001823C4030-0x00000001823C4080 0x00000001823C4B10-0x00000001823C4B70
		Vector2 ITextSelection.cursorPosition { get; } // 0x00000001823C1400-0x00000001823C1500 
		[CreateProperty(ReadOnly = true)]
		private Vector2 cursorPosition { get; } // 0x00000001823C3630-0x00000001823C3680 
		float ITextSelection.lineHeightAtCursorPosition { get; } // 0x00000001823C1540-0x00000001823C15D0 
		internal Color selectionColor { get; set; } // 0x00000001823C4150-0x00000001823C4160 0x00000001823C4BD0-0x00000001823C4C50
		internal Color cursorColor { get; set; } // 0x00000001823C35D0-0x00000001823C35E0 0x00000001823C43C0-0x00000001823C4440
		float ITextSelection.cursorWidth { get; } // 0x00000001823C1500-0x00000001823C1510 
		internal TextSelectingManipulator selectingManipulator { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x00000001823C40D0-0x00000001823C4150 
	
		// Nested types
		[IsReadOnly]
		public struct GlyphsEnumerable // TypeDefIndex: 4833
		{
			// Fields
			public readonly int Count; // 0x00
			private readonly List<NativeSlice<Vertex>> m_Vertices; // 0x08
			private readonly UIRQuadMap m_QuadMap; // 0x10
			private readonly TextElement m_TextElement; // 0x18
	
			// Constructors
			internal GlyphsEnumerable(TextElement te, List<NativeSlice<Vertex>> vertices); // 0x00000001823B7B30-0x00000001823B7BE0
			internal GlyphsEnumerable(TextElement te, List<NativeSlice<Vertex>> vertices, UIRQuadMap quadMap); // 0x00000001823B7BE0-0x00000001823B7C90
	
			// Methods
			private static int ComputeCount(List<NativeSlice<Vertex>> verts); // 0x00000001823B7AC0-0x00000001823B7B30
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 4834
		{
			// Fields
			public static Action<MeshGenerationContext> _0___OnGenerateVisualContent; // 0x00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass167_0 // TypeDefIndex: 4835
		{
			// Fields
			public EventBase evt; // 0x10
			public TextElement __4__this; // 0x18
			public long evtTimestamp; // 0x20
	
			// Constructors
			public __c__DisplayClass167_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _EditionHandleEvent_b__0(FocusEvent _); // 0x00000001823C8AF0-0x00000001823C8BA0
		}
	
		// Constructors
		public TextElement(); // 0x00000001823C31B0-0x00000001823C3570
		static TextElement(); // 0x00000001823C1DB0-0x00000001823C31B0
	
		// Methods
		private string GetDefaultValueType(); // 0x00000001815B1550-0x00000001815B1570
		[EventInterest(new Type[19] {typeof(ContextualMenuPopulateEvent), typeof(KeyDownEvent), typeof(KeyUpEvent), typeof(ValidateCommandEvent), typeof(ExecuteCommandEvent), typeof(FocusEvent), typeof(BlurEvent), typeof(FocusInEvent), typeof(FocusOutEvent), typeof(PointerDownEvent), typeof(PointerUpEvent), typeof(PointerMoveEvent), typeof(NavigationMoveEvent), typeof(NavigationSubmitEvent), typeof(NavigationCancelEvent), typeof(IMEEvent), typeof(GeometryChangedEvent), typeof(AttachToPanelEvent), typeof(DetachFromPanelEvent) })]
		protected override void HandleEventBubbleUp(EventBase evt); // 0x00000001823BF250-0x00000001823BF570
		private void OnAttachToPanel(AttachToPanelEvent attachEvent); // 0x00000001823BF5F0-0x00000001823BF6E0
		private void OnDetachFromPanel(DetachFromPanelEvent detachEvent); // 0x00000001823BF6E0-0x00000001823BF7F0
		internal static void OnGenerateVisualContent(MeshGenerationContext mgc); // 0x00000001823BFBB0-0x00000001823BFD20
		internal void OnGenerateTextOver(MeshGenerationContext mgc); // 0x00000001823BF9D0-0x00000001823BFBB0
		internal void OnGenerateTextOverNative(MeshGenerationContext mgc); // 0x00000001823BF7F0-0x00000001823BF9D0
		internal string ElideText(string drawText, string ellipsisText, float width, TextOverflowPosition textOverflowPosition); // 0x00000001823BEAC0-0x00000001823BEF60
		private void UpdateTooltip(); // 0x00000001823C1B40-0x00000001823C1BC0
		private void UpdateVisibleText(); // 0x00000001823C1BC0-0x00000001823C1DB0
		private bool ShouldElide(); // 0x00000001823BFF40-0x00000001823BFF90
		public Vector2 MeasureTextSize(string textToMeasure, float width, MeasureMode widthMode, float height, MeasureMode heightMode); // 0x00000001823BF5C0-0x00000001823BF5F0
		protected internal override Vector2 DoMeasure(float desiredWidth, MeasureMode widthMode, float desiredHeight, MeasureMode heightMode); // 0x00000001823BD460-0x00000001823BD540
		internal static bool AnySizeAutoOrNone(ref ComputedStyle computedStyle); // 0x00000001823BCEC0-0x00000001823BCF60
		void INotifyValueChanged<string>.SetValueWithoutNotify(string newValue); // 0x00000001823C0090-0x00000001823C0270
		public void MarkDirtyText(); // 0x00000001823BF570-0x00000001823BF5C0
		internal void RefreshCachedFontAsset(); // 0x00000001823BFEF0-0x00000001823BFF20
		private void ProcessMenuCommand(string command); // 0x00000001823BFDD0-0x00000001823BFEF0
		private void Cut(DropdownMenuAction a); // 0x00000001823BD420-0x00000001823BD460
		private void Copy(DropdownMenuAction a); // 0x00000001823BD340-0x00000001823BD380
		private void Paste(DropdownMenuAction a); // 0x00000001823BFD90-0x00000001823BFDD0
		private void BuildContextualMenu(ContextualMenuPopulateEvent evt); // 0x00000001823BCF60-0x00000001823BD2A0
		private DropdownMenuAction.Status CutActionStatus(DropdownMenuAction a); // 0x00000001823BD380-0x00000001823BD420
		private DropdownMenuAction.Status CopyActionStatus(DropdownMenuAction a); // 0x00000001823BD2A0-0x00000001823BD340
		private DropdownMenuAction.Status PasteActionStatus(DropdownMenuAction a); // 0x00000001823BFD20-0x00000001823BFD90
		private void EditionHandleEvent(EventBase evt); // 0x00000001823BE680-0x00000001823BEAC0
		void ITextEdition.SaveValueAndText(); // 0x00000001823C05E0-0x00000001823C0620
		void ITextEdition.RestoreValueAndText(); // 0x00000001823C05C0-0x00000001823C05E0
		void ITextEdition.UpdateText(string value); // 0x00000001823C0620-0x00000001823C0820
		string ITextEdition.CullString(string s); // 0x00000001823C0530-0x00000001823C05C0
		private void SetRenderedText(string value); // 0x00000001823BFF20-0x00000001823BFF40
		internal bool TryGetProcessedRenderedText(ref NativeTextBuffer dest); // 0x00000001823BFF90-0x00000001823C0090
		void ITextSelection.SelectNone(); // 0x00000001823C1310-0x00000001823C1380
		bool ITextSelection.HasSelection(); // 0x00000001823C12A0-0x00000001823C1310
		private void DrawHighlighting(MeshGenerationContext mgc); // 0x00000001823BD820-0x00000001823BE190
		private void DrawNativeHighlighting(MeshGenerationContext mgc); // 0x00000001823BE190-0x00000001823BE680
		internal void DrawCaret(MeshGenerationContext mgc); // 0x00000001823BD540-0x00000001823BD820
		private int GetLastCharacterAt(int lineIndex); // 0x00000001823BEF60-0x00000001823BF250
	}
}
