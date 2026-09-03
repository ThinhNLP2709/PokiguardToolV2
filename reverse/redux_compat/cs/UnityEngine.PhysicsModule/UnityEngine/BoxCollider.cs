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
	[NativeClass("BoxCollider", PersistentTypeId = 65)]
	[NativeHeader("Modules/Physics/BoxCollider.h")]
	[RequireComponent(typeof(Transform))]
	public class BoxCollider : Collider // TypeDefIndex: 15419
	{
		// Properties
		public Vector3 center { get; set; } // 0x00000001822D4140-0x00000001822D41B0 0x00000001822D42C0-0x00000001822D4320
		public Vector3 size { get; set; } // 0x00000001822D4200-0x00000001822D4270 0x00000001822D4370-0x00000001822D43D0
	
		// Constructors
		public BoxCollider(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static void get_center_Injected(IntPtr _unity_self, ); // 0x00000001822D40F0-0x00000001822D4140
		private static void set_center_Injected(IntPtr _unity_self, in Vector3 value); // 0x00000001822D4270-0x00000001822D42C0
		private static void get_size_Injected(IntPtr _unity_self, ); // 0x00000001822D41B0-0x00000001822D4200
		private static void set_size_Injected(IntPtr _unity_self, in Vector3 value); // 0x00000001822D4320-0x00000001822D4370
	}
}
