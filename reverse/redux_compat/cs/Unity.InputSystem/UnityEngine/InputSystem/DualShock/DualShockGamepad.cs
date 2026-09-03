/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.DualShock
{
	[InputControlLayout(displayName = "PlayStation Controller")]
	public class DualShockGamepad : Gamepad, IDualShockHaptics // TypeDefIndex: 6368
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _touchpadButton_k__BackingField; // 0x210
		[CompilerGenerated]
		private ButtonControl _optionsButton_k__BackingField; // 0x218
		[CompilerGenerated]
		private ButtonControl _shareButton_k__BackingField; // 0x220
		[CompilerGenerated]
		private ButtonControl _L1_k__BackingField; // 0x228
		[CompilerGenerated]
		private ButtonControl _R1_k__BackingField; // 0x230
		[CompilerGenerated]
		private ButtonControl _L2_k__BackingField; // 0x238
		[CompilerGenerated]
		private ButtonControl _R2_k__BackingField; // 0x240
		[CompilerGenerated]
		private ButtonControl _L3_k__BackingField; // 0x248
		[CompilerGenerated]
		private ButtonControl _R3_k__BackingField; // 0x250
		[CompilerGenerated]
		private static DualShockGamepad _current_k__BackingField; // 0x00
		[CompilerGenerated]
		private HID.HIDDeviceDescriptor _hidDescriptor_k__BackingField; // 0x258
	
		// Properties
		[InputControl(name = "buttonWest", displayName = "Square", shortDisplayName = "Square")]
		[InputControl(name = "buttonNorth", displayName = "Triangle", shortDisplayName = "Triangle")]
		[InputControl(name = "buttonEast", displayName = "Circle", shortDisplayName = "Circle")]
		[InputControl(name = "buttonSouth", displayName = "Cross", shortDisplayName = "Cross")]
		[InputControl]
		public ButtonControl touchpadButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		[InputControl(name = "start", displayName = "Options")]
		public ButtonControl optionsButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
		[InputControl(name = "select", displayName = "Share")]
		public ButtonControl shareButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28F0-0x0000000181CC2900 0x0000000181975220-0x0000000181975240
		[InputControl(name = "leftShoulder", displayName = "L1", shortDisplayName = "L1")]
		public ButtonControl L1 { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2900-0x0000000181CC2910 0x0000000181CC2920-0x0000000181CC2940
		[InputControl(name = "rightShoulder", displayName = "R1", shortDisplayName = "R1")]
		public ButtonControl R1 { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D490-0x000000018033D4A0 0x0000000180BBDE30-0x0000000180BBDE50
		[InputControl(name = "leftTrigger", displayName = "L2", shortDisplayName = "L2")]
		public ButtonControl L2 { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D3D0-0x000000018033D3E0 0x000000018033E920-0x000000018033E940
		[InputControl(name = "rightTrigger", displayName = "R2", shortDisplayName = "R2")]
		public ButtonControl R2 { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BBD8E0-0x0000000180BBD8F0 0x0000000180BBEA40-0x0000000180BBEA60
		[InputControl(name = "leftStickPress", displayName = "L3", shortDisplayName = "L3")]
		public ButtonControl L3 { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BBD670-0x0000000180BBD680 0x0000000180BBDDE0-0x0000000180BBDE00
		[InputControl(name = "rightStickPress", displayName = "R3", shortDisplayName = "R3")]
		public ButtonControl R3 { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D3E0-0x000000018033D3F0 0x000000018033E940-0x000000018033E960
		public static new DualShockGamepad current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181DC24F0-0x0000000181DC2530 0x0000000181DC2560-0x0000000181DC25C0
		internal HID.HIDDeviceDescriptor hidDescriptor { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181DC2530-0x0000000181DC2560 0x0000000181DC25C0-0x0000000181DC25F0
	
		// Constructors
		public DualShockGamepad(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181DC2400-0x0000000181DC2460
		protected override void OnRemoved(); // 0x0000000181DC2460-0x0000000181DC24F0
		protected override void FinishSetup(); // 0x0000000181DC2240-0x0000000181DC2400
		public virtual void SetLightBarColor(Color color); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
