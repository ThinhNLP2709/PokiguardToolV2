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
	[InputControlLayout(displayName = "Oculus Touch Controller", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class OculusTouchController : XRControllerWithRumble // TypeDefIndex: 6033
	{
		// Fields
		[CompilerGenerated]
		private Vector2Control _thumbstick_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private AxisControl _trigger_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private AxisControl _grip_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _primaryButton_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _secondaryButton_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _gripPressed_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _start_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private ButtonControl _thumbstickClicked_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private ButtonControl _primaryTouched_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private ButtonControl _secondaryTouched_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private AxisControl _triggerTouched_k__BackingField; // 0x200
		[CompilerGenerated]
		private ButtonControl _triggerPressed_k__BackingField; // 0x208
		[CompilerGenerated]
		private ButtonControl _thumbstickTouched_k__BackingField; // 0x210
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x218
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x220
		[CompilerGenerated]
		private Vector3Control _deviceAcceleration_k__BackingField; // 0x228
		[CompilerGenerated]
		private Vector3Control _deviceAngularAcceleration_k__BackingField; // 0x230
	
		// Properties
		[InputControl(aliases = new string[2] {"Primary2DAxis", "Joystick" })]
		public Vector2Control thumbstick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl]
		public AxisControl trigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl]
		public AxisControl grip { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(aliases = new string[3] {"A", "X", "Alternate" })]
		public ButtonControl primaryButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl(aliases = new string[3] {"B", "Y", "Primary" })]
		public ButtonControl secondaryButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl(aliases = new string[1] {"GripButton" })]
		public ButtonControl gripPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl]
		public ButtonControl start { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl(aliases = new string[2] {"JoystickOrPadPressed", "thumbstickClick" })]
		public ButtonControl thumbstickClicked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl(aliases = new string[4] {"ATouched", "XTouched", "ATouch", "XTouch" })]
		public ButtonControl primaryTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(aliases = new string[4] {"BTouched", "YTouched", "BTouch", "YTouch" })]
		public ButtonControl secondaryTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		[InputControl(aliases = new string[2] {"indexTouch", "indexNearTouched" })]
		public AxisControl triggerTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		[InputControl(aliases = new string[2] {"indexButton", "indexTouched" })]
		public ButtonControl triggerPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28E0-0x0000000181CC28F0 0x0000000181380170-0x0000000181380190
		[InputControl(aliases = new string[2] {"JoystickOrPadTouched", "thumbstickTouch" })]
		[InputControl(name = "trackingState", layout = "Integer", aliases = new string[1] {"controllerTrackingState" })]
		[InputControl(name = "isTracked", layout = "Button", aliases = new string[1] {"ControllerIsTracked" })]
		[InputControl(name = "devicePosition", layout = "Vector3", aliases = new string[1] {"controllerPosition" })]
		[InputControl(name = "deviceRotation", layout = "Quaternion", aliases = new string[1] {"controllerRotation" })]
		public ButtonControl thumbstickTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		[InputControl(noisy = true, aliases = new string[1] {"controllerVelocity" })]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
		[InputControl(noisy = true, aliases = new string[1] {"controllerAngularVelocity" })]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28F0-0x0000000181CC2900 0x0000000181975220-0x0000000181975240
		[InputControl(noisy = true, aliases = new string[1] {"controllerAcceleration" })]
		public Vector3Control deviceAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2900-0x0000000181CC2910 0x0000000181CC2920-0x0000000181CC2940
		[InputControl(noisy = true, aliases = new string[1] {"controllerAngularAcceleration" })]
		public Vector3Control deviceAngularAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D490-0x000000018033D4A0 0x0000000180BBDE30-0x0000000180BBDE50
	
		// Constructors
		public OculusTouchController(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC2AA0-0x0000000181CC2EC0
	}
}
