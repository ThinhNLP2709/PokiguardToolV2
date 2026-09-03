/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class IntegerControl : InputControl<int> // TypeDefIndex: 6569
	{
		// Constructors
		public IntegerControl(); // 0x0000000181CF0AF0-0x0000000181CF0B60
	
		// Methods
		public override unsafe int ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CF09B0-0x0000000181CF0A50
		public override unsafe void WriteValueIntoState(int value, void* statePtr); // 0x0000000181CF0A50-0x0000000181CF0AF0
		protected override FourCC CalculateOptimizedControlDataType(); // 0x0000000181CF0940-0x0000000181CF09B0
	}
}
