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
	[NativeClass("Collider", PersistentTypeId = 56)]
	[NativeHeader("Modules/Physics/Collider.h")]
	public class Collider : Component // TypeDefIndex: 15422
	{
		// Properties
		public bool enabled { get; } // 0x00000001822D45C0-0x00000001822D4620 
		public Rigidbody attachedRigidbody { [NativeMethod("GetRigidbody")] get; } // 0x00000001822D44F0-0x00000001822D4580 
		public bool isTrigger { set; } // 0x00000001822D4670-0x00000001822D46D0
	
		// Constructors
		public Collider(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public Vector3 ClosestPoint(Vector3 position); // 0x00000001822D4430-0x00000001822D44B0
		private static bool get_enabled_Injected(IntPtr _unity_self); // 0x00000001822D4580-0x00000001822D45C0
		private static IntPtr get_attachedRigidbody_Injected(IntPtr _unity_self); // 0x00000001822D44B0-0x00000001822D44F0
		private static void set_isTrigger_Injected(IntPtr _unity_self, bool value); // 0x00000001822D4620-0x00000001822D4670
		private static void ClosestPoint_Injected(IntPtr _unity_self, in Vector3 position, ); // 0x00000001822D43D0-0x00000001822D4430
	}
}
