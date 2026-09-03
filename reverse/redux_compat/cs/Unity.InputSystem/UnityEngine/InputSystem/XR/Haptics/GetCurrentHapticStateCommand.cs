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
	public struct GetCurrentHapticStateCommand : IInputDeviceCommandInfo // TypeDefIndex: 6269
	{
		// Fields
		private const int kSize = 16; // Metadata: 0x00698DAD
		private InputDeviceCommand baseCommand; // 0x00
		public uint samplesQueued; // 0x08
		public uint samplesAvailable; // 0x0C
	
		// Properties
		private static FourCC Type { get; } // 0x0000000181D8BF90-0x0000000181D8BFD0 
		public FourCC typeStatic { get; } // 0x0000000181D8BFF0-0x0000000181D8C030 
		public HapticState currentState { get; } // 0x0000000181D8BFD0-0x0000000181D8BFF0 
	
		// Methods
		public static GetCurrentHapticStateCommand Create(); // 0x0000000181D8BF10-0x0000000181D8BF90
	}
}
