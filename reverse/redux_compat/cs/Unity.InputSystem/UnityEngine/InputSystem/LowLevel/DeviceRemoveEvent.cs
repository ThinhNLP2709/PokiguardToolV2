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
	public struct DeviceRemoveEvent : IInputEventTypeInfo // TypeDefIndex: 6454
	{
		// Fields
		public const int Type = 1146242381; // Metadata: 0x00699036
		public InputEvent baseEvent; // 0x00
	
		// Properties
		public FourCC typeStatic { get; } // 0x0000000181DBF6B0-0x0000000181DBF6C0 
	
		// Methods
		public InputEventPtr ToEventPtr(); // 0x0000000180370C60-0x0000000180370C70
		public static DeviceRemoveEvent Create(int deviceId, double time = -1 /* Metadata: 0x0069902E */); // 0x0000000181DBF5F0-0x0000000181DBF6B0
	}
}
