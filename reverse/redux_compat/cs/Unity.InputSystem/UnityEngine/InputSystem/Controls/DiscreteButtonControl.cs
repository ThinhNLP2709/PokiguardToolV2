/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class DiscreteButtonControl : ButtonControl // TypeDefIndex: 6563
	{
		// Fields
		public int minValue; // 0x148
		public int maxValue; // 0x14C
		public int wrapAtValue; // 0x150
		public int nullValue; // 0x154
		public WriteMode writeMode; // 0x158
	
		// Nested types
		public enum WriteMode // TypeDefIndex: 6564
		{
			WriteDisabled = 0,
			WriteNullAndMaxValue = 1
		}
	
		// Constructors
		public DiscreteButtonControl(); // 0x0000000181CE5F00-0x0000000181CE5F10
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CE5BE0-0x0000000181CE5D00
		public override unsafe float ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CE5D00-0x0000000181CE5DD0
		public override unsafe void WriteValueIntoState(float value, void* statePtr); // 0x0000000181CE5DD0-0x0000000181CE5F00
	}
}
