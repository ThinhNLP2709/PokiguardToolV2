/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XInput.LowLevel
{
	internal struct XInputControllerWindowsState : IInputStateTypeInfo // TypeDefIndex: 6283
	{
		// Fields
		[InputControl(name = "dpad", layout = "Dpad", sizeInBits = 4, bit = 0)]
		[InputControl(name = "dpad/up", bit = 0)]
		[InputControl(name = "dpad/down", bit = 1)]
		[InputControl(name = "dpad/left", bit = 2)]
		[InputControl(name = "dpad/right", bit = 3)]
		[InputControl(name = "start", bit = 4, displayName = "Start")]
		[InputControl(name = "select", bit = 5, displayName = "Select")]
		[InputControl(name = "leftStickPress", bit = 6)]
		[InputControl(name = "rightStickPress", bit = 7)]
		[InputControl(name = "leftShoulder", bit = 8)]
		[InputControl(name = "rightShoulder", bit = 9)]
		[InputControl(name = "buttonSouth", bit = 12, displayName = "A")]
		[InputControl(name = "buttonEast", bit = 13, displayName = "B")]
		[InputControl(name = "buttonWest", bit = 14, displayName = "X")]
		[InputControl(name = "buttonNorth", bit = 15, displayName = "Y")]
		public ushort buttons; // 0x00
		[InputControl(name = "leftTrigger", format = "BYTE")]
		public byte leftTrigger; // 0x02
		[InputControl(name = "rightTrigger", format = "BYTE")]
		public byte rightTrigger; // 0x03
		[InputControl(name = "leftStick", layout = "Stick", format = "VC2S")]
		[InputControl(name = "leftStick/x", offset = 0, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
		[InputControl(name = "leftStick/left", offset = 0, format = "SHRT")]
		[InputControl(name = "leftStick/right", offset = 0, format = "SHRT")]
		[InputControl(name = "leftStick/y", offset = 2, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
		[InputControl(name = "leftStick/up", offset = 2, format = "SHRT")]
		[InputControl(name = "leftStick/down", offset = 2, format = "SHRT")]
		public short leftStickX; // 0x04
		public short leftStickY; // 0x06
		[InputControl(name = "rightStick", layout = "Stick", format = "VC2S")]
		[InputControl(name = "rightStick/x", offset = 0, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
		[InputControl(name = "rightStick/left", offset = 0, format = "SHRT")]
		[InputControl(name = "rightStick/right", offset = 0, format = "SHRT")]
		[InputControl(name = "rightStick/y", offset = 2, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
		[InputControl(name = "rightStick/up", offset = 2, format = "SHRT")]
		[InputControl(name = "rightStick/down", offset = 2, format = "SHRT")]
		public short rightStickX; // 0x08
		public short rightStickY; // 0x0A
	
		// Properties
		public FourCC format { get; } // 0x0000000181DA5960-0x0000000181DA59A0 
	
		// Nested types
		public enum Button // TypeDefIndex: 6284
		{
			DPadUp = 0,
			DPadDown = 1,
			DPadLeft = 2,
			DPadRight = 3,
			Start = 4,
			Select = 5,
			LeftThumbstickPress = 6,
			RightThumbstickPress = 7,
			LeftShoulder = 8,
			RightShoulder = 9,
			A = 12,
			B = 13,
			X = 14,
			Y = 15
		}
	
		// Methods
		public XInputControllerWindowsState WithButton(Button button); // 0x0000000181DA5930-0x0000000181DA5960
	}
}
