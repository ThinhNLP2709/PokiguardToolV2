/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	[InputControlLayout(isGenericTypeOfDevice = true, displayName = "XR HMD", canRunInBackground = true)]
	public class XRHMD : TrackedDevice // TypeDefIndex: 6248
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _leftEyePosition_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private QuaternionControl _leftEyeRotation_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private Vector3Control _rightEyePosition_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private QuaternionControl _rightEyeRotation_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private Vector3Control _centerEyePosition_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private QuaternionControl _centerEyeRotation_k__BackingField; // 0x1D8
	
		// Properties
		[InputControl(noisy = true)]
		public Vector3Control leftEyePosition { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(noisy = true)]
		public QuaternionControl leftEyeRotation { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl(noisy = true)]
		public Vector3Control rightEyePosition { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(noisy = true)]
		public QuaternionControl rightEyeRotation { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl(noisy = true)]
		public Vector3Control centerEyePosition { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl(noisy = true)]
		public QuaternionControl centerEyeRotation { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
	
		// Constructors
		public XRHMD(); // 0x0000000181CB2A40-0x0000000181CB2A50
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181DA5FD0-0x0000000181DA6160
	}
}
