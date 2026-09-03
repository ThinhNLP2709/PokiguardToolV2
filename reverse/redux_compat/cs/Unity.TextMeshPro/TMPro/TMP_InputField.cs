/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[AddComponentMenu("UI (Canvas)/TextMeshPro - Input Field", 11)]
	[TMPHelpURL("index")]
	public class TMP_InputField : Selectable, IUpdateSelectedHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICancelHandler, ICanvasElement, ILayoutElement, IScrollHandler // TypeDefIndex: 11837
	{
		// Fields
		protected TouchScreenKeyboard m_SoftKeyboard; // 0x100
		private static readonly char[] kSeparators; // 0x00
		[NoAutoStaticsCleanup]
		private static bool s_IsQuestDevice; // 0x08
		protected RectTransform m_RectTransform; // 0x108
		[SerializeField]
		protected RectTransform m_TextViewport; // 0x110
		protected RectMask2D m_TextComponentRectMask; // 0x118
		protected RectMask2D m_TextViewportRectMask; // 0x120
		[SerializeField]
		protected TMP_Text m_TextComponent; // 0x128
		protected RectTransform m_TextComponentRectTransform; // 0x130
		[SerializeField]
		protected Graphic m_Placeholder; // 0x138
		[SerializeField]
		protected Scrollbar m_VerticalScrollbar; // 0x140
		[SerializeField]
		protected TMP_ScrollbarEventHandler m_VerticalScrollbarEventHandler; // 0x148
		private bool m_IsDrivenByLayoutComponents; // 0x150
		[SerializeField]
		private LayoutGroup m_LayoutGroup; // 0x158
		private IScrollHandler m_IScrollHandlerParent; // 0x160
		private float m_ScrollPosition; // 0x168
		[SerializeField]
		protected float m_ScrollSensitivity; // 0x16C
		[SerializeField]
		private ContentType m_ContentType; // 0x170
		[SerializeField]
		private InputType m_InputType; // 0x174
		[SerializeField]
		private char m_AsteriskChar; // 0x178
		[SerializeField]
		private TouchScreenKeyboardType m_KeyboardType; // 0x17C
		[SerializeField]
		private LineType m_LineType; // 0x180
		[SerializeField]
		private bool m_HideMobileInput; // 0x184
		[SerializeField]
		private bool m_HideSoftKeyboard; // 0x185
		[SerializeField]
		private CharacterValidation m_CharacterValidation; // 0x188
		[SerializeField]
		private string m_RegexValue; // 0x190
		[SerializeField]
		private float m_GlobalPointSize; // 0x198
		[SerializeField]
		private int m_CharacterLimit; // 0x19C
		[SerializeField]
		private SubmitEvent m_OnEndEdit; // 0x1A0
		[SerializeField]
		private SubmitEvent m_OnSubmit; // 0x1A8
		[SerializeField]
		private SelectionEvent m_OnSelect; // 0x1B0
		[SerializeField]
		private SelectionEvent m_OnDeselect; // 0x1B8
		[SerializeField]
		private TextSelectionEvent m_OnTextSelection; // 0x1C0
		[SerializeField]
		private TextSelectionEvent m_OnEndTextSelection; // 0x1C8
		[SerializeField]
		private OnChangeEvent m_OnValueChanged; // 0x1D0
		[SerializeField]
		private TouchScreenKeyboardEvent m_OnTouchScreenKeyboardStatusChanged; // 0x1D8
		[SerializeField]
		private OnValidateInput m_OnValidateInput; // 0x1E0
		[SerializeField]
		private Color m_CaretColor; // 0x1E8
		[SerializeField]
		private bool m_CustomCaretColor; // 0x1F8
		[SerializeField]
		private Color m_SelectionColor; // 0x1FC
		[SerializeField]
		[TextArea(5, 10)]
		protected string m_Text; // 0x210
		[Range(0f, 4f)]
		[SerializeField]
		private float m_CaretBlinkRate; // 0x218
		[Range(1f, 5f)]
		[SerializeField]
		private int m_CaretWidth; // 0x21C
		[SerializeField]
		private bool m_ReadOnly; // 0x220
		[SerializeField]
		private bool m_RichText; // 0x221
		protected int m_StringPosition; // 0x224
		protected int m_StringSelectPosition; // 0x228
		protected int m_CaretPosition; // 0x22C
		protected int m_CaretSelectPosition; // 0x230
		private RectTransform caretRectTrans; // 0x238
		protected UIVertex[] m_CursorVerts; // 0x240
		private CanvasRenderer m_CachedInputRenderer; // 0x248
		private Vector2 m_LastPosition; // 0x250
		[NonSerialized]
		protected Mesh m_Mesh; // 0x258
		private bool m_AllowInput; // 0x260
		private bool m_ShouldActivateNextUpdate; // 0x261
		private bool m_UpdateDrag; // 0x262
		private bool m_DragPositionOutOfBounds; // 0x263
		private const float kHScrollSpeed = 0.05f; // Metadata: 0x006A1F76
		private const float kVScrollSpeed = 0.1f; // Metadata: 0x006A1F7A
		protected bool m_CaretVisible; // 0x264
		private Coroutine m_BlinkCoroutine; // 0x268
		private float m_BlinkStartTime; // 0x270
		private Coroutine m_DragCoroutine; // 0x278
		private string m_OriginalText; // 0x280
		private bool m_WasCanceled; // 0x288
		private bool m_HasDoneFocusTransition; // 0x289
		private WaitForSecondsRealtime m_WaitForSecondsRealtime; // 0x290
		private bool m_PreventCallback; // 0x298
		private bool m_TouchKeyboardAllowsInPlaceEditing; // 0x299
		private bool m_IsTextComponentUpdateRequired; // 0x29A
		private bool m_HasTextBeenRemoved; // 0x29B
		private float m_PointerDownClickStartTime; // 0x29C
		private float m_KeyDownStartTime; // 0x2A0
		private float m_DoubleClickDelay; // 0x2A4
		private bool m_IsApplePlatform; // 0x2A8
		private const string kEmailSpecialCharacters = "!#$%&\'*+-/=?^_`{|}~"; // Metadata: 0x006A1F7E
		private const string kOculusQuestDeviceModel = "Oculus Quest"; // Metadata: 0x006A1F92
		private bool m_ShouldUpdateIMEWindowPosition; // 0x2A9
		private int m_PreviousIMEInsertionLine; // 0x2AC
		[SerializeField]
		protected TMP_FontAsset m_GlobalFontAsset; // 0x2B0
		[SerializeField]
		protected bool m_OnFocusSelectAll; // 0x2B8
		protected bool m_isSelectAll; // 0x2B9
		[SerializeField]
		protected bool m_ResetOnDeActivation; // 0x2BA
		private bool m_SelectionStillActive; // 0x2BB
		private bool m_ReleaseSelection; // 0x2BC
		private KeyCode m_LastKeyCode; // 0x2C0
		private GameObject m_PreviouslySelectedObject; // 0x2C8
		[SerializeField]
		private bool m_KeepTextSelectionVisible; // 0x2D0
		[SerializeField]
		private bool m_RestoreOriginalTextOnEscape; // 0x2D1
		[SerializeField]
		protected bool m_isRichTextEditingAllowed; // 0x2D2
		[SerializeField]
		protected int m_LineLimit; // 0x2D4
		public bool isAlert; // 0x2D8
		[SerializeField]
		protected TMP_InputValidator m_InputValidator; // 0x2E0
		[SerializeField]
		private bool m_ShouldActivateOnSelect; // 0x2E8
		private bool m_isSelected; // 0x2E9
		private bool m_IsStringPositionDirty; // 0x2EA
		private bool m_IsCaretPositionDirty; // 0x2EB
		private bool m_forceRectTransformAdjustment; // 0x2EC
		private bool m_IsKeyboardBeingClosedInTouchscreen; // 0x2ED
		private Event m_ProcessingEvent; // 0x2F0
	
		// Properties
		private BaseInput inputSystem { get; } // 0x0000000182093870-0x0000000182093930 
		private string compositionString { get; } // 0x00000001820936E0-0x00000001820937B0 
		private int compositionLength { get; } // 0x00000001820936B0-0x00000001820936E0 
		protected Mesh mesh { get; } // 0x00000001820939B0-0x0000000182093A60 
		public virtual bool shouldActivateOnSelect { get; set; } // 0x0000000182093DE0-0x0000000182093E40 0x00000001820953B0-0x00000001820953C0
		public bool shouldHideMobileInput { get; set; } // 0x0000000182093E40-0x0000000182093EB0 0x00000001820953C0-0x0000000182095460
		public bool shouldHideSoftKeyboard { get; set; } // 0x0000000182093EB0-0x0000000182093F40 0x0000000182095460-0x00000001820955B0
		public string text { get; set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x00000001820957E0-0x00000001820957F0
		public bool isFocused { get; } // 0x0000000182093950-0x0000000182093960 
		public float caretBlinkRate { get; set; } // 0x0000000182093570-0x0000000182093580 0x0000000182094120-0x0000000182094190
		public int caretWidth { get; set; } // 0x00000001818400E0-0x00000001818400F0 0x00000001820942E0-0x0000000182094370
		public RectTransform textViewport { get; set; } // 0x000000018170B050-0x000000018170B060 0x0000000182095790-0x00000001820957E0
		public TMP_Text textComponent { get; set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000182095730-0x0000000182095790
		public Graphic placeholder { get; set; } // 0x0000000181974820-0x0000000181974830 0x0000000182094E50-0x0000000182094EA0
		public Scrollbar verticalScrollbar { get; set; } // 0x0000000181C0F740-0x0000000181C0F750 0x00000001820957F0-0x0000000182095970
		public float scrollSensitivity { get; set; } // 0x0000000181C4BAF0-0x0000000181C4BB00 0x00000001820950D0-0x0000000182095160
		public Color caretColor { get; set; } // 0x0000000182093580-0x00000001820935E0 0x0000000182094190-0x0000000182094200
		public bool customCaretColor { get; set; } // 0x00000001820937C0-0x00000001820937D0 0x0000000182094720-0x0000000182094780
		public Color selectionColor { get; set; } // 0x0000000182093D50-0x0000000182093D60 0x00000001820951C0-0x0000000182095230
		public SubmitEvent onEndEdit { get; set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000182094BC0-0x0000000182094C10
		public SubmitEvent onSubmit { get; set; } // 0x0000000180E224F0-0x0000000180E22500 0x0000000182094CC0-0x0000000182094D10
		public SelectionEvent onSelect { get; set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000182094C70-0x0000000182094CC0
		public SelectionEvent onDeselect { get; set; } // 0x000000018033D6C0-0x000000018033D6D0 0x0000000182094B70-0x0000000182094BC0
		public TextSelectionEvent onTextSelection { get; set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000182094D10-0x0000000182094D60
		public TextSelectionEvent onEndTextSelection { get; set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000182094C10-0x0000000182094C60
		public OnChangeEvent onValueChanged { get; set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000182094E00-0x0000000182094E50
		public TouchScreenKeyboardEvent onTouchScreenKeyboardStatusChanged { get; set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000182094D60-0x0000000182094DB0
		public OnValidateInput onValidateInput { get; set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000182094DB0-0x0000000182094E00
		public int characterLimit { get; set; } // 0x0000000181E62B30-0x0000000181E62B40 0x0000000182094370-0x0000000182094420
		public float pointSize { get; set; } // 0x0000000181E65020-0x0000000181E65030 0x0000000182094EA0-0x0000000182095010
		public TMP_FontAsset fontAsset { get; set; } // 0x00000001820937D0-0x00000001820937E0 0x0000000182094780-0x00000001820948C0
		public bool onFocusSelectAll { get; set; } // 0x0000000182093A80-0x0000000182093A90 0x0000000182094C60-0x0000000182094C70
		public bool resetOnDeActivation { get; set; } // 0x0000000182093D20-0x0000000182093D30 0x0000000182095020-0x0000000182095030
		public bool keepTextSelectionVisible { get; set; } // 0x0000000182093960-0x0000000182093970 0x00000001820949A0-0x00000001820949B0
		public bool restoreOriginalTextOnEscape { get; set; } // 0x0000000182093D30-0x0000000182093D40 0x0000000182095030-0x0000000182095040
		public bool isRichTextEditingAllowed { get; set; } // 0x0000000181E6ED10-0x0000000181E6ED20 0x0000000181E68200-0x0000000181E68210
		public ContentType contentType { get; set; } // 0x00000001820937B0-0x00000001820937C0 0x00000001820944E0-0x0000000182094720
		public LineType lineType { get; set; } // 0x0000000182093990-0x00000001820939A0 0x0000000182094A90-0x0000000182094B70
		public int lineLimit { get; set; } // 0x0000000182093980-0x0000000182093990 0x0000000182094A20-0x0000000182094A90
		public InputType inputType { get; set; } // 0x0000000182093930-0x0000000182093940 0x00000001820948C0-0x0000000182094930
		public TouchScreenKeyboard touchScreenKeyboard { get; } // 0x00000001816A28C0-0x00000001816A28D0 
		public TouchScreenKeyboardType keyboardType { get; set; } // 0x0000000182093970-0x0000000182093980 0x00000001820949B0-0x0000000182094A20
		public CharacterValidation characterValidation { get; set; } // 0x0000000182093660-0x0000000182093670 0x0000000182094420-0x0000000182094490
		public TMP_InputValidator inputValidator { get; set; } // 0x0000000182093940-0x0000000182093950 0x0000000182094930-0x00000001820949A0
		public bool readOnly { get; set; } // 0x0000000182093D10-0x0000000182093D20 0x0000000182095010-0x0000000182095020
		public bool richText { get; set; } // 0x0000000182093D40-0x0000000182093D50 0x0000000182095040-0x00000001820950D0
		public bool multiLine { get; } // 0x0000000182093A60-0x0000000182093A80 
		public char asteriskChar { get; set; } // 0x0000000182093560-0x0000000182093570 0x00000001820940C0-0x0000000182094120
		public bool wasCanceled { get; } // 0x0000000182093F40-0x0000000182093F50 
		protected int caretPositionInternal { get; set; } // 0x00000001820935E0-0x0000000182093620 0x0000000182094200-0x0000000182094220
		protected int stringPositionInternal { get; set; } // 0x0000000182093D60-0x0000000182093DA0 0x00000001820955B0-0x0000000182095600
		protected int caretSelectPositionInternal { get; set; } // 0x0000000182093620-0x0000000182093660 0x00000001820942C0-0x00000001820942E0
		protected int stringSelectPositionInternal { get; set; } // 0x0000000182093DA0-0x0000000182093DE0 0x00000001820956E0-0x0000000182095730
		private new bool hasSelection { get; } // 0x00000001820937E0-0x0000000182093870 
		public int caretPosition { get; set; } // 0x0000000182093620-0x0000000182093660 0x0000000182094220-0x00000001820942C0
		public int selectionAnchorPosition { get; set; } // 0x00000001820935E0-0x0000000182093620 0x0000000182095160-0x00000001820951C0
		public int selectionFocusPosition { get; set; } // 0x0000000182093620-0x0000000182093660 0x0000000182095230-0x0000000182095290
		public int stringPosition { get; set; } // 0x0000000182093DA0-0x0000000182093DE0 0x0000000182095600-0x00000001820956E0
		public int selectionStringAnchorPosition { get; set; } // 0x0000000182093D60-0x0000000182093DA0 0x0000000182095290-0x0000000182095320
		public int selectionStringFocusPosition { get; set; } // 0x0000000182093DA0-0x0000000182093DE0 0x0000000182095320-0x00000001820953B0
		private static string clipboard { get; set; } // 0x0000000182093670-0x00000001820936B0 0x0000000182094490-0x00000001820944E0
		public virtual float minWidth { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxWidth { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredWidth { get; } // 0x0000000182093BD0-0x0000000182093D10 
		public virtual float flexibleWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float minHeight { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxHeight { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredHeight { get; } // 0x0000000182093A90-0x0000000182093BD0 
		public virtual float flexibleHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual int layoutPriority { get; } // 0x0000000180472790-0x00000001804727A0 
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Nested types
		public enum ContentType // TypeDefIndex: 11838
		{
			Standard = 0,
			Autocorrected = 1,
			IntegerNumber = 2,
			DecimalNumber = 3,
			Alphanumeric = 4,
			Name = 5,
			EmailAddress = 6,
			Password = 7,
			Pin = 8,
			Custom = 9
		}
	
		public enum InputType // TypeDefIndex: 11839
		{
			Standard = 0,
			AutoCorrect = 1,
			Password = 2
		}
	
		public enum CharacterValidation // TypeDefIndex: 11840
		{
			None = 0,
			Digit = 1,
			Integer = 2,
			Decimal = 3,
			Alphanumeric = 4,
			Name = 5,
			Regex = 6,
			EmailAddress = 7,
			CustomValidator = 8
		}
	
		public enum LineType // TypeDefIndex: 11841
		{
			SingleLine = 0,
			MultiLineSubmit = 1,
			MultiLineNewline = 2
		}
	
		public delegate char OnValidateInput(string text, int charIndex, char addedChar); // TypeDefIndex: 11842; 0x0000000180A72B30-0x0000000180A72B50
	
		[Serializable]
		public class SubmitEvent : UnityEvent<string> // TypeDefIndex: 11843
		{
			// Constructors
			public SubmitEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class OnChangeEvent : UnityEvent<string> // TypeDefIndex: 11844
		{
			// Constructors
			public OnChangeEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class SelectionEvent : UnityEvent<string> // TypeDefIndex: 11845
		{
			// Constructors
			public SelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class TextSelectionEvent : UnityEvent<string, int, int> // TypeDefIndex: 11846
		{
			// Constructors
			public TextSelectionEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class TouchScreenKeyboardEvent : UnityEvent<TouchScreenKeyboard.Status> // TypeDefIndex: 11847
		{
			// Constructors
			public TouchScreenKeyboardEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		protected enum EditState // TypeDefIndex: 11848
		{
			Continue = 0,
			Finish = 1
		}
	
		[CompilerGenerated]
		private sealed class _CaretBlink_d__292 : IEnumerator<object> // TypeDefIndex: 11849
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TMP_InputField __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _CaretBlink_d__292(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001820D10A0-0x00000001820D1200
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001820D1200-0x00000001820D1240
		}
	
		[CompilerGenerated]
		private sealed class _MouseDragOutsideRect_d__313 : IEnumerator<object> // TypeDefIndex: 11850
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TMP_InputField __4__this; // 0x20
			public PointerEventData eventData; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _MouseDragOutsideRect_d__313(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001820D1D90-0x00000001820D2060
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001820D2060-0x00000001820D20A0
		}
	
		// Constructors
		protected TMP_InputField(); // 0x0000000182093220-0x0000000182093560
		static TMP_InputField(); // 0x0000000182093180-0x0000000182093220
	
		// Methods
		private bool isKeyboardUsingEvents(); // 0x0000000182093F50-0x0000000182094050
		private bool isUWP(); // 0x0000000182094050-0x00000001820940C0
		public void SetTextWithoutNotify(string input); // 0x00000001820919A0-0x00000001820919B0
		private void SetText(string value, bool sendCallback = true /* Metadata: 0x006A1F74 */); // 0x00000001820919B0-0x0000000182091B20
		protected void ClampStringPos(ref int pos); // 0x00000001820873D0-0x0000000182087410
		protected void ClampCaretPos(ref int pos); // 0x0000000182087350-0x00000001820873D0
		private int ClampArrayIndex(int index); // 0x0000000182087340-0x0000000182087350
		protected override void OnEnable(); // 0x000000018208EB60-0x000000018208F410
		protected override void OnDisable(); // 0x000000018208E390-0x000000018208E690
		private void ON_TEXT_CHANGED(UnityEngine.Object obj); // 0x000000018208E010-0x000000018208E200
		[IteratorStateMachine(typeof(_CaretBlink_d__292))]
		private IEnumerator CaretBlink(); // 0x00000001820872D0-0x0000000182087340
		private void SetCaretVisible(); // 0x0000000182091640-0x0000000182091680
		private void SetCaretActive(); // 0x0000000182091570-0x0000000182091640
		protected void OnFocus(); // 0x000000018208F6C0-0x000000018208F6E0
		protected void SelectAll(); // 0x0000000182091030-0x00000001820910B0
		public void MoveTextEnd(bool shift); // 0x000000018208D4A0-0x000000018208D690
		public void MoveTextStart(bool shift); // 0x000000018208D690-0x000000018208D7F0
		public void MoveToEndOfLine(bool shift, bool ctrl); // 0x000000018208D7F0-0x000000018208DA80
		public void MoveToStartOfLine(bool shift, bool ctrl); // 0x000000018208DA80-0x000000018208DD60
		private bool InPlaceEditing(); // 0x000000018208A080-0x000000018208A150
		private bool InPlaceEditingChanged(); // 0x000000018208A000-0x000000018208A080
		private bool TouchScreenKeyboardShouldBeUsed(); // 0x0000000182091BB0-0x0000000182091C50
		private void UpdateKeyboardStringPosition(); // 0x0000000182091E40-0x0000000182091FF0
		private void UpdateStringPositionFromKeyboard(); // 0x0000000182092720-0x0000000182092920
		protected virtual void LateUpdate(); // 0x000000018208A7B0-0x000000018208B190
		private bool MayDrag(PointerEventData eventData); // 0x000000018208B740-0x000000018208B830
		public virtual void OnBeginDrag(PointerEventData eventData); // 0x000000018208E200-0x000000018208E230
		public virtual void OnDrag(PointerEventData eventData); // 0x000000018208E690-0x000000018208EB60
		[IteratorStateMachine(typeof(_MouseDragOutsideRect_d__313))]
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData); // 0x000000018208B830-0x000000018208B8C0
		public virtual void OnEndDrag(PointerEventData eventData); // 0x000000018208F410-0x000000018208F440
		public override void OnPointerDown(PointerEventData eventData); // 0x000000018208F730-0x00000001820900B0
		protected EditState KeyPressed(Event evt); // 0x000000018208A2E0-0x000000018208A7B0
		protected virtual bool IsValidChar(char c); // 0x000000018208A2C0-0x000000018208A2E0
		public void ProcessEvent(Event e); // 0x0000000182090E50-0x0000000182090E60
		public virtual void OnUpdateSelected(BaseEventData eventData); // 0x0000000182090490-0x0000000182090620
		public virtual void OnScroll(PointerEventData eventData); // 0x00000001820900B0-0x0000000182090300
		private float GetScrollPositionRelativeToViewport(); // 0x0000000182089C90-0x0000000182089E70
		private string GetSelectedString(); // 0x0000000182089E70-0x0000000182089F50
		private int FindNextWordBegin(); // 0x00000001820881B0-0x00000001820882D0
		private void MoveRight(bool shift, bool ctrl); // 0x000000018208CC10-0x000000018208D4A0
		private int FindPrevWordBegin(); // 0x00000001820882D0-0x00000001820883E0
		private void MoveLeft(bool shift, bool ctrl); // 0x000000018208BB90-0x000000018208C300
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar); // 0x000000018208B460-0x000000018208B6F0
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar); // 0x000000018208B190-0x000000018208B460
		private int PageUpCharacterPosition(int originalPos, bool goToFirstChar); // 0x0000000182090A70-0x0000000182090E50
		private int PageDownCharacterPosition(int originalPos, bool goToLastChar); // 0x0000000182090620-0x0000000182090A70
		private void MoveDown(bool shift); // 0x000000018208BB80-0x000000018208BB90
		private void MoveDown(bool shift, bool goToLastChar); // 0x000000018208B8C0-0x000000018208BB80
		private void MoveUp(bool shift); // 0x000000018208DD60-0x000000018208DD70
		private void MoveUp(bool shift, bool goToFirstChar); // 0x000000018208DD70-0x000000018208E010
		private void MovePageUp(bool shift); // 0x000000018208CC00-0x000000018208CC10
		private void MovePageUp(bool shift, bool goToFirstChar); // 0x000000018208C790-0x000000018208CC00
		private void MovePageDown(bool shift); // 0x000000018208C780-0x000000018208C790
		private void MovePageDown(bool shift, bool goToLastChar); // 0x000000018208C300-0x000000018208C780
		private void Delete(); // 0x0000000182087BC0-0x0000000182087F80
		private void DeleteKey(); // 0x00000001820877F0-0x0000000182087BC0
		private void Backspace(); // 0x0000000182086E40-0x00000001820872D0
		protected virtual void Append(string input); // 0x0000000182086030-0x00000001820860E0
		protected virtual void Append(char input); // 0x00000001820860E0-0x00000001820866E0
		private void Insert(char c); // 0x000000018208A150-0x000000018208A2C0
		private void UpdateTouchKeyboardFromEditChanges(); // 0x0000000182092920-0x0000000182092970
		private void SendOnValueChangedAndUpdateLabel(); // 0x0000000182091440-0x00000001820914A0
		private void SendOnValueChanged(); // 0x00000001820914A0-0x0000000182091500
		protected void SendOnEndEdit(); // 0x00000001820910B0-0x0000000182091110
		protected void SendOnSubmit(); // 0x00000001820912E0-0x0000000182091340
		protected void SendOnFocus(); // 0x0000000182091280-0x00000001820912E0
		protected void SendOnFocusLost(); // 0x0000000182091220-0x0000000182091280
		protected void SendOnTextSelection(); // 0x0000000182091340-0x0000000182091440
		protected void SendOnEndTextSelection(); // 0x0000000182091110-0x0000000182091220
		protected void SendTouchScreenKeyboardStatusChanged(); // 0x0000000182091500-0x0000000182091570
		protected void UpdateLabel(); // 0x0000000182091FF0-0x0000000182092530
		private void UpdateScrollbar(); // 0x0000000182092530-0x0000000182092650
		private void OnScrollbarValueChange(float value); // 0x0000000182090300-0x0000000182090340
		private void UpdateMaskRegions(); // 0x00000001802E76C0-0x00000001802E76D0
		private void AdjustTextPositionRelativeToViewport(float relativePosition); // 0x0000000182085DB0-0x0000000182086030
		private int GetCaretPositionFromStringIndex(int stringIndex); // 0x0000000182089AC0-0x0000000182089B80
		private int GetMinCaretPositionFromStringIndex(int stringIndex); // 0x0000000182089B80-0x0000000182089C90
		private int GetMaxCaretPositionFromStringIndex(int stringIndex); // 0x0000000182089AC0-0x0000000182089B80
		private int GetStringIndexFromCaretPosition(int caretPosition); // 0x0000000182089F50-0x000000018208A000
		private void UpdateStringIndexFromCaretPosition(); // 0x0000000182092650-0x0000000182092720
		private void UpdateCaretPositionFromStringIndex(); // 0x0000000182091C60-0x0000000182091D30
		public void ForceLabelUpdate(); // 0x00000001820883E0-0x00000001820883F0
		private void MarkGeometryAsDirty(); // 0x000000018208B6F0-0x000000018208B740
		public virtual void Rebuild(CanvasUpdate update); // 0x0000000182090E60-0x0000000182090F70
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		private void UpdateGeometry(); // 0x0000000182091D30-0x0000000182091E40
		private void AssignPositioningIfNeeded(); // 0x00000001820866E0-0x0000000182086E40
		private void OnFillVBO(Mesh vbo); // 0x000000018208F440-0x000000018208F6C0
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset); // 0x00000001820883F0-0x0000000182089090
		private void CreateCursorVerts(); // 0x0000000182087410-0x00000001820875D0
		private void GenerateHighlight(VertexHelper vbo, Vector2 roundingOffset); // 0x0000000182089090-0x0000000182089AC0
		private void AdjustRectTransformRelativeToViewport(Vector2 startPosition, float height, bool isCharVisible); // 0x00000001820855D0-0x0000000182085DB0
		protected char Validate(string text, int pos, char ch); // 0x0000000182092970-0x0000000182093180
		public void ActivateInputField(); // 0x00000001820854A0-0x00000001820855D0
		private void ActivateInputFieldInternal(); // 0x0000000182085030-0x00000001820854A0
		public override void OnSelect(BaseEventData eventData); // 0x0000000182090340-0x00000001820903C0
		public virtual void OnPointerClick(PointerEventData eventData); // 0x000000018208F700-0x000000018208F730
		public void OnControlClick(); // 0x00000001802E76C0-0x00000001802E76D0
		public void ReleaseSelection(); // 0x0000000182090F70-0x0000000182091030
		public void DeactivateInputField(bool clearSelection = false /* Metadata: 0x006A1F75 */); // 0x00000001820875D0-0x00000001820877F0
		public override void OnDeselect(BaseEventData eventData); // 0x000000018208E2D0-0x000000018208E390
		public virtual void OnSubmit(BaseEventData eventData); // 0x00000001820903C0-0x0000000182090490
		public virtual void OnCancel(BaseEventData eventData); // 0x000000018208E230-0x000000018208E2D0
		public override void OnMove(AxisEventData eventData); // 0x000000018208F6E0-0x000000018208F700
		private void EnforceContentType(); // 0x0000000182087FB0-0x00000001820881B0
		private void SetTextComponentWrapMode(); // 0x00000001820918F0-0x00000001820919A0
		private void SetTextComponentRichTextMode(); // 0x0000000182091860-0x00000001820918F0
		private void SetToCustomIfContentTypeIsNot(params ContentType[] allowedContentTypes); // 0x0000000182091B20-0x0000000182091B90
		private void SetToCustom(); // 0x0000000182091B90-0x0000000182091BB0
		private void SetToCustom(CharacterValidation characterValidation); // 0x0000000182091B90-0x0000000182091BB0
		protected override void DoStateTransition(SelectionState state, bool instant); // 0x0000000182087F80-0x0000000182087FB0
		public virtual void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		public void SetGlobalPointSize(float pointSize); // 0x0000000182091770-0x0000000182091860
		public void SetGlobalFontAsset(TMP_FontAsset fontAsset); // 0x0000000182091680-0x0000000182091770
	}
}
