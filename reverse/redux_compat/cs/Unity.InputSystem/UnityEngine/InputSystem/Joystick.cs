/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(JoystickState), isGenericTypeOfDevice = true)]
	public class Joystick : InputDevice // TypeDefIndex: 6161
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _trigger_k__BackingField; // 0x190
		[CompilerGenerated]
		private StickControl _stick_k__BackingField; // 0x198
		[CompilerGenerated]
		private AxisControl _twist_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private Vector2Control _hatswitch_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private static Joystick _current_k__BackingField; // 0x00
		private static int s_JoystickCount; // 0x08
		private static Joystick[] s_Joysticks; // 0x10
	
		// Properties
		public ButtonControl trigger { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public StickControl stick { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public AxisControl twist { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		public Vector2Control hatswitch { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
		public static Joystick current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D81430-0x0000000181D81470 0x0000000181D81470-0x0000000181D814D0
		public static new ReadOnlyArray<Joystick> all { get; } // 0x0000000181D813D0-0x0000000181D81430 
	
		// Constructors
		public Joystick(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181D810C0-0x0000000181D81200
		public override void MakeCurrent(); // 0x0000000181D81200-0x0000000181D81260
		protected override void OnAdded(); // 0x0000000181D81260-0x0000000181D812D0
		protected override void OnRemoved(); // 0x0000000181D812D0-0x0000000181D813D0
	}
}
