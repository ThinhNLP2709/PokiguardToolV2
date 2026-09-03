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
	public struct StateEvent : IInputEventTypeInfo // TypeDefIndex: 6477
	{
		// Fields
		public const int Type = 1398030676; // Metadata: 0x006990BA
		internal const int kStateDataSizeToSubtract = 1; // Metadata: 0x006990BF
		public InputEvent baseEvent; // 0x00
		public FourCC stateFormat; // 0x14
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte stateData[0]; // 0x18
	
		// Properties
		public uint stateSizeInBytes { get; } // 0x0000000181DE98F0-0x0000000181DE9910 
		public unsafe void* state { get; } // 0x0000000181DE9910-0x0000000181DE9920 
		public FourCC typeStatic { get; } // 0x0000000181DE9920-0x0000000181DE9930 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _stateData_e__FixedBuffer // TypeDefIndex: 6478
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public InputEventPtr ToEventPtr(); // 0x0000000180370C60-0x0000000180370C70
		public TState GetState<TState>()
			where TState : struct, IInputStateTypeInfo;
		public static TState GetState<TState>(InputEventPtr ptr)
			where TState : struct, IInputStateTypeInfo;
		public static int GetEventSizeWithPayload<TState>()
			where TState : struct;
		public static unsafe StateEvent* From(InputEventPtr ptr); // 0x0000000181DE97E0-0x0000000181DE98F0
		internal static unsafe StateEvent* FromUnchecked(InputEventPtr ptr); // 0x0000000180370C60-0x0000000180370C70
		public static NativeArray<byte> From(InputDevice device, out InputEventPtr eventPtr, Allocator allocator = Allocator.Temp /* Metadata: 0x006990B8 */); // 0x0000000181DE97B0-0x0000000181DE97E0
		public static NativeArray<byte> FromDefaultStateFor(InputDevice device, out InputEventPtr eventPtr, Allocator allocator = Allocator.Temp /* Metadata: 0x006990B9 */); // 0x0000000181DE9490-0x0000000181DE94C0
		private static NativeArray<byte> From(InputDevice device, out InputEventPtr eventPtr, Allocator allocator, bool useDefaultState); // 0x0000000181DE94C0-0x0000000181DE97B0
	}
}
