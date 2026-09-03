/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace Unity.XR.OpenVR
{
	[InputControlLayout(displayName = "Windows MR Controller (OpenVR)", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class OpenVRControllerWMR : XRController // TypeDefIndex: 6026
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private ButtonControl _touchpadClick_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _touchpadTouch_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _gripPressed_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _triggerPressed_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _menu_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private AxisControl _trigger_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private AxisControl _grip_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private Vector2Control _touchpad_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private Vector2Control _joystick_k__BackingField; // 0x200
	
		// Properties
		[InputControl(noisy = true)]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl(aliases = new string[2] {"primary2DAxisClick", "joystickOrPadPressed" })]
		public ButtonControl touchpadClick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(aliases = new string[2] {"primary2DAxisTouch", "joystickOrPadTouched" })]
		public ButtonControl touchpadTouch { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl]
		public ButtonControl gripPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl]
		public ButtonControl triggerPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl(aliases = new string[1] {"primary" })]
		public ButtonControl menu { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl]
		public AxisControl trigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl]
		public AxisControl grip { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(aliases = new string[1] {"secondary2DAxis" })]
		public Vector2Control touchpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		[InputControl(aliases = new string[1] {"primary2DAxis" })]
		public Vector2Control joystick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
	
		// Constructors
		public OpenVRControllerWMR(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC2F70-0x0000000181CC3240
	}
}
