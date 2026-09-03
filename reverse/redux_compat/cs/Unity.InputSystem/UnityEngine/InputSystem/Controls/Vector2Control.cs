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
	public class Vector2Control : InputControl<Vector2> // TypeDefIndex: 6576
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _x_k__BackingField; // 0x110
		[CompilerGenerated]
		private AxisControl _y_k__BackingField; // 0x118
	
		// Properties
		[InputControl(offset = 0, displayName = "X")]
		public AxisControl x { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170B050-0x000000018170B060 0x000000018170B160-0x000000018170B180
		[InputControl(offset = 4, displayName = "Y")]
		public AxisControl y { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018171E0D0-0x000000018171E0E0 0x0000000180504EA0-0x0000000180504EC0
	
		// Constructors
		public Vector2Control(); // 0x0000000181CE5B60-0x0000000181CE5BD0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CF7830-0x0000000181CF78F0
		public override unsafe Vector2 ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CF78F0-0x0000000181CF79C0
		public override unsafe void WriteValueIntoState(Vector2 value, void* statePtr); // 0x0000000181CF79C0-0x0000000181CF7AA0
		public override unsafe float EvaluateMagnitude(void* statePtr); // 0x0000000181CF7750-0x0000000181CF7830
		protected override FourCC CalculateOptimizedControlDataType(); // 0x0000000181CF7690-0x0000000181CF7750
	}
}
