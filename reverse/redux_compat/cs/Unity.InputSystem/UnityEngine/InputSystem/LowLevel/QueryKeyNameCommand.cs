/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct QueryKeyNameCommand : IInputDeviceCommandInfo // TypeDefIndex: 6407
	{
		// Fields
		internal const int kMaxNameLength = 256; // Metadata: 0x00698FB3
		internal const int kSize = 268; // Metadata: 0x00698FB5
		public InputDeviceCommand baseCommand; // 0x00
		public int scanOrKeyCode; // 0x08
		public unsafe fixed /* 0x00000000-0x00000000 */ byte nameBuffer[0]; // 0x0C
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DCFEB0-0x0000000181DCFEF0 
		public FourCC typeStatic { get; } // 0x0000000181DCFEF0-0x0000000181DCFF30 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _nameBuffer_e__FixedBuffer // TypeDefIndex: 6408
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public string ReadKeyName(); // 0x0000000181DCFE90-0x0000000181DCFEB0
		public static QueryKeyNameCommand Create(Key key); // 0x0000000181DCFE10-0x0000000181DCFE90
	}
}
