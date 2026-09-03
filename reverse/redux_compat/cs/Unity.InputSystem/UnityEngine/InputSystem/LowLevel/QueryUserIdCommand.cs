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
	internal struct QueryUserIdCommand : IInputDeviceCommandInfo // TypeDefIndex: 6416
	{
		// Fields
		public const int kMaxIdLength = 256; // Metadata: 0x00698FE0
		internal const int kSize = 520; // Metadata: 0x00698FE2
		public InputDeviceCommand baseCommand; // 0x00
		public unsafe fixed /* 0x00000000-0x00000000 */ byte idBuffer[0]; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DD0510-0x0000000181DD0550 
		public FourCC typeStatic { get; } // 0x0000000181DD0550-0x0000000181DD0590 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _idBuffer_e__FixedBuffer // TypeDefIndex: 6417
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public string ReadId(); // 0x0000000181DCFFA0-0x0000000181DCFFC0
		public static QueryUserIdCommand Create(); // 0x0000000181DD04A0-0x0000000181DD0510
	}
}
