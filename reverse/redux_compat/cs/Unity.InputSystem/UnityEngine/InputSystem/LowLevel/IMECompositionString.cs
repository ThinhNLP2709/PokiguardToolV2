/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct IMECompositionString : IEnumerable<char> // TypeDefIndex: 6458
	{
		// Fields
		private int size; // 0x00
		private unsafe fixed /* 0x00000000-0x00000000 */ char buffer[0]; // 0x04
	
		// Properties
		public int Count { get; } // 0x0000000180732D10-0x0000000180732D20 
		public char this[int index] { get => default; } // 0x0000000181DCA700-0x0000000181DCA770 
	
		// Nested types
		internal struct Enumerator : IEnumerator<char> // TypeDefIndex: 6459
		{
			// Fields
			private IMECompositionString m_CompositionString; // 0x00
			private char m_CurrentCharacter; // 0x84
			private int m_CurrentIndex; // 0x88
	
			// Properties
			public char Current { get; } // 0x000000018170D350-0x000000018170D360 
			object IEnumerator.Current { get; } // 0x0000000181DC3A60-0x0000000181DC3A90 
	
			// Constructors
			public Enumerator(IMECompositionString compositionString); // 0x0000000181DC3A90-0x0000000181DC3AF0
	
			// Methods
			public bool MoveNext(); // 0x0000000181DC3930-0x0000000181DC3960
			public void Reset(); // 0x0000000181DC3980-0x0000000181DC3990
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _buffer_e__FixedBuffer // TypeDefIndex: 6460
		{
			// Fields
			public char FixedElementField; // 0x00
		}
	
		// Constructors
		public unsafe IMECompositionString(string characters); // 0x0000000181DCA670-0x0000000181DCA700
	
		// Methods
		public override string ToString(); // 0x0000000181DCA640-0x0000000181DCA670
		public IEnumerator<char> GetEnumerator(); // 0x0000000181DCA560-0x0000000181DCA630
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181DCA630-0x0000000181DCA640
	}
}
