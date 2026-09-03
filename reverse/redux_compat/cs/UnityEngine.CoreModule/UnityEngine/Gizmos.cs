/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/Gizmos/Gizmos.bindings.h")]
	[StaticAccessor("GizmoBindings", StaticAccessorType.DoubleColon)]
	public sealed class Gizmos // TypeDefIndex: 7533
	{
		// Properties
		public static Color color { get; set; } // 0x000000018219EA10-0x000000018219EA50 0x000000018219EA90-0x000000018219EAD0
		public static Matrix4x4 matrix { set; } // 0x000000018219EB10-0x000000018219EB50
	
		// Methods
		[NativeMethod(ThrowsException = true)]
		public static void DrawLine(Vector3 from, Vector3 to); // 0x000000018219E840-0x000000018219E890
		[NativeMethod(ThrowsException = true)]
		public static void DrawWireSphere(Vector3 center, float radius); // 0x000000018219E980-0x000000018219E9D0
		[NativeMethod(ThrowsException = true)]
		public static void DrawSphere(Vector3 center, float radius); // 0x000000018219E8E0-0x000000018219E930
		[NativeMethod(ThrowsException = true)]
		public static void DrawIcon(Vector3 center, string name, [DefaultValue("true")] bool allowScaling, [DefaultValue("Color(255,255,255,255)")] Color tint); // 0x000000018219E680-0x000000018219E7F0
		private static void DrawLine_Injected(in Vector3 from, in Vector3 to); // 0x000000018219E7F0-0x000000018219E840
		private static void DrawWireSphere_Injected(in Vector3 center, float radius); // 0x000000018219E930-0x000000018219E980
		private static void DrawSphere_Injected(in Vector3 center, float radius); // 0x000000018219E890-0x000000018219E8E0
		private static void DrawIcon_Injected(in Vector3 center, ref ManagedSpanWrapper name, [DefaultValue("true")] bool allowScaling, [DefaultValue("Color(255,255,255,255)")] in Color tint); // 0x000000018219E610-0x000000018219E680
		private static void get_color_Injected(); // 0x000000018219E9D0-0x000000018219EA10
		private static void set_color_Injected(in Color value); // 0x000000018219EA50-0x000000018219EA90
		private static void set_matrix_Injected(in Matrix4x4 value); // 0x000000018219EAD0-0x000000018219EB10
	}
}
