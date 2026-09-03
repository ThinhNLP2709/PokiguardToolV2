/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 54: UnityEngine.Physics2DModule.dll - Assembly: UnityEngine.Physics2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15597-15610

namespace UnityEngine
{
	[NativeHeader("Physics2DScriptingClasses.h")]
	[NativeHeader("Modules/Physics2D/PhysicsManager2D.h")]
	[StaticAccessor("GetPhysicsManager2D()", StaticAccessorType.Arrow)]
	public class Physics2D // TypeDefIndex: 15601
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static List<Rigidbody2D> m_LastDisabledRigidbody2D; // 0x00
	
		// Properties
		public static PhysicsScene2D defaultPhysicsScene { get; } // 0x00000001802E7860-0x00000001802E7870 
		[StaticAccessor("GetPhysics2DSettings()")]
		public static bool queriesHitTriggers { get; } // 0x00000001822C1960-0x00000001822C1990 
	
		// Constructors
		static Physics2D(); // 0x00000001822C18D0-0x00000001822C1960
	
		// Methods
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask); // 0x00000001822C1630-0x00000001822C18D0
		public static RaycastHit2D GetRayIntersection(Ray ray, float distance, [DefaultValue("DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA0F9 */); // 0x00000001822C14F0-0x00000001822C1630
		[RequiredByNativeCode]
		public static RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance, [DefaultValue("DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA0FA */); // 0x00000001822C12D0-0x00000001822C1370
		[NativeMethod("GetRayIntersectionAll_Binding")]
		[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
		private static RaycastHit2D[] GetRayIntersectionAll_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask); // 0x00000001822C1190-0x00000001822C12D0
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public static int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance, [DefaultValue("DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA0FB */); // 0x00000001822C1370-0x00000001822C14F0
		private static void GetRayIntersectionAll_Internal_Injected(in PhysicsScene2D physicsScene, in Vector3 origin, in Vector3 direction, float distance, int layerMask, ); // 0x00000001822C1120-0x00000001822C1190
	}
}
