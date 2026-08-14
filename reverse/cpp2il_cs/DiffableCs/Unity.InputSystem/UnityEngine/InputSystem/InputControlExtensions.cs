namespace UnityEngine.InputSystem;

[Extension]
public static class InputControlExtensions
{
	[CompilerGenerated]
	private sealed class <GetAllButtonPresses>d__43 : IEnumerable<InputControl>, IEnumerable, IEnumerator<InputControl>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private InputControl <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private InputEventPtr eventPtr; //Field offset: 0x28
		public InputEventPtr <>3__eventPtr; //Field offset: 0x30
		private float magnitude; //Field offset: 0x38
		public float <>3__magnitude; //Field offset: 0x3C
		private bool buttonControlsOnly; //Field offset: 0x40
		public bool <>3__buttonControlsOnly; //Field offset: 0x41
		private InputEventControlEnumerator <>7__wrap1; //Field offset: 0x48

		private override InputControl System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.InputControl>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <GetAllButtonPresses>d__43(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<InputControl> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputControl>.GetEnumerator() { }

		[DebuggerHidden]
		private override InputControl System.Collections.Generic.IEnumerator<UnityEngine.InputSystem.InputControl>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal struct ControlBuilder
	{
		[CompilerGenerated]
		private InputControl <control>k__BackingField; //Field offset: 0x0

		public internal InputControl control
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public ControlBuilder At(InputDevice device, int index) { }

		public ControlBuilder DontReset(bool value) { }

		public void Finish() { }

		[CompilerGenerated]
		[IsReadOnly]
		public InputControl get_control() { }

		public ControlBuilder IsButton(bool value) { }

		public ControlBuilder IsNoisy(bool value) { }

		public ControlBuilder IsSynthetic(bool value) { }

		[CompilerGenerated]
		internal void set_control(InputControl value) { }

		public ControlBuilder WithAliases(int startIndex, int count) { }

		public ControlBuilder WithChildren(int startIndex, int count) { }

		public ControlBuilder WithDefaultState(PrimitiveValue value) { }

		public ControlBuilder WithDisplayName(string displayName) { }

		public ControlBuilder WithLayout(InternedString layout) { }

		public ControlBuilder WithMinAndMax(PrimitiveValue min, PrimitiveValue max) { }

		public ControlBuilder WithName(string name) { }

		public ControlBuilder WithParent(InputControl parent) { }

		public ControlBuilder WithProcessor(TProcessor processor) { }

		public ControlBuilder WithShortDisplayName(string shortDisplayName) { }

		public ControlBuilder WithStateBlock(InputStateBlock stateBlock) { }

		public ControlBuilder WithUsages(int startIndex, int count) { }

	}

	internal struct DeviceBuilder
	{
		[CompilerGenerated]
		private InputDevice <device>k__BackingField; //Field offset: 0x0

		public internal InputDevice device
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
			[CompilerGenerated]
			internal set { } //Length: 8
		}

		public void Finish() { }

		[CompilerGenerated]
		[IsReadOnly]
		public InputDevice get_device() { }

		public DeviceBuilder IsNoisy(bool value) { }

		[CompilerGenerated]
		internal void set_device(InputDevice value) { }

		public DeviceBuilder WithChildren(int startIndex, int count) { }

		public DeviceBuilder WithControlAlias(int controlIndex, InternedString alias) { }

		public DeviceBuilder WithControlTree(Byte[] controlTreeNodes, UInt16[] controlTreeIndicies) { }

		public DeviceBuilder WithControlUsage(int controlIndex, InternedString usage, InputControl control) { }

		public DeviceBuilder WithDisplayName(string displayName) { }

		public DeviceBuilder WithLayout(InternedString layout) { }

		public DeviceBuilder WithName(string name) { }

		public DeviceBuilder WithShortDisplayName(string shortDisplayName) { }

		public DeviceBuilder WithStateBlock(InputStateBlock stateBlock) { }

		public DeviceBuilder WithStateOffsetToControlIndexMap(UInt32[] map) { }

	}

	[Flags]
	internal enum Enumerate
	{
		IgnoreControlsInDefaultState = 1,
		IgnoreControlsInCurrentState = 2,
		IncludeSyntheticControls = 4,
		IncludeNoisyControls = 8,
		IncludeNonLeafControls = 16,
	}

	internal struct InputEventControlCollection : IEnumerable<InputControl>, IEnumerable
	{
		internal InputDevice m_Device; //Field offset: 0x0
		internal InputEventPtr m_EventPtr; //Field offset: 0x8
		internal Enumerate m_Flags; //Field offset: 0x10
		internal float m_MagnitudeThreshold; //Field offset: 0x14

		public InputEventPtr eventPtr
		{
			 get { } //Length: 5
		}

		public InputEventPtr get_eventPtr() { }

		public InputEventControlEnumerator GetEnumerator() { }

		private override IEnumerator<InputControl> System.Collections.Generic.IEnumerable<UnityEngine.InputSystem.InputControl>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	internal struct InputEventControlEnumerator : IEnumerator<InputControl>, IEnumerator, IDisposable
	{
		private Enumerate m_Flags; //Field offset: 0x0
		private readonly InputDevice m_Device; //Field offset: 0x8
		private readonly UInt32[] m_StateOffsetToControlIndex; //Field offset: 0x10
		private readonly int m_StateOffsetToControlIndexLength; //Field offset: 0x18
		private readonly InputControl[] m_AllControls; //Field offset: 0x20
		private Byte* m_DefaultState; //Field offset: 0x28
		private Byte* m_CurrentState; //Field offset: 0x30
		private Byte* m_NoiseMask; //Field offset: 0x38
		private InputEventPtr m_EventPtr; //Field offset: 0x40
		private InputControl m_CurrentControl; //Field offset: 0x48
		private int m_CurrentIndexInStateOffsetToControlIndexMap; //Field offset: 0x50
		private uint m_CurrentControlStateBitOffset; //Field offset: 0x54
		private Byte* m_EventState; //Field offset: 0x58
		private uint m_CurrentBitOffset; //Field offset: 0x60
		private uint m_EndBitOffset; //Field offset: 0x64
		private float m_MagnitudeThreshold; //Field offset: 0x68

		public override InputControl Current
		{
			 get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 5
		}

		internal InputEventControlEnumerator(InputEventPtr eventPtr, InputDevice device, Enumerate flags, float magnitudeThreshold = 0) { }

		private bool CheckCurrent(uint numBits) { }

		private bool CheckDefault(uint numBits) { }

		public override void Dispose() { }

		public override InputControl get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}


	[Extension]
	internal static void AccumulateValueInEvent(InputControl<Vector2> control, Void* currentStatePtr, InputEventPtr newState) { }

	[Extension]
	public static void AccumulateValueInEvent(InputControl<Single> control, Void* currentStatePtr, InputEventPtr newState) { }

	[Extension]
	internal static string BuildPath(InputControl control, string deviceLayout, StringBuilder builder = null) { }

	[Extension]
	public static bool CheckStateIsAtDefault(InputControl control, Void* statePtr, Void* maskPtr = null) { }

	[Extension]
	public static bool CheckStateIsAtDefault(InputControl control) { }

	[Extension]
	public static bool CheckStateIsAtDefaultIgnoringNoise(InputControl control, Void* statePtr) { }

	[Extension]
	public static bool CheckStateIsAtDefaultIgnoringNoise(InputControl control) { }

	[Extension]
	public static bool CompareState(InputControl control, Void* statePtr, Void* maskPtr = null) { }

	[Extension]
	public static bool CompareState(InputControl control, Void* firstStatePtr, Void* secondStatePtr, Void* maskPtr = null) { }

	[Extension]
	public static bool CompareStateIgnoringNoise(InputControl control, Void* statePtr) { }

	[Extension]
	public static void CopyState(InputDevice device, out TState state) { }

	[Extension]
	public static void CopyState(InputDevice device, Void* buffer, int bufferSizeInBytes) { }

	[Extension]
	public static InputEventControlCollection EnumerateChangedControls(InputEventPtr eventPtr, InputDevice device = null, float magnitudeThreshold = 0) { }

	[Extension]
	public static InputEventControlCollection EnumerateControls(InputEventPtr eventPtr, Enumerate flags, InputDevice device = null, float magnitudeThreshold = 0) { }

	[Extension]
	public static void FindControlsRecursive(InputControl parent, IList<TControl> controls, Func<TControl, Boolean> predicate) { }

	[Extension]
	public static TControl FindInParentChain(InputControl control) { }

	[Extension]
	[IteratorStateMachine(typeof(<GetAllButtonPresses>d__43))]
	public static IEnumerable<InputControl> GetAllButtonPresses(InputEventPtr eventPtr, float magnitude = -1, bool buttonControlsOnly = true) { }

	[Extension]
	public static InputControl GetFirstButtonPressOrNull(InputEventPtr eventPtr, float magnitude = -1, bool buttonControlsOnly = true) { }

	[Extension]
	public static Void* GetStatePtrFromStateEvent(InputControl control, InputEventPtr eventPtr) { }

	[Extension]
	internal static Void* GetStatePtrFromStateEventUnchecked(InputControl control, InputEventPtr eventPtr, FourCC eventType) { }

	[Extension]
	public static bool HasButtonPress(InputEventPtr eventPtr, float magnitude = -1, bool buttonControlsOnly = true) { }

	[Extension]
	public static bool HasValueChangeInEvent(InputControl control, InputEventPtr eventPtr) { }

	[Extension]
	public static bool HasValueChangeInState(InputControl control, Void* statePtr) { }

	[Extension]
	public static bool IsActuated(InputControl control, float threshold = 0) { }

	[Extension]
	public static bool IsPressed(InputControl control, float buttonPressPoint = 0) { }

	[Extension]
	public static void QueueValueChange(InputControl<TValue> control, TValue value, double time = -1) { }

	[Extension]
	public static object ReadDefaultValueAsObject(InputControl control) { }

	[Extension]
	public static TValue ReadUnprocessedValueFromEvent(InputControl<TValue> control, InputEventPtr eventPtr) { }

	[Extension]
	public static bool ReadUnprocessedValueFromEvent(InputControl<TValue> control, InputEventPtr inputEvent, out TValue value) { }

	[Extension]
	public static object ReadValueAsObject(InputControl control) { }

	[Extension]
	public static bool ReadValueFromEvent(InputControl<TValue> control, InputEventPtr inputEvent, out TValue value) { }

	[Extension]
	public static TValue ReadValueFromEvent(InputControl<TValue> control, InputEventPtr inputEvent) { }

	[Extension]
	public static object ReadValueFromEventAsObject(InputControl control, InputEventPtr inputEvent) { }

	[Extension]
	public static void ReadValueIntoBuffer(InputControl control, Void* buffer, int bufferSize) { }

	[Extension]
	public static bool ResetToDefaultStateInEvent(InputControl control, InputEventPtr eventPtr) { }

	[Extension]
	public static DeviceBuilder Setup(InputDevice device, int controlCount, int usageCount, int aliasCount) { }

	[Extension]
	public static ControlBuilder Setup(InputControl control) { }

	[Extension]
	public static void WriteValueFromObjectIntoEvent(InputControl control, InputEventPtr eventPtr, object value) { }

	[Extension]
	public static void WriteValueIntoEvent(InputControl<TValue> control, TValue value, InputEventPtr eventPtr) { }

	[Extension]
	public static void WriteValueIntoEvent(InputControl control, TValue value, InputEventPtr eventPtr) { }

	[Extension]
	public static void WriteValueIntoState(InputControl control, Void* statePtr) { }

	[Extension]
	public static void WriteValueIntoState(InputControl control, TValue value, Void* statePtr) { }

	[Extension]
	public static void WriteValueIntoState(InputControl<TValue> control, TValue value, Void* statePtr) { }

	[Extension]
	public static void WriteValueIntoState(InputControl<TValue> control, Void* statePtr) { }

	[Extension]
	public static void WriteValueIntoState(InputControl<TValue> control, TValue value, ref TState state) { }

}

