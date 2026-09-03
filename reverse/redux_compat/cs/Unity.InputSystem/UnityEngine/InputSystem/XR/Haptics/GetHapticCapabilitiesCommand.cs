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
	public struct GetHapticCapabilitiesCommand : IInputDeviceCommandInfo // TypeDefIndex: 6271
	{
		// Fields
		private const int kSize = 28; // Metadata: 0x00698DAE
		private InputDeviceCommand baseCommand; // 0x00
		public uint numChannels; // 0x08
		public bool supportsImpulse; // 0x0C
		public bool supportsBuffer; // 0x0D
		public uint frequencyHz; // 0x10
		public uint maxBufferSize; // 0x14
		public uint optimalBufferSize; // 0x18
	
		// Properties
		private static FourCC Type { get; } // 0x0000000181D8C0B0-0x0000000181D8C0F0 
		public FourCC typeStatic { get; } // 0x0000000181D8C120-0x0000000181D8C160 
		public HapticCapabilities capabilities { get; } // 0x0000000181D8C0F0-0x0000000181D8C120 
	
		// Methods
		public static GetHapticCapabilitiesCommand Create(); // 0x0000000181D8C030-0x0000000181D8C0B0
	}
}
