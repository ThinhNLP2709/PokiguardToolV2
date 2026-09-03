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
	[InputControlLayout(displayName = "Magnetic Field")]
	public class MagneticFieldSensor : Sensor // TypeDefIndex: 6201
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _magneticField_k__BackingField; // 0x190
		[CompilerGenerated]
		private static MagneticFieldSensor _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Magnetic Field", noisy = true)]
		public Vector3Control magneticField { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static MagneticFieldSensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D84610-0x0000000181D84650 0x0000000181D84650-0x0000000181D846B0
	
		// Constructors
		public MagneticFieldSensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D84520-0x0000000181D84580
		protected override void OnRemoved(); // 0x0000000181D84580-0x0000000181D84610
		protected override void FinishSetup(); // 0x0000000181D844B0-0x0000000181D84520
	}
}
