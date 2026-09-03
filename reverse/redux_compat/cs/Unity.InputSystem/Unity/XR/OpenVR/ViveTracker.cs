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

namespace Unity.XR.OpenVR
{
	[InputControlLayout(displayName = "Vive Tracker")]
	public class ViveTracker : TrackedDevice // TypeDefIndex: 6029
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private Vector3Control _deviceAngularVelocity_k__BackingField; // 0x1B8
	
		// Properties
		[InputControl(noisy = true)]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(noisy = true)]
		public Vector3Control deviceAngularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
	
		// Constructors
		public ViveTracker(); // 0x0000000181CB2A40-0x0000000181CB2A50
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC9EF0-0x0000000181CC9FA0
	}
}
