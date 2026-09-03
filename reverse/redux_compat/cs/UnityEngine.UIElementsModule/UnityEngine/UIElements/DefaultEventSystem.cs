/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using Unity.Properties;
using UnityEngine;
using UnityEngine.InputForUI;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class DefaultEventSystem // TypeDefIndex: 4165
	{
		// Fields
		internal static Func<bool> IsEditorRemoteConnected; // 0x00
		private Panel m_FocusedPanel; // 0x10
		private Panel m_PreviousFocusedPanel; // 0x18
		private Focusable m_PreviousFocusedElement; // 0x20
		internal int m_UpdateFrameCount; // 0x28
		private InputForUIProcessor m_InputForUIProcessor; // 0x30
		private bool m_IsInputReady; // 0x38
		private bool m_IsInputForUIActive; // 0x39
		private IScreenRaycaster m_Raycaster; // 0x40
		public float worldSpaceMaxDistance; // 0x48
		public int worldSpaceLayers; // 0x4C
		private static readonly Vector3 s_InvalidPanelCoordinates; // 0x08
		internal bool verbose; // 0x50
		internal bool logToGameScreen; // 0x51
		private Label m_LogLabel; // 0x58
		private List<string> m_LogLines; // 0x60
	
		// Properties
		private bool isAppFocused { get; } // 0x0000000182491200-0x0000000182491240 
		public Panel focusedPanel { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001824906F0-0x0000000182490750
		private InputForUIProcessor inputForUIProcessor { get; } // 0x00000001824910D0-0x0000000182491200 
		internal bool isInputReady { set; } // 0x00000001824912B0-0x00000001824914F0
		public IScreenRaycaster raycaster { get; } // 0x0000000182491240-0x00000001824912B0 
	
		// Nested types
		public enum UpdateMode // TypeDefIndex: 4166
		{
			Always = 0,
			IgnoreIfAppNotFocused = 1
		}
	
		internal struct FocusBasedEventSequenceContext : IDisposable // TypeDefIndex: 4167
		{
			// Fields
			private DefaultEventSystem es; // 0x00
	
			// Constructors
			public FocusBasedEventSequenceContext(DefaultEventSystem es); // 0x0000000182495160-0x00000001824951E0
	
			// Methods
			public void Dispose(); // 0x0000000182495110-0x0000000182495160
		}
	
		private class InputForUIProcessor // TypeDefIndex: 4168
		{
			// Fields
			private readonly DefaultEventSystem m_EventSystem; // 0x10
			private DiscreteTime m_LastPointerTimestamp; // 0x18
			private DiscreteTime m_NextPointerTimestamp; // 0x20
			private readonly Queue<UnityEngine.InputForUI.Event> m_EventList; // 0x28
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 4169
			{
				// Fields
				public static readonly __c __9; // 0x00
				[TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })]
				public static Func<Vector3, ValueTuple<PointerEvent, int, float>, EventBase> __9__9_0; // 0x08
				[TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })]
				public static Func<Vector3, ValueTuple<PointerEvent, int, float>, EventBase> __9__9_1; // 0x10
				[TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })]
				public static Func<Vector3, ValueTuple<PointerEvent, int, float>, EventBase> __9__9_2; // 0x18
				[TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })]
				public static Func<Vector3, ValueTuple<PointerEvent, int, float>, EventBase> __9__9_3; // 0x20
				[TupleElementNames(new string[3] {"move", "deviceType", "mod" })]
				public static Func<ValueTuple<Vector2, NavigationDeviceType, UnityEngine.EventModifiers>, EventBase> __9__10_2; // 0x28
				[TupleElementNames(new string[3] {"direction", "deviceType", "mod" })]
				public static Func<ValueTuple<NavigationMoveEvent.Direction, NavigationDeviceType, UnityEngine.EventModifiers>, EventBase> __9__10_3; // 0x30
				[TupleElementNames(new string[2] {"deviceType", "mod" })]
				public static Func<ValueTuple<NavigationDeviceType, UnityEngine.EventModifiers>, EventBase> __9__10_0; // 0x38
				[TupleElementNames(new string[2] {"deviceType", "mod" })]
				public static Func<ValueTuple<NavigationDeviceType, UnityEngine.EventModifiers>, EventBase> __9__10_1; // 0x40
				[TupleElementNames(new string[2] {"modifiers", "keyCode" })]
				public static Func<ValueTuple<UnityEngine.EventModifiers, KeyCode>, EventBase> __9__11_0; // 0x48
				[TupleElementNames(new string[2] {"modifiers", "keyCode" })]
				public static Func<ValueTuple<UnityEngine.EventModifiers, KeyCode>, EventBase> __9__11_1; // 0x50
				[TupleElementNames(new string[2] {"modifiers", "character" })]
				public static Func<ValueTuple<UnityEngine.EventModifiers, char>, EventBase> __9__12_0; // 0x58
	
				// Constructors
				static __c(); // 0x00000001824ABCF0-0x00000001824ABD60
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal EventBase _ProcessPointerEvent_b__9_0(Vector3 panelPosition, [TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })] ValueTuple<PointerEvent, int, float> t); // 0x00000001824A9010-0x00000001824A9130
				internal EventBase _ProcessPointerEvent_b__9_1(Vector3 panelPosition, [TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })] ValueTuple<PointerEvent, int, float> t); // 0x00000001824A9130-0x00000001824A9250
				internal EventBase _ProcessPointerEvent_b__9_2(Vector3 panelPosition, [TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })] ValueTuple<PointerEvent, int, float> t); // 0x00000001824A9250-0x00000001824A9370
				internal EventBase _ProcessPointerEvent_b__9_3(Vector3 panelPosition, [TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })] ValueTuple<PointerEvent, int, float> t); // 0x00000001824A9370-0x00000001824A9490
				internal EventBase _ProcessNavigationEvent_b__10_2([TupleElementNames(new string[3] {"move", "deviceType", "mod" })] ValueTuple<Vector2, NavigationDeviceType, UnityEngine.EventModifiers> t); // 0x00000001824A8F60-0x00000001824A8FC0
				internal EventBase _ProcessNavigationEvent_b__10_3([TupleElementNames(new string[3] {"direction", "deviceType", "mod" })] ValueTuple<NavigationMoveEvent.Direction, NavigationDeviceType, UnityEngine.EventModifiers> t); // 0x00000001824A8FC0-0x00000001824A9010
				internal EventBase _ProcessNavigationEvent_b__10_0([TupleElementNames(new string[2] {"deviceType", "mod" })] ValueTuple<NavigationDeviceType, UnityEngine.EventModifiers> t); // 0x00000001824A8EE0-0x00000001824A8F20
				internal EventBase _ProcessNavigationEvent_b__10_1([TupleElementNames(new string[2] {"deviceType", "mod" })] ValueTuple<NavigationDeviceType, UnityEngine.EventModifiers> t); // 0x00000001824A8F20-0x00000001824A8F60
				internal EventBase _ProcessKeyEvent_b__11_0([TupleElementNames(new string[2] {"modifiers", "keyCode" })] ValueTuple<UnityEngine.EventModifiers, KeyCode> t); // 0x00000001824A8E40-0x00000001824A8E90
				internal EventBase _ProcessKeyEvent_b__11_1([TupleElementNames(new string[2] {"modifiers", "keyCode" })] ValueTuple<UnityEngine.EventModifiers, KeyCode> t); // 0x00000001824A8E90-0x00000001824A8EE0
				internal EventBase _ProcessTextInputEvent_b__12_0([TupleElementNames(new string[2] {"modifiers", "character" })] ValueTuple<UnityEngine.EventModifiers, char> t); // 0x00000001824A9490-0x00000001824A94E0
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass14_0 // TypeDefIndex: 4170
			{
				// Fields
				public IMECompositionEvent compositionEvent; // 0x10
	
				// Constructors
				public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal EventBase _ProcessIMECompositionEvent_b__0(int _); // 0x00000001824AA9D0-0x00000001824AAAA0
			}
	
			// Constructors
			public InputForUIProcessor(DefaultEventSystem eventSystem); // 0x000000018249C990-0x000000018249CA80
	
			// Methods
			public void Reset(); // 0x000000018249C7F0-0x000000018249C880
			public bool OnEvent([IsReadOnly] in UnityEngine.InputForUI.Event ev); // 0x000000018249A2B0-0x000000018249A380
			public void ProcessInputForUIEvents(); // 0x000000018249A550-0x000000018249ABC0
			private UnityEngine.EventModifiers GetModifiers(UnityEngine.InputForUI.EventModifiers eventModifiers); // 0x000000018249A200-0x000000018249A2B0
			private void ProcessPointerEvent(PointerEvent pointerEvent); // 0x000000018249B410-0x000000018249C650
			private void ProcessNavigationEvent(NavigationEvent navigationEvent); // 0x000000018249AE80-0x000000018249B410
			private void ProcessKeyEvent(KeyEvent keyEvent); // 0x000000018249ABC0-0x000000018249AE80
			private void ProcessTextInputEvent(TextInputEvent textInputEvent); // 0x000000018249C650-0x000000018249C7F0
			private void ProcessCommandEvent(CommandEvent commandEvent); // 0x000000018249A380-0x000000018249A410
			private void ProcessIMECompositionEvent(IMECompositionEvent compositionEvent); // 0x000000018249A410-0x000000018249A550
			[CompilerGenerated]
			private EventBase _ProcessPointerEvent_b__9_4(Vector3 panelPosition, [TupleElementNames(new string[3] {"pointerEvent", "pointerId", "deltaTime" })] ValueTuple<PointerEvent, int, float> t); // 0x000000018249C880-0x000000018249C990
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4171
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB040-0x00000001824AB0B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.cctor_b__52_0(); // 0x00000001802E7840-0x00000001802E7850
		}
	
		// Constructors
		public DefaultEventSystem(); // 0x0000000182491040-0x00000001824910D0
		static DefaultEventSystem(); // 0x0000000182490F50-0x0000000182491040
	
		// Methods
		private bool ShouldIgnoreEventsOnAppNotFocused(); // 0x0000000182490810-0x0000000182490830
		public void Update(UpdateMode updateMode = UpdateMode.Always /* Metadata: 0x00660518 */); // 0x0000000182490E80-0x0000000182490F50
		internal FocusBasedEventSequenceContext FocusBasedEventSequence(); // 0x000000018248FE00-0x000000018248FE90
		private void RemoveInputProcessor(); // 0x0000000182490750-0x0000000182490810
		private void InitInputProcessor(); // 0x0000000182490090-0x0000000182490220
		internal void OnFocusEvent(RuntimePanel panel, FocusEvent evt); // 0x00000001824906F0-0x0000000182490750
		internal void SendFocusBasedEvent<TArg>(Func<TArg, EventBase> evtFactory, TArg arg);
		internal void SendPositionBasedEvent<TArg>(Vector3 mousePosition, Vector3 delta, int pointerId, int? targetDisplay, Func<Vector3, TArg, EventBase> evtFactory, TArg arg, bool deselectIfNoTarget = false /* Metadata: 0x00660519 */);
		internal void SendRayBasedEvent<TArg>(Ray worldRay, float maxDistance, int pointerId, Func<Vector3, TArg, EventBase> evtFactory, TArg arg, bool deselectIfNoTarget = false /* Metadata: 0x0066051A */);
		internal void FindTargetAtPosition(Vector2 mousePosition, Vector2 delta, int pointerId, int? targetDisplay, out VisualElement target, out BaseRuntimePanel targetPanel, out Vector3 targetPanelPosition, out VisualElement elementUnderPointer, out Camera camera); // 0x000000018248EB80-0x000000018248F720
		internal void FindTargetAtRay(Ray worldRay, float maxDistance, int pointerId, out VisualElement target, out BaseRuntimePanel targetPanel, out Vector3 targetPanelPosition, out VisualElement elementUnderPointer); // 0x000000018248F720-0x000000018248FE00
		private Vector3 GetPanelPosition(VisualElement pickedElement, IPanelComponent panelComponent, Ray worldRay); // 0x000000018248FE90-0x0000000182490090
		private void UpdateFocusedPanel(Panel runtimePanel); // 0x0000000182490830-0x0000000182490910
		private void UpdateWorldSpacePointers(); // 0x0000000182490910-0x0000000182490E80
		private void Log(object o); // 0x0000000182490650-0x00000001824906F0
		private void LogToGameScreen(string s); // 0x0000000182490220-0x0000000182490650
	}
}
