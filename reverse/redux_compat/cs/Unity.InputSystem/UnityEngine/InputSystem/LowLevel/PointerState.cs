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
	internal struct PointerState : IInputStateTypeInfo // TypeDefIndex: 6438
	{
		// Fields
		private uint pointerId; // 0x00
		[InputControl(layout = "Vector2", displayName = "Position", usage = "Point", dontReset = true)]
		public Vector2 position; // 0x04
		[InputControl(layout = "Delta", displayName = "Delta", usage = "Secondary2DMotion")]
		public Vector2 delta; // 0x0C
		[InputControl(layout = "Analog", displayName = "Pressure", usage = "Pressure", defaultState = 1f)]
		public float pressure; // 0x14
		[InputControl(layout = "Vector2", displayName = "Radius", usage = "Radius")]
		public Vector2 radius; // 0x18
		[InputControl(name = "press", displayName = "Press", layout = "Button", format = "BIT", bit = 0)]
		public ushort buttons; // 0x20
		[InputControl(name = "displayIndex", layout = "Integer", displayName = "Display Index")]
		public ushort displayIndex; // 0x22
	
		// Properties
		public static FourCC kFormat { get; } // 0x0000000181DCFB20-0x0000000181DCFB60 
		public FourCC format { get; } // 0x0000000181DCFAE0-0x0000000181DCFB20 
	}
}
