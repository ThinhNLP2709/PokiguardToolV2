/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[Serializable]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsMask : IEnumerable<int> // TypeDefIndex: 14674
	{
		// Fields
		public ulong bitMask; // 0x00
		public static readonly PhysicsMask None; // 0x00
		public static readonly PhysicsMask One; // 0x08
		public static readonly PhysicsMask All; // 0x10
	
		// Nested types
		public struct SetBitIterator : IEnumerable<int>, IEnumerator<int> // TypeDefIndex: 14675
		{
			// Fields
			private int m_BitIndex; // 0x00
			private ulong bitMask; // 0x08
	
			// Properties
			int IEnumerator<System.Int32>.Current { [IsReadOnly] get; } // 0x0000000180732D10-0x0000000180732D20 
			object IEnumerator.Current { [IsReadOnly] get; } // 0x00000001822D2700-0x00000001822D2720 
	
			// Constructors
			public SetBitIterator(PhysicsMask bitMask); // 0x00000001822D2720-0x00000001822D2780
	
			// Methods
			bool IEnumerator.MoveNext(); // 0x00000001822D26B0-0x00000001822D2700
			void IEnumerator.Reset(); // 0x0000000181D03C60-0x0000000181D03C70
			public IEnumerator<int> GetEnumerator(); // 0x00000001822D2660-0x00000001822D26B0
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001822D2660-0x00000001822D26B0
			[IsReadOnly]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		static PhysicsMask(); // 0x00000001822C8F80-0x00000001822C8FF0
	
		// Methods
		public static implicit operator ulong(PhysicsMask bitMask); // 0x0000000180370C60-0x0000000180370C70
		[IsReadOnly]
		public IEnumerator<int> GetEnumerator(); // 0x00000001822C8E00-0x00000001822C8E90
		[IsReadOnly]
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001822C8E90-0x00000001822C8F20
		[IsReadOnly]
		public override string ToString(); // 0x00000001822C8F20-0x00000001822C8F80
	}
}
