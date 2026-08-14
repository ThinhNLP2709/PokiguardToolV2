namespace UnityEngine.InputSystem;

internal class InputManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<InputDevice, String> <>9__192_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <MakeDeviceNameUnique>b__192_0(InputDevice x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__85
	{
		public static readonly <>c__85<TDevice> <>9; //Field offset: 0x0
		public static Func<InputDevice> <>9__85_0; //Field offset: 0x0

		private static <>c__85`1() { }

		public <>c__85`1() { }

		internal InputDevice <RegisterPrecompiledLayout>b__85_0() { }

	}

	[CompilerGenerated]
	private sealed class <ListControlLayouts>d__100 : IEnumerable<String>, IEnumerable, IEnumerator<String>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private string <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		private string basedOn; //Field offset: 0x28
		public string <>3__basedOn; //Field offset: 0x30
		public InputManager <>4__this; //Field offset: 0x38
		private InternedString <internedBasedOn>5__2; //Field offset: 0x40
		private Enumerator<InternedString, Type> <>7__wrap2; //Field offset: 0x50
		private Enumerator<InternedString, String> <>7__wrap3; //Field offset: 0x80
		private Enumerator<InternedString, Func<InputControlLayout>> <>7__wrap4; //Field offset: 0xB0

		private override string System.Collections.Generic.IEnumerator<System.String>.Current
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
		public <ListControlLayouts>d__100(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

		private void <>m__Finally3() { }

		private void <>m__Finally4() { }

		private void <>m__Finally5() { }

		private void <>m__Finally6() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<String> System.Collections.Generic.IEnumerable<System.String>.GetEnumerator() { }

		[DebuggerHidden]
		private override string System.Collections.Generic.IEnumerator<System.String>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public struct AvailableDevice
	{
		public InputDeviceDescription description; //Field offset: 0x0
		public int deviceId; //Field offset: 0x38
		public bool isNative; //Field offset: 0x3C
		public bool isRemoved; //Field offset: 0x3D

	}

	public enum DeviceDisableScope
	{
		Everywhere = 0,
		InFrontendOnly = 1,
		TemporaryWhilePlayerIsInBackground = 2,
	}

	public struct StateChangeMonitorListener
	{
		public InputControl control; //Field offset: 0x0
		public IInputStateChangeMonitor monitor; //Field offset: 0x8
		public long monitorIndex; //Field offset: 0x10
		public uint groupIndex; //Field offset: 0x18

	}

	public struct StateChangeMonitorsForDevice
	{
		public BitRegion[] memoryRegions; //Field offset: 0x0
		public StateChangeMonitorListener[] listeners; //Field offset: 0x8
		public DynamicBitfield signalled; //Field offset: 0x10
		public bool needToUpdateOrderingOfMonitors; //Field offset: 0x30
		public bool needToCompactArrays; //Field offset: 0x31

		public int count
		{
			 get { } //Length: 4
		}

		public void Add(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex, uint groupIndex) { }

		public void Clear() { }

		public void CompactArrays() { }

		public int get_count() { }

		public void Remove(IInputStateChangeMonitor monitor, long monitorIndex, bool deferRemoval) { }

		private void RemoveAt(int i) { }

		public void SortMonitorsByIndex() { }

	}

	private struct StateChangeMonitorTimeout
	{
		public InputControl control; //Field offset: 0x0
		public double time; //Field offset: 0x8
		public IInputStateChangeMonitor monitor; //Field offset: 0x10
		public long monitorIndex; //Field offset: 0x18
		public int timerIndex; //Field offset: 0x20

	}

	private static readonly ProfilerMarker k_InputUpdateProfilerMarker; //Field offset: 0x0
	private static readonly ProfilerMarker k_InputTryFindMatchingControllerMarker; //Field offset: 0x8
	private static readonly ProfilerMarker k_InputAddDeviceMarker; //Field offset: 0x10
	private static readonly ProfilerMarker k_InputRestoreDevicesAfterReloadMarker; //Field offset: 0x18
	private static readonly ProfilerMarker k_InputRegisterCustomTypesMarker; //Field offset: 0x20
	private static readonly ProfilerMarker k_InputOnBeforeUpdateMarker; //Field offset: 0x28
	private static readonly ProfilerMarker k_InputOnAfterUpdateMarker; //Field offset: 0x30
	private static readonly ProfilerMarker k_InputOnSettingsChangeMarker; //Field offset: 0x38
	private static readonly ProfilerMarker k_InputOnDeviceSettingsChangeMarker; //Field offset: 0x40
	private static readonly ProfilerMarker k_InputOnEventMarker; //Field offset: 0x48
	private static readonly ProfilerMarker k_InputOnLayoutChangeMarker; //Field offset: 0x50
	private static readonly ProfilerMarker k_InputOnDeviceChangeMarker; //Field offset: 0x58
	private static readonly ProfilerMarker k_InputOnActionsChangeMarker; //Field offset: 0x60
	private bool m_CustomTypesRegistered; //Field offset: 0x10
	internal int m_LayoutRegistrationVersion; //Field offset: 0x14
	private float m_PollingFrequency; //Field offset: 0x18
	private InputEventHandledPolicy m_InputEventHandledPolicy; //Field offset: 0x1C
	internal Collection m_Layouts; //Field offset: 0x20
	private TypeTable m_Processors; //Field offset: 0x60
	private TypeTable m_Interactions; //Field offset: 0x70
	private TypeTable m_Composites; //Field offset: 0x80
	private int m_DevicesCount; //Field offset: 0x90
	private InputDevice[] m_Devices; //Field offset: 0x98
	private Dictionary<Int32, InputDevice> m_DevicesById; //Field offset: 0xA0
	internal int m_AvailableDeviceCount; //Field offset: 0xA8
	internal AvailableDevice[] m_AvailableDevices; //Field offset: 0xB0
	internal int m_DisconnectedDevicesCount; //Field offset: 0xB8
	internal InputDevice[] m_DisconnectedDevices; //Field offset: 0xC0
	internal InputUpdateType m_UpdateMask; //Field offset: 0xC8
	private InputUpdateType m_CurrentUpdate; //Field offset: 0xCC
	internal InputStateBuffers m_StateBuffers; //Field offset: 0xD0
	private ScrollDeltaBehavior m_ScrollDeltaBehavior; //Field offset: 0x108
	private CallbackArray<Action`2<InputDevice, InputDeviceChange>> m_DeviceChangeListeners; //Field offset: 0x110
	private CallbackArray<Action`2<InputDevice, InputEventPtr>> m_DeviceStateChangeListeners; //Field offset: 0x160
	private CallbackArray<InputDeviceFindControlLayoutDelegate> m_DeviceFindLayoutCallbacks; //Field offset: 0x1B0
	internal CallbackArray<InputDeviceCommandDelegate> m_DeviceCommandCallbacks; //Field offset: 0x200
	private CallbackArray<Action`2<String, InputControlLayoutChange>> m_LayoutChangeListeners; //Field offset: 0x250
	private CallbackArray<Action`2<InputEventPtr, InputDevice>> m_EventListeners; //Field offset: 0x2A0
	private CallbackArray<Action> m_BeforeUpdateListeners; //Field offset: 0x2F0
	private CallbackArray<Action> m_AfterUpdateListeners; //Field offset: 0x340
	private CallbackArray<Action> m_SettingsChangedListeners; //Field offset: 0x390
	private CallbackArray<Action> m_ActionsChangedListeners; //Field offset: 0x3E0
	private bool m_NativeBeforeUpdateHooked; //Field offset: 0x430
	private bool m_HaveDevicesWithStateCallbackReceivers; //Field offset: 0x431
	private bool m_HasFocus; //Field offset: 0x432
	private bool m_DiscardOutOfFocusEvents; //Field offset: 0x433
	private double m_FocusRegainedTime; //Field offset: 0x438
	private InputEventStream m_InputEventStream; //Field offset: 0x440
	private InputDeviceExecuteCommandDelegate m_DeviceFindExecuteCommandDelegate; //Field offset: 0x4B8
	private int m_DeviceFindExecuteCommandDeviceId; //Field offset: 0x4C0
	internal IInputRuntime m_Runtime; //Field offset: 0x4C8
	internal InputMetrics m_Metrics; //Field offset: 0x4D0
	internal InputSettings m_Settings; //Field offset: 0x508
	private bool m_OptimizedControlsFeatureEnabled; //Field offset: 0x510
	private bool m_ReadValueCachingFeatureEnabled; //Field offset: 0x511
	private bool m_ParanoidReadValueCachingChecksEnabled; //Field offset: 0x512
	private InputActionAsset m_Actions; //Field offset: 0x518
	private bool m_ShouldMakeCurrentlyUpdatingDeviceCurrent; //Field offset: 0x520
	internal StateChangeMonitorsForDevice[] m_StateChangeMonitors; //Field offset: 0x528
	private InlinedArray<StateChangeMonitorTimeout> m_StateChangeMonitorTimeouts; //Field offset: 0x530

	public event Action onActionsChange
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event Action onAfterUpdate
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event Action onBeforeUpdate
	{
		 add { } //Length: 86
		 remove { } //Length: 76
	}

	public event Action<InputDevice, InputDeviceChange> onDeviceChange
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event InputDeviceCommandDelegate onDeviceCommand
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event Action<InputDevice, InputEventPtr> onDeviceStateChange
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event Action<InputEventPtr, InputDevice> onEvent
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event InputDeviceFindControlLayoutDelegate onFindControlLayoutForDevice
	{
		 add { } //Length: 86
		 remove { } //Length: 76
	}

	public event Action<String, InputControlLayoutChange> onLayoutChange
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public event Action onSettingsChange
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public InputActionAsset actions
	{
		 get { } //Length: 8
		 set { } //Length: 43
	}

	public TypeTable composites
	{
		 get { } //Length: 14
	}

	public InputUpdateType defaultUpdateType
	{
		 get { } //Length: 29
	}

	public ReadOnlyArray<InputDevice> devices
	{
		 get { } //Length: 101
	}

	private bool gameHasFocus
	{
		private get { } //Length: 49
	}

	private bool gameIsPlaying
	{
		private get { } //Length: 3
	}

	private bool gameShouldGetInputRegardlessOfFocus
	{
		private get { } //Length: 33
	}

	internal InputEventHandledPolicy inputEventHandledPolicy
	{
		internal get { } //Length: 4
		internal set { } //Length: 158
	}

	public TypeTable interactions
	{
		 get { } //Length: 11
	}

	public bool isProcessingEvents
	{
		 get { } //Length: 8
	}

	public InputMetrics metrics
	{
		 get { } //Length: 449
	}

	internal bool optimizedControlsFeatureEnabled
	{
		internal get { } //Length: 8
		internal set { } //Length: 7
	}

	internal bool paranoidReadValueCachingChecksEnabled
	{
		internal get { } //Length: 8
		internal set { } //Length: 7
	}

	public float pollingFrequency
	{
		 get { } //Length: 6
		 set { } //Length: 206
	}

	public TypeTable processors
	{
		 get { } //Length: 11
	}

	internal bool readValueCachingFeatureEnabled
	{
		internal get { } //Length: 8
		internal set { } //Length: 7
	}

	public ScrollDeltaBehavior scrollDeltaBehavior
	{
		 get { } //Length: 7
		 set { } //Length: 230
	}

	public InputSettings settings
	{
		 get { } //Length: 8
		 set { } //Length: 253
	}

	public InputUpdateType updateMask
	{
		 get { } //Length: 7
		 set { } //Length: 31
	}

	private static InputManager() { }

	public InputManager() { }

	[CompilerGenerated]
	private long <TryFindMatchingControlLayout>b__97_0(ref InputDeviceCommand commandRef) { }

	public void add_onActionsChange(Action value) { }

	public void add_onAfterUpdate(Action value) { }

	public void add_onBeforeUpdate(Action value) { }

	public void add_onDeviceChange(Action<InputDevice, InputDeviceChange> value) { }

	public void add_onDeviceCommand(InputDeviceCommandDelegate value) { }

	public void add_onDeviceStateChange(Action<InputDevice, InputEventPtr> value) { }

	public void add_onEvent(Action<InputEventPtr, InputDevice> value) { }

	public void add_onFindControlLayoutForDevice(InputDeviceFindControlLayoutDelegate value) { }

	public void add_onLayoutChange(Action<String, InputControlLayoutChange> value) { }

	public void add_onSettingsChange(Action value) { }

	private void AddAvailableDevicesMatchingDescription(InputDeviceMatcher matcher, InternedString layout) { }

	internal void AddAvailableDevicesThatAreNowRecognized() { }

	public InputDevice AddDevice(Type type, string name = null) { }

	public InputDevice AddDevice(string layout, string name = null, InternedString variants = null) { }

	private InputDevice AddDevice(InternedString layout, int deviceId, string deviceName = null, InputDeviceDescription deviceDescription = null, DeviceFlags deviceFlags = 0, InternedString variants = null) { }

	public void AddDevice(InputDevice device) { }

	public InputDevice AddDevice(InputDeviceDescription description) { }

	public InputDevice AddDevice(InputDeviceDescription description, bool throwIfNoLayoutFound, string deviceName = null, int deviceId = 0, DeviceFlags deviceFlags = 0) { }

	public InputDevice AddDevice(InputDeviceDescription description, InternedString layout, string deviceName = null, int deviceId = 0, DeviceFlags deviceFlags = 0) { }

	public void AddDeviceUsage(InputDevice device, InternedString usage) { }

	public void AddStateChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex, uint groupIndex) { }

	public void AddStateChangeMonitorTimeout(InputControl control, IInputStateChangeMonitor monitor, double time, long monitorIndex, int timerIndex) { }

	internal void ApplyActions() { }

	internal void ApplySettings() { }

	private bool AreMaximumEventBytesPerUpdateExceeded(uint totalEventBytesProcessed) { }

	private void AssignUniqueDeviceId(InputDevice device) { }

	[Conditional("UNITY_EDITOR")]
	private void CheckAllDevicesOptimizedControlsHaveValidState() { }

	internal void Destroy() { }

	internal void DontMakeCurrentlyUpdatingDeviceCurrent() { }

	public void EnableOrDisableDevice(InputDevice device, bool enable, DeviceDisableScope scope = 0) { }

	internal long ExecuteGlobalCommand(ref TCommand command) { }

	private InternedString FindOrRegisterDeviceLayoutForType(Type type) { }

	internal void FireStateChangeNotifications(int deviceIndex, double internalTime, InputEvent* eventPtr) { }

	public void FireStateChangeNotifications() { }

	private bool FlipBuffersForDeviceIfNecessary(InputDevice device, InputUpdateType updateType) { }

	public void FlushDisconnectedDevices() { }

	public InputActionAsset get_actions() { }

	public TypeTable get_composites() { }

	public InputUpdateType get_defaultUpdateType() { }

	public ReadOnlyArray<InputDevice> get_devices() { }

	private bool get_gameHasFocus() { }

	private bool get_gameIsPlaying() { }

	private bool get_gameShouldGetInputRegardlessOfFocus() { }

	internal InputEventHandledPolicy get_inputEventHandledPolicy() { }

	public TypeTable get_interactions() { }

	public bool get_isProcessingEvents() { }

	public InputMetrics get_metrics() { }

	internal bool get_optimizedControlsFeatureEnabled() { }

	internal bool get_paranoidReadValueCachingChecksEnabled() { }

	public float get_pollingFrequency() { }

	public TypeTable get_processors() { }

	internal bool get_readValueCachingFeatureEnabled() { }

	public ScrollDeltaBehavior get_scrollDeltaBehavior() { }

	public InputSettings get_settings() { }

	public InputUpdateType get_updateMask() { }

	public int GetControls(string path, ref InputControlList<TControl>& controls) { }

	public InputDevice GetDevice(string nameOrLayout) { }

	public int GetUnsupportedDevices(List<InputDeviceDescription> descriptions) { }

	internal bool HasDevice(InputDevice device) { }

	internal void Initialize(IInputRuntime runtime, InputSettings settings) { }

	private void InitializeActions() { }

	internal void InitializeData() { }

	private void InitializeDefaultState(InputDevice device) { }

	private void InitializeDeviceState(InputDevice device) { }

	private void InstallBeforeUpdateHookIfNecessary() { }

	internal void InstallGlobals() { }

	internal void InstallRuntime(IInputRuntime runtime) { }

	private void InvokeAfterUpdateCallback(InputUpdateType updateType) { }

	private bool IsControlOrChildUsingLayoutRecursive(InputControl control, InternedString layout) { }

	private bool IsControlUsingLayout(InputControl control, InternedString layout) { }

	private bool IsDeviceLayoutMarkedAsSupportedInSettings(InternedString layoutName) { }

	[IteratorStateMachine(typeof(<ListControlLayouts>d__100))]
	public IEnumerable<String> ListControlLayouts(string basedOn = null) { }

	private void MakeDeviceNameUnique(InputDevice device) { }

	private JsonString MakeEscapedJsonString(string theString) { }

	private string MakeStringWithEventsProcessedByDevice() { }

	private void NotifyUsageChanged(InputDevice device) { }

	private void OnBeforeUpdate(InputUpdateType updateType) { }

	internal void OnFocusChanged(bool focus) { }

	private void OnNativeDeviceDiscovered(int deviceId, string deviceDescriptor) { }

	private void OnUpdate(InputUpdateType updateType, ref InputEventBuffer eventBuffer) { }

	private void PerformLayoutPostRegistration(InternedString layoutName, InlinedArray<InternedString> baseLayouts, bool isReplacement, bool isKnownToBeDeviceLayout = false, bool isOverride = false) { }

	private bool ProcessStateChangeMonitors(int deviceIndex, Void* newStateFromEvent, Void* oldStateOfDevice, uint newStateSizeInBytes, uint newStateOffsetInBytes) { }

	private void ProcessStateChangeMonitorTimeouts() { }

	public void QueueEvent(InputEventPtr ptr) { }

	public void QueueEvent(ref TEvent inputEvent) { }

	private void QueueEvent(InputEvent* eventPtr) { }

	private void ReallocateStateBuffers() { }

	private void RecreateDevice(InputDevice oldDevice, InternedString newLayout) { }

	private void RecreateDevicesUsingLayout(InternedString layout, bool isKnownToBeDeviceLayout = false) { }

	private void RecreateDevicesUsingLayoutWithInferiorMatch(InputDeviceMatcher deviceMatcher) { }

	public void RegisterControlLayout(string name, Type type) { }

	public void RegisterControlLayout(string json, string name = null, bool isOverride = false) { }

	public void RegisterControlLayoutBuilder(Func<InputControlLayout> method, string name, string baseLayout = null) { }

	public void RegisterControlLayoutMatcher(string layoutName, InputDeviceMatcher matcher) { }

	public void RegisterControlLayoutMatcher(Type type, InputDeviceMatcher matcher) { }

	private static void RegisterCustomTypes(Type[] types) { }

	internal bool RegisterCustomTypes() { }

	public void RegisterPrecompiledLayout(string metadata) { }

	public void remove_onActionsChange(Action value) { }

	public void remove_onAfterUpdate(Action value) { }

	public void remove_onBeforeUpdate(Action value) { }

	public void remove_onDeviceChange(Action<InputDevice, InputDeviceChange> value) { }

	public void remove_onDeviceCommand(InputDeviceCommandDelegate value) { }

	public void remove_onDeviceStateChange(Action<InputDevice, InputEventPtr> value) { }

	public void remove_onEvent(Action<InputEventPtr, InputDevice> value) { }

	public void remove_onFindControlLayoutForDevice(InputDeviceFindControlLayoutDelegate value) { }

	public void remove_onLayoutChange(Action<String, InputControlLayoutChange> value) { }

	public void remove_onSettingsChange(Action value) { }

	public void RemoveControlLayout(string name) { }

	public void RemoveDevice(InputDevice device, bool keepOnListOfAvailableDevices = false) { }

	public void RemoveDeviceUsage(InputDevice device, InternedString usage) { }

	public void RemoveStateChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex) { }

	private void RemoveStateChangeMonitors(InputDevice device) { }

	public void RemoveStateChangeMonitorTimeout(IInputStateChangeMonitor monitor, long monitorIndex, int timerIndex) { }

	private static void ResetControlPathsRecursive(InputControl control) { }

	private void ResetCurrentProcessedEventBytesForDevices() { }

	public void ResetDevice(InputDevice device, bool alsoResetDontResetControls = false, Nullable<Boolean> issueResetCommand = null) { }

	private void RestoreDevicesAfterDomainReloadIfNecessary() { }

	public void set_actions(InputActionAsset value) { }

	internal void set_inputEventHandledPolicy(InputEventHandledPolicy value) { }

	internal void set_optimizedControlsFeatureEnabled(bool value) { }

	internal void set_paranoidReadValueCachingChecksEnabled(bool value) { }

	public void set_pollingFrequency(float value) { }

	internal void set_readValueCachingFeatureEnabled(bool value) { }

	public void set_scrollDeltaBehavior(ScrollDeltaBehavior value) { }

	public void set_settings(InputSettings value) { }

	public void set_updateMask(InputUpdateType value) { }

	public void SetDeviceUsage(InputDevice device, InternedString usage) { }

	private bool ShouldExitEarlyFromEventProcessing(InputUpdateType updateType) { }

	private bool ShouldFlushEventBuffer() { }

	private bool ShouldRunDeviceInBackground(InputDevice device) { }

	internal bool ShouldRunUpdate(InputUpdateType updateType) { }

	public void SignalStateChangeMonitor(InputControl control, IInputStateChangeMonitor monitor) { }

	private void SortStateChangeMonitorsIfNecessary(int deviceIndex) { }

	public InternedString TryFindMatchingControlLayout(ref InputDeviceDescription deviceDescription, int deviceId = 0) { }

	public InputDevice TryGetDevice(Type layoutType) { }

	public InputDevice TryGetDevice(string nameOrLayout) { }

	public InputDevice TryGetDeviceById(int id) { }

	public InputControlLayout TryLoadControlLayout(InternedString name) { }

	public InputControlLayout TryLoadControlLayout(Type type) { }

	private InputDevice TryMatchDisconnectedDevice(string deviceDescriptor) { }

	internal void UninstallGlobals() { }

	public void Update() { }

	public void Update(InputUpdateType updateType) { }

	internal bool UpdateState(InputDevice device, InputUpdateType updateType, Void* statePtr, uint stateOffsetInDevice, uint stateSize, double internalTime, InputEventPtr eventPtr = null) { }

	internal bool UpdateState(InputDevice device, InputEvent* eventPtr, InputUpdateType updateType) { }

	private void WarnAboutDevicesFailingToRecreateAfterDomainReload() { }

	private void WriteStateChange(DoubleBuffers buffers, int deviceIndex, ref InputStateBlock deviceStateBlock, uint stateOffsetInDevice, Void* statePtr, uint stateSizeInBytes, bool flippedBuffers) { }

}

