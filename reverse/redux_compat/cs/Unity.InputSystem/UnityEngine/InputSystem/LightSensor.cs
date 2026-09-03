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
	[InputControlLayout(displayName = "Light")]
	public class LightSensor : Sensor // TypeDefIndex: 6202
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _lightLevel_k__BackingField; // 0x190
		[CompilerGenerated]
		private static LightSensor _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Light Level", noisy = true)]
		public AxisControl lightLevel { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static LightSensor current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D84210-0x0000000181D84250 0x0000000181D84250-0x0000000181D842B0
	
		// Constructors
		public LightSensor(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D84120-0x0000000181D84180
		protected override void OnRemoved(); // 0x0000000181D84180-0x0000000181D84210
		protected override void FinishSetup(); // 0x0000000181D840B0-0x0000000181D84120
	}
}
