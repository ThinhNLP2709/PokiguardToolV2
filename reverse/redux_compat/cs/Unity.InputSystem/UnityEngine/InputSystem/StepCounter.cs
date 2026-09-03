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
	[InputControlLayout(displayName = "Step Counter")]
	public class StepCounter : Sensor // TypeDefIndex: 6207
	{
		// Fields
		[CompilerGenerated]
		private IntegerControl _stepCounter_k__BackingField; // 0x190
		[CompilerGenerated]
		private static StepCounter _current_k__BackingField; // 0x00
	
		// Properties
		[InputControl(displayName = "Step Counter", noisy = true)]
		public IntegerControl stepCounter { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public static StepCounter current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D881A0-0x0000000181D881E0 0x0000000181D881E0-0x0000000181D88240
	
		// Constructors
		public StepCounter(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D880B0-0x0000000181D88110
		protected override void OnRemoved(); // 0x0000000181D88110-0x0000000181D881A0
		protected override void FinishSetup(); // 0x0000000181D88040-0x0000000181D880B0
	}
}
