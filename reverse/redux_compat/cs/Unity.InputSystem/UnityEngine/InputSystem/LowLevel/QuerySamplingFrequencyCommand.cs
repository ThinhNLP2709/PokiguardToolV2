/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal struct QuerySamplingFrequencyCommand : IInputDeviceCommandInfo // TypeDefIndex: 6415
	{
		// Fields
		internal const int kSize = 12; // Metadata: 0x00698FDF
		public InputDeviceCommand baseCommand; // 0x00
		public float frequency; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DD0420-0x0000000181DD0460 
		public FourCC typeStatic { get; } // 0x0000000181DD0460-0x0000000181DD04A0 
	
		// Methods
		public static QuerySamplingFrequencyCommand Create(); // 0x0000000181DD03C0-0x0000000181DD0420
	}
}
