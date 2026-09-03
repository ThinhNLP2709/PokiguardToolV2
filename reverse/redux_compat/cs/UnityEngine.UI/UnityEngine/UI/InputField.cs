/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Legacy/Input Field", 103)]
	[UGUIHelpURL("InputField")]
	public class InputField : Selectable, IUpdateSelectedHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, ILayoutElement // TypeDefIndex: 13050
	{
		// Fields
		protected TouchScreenKeyboard m_Keyboard; // 0x100
		private static readonly char[] kSeparators; // 0x00
		[NoAutoStaticsCleanup]
		private static bool s_IsQuestDevice; // 0x08
		[FormerlySerializedAs("text")]
		[SerializeField]
		protected Text m_TextComponent; // 0x108
		[SerializeField]
		protected Graphic m_Placeholder; // 0x110
		[SerializeField]
		private ContentType m_ContentType; // 0x118
		[FormerlySerializedAs("inputType")]
		[SerializeField]
		private InputType m_InputType; // 0x11C
		[FormerlySerializedAs("asteriskChar")]
		[SerializeField]
		private char m_AsteriskChar; // 0x120
		[FormerlySerializedAs("keyboardType")]
		[SerializeField]
		private TouchScreenKeyboardType m_KeyboardType; // 0x124
		[SerializeField]
		private LineType m_LineType; // 0x128
		[FormerlySerializedAs("hideMobileInput")]
		[SerializeField]
		private bool m_HideMobileInput; // 0x12C
		[FormerlySerializedAs("validation")]
		[SerializeField]
		private CharacterValidation m_CharacterValidation; // 0x130
		[FormerlySerializedAs("characterLimit")]
		[SerializeField]
		private int m_CharacterLimit; // 0x134
		[FormerlySerializedAs("onSubmit")]
		[FormerlySerializedAs("m_OnSubmit")]
		[FormerlySerializedAs("m_EndEdit")]
		[FormerlySerializedAs("m_OnEndEdit")]
		[SerializeField]
		private SubmitEvent m_OnSubmit; // 0x138
		[SerializeField]
		private EndEditEvent m_OnDidEndEdit; // 0x140
		[FormerlySerializedAs("onValueChange")]
		[FormerlySerializedAs("m_OnValueChange")]
		[SerializeField]
		private OnChangeEvent m_OnValueChanged; // 0x148
		[FormerlySerializedAs("onValidateInput")]
		[SerializeField]
		private OnValidateInput m_OnValidateInput; // 0x150
		[FormerlySerializedAs("selectionColor")]
		[SerializeField]
		private Color m_CaretColor; // 0x158
		[SerializeField]
		private bool m_CustomCaretColor; // 0x168
		[SerializeField]
		private Color m_SelectionColor; // 0x16C
		[FormerlySerializedAs("mValue")]
		[Multiline]
		[SerializeField]
		protected string m_Text; // 0x180
		[Range(0f, 4f)]
		[SerializeField]
		private float m_CaretBlinkRate; // 0x188
		[Range(1f, 5f)]
		[SerializeField]
		private int m_CaretWidth; // 0x18C
		[SerializeField]
		private bool m_ReadOnly; // 0x190
		[SerializeField]
		private bool m_ShouldActivateOnSelect; // 0x191
		protected int m_CaretPosition; // 0x194
		protected int m_CaretSelectPosition; // 0x198
		private RectTransform caretRectTrans; // 0x1A0
		protected UIVertex[] m_CursorVerts; // 0x1A8
		private TextGenerator m_InputTextCache; // 0x1B0
		private CanvasRenderer m_CachedInputRenderer; // 0x1B8
		private bool m_PreventFontCallback; // 0x1C0
		[NonSerialized]
		protected Mesh m_Mesh; // 0x1C8
		private bool m_AllowInput; // 0x1D0
		private bool m_ShouldActivateNextUpdate; // 0x1D1
		private bool m_UpdateDrag; // 0x1D2
		private bool m_DragPositionOutOfBounds; // 0x1D3
		private const float kHScrollSpeed = 0.05f; // Metadata: 0x006A7703
		private const float kVScrollSpeed = 0.1f; // Metadata: 0x006A7707
		private static readonly RangeInt k_KeyboardSelectionResetValue; // 0x0C
		protected bool m_CaretVisible; // 0x1D4
		private Coroutine m_BlinkCoroutine; // 0x1D8
		private float m_BlinkStartTime; // 0x1E0
		protected int m_DrawStart; // 0x1E4
		protected int m_DrawEnd; // 0x1E8
		private Coroutine m_DragCoroutine; // 0x1F0
		private string m_OriginalText; // 0x1F8
		private bool m_WasCanceled; // 0x200
		private bool m_HasDoneFocusTransition; // 0x201
		private WaitForSecondsRealtime m_WaitForSecondsRealtime; // 0x208
		private bool m_TouchKeyboardAllowsInPlaceEditing; // 0x210
		private bool m_UpdateCaretToKeyboardPending; // 0x211
		private RangeInt m_LastSyncedToKeyboard; // 0x214
		private const string kEmailSpecialCharacters = "!#$%&\'*+-/=?^_`{|}~"; // Metadata: 0x006A770B
		private const string kOculusQuestDeviceModel = "Oculus Quest"; // Metadata: 0x006A771F
		private Event m_ProcessingEvent; // 0x220
		private const int k_MaxTextLength = 16382; // Metadata: 0x006A772C
	
		// Properties
		private BaseInput input { get; } // 0x00000001825901B0-0x0000000182590270 
		private string compositionString { get; } // 0x00000001825900C0-0x0000000182590190 
		protected Mesh mesh { get; } // 0x0000000182590280-0x0000000182590330 
		protected TextGenerator cachedInputTextGenerator { get; } // 0x000000018258FF30-0x000000018258FFB0 
		public bool shouldHideMobileInput { get; set; } // 0x0000000182590790-0x00000001825907F0 0x0000000182591440-0x0000000182591490
		public virtual bool shouldActivateOnSelect { get; set; } // 0x0000000182590730-0x0000000182590790 0x0000000182591430-0x0000000182591440
		public string text { get; set; } // 0x0000000181C4BCD0-0x0000000181C4BCE0 0x0000000182591720-0x0000000182591730
		public bool isFocused { get; } // 0x0000000182590270-0x0000000182590280 
		public float caretBlinkRate { get; set; } // 0x00000001823308C0-0x00000001823308D0 0x0000000182590860-0x00000001825908D0
		public int caretWidth { get; set; } // 0x0000000182590070-0x0000000182590080 0x0000000182590AD0-0x0000000182590B60
		public Text textComponent { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000182591490-0x0000000182591720
		public Graphic placeholder { get; set; } // 0x000000018170B050-0x000000018170B060 0x0000000182591270-0x00000001825912C0
		public Color caretColor { get; set; } // 0x000000018258FFB0-0x0000000182590010 0x00000001825908D0-0x0000000182590940
		public bool customCaretColor { get; set; } // 0x00000001824430A0-0x00000001824430B0 0x0000000182590F10-0x0000000182590F70
		public Color selectionColor { get; set; } // 0x0000000182590720-0x0000000182590730 0x0000000182591340-0x00000001825913B0
		public EndEditEvent onEndEdit { get; set; } // 0x0000000181C0F740-0x0000000181C0F750 0x0000000182591130-0x0000000182591180
		public SubmitEvent onSubmit { get; set; } // 0x0000000181974820-0x0000000181974830 0x0000000182591180-0x00000001825911D0
		[Obsolete("onValueChange has been renamed to onValueChanged", true)]
		public OnChangeEvent onValueChange { get; set; } // 0x000000018033D220-0x000000018033D230 0x0000000182591220-0x0000000182591270
		public OnChangeEvent onValueChanged { get; set; } // 0x000000018033D220-0x000000018033D230 0x0000000182591220-0x0000000182591270
		public OnValidateInput onValidateInput { get; set; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 0x00000001825911D0-0x0000000182591220
		public int characterLimit { get; set; } // 0x0000000181C0F3A0-0x0000000181C0F3B0 0x0000000182590B60-0x0000000182590C10
		public ContentType contentType { get; set; } // 0x0000000181F63E40-0x0000000181F63E50 0x0000000182590CD0-0x0000000182590F10
		public LineType lineType { get; set; } // 0x000000018033D760-0x000000018033D770 0x0000000182591050-0x0000000182591130
		public InputType inputType { get; set; } // 0x00000001825901A0-0x00000001825901B0 0x0000000182590F70-0x0000000182590FE0
		public TouchScreenKeyboard touchScreenKeyboard { get; } // 0x00000001816A28C0-0x00000001816A28D0 
		public TouchScreenKeyboardType keyboardType { get; set; } // 0x000000018033D750-0x000000018033D760 0x0000000182590FE0-0x0000000182591050
		public CharacterValidation characterValidation { get; set; } // 0x0000000181CE61E0-0x0000000181CE61F0 0x0000000182590C10-0x0000000182590C80
		public bool readOnly { get; set; } // 0x0000000181C0F720-0x0000000181C0F730 0x0000000181C0FB90-0x0000000181C0FBA0
		public bool multiLine { get; } // 0x0000000182590340-0x0000000182590360 
		public char asteriskChar { get; set; } // 0x000000018258FF20-0x000000018258FF30 0x0000000182590800-0x0000000182590860
		public bool wasCanceled { get; } // 0x00000001825907F0-0x0000000182590800 
		protected int caretPositionInternal { get; set; } // 0x0000000182590010-0x0000000182590040 0x0000000182590940-0x00000001825909A0
		protected int caretSelectPositionInternal { get; set; } // 0x0000000182590040-0x0000000182590070 0x0000000182590A70-0x0000000182590AD0
		private new bool hasSelection { get; } // 0x0000000182590190-0x00000001825901A0 
		public int caretPosition { get; set; } // 0x0000000182590040-0x0000000182590070 0x00000001825909A0-0x0000000182590A70
		public int selectionAnchorPosition { get; set; } // 0x0000000182590010-0x0000000182590040 0x00000001825912C0-0x0000000182591340
		public int selectionFocusPosition { get; set; } // 0x0000000182590040-0x0000000182590070 0x00000001825913B0-0x0000000182591430
		private static string clipboard { get; set; } // 0x0000000182590080-0x00000001825900C0 0x0000000182590C80-0x0000000182590CD0
		public virtual float minWidth { get; } // 0x0000000182590330-0x0000000182590340 
		public virtual float maxWidth { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredWidth { get; } // 0x0000000182590560-0x0000000182590720 
		public virtual float flexibleWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float minHeight { get; } // 0x00000001807185C0-0x00000001807185D0 
		public virtual float maxHeight { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredHeight { get; } // 0x0000000182590360-0x0000000182590560 
		public virtual float flexibleHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual int layoutPriority { get; } // 0x0000000180472790-0x00000001804727A0 
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Nested types
		public enum ContentType // TypeDefIndex: 13051
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
	
		public enum InputType // TypeDefIndex: 13052
		{
			Standard = 0,
			AutoCorrect = 1,
			Password = 2
		}
	
		public enum CharacterValidation // TypeDefIndex: 13053
		{
			None = 0,
			Integer = 1,
			Decimal = 2,
			Alphanumeric = 3,
			Name = 4,
			EmailAddress = 5
		}
	
		public enum LineType // TypeDefIndex: 13054
		{
			SingleLine = 0,
			MultiLineSubmit = 1,
			MultiLineNewline = 2
		}
	
		public delegate char OnValidateInput(string text, int charIndex, char addedChar); // TypeDefIndex: 13055; 0x0000000180A72B30-0x0000000180A72B50
	
		[Serializable]
		public class SubmitEvent : UnityEvent<string> // TypeDefIndex: 13056
		{
			// Constructors
			public SubmitEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class EndEditEvent : UnityEvent<string> // TypeDefIndex: 13057
		{
			// Constructors
			public EndEditEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class OnChangeEvent : UnityEvent<string> // TypeDefIndex: 13058
		{
			// Constructors
			public OnChangeEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		protected enum EditState // TypeDefIndex: 13059
		{
			Continue = 0,
			Finish = 1
		}
	
		[CompilerGenerated]
		private sealed class _CaretBlink_d__172 : IEnumerator<object> // TypeDefIndex: 13060
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public InputField __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _CaretBlink_d__172(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182596920-0x0000000182596A70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182596A70-0x0000000182596AB0
		}
	
		[CompilerGenerated]
		private sealed class _MouseDragOutsideRect_d__200 : IEnumerator<object> // TypeDefIndex: 13061
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public PointerEventData eventData; // 0x20
			public InputField __4__this; // 0x28
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _MouseDragOutsideRect_d__200(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x0000000182596B80-0x0000000182596F30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000182596F30-0x0000000182596F70
		}
	
		// Constructors
		protected InputField(); // 0x000000018258FD00-0x000000018258FF20
		static InputField(); // 0x000000018258FC20-0x000000018258FD00
	
		// Methods
		public void SetTextWithoutNotify(string input); // 0x000000018258E0A0-0x000000018258E0B0
		private void SetText(string value, bool sendCallback = true /* Metadata: 0x006A7702 */); // 0x000000018258E0B0-0x000000018258E530
		protected void ClampPos(ref int pos); // 0x00000001825872D0-0x0000000182587310
		protected override void OnEnable(); // 0x000000018258C6B0-0x000000018258C910
		protected override void OnDisable(); // 0x000000018258C1B0-0x000000018258C3E0
		protected override void OnDestroy(); // 0x000000018258C150-0x000000018258C1B0
		[IteratorStateMachine(typeof(_CaretBlink_d__172))]
		private IEnumerator CaretBlink(); // 0x0000000182587260-0x00000001825872D0
		private void SetCaretVisible(); // 0x000000018258D7C0-0x000000018258D800
		private void SetCaretActive(); // 0x000000018258D700-0x000000018258D7C0
		private void UpdateCaretMaterial(); // 0x000000018258E880-0x000000018258E980
		protected void OnFocus(); // 0x000000018258CAF0-0x000000018258CB00
		protected void SelectAll(); // 0x000000018258D4D0-0x000000018258D560
		public void MoveTextEnd(bool shift); // 0x000000018258BC70-0x000000018258BDA0
		public void MoveTextStart(bool shift); // 0x000000018258BDA0-0x000000018258BEA0
		private bool TouchScreenKeyboardShouldBeUsed(); // 0x000000018258E5C0-0x000000018258E670
		private bool InPlaceEditing(); // 0x0000000182589C10-0x0000000182589C40
		private bool InPlaceEditingChanged(); // 0x0000000182589B90-0x0000000182589C10
		private RangeInt GetInternalSelection(); // 0x0000000182589570-0x0000000182589670
		private static int VisualToRawPosition(int visualPos, int compositionRawStart, int compositionLength); // 0x000000018258FC00-0x000000018258FC20
		private static int RawToVisualPosition(int rawPos, int compositionRawStart, int compositionLength); // 0x000000018258CFB0-0x000000018258CFD0
		private void UpdateCaretToKeyboard(); // 0x000000018258E980-0x000000018258EAF0
		private void MarkCaretToKeyboardDirty(); // 0x000000018258B330-0x000000018258B340
		private void UpdateKeyboardCaret(); // 0x000000018258EF80-0x000000018258F010
		private void UpdateCaretFromKeyboard(); // 0x000000018258E670-0x000000018258E880
		protected virtual void LateUpdate(); // 0x000000018258A740-0x000000018258AE60
		[Obsolete("This function is no longer used. Please use RectTransformUtility.ScreenPointToLocalPointInRectangle() instead.", true)]
		public Vector2 ScreenToLocal(Vector2 screen); // 0x000000018258CFE0-0x000000018258D4D0
		private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator); // 0x0000000182589910-0x0000000182589B90
		protected int GetCharacterIndexFromPosition(Vector2 pos); // 0x0000000182589320-0x0000000182589570
		private bool MayDrag(PointerEventData eventData); // 0x000000018258B390-0x000000018258B480
		public virtual void OnBeginDrag(PointerEventData eventData); // 0x000000018258C0B0-0x000000018258C0E0
		public virtual void OnDrag(PointerEventData eventData); // 0x000000018258C3E0-0x000000018258C6B0
		[IteratorStateMachine(typeof(_MouseDragOutsideRect_d__200))]
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData); // 0x000000018258B480-0x000000018258B510
		public virtual void OnEndDrag(PointerEventData eventData); // 0x000000018258C910-0x000000018258C940
		public override void OnPointerDown(PointerEventData eventData); // 0x000000018258CB30-0x000000018258CD90
		protected EditState KeyPressed(Event evt); // 0x0000000182589F10-0x000000018258A740
		private bool IsValidChar(char c); // 0x0000000182589EB0-0x0000000182589F10
		public void ProcessEvent(Event e); // 0x000000018258CFA0-0x000000018258CFB0
		public virtual void OnUpdateSelected(BaseEventData eventData); // 0x000000018258CE20-0x000000018258CFA0
		private string GetSelectedString(); // 0x0000000182589850-0x0000000182589910
		private int FindtNextWordBegin(); // 0x0000000182587DC0-0x0000000182587EC0
		private void MoveRight(bool shift, bool ctrl); // 0x000000018258B9B0-0x000000018258BC70
		private int FindtPrevWordBegin(); // 0x0000000182587EC0-0x0000000182587FB0
		private void MoveLeft(bool shift, bool ctrl); // 0x000000018258B720-0x000000018258B9B0
		private int DetermineCharacterLine(int charPos, TextGenerator generator); // 0x00000001825879C0-0x0000000182587AE0
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar); // 0x000000018258B110-0x000000018258B330
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar); // 0x000000018258AE60-0x000000018258B110
		private void MoveDown(bool shift); // 0x000000018258B710-0x000000018258B720
		private void MoveDown(bool shift, bool goToLastChar); // 0x000000018258B510-0x000000018258B710
		private void MoveUp(bool shift); // 0x000000018258BEA0-0x000000018258BEB0
		private void MoveUp(bool shift, bool goToFirstChar); // 0x000000018258BEB0-0x000000018258C0B0
		private void Delete(); // 0x00000001825876F0-0x00000001825879C0
		private void ForwardSpace(); // 0x0000000182587FC0-0x00000001825880E0
		private void Backspace(); // 0x00000001825870D0-0x0000000182587260
		private void Insert(char c); // 0x0000000182589C40-0x0000000182589DE0
		private void UpdateTouchKeyboardFromEditChanges(); // 0x000000018258F4A0-0x000000018258F500
		private void SendOnValueChangedAndUpdateLabel(); // 0x000000018258D660-0x000000018258D680
		private void SendOnValueChanged(); // 0x000000018258D680-0x000000018258D700
		protected void SendOnEndEdit(); // 0x000000018258D560-0x000000018258D5E0
		protected void SendOnSubmit(); // 0x000000018258D5E0-0x000000018258D660
		protected virtual void Append(string input); // 0x00000001825868C0-0x0000000182586970
		protected virtual void Append(char input); // 0x0000000182586540-0x00000001825868C0
		protected void UpdateLabel(); // 0x000000018258F010-0x000000018258F4A0
		private bool IsSelectionVisible(); // 0x0000000182589DE0-0x0000000182589EB0
		private static int GetLineStartPosition(TextGenerator gen, int line); // 0x0000000182589730-0x0000000182589850
		private static int GetLineEndPosition(TextGenerator gen, int line); // 0x0000000182589670-0x0000000182589730
		private void SetDrawRangeToContainCaretPosition(int caretPos); // 0x000000018258D800-0x000000018258E0A0
		public void ForceLabelUpdate(); // 0x0000000182587FB0-0x0000000182587FC0
		private void MarkGeometryAsDirty(); // 0x000000018258B340-0x000000018258B390
		public virtual void Rebuild(CanvasUpdate update); // 0x000000018258CFD0-0x000000018258CFE0
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		private void UpdateGeometry(); // 0x000000018258EAF0-0x000000018258EF80
		private void AssignPositioningIfNeeded(); // 0x0000000182586970-0x00000001825870D0
		private void OnFillVBO(Mesh vbo); // 0x000000018258C940-0x000000018258CAF0
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset); // 0x00000001825880E0-0x0000000182588B40
		private void CreateCursorVerts(); // 0x0000000182587310-0x00000001825874D0
		private void GenerateHighlight(VertexHelper vbo, Vector2 roundingOffset); // 0x0000000182588B40-0x0000000182589320
		protected char Validate(string text, int pos, char ch); // 0x000000018258F500-0x000000018258FC00
		public void ActivateInputField(); // 0x0000000182586410-0x0000000182586540
		private void ActivateInputFieldInternal(); // 0x0000000182586060-0x0000000182586410
		public override void OnSelect(BaseEventData eventData); // 0x000000018258CD90-0x000000018258CDD0
		public virtual void OnPointerClick(PointerEventData eventData); // 0x000000018258CB00-0x000000018258CB30
		public void DeactivateInputField(); // 0x00000001825874D0-0x00000001825876F0
		public override void OnDeselect(BaseEventData eventData); // 0x000000018258C0E0-0x000000018258C150
		public virtual void OnSubmit(BaseEventData eventData); // 0x000000018258CDD0-0x000000018258CE20
		private void EnforceContentType(); // 0x0000000182587B10-0x0000000182587D10
		private void EnforceTextHOverflow(); // 0x0000000182587D10-0x0000000182587DC0
		private void SetToCustomIfContentTypeIsNot(params ContentType[] allowedContentTypes); // 0x000000018258E530-0x000000018258E5A0
		private void SetToCustom(); // 0x000000018258E5A0-0x000000018258E5C0
		protected override void DoStateTransition(SelectionState state, bool instant); // 0x0000000182587AE0-0x0000000182587B10
		public virtual void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
