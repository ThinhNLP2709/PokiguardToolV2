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
	internal struct WarpMousePositionCommand : IInputDeviceCommandInfo // TypeDefIndex: 6422
	{
		// Fields
		internal const int kSize = 16; // Metadata: 0x00698FE8
		public InputDeviceCommand baseCommand; // 0x00
		public Vector2 warpPositionInPlayerDisplaySpace; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DD4DC0-0x0000000181DD4E00 
		public FourCC typeStatic { get; } // 0x0000000181DD4E00-0x0000000181DD4E90 
	
		// Methods
		public static WarpMousePositionCommand Create(Vector2 position); // 0x0000000181DD4D40-0x0000000181DD4DC0
	}
}
