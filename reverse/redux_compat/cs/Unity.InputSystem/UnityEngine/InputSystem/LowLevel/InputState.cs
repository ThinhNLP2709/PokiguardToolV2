/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public static class InputState // TypeDefIndex: 6496
	{
		// Properties
		public static InputUpdateType currentUpdateType { get; } // 0x0000000181DE4800-0x0000000181DE4840 
		public static uint updateCount { get; } // 0x0000000181DE4840-0x0000000181DE4880 
		public static double currentTime { get; } // 0x0000000181DE4780-0x0000000181DE4800 
	
		// Events
		public static event Action<InputDevice, InputEventPtr> onChange {
			add; // 0x0000000181DE4710-0x0000000181DE4780
			remove; // 0x0000000181DE4880-0x0000000181DE48F0
		}
	
		// Nested types
		private class StateChangeMonitorDelegate : IInputStateChangeMonitor // TypeDefIndex: 6497
		{
			// Fields
			public Action<InputControl, double, InputEventPtr, long> valueChangeCallback; // 0x10
			public Action<InputControl, double, long, int> timerExpiredCallback; // 0x18
	
			// Constructors
			public StateChangeMonitorDelegate(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex); // 0x0000000181DE9440-0x0000000181DE9470
			public void NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex); // 0x0000000181DE9470-0x0000000181DE9490
		}
	
		// Methods
		public static void Change(InputDevice device, InputEventPtr eventPtr, InputUpdateType updateType = InputUpdateType.None /* Metadata: 0x006990DC */); // 0x0000000181DE4170-0x0000000181DE4470
		public static void Change<TState>(InputControl control, TState state, InputUpdateType updateType = InputUpdateType.None /* Metadata: 0x006990DD */, InputEventPtr eventPtr = default)
			where TState : struct;
		public static void Change<TState>(InputControl control, ref ref TState state, InputUpdateType updateType = InputUpdateType.None /* Metadata: 0x006990DE */, InputEventPtr eventPtr = default)
			where TState : struct;
		public static void AddChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex = -1 /* Metadata: 0x006990DF */, uint groupIndex = 0 /* Metadata: 0x006990E7 */); // 0x0000000181DE3EA0-0x0000000181DE4060
		public static IInputStateChangeMonitor AddChangeMonitor(InputControl control, Action<InputControl, double, InputEventPtr, long> valueChangeCallback, int monitorIndex = -1 /* Metadata: 0x006990E8 */, Action<InputControl, double, long, int> timerExpiredCallback = null); // 0x0000000181DE4060-0x0000000181DE4170
		public static void RemoveChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex = -1 /* Metadata: 0x006990E9 */); // 0x0000000181DE45E0-0x0000000181DE4710
		public static void AddChangeMonitorTimeout(InputControl control, IInputStateChangeMonitor monitor, double time, long monitorIndex = -1 /* Metadata: 0x006990F1 */, int timerIndex = -1 /* Metadata: 0x006990F9 */); // 0x0000000181DE3DA0-0x0000000181DE3EA0
		public static void RemoveChangeMonitorTimeout(IInputStateChangeMonitor monitor, long monitorIndex = -1 /* Metadata: 0x006990FA */, int timerIndex = -1 /* Metadata: 0x00699102 */); // 0x0000000181DE4500-0x0000000181DE45E0
	
		// Extension methods
		public static bool IsIntegerFormat(this FourCC format); // 0x0000000181DE4470-0x0000000181DE4500
	}
}
