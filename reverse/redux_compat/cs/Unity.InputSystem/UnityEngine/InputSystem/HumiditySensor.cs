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
	[InputControlLayout(displayName = "Humidity")]
	public class HumiditySensor : Sensor // TypeDefIndex: 6205
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _relativeHumidity_k__BackingField; // 0x190
		[CompilerGenerated]
		private static HumiditySensor _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Relative Humidity", noisy = true)]
		public AxisControl relativeHumidity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static HumiditySensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D70AE0-0x0000000181D70B20 0x0000000181D70B20-0x0000000181D70B80
	
		// Constructors
		public HumiditySensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D709F0-0x0000000181D70A50
		protected override void OnRemoved(); // 0x0000000181D70A50-0x0000000181D70AE0
		protected override void FinishSetup(); // 0x0000000181D70980-0x0000000181D709F0
	}
}
