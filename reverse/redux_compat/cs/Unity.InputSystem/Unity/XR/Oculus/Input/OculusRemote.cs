/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace Unity.XR.Oculus.Input
{
	[InputControlLayout(displayName = "Oculus Remote", hideInUI = true)]
	public class OculusRemote : InputDevice // TypeDefIndex: 6035
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _back_k__BackingField; // 0x190
		[CompilerGenerated]
		private ButtonControl _start_k__BackingField; // 0x198
		[CompilerGenerated]
		private Vector2Control _touchpad_k__BackingField; // 0x1A0
	
		// Properties
		[InputControl]
		public ButtonControl back { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		[InputControl]
		public ButtonControl start { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		[InputControl]
		public Vector2Control touchpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
	
		// Constructors
		public OculusRemote(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC2940-0x0000000181CC2A30
	}
}
