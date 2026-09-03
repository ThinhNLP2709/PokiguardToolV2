/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsJoint : IEquatable<Unity.U2D.Physics.PhysicsJoint> // TypeDefIndex: 14667
	{
		// Fields
		private readonly PhysicsHandle m_PhysicsHandle; // 0x00
	
		// Properties
		public bool isValid { get; } // 0x00000001822C8DC0-0x00000001822C8E00 
		public object callbackTarget { get; } // 0x00000001822C8D80-0x00000001822C8DC0 
	
		// Methods
		public override string ToString(); // 0x00000001822C68B0-0x00000001822C68C0
		public override bool Equals(object obj); // 0x00000001822C8CE0-0x00000001822C8D80
		public bool Equals(PhysicsJoint other); // 0x00000001822C6770-0x00000001822C67A0
		public override int GetHashCode(); // 0x00000001822C6840-0x00000001822C68B0
	}
}
