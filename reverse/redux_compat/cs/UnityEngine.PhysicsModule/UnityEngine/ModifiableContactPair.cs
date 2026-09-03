/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[NativeHeader("Modules/Physics/PhysXContactModification.h")]
	[NativeHeader("Modules/Physics/PhysicsCollisionGeometry.h")]
	public struct ModifiableContactPair // TypeDefIndex: 15425
	{
		// Fields
		private IntPtr actor; // 0x00
		private IntPtr otherActor; // 0x08
		private IntPtr shape; // 0x10
		private IntPtr otherShape; // 0x18
		public Quaternion rotation; // 0x20
		public Vector3 position; // 0x30
		public Quaternion otherRotation; // 0x3C
		public Vector3 otherPosition; // 0x4C
		private int numContacts; // 0x58
		private IntPtr contacts; // 0x60
	}
}
