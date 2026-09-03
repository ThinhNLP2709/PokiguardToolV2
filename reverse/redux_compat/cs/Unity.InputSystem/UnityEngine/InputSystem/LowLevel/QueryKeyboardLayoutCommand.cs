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
	public struct QueryKeyboardLayoutCommand : IInputDeviceCommandInfo // TypeDefIndex: 6409
	{
		// Fields
		internal const int kMaxNameLength = 256; // Metadata: 0x00698FB7
		public InputDeviceCommand baseCommand; // 0x00
		public unsafe fixed /* 0x00000000-0x00000000 */ byte nameBuffer[0]; // 0x08
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DCFFF0-0x0000000181DD0030 
		public FourCC typeStatic { get; } // 0x0000000181DD0030-0x0000000181DD0070 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _nameBuffer_e__FixedBuffer // TypeDefIndex: 6410
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public string ReadLayoutName(); // 0x0000000181DCFFA0-0x0000000181DCFFC0
		public void WriteLayoutName(string name); // 0x0000000181DCFFC0-0x0000000181DCFFF0
		public static QueryKeyboardLayoutCommand Create(); // 0x0000000181DCFF30-0x0000000181DCFFA0
	}
}
