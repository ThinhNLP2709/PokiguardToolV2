/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace Unity.XR.OpenVR
{
	[InputControlLayout(displayName = "Handed Vive Tracker", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class HandedViveTracker : ViveTracker // TypeDefIndex: 6030
	{
		// Fields
		[CompilerGenerated]
		private AxisControl _grip_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _gripPressed_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _primary_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _trackpadPressed_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _triggerPressed_k__BackingField; // 0x1E0
	
		// Properties
		[InputControl]
		public AxisControl grip { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl]
		public ButtonControl gripPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		[InputControl]
		public ButtonControl primary { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		[InputControl(aliases = new string[1] {"JoystickOrPadPressed" })]
		public ButtonControl trackpadPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		[InputControl]
		public ButtonControl triggerPressed { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
	
		// Constructors
		public HandedViveTracker(); // 0x0000000181CB2A40-0x0000000181CB2A50
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CB2850-0x0000000181CB2A40
	}
}
