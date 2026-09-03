/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal struct TouchscreenState : IInputStateTypeInfo // TypeDefIndex: 6446
	{
		// Fields
		public const int MaxTouches = 10; // Metadata: 0x00699021
		[InputControl(name = "primaryTouch", displayName = "Primary Touch", layout = "Touch", synthetic = true)]
		[InputControl(name = "primaryTouch/tap", usage = "PrimaryAction")]
		[InputControl(name = "position", useStateFrom = "primaryTouch/position")]
		[InputControl(name = "delta", useStateFrom = "primaryTouch/delta", layout = "Delta")]
		[InputControl(name = "pressure", useStateFrom = "primaryTouch/pressure")]
		[InputControl(name = "radius", useStateFrom = "primaryTouch/radius")]
		[InputControl(name = "press", useStateFrom = "primaryTouch/phase", layout = "TouchPress", synthetic = true, usages = new string[0])]
		[InputControl(name = "displayIndex", useStateFrom = "primaryTouch/displayIndex", format = "BYTE")]
		public unsafe fixed /* 0x00000000-0x00000000 */ byte primaryTouchData[0]; // 0x00
		internal const int kTouchDataOffset = 56; // Metadata: 0x00699022
		[InputControl(layout = "Touch", name = "touch", displayName = "Touch", arraySize = 10)]
		public unsafe fixed /* 0x00000000-0x00000000 */ byte touchData[0]; // 0x38
	
		// Properties
		public static FourCC Format { get; } // 0x0000000181DD49C0-0x0000000181DD4A00 
		public unsafe TouchState* primaryTouch { get; } // 0x0000000180370C60-0x0000000180370C70 
		public unsafe TouchState* touches { get; } // 0x0000000181DD4A40-0x0000000181DD4A50 
		public FourCC format { get; } // 0x0000000181DD4A00-0x0000000181DD4A40 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _primaryTouchData_e__FixedBuffer // TypeDefIndex: 6447
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _touchData_e__FixedBuffer // TypeDefIndex: 6448
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	}
}
