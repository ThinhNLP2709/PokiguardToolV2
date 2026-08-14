namespace UnityEngine.InputForUI;

internal class InputManagerProvider : IEventProviderImpl
{
	private struct ButtonEventsIterator : IEnumerator
	{
		private uint _mask; //Field offset: 0x0
		private int _bit; //Field offset: 0x4

		public bool Current
		{
			 get { } //Length: 9
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 38
		}

		public static ButtonEventsIterator FromState(bool previous, bool down, bool up, bool current) { }

		public bool get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	internal struct Configuration
	{
		public string HorizontalAxis; //Field offset: 0x0
		public string VerticalAxis; //Field offset: 0x8
		public string SubmitButton; //Field offset: 0x10
		public string CancelButton; //Field offset: 0x18
		public string NavigateNextButton; //Field offset: 0x20
		public string NavigatePreviousButton; //Field offset: 0x28
		public float InputActionsPerSecond; //Field offset: 0x30
		public float RepeatDelay; //Field offset: 0x34

		public static Configuration GetDefaultConfiguration() { }

	}

	public interface IInput
	{

		public string compositionString
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

		public Vector2 mouseScrollDelta
		{
			 get { } //Length: 0
		}

		public int touchCount
		{
			 get { } //Length: 0
		}

		public bool touchSupported
		{
			 get { } //Length: 0
		}

		public string get_compositionString() { }

		public Vector3 get_mousePosition() { }

		public bool get_mousePresent() { }

		public Vector2 get_mouseScrollDelta() { }

		public int get_touchCount() { }

		public bool get_touchSupported() { }

		public float GetAxisRaw(string axis) { }

		public bool GetButtonDown(string button) { }

		public bool GetKey(KeyCode keyCode) { }

		public PenData GetLastPenContactEvent() { }

		public bool GetMouseButton(int button) { }

		public bool GetMouseButtonDown(int button) { }

		public bool GetMouseButtonUp(int button) { }

		public Touch GetTouch(int index) { }

	}

	private class Input : IInput
	{

		public override string compositionString
		{
			 get { } //Length: 7
		}

		public override Vector3 mousePosition
		{
			 get { } //Length: 44
		}

		public override bool mousePresent
		{
			 get { } //Length: 7
		}

		public override Vector2 mouseScrollDelta
		{
			 get { } //Length: 7
		}

		public override int touchCount
		{
			 get { } //Length: 7
		}

		public override bool touchSupported
		{
			 get { } //Length: 7
		}

		public Input() { }

		public override string get_compositionString() { }

		public override Vector3 get_mousePosition() { }

		public override bool get_mousePresent() { }

		public override Vector2 get_mouseScrollDelta() { }

		public override int get_touchCount() { }

		public override bool get_touchSupported() { }

		public override float GetAxisRaw(string axis) { }

		public override bool GetButtonDown(string button) { }

		public override bool GetKey(KeyCode key) { }

		public override PenData GetLastPenContactEvent() { }

		public override bool GetMouseButton(int button) { }

		public override bool GetMouseButtonDown(int button) { }

		public override bool GetMouseButtonUp(int button) { }

		public override Touch GetTouch(int index) { }

	}

	public interface ITime
	{

		public RationalTime timeAsRational
		{
			 get { } //Length: 0
		}

		public RationalTime get_timeAsRational() { }

	}

	private class Time : ITime
	{

		public override RationalTime timeAsRational
		{
			 get { } //Length: 36
		}

		public Time() { }

		public override RationalTime get_timeAsRational() { }

	}

	private InputEventPartialProvider _inputEventPartialProvider; //Field offset: 0x10
	private string _compositionString; //Field offset: 0x18
	private Configuration _configuration; //Field offset: 0x20
	private IInput _input; //Field offset: 0x58
	private ITime _time; //Field offset: 0x60
	private NavigationEventRepeatHelper _navigationEventRepeatHelper; //Field offset: 0x68
	private PointerState _mouseState; //Field offset: 0x70
	private bool _isPenPresent; //Field offset: 0x98
	private bool _seenAtLeastOnePenPosition; //Field offset: 0x99
	private Vector2 _lastSeenPenPositionForDetection; //Field offset: 0x9C
	private PointerState _penState; //Field offset: 0xA8
	private PenData _lastPenData; //Field offset: 0xD0
	private Dictionary<Int32, Int32> _touchFingerIdToFingerIndex; //Field offset: 0xF8
	private int _touchNextFingerIndex; //Field offset: 0x100
	private PointerState _touchState; //Field offset: 0x108

	private EventModifiers _eventModifiers
	{
		private get { } //Length: 26
	}

	public InputManagerProvider() { }

	internal static Vector2 AzimuthAndAlitutudeToTilt(float altitude, float azimuth) { }

	private void CheckIfIMEChanged(DiscreteTime currentTime) { }

	private void CheckMouseEvents(DiscreteTime currentTime, bool muted = false) { }

	private void CheckMouseScroll(DiscreteTime currentTime) { }

	private bool CheckPenEvent(DiscreteTime currentTime, in PenData currentPenData) { }

	private bool CheckTouchEvents(DiscreteTime currentTime) { }

	private void DetectPen() { }

	private void DirectionNavigation(DiscreteTime currentTime) { }

	private EventModifiers get__eventModifiers() { }

	private EventSource GetEventSourceFromPressedKey() { }

	public override void Initialize() { }

	private float InputManagerGetAxisRawOrDefault(string axisName) { }

	private bool InputManagerGetButtonDownOrDefault(string axisName) { }

	private bool InputManagerJoystickWasPressed() { }

	private bool InputManagerKeyboardWasPressed() { }

	private static Vector2 MultiDisplayBottomLeftToPanelPosition(Vector2 position, out int targetDisplay) { }

	private static Vector2 MultiDisplayToLocalScreenPosition(Vector2 position, out Nullable<Int32>& targetDisplay) { }

	private void NextPreviousNavigation(DiscreteTime currentTime) { }

	public override void OnFocusChanged(bool focus) { }

	private static Button PenStatusToButton(PenStatus status) { }

	private ValueTuple<Vector2, Boolean> ReadCurrentNavigationMoveVector() { }

	private static Vector2 ScreenBottomLeftToPanelPosition(Vector2 position, int targetDisplay) { }

	public override void Shutdown() { }

	private void SubmitCancelNavigation(DiscreteTime currentTime) { }

	internal static float TiltToAltitude(Vector2 tilt) { }

	internal static float TiltToAzimuth(Vector2 tilt) { }

	private IMECompositionEvent ToIMECompositionEvent(DiscreteTime currentTime, string compositionString) { }

	public override void Update() { }

}

