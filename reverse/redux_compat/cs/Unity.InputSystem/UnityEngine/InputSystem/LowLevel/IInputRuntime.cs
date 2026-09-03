/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal interface IInputRuntime // TypeDefIndex: 6481
	{
		// Properties
		InputUpdateDelegate onUpdate { get; set; }
		Action<InputUpdateType> onBeforeUpdate { get; set; }
		Func<InputUpdateType, bool> onShouldRunUpdate { get; set; }
		Action<int, string> onDeviceDiscovered { get; set; }
		Action<bool> onPlayerFocusChanged { get; set; }
		bool isPlayerFocused { get; }
		Action onShutdown { get; set; }
		float pollingFrequency { get; set; }
		double currentTime { get; }
		double currentTimeForFixedUpdate { get; }
		float unscaledGameTime { get; }
		double currentTimeOffsetToRealtimeSinceStartup { get; }
		bool runInBackground { get; set; }
		Vector2 screenSize { get; }
		ScreenOrientation screenOrientation { get; }
		bool normalizeScrollWheelDelta { get; set; }
		float scrollWheelDeltaPerTick { get; }
	
		// Methods
		int AllocateDeviceId();
		void Update(InputUpdateType type);
		void QueueEvent(InputEvent* ptr);
		long DeviceCommand(int deviceId, InputDeviceCommand* commandPtr);
	}
}
