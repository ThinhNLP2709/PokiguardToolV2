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
	public class BoneControl : InputControl<Bone> // TypeDefIndex: 6264
	{
		// Fields
		[CompilerGenerated]
		private IntegerControl _parentBoneIndex_k__BackingField; // 0x140
		[CompilerGenerated]
		private Vector3Control _position_k__BackingField; // 0x148
		[CompilerGenerated]
		private QuaternionControl _rotation_k__BackingField; // 0x150
	
		// Properties
		[InputControl(offset = 0, displayName = "parentBoneIndex")]
		public IntegerControl parentBoneIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C0F740-0x0000000181C0F750 0x0000000181380090-0x00000001813800B0
		[InputControl(offset = 4, displayName = "Position")]
		public Vector3Control position { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D220-0x000000018033D230 0x000000018033E800-0x000000018033E820
		[InputControl(offset = 16, displayName = "Rotation")]
		public QuaternionControl rotation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 0x0000000181D8A7C0-0x0000000181D8A7E0
	
		// Constructors
		public BoneControl(); // 0x0000000181D8A7B0-0x0000000181D8A7C0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D8A530-0x0000000181D8A640
		public override unsafe Bone ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181D8A640-0x0000000181D8A6F0
		public override unsafe void WriteValueIntoState(Bone value, void* statePtr); // 0x0000000181D8A6F0-0x0000000181D8A7B0
	}
}
