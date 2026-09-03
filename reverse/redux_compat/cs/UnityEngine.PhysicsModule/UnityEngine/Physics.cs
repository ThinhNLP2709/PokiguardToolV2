/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[NativeHeader("Modules/Physics/PhysicsQuery.h")]
	[NativeHeader("Modules/Physics/PhysicsManager.h")]
	[StaticAccessor("GetPhysicsManager()", StaticAccessorType.Dot)]
	public class Physics // TypeDefIndex: 15423
	{
		// Fields
		[CompilerGenerated]
		private static Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEvent; // 0x00
		[CompilerGenerated]
		private static Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEventCCD; // 0x08
		[CompilerGenerated]
		private static Action<PhysicsScene, IntPtr, int, bool> GenericContactModifyEvent; // 0x10
		[CompilerGenerated]
		private static ContactEventDelegate ContactEvent; // 0x18
		[AutoStaticsCleanupOnCodeReload(CleanupStrategy = CleanupStrategy.Clear)]
		private static readonly Collision s_ReusableCollision; // 0x20
		private static readonly ProfilerMarker s_ContactEventMarker; // 0x28
		private static readonly ProfilerMarker s_InvokeOnCollisionEventsMarker; // 0x30
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x38
	
		// Properties
		public static bool invokeCollisionCallbacks { get; } // 0x00000001822D8230-0x00000001822D8260 
		public static PhysicsScene defaultPhysicsScene { get; } // 0x0000000180E5ACD0-0x0000000180E5ACE0 
		public static bool reuseCollisionCallbacks { get; } // 0x00000001822D8260-0x00000001822D8290 
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEvent {
			add; // 0x00000001822D8140-0x00000001822D8230
			remove; // 0x00000001822D8450-0x00000001822D8540
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<PhysicsScene, NativeArray<ModifiableContactPair>> ContactModifyEventCCD {
			add; // 0x00000001822D8050-0x00000001822D8140
			remove; // 0x00000001822D8360-0x00000001822D8450
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event ContactEventDelegate ContactEvent {
			add; // 0x00000001822D7F80-0x00000001822D8050
			remove; // 0x00000001822D8290-0x00000001822D8360
		}
	
		// Nested types
		public delegate void ContactEventDelegate(PhysicsScene scene, NativeArray<ContactPairHeader> headerArray); // TypeDefIndex: 15424; 0x0000000180A71070-0x0000000180A710A0
	
		// Constructors
		static Physics(); // 0x00000001822D7CF0-0x00000001822D7F80
	
		// Methods
		[RequiredByNativeCode]
		private static void OnSceneContactModify(PhysicsScene scene, IntPtr buffer, int count, bool isCCD); // 0x00000001822D61E0-0x00000001822D6290
		private static void PhysXOnSceneContactModify(PhysicsScene scene, IntPtr buffer, int count, bool isCCD); // 0x00000001822D6530-0x00000001822D6620
		[NativeMethod(IsThreadSafe = true)]
		private static void GetCurrentIntegrationInfo(out IntPtr integration); // 0x00000001822D5EE0-0x00000001822D5F20
		public static IntegrationInfo GetCurrentIntegrationInfo(); // 0x00000001822D5F20-0x00000001822D6020
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D6EE0-0x00000001822D6FC0
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask); // 0x00000001822D6E00-0x00000001822D6EE0
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, [DefaultValue("Mathf.Infinity")] float maxDistance, [DefaultValue("DefaultRaycastLayers")] int layerMask, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D6FC0-0x00000001822D70A0
		[ExcludeFromDocs]
		public static bool Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask); // 0x00000001822D6CF0-0x00000001822D6E00
		[FreeFunction("Physics::RaycastAll")]
		private static RaycastHit[] Internal_RaycastAll(PhysicsScene physicsScene, Ray ray, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D6090-0x00000001822D61E0
		public static RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, [DefaultValue("Mathf.Infinity")] float maxDistance, [DefaultValue("DefaultRaycastLayers")] int layerMask, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D6880-0x00000001822D6A50
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public static RaycastHit[] RaycastAll(Ray ray, float maxDistance, int layerMask); // 0x00000001822D6620-0x00000001822D6880
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public static int RaycastNonAlloc(Ray ray, RaycastHit[] results, float maxDistance, int layerMask); // 0x00000001822D6A50-0x00000001822D6CF0
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static Collider GetColliderByInstanceID(EntityId entityId); // 0x00000001822D5C50-0x00000001822D5CD0
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		internal static Component GetBodyByInstanceID(EntityId entityId); // 0x00000001822D5B90-0x00000001822D5C10
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		private static void SendOnCollisionEnter(Component component, Collision collision); // 0x00000001822D75B0-0x00000001822D7630
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		private static void SendOnCollisionStay(Component component, Collision collision); // 0x00000001822D7750-0x00000001822D77D0
		[StaticAccessor("PhysicsManager", StaticAccessorType.DoubleColon)]
		private static void SendOnCollisionExit(Component component, Collision collision); // 0x00000001822D7680-0x00000001822D7700
		[RequiredByNativeCode]
		private static void OnSceneContact(PhysicsScene scene, IntPtr buffer, int count); // 0x00000001822D6290-0x00000001822D6530
		private static void ReportContacts(NativeArray<ContactPairHeader> array); // 0x00000001822D70A0-0x00000001822D7560
		private static Collision GetCollisionToReport([IsReadOnly] in ContactPairHeader header, [IsReadOnly] in ContactPair pair, bool flipped); // 0x00000001822D5CD0-0x00000001822D5EE0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822D77D0-0x00000001822D7CF0
		private static void Internal_RaycastAll_Injected(in PhysicsScene physicsScene, in Ray ray, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction, ); // 0x00000001822D6020-0x00000001822D6090
		private static IntPtr GetColliderByInstanceID_Injected(in EntityId entityId); // 0x00000001822D5C10-0x00000001822D5C50
		private static IntPtr GetBodyByInstanceID_Injected(in EntityId entityId); // 0x00000001822D5B50-0x00000001822D5B90
		private static void SendOnCollisionEnter_Injected(IntPtr component, Collision collision); // 0x00000001822D7560-0x00000001822D75B0
		private static void SendOnCollisionStay_Injected(IntPtr component, Collision collision); // 0x00000001822D7700-0x00000001822D7750
		private static void SendOnCollisionExit_Injected(IntPtr component, Collision collision); // 0x00000001822D7630-0x00000001822D7680
	}
}
