namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Public/PhysicsSceneHandle2D.h")]
public struct PhysicsScene2D : IEquatable<PhysicsScene2D>
{
	private int m_Handle; //Field offset: 0x0

	public virtual bool Equals(object other) { }

	public override bool Equals(PhysicsScene2D other) { }

	public virtual int GetHashCode() { }

	public RaycastHit2D GetRayIntersection(Ray ray, float distance, int layerMask = -5) { }

	public int GetRayIntersection(Ray ray, float distance, RaycastHit2D[] results, int layerMask = -5) { }

	[NativeMethod("GetRayIntersection_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType::DoubleColon (2))]
	private static RaycastHit2D GetRayIntersection_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask) { }

	private static void GetRayIntersection_Internal_Injected(in PhysicsScene2D physicsScene, in Vector3 origin, in Vector3 direction, float distance, int layerMask, out RaycastHit2D ret) { }

	[NativeMethod("GetRayIntersectionArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType::DoubleColon (2))]
	private static int GetRayIntersectionArray_Internal(PhysicsScene2D physicsScene, Vector3 origin, Vector3 direction, float distance, int layerMask, RaycastHit2D[] results) { }

	private static int GetRayIntersectionArray_Internal_Injected(in PhysicsScene2D physicsScene, in Vector3 origin, in Vector3 direction, float distance, int layerMask, ref ManagedSpanWrapper results) { }

	public RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask = -5) { }

	public RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter) { }

	public int Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, RaycastHit2D[] results) { }

	public int Raycast(Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, List<RaycastHit2D> results) { }

	[NativeMethod("Raycast_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType::DoubleColon (2))]
	private static RaycastHit2D Raycast_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter) { }

	private static void Raycast_Internal_Injected(in PhysicsScene2D physicsScene, in Vector2 origin, in Vector2 direction, float distance, in ContactFilter2D contactFilter, out RaycastHit2D ret) { }

	[NativeMethod("RaycastArray_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType::DoubleColon (2))]
	private static int RaycastArray_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, RaycastHit2D[] results) { }

	private static int RaycastArray_Internal_Injected(in PhysicsScene2D physicsScene, in Vector2 origin, in Vector2 direction, float distance, in ContactFilter2D contactFilter, ref ManagedSpanWrapper results) { }

	[NativeMethod("RaycastList_Binding")]
	[StaticAccessor("PhysicsQuery2D", StaticAccessorType::DoubleColon (2))]
	private static int RaycastList_Internal(PhysicsScene2D physicsScene, Vector2 origin, Vector2 direction, float distance, ContactFilter2D contactFilter, List<RaycastHit2D> results) { }

	private static int RaycastList_Internal_Injected(in PhysicsScene2D physicsScene, in Vector2 origin, in Vector2 direction, float distance, in ContactFilter2D contactFilter, ref BlittableListWrapper results) { }

	public virtual string ToString() { }

}

