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
	public struct QueryCanRunInBackground : IInputDeviceCommandInfo // TypeDefIndex: 6404
	{
		// Fields
		internal const int kSize = 9; // Metadata: 0x00698FB0
		public InputDeviceCommand baseCommand; // 0x00
		public bool canRunInBackground; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DCFBD0-0x0000000181DCFC10 
		public FourCC typeStatic { get; } // 0x0000000181DCFC10-0x0000000181DCFC50 
	
		// Methods
		public static QueryCanRunInBackground Create(); // 0x0000000181DCFB60-0x0000000181DCFBD0
	}
}
