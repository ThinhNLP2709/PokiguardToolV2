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

namespace UnityEngine.InputSystem.Switch.LowLevel
{
	internal struct SwitchProControllerHIDInputState : IInputStateTypeInfo // TypeDefIndex: 6328
	{
		// Fields
		public static FourCC Format; // 0x00
		[InputControl(name = "leftStick", layout = "Stick", format = "VC2B")]
		[InputControl(name = "leftStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
		[InputControl(name = "leftStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.15,clampMax=0.5,invert")]
		[InputControl(name = "leftStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=0.85")]
		[InputControl(name = "leftStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
		[InputControl(name = "leftStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.15,clampMax=0.5,invert")]
		[InputControl(name = "leftStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=0.85,invert=false")]
		public byte leftStickX; // 0x00
		public byte leftStickY; // 0x01
		[InputControl(name = "rightStick", layout = "Stick", format = "VC2B")]
		[InputControl(name = "rightStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
		[InputControl(name = "rightStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
		[InputControl(name = "rightStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
		[InputControl(name = "rightStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
		[InputControl(name = "rightStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.15,clampMax=0.5,invert")]
		[InputControl(name = "rightStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=0.85,invert=false")]
		public byte rightStickX; // 0x02
		public byte rightStickY; // 0x03
		[InputControl(name = "dpad", format = "BIT", bit = 0, sizeInBits = 4)]
		[InputControl(name = "dpad/up", bit = 0)]
		[InputControl(name = "dpad/right", bit = 1)]
		[InputControl(name = "dpad/down", bit = 2)]
		[InputControl(name = "dpad/left", bit = 3)]
		[InputControl(name = "buttonWest", displayName = "Y", shortDisplayName = "Y", bit = 4, usage = "SecondaryAction")]
		[InputControl(name = "buttonNorth", displayName = "X", shortDisplayName = "X", bit = 5)]
		[InputControl(name = "buttonSouth", displayName = "B", shortDisplayName = "B", bit = 6, usages = new string[2] {"Back", "Cancel" })]
		[InputControl(name = "buttonEast", displayName = "A", shortDisplayName = "A", bit = 7, usages = new string[2] {"PrimaryAction", "Submit" })]
		[InputControl(name = "leftShoulder", displayName = "L", shortDisplayName = "L", bit = 8)]
		[InputControl(name = "rightShoulder", displayName = "R", shortDisplayName = "R", bit = 9)]
		[InputControl(name = "leftStickPress", displayName = "Left Stick", bit = 10)]
		[InputControl(name = "rightStickPress", displayName = "Right Stick", bit = 11)]
		[InputControl(name = "leftTrigger", displayName = "ZL", shortDisplayName = "ZL", format = "BIT", bit = 12)]
		[InputControl(name = "rightTrigger", displayName = "ZR", shortDisplayName = "ZR", format = "BIT", bit = 13)]
		[InputControl(name = "start", displayName = "Plus", bit = 14, usage = "Menu")]
		[InputControl(name = "select", displayName = "Minus", bit = 15)]
		public ushort buttons1; // 0x04
		[InputControl(name = "capture", layout = "Button", displayName = "Capture", bit = 0)]
		[InputControl(name = "home", layout = "Button", displayName = "Home", bit = 1)]
		public byte buttons2; // 0x06
	
		// Properties
		public FourCC format { get; } // 0x0000000181DBA140-0x0000000181DBA190 
	
		// Nested types
		public enum Button // TypeDefIndex: 6329
		{
			Up = 0,
			Right = 1,
			Down = 2,
			Left = 3,
			West = 4,
			Y = 4,
			North = 5,
			X = 5,
			South = 6,
			B = 6,
			East = 7,
			A = 7,
			L = 8,
			R = 9,
			StickL = 10,
			StickR = 11,
			ZL = 12,
			ZR = 13,
			Plus = 14,
			Minus = 15,
			Capture = 16,
			Home = 17
		}
	
		// Constructors
		static SwitchProControllerHIDInputState(); // 0x0000000181DBA0D0-0x0000000181DBA140
	
		// Methods
		public SwitchProControllerHIDInputState WithButton(Button button, bool value = true /* Metadata: 0x00698E15 */); // 0x0000000181DB9FF0-0x0000000181DBA0D0
		public void Set(Button button, bool state); // 0x0000000181DB9F80-0x0000000181DB9FF0
		public void Press(Button button); // 0x0000000181DB9E80-0x0000000181DB9F00
		public void Release(Button button); // 0x0000000181DB9F00-0x0000000181DB9F80
	}
}
