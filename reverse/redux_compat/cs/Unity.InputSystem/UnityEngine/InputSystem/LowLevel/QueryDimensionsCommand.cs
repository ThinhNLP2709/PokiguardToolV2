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
	public struct QueryDimensionsCommand : IInputDeviceCommandInfo // TypeDefIndex: 6405
	{
		// Fields
		internal const int kSize = 16; // Metadata: 0x00698FB1
		public InputDeviceCommand baseCommand; // 0x00
		public Vector2 outDimensions; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DCFCB0-0x0000000181DCFCF0 
		public FourCC typeStatic { get; } // 0x0000000181DCFCF0-0x0000000181DCFD30 
	
		// Methods
		public static QueryDimensionsCommand Create(); // 0x0000000181DCFC50-0x0000000181DCFCB0
	}
}
