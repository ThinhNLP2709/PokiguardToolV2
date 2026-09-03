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
	[Serializable]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsTransform // TypeDefIndex: 14676
	{
		// Fields
		public Vector2 position; // 0x00
		public PhysicsRotate rotation; // 0x08
	
		// Constructors
		public PhysicsTransform(); // 0x00000001822CD290-0x00000001822CD350
	
		// Methods
		[IsReadOnly]
		public void GetPositionAndRotation(out Vector2 position, out PhysicsRotate rotation); // 0x00000001822CD1D0-0x00000001822CD200
		[IsReadOnly]
		public override string ToString(); // 0x00000001822CD200-0x00000001822CD290
	}
}
