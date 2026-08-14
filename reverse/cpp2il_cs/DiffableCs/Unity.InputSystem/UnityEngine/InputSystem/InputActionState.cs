namespace UnityEngine.InputSystem;

internal class InputActionState : IInputStateChangeMonitor, ICloneable, IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static TypedRestore<GlobalState> <>9__143_0; //Field offset: 0x8
		public static Action <>9__143_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <SaveAndResetState>b__143_0(ref GlobalState state) { }

		internal void <SaveAndResetState>b__143_1() { }

	}

	internal struct ActionMapIndices
	{
		public int actionStartIndex; //Field offset: 0x0
		public int actionCount; //Field offset: 0x4
		public int controlStartIndex; //Field offset: 0x8
		public int controlCount; //Field offset: 0xC
		public int bindingStartIndex; //Field offset: 0x10
		public int bindingCount; //Field offset: 0x14
		public int interactionStartIndex; //Field offset: 0x18
		public int interactionCount; //Field offset: 0x1C
		public int processorStartIndex; //Field offset: 0x20
		public int processorCount; //Field offset: 0x24
		public int compositeStartIndex; //Field offset: 0x28
		public int compositeCount; //Field offset: 0x2C

	}

	public struct BindingState
	{
		[Flags]
		internal enum Flags
		{
			ChainsWithNext = 1,
			EndOfChain = 2,
			Composite = 4,
			PartOfComposite = 8,
			InitialStateCheckPending = 16,
			WantsInitialStateCheck = 32,
		}

		private byte m_ControlCount; //Field offset: 0x0
		private byte m_InteractionCount; //Field offset: 0x1
		private byte m_ProcessorCount; //Field offset: 0x2
		private byte m_MapIndex; //Field offset: 0x3
		private byte m_Flags; //Field offset: 0x4
		private byte m_PartIndex; //Field offset: 0x5
		private ushort m_ActionIndex; //Field offset: 0x6
		private ushort m_CompositeOrCompositeBindingIndex; //Field offset: 0x8
		private ushort m_ProcessorStartIndex; //Field offset: 0xA
		private ushort m_InteractionStartIndex; //Field offset: 0xC
		private ushort m_ControlStartIndex; //Field offset: 0xE
		private double m_PressTime; //Field offset: 0x10
		private int m_TriggerEventIdForComposite; //Field offset: 0x18
		private int __padding; //Field offset: 0x1C

		public int actionIndex
		{
			 get { } //Length: 22
			 set { } //Length: 167
		}

		public bool chainsWithNext
		{
			 get { } //Length: 7
			 set { } //Length: 33
		}

		public int compositeOrCompositeBindingIndex
		{
			 get { } //Length: 22
			 set { } //Length: 167
		}

		public int controlCount
		{
			 get { } //Length: 4
			 set { } //Length: 148
		}

		public int controlStartIndex
		{
			 get { } //Length: 5
			 set { } //Length: 151
		}

		public Flags flags
		{
			 get { } //Length: 5
			 set { } //Length: 4
		}

		public bool initialStateCheckPending
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public int interactionCount
		{
			 get { } //Length: 5
			 set { } //Length: 149
		}

		public int interactionStartIndex
		{
			 get { } //Length: 22
			 set { } //Length: 167
		}

		public bool isComposite
		{
			 get { } //Length: 10
			 set { } //Length: 33
		}

		public bool isEndOfChain
		{
			 get { } //Length: 9
			 set { } //Length: 33
		}

		public bool isPartOfChain
		{
			 get { } //Length: 18
		}

		public bool isPartOfComposite
		{
			 get { } //Length: 10
			 set { } //Length: 33
		}

		public int mapIndex
		{
			 get { } //Length: 5
			 set { } //Length: 149
		}

		public int partIndex
		{
			 get { } //Length: 5
			 set { } //Length: 6
		}

		public double pressTime
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public int processorCount
		{
			 get { } //Length: 5
			 set { } //Length: 149
		}

		public int processorStartIndex
		{
			 get { } //Length: 22
			 set { } //Length: 167
		}

		public int triggerEventIdForComposite
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public bool wantsInitialStateCheck
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public int get_actionIndex() { }

		public bool get_chainsWithNext() { }

		public int get_compositeOrCompositeBindingIndex() { }

		public int get_controlCount() { }

		public int get_controlStartIndex() { }

		public Flags get_flags() { }

		public bool get_initialStateCheckPending() { }

		public int get_interactionCount() { }

		public int get_interactionStartIndex() { }

		public bool get_isComposite() { }

		public bool get_isEndOfChain() { }

		public bool get_isPartOfChain() { }

		public bool get_isPartOfComposite() { }

		public int get_mapIndex() { }

		public int get_partIndex() { }

		public double get_pressTime() { }

		public int get_processorCount() { }

		public int get_processorStartIndex() { }

		public int get_triggerEventIdForComposite() { }

		public bool get_wantsInitialStateCheck() { }

		public void set_actionIndex(int value) { }

		public void set_chainsWithNext(bool value) { }

		public void set_compositeOrCompositeBindingIndex(int value) { }

		public void set_controlCount(int value) { }

		public void set_controlStartIndex(int value) { }

		public void set_flags(Flags value) { }

		public void set_initialStateCheckPending(bool value) { }

		public void set_interactionCount(int value) { }

		public void set_interactionStartIndex(int value) { }

		public void set_isComposite(bool value) { }

		public void set_isEndOfChain(bool value) { }

		public void set_isPartOfComposite(bool value) { }

		public void set_mapIndex(int value) { }

		public void set_partIndex(int value) { }

		public void set_pressTime(double value) { }

		public void set_processorCount(int value) { }

		public void set_processorStartIndex(int value) { }

		public void set_triggerEventIdForComposite(int value) { }

		public void set_wantsInitialStateCheck(bool value) { }

	}

	public struct GlobalState
	{
		internal InlinedArray<GCHandle> globalList; //Field offset: 0x0
		internal CallbackArray<Action`2<Object, InputActionChange>> onActionChange; //Field offset: 0x18
		internal CallbackArray<Action`1<Object>> onActionControlsChanged; //Field offset: 0x68

	}

	public struct InteractionState
	{
		[Flags]
		private enum Flags
		{
			TimerRunning = 1,
		}

		private ushort m_TriggerControlIndex; //Field offset: 0x0
		private byte m_Phase; //Field offset: 0x2
		private byte m_Flags; //Field offset: 0x3
		private float m_TimerDuration; //Field offset: 0x4
		private double m_StartTime; //Field offset: 0x8
		private double m_TimerStartTime; //Field offset: 0x10
		private double m_PerformedTime; //Field offset: 0x18
		private float m_TotalTimeoutCompletionTimeDone; //Field offset: 0x20
		private float m_TotalTimeoutCompletionTimeRemaining; //Field offset: 0x24
		private long m_TimerMonitorIndex; //Field offset: 0x28

		public bool isTimerRunning
		{
			 get { } //Length: 7
			 set { } //Length: 33
		}

		public double performedTime
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public InputActionPhase phase
		{
			 get { } //Length: 5
			 set { } //Length: 4
		}

		public double startTime
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public float timerDuration
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public long timerMonitorIndex
		{
			 get { } //Length: 5
			 set { } //Length: 5
		}

		public double timerStartTime
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public float totalTimeoutCompletionDone
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public float totalTimeoutCompletionTimeRemaining
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public int triggerControlIndex
		{
			 get { } //Length: 20
			 set { } //Length: 117
		}

		public bool get_isTimerRunning() { }

		public double get_performedTime() { }

		public InputActionPhase get_phase() { }

		public double get_startTime() { }

		public float get_timerDuration() { }

		public long get_timerMonitorIndex() { }

		public double get_timerStartTime() { }

		public float get_totalTimeoutCompletionDone() { }

		public float get_totalTimeoutCompletionTimeRemaining() { }

		public int get_triggerControlIndex() { }

		public void set_isTimerRunning(bool value) { }

		public void set_performedTime(double value) { }

		public void set_phase(InputActionPhase value) { }

		public void set_startTime(double value) { }

		public void set_timerDuration(float value) { }

		public void set_timerMonitorIndex(long value) { }

		public void set_timerStartTime(double value) { }

		public void set_totalTimeoutCompletionDone(float value) { }

		public void set_totalTimeoutCompletionTimeRemaining(float value) { }

		public void set_triggerControlIndex(int value) { }

	}

	internal struct TriggerState
	{
		[Flags]
		internal enum Flags
		{
			HaveMagnitude = 1,
			PassThrough = 2,
			MayNeedConflictResolution = 4,
			HasMultipleConcurrentActuations = 8,
			InProcessing = 16,
			Button = 32,
			Pressed = 64,
		}

		public const int kMaxNumMaps = 255; //Field offset: 0x0
		public const int kMaxNumControls = 65535; //Field offset: 0x0
		public const int kMaxNumBindings = 65535; //Field offset: 0x0
		private byte m_Phase; //Field offset: 0x0
		private byte m_Flags; //Field offset: 0x1
		private byte m_MapIndex; //Field offset: 0x2
		private ushort m_ControlIndex; //Field offset: 0x4
		private double m_Time; //Field offset: 0x8
		private double m_StartTime; //Field offset: 0x10
		private ushort m_BindingIndex; //Field offset: 0x18
		private ushort m_InteractionIndex; //Field offset: 0x1A
		private float m_Magnitude; //Field offset: 0x1C
		private uint m_LastPerformedInUpdate; //Field offset: 0x20
		private uint m_LastCanceledInUpdate; //Field offset: 0x24
		private uint m_PressedInUpdate; //Field offset: 0x28
		private uint m_ReleasedInUpdate; //Field offset: 0x2C
		private uint m_LastCompletedInUpdate; //Field offset: 0x30
		internal int framePerformed; //Field offset: 0x34
		internal int framePressed; //Field offset: 0x38
		internal int frameReleased; //Field offset: 0x3C
		internal int frameCompleted; //Field offset: 0x40

		public int bindingIndex
		{
			 get { } //Length: 5
			 set { } //Length: 103
		}

		public int controlIndex
		{
			 get { } //Length: 22
			 set { } //Length: 119
		}

		public Flags flags
		{
			 get { } //Length: 5
			 set { } //Length: 4
		}

		public bool hasMultipleConcurrentActuations
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public bool haveMagnitude
		{
			 get { } //Length: 7
		}

		public bool inProcessing
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public int interactionIndex
		{
			 get { } //Length: 22
			 set { } //Length: 119
		}

		public bool isButton
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public bool isCanceled
		{
			 get { } //Length: 7
		}

		public bool isDisabled
		{
			 get { } //Length: 7
		}

		public bool isPassThrough
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public bool isPerformed
		{
			 get { } //Length: 7
		}

		public bool isPressed
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public bool isStarted
		{
			 get { } //Length: 7
		}

		public bool isWaiting
		{
			 get { } //Length: 7
		}

		public uint lastCanceledInUpdate
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public uint lastCompletedInUpdate
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public uint lastPerformedInUpdate
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public float magnitude
		{
			 get { } //Length: 6
			 set { } //Length: 10
		}

		public int mapIndex
		{
			 get { } //Length: 5
			 set { } //Length: 102
		}

		public bool mayNeedConflictResolution
		{
			 get { } //Length: 8
			 set { } //Length: 33
		}

		public InputActionPhase phase
		{
			 get { } //Length: 4
			 set { } //Length: 3
		}

		public uint pressedInUpdate
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public uint releasedInUpdate
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public double startTime
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public double time
		{
			 get { } //Length: 6
			 set { } //Length: 6
		}

		public int get_bindingIndex() { }

		public int get_controlIndex() { }

		public Flags get_flags() { }

		public bool get_hasMultipleConcurrentActuations() { }

		public bool get_haveMagnitude() { }

		public bool get_inProcessing() { }

		public int get_interactionIndex() { }

		public bool get_isButton() { }

		public bool get_isCanceled() { }

		public bool get_isDisabled() { }

		public bool get_isPassThrough() { }

		public bool get_isPerformed() { }

		public bool get_isPressed() { }

		public bool get_isStarted() { }

		public bool get_isWaiting() { }

		public uint get_lastCanceledInUpdate() { }

		public uint get_lastCompletedInUpdate() { }

		public uint get_lastPerformedInUpdate() { }

		public float get_magnitude() { }

		public int get_mapIndex() { }

		public bool get_mayNeedConflictResolution() { }

		public InputActionPhase get_phase() { }

		public uint get_pressedInUpdate() { }

		public uint get_releasedInUpdate() { }

		public double get_startTime() { }

		public double get_time() { }

		public void set_bindingIndex(int value) { }

		public void set_controlIndex(int value) { }

		public void set_flags(Flags value) { }

		public void set_hasMultipleConcurrentActuations(bool value) { }

		public void set_inProcessing(bool value) { }

		public void set_interactionIndex(int value) { }

		public void set_isButton(bool value) { }

		public void set_isPassThrough(bool value) { }

		public void set_isPressed(bool value) { }

		public void set_lastCanceledInUpdate(uint value) { }

		public void set_lastCompletedInUpdate(uint value) { }

		public void set_lastPerformedInUpdate(uint value) { }

		public void set_magnitude(float value) { }

		public void set_mapIndex(int value) { }

		public void set_mayNeedConflictResolution(bool value) { }

		public void set_phase(InputActionPhase value) { }

		public void set_pressedInUpdate(uint value) { }

		public void set_releasedInUpdate(uint value) { }

		public void set_startTime(double value) { }

		public void set_time(double value) { }

	}

	internal struct UnmanagedMemory : IDisposable
	{
		public Void* basePtr; //Field offset: 0x0
		public int mapCount; //Field offset: 0x8
		public int actionCount; //Field offset: 0xC
		public int interactionCount; //Field offset: 0x10
		public int bindingCount; //Field offset: 0x14
		public int controlCount; //Field offset: 0x18
		public int compositeCount; //Field offset: 0x1C
		public TriggerState* actionStates; //Field offset: 0x20
		public BindingState* bindingStates; //Field offset: 0x28
		public InteractionState* interactionStates; //Field offset: 0x30
		public Single* controlMagnitudes; //Field offset: 0x38
		public Single* compositeMagnitudes; //Field offset: 0x40
		public Int32* enabledControls; //Field offset: 0x48
		public UInt16* actionBindingIndicesAndCounts; //Field offset: 0x50
		public UInt16* actionBindingIndices; //Field offset: 0x58
		public Int32* controlIndexToBindingIndex; //Field offset: 0x60
		public UInt16* controlGroupingAndComplexity; //Field offset: 0x68
		public bool controlGroupingInitialized; //Field offset: 0x70
		public ActionMapIndices* mapIndices; //Field offset: 0x78

		public bool isAllocated
		{
			 get { } //Length: 8
		}

		public int sizeInBytes
		{
			 get { } //Length: 65
		}

		public void Allocate(int mapCount, int actionCount, int bindingCount, int controlCount, int interactionCount, int compositeCount) { }

		private static Byte* AllocFromBlob(ref Byte* top, int size) { }

		public UnmanagedMemory Clone() { }

		public void CopyDataFrom(UnmanagedMemory memory) { }

		public override void Dispose() { }

		public bool get_isAllocated() { }

		public int get_sizeInBytes() { }

	}

	public const int kInvalidIndex = -1; //Field offset: 0x0
	private static readonly ProfilerMarker k_InputInitialActionStateCheckMarker; //Field offset: 0x0
	private static readonly ProfilerMarker k_InputActionResolveConflictMarker; //Field offset: 0x8
	private static readonly ProfilerMarker k_InputActionCallbackMarker; //Field offset: 0x10
	private static readonly ProfilerMarker k_InputOnActionChangeMarker; //Field offset: 0x18
	private static readonly ProfilerMarker k_InputOnDeviceChangeMarker; //Field offset: 0x20
	internal static GlobalState s_GlobalState; //Field offset: 0x28
	public InputActionMap[] maps; //Field offset: 0x10
	public InputControl[] controls; //Field offset: 0x18
	public IInputInteraction[] interactions; //Field offset: 0x20
	public InputProcessor[] processors; //Field offset: 0x28
	public InputBindingComposite[] composites; //Field offset: 0x30
	public int totalProcessorCount; //Field offset: 0x38
	public UnmanagedMemory memory; //Field offset: 0x40
	private bool m_OnBeforeUpdateHooked; //Field offset: 0xC0
	private bool m_OnAfterUpdateHooked; //Field offset: 0xC1
	private bool m_InProcessControlStateChange; //Field offset: 0xC2
	private bool m_Suppressed; //Field offset: 0xC3
	private InputEventPtr m_CurrentlyProcessingThisEvent; //Field offset: 0xC8
	private Action m_OnBeforeUpdateDelegate; //Field offset: 0xD0
	private Action m_OnAfterUpdateDelegate; //Field offset: 0xD8

	public TriggerState* actionStates
	{
		 get { } //Length: 694
	}

	public BindingState* bindingStates
	{
		 get { } //Length: 5
	}

	public UInt16* controlGroupingAndComplexity
	{
		 get { } //Length: 8
	}

	public Int32* controlIndexToBindingIndex
	{
		 get { } //Length: 8
	}

	public Single* controlMagnitudes
	{
		 get { } //Length: 5
	}

	public UInt32* enabledControls
	{
		 get { } //Length: 8
	}

	public InteractionState* interactionStates
	{
		 get { } //Length: 5
	}

	public bool isProcessingControlStateChange
	{
		 get { } //Length: 8
	}

	public bool IsSuppressed
	{
		 get { } //Length: 8
	}

	public ActionMapIndices* mapIndices
	{
		 get { } //Length: 8
	}

	public int totalActionCount
	{
		 get { } //Length: 4
	}

	public int totalBindingCount
	{
		 get { } //Length: 4
	}

	public int totalCompositeCount
	{
		 get { } //Length: 4
	}

	public int totalControlCount
	{
		 get { } //Length: 4
	}

	public int totalInteractionCount
	{
		 get { } //Length: 4
	}

	public int totalMapCount
	{
		 get { } //Length: 4
	}

	private static InputActionState() { }

	public InputActionState() { }

	private void AddToGlobalList() { }

	internal TValue ApplyProcessors(int bindingIndex, TValue value, InputControl<TValue> controlOfType = null) { }

	private void CallActionListeners(int actionIndex, InputActionMap actionMap, InputActionPhase phase, ref CallbackArray<Action`1<CallbackContext>>& listeners, string callbackName) { }

	private bool CanUseDevice(InputDevice device) { }

	private bool ChangePhaseOfAction(InputActionPhase newPhase, ref TriggerState trigger, InputActionPhase phaseAfterPerformedOrCanceled = 1) { }

	private void ChangePhaseOfActionInternal(int actionIndex, TriggerState* actionState, InputActionPhase newPhase, ref TriggerState trigger, bool isDisablingAction = false) { }

	internal void ChangePhaseOfInteraction(InputActionPhase newPhase, ref TriggerState trigger, InputActionPhase phaseAfterPerformed = 1, InputActionPhase phaseAfterCanceled = 1, bool processNextInteractionOnCancel = true) { }

	public void ClaimDataFrom(InputBindingResolver resolver) { }

	public InputActionState Clone() { }

	private static void CompactGlobalList() { }

	private void ComputeControlGroupingIfNecessary() { }

	internal static void DeferredResolutionOfBindings() { }

	private void Destroy(bool isFinalizing = false) { }

	internal static void DestroyAllActionMapStates() { }

	internal static void DisableAllActions() { }

	public void DisableAllActions(InputActionMap map) { }

	private void DisableControls(int mapIndex, int controlStartIndex, int numControls) { }

	public void DisableControls(InputActionMap map) { }

	private void DisableControls(InputAction action) { }

	public void DisableSingleAction(InputAction action) { }

	public override void Dispose() { }

	public void EnableAllActions(InputActionMap map) { }

	private void EnableControls(int mapIndex, int controlStartIndex, int numControls) { }

	private void EnableControls(InputAction action) { }

	private void EnableControls(InputActionMap map) { }

	public void EnableSingleAction(InputAction action) { }

	public float EvaluateCompositePartMagnitude(int bindingIndex, int partNumber) { }

	public TriggerState FetchActionState(InputAction action) { }

	public ActionMapIndices FetchMapIndices(InputActionMap map) { }

	protected virtual void Finalize() { }

	internal static int FindAllEnabledActions(List<InputAction> result) { }

	private int FindControlIndexOnBinding(int bindingIndex, InputControl control) { }

	private void FinishBindingCompositeSetups() { }

	public void FinishBindingResolution(bool hasEnabledActions, UnmanagedMemory oldMemory, InputControlList<InputControl> activeControls, bool isFullResolve) { }

	public TriggerState* get_actionStates() { }

	public BindingState* get_bindingStates() { }

	public UInt16* get_controlGroupingAndComplexity() { }

	public Int32* get_controlIndexToBindingIndex() { }

	public Single* get_controlMagnitudes() { }

	public UInt32* get_enabledControls() { }

	public InteractionState* get_interactionStates() { }

	public bool get_isProcessingControlStateChange() { }

	public bool get_IsSuppressed() { }

	public ActionMapIndices* get_mapIndices() { }

	public int get_totalActionCount() { }

	public int get_totalBindingCount() { }

	public int get_totalCompositeCount() { }

	public int get_totalControlCount() { }

	public int get_totalInteractionCount() { }

	public int get_totalMapCount() { }

	private ushort GetActionBindingStartIndexAndCount(int actionIndex, out ushort bindingCount) { }

	internal InputActionMap GetActionMap(int bindingIndex) { }

	private object GetActionOrNoneString(ref TriggerState trigger) { }

	internal InputAction GetActionOrNull(ref TriggerState trigger) { }

	internal InputAction GetActionOrNull(int bindingIndex) { }

	internal InputBinding GetBinding(int bindingIndex) { }

	internal int GetBindingIndexInMap(int bindingIndex) { }

	internal int GetBindingIndexInState(int mapIndex, int bindingIndexInMap) { }

	internal BindingState GetBindingState(int bindingIndex) { }

	internal static int GetComplexityFromMonitorIndex(long mapControlAndBindingIndex) { }

	internal double GetCompositePartPressTime(int bindingIndex, int partNumber) { }

	internal InputControl GetControl(ref TriggerState trigger) { }

	private IInputInteraction GetInteractionOrNull(ref TriggerState trigger) { }

	internal int GetValueSizeInBytes(int bindingIndex, int controlIndex) { }

	internal Type GetValueType(int bindingIndex, int controlIndex) { }

	public bool HasEnabledActions() { }

	private void HookOnBeforeUpdate() { }

	public void Initialize(InputBindingResolver resolver) { }

	private bool IsActionBoundToControlFromDevice(InputDevice device, int actionIndex) { }

	private bool IsActiveControl(int bindingIndex, int controlIndex) { }

	internal static bool IsActuated(ref TriggerState trigger, float threshold = 0) { }

	private bool IsConflictingInput(ref TriggerState trigger, int actionIndex) { }

	private bool IsControlEnabled(int controlIndex) { }

	private bool IsUsingDevice(InputDevice device) { }

	internal void NotifyListenersOfActionChange(InputActionChange change) { }

	internal static void NotifyListenersOfActionChange(InputActionChange change, object actionOrMapOrAsset) { }

	private void OnBeforeInitialUpdate() { }

	internal static void OnDeviceChange(InputDevice device, InputDeviceChange change) { }

	internal void PrepareForBindingReResolution(bool needFullResolve, ref InputControlList<InputControl>& activeControls, ref bool hasEnabledActions) { }

	private void ProcessButtonState(ref TriggerState trigger, int actionIndex, BindingState* bindingStatePtr) { }

	private void ProcessControlStateChange(int mapIndex, int controlIndex, int bindingIndex, double time, InputEventPtr eventPtr) { }

	private void ProcessDefaultInteraction(ref TriggerState trigger, int actionIndex) { }

	private void ProcessInteractions(ref TriggerState trigger, int interactionStartIndex, int interactionCount) { }

	private void ProcessTimeout(double time, int mapIndex, int controlIndex, int bindingIndex, int interactionIndex) { }

	internal bool ReadCompositePartValue(int bindingIndex, int partNumber, Void* buffer, int bufferSize) { }

	internal TValue ReadCompositePartValue(int bindingIndex, int partNumber, Boolean* buttonValuePtr, out int controlIndex, TComparer comparer = null) { }

	internal object ReadCompositePartValueAsObject(int bindingIndex, int partNumber) { }

	internal void ReadValue(int bindingIndex, int controlIndex, Void* buffer, int bufferSize, bool ignoreComposites = false) { }

	internal TValue ReadValue(int bindingIndex, int controlIndex, bool ignoreComposites = false) { }

	internal bool ReadValueAsButton(int bindingIndex, int controlIndex) { }

	internal object ReadValueAsObject(int bindingIndex, int controlIndex, bool ignoreComposites = false) { }

	private void RemoveMapFromGlobalList() { }

	public void ResetActionState(int actionIndex, InputActionPhase toPhase = 1, bool hardReset = false) { }

	private void ResetActionStatesDrivenBy(InputDevice device) { }

	private static void ResetGlobals() { }

	private void ResetInteractionState(int interactionIndex) { }

	private void ResetInteractionStateAndCancelIfNecessary(int mapIndex, int bindingIndex, int interactionIndex, InputActionPhase phaseAfterCanceled) { }

	private void RestoreActionStatesAfterReResolvingBindings(UnmanagedMemory oldState, InputControlList<InputControl> activeControls, bool isFullResolve) { }

	internal static ISavedState SaveAndResetState() { }

	private void SetControlEnabled(int controlIndex, bool state) { }

	private void SetInitialStateCheckPending(BindingState* bindingStatePtr, bool value) { }

	public void SetInitialStateCheckPending(int actionIndex, bool value = true) { }

	internal void SetTotalTimeoutCompletionTime(float seconds, ref TriggerState trigger) { }

	private static bool ShouldIgnoreInputOnCompositeBinding(BindingState* binding, InputEvent* eventPtr) { }

	private void SplitUpMapAndControlAndBindingIndex(long mapControlAndBindingIndex, out int mapIndex, out int controlIndex, out int bindingIndex) { }

	internal void StartTimeout(float seconds, ref TriggerState trigger) { }

	private void StopTimeout(int interactionIndex) { }

	private override object System.ICloneable.Clone() { }

	private long ToCombinedMapAndControlAndBindingIndex(int mapIndex, int controlIndex, int bindingIndex) { }

	private void UnhookOnBeforeUpdate() { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateChangeMonitor.NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long mapControlAndBindingIndex) { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateChangeMonitor.NotifyTimerExpired(InputControl control, double time, long mapControlAndBindingIndex, int interactionIndex) { }

}

