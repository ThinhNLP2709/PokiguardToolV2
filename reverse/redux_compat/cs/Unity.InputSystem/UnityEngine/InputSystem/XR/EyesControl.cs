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
	public class EyesControl : InputControl<Eyes> // TypeDefIndex: 6265
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _leftEyePosition_k__BackingField; // 0x198
		[CompilerGenerated]
		private QuaternionControl _leftEyeRotation_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private Vector3Control _rightEyePosition_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private QuaternionControl _rightEyeRotation_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private Vector3Control _fixationPoint_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private AxisControl _leftEyeOpenAmount_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private AxisControl _rightEyeOpenAmount_k__BackingField; // 0x1C8
	
		// Properties
		[InputControl(offset = 0, displayName = "LeftEyePosition")]
		public Vector3Control leftEyePosition { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		[InputControl(offset = 12, displayName = "LeftEyeRotation")]
		public QuaternionControl leftEyeRotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		[InputControl(offset = 28, displayName = "RightEyePosition")]
		public Vector3Control rightEyePosition { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
		[InputControl(offset = 40, displayName = "RightEyeRotation")]
		public QuaternionControl rightEyeRotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(offset = 56, displayName = "FixationPoint")]
		public Vector3Control fixationPoint { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl(offset = 68, displayName = "LeftEyeOpenAmount")]
		public AxisControl leftEyeOpenAmount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(offset = 72, displayName = "RightEyeOpenAmount")]
		public AxisControl rightEyeOpenAmount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
	
		// Constructors
		public EyesControl(); // 0x0000000181D8A7B0-0x0000000181D8A7C0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D8B960-0x0000000181D8BB50
		public override unsafe Eyes ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181D8BB50-0x0000000181D8BCB0
		public override unsafe void WriteValueIntoState(Eyes value, void* statePtr); // 0x0000000181D8BCB0-0x0000000181D8BE50
	}
}
