namespace UnityEngine.UIElements;

internal class DefaultEventSystem
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal bool <.cctor>b__48_0() { }

	}

	public struct FocusBasedEventSequenceContext : IDisposable
	{
		private DefaultEventSystem es; //Field offset: 0x0

		public FocusBasedEventSequenceContext(DefaultEventSystem es) { }

		public override void Dispose() { }

	}

	private class InputForUIProcessor
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"pointerEvent", "pointerId", "deltaTime"})]
			public static Func<Vector3, Vector3, ValueTuple`3<PointerEvent, Int32, Single>, EventBase> <>9__9_0; //Field offset: 0x8
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"pointerEvent", "pointerId", "deltaTime"})]
			public static Func<Vector3, Vector3, ValueTuple`3<PointerEvent, Int32, Single>, EventBase> <>9__9_1; //Field offset: 0x10
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"pointerEvent", "pointerId", "deltaTime"})]
			public static Func<Vector3, Vector3, ValueTuple`3<PointerEvent, Int32, Single>, EventBase> <>9__9_2; //Field offset: 0x18
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"pointerEvent", "pointerId", "deltaTime"})]
			public static Func<Vector3, Vector3, ValueTuple`3<PointerEvent, Int32, Single>, EventBase> <>9__9_3; //Field offset: 0x20
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"modifiers", "scrollDelta"})]
			public static Func<Vector3, Vector3, ValueTuple`2<EventModifiers, Vector2>, EventBase> <>9__9_4; //Field offset: 0x28
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"move", "deviceType", "mod"})]
			public static Func<ValueTuple`3<Vector2, NavigationDeviceType, EventModifiers>, EventBase> <>9__10_2; //Field offset: 0x30
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"direction", "deviceType", "mod"})]
			public static Func<ValueTuple`3<Direction, NavigationDeviceType, EventModifiers>, EventBase> <>9__10_3; //Field offset: 0x38
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"deviceType", "mod"})]
			public static Func<ValueTuple`2<NavigationDeviceType, EventModifiers>, EventBase> <>9__10_0; //Field offset: 0x40
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"deviceType", "mod"})]
			public static Func<ValueTuple`2<NavigationDeviceType, EventModifiers>, EventBase> <>9__10_1; //Field offset: 0x48
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"modifiers", "keyCode"})]
			public static Func<ValueTuple`2<EventModifiers, KeyCode>, EventBase> <>9__11_0; //Field offset: 0x50
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"modifiers", "keyCode"})]
			public static Func<ValueTuple`2<EventModifiers, KeyCode>, EventBase> <>9__11_1; //Field offset: 0x58
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"modifiers", "character"})]
			public static Func<ValueTuple`2<EventModifiers, Char>, EventBase> <>9__12_0; //Field offset: 0x60

			private static <>c() { }

			public <>c() { }

			internal EventBase <ProcessKeyEvent>b__11_0(ValueTuple<EventModifiers, KeyCode> t) { }

			internal EventBase <ProcessKeyEvent>b__11_1(ValueTuple<EventModifiers, KeyCode> t) { }

			internal EventBase <ProcessNavigationEvent>b__10_0(ValueTuple<NavigationDeviceType, EventModifiers> t) { }

			internal EventBase <ProcessNavigationEvent>b__10_1(ValueTuple<NavigationDeviceType, EventModifiers> t) { }

			internal EventBase <ProcessNavigationEvent>b__10_2(ValueTuple<Vector2, NavigationDeviceType, EventModifiers> t) { }

			internal EventBase <ProcessNavigationEvent>b__10_3(ValueTuple<Direction, NavigationDeviceType, EventModifiers> t) { }

			internal EventBase <ProcessPointerEvent>b__9_0(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<PointerEvent, Int32, Single> t) { }

			internal EventBase <ProcessPointerEvent>b__9_1(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<PointerEvent, Int32, Single> t) { }

			internal EventBase <ProcessPointerEvent>b__9_2(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<PointerEvent, Int32, Single> t) { }

			internal EventBase <ProcessPointerEvent>b__9_3(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<PointerEvent, Int32, Single> t) { }

			internal EventBase <ProcessPointerEvent>b__9_4(Vector3 panelPosition, Vector3 _, ValueTuple<EventModifiers, Vector2> t) { }

			internal EventBase <ProcessTextInputEvent>b__12_0(ValueTuple<EventModifiers, Char> t) { }

		}

		private readonly DefaultEventSystem m_EventSystem; //Field offset: 0x10
		private DiscreteTime m_LastPointerTimestamp; //Field offset: 0x18
		private DiscreteTime m_NextPointerTimestamp; //Field offset: 0x20
		private readonly Queue<Event> m_EventList; //Field offset: 0x28

		public InputForUIProcessor(DefaultEventSystem eventSystem) { }

		private EventModifiers GetModifiers(EventModifiers eventModifiers) { }

		public bool OnEvent(in Event ev) { }

		private void ProcessCommandEvent(CommandEvent commandEvent) { }

		private void ProcessIMECompositionEvent(IMECompositionEvent compositionEvent) { }

		public void ProcessInputForUIEvents() { }

		private void ProcessKeyEvent(KeyEvent keyEvent) { }

		private void ProcessNavigationEvent(NavigationEvent navigationEvent) { }

		private void ProcessPointerEvent(PointerEvent pointerEvent) { }

		private void ProcessTextInputEvent(TextInputEvent textInputEvent) { }

	}

	public class LegacyInputProcessor
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Func<Event, EventBase> <>9__26_0; //Field offset: 0x8
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"modifiers", "scrollDelta"})]
			public static Func<Vector3, Vector3, ValueTuple`2<EventModifiers, Vector2>, EventBase> <>9__26_1; //Field offset: 0x10
			public static Func<Vector3, Vector3, Event, EventBase> <>9__26_2; //Field offset: 0x18
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"modifiers", "targetDisplay"})]
			public static Func<Vector3, Vector3, ValueTuple`2<EventModifiers, Nullable`1<Int32>>, EventBase> <>9__27_0; //Field offset: 0x20
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"button", "clickCount", "modifiers", "targetDisplay"})]
			public static Func<Vector3, Vector3, ValueTuple`4<Int32, Int32, EventModifiers, Nullable`1<Int32>>, EventBase> <>9__27_1; //Field offset: 0x28
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"button", "clickCount", "modifiers", "targetDisplay"})]
			public static Func<Vector3, Vector3, ValueTuple`4<Int32, Int32, EventModifiers, Nullable`1<Int32>>, EventBase> <>9__27_2; //Field offset: 0x30
			public static Func<LegacyInputProcessor, EventBase> <>9__28_0; //Field offset: 0x38
			public static Func<LegacyInputProcessor, EventBase> <>9__28_1; //Field offset: 0x40
			public static Func<LegacyInputProcessor, EventBase> <>9__28_2; //Field offset: 0x48
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"touch", "targetDisplay"})]
			public static Func<Vector3, Vector3, ValueTuple`2<Touch, Nullable`1<Int32>>, EventBase> <>9__29_0; //Field offset: 0x50
			public static Func<Vector3, Vector3, PenData, EventBase> <>9__30_0; //Field offset: 0x58
			[TupleElementNames(new IL2CPP_TYPE_STRING[] {"direction", "modifiers", "input"})]
			public static Func<ValueTuple`3<Direction, EventModifiers, IInput>, EventBase> <>9__37_0; //Field offset: 0x60

			private static <>c() { }

			public <>c() { }

			internal EventBase <ProcessMouseEvents>b__27_0(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<EventModifiers, Nullable`1<Int32>> t) { }

			internal EventBase <ProcessMouseEvents>b__27_1(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<Int32, Int32, EventModifiers, Nullable`1<Int32>> t) { }

			internal EventBase <ProcessMouseEvents>b__27_2(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<Int32, Int32, EventModifiers, Nullable`1<Int32>> t) { }

			internal EventBase <ProcessPenEvents>b__30_0(Vector3 panelPosition, Vector3 panelDelta, PenData _pen) { }

			internal EventBase <ProcessTabEvent>b__37_0(ValueTuple<Direction, EventModifiers, IInput> t) { }

			internal EventBase <ProcessTouchEvents>b__29_0(Vector3 panelPosition, Vector3 panelDelta, ValueTuple<Touch, Nullable`1<Int32>> t) { }

			internal EventBase <SendIMGUIEvents>b__26_0(Event e) { }

			internal EventBase <SendIMGUIEvents>b__26_1(Vector3 panelPosition, Vector3 _, ValueTuple<EventModifiers, Vector2> t) { }

			internal EventBase <SendIMGUIEvents>b__26_2(Vector3 panelPosition, Vector3 panelDelta, Event evt) { }

			internal EventBase <SendInputEvents>b__28_0(LegacyInputProcessor self) { }

			internal EventBase <SendInputEvents>b__28_1(LegacyInputProcessor self) { }

			internal EventBase <SendInputEvents>b__28_2(LegacyInputProcessor self) { }

		}

		public interface IInput
		{

			public bool anyKey
			{
				 get { } //Length: 0
			}

			public float doubleClickTime
			{
				 get { } //Length: 0
			}

			public int mouseButtonCount
			{
				 get { } //Length: 0
			}

			public Vector3 mousePosition
			{
				 get { } //Length: 0
			}

			public bool mousePresent
			{
				 get { } //Length: 0
			}

			public int touchCount
			{
				 get { } //Length: 0
			}

			public float unscaledTime
			{
				 get { } //Length: 0
			}

			public void ClearLastPenContactEvent() { }

			public bool get_anyKey() { }

			public float get_doubleClickTime() { }

			public int get_mouseButtonCount() { }

			public Vector3 get_mousePosition() { }

			public bool get_mousePresent() { }

			public int get_touchCount() { }

			public float get_unscaledTime() { }

			public float GetAxisRaw(string axis) { }

			public bool GetButtonDown(string button) { }

			public PenData GetLastPenContactEvent() { }

			public bool GetMouseButtonDown(int button) { }

			public bool GetMouseButtonUp(int button) { }

			public Touch GetTouch(int index) { }

		}

		private class Input : IInput
		{

			public override bool anyKey
			{
				 get { } //Length: 7
			}

			public override float doubleClickTime
			{
				 get { } //Length: 31
			}

			public override int mouseButtonCount
			{
				 get { } //Length: 6
			}

			public override Vector3 mousePosition
			{
				 get { } //Length: 44
			}

			public override bool mousePresent
			{
				 get { } //Length: 7
			}

			public override int touchCount
			{
				 get { } //Length: 7
			}

			public override float unscaledTime
			{
				 get { } //Length: 7
			}

			public Input() { }

			public override void ClearLastPenContactEvent() { }

			public override bool get_anyKey() { }

			public override float get_doubleClickTime() { }

			public override int get_mouseButtonCount() { }

			public override Vector3 get_mousePosition() { }

			public override bool get_mousePresent() { }

			public override int get_touchCount() { }

			public override float get_unscaledTime() { }

			public override float GetAxisRaw(string axis) { }

			public override bool GetButtonDown(string button) { }

			public override PenData GetLastPenContactEvent() { }

			public override bool GetMouseButtonDown(int button) { }

			public override bool GetMouseButtonUp(int button) { }

			public override Touch GetTouch(int index) { }

		}

		private class NoInput : IInput
		{

			public override bool anyKey
			{
				 get { } //Length: 3
			}

			public override float doubleClickTime
			{
				 get { } //Length: 9
			}

			public override int mouseButtonCount
			{
				 get { } //Length: 3
			}

			public override Vector3 mousePosition
			{
				 get { } //Length: 12
			}

			public override bool mousePresent
			{
				 get { } //Length: 3
			}

			public override int touchCount
			{
				 get { } //Length: 3
			}

			public override float unscaledTime
			{
				 get { } //Length: 4
			}

			public NoInput() { }

			public override void ClearLastPenContactEvent() { }

			public override bool get_anyKey() { }

			public override float get_doubleClickTime() { }

			public override int get_mouseButtonCount() { }

			public override Vector3 get_mousePosition() { }

			public override bool get_mousePresent() { }

			public override int get_touchCount() { }

			public override float get_unscaledTime() { }

			public override float GetAxisRaw(string axis) { }

			public override bool GetButtonDown(string button) { }

			public override PenData GetLastPenContactEvent() { }

			public override bool GetMouseButtonDown(int button) { }

			public override bool GetMouseButtonUp(int button) { }

			public override Touch GetTouch(int index) { }

		}

		private bool m_SendingTouchEvents; //Field offset: 0x10
		private bool m_SendingPenEvent; //Field offset: 0x11
		private EventModifiers m_CurrentModifiers; //Field offset: 0x14
		private int m_LastMousePressButton; //Field offset: 0x18
		private float m_NextMousePressTime; //Field offset: 0x1C
		private int m_LastMouseClickCount; //Field offset: 0x20
		private Vector2 m_LastMousePosition; //Field offset: 0x24
		private bool m_MouseProcessedAtLeastOnce; //Field offset: 0x2C
		private IInput m_Input; //Field offset: 0x30
		private readonly Event m_Event; //Field offset: 0x38
		private readonly DefaultEventSystem m_EventSystem; //Field offset: 0x40
		private int m_ConsecutiveMoveCount; //Field offset: 0x48
		private Vector2 m_LastMoveVector; //Field offset: 0x4C
		private float m_PrevActionTime; //Field offset: 0x54
		private bool m_IsMoveFromKeyboard; //Field offset: 0x58

		public IInput input
		{
			 get { } //Length: 63
		}

		private EventModifiers m_CurrentPointerModifiers
		{
			private get { } //Length: 7
		}

		public LegacyInputProcessor(DefaultEventSystem eventSystem) { }

		public IInput get_input() { }

		private EventModifiers get_m_CurrentPointerModifiers() { }

		public IInput GetDefaultInput() { }

		private Vector2 GetRawMoveVector() { }

		public void ProcessLegacyInputEvents() { }

		private void ProcessMouseEvents() { }

		private bool ProcessPenEvents() { }

		private void ProcessTabEvent(Event e, EventModifiers modifiers) { }

		private bool ProcessTouchEvents() { }

		private void SendIMGUIEvents() { }

		private void SendInputEvents() { }

		private bool ShouldSendMoveFromInput() { }

	}

	internal enum UpdateMode
	{
		Always = 0,
		IgnoreIfAppNotFocused = 1,
	}

	internal static Func<Boolean> IsEditorRemoteConnected; //Field offset: 0x0
	private BaseRuntimePanel m_FocusedPanel; //Field offset: 0x10
	private BaseRuntimePanel m_PreviousFocusedPanel; //Field offset: 0x18
	private Focusable m_PreviousFocusedElement; //Field offset: 0x20
	private LegacyInputProcessor m_LegacyInputProcessor; //Field offset: 0x28
	private InputForUIProcessor m_InputForUIProcessor; //Field offset: 0x30
	private bool m_IsInputReady; //Field offset: 0x38
	private bool m_UseInputForUI; //Field offset: 0x39
	private bool m_IsInputForUIActive; //Field offset: 0x3A
	internal bool verbose; //Field offset: 0x3B
	internal bool logToGameScreen; //Field offset: 0x3C
	private Label m_LogLabel; //Field offset: 0x40
	private List<String> m_LogLines; //Field offset: 0x48

	public BaseRuntimePanel focusedPanel
	{
		 get { } //Length: 5
		 set { } //Length: 81
	}

	private InputForUIProcessor inputForUIProcessor
	{
		private get { } //Length: 300
	}

	private bool isAppFocused
	{
		private get { } //Length: 64
	}

	internal bool isInputReady
	{
		internal set { } //Length: 498
	}

	internal LegacyInputProcessor legacyInputProcessor
	{
		internal get { } //Length: 278
	}

	private static DefaultEventSystem() { }

	public DefaultEventSystem() { }

	internal FocusBasedEventSequenceContext FocusBasedEventSequence() { }

	public BaseRuntimePanel get_focusedPanel() { }

	private InputForUIProcessor get_inputForUIProcessor() { }

	private bool get_isAppFocused() { }

	internal LegacyInputProcessor get_legacyInputProcessor() { }

	private void InitInputProcessor() { }

	private void Log(object o) { }

	private void LogToGameScreen(string s) { }

	private void LogWarning(object o) { }

	private static EventBase MakePenEvent(PenData pen, EventModifiers modifiers, int targetDisplay) { }

	private static EventBase MakeTouchEvent(Touch touch, EventModifiers modifiers, int targetDisplay) { }

	internal void OnFocusEvent(RuntimePanel panel, FocusEvent evt) { }

	private void RemoveInputProcessor() { }

	internal void SendFocusBasedEvent(Func<TArg, EventBase> evtFactory, TArg arg) { }

	private void SendPositionBasedEvent(Vector3 mousePosition, Vector3 delta, int pointerId, Nullable<Int32> targetDisplay, Func<Vector3, Vector3, TArg, EventBase> evtFactory, TArg arg, bool deselectIfNoTarget = false) { }

	public void set_focusedPanel(BaseRuntimePanel value) { }

	internal void set_isInputReady(bool value) { }

	private bool ShouldIgnoreEventsOnAppNotFocused() { }

	public void Update(UpdateMode updateMode = 0) { }

	private void UpdateFocusedPanel(BaseRuntimePanel runtimePanel) { }

}

