/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Scripting;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	[InputControlLayout(stateType = typeof(PoseState))]
	[Preserve]
	public class PoseControl : InputControl<PoseState> // TypeDefIndex: 6247
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _isTracked_k__BackingField; // 0x178
		[CompilerGenerated]
		private IntegerControl _trackingState_k__BackingField; // 0x180
		[CompilerGenerated]
		private Vector3Control _position_k__BackingField; // 0x188
		[CompilerGenerated]
		private QuaternionControl _rotation_k__BackingField; // 0x190
		[CompilerGenerated]
		private Vector3Control _velocity_k__BackingField; // 0x198
		[CompilerGenerated]
		private Vector3Control _angularVelocity_k__BackingField; // 0x1A0
	
		// Properties
		public ButtonControl isTracked { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CF6CA0-0x0000000181CF6CB0 0x00000001813800F0-0x0000000181380110
		public IntegerControl trackingState { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C4BCD0-0x0000000181C4BCE0 0x0000000181CF6CF0-0x0000000181CF6D10
		public Vector3Control position { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D500-0x000000018033D510 0x000000018033EA90-0x000000018033EAB0
		public QuaternionControl rotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public Vector3Control velocity { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public Vector3Control angularVelocity { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
	
		// Constructors
		public PoseControl(); // 0x0000000181D9F520-0x0000000181D9F5B0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D9EF70-0x0000000181D9F130
		public override unsafe PoseState ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181D9F130-0x0000000181D9F300
		public override unsafe void WriteValueIntoState(PoseState value, void* statePtr); // 0x0000000181D9F300-0x0000000181D9F520
		protected override FourCC CalculateOptimizedControlDataType(); // 0x0000000181D9EDC0-0x0000000181D9EF70
	}
}
