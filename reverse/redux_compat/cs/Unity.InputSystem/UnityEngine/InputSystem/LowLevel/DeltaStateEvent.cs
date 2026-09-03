/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct DeltaStateEvent : IInputEventTypeInfo // TypeDefIndex: 6451
	{
		// Fields
		public const int Type = 1145852993; // Metadata: 0x00699024
		public InputEvent baseEvent; // 0x00
		public FourCC stateFormat; // 0x14
		public uint stateOffset; // 0x18
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte stateData[0]; // 0x1C
	
		// Properties
		public uint deltaStateSizeInBytes { get; } // 0x0000000181DBF4F0-0x0000000181DBF500 
		public unsafe void* deltaState { get; } // 0x0000000181DBF500-0x0000000181DBF510 
		public FourCC typeStatic { get; } // 0x0000000181DBF510-0x0000000181DBF520 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _stateData_e__FixedBuffer // TypeDefIndex: 6452
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public InputEventPtr ToEventPtr(); // 0x0000000180370C60-0x0000000180370C70
		public static unsafe DeltaStateEvent* From(InputEventPtr ptr); // 0x0000000181DBF3E0-0x0000000181DBF4F0
		internal static unsafe DeltaStateEvent* FromUnchecked(InputEventPtr ptr); // 0x0000000180370C60-0x0000000180370C70
		public static NativeArray<byte> From(InputControl control, out InputEventPtr eventPtr, Allocator allocator = Allocator.Temp /* Metadata: 0x00699023 */); // 0x0000000181DBF0A0-0x0000000181DBF3E0
	}
}
