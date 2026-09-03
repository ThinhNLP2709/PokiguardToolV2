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
	public struct MouseState : IInputStateTypeInfo // TypeDefIndex: 6435
	{
		// Fields
		[InputControl(usage = "Point", dontReset = true)]
		public Vector2 position; // 0x00
		[InputControl(usage = "Secondary2DMotion", layout = "Delta")]
		public Vector2 delta; // 0x08
		[InputControl(displayName = "Scroll", layout = "Delta")]
		[InputControl(name = "scroll/x", aliases = new string[1] {"horizontal" }, usage = "ScrollHorizontal", displayName = "Left/Right")]
		[InputControl(name = "scroll/y", aliases = new string[1] {"vertical" }, usage = "ScrollVertical", displayName = "Up/Down", shortDisplayName = "Wheel")]
		public Vector2 scroll; // 0x10
		[InputControl(name = "press", useStateFrom = "leftButton", synthetic = true, usages = new string[0])]
		[InputControl(name = "leftButton", layout = "Button", bit = 0, usage = "PrimaryAction", displayName = "Left Button", shortDisplayName = "LMB")]
		[InputControl(name = "rightButton", layout = "Button", bit = 1, usage = "SecondaryAction", displayName = "Right Button", shortDisplayName = "RMB")]
		[InputControl(name = "middleButton", layout = "Button", bit = 2, displayName = "Middle Button", shortDisplayName = "MMB")]
		[InputControl(name = "forwardButton", layout = "Button", bit = 3, usage = "Forward", displayName = "Forward")]
		[InputControl(name = "backButton", layout = "Button", bit = 4, usage = "Back", displayName = "Back")]
		[InputControl(name = "pressure", layout = "Axis", usage = "Pressure", offset = 4294967294, format = "FLT", sizeInBits = 32)]
		[InputControl(name = "radius", layout = "Vector2", usage = "Radius", offset = 4294967294, format = "VEC2", sizeInBits = 64)]
		[InputControl(name = "pointerId", layout = "Digital", format = "BIT", sizeInBits = 1, offset = 4294967294)]
		public ushort buttons; // 0x18
		[InputControl(name = "displayIndex", layout = "Integer", displayName = "Display Index")]
		public ushort displayIndex; // 0x1A
		[InputControl(name = "clickCount", layout = "Integer", displayName = "Click Count", synthetic = true)]
		public ushort clickCount; // 0x1C
	
		// Properties
		public static FourCC Format { get; } // 0x0000000181DCF800-0x0000000181DCF840 
		public FourCC format { get; } // 0x0000000181DCF840-0x0000000181DCF880 
	
		// Methods
		public MouseState WithButton(MouseButton button, bool state = true /* Metadata: 0x00699013 */); // 0x0000000181DCF7A0-0x0000000181DCF800
	}
}
