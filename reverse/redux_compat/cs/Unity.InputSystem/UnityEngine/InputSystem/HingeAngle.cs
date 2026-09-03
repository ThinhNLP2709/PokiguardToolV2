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
	[InputControlLayout(displayName = "Hinge Angle")]
	public class HingeAngle : Sensor // TypeDefIndex: 6208
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _angle_k__BackingField; // 0x190
		[CompilerGenerated]
		private static HingeAngle _current_k__BackingField; // 0x00
	
		// Properties
		public AxisControl angle { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static HingeAngle current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D708E0-0x0000000181D70920 0x0000000181D70920-0x0000000181D70980
	
		// Constructors
		public HingeAngle(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D707F0-0x0000000181D70850
		protected override void OnRemoved(); // 0x0000000181D70850-0x0000000181D708E0
		protected override void FinishSetup(); // 0x0000000181D70780-0x0000000181D707F0
	}
}
