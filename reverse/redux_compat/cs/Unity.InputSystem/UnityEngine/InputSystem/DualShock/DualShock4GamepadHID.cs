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
	[InputControlLayout(stateType = typeof(DualShock4HIDInputReport), hideInUI = true, isNoisy = true)]
	public class DualShock4GamepadHID : DualShockGamepad, IEventPreProcessor, IInputStateCallbackReceiver // TypeDefIndex: 6374
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
		private Color? m_LightBarColor; // 0x2B0
		internal const byte JitterMaskLow = 120; // Metadata: 0x00698F8D
		internal const byte JitterMaskHigh = 135; // Metadata: 0x00698F8E
	
		// Properties
		public ButtonControl leftTriggerButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D00-0x0000000181DC0D10 0x0000000181380230-0x0000000181380250
		public ButtonControl rightTriggerButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D20-0x0000000181DC0D30 0x00000001813801F0-0x0000000181380210
		public ButtonControl playStationButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D10-0x0000000181DC0D20 0x0000000181DC0D30-0x0000000181DC0D50
	
		// Nested types
		internal struct DualShock4HIDGenericInputReport // TypeDefIndex: 6375
		{
			// Fields
			public byte leftStickX; // 0x00
			public byte leftStickY; // 0x01
			public byte rightStickX; // 0x02
			public byte rightStickY; // 0x03
			public byte buttons0; // 0x04
			public byte buttons1; // 0x05
			public byte buttons2; // 0x06
			public byte leftTrigger; // 0x07
			public byte rightTrigger; // 0x08
	
			// Properties
			public static FourCC Format { get; } // 0x0000000181DB99A0-0x0000000181DB99E0 
	
			// Methods
			public DualShock4HIDInputReport ToHIDInputReport(); // 0x0000000181DC2130-0x0000000181DC2180
		}
	
		// Constructors
		public DualShock4GamepadHID(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181DC1210-0x0000000181DC12F0
		public override void PauseHaptics(); // 0x0000000181DC14C0-0x0000000181DC15F0
		public override void ResetHaptics(); // 0x0000000181DC15F0-0x0000000181DC1740
		public override void ResumeHaptics(); // 0x0000000181DC1740-0x0000000181DC1960
		public override void SetLightBarColor(Color color); // 0x0000000181DC1960-0x0000000181DC1B10
		public override void SetMotorSpeeds(float lowFrequency, float highFrequency); // 0x0000000181DC1D70-0x0000000181DC1F10
		public bool SetMotorSpeedsAndLightBarColor(float lowFrequency, float highFrequency, Color color); // 0x0000000181DC1B10-0x0000000181DC1D70
		bool IEventPreProcessor.PreProcessEvent(InputEventPtr eventPtr); // 0x0000000181DC1F10-0x0000000181DC2130
		public void OnNextUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181DC12F0-0x0000000181DC14C0
		public bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset); // 0x00000001802E7840-0x00000001802E7850
	}
}
