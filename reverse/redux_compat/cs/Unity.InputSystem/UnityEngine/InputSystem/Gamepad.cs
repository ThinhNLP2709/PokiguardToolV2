/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(GamepadState), isGenericTypeOfDevice = true)]
	public class Gamepad : InputDevice, IDualMotorRumble // TypeDefIndex: 6156
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _buttonWest_k__BackingField; // 0x190
		[CompilerGenerated]
		private ButtonControl _buttonNorth_k__BackingField; // 0x198
		[CompilerGenerated]
		private ButtonControl _buttonSouth_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private ButtonControl _buttonEast_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private ButtonControl _leftStickButton_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private ButtonControl _rightStickButton_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private ButtonControl _startButton_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _selectButton_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private DpadControl _dpad_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _leftShoulder_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _rightShoulder_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private StickControl _leftStick_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private StickControl _rightStick_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private ButtonControl _leftTrigger_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private ButtonControl _rightTrigger_k__BackingField; // 0x200
		[CompilerGenerated]
		private static Gamepad _current_k__BackingField; // 0x00
		private DualMotorRumble m_Rumble; // 0x208
		private static int s_GamepadCount; // 0x08
		private static Gamepad[] s_Gamepads; // 0x10
	
		// Properties
		public ButtonControl buttonWest { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public ButtonControl buttonNorth { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public ButtonControl buttonSouth { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		public ButtonControl buttonEast { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
		public ButtonControl leftStickButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		public ButtonControl rightStickButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		public ButtonControl startButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		public ButtonControl selectButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		public DpadControl dpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		public ButtonControl leftShoulder { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		public ButtonControl rightShoulder { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		public StickControl leftStick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		public StickControl rightStick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		public ButtonControl leftTrigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		public ButtonControl rightTrigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		public ButtonControl aButton { get; } // 0x0000000181CC2A50-0x0000000181CC2A60 
		public ButtonControl bButton { get; } // 0x0000000180E224F0-0x0000000180E22500 
		public ButtonControl xButton { get; } // 0x0000000181C4BDF0-0x0000000181C4BE00 
		public ButtonControl yButton { get; } // 0x0000000181CC2A40-0x0000000181CC2A50 
		public ButtonControl triangleButton { get; } // 0x0000000181CC2A40-0x0000000181CC2A50 
		public ButtonControl squareButton { get; } // 0x0000000181C4BDF0-0x0000000181C4BE00 
		public ButtonControl circleButton { get; } // 0x0000000180E224F0-0x0000000180E22500 
		public ButtonControl crossButton { get; } // 0x0000000181CC2A50-0x0000000181CC2A60 
		public ButtonControl this[GamepadButton button] { get => default; } // 0x0000000181D04400-0x0000000181D04610 
		public static Gamepad current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D04670-0x0000000181D046B0 0x0000000181D046B0-0x0000000181D04710
		public static new ReadOnlyArray<Gamepad> all { get; } // 0x0000000181D04610-0x0000000181D04670 
	
		// Constructors
		public Gamepad(); // 0x0000000181D04390-0x0000000181D04400
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D03DA0-0x0000000181D04130
		public override void MakeCurrent(); // 0x0000000181D04130-0x0000000181D04190
		protected override void OnAdded(); // 0x0000000181D04190-0x0000000181D04200
		protected override void OnRemoved(); // 0x0000000181D04200-0x0000000181D04300
		public virtual void PauseHaptics(); // 0x0000000181D04300-0x0000000181D04320
		public virtual void ResumeHaptics(); // 0x0000000181D04340-0x0000000181D04360
		public virtual void ResetHaptics(); // 0x0000000181D04320-0x0000000181D04340
		public virtual void SetMotorSpeeds(float lowFrequency, float highFrequency); // 0x0000000181D04360-0x0000000181D04390
	}
}
