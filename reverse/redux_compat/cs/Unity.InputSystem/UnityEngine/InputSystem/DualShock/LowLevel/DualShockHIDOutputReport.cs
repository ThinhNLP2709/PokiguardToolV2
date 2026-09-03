/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.DualShock.LowLevel
{
	internal struct DualShockHIDOutputReport : IInputDeviceCommandInfo // TypeDefIndex: 6387
	{
		// Fields
		internal const int kSize = 40; // Metadata: 0x00698F92
		internal const int kReportId = 5; // Metadata: 0x00698F93
		public InputDeviceCommand baseCommand; // 0x00
		public byte reportId; // 0x08
		public byte flags; // 0x09
		public unsafe fixed /* 0x00000000-0x00000000 */ byte unknown1[0]; // 0x0A
		public byte highFrequencyMotorSpeed; // 0x0C
		public byte lowFrequencyMotorSpeed; // 0x0D
		public byte redColor; // 0x0E
		public byte greenColor; // 0x0F
		public byte blueColor; // 0x10
		public unsafe fixed /* 0x00000000-0x00000000 */ byte unknown2[0]; // 0x11
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DB9D40-0x0000000181DB9D80 
		public FourCC typeStatic { get; } // 0x0000000181DB9D80-0x0000000181DB9DC0 
	
		// Nested types
		[Flags]
		public enum Flags // TypeDefIndex: 6388
		{
			Rumble = 1,
			Color = 2
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _unknown1_e__FixedBuffer // TypeDefIndex: 6389
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _unknown2_e__FixedBuffer // TypeDefIndex: 6390
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public void SetMotorSpeeds(float lowFreq, float highFreq); // 0x0000000181DC26F0-0x0000000181DC2740
		public void SetColor(Color color); // 0x0000000181DC2670-0x0000000181DC26F0
		public static DualShockHIDOutputReport Create(int outputReportSize); // 0x0000000181DC25F0-0x0000000181DC2670
	}
}
