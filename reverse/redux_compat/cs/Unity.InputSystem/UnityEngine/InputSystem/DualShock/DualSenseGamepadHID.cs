/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.DualShock.LowLevel;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.DualShock
{
	[InputControlLayout(stateType = typeof(DualSenseHIDInputReport), displayName = "DualSense HID")]
	public class DualSenseGamepadHID : DualShockGamepad, IEventMerger, IEventPreProcessor, IInputStateCallbackReceiver // TypeDefIndex: 6369
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _leftTriggerButton_k__BackingField; // 0x288
		[CompilerGenerated]
		private ButtonControl _rightTriggerButton_k__BackingField; // 0x290
		[CompilerGenerated]
		private ButtonControl _playStationButton_k__BackingField; // 0x298
		private float? m_LowFrequencyMotorSpeed; // 0x2A0
		private float? m_HighFrequenceyMotorSpeed; // 0x2A8
		protected Color? m_LightBarColor; // 0x2B0
		private byte outputSequenceId; // 0x2C4
		internal const byte JitterMaskLow = 120; // Metadata: 0x00698F89
		internal const byte JitterMaskHigh = 135; // Metadata: 0x00698F8A
	
		// Properties
		public ButtonControl leftTriggerButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D00-0x0000000181DC0D10 0x0000000181380230-0x0000000181380250
		public ButtonControl rightTriggerButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D20-0x0000000181DC0D30 0x00000001813801F0-0x0000000181380210
		public ButtonControl playStationButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D10-0x0000000181DC0D20 0x0000000181DC0D30-0x0000000181DC0D50
	
		// Nested types
		internal struct DualSenseHIDGenericInputReport // TypeDefIndex: 6370
		{
			// Fields
			public byte reportId; // 0x00
	
			// Properties
			public static FourCC Format { get; } // 0x0000000181DB99A0-0x0000000181DB99E0 
		}
	
		internal struct DualSenseHIDUSBInputReport // TypeDefIndex: 6371
		{
			// Fields
			public const int ExpectedReportId = 1; // Metadata: 0x00698F8B
			public byte reportId; // 0x00
			public byte leftStickX; // 0x01
			public byte leftStickY; // 0x02
			public byte rightStickX; // 0x03
			public byte rightStickY; // 0x04
			public byte leftTrigger; // 0x05
			public byte rightTrigger; // 0x06
			public byte buttons0; // 0x08
			public byte buttons1; // 0x09
			public byte buttons2; // 0x0A
	
			// Methods
			public DualSenseHIDInputReport ToHIDInputReport(); // 0x0000000181DC0FE0-0x0000000181DC1030
		}
	
		internal struct DualSenseHIDBluetoothInputReport // TypeDefIndex: 6372
		{
			// Fields
			public const int ExpectedReportId = 49; // Metadata: 0x00698F8C
			public byte reportId; // 0x00
			public byte leftStickX; // 0x02
			public byte leftStickY; // 0x03
			public byte rightStickX; // 0x04
			public byte rightStickY; // 0x05
			public byte leftTrigger; // 0x06
			public byte rightTrigger; // 0x07
			public byte buttons0; // 0x09
			public byte buttons1; // 0x0A
			public byte buttons2; // 0x0B
	
			// Methods
			public DualSenseHIDInputReport ToHIDInputReport(); // 0x0000000181DC0D50-0x0000000181DC0DA0
		}
	
		internal struct DualSenseHIDMinimalInputReport // TypeDefIndex: 6373
		{
			// Fields
			public static int ExpectedSize1; // 0x00
			public static int ExpectedSize2; // 0x04
			public byte reportId; // 0x00
			public byte leftStickX; // 0x01
			public byte leftStickY; // 0x02
			public byte rightStickX; // 0x03
			public byte rightStickY; // 0x04
			public byte buttons0; // 0x05
			public byte buttons1; // 0x06
			public byte buttons2; // 0x07
			public byte leftTrigger; // 0x08
			public byte rightTrigger; // 0x09
	
			// Constructors
			static DualSenseHIDMinimalInputReport(); // 0x0000000181DC0F90-0x0000000181DC0FE0
	
			// Methods
			public DualSenseHIDInputReport ToHIDInputReport(); // 0x0000000181DC0F40-0x0000000181DC0F90
		}
	
		// Constructors
		public DualSenseGamepadHID(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181DBFED0-0x0000000181DBFFB0
		public override void PauseHaptics(); // 0x0000000181DC0240-0x0000000181DC02D0
		public override void ResetHaptics(); // 0x0000000181DC02D0-0x0000000181DC0340
		public override void ResumeHaptics(); // 0x0000000181DC0340-0x0000000181DC03A0
		public override void SetLightBarColor(Color color); // 0x0000000181DC03A0-0x0000000181DC0420
		public override void SetMotorSpeeds(float lowFrequency, float highFrequency); // 0x0000000181DC06E0-0x0000000181DC0780
		public bool SetMotorSpeedsAndLightBarColor(float? lowFrequency, float? highFrequency, Color? color); // 0x0000000181DC0420-0x0000000181DC06E0
		private static unsafe bool MergeForward(DualSenseHIDUSBInputReport* currentState, DualSenseHIDUSBInputReport* nextState); // 0x0000000181DBFFB0-0x0000000181DBFFF0
		private static unsafe bool MergeForward(DualSenseHIDBluetoothInputReport* currentState, DualSenseHIDBluetoothInputReport* nextState); // 0x0000000181DBFFF0-0x0000000181DC0030
		private static unsafe bool MergeForward(DualSenseHIDMinimalInputReport* currentState, DualSenseHIDMinimalInputReport* nextState); // 0x0000000181DC0030-0x0000000181DC0070
		bool IEventMerger.MergeForward(InputEventPtr currentEventPtr, InputEventPtr nextEventPtr); // 0x0000000181DC0780-0x0000000181DC0A30
		bool IEventPreProcessor.PreProcessEvent(InputEventPtr eventPtr); // 0x0000000181DC0A30-0x0000000181DC0D00
		public void OnNextUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181DC0070-0x0000000181DC0240
		public bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset); // 0x00000001802E7840-0x00000001802E7850
	}
}
