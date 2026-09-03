/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Serialization;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[Serializable]
	public sealed class InputAction : ICloneable, IDisposable // TypeDefIndex: 6048
	{
		// Fields
		private static readonly ProfilerMarker k_InputActionEnableProfilerMarker; // 0x00
		private static readonly ProfilerMarker k_InputActionDisableProfilerMarker; // 0x08
		[SerializeField]
		[Tooltip("Human readable name of the action. Must be unique within its action map (case is ignored). Can be changed without breaking references to the action.")]
		internal string m_Name; // 0x10
		[SerializeField]
		[Tooltip("Determines how the action triggers.\n\nA Value action will start and perform when a control moves from its default value and then perform on every value change. It will cancel when controls go back to default value. Also, when enabled, a Value action will respond right away to a control\'s current value.\n\nA Button action will start when a button is pressed and perform when the press threshold (see \'Default Button Press Point\' in settings) is reached. It will cancel when the button is going below the release threshold (see \'Button Release Threshold\' in settings). Also, if a button is already pressed when the action is enabled, the button has to be released first.\n\nA Pass-Through action will not explicitly start and will never cancel. Instead, for every value change on any bound control, the action will perform.")]
		internal InputActionType m_Type; // 0x18
		[FormerlySerializedAs("m_ExpectedControlLayout")]
		[SerializeField]
		[Tooltip("The type of control expected by the action (e.g. \"Digital\" for buttons, \"Vector2\" for sticks). This will limit the controls shown when setting up bindings in the UI and will also limit which controls can be bound interactively to the action.")]
		internal string m_ExpectedControlType; // 0x20
		[SerializeField]
		[Tooltip("Unique ID of the action (GUID). Used to reference the action from bindings such that actions can be renamed without breaking references.")]
		internal string m_Id; // 0x28
		[SerializeField]
		internal string m_Processors; // 0x30
		[SerializeField]
		internal string m_Interactions; // 0x38
		[SerializeField]
		internal InputBinding[] m_SingletonActionBindings; // 0x40
		[SerializeField]
		internal ActionFlags m_Flags; // 0x48
		[NonSerialized]
		internal InputBinding? m_BindingMask; // 0x50
		[NonSerialized]
		internal int m_BindingsStartIndex; // 0xB0
		[NonSerialized]
		internal int m_BindingsCount; // 0xB4
		[NonSerialized]
		internal int m_ControlStartIndex; // 0xB8
		[NonSerialized]
		internal int m_ControlCount; // 0xBC
		[NonSerialized]
		internal int m_ActionIndexInState; // 0xC0
		[NonSerialized]
		internal InputActionMap m_ActionMap; // 0xC8
		[NonSerialized]
		internal CallbackArray<Action<CallbackContext>> m_OnStarted; // 0xD0
		[NonSerialized]
		internal CallbackArray<Action<CallbackContext>> m_OnCanceled; // 0x120
		[NonSerialized]
		internal CallbackArray<Action<CallbackContext>> m_OnPerformed; // 0x170
	
		// Properties
		public string name { get; } // 0x0000000180377550-0x0000000180377560 
		public InputActionType type { get; } // 0x0000000180B23260-0x0000000180B23270 
		public Guid id { get; } // 0x0000000181CC1C60-0x0000000181CC1CE0 
		internal Guid idDontGenerate { get; } // 0x0000000181CC1C10-0x0000000181CC1C60 
		public string expectedControlType { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public string processors { get; } // 0x000000018031E110-0x000000018031E120 
		public string interactions { get; } // 0x00000001803272A0-0x00000001803272B0 
		public InputActionMap actionMap { get; } // 0x0000000181CC1860-0x0000000181CC1880 
		public InputBinding? bindingMask { get; set; } // 0x0000000181CC1980-0x0000000181CC19C0 0x0000000181CC1F50-0x0000000181CC21D0
		public ReadOnlyArray<InputBinding> bindings { get; } // 0x0000000181CC19C0-0x0000000181CC1A60 
		public ReadOnlyArray<InputControl> controls { get; } // 0x0000000181CC1A60-0x0000000181CC1B20 
		public InputActionPhase phase { get; } // 0x0000000181CC1D60-0x0000000181CC1DC0 
		public bool inProgress { get; } // 0x0000000181CC1CE0-0x0000000181CC1D40 
		public bool enabled { get; } // 0x0000000181CC1BB0-0x0000000181CC1C10 
		public bool triggered { get; } // 0x0000000181CC1DC0-0x0000000181CC1E50 
		public InputControl activeControl { get; } // 0x0000000181CC1880-0x0000000181CC1900 
		public Type activeValueType { get; } // 0x0000000181CC1900-0x0000000181CC1980 
		public bool wantsInitialStateCheck { get; set; } // 0x0000000181CC1E50-0x0000000181CC1E60 0x0000000181CC21D0-0x0000000181CC21F0
		internal bool isSingletonAction { get; } // 0x0000000181CC1D40-0x0000000181CC1D60 
		private InputActionState.TriggerState currentState { get; } // 0x0000000181CC1B20-0x0000000181CC1BB0 
	
		// Events
		public event Action<CallbackContext> started {
			add; // 0x0000000181CC1810-0x0000000181CC1860
			remove; // 0x0000000181CC1F00-0x0000000181CC1F50
		}
		public event Action<CallbackContext> canceled {
			add; // 0x0000000181CC1770-0x0000000181CC17C0
			remove; // 0x0000000181CC1E60-0x0000000181CC1EB0
		}
		public event Action<CallbackContext> performed {
			add; // 0x0000000181CC17C0-0x0000000181CC1810
			remove; // 0x0000000181CC1EB0-0x0000000181CC1F00
		}
	
		// Nested types
		[Flags]
		internal enum ActionFlags // TypeDefIndex: 6049
		{
			WantsInitialStateCheck = 1
		}
	
		public struct CallbackContext // TypeDefIndex: 6050
		{
			// Fields
			internal InputActionState m_State; // 0x00
			internal int m_ActionIndex; // 0x08
	
			// Properties
			private int actionIndex { get; } // 0x0000000180732D20-0x0000000180732D30 
			private int bindingIndex { get; } // 0x0000000181CB1B10-0x0000000181CB1B50 
			private int controlIndex { get; } // 0x0000000181CB1B90-0x0000000181CB1BD0 
			private int interactionIndex { get; } // 0x0000000181CB1CB0-0x0000000181CB1CF0 
			public InputActionPhase phase { get; } // 0x0000000181CB1DA0-0x0000000181CB1DE0 
			public bool started { get; } // 0x0000000181CB1E20-0x0000000181CB1E60 
			public bool performed { get; } // 0x0000000181CB1D60-0x0000000181CB1DA0 
			public bool canceled { get; } // 0x0000000181CB1B50-0x0000000181CB1B90 
			public InputAction action { get; } // 0x0000000181CB1AC0-0x0000000181CB1B10 
			public InputControl control { get; } // 0x0000000181CB1BD0-0x0000000181CB1C40 
			public IInputInteraction interaction { get; } // 0x0000000181CB1CF0-0x0000000181CB1D60 
			public double time { get; } // 0x0000000181CB1E60-0x0000000181CB1EA0 
			public double startTime { get; } // 0x0000000181CB1DE0-0x0000000181CB1E20 
			public double duration { get; } // 0x0000000181CB1C40-0x0000000181CB1CB0 
			public Type valueType { get; } // 0x0000000181CB1F30-0x0000000181CB1FC0 
			public int valueSizeInBytes { get; } // 0x0000000181CB1EA0-0x0000000181CB1F30 
	
			// Methods
			public unsafe void ReadValue(void* buffer, int bufferSize); // 0x0000000181CB14C0-0x0000000181CB16B0
			public TValue ReadValue<TValue>()
				where TValue : struct;
			public bool ReadValueAsButton(); // 0x0000000181CB1340-0x0000000181CB1400
			public object ReadValueAsObject(); // 0x0000000181CB1400-0x0000000181CB14C0
			public override string ToString(); // 0x0000000181CB16B0-0x0000000181CB1AC0
		}
	
		// Constructors
		public InputAction(); // 0x0000000181CC14D0-0x0000000181CC1530
		public InputAction(string name = null, InputActionType type = InputActionType.Value /* Metadata: 0x006988E9 */, string binding = null, string interactions = null, string processors = null, string expectedControlType = null); // 0x0000000181CC1530-0x0000000181CC1770
		static InputAction(); // 0x0000000181CC1430-0x0000000181CC14D0
	
		// Methods
		public void Dispose(); // 0x0000000181CC0440-0x0000000181CC0460
		public override string ToString(); // 0x0000000181CC0D40-0x0000000181CC1030
		public void Enable(); // 0x0000000181CC0460-0x0000000181CC0610
		public void Disable(); // 0x0000000181CC02C0-0x0000000181CC0440
		public InputAction Clone(); // 0x0000000181CC0050-0x0000000181CC01D0
		object ICloneable.Clone(); // 0x0000000181CC0050-0x0000000181CC01D0
		public TValue ReadValue<TValue>()
			where TValue : struct;
		public object ReadValueAsObject(); // 0x0000000181CC0BC0-0x0000000181CC0C60
		public float GetControlMagnitude(); // 0x0000000181CC07D0-0x0000000181CC0830
		public void Reset(); // 0x0000000181CC0CA0-0x0000000181CC0D40
		public bool IsPressed(); // 0x0000000181CC0B10-0x0000000181CC0B60
		public bool IsInProgress(); // 0x0000000181CC0AC0-0x0000000181CC0B10
		private int ExpectedFrame(); // 0x0000000181CC0610-0x0000000181CC0680
		public bool WasPressedThisFrame(); // 0x0000000181CC12A0-0x0000000181CC1330
		public bool WasPressedThisDynamicUpdate(); // 0x0000000181CC1230-0x0000000181CC12A0
		public bool WasReleasedThisFrame(); // 0x0000000181CC13A0-0x0000000181CC1430
		public bool WasReleasedThisDynamicUpdate(); // 0x0000000181CC1330-0x0000000181CC13A0
		public bool WasPerformedThisFrame(); // 0x0000000181CC11A0-0x0000000181CC1230
		public bool WasPerformedThisDynamicUpdate(); // 0x0000000181CC1130-0x0000000181CC11A0
		public bool WasCompletedThisFrame(); // 0x0000000181CC10A0-0x0000000181CC1130
		public bool WasCompletedThisDynamicUpdate(); // 0x0000000181CC1030-0x0000000181CC10A0
		public float GetTimeoutCompletionPercentage(); // 0x0000000181CC0930-0x0000000181CC0AC0
		internal string MakeSureIdIsInPlace(); // 0x0000000181CC0B60-0x0000000181CC0BC0
		internal void GenerateId(); // 0x0000000181CC0780-0x0000000181CC07D0
		internal InputActionMap GetOrCreateActionMap(); // 0x0000000181CC0830-0x0000000181CC0930
		private void CreateInternalActionMapForSingletonAction(); // 0x0000000181CC01D0-0x0000000181CC02C0
		internal void RequestInitialStateCheckOnEnabledAction(); // 0x0000000181CC0C60-0x0000000181CC0CA0
		internal bool ActiveControlIsValid(InputControl control); // 0x0000000181CBFC50-0x0000000181CBFE20
		internal InputBinding? FindEffectiveBindingMask(); // 0x0000000181CC0680-0x0000000181CC0780
		internal int BindingIndexOnActionToBindingIndexOnMap(int indexOfBindingOnAction); // 0x0000000181CBFE20-0x0000000181CBFF80
		internal int BindingIndexOnMapToBindingIndexOnAction(int indexOfBindingOnMap); // 0x0000000181CBFF80-0x0000000181CC0050
	}
}
