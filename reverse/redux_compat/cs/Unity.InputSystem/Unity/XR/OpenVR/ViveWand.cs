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
	[InputControlLayout(displayName = "Vive Wand", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class ViveWand : XRControllerWithRumble // TypeDefIndex: 6027
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _grip_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private ButtonControl _gripPressed_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private ButtonControl _primary_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _trackpadPressed_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _trackpadTouched_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private Vector2Control _trackpad_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private AxisControl _trigger_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private ButtonControl _triggerPressed_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x1F8
	
		// Properties
		[InputControl]
		public AxisControl grip { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl]
		public ButtonControl gripPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl]
		public ButtonControl primary { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(aliases = new string[2] {"primary2DAxisClick", "joystickOrPadPressed" })]
		public ButtonControl trackpadPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl(aliases = new string[2] {"primary2DAxisTouch", "joystickOrPadTouched" })]
		public ButtonControl trackpadTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl(aliases = new string[1] {"Primary2DAxis" })]
		public Vector2Control trackpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl]
		public AxisControl trigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl]
		public ButtonControl triggerPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl(noisy = true)]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
	
		// Constructors
		public ViveWand(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC9FA0-0x0000000181CCA230
	}
}
