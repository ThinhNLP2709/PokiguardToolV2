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
	public struct InputEventPtr : IEquatable<UnityEngine.InputSystem.LowLevel.InputEventPtr> // TypeDefIndex: 6468
	{
		// Fields
		private readonly unsafe InputEvent* m_EventPtr; // 0x00
	
		// Properties
		public bool valid { get; } // 0x0000000180B1C1D0-0x0000000180B1C1E0 
		public bool handled { get; set; } // 0x0000000181DCBA20-0x0000000181DCBA40 0x0000000181DCBDC0-0x0000000181DCBE40
		public int id { get; set; } // 0x0000000181DCBA40-0x0000000181DCBA60 0x0000000181DCBE40-0x0000000181DCBEC0
		public FourCC type { get; } // 0x0000000180E873C0-0x0000000180E873D0 
		public uint sizeInBytes { get; } // 0x0000000181DCBA80-0x0000000181DCBAA0 
		public int deviceId { get; set; } // 0x0000000181DCBA00-0x0000000181DCBA20 0x0000000181DCBD50-0x0000000181DCBDC0
		public double time { get; set; } // 0x0000000181DCBCF0-0x0000000181DCBD50 0x0000000181DCBF30-0x0000000181DCBFD0
		internal double internalTime { get; set; } // 0x0000000181DCBA60-0x0000000181DCBA80 0x0000000181DCBEC0-0x0000000181DCBF30
		public unsafe InputEvent* data { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		internal FourCC stateFormat { get; } // 0x0000000181DCBAA0-0x0000000181DCBB70 
		internal uint stateSizeInBytes { get; } // 0x0000000181DCBC20-0x0000000181DCBCF0 
		internal uint stateOffset { get; } // 0x0000000181DCBB70-0x0000000181DCBC20 
	
		// Constructors
		public unsafe InputEventPtr(InputEvent* eventPtr); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public bool IsA<TOtherEvent>()
			where TOtherEvent : struct, IInputEventTypeInfo;
		public InputEventPtr Next(); // 0x0000000181DCB980-0x0000000181DCB9A0
		public override string ToString(); // 0x0000000181DCB9A0-0x0000000181DCBA00
		public unsafe InputEvent* ToPointer(); // 0x00000001808BADD0-0x00000001808BADE0
		public bool Equals(InputEventPtr other); // 0x0000000181DCB930-0x0000000181DCB980
		public override bool Equals(object obj); // 0x0000000181DCB870-0x0000000181DCB930
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public static bool operator ==(InputEventPtr left, InputEventPtr right); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(InputEventPtr left, InputEventPtr right); // 0x000000018126B560-0x000000018126B570
		public static unsafe implicit operator InputEventPtr(InputEvent* eventPtr); // 0x0000000180370C60-0x0000000180370C70
		public static unsafe InputEventPtr From(InputEvent* eventPtr); // 0x0000000180370C60-0x0000000180370C70
		public static unsafe implicit operator InputEvent*(InputEventPtr eventPtr); // 0x0000000180370C60-0x0000000180370C70
		public static unsafe InputEvent* FromInputEventPtr(InputEventPtr eventPtr); // 0x0000000180370C60-0x0000000180370C70
	}
}
