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
	internal struct AccelerometerState : IInputStateTypeInfo // TypeDefIndex: 6439
	{
		// Fields
		[InputControl(displayName = "Acceleration", processors = "CompensateDirection", noisy = true)]
		public Vector3 acceleration; // 0x00
	
		// Properties
		public static FourCC kFormat { get; } // 0x0000000181DBEBF0-0x0000000181DBEC30 
		public FourCC format { get; } // 0x0000000181DBEBB0-0x0000000181DBEBF0 
	}
}
