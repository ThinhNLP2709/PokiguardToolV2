/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	internal class InputActionState : IInputStateChangeMonitor, ICloneable, IDisposable // TypeDefIndex: 6089
	{
		// Fields
		public const int kInvalidIndex = -1; // Metadata: 0x00698946
		public InputActionMap[] maps; // 0x10
		public InputControl[] controls; // 0x18
		public IInputInteraction[] interactions; // 0x20
		public InputProcessor[] processors; // 0x28
		public InputBindingComposite[] composites; // 0x30
		public int totalProcessorCount; // 0x38
		public UnmanagedMemory memory; // 0x40
		private bool m_OnBeforeUpdateHooked; // 0xC0
		private bool m_OnAfterUpdateHooked; // 0xC1
		private bool m_InProcessControlStateChange; // 0xC2
		private bool m_Suppressed; // 0xC3
		private InputEventPtr m_CurrentlyProcessingThisEvent; // 0xC8
		private Action m_OnBeforeUpdateDelegate; // 0xD0
		private Action m_OnAfterUpdateDelegate; // 0xD8
		private static readonly ProfilerMarker k_InputInitialActionStateCheckMarker; // 0x00
		private static readonly ProfilerMarker k_InputActionResolveConflictMarker; // 0x08
		private static readonly ProfilerMarker k_InputActionCallbackMarker; // 0x10
		private static readonly ProfilerMarker k_InputOnActionChangeMarker; // 0x18
		private static readonly ProfilerMarker k_InputOnDeviceChangeMarker; // 0x20
		internal static GlobalState s_GlobalState; // 0x28
	
		// Properties
		public int totalCompositeCount { get; } // 0x000000018033D270-0x000000018033D280 
		public int totalMapCount { get; } // 0x000000018033D1C0-0x000000018033D1D0 
		public int totalActionCount { get; } // 0x000000018033D1B0-0x000000018033D1C0 
		public int totalBindingCount { get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
		public int totalInteractionCount { get; } // 0x000000018033D660-0x000000018033D670 
		public int totalControlCount { get; } // 0x000000018033D260-0x000000018033D270 
		public unsafe ActionMapIndices* mapIndices { get; } // 0x00000001806CCB90-0x00000001806CCBA0 
		public unsafe TriggerState* actionStates { get; } // 0x0000000180333260-0x0000000180333490 
		public unsafe BindingState* bindingStates { get; } // 0x0000000180316960-0x0000000180316970 
		public unsafe InteractionState* interactionStates { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		public unsafe int* controlIndexToBindingIndex { get; } // 0x00000001805B5990-0x00000001805B59A0 
		public unsafe ushort* controlGroupingAndComplexity { get; } // 0x000000018033D510-0x000000018033D520 
		public unsafe float* controlMagnitudes { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		public unsafe uint* enabledControls { get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public bool isProcessingControlStateChange { get; } // 0x00000001816A5690-0x00000001816A56A0 
		public bool IsSuppressed { get; } // 0x0000000181CE1700-0x0000000181CE1710 
	
		// Nested types
		internal struct InteractionState // TypeDefIndex: 6090
		{
			// Fields
			private ushort m_TriggerControlIndex; // 0x00
			private byte m_Phase; // 0x02
			private byte m_Flags; // 0x03
			private float m_TimerDuration; // 0x04
			private double m_StartTime; // 0x08
			private double m_TimerStartTime; // 0x10
			private double m_PerformedTime; // 0x18
			private float m_TotalTimeoutCompletionTimeDone; // 0x20
			private float m_TotalTimeoutCompletionTimeRemaining; // 0x24
			private long m_TimerMonitorIndex; // 0x28
	
			// Properties
			public int triggerControlIndex { get; set; } // 0x0000000181CE2840-0x0000000181CE2860 0x0000000181CE28F0-0x0000000181CE2970
			public double startTime { get; set; } // 0x0000000180C5D1A0-0x0000000180C5D1B0 0x0000000181CE28B0-0x0000000181CE28C0
			public double performedTime { get; set; } // 0x0000000181CE2810-0x0000000181CE2820 0x0000000181CE2890-0x0000000181CE28A0
			public double timerStartTime { get; set; } // 0x0000000181107A70-0x0000000181107A80 0x0000000181CCFFC0-0x0000000181CCFFD0
			public float timerDuration { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
			public float totalTimeoutCompletionDone { get; set; } // 0x0000000181CE2820-0x0000000181CE2830 0x0000000181CE28D0-0x0000000181CE28E0
			public float totalTimeoutCompletionTimeRemaining { get; set; } // 0x0000000181CE2830-0x0000000181CE2840 0x0000000181CE28E0-0x0000000181CE28F0
			public long timerMonitorIndex { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181C854D0-0x0000000181C854E0
			public bool isTimerRunning { get; set; } // 0x0000000181CE2800-0x0000000181CE2810 0x0000000181CE2860-0x0000000181CE2890
			public InputActionPhase phase { get; set; } // 0x000000018166C8F0-0x000000018166C900 0x0000000181CE28A0-0x0000000181CE28B0
	
			// Nested types
			[Flags]
			private enum Flags // TypeDefIndex: 6091
			{
				TimerRunning = 1
			}
		}
	
		internal struct BindingState // TypeDefIndex: 6092
		{
			// Fields
			private byte m_ControlCount; // 0x00
			private byte m_InteractionCount; // 0x01
			private byte m_ProcessorCount; // 0x02
			private byte m_MapIndex; // 0x03
			private byte m_Flags; // 0x04
			private byte m_PartIndex; // 0x05
			private ushort m_ActionIndex; // 0x06
			private ushort m_CompositeOrCompositeBindingIndex; // 0x08
			private ushort m_ProcessorStartIndex; // 0x0A
			private ushort m_InteractionStartIndex; // 0x0C
			private ushort m_ControlStartIndex; // 0x0E
			private double m_PressTime; // 0x10
			private int m_TriggerEventIdForComposite; // 0x18
			private int __padding; // 0x1C
	
			// Properties
			public int controlStartIndex { get; set; } // 0x0000000181CCF940-0x0000000181CCF950 0x0000000181CCFC50-0x0000000181CCFCF0
			public int controlCount { get; set; } // 0x0000000180333490-0x00000001803334A0 0x0000000181CCFBB0-0x0000000181CCFC50
			public int interactionStartIndex { get; set; } // 0x0000000181CCF960-0x0000000181CCF980 0x0000000181CCFDD0-0x0000000181CCFE80
			public int interactionCount { get; set; } // 0x0000000180C572C0-0x0000000180C572D0 0x0000000181CCFD30-0x0000000181CCFDD0
			public int processorStartIndex { get; set; } // 0x0000000181CCF9F0-0x0000000181CCFA10 0x0000000181CD0070-0x0000000181CD0120
			public int processorCount { get; set; } // 0x000000018166C8F0-0x000000018166C900 0x0000000181CCFFD0-0x0000000181CD0070
			public int actionIndex { get; set; } // 0x0000000181CCF8F0-0x0000000181CCF910 0x0000000181CCFA20-0x0000000181CCFAD0
			public int mapIndex { get; set; } // 0x0000000181CCF9D0-0x0000000181CCF9E0 0x0000000181CCFF10-0x0000000181CCFFB0
			public int compositeOrCompositeBindingIndex { get; set; } // 0x0000000181CCF920-0x0000000181CCF940 0x0000000181CCFB00-0x0000000181CCFBB0
			public int triggerEventIdForComposite { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
			public double pressTime { get; set; } // 0x0000000181107A70-0x0000000181107A80 0x0000000181CCFFC0-0x0000000181CCFFD0
			public Flags flags { get; set; } // 0x00000001813282D0-0x00000001813282E0 0x0000000181CCFCF0-0x0000000181CCFD00
			public bool chainsWithNext { get; set; } // 0x0000000181CCF910-0x0000000181CCF920 0x0000000181CCFAD0-0x0000000181CCFB00
			public bool isEndOfChain { get; set; } // 0x0000000181CCF990-0x0000000181CCF9A0 0x0000000181CCFEB0-0x0000000181CCFEE0
			public bool isPartOfChain { get; } // 0x0000000181CCF9A0-0x0000000181CCF9C0 
			public bool isComposite { get; set; } // 0x0000000181CCF980-0x0000000181CCF990 0x0000000181CCFE80-0x0000000181CCFEB0
			public bool isPartOfComposite { get; set; } // 0x0000000181CCF9C0-0x0000000181CCF9D0 0x0000000181CCFEE0-0x0000000181CCFF10
			public bool initialStateCheckPending { get; set; } // 0x0000000181CCF950-0x0000000181CCF960 0x0000000181CCFD00-0x0000000181CCFD30
			public bool wantsInitialStateCheck { get; set; } // 0x0000000181CCFA10-0x0000000181CCFA20 0x0000000181CD0120-0x0000000181CD0150
			public int partIndex { get; set; } // 0x0000000181CCF9E0-0x0000000181CCF9F0 0x0000000181CCFFB0-0x0000000181CCFFC0
	
			// Nested types
			[Flags]
			public enum Flags // TypeDefIndex: 6093
			{
				ChainsWithNext = 1,
				EndOfChain = 2,
				Composite = 4,
				PartOfComposite = 8,
				InitialStateCheckPending = 16,
				WantsInitialStateCheck = 32
			}
		}
	
		public struct TriggerState // TypeDefIndex: 6094
		{
			// Fields
			public const int kMaxNumMaps = 255; // Metadata: 0x0069894E
			public const int kMaxNumControls = 65535; // Metadata: 0x00698950
			public const int kMaxNumBindings = 65535; // Metadata: 0x00698954
			private byte m_Phase; // 0x00
			private byte m_Flags; // 0x01
			private byte m_MapIndex; // 0x02
			private ushort m_ControlIndex; // 0x04
			private double m_Time; // 0x08
			private double m_StartTime; // 0x10
			private ushort m_BindingIndex; // 0x18
			private ushort m_InteractionIndex; // 0x1A
			private float m_Magnitude; // 0x1C
			private uint m_LastPerformedInUpdate; // 0x20
			private uint m_LastCanceledInUpdate; // 0x24
			private uint m_PressedInUpdate; // 0x28
			private uint m_ReleasedInUpdate; // 0x2C
			private uint m_LastCompletedInUpdate; // 0x30
			internal int framePerformed; // 0x34
			internal int framePressed; // 0x38
			internal int frameReleased; // 0x3C
			internal int frameCompleted; // 0x40
	
			// Properties
			public InputActionPhase phase { get; set; } // 0x0000000180333490-0x00000001803334A0 0x0000000180F21780-0x0000000180F21790
			public bool isDisabled { get; } // 0x00000001818C64D0-0x00000001818C64E0 
			public bool isWaiting { get; } // 0x00000001818C64C0-0x00000001818C64D0 
			public bool isStarted { get; } // 0x00000001818C64E0-0x00000001818C64F0 
			public bool isPerformed { get; } // 0x0000000181CE2A10-0x0000000181CE2A20 
			public bool isCanceled { get; } // 0x0000000181CE29F0-0x0000000181CE2A00 
			public double time { get; set; } // 0x0000000180C5D1A0-0x0000000180C5D1B0 0x0000000181CE28B0-0x0000000181CE28C0
			public double startTime { get; set; } // 0x0000000181107A70-0x0000000181107A80 0x0000000181CCFFC0-0x0000000181CCFFD0
			public float magnitude { get; set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181CE2CC0-0x0000000181CE2CD0
			public bool haveMagnitude { get; } // 0x0000000181CE29A0-0x0000000181CE29B0 
			public int mapIndex { get; set; } // 0x000000018166C8F0-0x000000018166C900 0x0000000181CE2CD0-0x0000000181CE2D40
			public int controlIndex { get; set; } // 0x0000000181CE2970-0x0000000181CE2990 0x0000000181CE2AC0-0x0000000181CE2B40
			public int bindingIndex { get; set; } // 0x0000000180E340D0-0x0000000180E340E0 0x0000000181CE2A50-0x0000000181CE2AC0
			public int interactionIndex { get; set; } // 0x0000000181CE29C0-0x0000000181CE29E0 0x0000000181CE2BB0-0x0000000181CE2C30
			public uint lastPerformedInUpdate { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
			public uint lastCompletedInUpdate { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
			public uint lastCanceledInUpdate { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
			public uint pressedInUpdate { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
			public uint releasedInUpdate { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
			public bool isPassThrough { get; set; } // 0x0000000181CE2A00-0x0000000181CE2A10 0x0000000181CE2C60-0x0000000181CE2C90
			public bool isButton { get; set; } // 0x0000000181CE29E0-0x0000000181CE29F0 0x0000000181CE2C30-0x0000000181CE2C60
			public bool isPressed { get; set; } // 0x0000000181CE2A20-0x0000000181CE2A30 0x0000000181CE2C90-0x0000000181CE2CC0
			public bool mayNeedConflictResolution { get; set; } // 0x0000000181CE2A40-0x0000000181CE2A50 0x0000000181CE2D40-0x0000000181CE2D70
			public bool hasMultipleConcurrentActuations { get; set; } // 0x0000000181CE2990-0x0000000181CE29A0 0x0000000181CE2B50-0x0000000181CE2B80
			public bool inProcessing { get; set; } // 0x0000000181CE29B0-0x0000000181CE29C0 0x0000000181CE2B80-0x0000000181CE2BB0
			public Flags flags { get; set; } // 0x0000000180C572C0-0x0000000180C572D0 0x0000000181CE2B40-0x0000000181CE2B50
	
			// Nested types
			[Flags]
			public enum Flags // TypeDefIndex: 6095
			{
				HaveMagnitude = 1,
				PassThrough = 2,
				MayNeedConflictResolution = 4,
				HasMultipleConcurrentActuations = 8,
				InProcessing = 16,
				Button = 32,
				Pressed = 64
			}
		}
	
		public struct ActionMapIndices // TypeDefIndex: 6096
		{
			// Fields
			public int actionStartIndex; // 0x00
			public int actionCount; // 0x04
			public int controlStartIndex; // 0x08
			public int controlCount; // 0x0C
			public int bindingStartIndex; // 0x10
			public int bindingCount; // 0x14
			public int interactionStartIndex; // 0x18
			public int interactionCount; // 0x1C
			public int processorStartIndex; // 0x20
			public int processorCount; // 0x24
			public int compositeStartIndex; // 0x28
			public int compositeCount; // 0x2C
		}
	
		public struct UnmanagedMemory : IDisposable // TypeDefIndex: 6097
		{
			// Fields
			public unsafe void* basePtr; // 0x00
			public int mapCount; // 0x08
			public int actionCount; // 0x0C
			public int interactionCount; // 0x10
			public int bindingCount; // 0x14
			public int controlCount; // 0x18
			public int compositeCount; // 0x1C
			public unsafe TriggerState* actionStates; // 0x20
			public unsafe BindingState* bindingStates; // 0x28
			public unsafe InteractionState* interactionStates; // 0x30
			public unsafe float* controlMagnitudes; // 0x38
			public unsafe float* compositeMagnitudes; // 0x40
			public unsafe int* enabledControls; // 0x48
			public unsafe ushort* actionBindingIndicesAndCounts; // 0x50
			public unsafe ushort* actionBindingIndices; // 0x58
			public unsafe int* controlIndexToBindingIndex; // 0x60
			public unsafe ushort* controlGroupingAndComplexity; // 0x68
			public bool controlGroupingInitialized; // 0x70
			public unsafe ActionMapIndices* mapIndices; // 0x78
	
			// Properties
			public bool isAllocated { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
			public int sizeInBytes { get; } // 0x0000000181CE37A0-0x0000000181CE37F0 
	
			// Methods
			private static unsafe byte* AllocFromBlob(ref byte* top, int size); // 0x0000000181CE3270-0x0000000181CE3290
			public void Allocate(int mapCount, int actionCount, int bindingCount, int controlCount, int interactionCount, int compositeCount); // 0x0000000181CE3290-0x0000000181CE34B0
			public void Dispose(); // 0x0000000181CE3740-0x0000000181CE37A0
			public void CopyDataFrom(UnmanagedMemory memory); // 0x0000000181CE3600-0x0000000181CE3740
			public UnmanagedMemory Clone(); // 0x0000000181CE34B0-0x0000000181CE3600
		}
	
		internal struct GlobalState // TypeDefIndex: 6098
		{
			// Fields
			internal InlinedArray<GCHandle> globalList; // 0x00
			internal CallbackArray<Action<object, InputActionChange>> onActionChange; // 0x18
			internal CallbackArray<Action<object>> onActionControlsChanged; // 0x68
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6099
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static SavedStructState<GlobalState> __9__143_0; // 0x08
			public static Action __9__143_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181CE3200-0x0000000181CE3270
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SaveAndResetState_b__143_0(ref GlobalState state); // 0x0000000181CE2D70-0x0000000181CE2EE0
			internal void _SaveAndResetState_b__143_1(); // 0x0000000181CE2EE0-0x0000000181CE2F20
		}
	
		// Constructors
		public InputActionState(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static InputActionState(); // 0x0000000181CE15B0-0x0000000181CE1700
	
		// Methods
		public void Initialize(InputBindingResolver resolver); // 0x0000000181CDC000-0x0000000181CDC640
		private void ComputeControlGroupingIfNecessary(); // 0x0000000181CD92D0-0x0000000181CD94E0
		public void ClaimDataFrom(InputBindingResolver resolver); // 0x0000000181CD8DB0-0x0000000181CD8E90
		~InputActionState(); // 0x0000000181CDB150-0x0000000181CDB240
		public void Dispose(); // 0x0000000181CDA7F0-0x0000000181CDA800
		private void Destroy(bool isFinalizing = false /* Metadata: 0x00698936 */); // 0x0000000181CD9A10-0x0000000181CD9D90
		public InputActionState Clone(); // 0x0000000181CD8E90-0x0000000181CD9140
		object ICloneable.Clone(); // 0x0000000181CE1440-0x0000000181CE1450
		private bool IsUsingDevice(InputDevice device); // 0x0000000181CDCE80-0x0000000181CDD010
		private bool CanUseDevice(InputDevice device); // 0x0000000181CD8040-0x0000000181CD8250
		public bool HasEnabledActions(); // 0x0000000181CDBE90-0x0000000181CDBF10
		private void FinishBindingCompositeSetups(); // 0x0000000181CDB5C0-0x0000000181CDB6A0
		internal void PrepareForBindingReResolution(bool needFullResolve, ref InputControlList<InputControl> activeControls, ref bool hasEnabledActions); // 0x0000000181CDD900-0x0000000181CDDDE0
		public void FinishBindingResolution(bool hasEnabledActions, UnmanagedMemory oldMemory, InputControlList<InputControl> activeControls, bool isFullResolve); // 0x0000000181CDB6A0-0x0000000181CDB860
		private void RestoreActionStatesAfterReResolvingBindings(UnmanagedMemory oldState, InputControlList<InputControl> activeControls, bool isFullResolve); // 0x0000000181CE04A0-0x0000000181CE0DC0
		private bool IsActiveControl(int bindingIndex, int controlIndex); // 0x0000000181CDC760-0x0000000181CDC820
		private int FindControlIndexOnBinding(int bindingIndex, InputControl control); // 0x0000000181CDB530-0x0000000181CDB5C0
		private void ResetActionStatesDrivenBy(InputDevice device); // 0x0000000181CDFE90-0x0000000181CE0020
		private bool IsActionBoundToControlFromDevice(InputDevice device, int actionIndex); // 0x0000000181CDC640-0x0000000181CDC760
		public void ResetActionState(int actionIndex, InputActionPhase toPhase = InputActionPhase.Waiting /* Metadata: 0x00698937 */, bool hardReset = false /* Metadata: 0x00698938 */); // 0x0000000181CDFC00-0x0000000181CDFE90
		public ref TriggerState FetchActionState(InputAction action); // 0x0000000181CDB0D0-0x0000000181CDB100
		public ActionMapIndices FetchMapIndices(InputActionMap map); // 0x0000000181CDB100-0x0000000181CDB150
		public void EnableAllActions(InputActionMap map); // 0x0000000181CDA800-0x0000000181CDAAA0
		private void EnableControls(InputActionMap map); // 0x0000000181CDADF0-0x0000000181CDAE60
		public void EnableSingleAction(InputAction action); // 0x0000000181CDAE60-0x0000000181CDAFE0
		private void EnableControls(InputAction action); // 0x0000000181CDAAA0-0x0000000181CDABC0
		public void DisableAllActions(InputActionMap map); // 0x0000000181CD9F40-0x0000000181CDA2E0
		public void DisableControls(InputActionMap map); // 0x0000000181CDA600-0x0000000181CDA670
		public void DisableSingleAction(InputAction action); // 0x0000000181CDA670-0x0000000181CDA7F0
		private void DisableControls(InputAction action); // 0x0000000181CDA2E0-0x0000000181CDA400
		private void EnableControls(int mapIndex, int controlStartIndex, int numControls); // 0x0000000181CDABC0-0x0000000181CDADF0
		private void DisableControls(int mapIndex, int controlStartIndex, int numControls); // 0x0000000181CDA400-0x0000000181CDA600
		public void SetInitialStateCheckPending(int actionIndex, bool value = true /* Metadata: 0x00698939 */); // 0x0000000181CE0FF0-0x0000000181CE10A0
		private unsafe void SetInitialStateCheckPending(BindingState* bindingStatePtr, bool value); // 0x0000000181CE10A0-0x0000000181CE10E0
		private bool IsControlEnabled(int controlIndex); // 0x0000000181CDCE40-0x0000000181CDCE80
		private void SetControlEnabled(int controlIndex, bool state); // 0x0000000181CE0FB0-0x0000000181CE0FF0
		private void HookOnBeforeUpdate(); // 0x0000000181CDBF10-0x0000000181CDC000
		private void UnhookOnBeforeUpdate(); // 0x0000000181CE1490-0x0000000181CE1510
		private void OnBeforeInitialUpdate(); // 0x0000000181CDD260-0x0000000181CDD540
		void IInputStateChangeMonitor.NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long mapControlAndBindingIndex); // 0x0000000181CE1510-0x0000000181CE1560
		void IInputStateChangeMonitor.NotifyTimerExpired(InputControl control, double time, long mapControlAndBindingIndex, int interactionIndex); // 0x0000000181CE1560-0x0000000181CE15B0
		private long ToCombinedMapAndControlAndBindingIndex(int mapIndex, int controlIndex, int bindingIndex); // 0x0000000181CE1450-0x0000000181CE1490
		private void SplitUpMapAndControlAndBindingIndex(long mapControlAndBindingIndex, out int mapIndex, out int controlIndex, out int bindingIndex); // 0x0000000181CE1160-0x0000000181CE1190
		internal static int GetComplexityFromMonitorIndex(long mapControlAndBindingIndex); // 0x0000000181CDBC10-0x0000000181CDBC20
		private void ProcessControlStateChange(int mapIndex, int controlIndex, int bindingIndex, double time, InputEventPtr eventPtr); // 0x0000000181CDDFC0-0x0000000181CDE8A0
		private unsafe void ProcessButtonState(ref TriggerState trigger, int actionIndex, BindingState* bindingStatePtr); // 0x0000000181CDDDE0-0x0000000181CDDFC0
		private static unsafe bool ShouldIgnoreInputOnCompositeBinding(BindingState* binding, InputEvent* eventPtr); // 0x0000000181CE1120-0x0000000181CE1160
		private bool IsConflictingInput(ref TriggerState trigger, int actionIndex); // 0x0000000181CDC8A0-0x0000000181CDCE40
		private ushort GetActionBindingStartIndexAndCount(int actionIndex, out ushort bindingCount); // 0x0000000181CDB860-0x0000000181CDB890
		private void ProcessDefaultInteraction(ref TriggerState trigger, int actionIndex); // 0x0000000181CDE8A0-0x0000000181CDEC80
		private void ProcessInteractions(ref TriggerState trigger, int interactionStartIndex, int interactionCount); // 0x0000000181CDEC80-0x0000000181CDEEF0
		private void ProcessTimeout(double time, int mapIndex, int controlIndex, int bindingIndex, int interactionIndex); // 0x0000000181CDEEF0-0x0000000181CDF2C0
		internal void SetTotalTimeoutCompletionTime(float seconds, ref TriggerState trigger); // 0x0000000181CE10E0-0x0000000181CE1120
		internal void StartTimeout(float seconds, ref TriggerState trigger); // 0x0000000181CE1190-0x0000000181CE1350
		private void StopTimeout(int interactionIndex); // 0x0000000181CE1350-0x0000000181CE1440
		internal void ChangePhaseOfInteraction(InputActionPhase newPhase, ref TriggerState trigger, InputActionPhase phaseAfterPerformed = InputActionPhase.Waiting /* Metadata: 0x0069893A */, InputActionPhase phaseAfterCanceled = InputActionPhase.Waiting /* Metadata: 0x0069893B */, bool processNextInteractionOnCancel = true /* Metadata: 0x0069893C */); // 0x0000000181CD8800-0x0000000181CD8DB0
		private bool ChangePhaseOfAction(InputActionPhase newPhase, ref TriggerState trigger, InputActionPhase phaseAfterPerformedOrCanceled = InputActionPhase.Waiting /* Metadata: 0x0069893D */); // 0x0000000181CD8550-0x0000000181CD8800
		private unsafe void ChangePhaseOfActionInternal(int actionIndex, TriggerState* actionState, InputActionPhase newPhase, ref TriggerState trigger, bool isDisablingAction = false /* Metadata: 0x0069893E */); // 0x0000000181CD8250-0x0000000181CD8550
		private void CallActionListeners(int actionIndex, InputActionMap actionMap, InputActionPhase phase, ref CallbackArray<Action<InputAction.CallbackContext>> listeners, string callbackName); // 0x0000000181CD7DB0-0x0000000181CD8040
		private object GetActionOrNoneString(ref TriggerState trigger); // 0x0000000181CDB8D0-0x0000000181CDB9B0
		internal InputAction GetActionOrNull(int bindingIndex); // 0x0000000181CDBA50-0x0000000181CDBAF0
		internal InputAction GetActionOrNull(ref TriggerState trigger); // 0x0000000181CDB9B0-0x0000000181CDBA50
		internal InputControl GetControl(ref TriggerState trigger); // 0x0000000181CDBCA0-0x0000000181CDBCF0
		private IInputInteraction GetInteractionOrNull(ref TriggerState trigger); // 0x0000000181CDBCF0-0x0000000181CDBD30
		internal int GetBindingIndexInMap(int bindingIndex); // 0x0000000181CDBAF0-0x0000000181CDBB40
		internal int GetBindingIndexInState(int mapIndex, int bindingIndexInMap); // 0x0000000181CDBB40-0x0000000181CDBB80
		internal ref BindingState GetBindingState(int bindingIndex); // 0x0000000181CDBB80-0x0000000181CDBB90
		internal ref InputBinding GetBinding(int bindingIndex); // 0x0000000181CDBB90-0x0000000181CDBC10
		internal InputActionMap GetActionMap(int bindingIndex); // 0x0000000181CDB890-0x0000000181CDB8D0
		private void ResetInteractionStateAndCancelIfNecessary(int mapIndex, int bindingIndex, int interactionIndex, InputActionPhase phaseAfterCanceled); // 0x0000000181CE02F0-0x0000000181CE03D0
		private void ResetInteractionState(int interactionIndex); // 0x0000000181CE03D0-0x0000000181CE04A0
		internal int GetValueSizeInBytes(int bindingIndex, int controlIndex); // 0x0000000181CDBD30-0x0000000181CDBDE0
		internal Type GetValueType(int bindingIndex, int controlIndex); // 0x0000000181CDBDE0-0x0000000181CDBE90
		internal static bool IsActuated(ref TriggerState trigger, float threshold = 0f /* Metadata: 0x0069893F */); // 0x0000000181CDC820-0x0000000181CDC8A0
		internal unsafe void ReadValue(int bindingIndex, int controlIndex, void* buffer, int bufferSize, bool ignoreComposites = false /* Metadata: 0x00698943 */); // 0x0000000181CDF870-0x0000000181CDFA80
		internal TValue ReadValue<TValue>(int bindingIndex, int controlIndex, bool ignoreComposites = false /* Metadata: 0x00698944 */)
			where TValue : struct;
		internal TValue ApplyProcessors<TValue>(int bindingIndex, TValue value, InputControl<TValue> controlOfType = null)
			where TValue : struct;
		public float EvaluateCompositePartMagnitude(int bindingIndex, int partNumber); // 0x0000000181CDAFE0-0x0000000181CDB0D0
		internal double GetCompositePartPressTime(int bindingIndex, int partNumber); // 0x0000000181CDBC20-0x0000000181CDBCA0
		internal unsafe TValue ReadCompositePartValue<TValue, TComparer>(int bindingIndex, int partNumber, bool* buttonValuePtr, out int controlIndex, TComparer comparer = default)
			where TValue : struct
			where TComparer : IComparer<TValue>;
		internal unsafe bool ReadCompositePartValue(int bindingIndex, int partNumber, void* buffer, int bufferSize); // 0x0000000181CDF400-0x0000000181CDF560
		internal object ReadCompositePartValueAsObject(int bindingIndex, int partNumber); // 0x0000000181CDF2C0-0x0000000181CDF400
		internal object ReadValueAsObject(int bindingIndex, int controlIndex, bool ignoreComposites = false /* Metadata: 0x00698945 */); // 0x0000000181CDF690-0x0000000181CDF870
		internal bool ReadValueAsButton(int bindingIndex, int controlIndex); // 0x0000000181CDF560-0x0000000181CDF690
		internal static ISavedState SaveAndResetState(); // 0x0000000181CE0DC0-0x0000000181CE0FB0
		private void AddToGlobalList(); // 0x0000000181CD7BC0-0x0000000181CD7DB0
		private void RemoveMapFromGlobalList(); // 0x0000000181CDFA80-0x0000000181CDFC00
		private static void CompactGlobalList(); // 0x0000000181CD9140-0x0000000181CD92D0
		internal void NotifyListenersOfActionChange(InputActionChange change); // 0x0000000181CDD010-0x0000000181CDD160
		internal static void NotifyListenersOfActionChange(InputActionChange change, object actionOrMapOrAsset); // 0x0000000181CDD160-0x0000000181CDD260
		private static void ResetGlobals(); // 0x0000000181CE0020-0x0000000181CE02F0
		internal static int FindAllEnabledActions(List<InputAction> result); // 0x0000000181CDB240-0x0000000181CDB530
		internal static void OnDeviceChange(InputDevice device, InputDeviceChange change); // 0x0000000181CDD540-0x0000000181CDD900
		internal static void DeferredResolutionOfBindings(); // 0x0000000181CD94E0-0x0000000181CD9840
		internal static void DisableAllActions(); // 0x0000000181CD9D90-0x0000000181CD9F40
		internal static void DestroyAllActionMapStates(); // 0x0000000181CD9840-0x0000000181CD9A10
	}
}
