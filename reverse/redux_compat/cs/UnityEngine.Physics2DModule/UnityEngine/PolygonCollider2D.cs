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
	[NativeClass("PolygonCollider2D", PersistentTypeId = 60)]
	[NativeHeader("Modules/Physics2D/Public/PolygonCollider2D.h")]
	public sealed class PolygonCollider2D : Collider2D // TypeDefIndex: 15610
	{
		// Properties
		public Vector2[] points { [NativeMethod("SetPoints_Binding")] set; } // 0x00000001822C20E0-0x00000001822C21A0
	
		// Constructors
		public PolygonCollider2D(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static void set_points_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x00000001822C2090-0x00000001822C20E0
	}
}
