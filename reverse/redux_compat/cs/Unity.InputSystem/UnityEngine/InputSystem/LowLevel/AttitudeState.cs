/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal struct AttitudeState : IInputStateTypeInfo // TypeDefIndex: 6442
	{
		// Fields
		[InputControl(displayName = "Attitude", processors = "CompensateRotation", noisy = true)]
		public Quaternion attitude; // 0x00
	
		// Properties
		public static FourCC kFormat { get; } // 0x0000000181DBF060-0x0000000181DBF0A0 
		public FourCC format { get; } // 0x0000000181DBF020-0x0000000181DBF060 
	}
}
