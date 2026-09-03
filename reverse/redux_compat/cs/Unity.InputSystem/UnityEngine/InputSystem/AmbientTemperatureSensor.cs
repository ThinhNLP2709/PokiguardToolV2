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
	[InputControlLayout(displayName = "Ambient Temperature")]
	public class AmbientTemperatureSensor : Sensor // TypeDefIndex: 6206
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _ambientTemperature_k__BackingField; // 0x190
		[CompilerGenerated]
		private static AmbientTemperatureSensor _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Ambient Temperature", noisy = true)]
		public AxisControl ambientTemperature { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static AmbientTemperatureSensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D69490-0x0000000181D694D0 0x0000000181D694D0-0x0000000181D69530
	
		// Constructors
		public AmbientTemperatureSensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D693A0-0x0000000181D69400
		protected override void OnRemoved(); // 0x0000000181D69400-0x0000000181D69490
		protected override void FinishSetup(); // 0x0000000181D69330-0x0000000181D693A0
	}
}
