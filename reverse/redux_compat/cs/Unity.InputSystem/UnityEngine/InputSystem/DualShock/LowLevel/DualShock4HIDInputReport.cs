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
	internal struct DualShock4HIDInputReport : IInputStateTypeInfo // TypeDefIndex: 6384
	{
		// Fields
		public static FourCC Format; // 0x00
		[InputControl(name = "leftStick", layout = "Stick", format = "VC2B")]
		[InputControl(name = "leftStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "leftStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "leftStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
		[InputControl(name = "leftStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "leftStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "leftStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1,invert=false")]
		public byte leftStickX; // 0x00
		public byte leftStickY; // 0x01
		[InputControl(name = "rightStick", layout = "Stick", format = "VC2B")]
		[InputControl(name = "rightStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "rightStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "rightStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
		[InputControl(name = "rightStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5")]
		[InputControl(name = "rightStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "rightStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0,normalizeMax=1,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1,invert=false")]
		public byte rightStickX; // 0x02
		public byte rightStickY; // 0x03
		[InputControl(name = "dpad", format = "BIT", layout = "Dpad", sizeInBits = 4, defaultState = 8)]
		[InputControl(name = "dpad/up", format = "BIT", layout = "DiscreteButton", parameters = "minValue=7,maxValue=1,nullValue=8,wrapAtValue=7", bit = 0, sizeInBits = 4)]
		[InputControl(name = "dpad/right", format = "BIT", layout = "DiscreteButton", parameters = "minValue=1,maxValue=3", bit = 0, sizeInBits = 4)]
		[InputControl(name = "dpad/down", format = "BIT", layout = "DiscreteButton", parameters = "minValue=3,maxValue=5", bit = 0, sizeInBits = 4)]
		[InputControl(name = "dpad/left", format = "BIT", layout = "DiscreteButton", parameters = "minValue=5, maxValue=7", bit = 0, sizeInBits = 4)]
		[InputControl(name = "buttonWest", displayName = "Square", bit = 4)]
		[InputControl(name = "buttonSouth", displayName = "Cross", bit = 5)]
		[InputControl(name = "buttonEast", displayName = "Circle", bit = 6)]
		[InputControl(name = "buttonNorth", displayName = "Triangle", bit = 7)]
		public byte buttons1; // 0x04
		[InputControl(name = "leftShoulder", bit = 0)]
		[InputControl(name = "rightShoulder", bit = 1)]
		[InputControl(name = "leftTriggerButton", layout = "Button", bit = 2, synthetic = true)]
		[InputControl(name = "rightTriggerButton", layout = "Button", bit = 3, synthetic = true)]
		[InputControl(name = "select", displayName = "Share", bit = 4)]
		[InputControl(name = "start", displayName = "Options", bit = 5)]
		[InputControl(name = "leftStickPress", bit = 6)]
		[InputControl(name = "rightStickPress", bit = 7)]
		public byte buttons2; // 0x05
		[InputControl(name = "systemButton", layout = "Button", displayName = "System", bit = 0)]
		[InputControl(name = "touchpadButton", layout = "Button", displayName = "Touchpad Press", bit = 1)]
		public byte buttons3; // 0x06
		[InputControl(name = "leftTrigger", format = "BYTE")]
		public byte leftTrigger; // 0x07
		[InputControl(name = "rightTrigger", format = "BYTE")]
		public byte rightTrigger; // 0x08
	
		// Properties
		public FourCC format { get; } // 0x0000000181DC21F0-0x0000000181DC2240 
	
		// Constructors
		static DualShock4HIDInputReport(); // 0x0000000181DC2180-0x0000000181DC21F0
	}
}
