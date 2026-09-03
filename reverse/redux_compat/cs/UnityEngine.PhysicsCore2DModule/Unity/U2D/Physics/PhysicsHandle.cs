/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	public struct PhysicsHandle : IEquatable<Unity.U2D.Physics.PhysicsHandle> // TypeDefIndex: 14671
	{
		// Fields
		private readonly int m_Index1; // 0x00
		private readonly ushort m_World0; // 0x04
		private readonly ushort m_Generation; // 0x06
	
		// Methods
		public override string ToString(); // 0x00000001822C8A10-0x00000001822C8AB0
		public override bool Equals(object obj); // 0x00000001822C8950-0x00000001822C89F0
		public bool Equals(PhysicsHandle other); // 0x00000001822C89F0-0x00000001822C8A10
		public static bool operator ==(PhysicsHandle lhs, PhysicsHandle rhs); // 0x00000001822C8AB0-0x00000001822C8AE0
		public override int GetHashCode(); // 0x00000001822C6840-0x00000001822C68B0
	}
}
