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
	[InputControlLayout(displayName = "Proximity")]
	public class ProximitySensor : Sensor // TypeDefIndex: 6204
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _distance_k__BackingField; // 0x190
		[CompilerGenerated]
		private static ProximitySensor _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Distance", noisy = true)]
		public AxisControl distance { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static ProximitySensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D86C20-0x0000000181D86C60 0x0000000181D86C60-0x0000000181D86CC0
	
		// Constructors
		public ProximitySensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D86B30-0x0000000181D86B90
		protected override void OnRemoved(); // 0x0000000181D86B90-0x0000000181D86C20
		protected override void FinishSetup(); // 0x0000000181D86AC0-0x0000000181D86B30
	}
}
