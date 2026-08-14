namespace UnityEngine.InputSystem;

public class InputDevice : InputControl
{
	public struct ControlBitRangeNode
	{
		public ushort endBitOffset; //Field offset: 0x0
		public short leftChildIndex; //Field offset: 0x2
		public ushort controlStartIndex; //Field offset: 0x4
		public byte controlCount; //Field offset: 0x6

		public ControlBitRangeNode(ushort endOffset) { }

	}

	[Flags]
	public enum DeviceFlags
	{
		UpdateBeforeRender = 1,
		HasStateCallbacks = 2,
		HasControlsWithDefaultState = 4,
		HasDontResetControls = 1024,
		HasEventMerger = 8192,
		HasEventPreProcessor = 16384,
		Remote = 8,
		Native = 16,
		DisabledInFrontend = 32,
		DisabledInRuntime = 128,
		DisabledWhileInBackground = 256,
		DisabledStateHasBeenQueriedFromRuntime = 64,
		CanRunInBackground = 2048,
		CanRunInBackgroundHasBeenQueried = 4096,
	}

	public const int InvalidDeviceId = 0; //Field offset: 0x0
	internal const int kControlIndexBits = 10; //Field offset: 0x0
	internal const int kStateOffsetBits = 13; //Field offset: 0x0
	internal const int kStateSizeBits = 9; //Field offset: 0x0
	internal const int kInvalidDeviceIndex = -1; //Field offset: 0x0
	internal const int kLocalParticipantId = 0; //Field offset: 0x0
	internal DeviceFlags m_DeviceFlags; //Field offset: 0xE0
	internal int m_DeviceId; //Field offset: 0xE4
	internal int m_ParticipantId; //Field offset: 0xE8
	internal int m_DeviceIndex; //Field offset: 0xEC
	internal uint m_CurrentProcessedEventBytesOnUpdate; //Field offset: 0xF0
	internal InputDeviceDescription m_Description; //Field offset: 0xF8
	internal double m_LastUpdateTimeInternal; //Field offset: 0x130
	internal uint m_CurrentUpdateStepCount; //Field offset: 0x138
	internal InternedString[] m_AliasesForEachControl; //Field offset: 0x140
	internal InternedString[] m_UsagesForEachControl; //Field offset: 0x148
	internal InputControl[] m_UsageToControl; //Field offset: 0x150
	internal InputControl[] m_ChildrenForEachControl; //Field offset: 0x158
	internal HashSet<Int32> m_UpdatedButtons; //Field offset: 0x160
	internal List<ButtonControl> m_ButtonControlsCheckingPressState; //Field offset: 0x168
	internal bool m_UseCachePathForButtonPresses; //Field offset: 0x170
	internal UInt32[] m_StateOffsetToControlMap; //Field offset: 0x178
	internal ControlBitRangeNode[] m_ControlTreeNodes; //Field offset: 0x180
	internal UInt16[] m_ControlTreeIndices; //Field offset: 0x188

	public bool added
	{
		 get { } //Length: 11
	}

	[Obsolete("Use 'InputSystem.devices' instead. (UnityUpgradable) -> InputSystem.devices", False)]
	public static ReadOnlyArray<InputDevice> all
	{
		 get { } //Length: 163
	}

	public ReadOnlyArray<InputControl> allControls
	{
		 get { } //Length: 86
	}

	internal bool canDeviceRunInBackground
	{
		internal get { } //Length: 187
	}

	public bool canRunInBackground
	{
		 get { } //Length: 187
	}

	public InputDeviceDescription description
	{
		 get { } //Length: 49
	}

	public int deviceId
	{
		 get { } //Length: 7
	}

	internal bool disabledInFrontend
	{
		internal get { } //Length: 11
		internal set { } //Length: 31
	}

	internal bool disabledInRuntime
	{
		internal get { } //Length: 14
		internal set { } //Length: 33
	}

	internal bool disabledWhileInBackground
	{
		internal get { } //Length: 14
		internal set { } //Length: 33
	}

	public bool enabled
	{
		 get { } //Length: 196
	}

	internal bool hasControlsWithDefaultState
	{
		internal get { } //Length: 12
		internal set { } //Length: 31
	}

	internal bool hasDontResetControls
	{
		internal get { } //Length: 12
		internal set { } //Length: 33
	}

	internal bool hasEventMerger
	{
		internal get { } //Length: 12
		internal set { } //Length: 33
	}

	internal bool hasEventPreProcessor
	{
		internal get { } //Length: 12
		internal set { } //Length: 33
	}

	internal bool hasStateCallbacks
	{
		internal get { } //Length: 11
		internal set { } //Length: 31
	}

	public double lastUpdateTime
	{
		 get { } //Length: 70
	}

	public bool native
	{
		 get { } //Length: 12
	}

	public bool remote
	{
		 get { } //Length: 12
	}

	public bool updateBeforeRender
	{
		 get { } //Length: 10
	}

	public virtual int valueSizeInBytes
	{
		 get { } //Length: 74
	}

	public virtual Type valueType
	{
		 get { } //Length: 77
	}

	public bool wasUpdatedThisFrame
	{
		 get { } //Length: 68
	}

	public InputDevice() { }

	internal void AddDeviceUsage(InternedString usage) { }

	internal static TDevice Build(string layoutName = null, string layoutVariants = null, InputDeviceDescription deviceDescription = null, bool noPrecompiledLayouts = false) { }

	internal void ClearDeviceUsages() { }

	public virtual bool CompareValue(Void* firstStatePtr, Void* secondStatePtr) { }

	internal static void DecodeStateOffsetToControlMapEntry(uint entry, out uint controlIndex, out uint stateOffset, out uint stateSize) { }

	private void DumpControlBitRangeNode(int nodeIndex, ControlBitRangeNode node, uint startOffset, uint sizeInBits, List<String> output) { }

	private void DumpControlTree(ControlBitRangeNode parentNode, uint startOffset, List<String> output) { }

	internal string DumpControlTree() { }

	internal static uint EncodeStateOffsetToControlMapEntry(uint controlIndex, uint stateOffsetInBits, uint stateSizeInBits) { }

	protected override long ExecuteCommand(InputDeviceCommand* commandPtr) { }

	public long ExecuteCommand(ref TCommand command) { }

	internal bool ExecuteDisableCommand() { }

	internal bool ExecuteEnableCommand() { }

	public bool get_added() { }

	public static ReadOnlyArray<InputDevice> get_all() { }

	public ReadOnlyArray<InputControl> get_allControls() { }

	internal bool get_canDeviceRunInBackground() { }

	public bool get_canRunInBackground() { }

	public InputDeviceDescription get_description() { }

	public int get_deviceId() { }

	internal bool get_disabledInFrontend() { }

	internal bool get_disabledInRuntime() { }

	internal bool get_disabledWhileInBackground() { }

	public bool get_enabled() { }

	internal bool get_hasControlsWithDefaultState() { }

	internal bool get_hasDontResetControls() { }

	internal bool get_hasEventMerger() { }

	internal bool get_hasEventPreProcessor() { }

	internal bool get_hasStateCallbacks() { }

	public double get_lastUpdateTime() { }

	public bool get_native() { }

	public bool get_remote() { }

	public bool get_updateBeforeRender() { }

	public virtual int get_valueSizeInBytes() { }

	public virtual Type get_valueType() { }

	public bool get_wasUpdatedThisFrame() { }

	private static bool HasDataChangedInRange(Byte* deviceStatePtr, Void* statePtr, uint startOffset, uint sizeInBits) { }

	public override void MakeCurrent() { }

	internal void NotifyAdded() { }

	internal void NotifyConfigurationChanged() { }

	internal void NotifyRemoved() { }

	protected override void OnAdded() { }

	protected override void OnConfigurationChanged() { }

	protected override void OnRemoved() { }

	internal bool QueryEnabledStateFromRuntime() { }

	public virtual object ReadValueFromBufferAsObject(Void* buffer, int bufferSize) { }

	public virtual object ReadValueFromStateAsObject(Void* statePtr) { }

	public virtual void ReadValueFromStateIntoBuffer(Void* statePtr, Void* bufferPtr, int bufferSize) { }

	internal void RemoveDeviceUsage(InternedString usage) { }

	internal bool RequestReset() { }

	internal bool RequestSync() { }

	internal void set_disabledInFrontend(bool value) { }

	internal void set_disabledInRuntime(bool value) { }

	internal void set_disabledWhileInBackground(bool value) { }

	internal void set_hasControlsWithDefaultState(bool value) { }

	internal void set_hasDontResetControls(bool value) { }

	internal void set_hasEventMerger(bool value) { }

	internal void set_hasEventPreProcessor(bool value) { }

	internal void set_hasStateCallbacks(bool value) { }

	internal void WriteChangedControlStates(Byte* deviceStateBuffer, Void* statePtr, uint stateSizeInBytes, uint stateOffsetInDevice) { }

	private void WriteChangedControlStatesInternal(Void* statePtr, Byte* deviceStatePtr, ControlBitRangeNode parentNode, uint startOffset) { }

	private void WritePartialChangedControlStatesInternal(uint stateSizeInBits, uint stateOffsetInDeviceInBits, ControlBitRangeNode parentNode, uint startOffset) { }

}

