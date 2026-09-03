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

namespace Unity.XR.Oculus.Input
{
	public class OculusTrackingReference : TrackedDevice // TypeDefIndex: 6034
	{
		// Fields
		[CompilerGenerated]
		private IntegerControl _trackingState_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private ButtonControl _isTracked_k__BackingField; // 0x1B8
	
		// Properties
		[InputControl(aliases = new string[1] {"trackingReferenceTrackingState" })]
		public new IntegerControl trackingState { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(aliases = new string[1] {"trackingReferenceIsTracked" })]
		public new ButtonControl isTracked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
	
		// Constructors
		public OculusTrackingReference(); // 0x0000000181CB2A40-0x0000000181CB2A50
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC2EC0-0x0000000181CC2F70
	}
}
