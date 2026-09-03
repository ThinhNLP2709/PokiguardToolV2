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
	internal struct ActionEvent : IInputEventTypeInfo // TypeDefIndex: 6449
	{
		// Fields
		public InputEvent baseEvent; // 0x00
		private ushort m_ControlIndex; // 0x14
		private ushort m_BindingIndex; // 0x16
		private ushort m_InteractionIndex; // 0x18
		private byte m_StateIndex; // 0x1A
		private byte m_Phase; // 0x1B
		private double m_StartTime; // 0x1C
		public unsafe fixed /* 0x00000000-0x00000000 */ byte m_ValueData[0]; // 0x24
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DBED50-0x0000000181DBED90 
		public double startTime { get; set; } // 0x0000000181D11B20-0x0000000181D11B30 0x0000000181DBEFA0-0x0000000181DBEFB0
		public InputActionPhase phase { get; set; } // 0x0000000181DBEDC0-0x0000000181DBEDD0 0x0000000181DBEF90-0x0000000181DBEFA0
		public unsafe byte* valueData { get; } // 0x0000000181DBEE10-0x0000000181DBEE20 
		public int valueSizeInBytes { get; } // 0x0000000181DBEE20-0x0000000181DBEE30 
		public int stateIndex { get; set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181DBEFB0-0x0000000181DBF020
		public int controlIndex { get; set; } // 0x0000000180A7E830-0x0000000180A7E840 0x0000000181DBEEA0-0x0000000181DBEF10
		public int bindingIndex { get; set; } // 0x0000000181DBED90-0x0000000181DBEDA0 0x0000000181DBEE30-0x0000000181DBEEA0
		public int interactionIndex { get; set; } // 0x0000000181DBEDA0-0x0000000181DBEDC0 0x0000000181DBEF10-0x0000000181DBEF90
		public FourCC typeStatic { get; } // 0x0000000181DBEDD0-0x0000000181DBEE10 
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_ValueData_e__FixedBuffer // TypeDefIndex: 6450
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public InputEventPtr ToEventPtr(); // 0x0000000180370C60-0x0000000180370C70
		public static int GetEventSizeWithValueSize(int valueSizeInBytes); // 0x0000000181DBED40-0x0000000181DBED50
		public static unsafe ActionEvent* From(InputEventPtr ptr); // 0x0000000181DBEC30-0x0000000181DBED40
	}
}
