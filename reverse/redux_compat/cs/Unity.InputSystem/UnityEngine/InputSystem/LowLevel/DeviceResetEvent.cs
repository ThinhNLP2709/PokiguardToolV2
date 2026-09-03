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
	public struct DeviceResetEvent : IInputEventTypeInfo // TypeDefIndex: 6455
	{
		// Fields
		public const int Type = 1146245972; // Metadata: 0x00699044
		public InputEvent baseEvent; // 0x00
		public bool hardReset; // 0x08
	
		// Properties
		public FourCC typeStatic { get; } // 0x0000000181DBF7A0-0x0000000181DBF7B0 
	
		// Methods
		public static DeviceResetEvent Create(int deviceId, bool hardReset = false /* Metadata: 0x0069903B */, double time = -1 /* Metadata: 0x0069903C */); // 0x0000000181DBF6C0-0x0000000181DBF7A0
	}
}
