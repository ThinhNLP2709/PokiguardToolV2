/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.DualShock.LowLevel;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.DualShock
{
	[InputControlLayout(stateType = typeof(DualShock3HIDInputReport), hideInUI = true, displayName = "PS3 Controller")]
	public class DualShock3GamepadHID : DualShockGamepad // TypeDefIndex: 6376
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _leftTriggerButton_k__BackingField; // 0x288
		[CompilerGenerated]
		private ButtonControl _rightTriggerButton_k__BackingField; // 0x290
		[CompilerGenerated]
		private ButtonControl _playStationButton_k__BackingField; // 0x298
	
		// Properties
		public ButtonControl leftTriggerButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D00-0x0000000181DC0D10 0x0000000181380230-0x0000000181380250
		public ButtonControl rightTriggerButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D20-0x0000000181DC0D30 0x00000001813801F0-0x0000000181380210
		public ButtonControl playStationButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181DC0D10-0x0000000181DC0D20 0x0000000181DC0D30-0x0000000181DC0D50
	
		// Constructors
		public DualShock3GamepadHID(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181DC10F0-0x0000000181DC11D0
	}
}
