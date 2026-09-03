/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(displayName = "Pressure")]
	public class PressureSensor : Sensor // TypeDefIndex: 6203
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _atmosphericPressure_k__BackingField; // 0x190
		[CompilerGenerated]
		private static PressureSensor _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Atmospheric Pressure", noisy = true)]
		public AxisControl atmosphericPressure { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static PressureSensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D86A20-0x0000000181D86A60 0x0000000181D86A60-0x0000000181D86AC0
	
		// Constructors
		public PressureSensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D86930-0x0000000181D86990
		protected override void OnRemoved(); // 0x0000000181D86990-0x0000000181D86A20
		protected override void FinishSetup(); // 0x0000000181D868C0-0x0000000181D86930
	}
}
