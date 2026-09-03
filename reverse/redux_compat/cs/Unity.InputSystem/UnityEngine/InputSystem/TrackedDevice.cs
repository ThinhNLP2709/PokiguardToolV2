/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(displayName = "Tracked Device", isGenericTypeOfDevice = true)]
	public class TrackedDevice : InputDevice // TypeDefIndex: 6211
	{
		// Fields
		[CompilerGenerated]
		private IntegerControl _trackingState_k__BackingField; // 0x190
		[CompilerGenerated]
		private ButtonControl _isTracked_k__BackingField; // 0x198
		[CompilerGenerated]
		private Vector3Control _devicePosition_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private QuaternionControl _deviceRotation_k__BackingField; // 0x1A8
	
		// Properties
		[InputControl(synthetic = true)]
		public IntegerControl trackingState { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		[InputControl(synthetic = true)]
		public ButtonControl isTracked { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		[InputControl(noisy = true, dontReset = true)]
		public Vector3Control devicePosition { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		[InputControl(noisy = true, dontReset = true)]
		public QuaternionControl deviceRotation { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
	
		// Constructors
		public TrackedDevice(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D89F40-0x0000000181D8A080
	}
}
