/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct SetIMECursorPositionCommand : IInputDeviceCommandInfo // TypeDefIndex: 6420
	{
		// Fields
		internal const int kSize = 16; // Metadata: 0x00698FE6
		public InputDeviceCommand baseCommand; // 0x00
		private Vector2 m_Position; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DD0890-0x0000000181DD08D0 
		public Vector2 position { get; } // 0x0000000181DD08D0-0x0000000181DD08F0 
		public FourCC typeStatic { get; } // 0x0000000181DD08F0-0x0000000181DD0930 
	
		// Methods
		public static SetIMECursorPositionCommand Create(Vector2 cursorPosition); // 0x0000000181DD0810-0x0000000181DD0890
	}
}
