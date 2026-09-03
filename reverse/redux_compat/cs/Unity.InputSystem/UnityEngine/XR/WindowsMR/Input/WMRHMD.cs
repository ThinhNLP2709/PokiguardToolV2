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
	[InputControlLayout(displayName = "Windows MR Headset", hideInUI = true)]
	public class WMRHMD : XRHMD // TypeDefIndex: 6040
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _userPresence_k__BackingField; // 0x1E0
	
		// Properties
		[InputControl]
		[InputControl(name = "devicePosition", layout = "Vector3", aliases = new string[1] {"HeadPosition" })]
		[InputControl(name = "deviceRotation", layout = "Quaternion", aliases = new string[1] {"HeadRotation" })]
		public ButtonControl userPresence { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
	
		// Constructors
		public WMRHMD(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CCA230-0x0000000181CCA2A0
	}
}
