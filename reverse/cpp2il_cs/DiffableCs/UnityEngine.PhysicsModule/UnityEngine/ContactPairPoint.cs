namespace UnityEngine;

[IsReadOnly]
[UsedByNativeCode]
public struct ContactPairPoint
{
	internal readonly Vector3 m_Position; //Field offset: 0x0
	internal readonly float m_Separation; //Field offset: 0xC
	internal readonly Vector3 m_Normal; //Field offset: 0x10
	internal readonly uint m_InternalFaceIndex0; //Field offset: 0x1C
	internal readonly Vector3 m_Impulse; //Field offset: 0x20
	internal readonly uint m_InternalFaceIndex1; //Field offset: 0x2C

	public Vector3 impulse
	{
		 get { } //Length: 19
	}

	public Vector3 normal
	{
		 get { } //Length: 19
	}

	public Vector3 position
	{
		 get { } //Length: 18
	}

	public float separation
	{
		 get { } //Length: 6
	}

	public Vector3 get_impulse() { }

	public Vector3 get_normal() { }

	public Vector3 get_position() { }

	public float get_separation() { }

}

