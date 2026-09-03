/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class Vector3Control : InputControl<Vector3> // TypeDefIndex: 6577
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _x_k__BackingField; // 0x118
		[CompilerGenerated]
		private AxisControl _y_k__BackingField; // 0x120
		[CompilerGenerated]
		private AxisControl _z_k__BackingField; // 0x128
	
		// Properties
		[InputControl(offset = 0, displayName = "X")]
		public AxisControl x { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018171E0D0-0x000000018171E0E0 0x0000000180504EA0-0x0000000180504EC0
		[InputControl(offset = 4, displayName = "Y")]
		public AxisControl y { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000181380050-0x0000000181380070
		[InputControl(offset = 8, displayName = "Z")]
		public AxisControl z { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
	
		// Constructors
		public Vector3Control(); // 0x0000000181CF8000-0x0000000181CF8070
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CF7CF0-0x0000000181CF7DE0
		public override unsafe Vector3 ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CF7DE0-0x0000000181CF7EF0
		public override unsafe void WriteValueIntoState(Vector3 value, void* statePtr); // 0x0000000181CF7EF0-0x0000000181CF8000
		public override unsafe float EvaluateMagnitude(void* statePtr); // 0x0000000181CF7C00-0x0000000181CF7CF0
		protected override FourCC CalculateOptimizedControlDataType(); // 0x0000000181CF7B00-0x0000000181CF7C00
	}
}
