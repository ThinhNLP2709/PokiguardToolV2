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
	[InputControlLayout(hideInUI = true)]
	public class TouchPressControl : ButtonControl // TypeDefIndex: 6575
	{
		// Constructors
		public TouchPressControl(); // 0x0000000181CE5F00-0x0000000181CE5F10
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CF6E50-0x0000000181CF6F70
		public override unsafe float ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CF6F70-0x0000000181CF7000
		public override unsafe void WriteValueIntoState(float value, void* statePtr); // 0x0000000181CF7000-0x0000000181CF7040
	}
}
