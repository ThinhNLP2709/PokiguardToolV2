/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Scripting;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	[Preserve]
	public class DeltaControl : Vector2Control // TypeDefIndex: 6562
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _up_k__BackingField; // 0x120
		[CompilerGenerated]
		private AxisControl _down_k__BackingField; // 0x128
		[CompilerGenerated]
		private AxisControl _left_k__BackingField; // 0x130
		[CompilerGenerated]
		private AxisControl _right_k__BackingField; // 0x138
	
		// Properties
		[InputControl(useStateFrom = "y", parameters = "clamp=1,clampMin=0,clampMax=3.402823E+38", synthetic = true, displayName = "Up")]
		[Preserve]
		public AxisControl up { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000181380050-0x0000000181380070
		[InputControl(useStateFrom = "y", parameters = "clamp=1,clampMin=-3.402823E+38,clampMax=0,invert", synthetic = true, displayName = "Down")]
		[Preserve]
		public AxisControl down { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		[InputControl(useStateFrom = "x", parameters = "clamp=1,clampMin=-3.402823E+38,clampMax=0,invert", synthetic = true, displayName = "Left")]
		[Preserve]
		public AxisControl left { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C2D460-0x0000000181C2D470 0x00000001818418A0-0x00000001818418C0
		[InputControl(useStateFrom = "x", parameters = "clamp=1,clampMin=0,clampMax=3.402823E+38", synthetic = true, displayName = "Right")]
		[Preserve]
		public AxisControl right { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
	
		// Constructors
		public DeltaControl(); // 0x0000000181CE5B60-0x0000000181CE5BD0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CE5A40-0x0000000181CE5B60
	}
}
