/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	[NativeHeader("Modules/Physics/PhysicsQuery.h")]
	[NativeHeader("Modules/Physics/Public/PhysicsSceneHandle.h")]
	public struct PhysicsScene : IEquatable<UnityEngine.PhysicsScene> // TypeDefIndex: 15442
	{
		// Fields
		private int m_index; // 0x00
		private int m_version; // 0x04
	
		// Methods
		public override string ToString(); // 0x00000001822D5AD0-0x00000001822D5B50
		public static bool operator ==(PhysicsScene lhs, PhysicsScene rhs); // 0x000000018192DC90-0x000000018192DCB0
		public override int GetHashCode(); // 0x00000001822D5510-0x00000001822D5570
		public override bool Equals(object other); // 0x00000001822D5480-0x00000001822D5510
		public bool Equals(PhysicsScene other); // 0x000000018192DA40-0x000000018192DA60
		internal static PhysicsScene GetDefaultScene(); // 0x0000000180E5ACD0-0x0000000180E5ACE0
		public bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, [DefaultValue("Mathf.Infinity")] float maxDistance = 1F / 0F /* Metadata: 0x006AA038 */, [DefaultValue("Physics.DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA03C */, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal /* Metadata: 0x006AA03D */); // 0x00000001822D5950-0x00000001822D5AD0
		[FreeFunction("Physics::Raycast")]
		private static bool Internal_Raycast(PhysicsScene physicsScene, Ray ray, float maxDistance, ref RaycastHit hit, int layerMask, QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D5710-0x00000001822D5780
		public int Raycast(Vector3 origin, Vector3 direction, RaycastHit[] raycastHits, [DefaultValue("Mathf.Infinity")] float maxDistance = 1F / 0F /* Metadata: 0x006AA03E */, [DefaultValue("Physics.DefaultRaycastLayers")] int layerMask = -5 /* Metadata: 0x006AA042 */, [DefaultValue("QueryTriggerInteraction.UseGlobal")] QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal /* Metadata: 0x006AA043 */); // 0x00000001822D5780-0x00000001822D5950
		[FreeFunction("Physics::RaycastNonAlloc")]
		private static int Internal_RaycastNonAlloc(PhysicsScene physicsScene, Ray ray, RaycastHit[] raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D55E0-0x00000001822D56A0
		private static bool Internal_Raycast_Injected(in PhysicsScene physicsScene, in Ray ray, float maxDistance, ref RaycastHit hit, int layerMask, QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D56A0-0x00000001822D5710
		private static int Internal_RaycastNonAlloc_Injected(in PhysicsScene physicsScene, in Ray ray, ref ManagedSpanWrapper raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction); // 0x00000001822D5570-0x00000001822D55E0
	}
}
