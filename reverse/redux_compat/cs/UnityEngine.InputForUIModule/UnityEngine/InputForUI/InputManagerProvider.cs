/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	internal class InputManagerProvider : IEventProviderImpl // TypeDefIndex: 15289
	{
		// Fields
		private InputEventPartialProvider _inputEventPartialProvider; // 0x10
		private string _compositionString; // 0x18
		private Configuration _configuration; // 0x20
		private IInput _input; // 0x58
		private ITime _time; // 0x60
		private NavigationEventRepeatHelper _navigationEventRepeatHelper; // 0x68
		private PointerState _mouseState; // 0x70
		private bool _isPenPresent; // 0x98
		private bool _seenAtLeastOnePenPosition; // 0x99
		private Vector2 _lastSeenPenPositionForDetection; // 0x9C
		private PointerState _penState; // 0xA8
		private PenData _lastPenData; // 0xD0
		private Dictionary<int, int> _touchFingerIdToFingerIndex; // 0xF8
		private int _touchNextFingerIndex; // 0x100
		private PointerState _touchState; // 0x108
	
		// Properties
		private EventModifiers _eventModifiers { get; } // 0x0000000181CCF6A0-0x0000000181CCF6C0 
	
		// Nested types
		private struct ButtonEventsIterator : IEnumerator // TypeDefIndex: 15290
		{
			// Fields
			private uint _mask; // 0x00
			private int _bit; // 0x04
	
			// Properties
			public bool Current { get; } // 0x00000001822A2A10-0x00000001822A2A20 
			object IEnumerator.Current { get; } // 0x00000001822A29E0-0x00000001822A2A10 
	
			// Methods
			public bool MoveNext(); // 0x00000001822A29A0-0x00000001822A29D0
			public void Reset(); // 0x00000001822A29D0-0x00000001822A29E0
			public static ButtonEventsIterator FromState(bool previous, bool down, bool up, bool current); // 0x00000001822A2940-0x00000001822A29A0
		}
	
		public struct Configuration // TypeDefIndex: 15291
		{
			// Fields
			public string HorizontalAxis; // 0x00
			public string VerticalAxis; // 0x08
			public string SubmitButton; // 0x10
			public string CancelButton; // 0x18
			public string NavigateNextButton; // 0x20
			public string NavigatePreviousButton; // 0x28
			public float InputActionsPerSecond; // 0x30
			public float RepeatDelay; // 0x34
	
			// Methods
			public static Configuration GetDefaultConfiguration(); // 0x00000001822A2D60-0x00000001822A2E90
		}
	
		internal interface IInput // TypeDefIndex: 15292
		{
			// Properties
			string compositionString { get; }
			bool touchSupported { get; }
			int touchCount { get; }
			bool mousePresent { get; }
			Vector3 mousePosition { get; }
			Vector2 mouseScrollDelta { get; }
	
			// Methods
			bool GetKey(KeyCode keyCode);
			bool GetButtonDown(string button);
			float GetAxisRaw(string axis);
			PenData GetLastPenContactEvent();
			Touch GetTouch(int index);
			bool GetMouseButton(int button);
			bool GetMouseButtonDown(int button);
			bool GetMouseButtonUp(int button);
		}
	
		private class Input : IInput // TypeDefIndex: 15293
		{
			// Properties
			public string compositionString { get; } // 0x00000001822AA8B0-0x00000001822AA8F0 
			public bool touchSupported { get; } // 0x00000001822AAA10-0x00000001822AAA50 
			public int touchCount { get; } // 0x00000001822AA9D0-0x00000001822AAA10 
			public bool mousePresent { get; } // 0x00000001822AA950-0x00000001822AA990 
			public Vector3 mousePosition { get; } // 0x00000001822AA8F0-0x00000001822AA950 
			public Vector2 mouseScrollDelta { get; } // 0x00000001822AA990-0x00000001822AA9D0 
	
			// Constructors
			public Input(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool GetKey(KeyCode key); // 0x00000001822AA670-0x00000001822AA6C0
			public bool GetButtonDown(string button); // 0x00000001822AA620-0x00000001822AA670
			public float GetAxisRaw(string axis); // 0x00000001822AA5D0-0x00000001822AA620
			public PenData GetLastPenContactEvent(); // 0x00000001822AA6C0-0x00000001822AA730
			public Touch GetTouch(int index); // 0x00000001822AA820-0x00000001822AA8B0
			public bool GetMouseButton(int button); // 0x00000001822AA7D0-0x00000001822AA820
			public bool GetMouseButtonDown(int button); // 0x00000001822AA730-0x00000001822AA780
			public bool GetMouseButtonUp(int button); // 0x00000001822AA780-0x00000001822AA7D0
		}
	
		internal interface ITime // TypeDefIndex: 15294
		{
			// Properties
			RationalTime timeAsRational { get; }
		}
	
		private class Time : ITime // TypeDefIndex: 15295
		{
			// Properties
			public RationalTime timeAsRational { get; } // 0x00000001822AC670-0x00000001822AC6A0 
	
			// Constructors
			public Time(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public InputManagerProvider(); // 0x00000001822AA2D0-0x00000001822AA5D0
	
		// Methods
		public void Initialize(); // 0x00000001822A8E90-0x00000001822A8FD0
		public void Shutdown(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Update(); // 0x00000001822A9D90-0x00000001822AA2D0
		private bool CheckTouchEvents(DiscreteTime currentTime); // 0x00000001822A8100-0x00000001822A8800
		private void DetectPen(); // 0x00000001822A8800-0x00000001822A88C0
		private static PointerEvent.Button PenStatusToButton(PenStatus status); // 0x00000001822A9850-0x00000001822A9870
		private bool CheckPenEvent(DiscreteTime currentTime, [IsReadOnly] in PenData currentPenData); // 0x00000001822A7CB0-0x00000001822A8100
		private void CheckMouseEvents(DiscreteTime currentTime, bool muted = false /* Metadata: 0x006A9F55 */); // 0x00000001822A7210-0x00000001822A7900
		private void CheckMouseScroll(DiscreteTime currentTime); // 0x00000001822A7900-0x00000001822A7CB0
		private void NextPreviousNavigation(DiscreteTime currentTime); // 0x00000001822A9630-0x00000001822A9810
		private void SubmitCancelNavigation(DiscreteTime currentTime); // 0x00000001822A9A40-0x00000001822A9D20
		private void DirectionNavigation(DiscreteTime currentTime); // 0x00000001822A88C0-0x00000001822A8D00
		private void CheckIfIMEChanged(DiscreteTime currentTime); // 0x00000001822A6F30-0x00000001822A7210
		public void OnFocusChanged(bool focus); // 0x00000001822A9810-0x00000001822A9850
		private EventSource GetEventSourceFromPressedKey(); // 0x00000001822A8D00-0x00000001822A8DE0
		private bool InputManagerJoystickWasPressed(); // 0x00000001822A91B0-0x00000001822A9230
		private bool InputManagerKeyboardWasPressed(); // 0x00000001822A9230-0x00000001822A92B0
		private float InputManagerGetAxisRawOrDefault(string axisName); // 0x00000001822A8FD0-0x00000001822A90C0
		private bool InputManagerGetButtonDownOrDefault(string axisName); // 0x00000001822A90C0-0x00000001822A91B0
		private ValueTuple<Vector2, bool> ReadCurrentNavigationMoveVector(); // 0x00000001822A9870-0x00000001822A9970
		private IMECompositionEvent ToIMECompositionEvent(DiscreteTime currentTime, string compositionString); // 0x00000001822A9D20-0x00000001822A9D90
		internal static float TiltToAzimuth(Vector2 tilt); // 0x0000000180CC3640-0x0000000180CC3740
		internal static Vector2 AzimuthAndAlitutudeToTilt(float altitude, float azimuth); // 0x0000000180CC2280-0x0000000180CC2320
		internal static float TiltToAltitude(Vector2 tilt); // 0x0000000180CC35F0-0x0000000180CC3640
		private static Vector2 MultiDisplayBottomLeftToPanelPosition(Vector2 position, out int targetDisplay); // 0x00000001822A92B0-0x00000001822A94C0
		private static Vector2 MultiDisplayToLocalScreenPosition(Vector2 position, out int? targetDisplay); // 0x00000001822A94C0-0x00000001822A9630
		private static Vector2 ScreenBottomLeftToPanelPosition(Vector2 position, int targetDisplay); // 0x00000001822A9990-0x00000001822A9A40
		private static float GetScreenHeight(int targetDisplay); // 0x00000001822A8DE0-0x00000001822A8E90
		private static Vector2 ScreenBottomLeftToPanelDelta(Vector2 delta); // 0x00000001822A9970-0x00000001822A9990
	}
}
