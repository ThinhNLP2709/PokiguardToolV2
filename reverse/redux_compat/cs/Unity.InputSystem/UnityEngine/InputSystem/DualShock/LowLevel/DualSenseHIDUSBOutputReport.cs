/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.DualShock.LowLevel
{
	internal struct DualSenseHIDUSBOutputReport : IInputDeviceCommandInfo // TypeDefIndex: 6381
	{
		// Fields
		internal const int kSize = 56; // Metadata: 0x00698F8F
		public InputDeviceCommand baseCommand; // 0x00
		public byte reportId; // 0x08
		public DualSenseHIDOutputReportPayload payload; // 0x09
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DB9D40-0x0000000181DB9D80 
		public FourCC typeStatic { get; } // 0x0000000181DB9D80-0x0000000181DB9DC0 
	
		// Methods
		public static DualSenseHIDUSBOutputReport Create(DualSenseHIDOutputReportPayload payload, int outputReportSize); // 0x0000000181DC1030-0x0000000181DC10F0
	}
}
