/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR.Haptics
{
	public struct SendHapticImpulseCommand : IInputDeviceCommandInfo // TypeDefIndex: 6274
	{
		// Fields
		private const int kSize = 20; // Metadata: 0x00698DB3
		private InputDeviceCommand baseCommand; // 0x00
		private int channel; // 0x08
		private float amplitude; // 0x0C
		private float duration; // 0x10
	
		// Properties
		private static FourCC Type { get; } // 0x0000000181D9F9C0-0x0000000181D9FA00 
		public FourCC typeStatic { get; } // 0x0000000181D9FA00-0x0000000181D9FA40 
	
		// Methods
		public static SendHapticImpulseCommand Create(int motorChannel, float motorAmplitude, float motorDuration); // 0x0000000181D9F910-0x0000000181D9F9C0
	}
}
