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
	public struct SendBufferedHapticCommand : IInputDeviceCommandInfo // TypeDefIndex: 6272
	{
		// Fields
		private const int kMaxHapticBufferSize = 1024; // Metadata: 0x00698DAF
		private const int kSize = 1040; // Metadata: 0x00698DB1
		private InputDeviceCommand baseCommand; // 0x00
		private int channel; // 0x08
		private int bufferSize; // 0x0C
		private unsafe fixed /* 0x00000000-0x00000000 */ byte buffer[0]; // 0x10
	
		// Properties
		private static FourCC Type { get; } // 0x0000000181D9F890-0x0000000181D9F8D0 
		public FourCC typeStatic { get; } // 0x0000000181D9F8D0-0x0000000181D9F910 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _buffer_e__FixedBuffer // TypeDefIndex: 6273
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public static SendBufferedHapticCommand Create(byte[] rumbleBuffer); // 0x0000000181D9F6C0-0x0000000181D9F890
	}
}
