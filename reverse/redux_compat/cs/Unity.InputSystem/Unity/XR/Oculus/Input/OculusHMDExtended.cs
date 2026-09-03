/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace Unity.XR.Oculus.Input
{
	[InputControlLayout(displayName = "Oculus Headset (w/ on-headset controls)", hideInUI = true)]
	public class OculusHMDExtended : OculusHMD // TypeDefIndex: 6036
	{
		// Fields
		[CompilerGenerated]
		private ButtonControl _back_k__BackingField; // 0x248
		[CompilerGenerated]
		private Vector2Control _touchpad_k__BackingField; // 0x250
	
		// Properties
		[InputControl]
		public ButtonControl back { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180BBD670-0x0000000180BBD680 0x0000000180BBDDE0-0x0000000180BBDE00
		[InputControl]
		public Vector2Control touchpad { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D3E0-0x000000018033D3F0 0x000000018033E940-0x000000018033E960
	
		// Constructors
		public OculusHMDExtended(); // 0x0000000181CB2280-0x0000000181CB2290
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CC2510-0x0000000181CC25C0
	}
}
