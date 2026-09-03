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

namespace UnityEngine.XR.WindowsMR.Input
{
	[InputControlLayout(displayName = "Windows MR Controller", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class WMRSpatialController : XRControllerWithRumble // TypeDefIndex: 6042
	{
		// Fields
		[CompilerGenerated]
		private Vector2Control _joystick_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private Vector2Control _touchpad_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private AxisControl _grip_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _gripPressed_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _menu_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private AxisControl _trigger_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _triggerPressed_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private ButtonControl _joystickClicked_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private ButtonControl _touchpadClicked_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private ButtonControl _touchpadTouched_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x200
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x208
		[CompilerGenerated]
		private AxisControl _batteryLevel_k__BackingField; // 0x210
		[CompilerGenerated]
		private AxisControl _sourceLossRisk_k__BackingField; // 0x218
		[CompilerGenerated]
		private Vector3Control _sourceLossMitigationDirection_k__BackingField; // 0x220
		[CompilerGenerated]
		private Vector3Control _pointerPosition_k__BackingField; // 0x228
		[CompilerGenerated]
		private QuaternionControl _pointerRotation_k__BackingField; // 0x230
	
		// Properties
		[InputControl(aliases = new string[2] {"Primary2DAxis", "thumbstickaxes" })]
		public Vector2Control joystick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(aliases = new string[2] {"Secondary2DAxis", "touchpadaxes" })]
		public Vector2Control touchpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl(aliases = new string[1] {"gripaxis" })]
		public AxisControl grip { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(aliases = new string[1] {"gripbutton" })]
		public ButtonControl gripPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl(aliases = new string[2] {"Primary", "menubutton" })]
		public ButtonControl menu { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl(aliases = new string[1] {"triggeraxis" })]
		public AxisControl trigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl(aliases = new string[1] {"triggerbutton" })]
		public ButtonControl triggerPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl(aliases = new string[1] {"thumbstickpressed" })]
		public ButtonControl joystickClicked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl(aliases = new string[2] {"joystickorpadpressed", "touchpadpressed" })]
		public ButtonControl touchpadClicked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(aliases = new string[2] {"joystickorpadtouched", "touchpadtouched" })]
		public ButtonControl touchpadTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		[InputControl(noisy = true, aliases = new string[1] {"gripVelocity" })]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		[InputControl(noisy = true, aliases = new string[1] {"gripAngularVelocity" })]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28E0-0x0000000181CC28F0 0x0000000181380170-0x0000000181380190
		[InputControl(noisy = true)]
		public AxisControl batteryLevel { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		[InputControl(noisy = true)]
		public AxisControl sourceLossRisk { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
		[InputControl(noisy = true)]
		public Vector3Control sourceLossMitigationDirection { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28F0-0x0000000181CC2900 0x0000000181975220-0x0000000181975240
		[InputControl(noisy = true)]
		public Vector3Control pointerPosition { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2900-0x0000000181CC2910 0x0000000181CC2920-0x0000000181CC2940
		[InputControl(noisy = true, aliases = new string[1] {"PointerOrientation" })]
		public QuaternionControl pointerRotation { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D490-0x000000018033D4A0 0x0000000180BBDE30-0x0000000180BBDE50
	
		// Constructors
		public WMRSpatialController(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CCA2A0-0x0000000181CCA6C0
	}
}
