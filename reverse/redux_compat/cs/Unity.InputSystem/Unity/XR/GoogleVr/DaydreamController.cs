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

namespace Unity.XR.GoogleVr
{
	[InputControlLayout(displayName = "Daydream Controller", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class DaydreamController : XRController // TypeDefIndex: 6039
	{
		// Fields
		[CompilerGenerated]
		private Vector2Control _touchpad_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private ButtonControl _volumeUp_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private ButtonControl _recentered_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _volumeDown_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _recentering_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _app_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _home_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private ButtonControl _touchpadClicked_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private ButtonControl _touchpadTouched_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private Vector3Control _deviceAcceleration_k__BackingField; // 0x200
	
		// Properties
		[InputControl]
		public Vector2Control touchpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl]
		public ButtonControl volumeUp { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl]
		public ButtonControl recentered { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl]
		public ButtonControl volumeDown { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl]
		public ButtonControl recentering { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl]
		public ButtonControl app { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl]
		public ButtonControl home { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl]
		public ButtonControl touchpadClicked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl]
		public ButtonControl touchpadTouched { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(noisy = true)]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		[InputControl(noisy = true)]
		public Vector3Control deviceAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
	
		// Constructors
		public DaydreamController(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CB1FC0-0x0000000181CB2280
	}
}
