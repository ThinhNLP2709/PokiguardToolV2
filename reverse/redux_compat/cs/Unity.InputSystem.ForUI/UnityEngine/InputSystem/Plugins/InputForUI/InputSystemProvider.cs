/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.InputForUI;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;

// Image 76: Unity.InputSystem.ForUI.dll - Assembly: Unity.InputSystem.ForUI, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15884-15887

namespace UnityEngine.InputSystem.Plugins.InputForUI
{
	internal class InputSystemProvider : IEventProviderImpl // TypeDefIndex: 15885
	{
		// Fields
		private InputEventPartialProvider m_InputEventPartialProvider; // 0x10
		private DefaultInputActions m_DefaultInputActions; // 0x18
		private InputActionAsset m_InputActionAsset; // 0x20
		private InputAction m_PointAction; // 0x28
		private InputAction m_MoveAction; // 0x30
		private InputAction m_SubmitAction; // 0x38
		private InputAction m_CancelAction; // 0x40
		private InputAction m_LeftClickAction; // 0x48
		private InputAction m_MiddleClickAction; // 0x50
		private InputAction m_RightClickAction; // 0x58
		private InputAction m_ScrollWheelAction; // 0x60
		private InputAction m_NextPreviousAction; // 0x68
		private List<UnityEngine.InputForUI.Event> m_Events; // 0x70
		private PointerState m_MouseState; // 0x78
		private PointerState m_PenState; // 0xA0
		private bool m_SeenPenEvents; // 0xC8
		private PointerState m_TouchState; // 0xD0
		private bool m_SeenTouchEvents; // 0xF8
		private const float k_SmallestReportedMovementSqrDist = 0.01f; // Metadata: 0x006AA1E3
		private NavigationEventRepeatHelper m_RepeatHelper; // 0x100
		private bool m_ResetSeenEventsOnUpdate; // 0x108
		private const float kScrollUGUIScaleFactor = 3f; // Metadata: 0x006AA1E7
		private static Action<InputActionAsset> s_OnRegisterActions; // 0x00
		private const uint k_DefaultPlayerId = 0; // Metadata: 0x006AA1EB
	
		// Properties
		private UnityEngine.InputForUI.EventModifiers m_EventModifiers { get; } // 0x0000000181CCF6A0-0x0000000181CCF6C0 
		private DiscreteTime m_CurrentTime { get; } // 0x0000000181CCF670-0x0000000181CCF6A0 
		public uint playerCount { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Nested types
		public static class Actions // TypeDefIndex: 15886
		{
			// Fields
			public static readonly string PointAction; // 0x00
			public static readonly string MoveAction; // 0x08
			public static readonly string SubmitAction; // 0x10
			public static readonly string CancelAction; // 0x18
			public static readonly string LeftClickAction; // 0x20
			public static readonly string MiddleClickAction; // 0x28
			public static readonly string RightClickAction; // 0x30
			public static readonly string ScrollWheelAction; // 0x38
	
			// Constructors
			static Actions(); // 0x0000000181CCAFF0-0x0000000181CCB230
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 15887
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<UnityEngine.InputForUI.Event> __9__33_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181CCF830-0x0000000181CCF8F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _Update_b__33_0(UnityEngine.InputForUI.Event a, UnityEngine.InputForUI.Event b); // 0x0000000181CCF6C0-0x0000000181CCF830
		}
	
		// Constructors
		static InputSystemProvider(); // 0x0000000181CCF4A0-0x0000000181CCF5B0
		public InputSystemProvider(); // 0x0000000181CCF5B0-0x0000000181CCF670
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Bootstrap(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Initialize(); // 0x0000000181CCBEA0-0x0000000181CCC0E0
		public void Shutdown(); // 0x0000000181CCE860-0x0000000181CCE970
		public void OnActionsChange(); // 0x0000000181CCC0E0-0x0000000181CCC110
		public void Update(); // 0x0000000181CCEF80-0x0000000181CCF4A0
		private void ResetSeenEvents(); // 0x0000000181CCE5F0-0x0000000181CCE600
		public bool ActionAssetIsNotNull(); // 0x0000000181CCB230-0x0000000181CCB280
		private void DirectionNavigation(DiscreteTime currentTime); // 0x0000000181CCB280-0x0000000181CCB720
		private InputDevice GetActiveDeviceFromDirection(NavigationEvent.Direction direction); // 0x0000000181CCBC10-0x0000000181CCBCC0
		private ValueTuple<Vector2, bool> ReadCurrentNavigationMoveVector(); // 0x0000000181CCD7F0-0x0000000181CCD8B0
		private NavigationEvent.Direction ReadNextPreviousDirection(); // 0x0000000181CCD8B0-0x0000000181CCDA00
		private static int SortEvents(UnityEngine.InputForUI.Event a, UnityEngine.InputForUI.Event b); // 0x0000000181CCE970-0x0000000181CCEAB0
		public void OnFocusChanged(bool focus); // 0x0000000181CCC730-0x0000000181CCC750
		public bool RequestCurrentState(UnityEngine.InputForUI.Event.Type type); // 0x0000000181CCE040-0x0000000181CCE5F0
		internal static Vector2 ScreenBottomLeftToPanelPosition(Vector2 position, int targetDisplay); // 0x0000000181CCE600-0x0000000181CCE6C0
		private PointerEvent ToPointerStateEvent(DiscreteTime currentTime, [IsReadOnly] in PointerState state, EventSource eventSource); // 0x0000000181CCEAB0-0x0000000181CCEBE0
		private EventSource GetEventSource(InputAction.CallbackContext ctx); // 0x0000000181CCBCC0-0x0000000181CCBD00
		private EventSource GetEventSource(InputDevice device); // 0x0000000181CCBD00-0x0000000181CCBE70
		private ref PointerState GetPointerStateForSource(EventSource eventSource); // 0x0000000181CCBE70-0x0000000181CCBEA0
		private void DispatchFromCallback([IsReadOnly] in UnityEngine.InputForUI.Event ev); // 0x0000000181CCB720-0x0000000181CCB8B0
		private static int FindTouchFingerIndex(Touchscreen touchscreen, InputAction.CallbackContext ctx); // 0x0000000181CCB910-0x0000000181CCBC10
		private void OnPointerPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCC830-0x0000000181CCD120
		private void OnSubmitPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCD660-0x0000000181CCD7F0
		private void OnCancelPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCC110-0x0000000181CCC2A0
		private void OnClickPerformed(InputAction.CallbackContext ctx, EventSource eventSource, PointerEvent.Button button); // 0x0000000181CCC2A0-0x0000000181CCC730
		private void OnLeftClickPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCC750-0x0000000181CCC7C0
		private void OnMiddleClickPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCC7C0-0x0000000181CCC830
		private void OnRightClickPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCD120-0x0000000181CCD190
		private void OnScrollWheelPerformed(InputAction.CallbackContext ctx); // 0x0000000181CCD190-0x0000000181CCD660
		private void RegisterFixedActions(); // 0x0000000181CCDF60-0x0000000181CCE040
		private void UnregisterFixedActions(); // 0x0000000181CCEF40-0x0000000181CCEF80
		private InputAction FindActionAndRegisterCallback(string actionNameOrId, Action<InputAction.CallbackContext> callback = null); // 0x0000000181CCB8B0-0x0000000181CCB910
		private void RegisterActions(); // 0x0000000181CCDA00-0x0000000181CCDF60
		private void UnregisterAction(ref InputAction action, Action<InputAction.CallbackContext> callback = null); // 0x0000000181CCEBE0-0x0000000181CCEC20
		private void UnregisterActions(); // 0x0000000181CCEC20-0x0000000181CCEF40
		private void SelectInputActionAsset(); // 0x0000000181CCE6C0-0x0000000181CCE7F0
		internal static void SetOnRegisterActions(Action<InputActionAsset> callback); // 0x0000000181CCE7F0-0x0000000181CCE860
	}
}
