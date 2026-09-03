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

namespace UnityEngine.InputSystem.DualShock.LowLevel
{
	internal struct DualShock3HIDInputReport : IInputStateTypeInfo // TypeDefIndex: 6385
	{
		// Fields
		private ushort padding1; // 0x00
		[InputControl(name = "select", displayName = "Share", bit = 0)]
		[InputControl(name = "leftStickPress", bit = 1)]
		[InputControl(name = "rightStickPress", bit = 2)]
		[InputControl(name = "start", displayName = "Options", bit = 3)]
		[InputControl(name = "dpad", format = "BIT", layout = "Dpad", bit = 4, sizeInBits = 4)]
		[InputControl(name = "dpad/up", bit = 4)]
		[InputControl(name = "dpad/right", bit = 5)]
		[InputControl(name = "dpad/down", bit = 6)]
		[InputControl(name = "dpad/left", bit = 7)]
		public byte buttons1; // 0x02
		[InputControl(name = "leftTriggerButton", layout = "Button", bit = 0, synthetic = true)]
		[InputControl(name = "rightTriggerButton", layout = "Button", bit = 1, synthetic = true)]
		[InputControl(name = "leftShoulder", bit = 2)]
		[InputControl(name = "rightShoulder", bit = 3)]
		[InputControl(name = "buttonNorth", displayName = "Triangle", bit = 4)]
		[InputControl(name = "buttonEast", displayName = "Circle", bit = 5)]
		[InputControl(name = "buttonSouth", displayName = "Cross", bit = 6)]
		[InputControl(name = "buttonWest", displayName = "Square", bit = 7)]
		public byte buttons2; // 0x03
		[InputControl(name = "systemButton", layout = "Button", displayName = "System", bit = 0)]
		[InputControl(name = "touchpadButton", layout = "Button", displayName = "Touchpad Press", bit = 1)]
		public byte buttons3; // 0x04
		private byte padding2; // 0x05
		[InputControl(name = "leftStick", layout = "Stick", format = "VC2B")]
		[InputControl(name = "leftStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "leftStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "leftStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
		[InputControl(name = "leftStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "leftStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "leftStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1,invert=false")]
		public byte leftStickX; // 0x06
		public byte leftStickY; // 0x07
		[InputControl(name = "rightStick", layout = "Stick", format = "VC2B")]
		[InputControl(name = "rightStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "rightStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "rightStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
		[InputControl(name = "rightStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "rightStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "rightStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1,invert=false")]
		public byte rightStickX; // 0x08
		public byte rightStickY; // 0x09
		private unsafe fixed /* 0x00000000-0x00000000 */ byte padding3[0]; // 0x0A
		[InputControl(name = "leftTrigger", format = "BYTE")]
		public byte leftTrigger; // 0x12
		[InputControl(name = "rightTrigger", format = "BYTE")]
		public byte rightTrigger; // 0x13
	
		// Properties
		public FourCC format { get; } // 0x0000000181DC11D0-0x0000000181DC1210 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _padding3_e__FixedBuffer // TypeDefIndex: 6386
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	}
}
