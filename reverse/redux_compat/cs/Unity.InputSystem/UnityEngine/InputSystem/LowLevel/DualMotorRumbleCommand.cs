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
	internal struct DualMotorRumbleCommand : IInputDeviceCommandInfo // TypeDefIndex: 6425
	{
		// Fields
		internal const int kSize = 16; // Metadata: 0x0069900A
		public InputDeviceCommand baseCommand; // 0x00
		public float lowFrequencyMotorSpeed; // 0x08
		public float highFrequencyMotorSpeed; // 0x0C
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DBFA50-0x0000000181DBFA90 
		public FourCC typeStatic { get; } // 0x0000000181DBFA90-0x0000000181DBFAD0 
	
		// Methods
		public static DualMotorRumbleCommand Create(float lowFrequency, float highFrequency); // 0x0000000181DBF9C0-0x0000000181DBFA50
	}
}
