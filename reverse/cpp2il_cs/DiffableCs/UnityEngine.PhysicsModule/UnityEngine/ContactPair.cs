namespace UnityEngine;

[IsReadOnly]
[UsedByNativeCode]
public struct ContactPair
{
	internal readonly int m_ColliderID; //Field offset: 0x0
	internal readonly int m_OtherColliderID; //Field offset: 0x4
	internal readonly IntPtr m_StartPtr; //Field offset: 0x8
	internal readonly uint m_NbPoints; //Field offset: 0x10
	internal readonly CollisionPairFlags m_Flags; //Field offset: 0x14
	internal readonly CollisionPairEventFlags m_Events; //Field offset: 0x16
	internal readonly Vector3 m_ImpulseSum; //Field offset: 0x18

	public Collider collider
	{
		 get { } //Length: 88
	}

	internal bool hasRemovedCollider
	{
		internal get { } //Length: 20
	}

	public Vector3 impulseSum
	{
		 get { } //Length: 19
	}

	public bool isCollisionEnter
	{
		 get { } //Length: 8
	}

	public bool isCollisionExit
	{
		 get { } //Length: 8
	}

	public bool isCollisionStay
	{
		 get { } //Length: 8
	}

	public Collider otherCollider
	{
		 get { } //Length: 90
	}

	internal int ExtractContactsArray(ContactPoint[] managedContainer, bool flipped) { }

	public Collider get_collider() { }

	internal bool get_hasRemovedCollider() { }

	public Vector3 get_impulseSum() { }

	public bool get_isCollisionEnter() { }

	public bool get_isCollisionExit() { }

	public bool get_isCollisionStay() { }

	public Collider get_otherCollider() { }

	public ContactPairPoint GetContactPoint(int index) { }

	internal ContactPairPoint* GetContactPoint_Internal(int index) { }

}

