/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct InputDeviceCommand : IInputDeviceCommandInfo // TypeDefIndex: 6403
	{
		// Fields
		internal const int kBaseCommandSize = 8; // Metadata: 0x00698F9E
		public const int BaseCommandSize = 8; // Metadata: 0x00698F9F
		public const long GenericFailure = -1; // Metadata: 0x00698FA0
		public const long GenericSuccess = 1; // Metadata: 0x00698FA8
		public FourCC type; // 0x00
		public int sizeInBytes; // 0x04
	
		// Properties
		public int payloadSizeInBytes { get; } // 0x0000000181DCAA40-0x0000000181DCAA50 
		public unsafe void* payloadPtr { get; } // 0x0000000181DCAA30-0x0000000181DCAA40 
		public FourCC typeStatic { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public InputDeviceCommand(FourCC type, int sizeInBytes = 8 /* Metadata: 0x00698F9D */); // 0x0000000180C55C70-0x0000000180C55C80
	
		// Methods
		public static NativeArray<byte> AllocateNative(FourCC type, int payloadSize); // 0x0000000181DCA9C0-0x0000000181DCAA30
	}
}
