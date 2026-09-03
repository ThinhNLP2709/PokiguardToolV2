/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.LowLevelPhysics2D", "UnityEngine.Physics2DModule", null)]
	public struct PhysicsMath // TypeDefIndex: 14697
	{
		// Methods
		public static float ToDegrees(float radians); // 0x00000001822C9280-0x00000001822C92C0
		public static float Atan2(float y, float x); // 0x00000001822C9230-0x00000001822C9280
		public static Vector3 Swizzle(Vector3 position, PhysicsWorld.TransformPlane transformPlane = PhysicsWorld.TransformPlane.XY /* Metadata: 0x006A9790 */); // 0x00000001822C2890-0x00000001822C2970
		public static Vector3 ToPosition3D(Vector2 position, Vector3 reference, PhysicsWorld.TransformPlane transformPlane = PhysicsWorld.TransformPlane.XY /* Metadata: 0x006A9791 */); // 0x00000001822C2970-0x00000001822C2A50
		public static float ToRotation2D(Quaternion quaternion, PhysicsWorld.TransformPlane transformPlane = PhysicsWorld.TransformPlane.XY /* Metadata: 0x006A9792 */); // 0x00000001822C2A50-0x00000001822C2DD0
		public static Quaternion AngularVelocityToQuaternion(float angularVelocity, float deltaTime, PhysicsWorld.TransformPlane transformPlane); // 0x00000001822C8FF0-0x00000001822C9230
		public static Quaternion ToRotationFast3D(float angle, PhysicsWorld.TransformPlane transformPlane = PhysicsWorld.TransformPlane.XY /* Metadata: 0x006A9793 */); // 0x00000001822C92C0-0x00000001822C94C0
		public static Quaternion ToRotationSlow3D(float angle, Quaternion reference, PhysicsWorld.TransformPlane transformPlane = PhysicsWorld.TransformPlane.XY /* Metadata: 0x006A9794 */); // 0x00000001822C2DD0-0x00000001822C3090
	}
}
