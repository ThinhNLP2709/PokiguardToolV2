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
	[InputControlLayout(displayName = "OpenVR Headset", hideInUI = true)]
	public class OpenVRHMD : XRHMD // TypeDefIndex: 6025
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private Vector3Control _leftEyeVelocity_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private Vector3Control _leftEyeAngularVelocity_k__BackingField; // 0x1F8
		[CompilerGenerated]
		private Vector3Control _rightEyeVelocity_k__BackingField; // 0x200
		[CompilerGenerated]
		private Vector3Control _rightEyeAngularVelocity_k__BackingField; // 0x208
		[CompilerGenerated]
		private Vector3Control _centerEyeVelocity_k__BackingField; // 0x210
		[CompilerGenerated]
		private Vector3Control _centerEyeAngularVelocity_k__BackingField; // 0x218
	
		// Properties
		[InputControl(noisy = true)]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		[InputControl(noisy = true)]
		public Vector3Control leftEyeVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		[InputControl(noisy = true)]
		public Vector3Control leftEyeAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22A0-0x0000000181CB22B0 0x0000000181CB2310-0x0000000181CB2330
		[InputControl(noisy = true)]
		public Vector3Control rightEyeVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D670-0x000000018033D680 0x000000018033EC50-0x000000018033EC70
		[InputControl(noisy = true)]
		public Vector3Control rightEyeAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC28E0-0x0000000181CC28F0 0x0000000181380170-0x0000000181380190
		[InputControl(noisy = true)]
		public Vector3Control centerEyeVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BB3F80-0x0000000180BB3F90 0x0000000181380190-0x00000001813801B0
		[InputControl(noisy = true)]
		public Vector3Control centerEyeAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2910-0x0000000181CC2920 0x00000001813801D0-0x00000001813801F0
	
		// Constructors
		public OpenVRHMD(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC3240-0x0000000181CC3440
	}
}
