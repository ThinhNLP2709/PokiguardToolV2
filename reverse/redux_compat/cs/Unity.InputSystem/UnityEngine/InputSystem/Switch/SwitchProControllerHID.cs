/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Switch.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Switch
{
	[InputControlLayout(stateType = typeof(SwitchProControllerHIDInputState), displayName = "Switch Pro Controller")]
	public class SwitchProControllerHID : Gamepad, IInputStateCallbackReceiver, IEventPreProcessor // TypeDefIndex: 6317
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _captureButton_k__BackingField; // 0x210
		[CompilerGenerated]
		private ButtonControl _homeButton_k__BackingField; // 0x218
		private static readonly SwitchMagicOutputReport.CommandIdType[] s_HandshakeSequence; // 0x00
		private int m_HandshakeStepIndex; // 0x220
		private double m_HandshakeTimer; // 0x228
		internal const byte JitterMaskLow = 120; // Metadata: 0x00698E03
		internal const byte JitterMaskHigh = 135; // Metadata: 0x00698E04
	
		// Properties
		[InputControl(name = "capture", displayName = "Capture")]
		public ButtonControl captureButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		[InputControl(name = "home", displayName = "Home")]
		public ButtonControl homeButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
	
		// Nested types
		private struct SwitchInputOnlyReport // TypeDefIndex: 6318
		{
			// Fields
			public const int kSize = 7; // Metadata: 0x00698E05
			public byte buttons0; // 0x00
			public byte buttons1; // 0x01
			public byte hat; // 0x02
			public byte leftX; // 0x03
			public byte leftY; // 0x04
			public byte rightX; // 0x05
			public byte rightY; // 0x06
	
			// Methods
			public SwitchProControllerHIDInputState ToHIDInputReport(); // 0x0000000181DB99E0-0x0000000181DB9C80
		}
	
		private struct SwitchSimpleInputReport // TypeDefIndex: 6319
		{
			// Fields
			public const int kSize = 12; // Metadata: 0x00698E06
			public const byte ExpectedReportId = 63; // Metadata: 0x00698E07
			public byte reportId; // 0x00
			public byte buttons0; // 0x01
			public byte buttons1; // 0x02
			public byte hat; // 0x03
			public ushort leftX; // 0x04
			public ushort leftY; // 0x06
			public ushort rightX; // 0x08
			public ushort rightY; // 0x0A
	
			// Methods
			public SwitchProControllerHIDInputState ToHIDInputReport(); // 0x0000000181DBAB10-0x0000000181DBAE10
		}
	
		private struct SwitchFullInputReport // TypeDefIndex: 6320
		{
			// Fields
			public const int kSize = 25; // Metadata: 0x00698E08
			public const byte ExpectedReportId = 48; // Metadata: 0x00698E09
			public byte reportId; // 0x00
			public byte buttons0; // 0x03
			public byte buttons1; // 0x04
			public byte buttons2; // 0x05
			public byte left0; // 0x06
			public byte left1; // 0x07
			public byte left2; // 0x08
			public byte right0; // 0x09
			public byte right1; // 0x0A
			public byte right2; // 0x0B
	
			// Methods
			public SwitchProControllerHIDInputState ToHIDInputReport(); // 0x0000000181DB9680-0x0000000181DB99A0
		}
	
		private struct SwitchHIDGenericInputReport // TypeDefIndex: 6321
		{
			// Fields
			public byte reportId; // 0x00
	
			// Properties
			public static FourCC Format { get; } // 0x0000000181DB99A0-0x0000000181DB99E0 
		}
	
		internal struct SwitchMagicOutputReport // TypeDefIndex: 6322
		{
			// Fields
			public const int kSize = 49; // Metadata: 0x00698E0A
			public const byte ExpectedReplyInputReportId = 129; // Metadata: 0x00698E0B
			public byte reportType; // 0x00
			public byte commandId; // 0x01
	
			// Nested types
			internal enum ReportType // TypeDefIndex: 6323
			{
				Magic = 128
			}
	
			public enum CommandIdType // TypeDefIndex: 6324
			{
				Status = 1,
				Handshake = 2,
				Highspeed = 3,
				ForceUSB = 4
			}
		}
	
		internal struct SwitchMagicOutputHIDBluetooth : IInputDeviceCommandInfo // TypeDefIndex: 6325
		{
			// Fields
			public const int kSize = 57; // Metadata: 0x00698E12
			public InputDeviceCommand baseCommand; // 0x00
			public SwitchMagicOutputReport report; // 0x08
	
			// Properties
			public static FourCC Type { get; } // 0x0000000181DB9D40-0x0000000181DB9D80 
			public FourCC typeStatic { get; } // 0x0000000181DB9D80-0x0000000181DB9DC0 
	
			// Methods
			public static SwitchMagicOutputHIDBluetooth Create(SwitchMagicOutputReport.CommandIdType type); // 0x0000000181DB9C80-0x0000000181DB9D40
		}
	
		internal struct SwitchMagicOutputHIDUSB : IInputDeviceCommandInfo // TypeDefIndex: 6326
		{
			// Fields
			public const int kSize = 72; // Metadata: 0x00698E13
			public InputDeviceCommand baseCommand; // 0x00
			public SwitchMagicOutputReport report; // 0x08
	
			// Properties
			public static FourCC Type { get; } // 0x0000000181DB9D40-0x0000000181DB9D80 
			public FourCC typeStatic { get; } // 0x0000000181DB9D80-0x0000000181DB9DC0 
	
			// Methods
			public static SwitchMagicOutputHIDUSB Create(SwitchMagicOutputReport.CommandIdType type); // 0x0000000181DB9DC0-0x0000000181DB9E80
		}
	
		// Constructors
		public SwitchProControllerHID(); // 0x0000000181CC2A30-0x0000000181CC2A40
		static SwitchProControllerHID(); // 0x0000000181DBAA80-0x0000000181DBAB10
	
		// Methods
		protected override void OnAdded(); // 0x0000000181DBA5A0-0x0000000181DBA6B0
		private void HandshakeRestart(); // 0x0000000181DBA190-0x0000000181DBA210
		private void HandshakeTick(); // 0x0000000181DBA210-0x0000000181DBA5A0
		public void OnNextUpdate(); // 0x0000000181DBA6B0-0x0000000181DBA6C0
		public void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181DBA6C0-0x0000000181DBA850
		public bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset); // 0x00000001802E7840-0x00000001802E7850
		public bool PreProcessEvent(InputEventPtr eventPtr); // 0x0000000181DBA850-0x0000000181DBAA80
	}
}
