/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public sealed class InputActionTrace : IEnumerable<InputActionTrace.ActionEventPtr>, IDisposable // TypeDefIndex: 6585
	{
		// Fields
		private bool m_SubscribedToAll; // 0x10
		private bool m_OnActionChangeHooked; // 0x11
		private InlinedArray<InputAction> m_SubscribedActions; // 0x18
		private InlinedArray<InputActionMap> m_SubscribedActionMaps; // 0x30
		private InputEventBuffer m_EventBuffer; // 0x48
		private InlinedArray<InputActionState> m_ActionMapStates; // 0x68
		private InlinedArray<InputActionState> m_ActionMapStateClones; // 0x80
		private Action<InputAction.CallbackContext> m_CallbackDelegate; // 0x98
		private Action<object, InputActionChange> m_ActionChangeDelegate; // 0xA0
	
		// Properties
		public InputEventBuffer buffer { get; } // 0x0000000181CE8AC0-0x0000000181CE8AE0 
		public int count { get; } // 0x000000018150C180-0x000000018150C190 
	
		// Nested types
		public struct ActionEventPtr // TypeDefIndex: 6586
		{
			// Fields
			internal InputActionState m_State; // 0x00
			internal unsafe ActionEvent* m_Ptr; // 0x08
	
			// Properties
			public InputAction action { get; } // 0x0000000181CE4260-0x0000000181CE4290 
			public InputActionPhase phase { get; } // 0x0000000181CE4350-0x0000000181CE4360 
			public InputControl control { get; } // 0x0000000181CE4290-0x0000000181CE42D0 
			public IInputInteraction interaction { get; } // 0x0000000181CE4300-0x0000000181CE4350 
			public double time { get; } // 0x0000000181CE4370-0x0000000181CE4390 
			public double startTime { get; } // 0x0000000181CE4360-0x0000000181CE4370 
			public double duration { get; } // 0x0000000181CE42D0-0x0000000181CE4300 
			public int valueSizeInBytes { get; } // 0x0000000181CE4390-0x0000000181CE43A0 
	
			// Methods
			public object ReadValueAsObject(); // 0x0000000181CE3A80-0x0000000181CE3CF0
			public unsafe void ReadValue(void* buffer, int bufferSize); // 0x0000000181CE3CF0-0x0000000181CE3DE0
			public TValue ReadValue<TValue>()
				where TValue : struct;
			public override string ToString(); // 0x0000000181CE3DE0-0x0000000181CE4260
		}
	
		private struct Enumerator : IEnumerator<ActionEventPtr> // TypeDefIndex: 6587
		{
			// Fields
			private readonly InputActionTrace m_Trace; // 0x00
			private readonly unsafe ActionEvent* m_Buffer; // 0x08
			private readonly int m_EventCount; // 0x10
			private unsafe ActionEvent* m_CurrentEvent; // 0x18
			private int m_CurrentIndex; // 0x20
	
			// Properties
			public ActionEventPtr Current { get; } // 0x0000000181CE6AB0-0x0000000181CE6B40 
			object IEnumerator.Current { get; } // 0x0000000181CE69A0-0x0000000181CE6A60 
	
			// Constructors
			public unsafe Enumerator(InputActionTrace trace); // 0x0000000181CE6A60-0x0000000181CE6AB0
	
			// Methods
			public bool MoveNext(); // 0x0000000181CE6930-0x0000000181CE6990
			public void Reset(); // 0x0000000181CE6990-0x0000000181CE69A0
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public InputActionTrace(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public InputActionTrace(InputAction action); // 0x0000000181CE8850-0x0000000181CE89A0
		public InputActionTrace(InputActionMap actionMap); // 0x0000000181CE89A0-0x0000000181CE8AC0
	
		// Methods
		public void SubscribeToAll(); // 0x0000000181CE7B10-0x0000000181CE7DA0
		public void UnsubscribeFromAll(); // 0x0000000181CE8370-0x0000000181CE8640
		public void SubscribeTo(InputAction action); // 0x0000000181CE7EC0-0x0000000181CE8000
		public void SubscribeTo(InputActionMap actionMap); // 0x0000000181CE7DA0-0x0000000181CE7EC0
		public void UnsubscribeFrom(InputAction action); // 0x0000000181CE8640-0x0000000181CE8760
		public void UnsubscribeFrom(InputActionMap actionMap); // 0x0000000181CE8760-0x0000000181CE8850
		public void RecordAction(InputAction.CallbackContext context); // 0x0000000181CE7950-0x0000000181CE7B10
		public void Clear(); // 0x0000000181CE72B0-0x0000000181CE72E0
		~InputActionTrace(); // 0x0000000181CE74F0-0x0000000181CE7560
		public override string ToString(); // 0x0000000181CE8010-0x0000000181CE8300
		public void Dispose(); // 0x0000000181CE74D0-0x0000000181CE74F0
		private void DisposeInternal(); // 0x0000000181CE73C0-0x0000000181CE74D0
		public IEnumerator<ActionEventPtr> GetEnumerator(); // 0x0000000181CE7560-0x0000000181CE7610
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181CE8000-0x0000000181CE8010
		private void HookOnActionChange(); // 0x0000000181CE7610-0x0000000181CE76E0
		private void UnhookOnActionChange(); // 0x0000000181CE8300-0x0000000181CE8370
		private void OnActionChange(object actionOrMapOrAsset, InputActionChange change); // 0x0000000181CE76E0-0x0000000181CE7950
		private void CloneActionStateBeforeBindingsChange(InputActionMap actionMap); // 0x0000000181CE72E0-0x0000000181CE73C0
	}
}
