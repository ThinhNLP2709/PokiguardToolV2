/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Jobs;

// Image 31: UnityEngine.PhysicsCore2DModule.dll - Assembly: UnityEngine.PhysicsCore2DModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14601-14714

namespace Unity.U2D.Physics
{
	[NativeHeader("Modules/PhysicsCore2D/Core/PhysicsWorldManager2D.h")]
	[NativeHeader("Modules/PhysicsCore2D/Core/PhysicsCore2D.h")]
	[StaticAccessor("PhysicsCore2D", StaticAccessorType.DoubleColon)]
	internal static class Scripting2D // TypeDefIndex: 14662
	{
		// Nested types
		internal struct PhysicsBuffer : IDisposable // TypeDefIndex: 14663
		{
			// Fields
			private IntPtr m_Buffer; // 0x00
			private int m_Size; // 0x08
			private Allocator m_Allocator; // 0x0C
	
			// Properties
			public bool isEmpty { [IsReadOnly] get; } // 0x0000000180D853E0-0x0000000180D853F0 
			public bool isValid { [IsReadOnly] get; } // 0x00000001822C6A20-0x00000001822C6A30 
	
			// Constructors
			public PhysicsBuffer(); // 0x00000001822C6A10-0x00000001822C6A20
	
			// Methods
			[IsReadOnly]
			public NativeArray<T> ToNativeArray<T>()
				where T : struct;
			[IsReadOnly]
			public Span<T> ToSpan<T>()
				where T : struct;
			[IsReadOnly]
			public ReadOnlySpan<T> ToReadOnlySpan<T>()
				where T : struct;
			public void Dispose(); // 0x00000001822C6940-0x00000001822C6980
			[IsReadOnly]
			public override string ToString(); // 0x00000001822C6980-0x00000001822C6A10
		}
	
		// Methods
		[NativeMethod(Name = "PhysicsBody::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsBodyDefinition PhysicsBody_GetDefaultDefinition(bool useSettings); // 0x00000001822D1290-0x00000001822D12F0
		[NativeMethod(Name = "PhysicsBody::IsValid", IsThreadSafe = true)]
		internal static bool PhysicsBody_IsValid(PhysicsBody body); // 0x00000001822D1330-0x00000001822D1370
		[NativeMethod(Name = "PhysicsBody::GetCallbackTarget", IsThreadSafe = true)]
		internal static object PhysicsBody_GetCallbackTarget(PhysicsBody body); // 0x00000001822D1200-0x00000001822D1240
		[NativeMethod(Name = "PhysicsChain::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsChainDefinition PhysicsChain_GetDefaultDefinition(bool useSettings); // 0x00000001822D13C0-0x00000001822D1420
		[NativeMethod(Name = "PhysicsJoint::IsValid", IsThreadSafe = true)]
		internal static bool PhysicsJoint_IsValid(PhysicsJoint joint); // 0x00000001822D16E0-0x00000001822D1720
		[NativeMethod(Name = "PhysicsJoint::GetCallbackTarget", IsThreadSafe = true)]
		internal static object PhysicsJoint_GetCallbackTarget(PhysicsJoint joint); // 0x00000001822D1660-0x00000001822D16A0
		[NativeMethod(Name = "PhysicsDistanceJoint::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsDistanceJointDefinition DistanceJoint_GetDefaultDefinition(bool useSettings); // 0x00000001822D0F50-0x00000001822D0FC0
		[NativeMethod(Name = "PhysicsRelativeJoint::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsRelativeJointDefinition RelativeJoint_GetDefaultDefinition(bool useSettings); // 0x00000001822D2470-0x00000001822D24E0
		[NativeMethod(Name = "PhysicsSliderJoint::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsSliderJointDefinition SliderJoint_GetDefaultDefinition(bool useSettings); // 0x00000001822D2530-0x00000001822D25A0
		[NativeMethod(Name = "PhysicsHingeJoint::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsHingeJointDefinition HingeJoint_GetDefaultDefinition(bool useSettings); // 0x00000001822D10D0-0x00000001822D1140
		[NativeMethod(Name = "PhysicsFixedJoint::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsFixedJointDefinition FixedJoint_GetDefaultDefinition(bool useSettings); // 0x00000001822D1010-0x00000001822D1080
		[NativeMethod(Name = "PhysicsWheelJoint::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsWheelJointDefinition WheelJoint_GetDefaultDefinition(bool useSettings); // 0x00000001822D25F0-0x00000001822D2660
		[NativeMethod(Name = "PhysicsRotate::Create", IsThreadSafe = true)]
		internal static PhysicsRotate PhysicsRotate_CreateAngle(float angle); // 0x00000001822C9710-0x00000001822C9760
		[NativeMethod(Name = "PhysicsRotate::IsValid", IsThreadSafe = true)]
		internal static bool PhysicsRotate_IsValid(PhysicsRotate rotation); // 0x00000001822D18F0-0x00000001822D1930
		[NativeMethod(Name = "PhysicsRotate::GetAngle", IsThreadSafe = true)]
		internal static float PhysicsRotate_GetAngle(PhysicsRotate rotate); // 0x00000001822D17B0-0x00000001822D17F0
		[NativeMethod(Name = "PhysicsRotate::IntegrateRotation", IsThreadSafe = true)]
		internal static PhysicsRotate PhysicsRotate_IntegrateRotation(PhysicsRotate rotation, float deltaAngle); // 0x00000001822D1850-0x00000001822D18B0
		[NativeMethod(Name = "PhysicsAABB::IsValid", IsThreadSafe = true)]
		internal static bool PhysicsAABB_IsValid(PhysicsAABB aabb); // 0x00000001822D1180-0x00000001822D11C0
		[NativeMethod(Name = "PhysicsMath::ToDegrees", IsThreadSafe = true)]
		internal static float PhysicsMath_ToDegrees(float radians); // 0x00000001822C9280-0x00000001822C92C0
		[NativeMethod(Name = "PhysicsMath::Atan2", IsThreadSafe = true)]
		internal static float PhysicsMath_Atan2(float y, float x); // 0x00000001822C9230-0x00000001822C9280
		[NativeMethod(Name = "PhysicsCore2D::Global_GetObject", IsThreadSafe = true)]
		internal static UnityEngine.Object PhysicsGlobal_GetObject(EntityId entityId); // 0x00000001822D15C0-0x00000001822D1620
		[NativeMethod(Name = "PhysicsCore2D::Global_GetAllocatedWorldCapacity")]
		internal static int PhysicsGlobal_GetAllocatedWorldCapacity(); // 0x00000001822D01B0-0x00000001822D01E0
		[NativeMethod(Name = "PhysicsCore2D::Global_GetAlwaysDrawWorlds")]
		internal static bool PhysicsGlobal_GetAlwaysDrawWorlds(); // 0x00000001822D01E0-0x00000001822D0210
		[NativeMethod(Name = "PhysicsCore2D::Global_IsRenderingAllowed")]
		internal static bool PhysicsGlobal_IsRenderingAllowed(); // 0x00000001822D0210-0x00000001822D0240
		[NativeMethod(Name = "PhysicsCore2D::Global_CalculateWorldTransformWrite")]
		internal static PhysicsBuffer PhysicsGlobal_CalculateWorldTransformWrite(PhysicsWorld world, PhysicsWorld.TransformPlane transformPlane, PhysicsWorld.TransformPlaneCustom transformPlaneCustom, PhysicsWorld.TransformWriteMode transformWriteMode, IntPtr transformAccessArrayIntPtr); // 0x00000001822D1500-0x00000001822D1580
		[NativeMethod(Name = "PhysicsShape::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsShapeDefinition PhysicsShape_GetDefaultDefinition(bool useSettings); // 0x00000001822D1A00-0x00000001822D1A60
		[NativeMethod(Name = "PhysicsShape::GetDefaultSurfaceMaterial", IsThreadSafe = true)]
		internal static PhysicsShape.SurfaceMaterial PhysicsShape_GetDefaultSurfaceMaterial(bool useSettings); // 0x00000001822D1AB0-0x00000001822D1B00
		[NativeMethod(Name = "PhysicsShape::IsValid", IsThreadSafe = true)]
		internal static bool PhysicsShape_IsValid(PhysicsShape shape); // 0x00000001822D1B40-0x00000001822D1B80
		[NativeMethod(Name = "PhysicsShape::GetCallbackTarget", IsThreadSafe = true)]
		internal static object PhysicsShape_GetCallbackTarget(PhysicsShape shape); // 0x00000001822D1970-0x00000001822D19B0
		[NativeMethod(Name = "PhysicsCore2D::UnregisterTransformWatcher")]
		internal static void PhysicsCore2D_UnregisterTransformWatcher(Transform transform); // 0x00000001822D1460-0x00000001822D14A0
		[NativeMethod(Name = "PhysicsWorld::GetDefaultDefinition", IsThreadSafe = true)]
		internal static PhysicsWorldDefinition PhysicsWorld_GetDefaultDefinition(bool useSettings); // 0x00000001822D1DB0-0x00000001822D1E10
		[NativeMethod(Name = "PhysicsWorld::IsValid", IsThreadSafe = true)]
		internal static bool PhysicsWorld_IsValid(PhysicsWorld world); // 0x00000001822D22B0-0x00000001822D22F0
		[NativeMethod(Name = "PhysicsWorld::SetTransformWriteTweens", IsThreadSafe = true)]
		internal static void PhysicsWorld_SetTransformWriteTweens(PhysicsWorld world, ReadOnlySpan<PhysicsBody.TransformWriteTween> transformWriteTweens); // 0x00000001822D2340-0x00000001822D23B0
		[NativeMethod(Name = "PhysicsWorld::SetTransform")]
		internal static void PhysicsWorld_SetTransform(Transform transform, ref Vector3 position, ref Quaternion rotation, bool transformChangedEvent); // 0x00000001822D00C0-0x00000001822D0130
		[NativeMethod(Name = "PhysicsWorld::SetTransformAccess", IsThreadSafe = true, ThrowsException = true)]
		internal static void PhysicsWorld_SetTransformAccess(ref TransformAccess access, ref Vector3 position, ref Quaternion rotation, bool transformChangedEvent); // 0x00000001822CFFE0-0x00000001822D0050
		[NativeMethod(Name = "PhysicsWorld::GetBodyUpdateCallbackTargets", IsThreadSafe = true)]
		internal static PhysicsCallbacks.BodyUpdateCallbackTargets PhysicsWorld_GetBodyUpdateCallbackTargets(PhysicsWorld world, Allocator allocator); // 0x00000001822D1C50-0x00000001822D1CB0
		[NativeMethod(Name = "PhysicsWorld::GetTriggerCallbackTargets", IsThreadSafe = true)]
		internal static PhysicsCallbacks.TriggerCallbackTargets PhysicsWorld_GetTriggerCallbackTargets(PhysicsWorld world, Allocator allocator); // 0x00000001822D2210-0x00000001822D2270
		[NativeMethod(Name = "PhysicsWorld::GetContactCallbackTargets", IsThreadSafe = true)]
		internal static PhysicsCallbacks.ContactCallbackTargets PhysicsWorld_GetContactCallbackTargets(PhysicsWorld world, Allocator allocator); // 0x00000001822D1D00-0x00000001822D1D60
		[NativeMethod(Name = "PhysicsWorld::GetJointThresholdCallbackTargets", IsThreadSafe = true)]
		internal static PhysicsCallbacks.JointThresholdCallbackTargets PhysicsWorld_GetJointThresholdCallbackTargets(PhysicsWorld world, Allocator allocator); // 0x00000001822D1E60-0x00000001822D1EC0
		[NativeMethod(Name = "PhysicsWorld::GetRenderMaterial", IsThreadSafe = true)]
		internal static Material PhysicsWorld_GetRenderMaterial(string editorResourceName, string playerResourceName); // 0x00000001822D1F10-0x00000001822D21C0
		[NativeMethod(Name = "PhysicsWorld::DrawAllWorlds")]
		internal static void PhysicsWorld_DrawAllWorlds(PhysicsAABB drawAABB, PhysicsWorld.DrawTarget cameraTarget); // 0x00000001822D1BC0-0x00000001822D1C00
		private static void PhysicsBody_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D1240-0x00000001822D1290
		private static bool PhysicsBody_IsValid_Injected(in PhysicsBody body); // 0x00000001822D12F0-0x00000001822D1330
		private static object PhysicsBody_GetCallbackTarget_Injected(in PhysicsBody body); // 0x00000001822D11C0-0x00000001822D1200
		private static void PhysicsChain_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D1370-0x00000001822D13C0
		private static bool PhysicsJoint_IsValid_Injected(in PhysicsJoint joint); // 0x00000001822D16A0-0x00000001822D16E0
		private static object PhysicsJoint_GetCallbackTarget_Injected(in PhysicsJoint joint); // 0x00000001822D1620-0x00000001822D1660
		private static void DistanceJoint_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D0F00-0x00000001822D0F50
		private static void RelativeJoint_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D2420-0x00000001822D2470
		private static void SliderJoint_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D24E0-0x00000001822D2530
		private static void HingeJoint_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D1080-0x00000001822D10D0
		private static void FixedJoint_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D0FC0-0x00000001822D1010
		private static void WheelJoint_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D25A0-0x00000001822D25F0
		private static void PhysicsRotate_CreateAngle_Injected(float angle, ); // 0x00000001822D1720-0x00000001822D1770
		private static bool PhysicsRotate_IsValid_Injected(in PhysicsRotate rotation); // 0x00000001822D18B0-0x00000001822D18F0
		private static float PhysicsRotate_GetAngle_Injected(in PhysicsRotate rotate); // 0x00000001822D1770-0x00000001822D17B0
		private static void PhysicsRotate_IntegrateRotation_Injected(in PhysicsRotate rotation, float deltaAngle, ); // 0x00000001822D17F0-0x00000001822D1850
		private static bool PhysicsAABB_IsValid_Injected(in PhysicsAABB aabb); // 0x00000001822D1140-0x00000001822D1180
		private static IntPtr PhysicsGlobal_GetObject_Injected(in EntityId entityId); // 0x00000001822D1580-0x00000001822D15C0
		private static void PhysicsGlobal_CalculateWorldTransformWrite_Injected(in PhysicsWorld world, PhysicsWorld.TransformPlane transformPlane, in PhysicsWorld.TransformPlaneCustom transformPlaneCustom, PhysicsWorld.TransformWriteMode transformWriteMode, IntPtr transformAccessArrayIntPtr, ); // 0x00000001822D14A0-0x00000001822D1500
		private static void PhysicsShape_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D19B0-0x00000001822D1A00
		private static void PhysicsShape_GetDefaultSurfaceMaterial_Injected(bool useSettings, ); // 0x00000001822D1A60-0x00000001822D1AB0
		private static bool PhysicsShape_IsValid_Injected(in PhysicsShape shape); // 0x00000001822D1B00-0x00000001822D1B40
		private static object PhysicsShape_GetCallbackTarget_Injected(in PhysicsShape shape); // 0x00000001822D1930-0x00000001822D1970
		private static void PhysicsCore2D_UnregisterTransformWatcher_Injected(IntPtr transform); // 0x00000001822D1420-0x00000001822D1460
		private static void PhysicsWorld_GetDefaultDefinition_Injected(bool useSettings, ); // 0x00000001822D1D60-0x00000001822D1DB0
		private static bool PhysicsWorld_IsValid_Injected(in PhysicsWorld world); // 0x00000001822D2270-0x00000001822D22B0
		private static void PhysicsWorld_SetTransformWriteTweens_Injected(in PhysicsWorld world, ref ManagedSpanWrapper transformWriteTweens); // 0x00000001822D22F0-0x00000001822D2340
		private static void PhysicsWorld_SetTransform_Injected(IntPtr transform, ref Vector3 position, ref Quaternion rotation, bool transformChangedEvent); // 0x00000001822D23B0-0x00000001822D2420
		private static void PhysicsWorld_GetBodyUpdateCallbackTargets_Injected(in PhysicsWorld world, Allocator allocator, ); // 0x00000001822D1C00-0x00000001822D1C50
		private static void PhysicsWorld_GetTriggerCallbackTargets_Injected(in PhysicsWorld world, Allocator allocator, ); // 0x00000001822D21C0-0x00000001822D2210
		private static void PhysicsWorld_GetContactCallbackTargets_Injected(in PhysicsWorld world, Allocator allocator, ); // 0x00000001822D1CB0-0x00000001822D1D00
		private static void PhysicsWorld_GetJointThresholdCallbackTargets_Injected(in PhysicsWorld world, Allocator allocator, ); // 0x00000001822D1E10-0x00000001822D1E60
		private static IntPtr PhysicsWorld_GetRenderMaterial_Injected(ref ManagedSpanWrapper editorResourceName, ref ManagedSpanWrapper playerResourceName); // 0x00000001822D1EC0-0x00000001822D1F10
		private static void PhysicsWorld_DrawAllWorlds_Injected(in PhysicsAABB drawAABB, PhysicsWorld.DrawTarget cameraTarget); // 0x00000001822D1B80-0x00000001822D1BC0
	}
}
