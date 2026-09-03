/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	[InputControlLayout(commonUsages = new string[2] {"LeftHand", "RightHand" }, isGenericTypeOfDevice = true, displayName = "XR Controller")]
	public class XRController : TrackedDevice // TypeDefIndex: 6249
	{
		// Properties
		public static XRController leftHand { get; } // 0x0000000181DA5E40-0x0000000181DA5EE0 
		public static XRController rightHand { get; } // 0x0000000181DA5EE0-0x0000000181DA5F80 
	
		// Constructors
		public XRController(); // 0x0000000181CB2A40-0x0000000181CB2A50
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181DA5D00-0x0000000181DA5E40
	}
}
