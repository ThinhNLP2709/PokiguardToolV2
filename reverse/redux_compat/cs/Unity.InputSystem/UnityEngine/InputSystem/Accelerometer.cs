/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(AccelerometerState))]
	public class Accelerometer : Sensor // TypeDefIndex: 6196
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _acceleration_k__BackingField; // 0x190
		[CompilerGenerated]
		private static Accelerometer _current_k__BackingField; // 0x00
	
		// Properties
		public Vector3Control acceleration { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static Accelerometer current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D69290-0x0000000181D692D0 0x0000000181D692D0-0x0000000181D69330
	
		// Constructors
		public Accelerometer(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D691A0-0x0000000181D69200
		protected override void OnRemoved(); // 0x0000000181D69200-0x0000000181D69290
		protected override void FinishSetup(); // 0x0000000181D69130-0x0000000181D691A0
	}
}
