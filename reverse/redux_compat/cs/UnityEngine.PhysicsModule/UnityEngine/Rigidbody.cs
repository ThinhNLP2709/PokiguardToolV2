/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[NativeClass("Rigidbody", PersistentTypeId = 54)]
	[NativeHeader("Modules/Physics/Rigidbody.h")]
	[RequireComponent(typeof(Transform))]
	public class Rigidbody : Component // TypeDefIndex: 15444
	{
		// Properties
		public Vector3 position { get; } // 0x00000001822D8C90-0x00000001822D8D00 
		public Quaternion rotation { get; set; } // 0x00000001822D8D50-0x00000001822D8DC0 0x00000001822D8E10-0x00000001822D9150
	
		// Methods
		public void MovePosition(Vector3 position); // 0x00000001822D8B30-0x00000001822D8B90
		public void MoveRotation(Quaternion rotation); // 0x00000001822D8BE0-0x00000001822D8C40
		public void AddForce(Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode); // 0x00000001822D8930-0x00000001822D89A0
		[ExcludeFromDocs]
		public void AddForce(Vector3 force); // 0x00000001822D88C0-0x00000001822D8930
		public void AddRelativeForce(Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode); // 0x00000001822D8A70-0x00000001822D8AE0
		[ExcludeFromDocs]
		public void AddRelativeForce(Vector3 force); // 0x00000001822D8A00-0x00000001822D8A70
		private static void get_position_Injected(IntPtr _unity_self, ); // 0x00000001822D8C40-0x00000001822D8C90
		private static void get_rotation_Injected(IntPtr _unity_self, ); // 0x00000001822D8D00-0x00000001822D8D50
		private static void set_rotation_Injected(IntPtr _unity_self, in Quaternion value); // 0x00000001822D8DC0-0x00000001822D8E10
		private static void MovePosition_Injected(IntPtr _unity_self, in Vector3 position); // 0x00000001822D8AE0-0x00000001822D8B30
		private static void MoveRotation_Injected(IntPtr _unity_self, in Quaternion rotation); // 0x00000001822D8B90-0x00000001822D8BE0
		private static void AddForce_Injected(IntPtr _unity_self, in Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode); // 0x00000001822D8860-0x00000001822D88C0
		private static void AddRelativeForce_Injected(IntPtr _unity_self, in Vector3 force, [DefaultValue("ForceMode.Force")] ForceMode mode); // 0x00000001822D89A0-0x00000001822D8A00
	}
}
