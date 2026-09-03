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
	[NativeHeader("Modules/Physics2D/Public/PhysicsSceneHandle2D.h")]
	public struct PhysicsScene2D : IEquatable<UnityEngine.PhysicsScene2D> // TypeDefIndex: 15600
	{
		// Fields
		private int m_Handle; // 0x00
	
		// Methods
		public override string ToString(); // 0x00000001822C2030-0x00000001822C2090
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public override bool Equals(object other); // 0x00000001822C1990-0x00000001822C1A10
		public bool Equals(PhysicsScene2D other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter); // 0x00000001822C1F60-0x00000001822C2030
		[NativeMethod("Raycast_Binding")]
		[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
		private static RaycastHit2D Raycast_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter); // 0x00000001822C1EE0-0x00000001822C1F60
		public RaycastHit2D GetRayIntersection(Ray ray, float distance, [DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA0F7 */); // 0x00000001822C1C70-0x00000001822C1D50
		public int GetRayIntersection(Ray ray, float distance, RaycastHit2D[] results, [DefaultValue("Physics2D.DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA0F8 */); // 0x00000001822C1D50-0x00000001822C1E70
		[NativeMethod("GetRayIntersection_Binding")]
		[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
		private static RaycastHit2D GetRayIntersection_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask); // 0x00000001822C1BF0-0x00000001822C1C70
		[NativeMethod("GetRayIntersectionArray_Binding")]
		[StaticAccessor("PhysicsQuery2D", StaticAccessorType.DoubleColon)]
		private static int GetRayIntersectionArray_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask, [NotNull] RaycastHit2D[] results); // 0x00000001822C1A80-0x00000001822C1B80
		private static void Raycast_Internal_Injected(in PhysicsScene2D physicsScene, in Vector2 origin, in Vector2 direction, float distance, in ContactFilter2D contactFilter, ); // 0x00000001822C1E70-0x00000001822C1EE0
		private static void GetRayIntersection_Internal_Injected(in PhysicsScene2D physicsScene, in Vector3 origin, in Vector3 direction, float distance, int layerMask, ); // 0x00000001822C1B80-0x00000001822C1BF0
		private static int GetRayIntersectionArray_Internal_Injected(in PhysicsScene2D physicsScene, in Vector3 origin, in Vector3 direction, float distance, int layerMask, ref ManagedSpanWrapper results); // 0x00000001822C1A10-0x00000001822C1A80
	}
}
