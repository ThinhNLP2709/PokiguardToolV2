/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct QueryEnabledStateCommand : IInputDeviceCommandInfo // TypeDefIndex: 6406
	{
		// Fields
		internal const int kSize = 9; // Metadata: 0x00698FB2
		public InputDeviceCommand baseCommand; // 0x00
		public bool isEnabled; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DCFD90-0x0000000181DCFDD0 
		public FourCC typeStatic { get; } // 0x0000000181DCFDD0-0x0000000181DCFE10 
	
		// Methods
		public static QueryEnabledStateCommand Create(); // 0x0000000181DCFD30-0x0000000181DCFD90
	}
}
