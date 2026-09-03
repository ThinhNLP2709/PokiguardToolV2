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
	internal struct DualSenseHIDBluetoothOutputReport : IInputDeviceCommandInfo // TypeDefIndex: 6382
	{
		// Fields
		internal const int kSize = 86; // Metadata: 0x00698F90
		public InputDeviceCommand baseCommand; // 0x00
		public byte reportId; // 0x08
		public byte tag1; // 0x09
		public byte tag2; // 0x0A
		public DualSenseHIDOutputReportPayload payload; // 0x0B
		public uint crc32; // 0x52
		public unsafe fixed /* 0x00000000-0x00000000 */ byte rawData[0]; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DB9D40-0x0000000181DB9D80 
		public FourCC typeStatic { get; } // 0x0000000181DB9D80-0x0000000181DB9DC0 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _rawData_e__FixedBuffer // TypeDefIndex: 6383
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public static DualSenseHIDBluetoothOutputReport Create(DualSenseHIDOutputReportPayload payload, byte outputSequenceId, int outputReportSize); // 0x0000000181DC0DA0-0x0000000181DC0E80
	}
}
