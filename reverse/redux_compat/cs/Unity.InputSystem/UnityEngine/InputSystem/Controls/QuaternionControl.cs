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
	public class QuaternionControl : InputControl<Quaternion> // TypeDefIndex: 6571
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _x_k__BackingField; // 0x120
		[CompilerGenerated]
		private AxisControl _y_k__BackingField; // 0x128
		[CompilerGenerated]
		private AxisControl _z_k__BackingField; // 0x130
		[CompilerGenerated]
		private AxisControl _w_k__BackingField; // 0x138
	
		// Properties
		[InputControl(displayName = "X")]
		public AxisControl x { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000181380050-0x0000000181380070
		[InputControl(displayName = "Y")]
		public AxisControl y { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		[InputControl(displayName = "Z")]
		public AxisControl z { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C2D460-0x0000000181C2D470 0x00000001818418A0-0x00000001818418C0
		[InputControl(displayName = "W")]
		public AxisControl w { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
	
		// Constructors
		public QuaternionControl(); // 0x0000000181CF6000-0x0000000181CF6070
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CF5C40-0x0000000181CF5D70
		public override unsafe Quaternion ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CF5D70-0x0000000181CF5EC0
		public override unsafe void WriteValueIntoState(Quaternion value, void* statePtr); // 0x0000000181CF5EC0-0x0000000181CF6000
		protected override FourCC CalculateOptimizedControlDataType(); // 0x0000000181CF5AD0-0x0000000181CF5C40
	}
}
