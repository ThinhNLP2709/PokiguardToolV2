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
	[InputControlLayout(displayName = "Oculus Headset", hideInUI = true)]
	public class OculusHMD : XRHMD // TypeDefIndex: 6032
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _userPresence_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private Vector3Control _deviceAcceleration_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private Vector3Control _deviceAngularAcceleration_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private Vector3Control _leftEyeAngularVelocity_k__BackingField; // 0x200
		[CompilerGenerated]
		private Vector3Control _leftEyeAcceleration_k__BackingField; // 0x208
		[CompilerGenerated]
		private Vector3Control _leftEyeAngularAcceleration_k__BackingField; // 0x210
		[CompilerGenerated]
		private Vector3Control _rightEyeAngularVelocity_k__BackingField; // 0x218
		[CompilerGenerated]
		private Vector3Control _rightEyeAcceleration_k__BackingField; // 0x220
		[CompilerGenerated]
		private Vector3Control _rightEyeAngularAcceleration_k__BackingField; // 0x228
		[CompilerGenerated]
		private Vector3Control _centerEyeAngularVelocity_k__BackingField; // 0x230
		[CompilerGenerated]
		private Vector3Control _centerEyeAcceleration_k__BackingField; // 0x238
		[CompilerGenerated]
		private Vector3Control _centerEyeAngularAcceleration_k__BackingField; // 0x240
	
		// Properties
		[InputControl]
		[InputControl(name = "trackingState", layout = "Integer", aliases = new string[1] {"devicetrackingstate" })]
		[InputControl(name = "isTracked", layout = "Button", aliases = new string[1] {"deviceistracked" })]
		public ButtonControl userPresence { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl(noisy = true)]
		public Vector3Control deviceAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		[InputControl(noisy = true)]
		public Vector3Control leftEyeAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		[InputControl(noisy = true)]
		public Vector3Control leftEyeAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28E0-0x0000000181CC28F0 0x0000000181380170-0x0000000181380190
		[InputControl(noisy = true)]
		public Vector3Control leftEyeAngularAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		[InputControl(noisy = true)]
		public Vector3Control rightEyeAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
		[InputControl(noisy = true)]
		public Vector3Control rightEyeAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28F0-0x0000000181CC2900 0x0000000181975220-0x0000000181975240
		[InputControl(noisy = true)]
		public Vector3Control rightEyeAngularAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2900-0x0000000181CC2910 0x0000000181CC2920-0x0000000181CC2940
		[InputControl(noisy = true)]
		public Vector3Control centerEyeAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D490-0x000000018033D4A0 0x0000000180BBDE30-0x0000000180BBDE50
		[InputControl(noisy = true)]
		public Vector3Control centerEyeAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D3D0-0x000000018033D3E0 0x000000018033E920-0x000000018033E940
		[InputControl(noisy = true)]
		public Vector3Control centerEyeAngularAcceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BBD8E0-0x0000000180BBD8F0 0x0000000180BBEA40-0x0000000180BBEA60
	
		// Constructors
		public OculusHMD(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC25C0-0x0000000181CC28E0
	}
}
