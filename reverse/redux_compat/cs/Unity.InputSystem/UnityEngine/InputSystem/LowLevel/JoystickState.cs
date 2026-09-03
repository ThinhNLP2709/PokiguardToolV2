/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal struct JoystickState : IInputStateTypeInfo // TypeDefIndex: 6431
	{
		// Fields
		[InputControl(name = "trigger", displayName = "Trigger", layout = "Button", usages = new string[3] {"PrimaryTrigger", "PrimaryAction", "Submit" }, bit = 4)]
		public int buttons; // 0x00
		[InputControl(displayName = "Stick", layout = "Stick", usage = "Primary2DMotion", processors = "stickDeadzone")]
		public Vector2 stick; // 0x04
	
		// Properties
		public static FourCC kFormat { get; } // 0x0000000181DCF480-0x0000000181DCF4C0 
		public FourCC format { get; } // 0x0000000181DCF440-0x0000000181DCF480 
	
		// Nested types
		public enum Button // TypeDefIndex: 6432
		{
			HatSwitchUp = 0,
			HatSwitchDown = 1,
			HatSwitchLeft = 2,
			HatSwitchRight = 3,
			Trigger = 4
		}
	}
}
