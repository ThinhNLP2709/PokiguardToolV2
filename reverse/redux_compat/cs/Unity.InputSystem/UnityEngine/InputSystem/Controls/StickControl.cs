/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class StickControl : Vector2Control // TypeDefIndex: 6572
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _up_k__BackingField; // 0x120
		[CompilerGenerated]
		private ButtonControl _down_k__BackingField; // 0x128
		[CompilerGenerated]
		private ButtonControl _left_k__BackingField; // 0x130
		[CompilerGenerated]
		private ButtonControl _right_k__BackingField; // 0x138
	
		// Properties
		[InputControl(useStateFrom = "y", processors = "axisDeadzone", parameters = "clamp=2,clampMin=0,clampMax=1", synthetic = true, displayName = "Up")]
		[InputControl(name = "x", minValue = -1f, maxValue = 1f, layout = "Axis", processors = "axisDeadzone")]
		[InputControl(name = "y", minValue = -1f, maxValue = 1f, layout = "Axis", processors = "axisDeadzone")]
		public ButtonControl up { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000181380050-0x0000000181380070
		[InputControl(useStateFrom = "y", processors = "axisDeadzone", parameters = "clamp=2,clampMin=-1,clampMax=0,invert", synthetic = true, displayName = "Down")]
		public ButtonControl down { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		[InputControl(useStateFrom = "x", processors = "axisDeadzone", parameters = "clamp=2,clampMin=-1,clampMax=0,invert", synthetic = true, displayName = "Left")]
		public ButtonControl left { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C2D460-0x0000000181C2D470 0x00000001818418A0-0x00000001818418C0
		[InputControl(useStateFrom = "x", processors = "axisDeadzone", parameters = "clamp=2,clampMin=0,clampMax=1", synthetic = true, displayName = "Right")]
		public ButtonControl right { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
	
		// Constructors
		public StickControl(); // 0x0000000181CE5B60-0x0000000181CE5BD0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CF63C0-0x0000000181CF64E0
	}
}
