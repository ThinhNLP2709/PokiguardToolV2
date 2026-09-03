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
	[InputControlLayout(stateType = typeof(GyroscopeState))]
	public class Gyroscope : Sensor // TypeDefIndex: 6197
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _angularVelocity_k__BackingField; // 0x190
		[CompilerGenerated]
		private static Gyroscope _current_k__BackingField; // 0x00
	
		// Properties
		public Vector3Control angularVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static Gyroscope current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D706E0-0x0000000181D70720 0x0000000181D70720-0x0000000181D70780
	
		// Constructors
		public Gyroscope(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D705F0-0x0000000181D70650
		protected override void OnRemoved(); // 0x0000000181D70650-0x0000000181D706E0
		protected override void FinishSetup(); // 0x0000000181D70580-0x0000000181D705F0
	}
}
