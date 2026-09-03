/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct PenState : IInputStateTypeInfo // TypeDefIndex: 6437
	{
		// Fields
		[InputControl(usage = "Point", dontReset = true)]
		public Vector2 position; // 0x00
		[InputControl(usage = "Secondary2DMotion", layout = "Delta")]
		public Vector2 delta; // 0x08
		[InputControl(layout = "Vector2", displayName = "Tilt", usage = "Tilt")]
		public Vector2 tilt; // 0x10
		[InputControl(layout = "Analog", usage = "Pressure", defaultState = 0f)]
		public float pressure; // 0x18
		[InputControl(layout = "Axis", displayName = "Twist", usage = "Twist")]
		public float twist; // 0x1C
		[InputControl(name = "tip", displayName = "Tip", layout = "Button", bit = 0, usage = "PrimaryAction")]
		[InputControl(name = "press", useStateFrom = "tip", synthetic = true, usages = new string[0])]
		[InputControl(name = "eraser", displayName = "Eraser", layout = "Button", bit = 1)]
		[InputControl(name = "inRange", displayName = "In Range?", layout = "Button", bit = 4, synthetic = true)]
		[InputControl(name = "barrel1", displayName = "Barrel Button #1", layout = "Button", bit = 2, alias = "barrelFirst", usage = "SecondaryAction")]
		[InputControl(name = "barrel2", displayName = "Barrel Button #2", layout = "Button", bit = 3, alias = "barrelSecond")]
		[InputControl(name = "barrel3", displayName = "Barrel Button #3", layout = "Button", bit = 5, alias = "barrelThird")]
		[InputControl(name = "barrel4", displayName = "Barrel Button #4", layout = "Button", bit = 6, alias = "barrelFourth")]
		[InputControl(name = "radius", layout = "Vector2", format = "VEC2", sizeInBits = 64, usage = "Radius", offset = 4294967294)]
		[InputControl(name = "pointerId", layout = "Digital", format = "UINT", sizeInBits = 32, offset = 4294967294)]
		public ushort buttons; // 0x20
		[InputControl(name = "displayIndex", displayName = "Display Index", layout = "Integer")]
		private ushort displayIndex; // 0x22
	
		// Properties
		public static FourCC Format { get; } // 0x0000000181DCFA60-0x0000000181DCFAA0 
		public FourCC format { get; } // 0x0000000181DCFAA0-0x0000000181DCFAE0 
	
		// Methods
		public PenState WithButton(PenButton button, bool state = true /* Metadata: 0x00699019 */); // 0x0000000181DCFA10-0x0000000181DCFA60
	}
}
