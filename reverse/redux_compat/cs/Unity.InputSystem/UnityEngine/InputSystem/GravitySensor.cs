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
	[InputControlLayout(stateType = typeof(GravityState), displayName = "Gravity")]
	public class GravitySensor : Sensor // TypeDefIndex: 6198
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _gravity_k__BackingField; // 0x190
		[CompilerGenerated]
		private static GravitySensor _current_k__BackingField; // 0x00
	
		// Properties
		public Vector3Control gravity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static GravitySensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D704E0-0x0000000181D70520 0x0000000181D70520-0x0000000181D70580
	
		// Constructors
		public GravitySensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D70380-0x0000000181D703F0
		public override void MakeCurrent(); // 0x0000000181D703F0-0x0000000181D70450
		protected override void OnRemoved(); // 0x0000000181D70450-0x0000000181D704E0
	}
}
