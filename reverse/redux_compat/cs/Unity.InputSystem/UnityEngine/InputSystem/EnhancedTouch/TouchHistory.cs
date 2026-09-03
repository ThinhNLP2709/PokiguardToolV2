/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.EnhancedTouch
{
	public struct TouchHistory : IReadOnlyList<UnityEngine.InputSystem.EnhancedTouch.Touch> // TypeDefIndex: 6365
	{
		// Fields
		private readonly InputStateHistory<TouchState> m_History; // 0x00
		private readonly Finger m_Finger; // 0x08
		private readonly int m_Count; // 0x10
		private readonly int m_StartIndex; // 0x14
		private readonly uint m_Version; // 0x18
	
		// Properties
		public int Count { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public Touch this[int index] { get => default; } // 0x0000000181DD0BF0-0x0000000181DD0E00 
	
		// Nested types
		private class Enumerator : IEnumerator<Touch> // TypeDefIndex: 6366
		{
			// Fields
			private readonly TouchHistory m_Owner; // 0x10
			private int m_Index; // 0x30
	
			// Properties
			public Touch Current { get; } // 0x0000000181DC3B60-0x0000000181DC3BB0 
			object IEnumerator.Current { get; } // 0x0000000181DC39E0-0x0000000181DC3A60 
	
			// Constructors
			internal Enumerator(TouchHistory owner); // 0x0000000181DC3AF0-0x0000000181DC3B40
	
			// Methods
			public bool MoveNext(); // 0x0000000181DC38C0-0x0000000181DC38E0
			public void Reset(); // 0x0000000181DC3970-0x0000000181DC3980
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		internal TouchHistory(Finger finger, InputStateHistory<TouchState> history, int startIndex = -1 /* Metadata: 0x00698F85 */, int count = -1 /* Metadata: 0x00698F86 */); // 0x0000000181DD0B70-0x0000000181DD0BF0
	
		// Methods
		public IEnumerator<Touch> GetEnumerator(); // 0x0000000181DD0AE0-0x0000000181DD0B60
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181DD0B60-0x0000000181DD0B70
		internal void CheckValid(); // 0x0000000181DD0A20-0x0000000181DD0AE0
	}
}
