/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 54: UnityEngine.Physics2DModule.dll - Assembly: UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15597-15610

namespace UnityEngine
{
	[NativeClass("CircleCollider2D", PersistentTypeId = 58)]
	[NativeHeader("Modules/Physics2D/Public/CircleCollider2D.h")]
	public sealed class CircleCollider2D : Collider2D // TypeDefIndex: 15608
	{
		// Properties
		public float radius { get; set; } // 0x00000001822C0A60-0x00000001822C0AC0 0x00000001822C0B50-0x00000001822C0BC0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("CircleCollider2D.center has been obsolete. Use CircleCollider2D.offset instead (UnityUpgradable) -> offset", true)]
		public Vector2 center { get; set; } // 0x00000001822C09E0-0x00000001822C0A20 0x00000001822C0AC0-0x00000001822C0B00
	
		// Constructors
		public CircleCollider2D(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static float get_radius_Injected(IntPtr _unity_self); // 0x00000001822C0A20-0x00000001822C0A60
		private static void set_radius_Injected(IntPtr _unity_self, float value); // 0x00000001822C0B00-0x00000001822C0B50
	}
}
