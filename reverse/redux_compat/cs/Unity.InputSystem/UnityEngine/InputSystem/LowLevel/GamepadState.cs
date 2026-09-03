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
	public struct GamepadState : IInputStateTypeInfo // TypeDefIndex: 6423
	{
		// Fields
		internal const string ButtonSouthShortDisplayName = "A"; // Metadata: 0x00698FEA
		internal const string ButtonNorthShortDisplayName = "Y"; // Metadata: 0x00698FEC
		internal const string ButtonWestShortDisplayName = "X"; // Metadata: 0x00698FEE
		internal const string ButtonEastShortDisplayName = "B"; // Metadata: 0x00698FF0
		[InputControl(name = "dpad", layout = "Dpad", usage = "Hatswitch", displayName = "D-Pad", format = "BIT", sizeInBits = 4, bit = 0)]
		[InputControl(name = "buttonSouth", layout = "Button", bit = 6, usages = new string[2] {"PrimaryAction", "Submit" }, aliases = new string[2] {"a", "cross" }, displayName = "Button South", shortDisplayName = "A")]
		[InputControl(name = "buttonWest", layout = "Button", bit = 7, usage = "SecondaryAction", aliases = new string[2] {"x", "square" }, displayName = "Button West", shortDisplayName = "X")]
		[InputControl(name = "buttonNorth", layout = "Button", bit = 4, aliases = new string[2] {"y", "triangle" }, displayName = "Button North", shortDisplayName = "Y")]
		[InputControl(name = "buttonEast", layout = "Button", bit = 5, usages = new string[2] {"Back", "Cancel" }, aliases = new string[2] {"b", "circle" }, displayName = "Button East", shortDisplayName = "B")]
		[InputControl(name = "leftStickPress", layout = "Button", bit = 8, displayName = "Left Stick Press")]
		[InputControl(name = "rightStickPress", layout = "Button", bit = 9, displayName = "Right Stick Press")]
		[InputControl(name = "leftShoulder", layout = "Button", bit = 10, displayName = "Left Shoulder", shortDisplayName = "LB")]
		[InputControl(name = "rightShoulder", layout = "Button", bit = 11, displayName = "Right Shoulder", shortDisplayName = "RB")]
		[InputControl(name = "start", layout = "Button", bit = 12, usage = "Menu", displayName = "Start")]
		[InputControl(name = "select", layout = "Button", bit = 13, displayName = "Select")]
		public uint buttons; // 0x00
		[InputControl(layout = "Stick", usage = "Primary2DMotion", processors = "stickDeadzone", displayName = "Left Stick", shortDisplayName = "LS")]
		public Vector2 leftStick; // 0x04
		[InputControl(layout = "Stick", usage = "Secondary2DMotion", processors = "stickDeadzone", displayName = "Right Stick", shortDisplayName = "RS")]
		public Vector2 rightStick; // 0x0C
		[InputControl(layout = "Button", format = "FLT", usage = "SecondaryTrigger", displayName = "Left Trigger", shortDisplayName = "LT")]
		public float leftTrigger; // 0x14
		[InputControl(layout = "Button", format = "FLT", usage = "SecondaryTrigger", displayName = "Right Trigger", shortDisplayName = "RT")]
		public float rightTrigger; // 0x18
	
		// Properties
		public static FourCC Format { get; } // 0x0000000181DC5870-0x0000000181DC58B0 
		public FourCC format { get; } // 0x0000000181DC58B0-0x0000000181DC58F0 
	
		// Constructors
		public GamepadState(params GamepadButton[] buttons); // 0x0000000181DC57C0-0x0000000181DC5870
	
		// Methods
		public GamepadState WithButton(GamepadButton button, bool value = true /* Metadata: 0x00698FE9 */); // 0x0000000181DC5770-0x0000000181DC57C0
	}
}
