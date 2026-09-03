/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class DpadControl : Vector2Control // TypeDefIndex: 6566
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
		[InputControl(name = "x", layout = "DpadAxis", useStateFrom = "right", synthetic = true)]
		[InputControl(name = "y", layout = "DpadAxis", useStateFrom = "up", synthetic = true)]
		[InputControl(bit = 0, displayName = "Up")]
		public ButtonControl up { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000181380050-0x0000000181380070
		[InputControl(bit = 1, displayName = "Down")]
		public ButtonControl down { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		[InputControl(bit = 2, displayName = "Left")]
		public ButtonControl left { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C2D460-0x0000000181C2D470 0x00000001818418A0-0x00000001818418C0
		[InputControl(bit = 3, displayName = "Right")]
		public ButtonControl right { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
	
		// Nested types
		[InputControlLayout(hideInUI = true)]
		public class DpadAxisControl : AxisControl // TypeDefIndex: 6567
		{
			// Fields
			[CompilerGenerated]
			private int _component_k__BackingField; // 0x130
	
			// Properties
			public int component { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE61E0-0x0000000181CE61F0 0x0000000181CE61F0-0x0000000181CE6200
	
			// Constructors
			public DpadAxisControl(); // 0x0000000181CE4B10-0x0000000181CE4B80
	
			// Methods
			protected override void FinishSetup(); // 0x0000000181CE6050-0x0000000181CE60D0
			public override unsafe float ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CE60D0-0x0000000181CE61E0
		}
	
		internal enum ButtonBits // TypeDefIndex: 6568
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3
		}
	
		// Constructors
		public DpadControl(); // 0x0000000181CE6880-0x0000000181CE6930
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CE6200-0x0000000181CE6320
		public override unsafe Vector2 ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CE63C0-0x0000000181CE66A0
		public override unsafe void WriteValueIntoState(Vector2 value, void* statePtr); // 0x0000000181CE66A0-0x0000000181CE6880
		public static Vector2 MakeDpadVector(bool up, bool down, bool left, bool right, bool normalize = true /* Metadata: 0x00699186 */); // 0x0000000181CE6340-0x0000000181CE63C0
		public static Vector2 MakeDpadVector(float up, float down, float left, float right); // 0x0000000181CE6320-0x0000000181CE6340
	}
}
