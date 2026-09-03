/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.XR.WindowsMR.Input
{
	[InputControlLayout(displayName = "HoloLens Hand", commonUsages = new string[2] {"LeftHand", "RightHand" }, hideInUI = true)]
	public class HololensHand : XRController // TypeDefIndex: 6041
	{
		// Fields
		[CompilerGenerated]
		private Vector3Control _deviceVelocity_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private ButtonControl _airTap_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private AxisControl _sourceLossRisk_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private Vector3Control _sourceLossMitigationDirection_k__BackingField; // 0x1C8
	
		// Properties
		[InputControl(noisy = true, aliases = new string[1] {"gripVelocity" })]
		public Vector3Control deviceVelocity { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		[InputControl(aliases = new string[1] {"triggerbutton" })]
		public ButtonControl airTap { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		[InputControl(noisy = true)]
		public AxisControl sourceLossRisk { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		[InputControl(noisy = true)]
		public Vector3Control sourceLossMitigationDirection { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
	
		// Constructors
		public HololensHand(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CB2A50-0x0000000181CB2B80
	}
}
