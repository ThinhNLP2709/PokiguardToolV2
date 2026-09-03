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

namespace Unity.XR.Oculus.Input
{
	[InputControlLayout(displayName = "GearVR Controller", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class GearVRTrackedController : XRController // TypeDefIndex: 6037
	{
		// Fields
		[CompilerGenerated]
		private Vector2Control _touchpad_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private AxisControl _trigger_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private ButtonControl _back_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _triggerPressed_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _touchpadClicked_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _touchpadTouched_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private Vector3Control _deviceAcceleration_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private Vector3Control _deviceAngularAcceleration_k__BackingField; // 0x1F0
	
		// Properties
		[InputControl]
		public Vector2Control touchpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl]
		public AxisControl trigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl]
		public ButtonControl back { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl]
		public ButtonControl triggerPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl]
		public ButtonControl touchpadClicked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl]
		public ButtonControl touchpadTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl(noisy = true)]
		public Vector3Control deviceAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
	
		// Constructors
		public GearVRTrackedController(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CB25F0-0x0000000181CB2850
	}
}
