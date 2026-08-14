namespace UnityEngine;

[RequiredByNativeCode(Optional = True)]
public struct ParticleCollisionEvent
{
	internal Vector3 m_Intersection; //Field offset: 0x0
	internal Vector3 m_Normal; //Field offset: 0xC
	internal Vector3 m_Velocity; //Field offset: 0x18
	internal int m_ColliderInstanceID; //Field offset: 0x24

}

