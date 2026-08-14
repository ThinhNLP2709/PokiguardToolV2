namespace UnityEngine;

[NativeHeader("Modules/Physics/Public/PhysicsSceneHandle.h")]
[NativeHeader("Modules/Physics/PhysicsQuery.h")]
public struct PhysicsScene : IEquatable<PhysicsScene>
{
	private int m_Handle; //Field offset: 0x0

	public virtual bool Equals(object other) { }

	public override bool Equals(PhysicsScene other) { }

	public virtual int GetHashCode() { }

	[FreeFunction("Physics::Raycast")]
	private static bool Internal_Raycast(PhysicsScene physicsScene, Ray ray, float maxDistance, ref RaycastHit hit, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { }

	private static bool Internal_Raycast_Injected(in PhysicsScene physicsScene, in Ray ray, float maxDistance, ref RaycastHit hit, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { }

	[FreeFunction("Physics::RaycastNonAlloc")]
	private static int Internal_RaycastNonAlloc(PhysicsScene physicsScene, Ray ray, RaycastHit[] raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction) { }

	private static int Internal_RaycastNonAlloc_Injected(in PhysicsScene physicsScene, in Ray ray, ref ManagedSpanWrapper raycastHits, float maxDistance, int mask, QueryTriggerInteraction queryTriggerInteraction) { }

	[FreeFunction("Physics::RaycastTest")]
	private static bool Internal_RaycastTest(PhysicsScene physicsScene, Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { }

	private static bool Internal_RaycastTest_Injected(in PhysicsScene physicsScene, in Ray ray, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction) { }

	public bool Raycast(Vector3 origin, Vector3 direction, float maxDistance = ∞, int layerMask = -5, QueryTriggerInteraction queryTriggerInteraction = 0) { }

	public bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance = ∞, int layerMask = -5, QueryTriggerInteraction queryTriggerInteraction = 0) { }

	public int Raycast(Vector3 origin, Vector3 direction, RaycastHit[] raycastHits, float maxDistance = ∞, int layerMask = -5, QueryTriggerInteraction queryTriggerInteraction = 0) { }

	public virtual string ToString() { }

}

