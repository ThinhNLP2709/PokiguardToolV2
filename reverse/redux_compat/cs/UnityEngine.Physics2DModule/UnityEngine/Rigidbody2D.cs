/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 54: UnityEngine.Physics2DModule.dll - Assembly: UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15597-15610

namespace UnityEngine
{
	[NativeClass("Rigidbody2D", PersistentTypeId = 50)]
	[NativeHeader("Modules/Physics2D/Public/Rigidbody2D.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class Rigidbody2D : Component // TypeDefIndex: 15606
	{
		// Properties
		public Vector2 position { get; set; } // 0x00000001822C2400-0x00000001822C2470 0x00000001822C2560-0x00000001822C2890
		public float rotation { get; } // 0x00000001822C24B0-0x00000001822C2510 
	
		// Methods
		public void MovePosition(Vector2 position); // 0x00000001822C2290-0x00000001822C22F0
		public void MoveRotation(float angle); // 0x00000001822C2340-0x00000001822C23B0
		[NativeMethod("MoveRotation")]
		private void MoveRotation_Angle(float angle); // 0x00000001822C2340-0x00000001822C23B0
		private static void get_position_Injected(IntPtr _unity_self, ); // 0x00000001822C23B0-0x00000001822C2400
		private static void set_position_Injected(IntPtr _unity_self, in Vector2 value); // 0x00000001822C2510-0x00000001822C2560
		private static float get_rotation_Injected(IntPtr _unity_self); // 0x00000001822C2470-0x00000001822C24B0
		private static void MovePosition_Injected(IntPtr _unity_self, in Vector2 position); // 0x00000001822C2240-0x00000001822C2290
		private static void MoveRotation_Angle_Injected(IntPtr _unity_self, float angle); // 0x00000001822C22F0-0x00000001822C2340
	}
}
